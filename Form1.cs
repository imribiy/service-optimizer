using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Drawing;

namespace ServiceOptimizer
{
    public partial class MainForm : Form
    {
        private List<ServiceController> allServices;
        private HashSet<string> checkedServices;
        private readonly string psexecPath;

        public MainForm()
        {
            InitializeComponent();
            psexecPath = Path.Combine(Path.GetTempPath(), "PsExec.exe");
            LoadServices();
        }

        private void LoadServices()
        {
            checkedServices = new HashSet<string>();
            allServices = ServiceController.GetServices().ToList();
            UpdateServiceList(allServices.Where(s => s.Status == ServiceControllerStatus.Running).ToList(), checkedListBoxRunningServices);
            UpdateServiceList(allServices.Where(s => GetServiceStartupType(s.ServiceName) == "Automatic" || GetServiceStartupType(s.ServiceName) == "Boot" || GetServiceStartupType(s.ServiceName) == "System").ToList(), checkedListBoxStartupServices);
        }

        private void UpdateServiceList(List<ServiceController> services, CheckedListBox checkedListBox)
        {
            checkedListBox.ItemCheck -= checkedListBox_ItemCheck;
            checkedListBox.Items.Clear();
            foreach (var service in services)
            {
                checkedListBox.Items.Add(service.DisplayName, checkedServices.Contains(service.ServiceName));
            }
            checkedListBox.ItemCheck += checkedListBox_ItemCheck;
        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var checkedListBox = sender as CheckedListBox;
            var serviceName = allServices.FirstOrDefault(s => s.DisplayName == checkedListBox.Items[e.Index].ToString())?.ServiceName;

            if (e.NewValue == CheckState.Checked)
            {
                checkedServices.Add(serviceName);
            }
            else
            {
                checkedServices.Remove(serviceName);
            }
        }

        private void textBoxSearchRunning_TextChanged(object sender, EventArgs e)
        {
            var query = textBoxSearchRunning.Text.ToLower();
            var filteredServices = allServices.Where(s => s.Status == ServiceControllerStatus.Running && s.DisplayName.ToLower().Contains(query)).ToList();
            UpdateServiceList(filteredServices, checkedListBoxRunningServices);
        }

        private void textBoxSearchStartup_TextChanged(object sender, EventArgs e)
        {
            var query = textBoxSearchStartup.Text.ToLower();
            var filteredServices = allServices.Where(s => (GetServiceStartupType(s.ServiceName) == "Automatic" || GetServiceStartupType(s.ServiceName) == "Boot" || GetServiceStartupType(s.ServiceName) == "System") && s.DisplayName.ToLower().Contains(query)).ToList();
            UpdateServiceList(filteredServices, checkedListBoxStartupServices);
        }

        private void checkedListBoxServices_MouseDown(object sender, MouseEventArgs e)
        {
            var checkedListBox = sender as CheckedListBox;
            var index = checkedListBox.IndexFromPoint(e.Location);

            if (index != ListBox.NoMatches)
            {
                Rectangle checkboxRectangle = checkedListBox.GetItemRectangle(index);
                checkboxRectangle.Width = 16; // Width of the checkbox
                if (checkboxRectangle.Contains(e.Location))
                {
                    bool isChecked = checkedListBox.GetItemChecked(index);
                    checkedListBox.SetItemChecked(index, !isChecked);
                }
            }
        }

        private void buttonDisableServices_Click(object sender, EventArgs e)
        {
            if (!IsAdministrator())
            {
                MessageBox.Show("Please run this application as an administrator.", "Administrator Privileges Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var services = ServiceController.GetServices().ToList();
            var logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ServiceOptimizerLog.txt");

            using (var logFile = new StreamWriter(logFilePath))
            {
                logFile.WriteLine("Service Optimizer Log");
                logFile.WriteLine($"Run Date: {DateTime.Now}");
                logFile.WriteLine();

                foreach (var serviceName in checkedServices)
                {
                    var baseServiceName = GetBaseServiceName(serviceName);
                    try
                    {
                        var previousStartupType = GetServiceStartupType(baseServiceName);
                        DisableService(baseServiceName);

                        logFile.WriteLine($"Service: {baseServiceName}");
                        logFile.WriteLine($"Previous Startup Type: {previousStartupType}");
                        logFile.WriteLine("Status: Disabled");
                        logFile.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        logFile.WriteLine($"Service: {baseServiceName}");
                        logFile.WriteLine("Status: Failed to disable");
                        logFile.WriteLine($"Reason: {ex.Message}");
                        logFile.WriteLine();
                    }
                }
            }

            MessageBox.Show($"Log file created at: {logFilePath}", "Operation Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DisableService(string serviceName)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = psexecPath,
                    Arguments = $"-s sc config \"{serviceName}\" start= disabled",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            process.WaitForExit();
        }

        private bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private string GetServiceStartupType(string serviceName)
        {
            var key = Registry.LocalMachine.OpenSubKey($@"SYSTEM\CurrentControlSet\Services\{serviceName}");
            var value = key?.GetValue("Start");
            if (value == null) return "Unknown";
            switch ((int)value)
            {
                case 0:
                    return "Boot";
                case 1:
                    return "System";
                case 2:
                    return "Automatic";
                case 3:
                    return "Manual";
                case 4:
                    return "Disabled";
                default:
                    return "Unknown";
            }
        }

        private void SetServiceStartupType(string serviceName, string startupType)
        {
            var key = Registry.LocalMachine.OpenSubKey($@"SYSTEM\CurrentControlSet\Services\{serviceName}", true);
            if (key == null) throw new ArgumentException("Service not found");
            switch (startupType)
            {
                case "Automatic":
                    key.SetValue("Start", 2);
                    break;
                case "Manual":
                    key.SetValue("Start", 3);
                    break;
                case "Disabled":
                    key.SetValue("Start", 4);
                    break;
                default:
                    throw new ArgumentException("Invalid startup type");
            }
        }

        private string GetBaseServiceName(string serviceName)
        {
            if (serviceName.Length > 6 && serviceName[serviceName.Length - 6] == '_')
            {
                return serviceName.Substring(0, serviceName.Length - 6);
            }
            return serviceName;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists(psexecPath))
            {
                File.Delete(psexecPath);
            }
        }
    }
}