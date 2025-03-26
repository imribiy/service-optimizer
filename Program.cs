using ServiceOptimizer;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;

namespace ServiceOptimizer
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if (!IsRunAsAdmin())
            {
                LogPsExecUsage();
                RunWithPsExec();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static bool IsRunAsAdmin()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private static void RunWithPsExec()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "ServiceOptimizer.Resources.PsExec.exe";

            var tempPath = Path.Combine(Path.GetTempPath(), "PsExec.exe");
            using (var resource = assembly.GetManifestResourceStream(resourceName))
            using (var file = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
            {
                resource.CopyTo(file);
            }

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = tempPath,
                    Arguments = $"-s -i -d \"{assembly.Location}\"",
                    UseShellExecute = false,
                }
            };
            process.Start();
            process.WaitForExit();

            // Clean up
            File.Delete(tempPath);
        }

        private static void LogPsExecUsage()
        {
            var logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ServiceOptimizerLog.txt");
            using (var logFile = new StreamWriter(logFilePath, true))
            {
                logFile.WriteLine("PsExec Usage Log");
                logFile.WriteLine($"PsExec was used at: {DateTime.Now}");
                logFile.WriteLine();
            }
        }
    }
}