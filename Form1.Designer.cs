namespace ServiceOptimizer
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageRunning = new System.Windows.Forms.TabPage();
            this.labelSearchRunning = new System.Windows.Forms.Label();
            this.textBoxSearchRunning = new System.Windows.Forms.TextBox();
            this.checkedListBoxRunningServices = new System.Windows.Forms.CheckedListBox();
            this.tabPageStartup = new System.Windows.Forms.TabPage();
            this.labelSearchStartup = new System.Windows.Forms.Label();
            this.textBoxSearchStartup = new System.Windows.Forms.TextBox();
            this.checkedListBoxStartupServices = new System.Windows.Forms.CheckedListBox();
            this.buttonDisableServices = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPageRunning.SuspendLayout();
            this.tabPageStartup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageRunning);
            this.tabControl.Controls.Add(this.tabPageStartup);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(460, 410);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageRunning
            // 
            this.tabPageRunning.Controls.Add(this.labelSearchRunning);
            this.tabPageRunning.Controls.Add(this.textBoxSearchRunning);
            this.tabPageRunning.Controls.Add(this.checkedListBoxRunningServices);
            this.tabPageRunning.Location = new System.Drawing.Point(4, 22);
            this.tabPageRunning.Name = "tabPageRunning";
            this.tabPageRunning.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRunning.Size = new System.Drawing.Size(452, 384);
            this.tabPageRunning.TabIndex = 0;
            this.tabPageRunning.Text = "Running Services";
            this.tabPageRunning.UseVisualStyleBackColor = true;
            // 
            // labelSearchRunning
            // 
            this.labelSearchRunning.AutoSize = true;
            this.labelSearchRunning.Location = new System.Drawing.Point(6, 15);
            this.labelSearchRunning.Name = "labelSearchRunning";
            this.labelSearchRunning.Size = new System.Drawing.Size(44, 13);
            this.labelSearchRunning.TabIndex = 2;
            this.labelSearchRunning.Text = "Search:";
            // 
            // textBoxSearchRunning
            // 
            this.textBoxSearchRunning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchRunning.Location = new System.Drawing.Point(56, 12);
            this.textBoxSearchRunning.Name = "textBoxSearchRunning";
            this.textBoxSearchRunning.Size = new System.Drawing.Size(390, 20);
            this.textBoxSearchRunning.TabIndex = 1;
            this.textBoxSearchRunning.TextChanged += new System.EventHandler(this.textBoxSearchRunning_TextChanged);
            // 
            // checkedListBoxRunningServices
            // 
            this.checkedListBoxRunningServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxRunningServices.FormattingEnabled = true;
            this.checkedListBoxRunningServices.Location = new System.Drawing.Point(6, 38);
            this.checkedListBoxRunningServices.Name = "checkedListBoxRunningServices";
            this.checkedListBoxRunningServices.Size = new System.Drawing.Size(440, 334);
            this.checkedListBoxRunningServices.TabIndex = 0;
            this.checkedListBoxRunningServices.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_ItemCheck);
            this.checkedListBoxRunningServices.MouseDown += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxServices_MouseDown);
            // 
            // tabPageStartup
            // 
            this.tabPageStartup.Controls.Add(this.labelSearchStartup);
            this.tabPageStartup.Controls.Add(this.textBoxSearchStartup);
            this.tabPageStartup.Controls.Add(this.checkedListBoxStartupServices);
            this.tabPageStartup.Location = new System.Drawing.Point(4, 22);
            this.tabPageStartup.Name = "tabPageStartup";
            this.tabPageStartup.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStartup.Size = new System.Drawing.Size(452, 384);
            this.tabPageStartup.TabIndex = 1;
            this.tabPageStartup.Text = "Startup Services";
            this.tabPageStartup.UseVisualStyleBackColor = true;
            // 
            // labelSearchStartup
            // 
            this.labelSearchStartup.AutoSize = true;
            this.labelSearchStartup.Location = new System.Drawing.Point(6, 15);
            this.labelSearchStartup.Name = "labelSearchStartup";
            this.labelSearchStartup.Size = new System.Drawing.Size(44, 13);
            this.labelSearchStartup.TabIndex = 5;
            this.labelSearchStartup.Text = "Search:";
            // 
            // textBoxSearchStartup
            // 
            this.textBoxSearchStartup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchStartup.Location = new System.Drawing.Point(56, 12);
            this.textBoxSearchStartup.Name = "textBoxSearchStartup";
            this.textBoxSearchStartup.Size = new System.Drawing.Size(390, 20);
            this.textBoxSearchStartup.TabIndex = 4;
            this.textBoxSearchStartup.TextChanged += new System.EventHandler(this.textBoxSearchStartup_TextChanged);
            // 
            // checkedListBoxStartupServices
            // 
            this.checkedListBoxStartupServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxStartupServices.FormattingEnabled = true;
            this.checkedListBoxStartupServices.Location = new System.Drawing.Point(6, 38);
            this.checkedListBoxStartupServices.Name = "checkedListBoxStartupServices";
            this.checkedListBoxStartupServices.Size = new System.Drawing.Size(440, 334);
            this.checkedListBoxStartupServices.TabIndex = 3;
            this.checkedListBoxStartupServices.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_ItemCheck);
            this.checkedListBoxStartupServices.MouseDown += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxServices_MouseDown);
            // 
            // buttonDisableServices
            // 
            this.buttonDisableServices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDisableServices.Location = new System.Drawing.Point(12, 428);
            this.buttonDisableServices.Name = "buttonDisableServices";
            this.buttonDisableServices.Size = new System.Drawing.Size(460, 23);
            this.buttonDisableServices.TabIndex = 1;
            this.buttonDisableServices.Text = "Disable Selected Services";
            this.buttonDisableServices.UseVisualStyleBackColor = true;
            this.buttonDisableServices.Click += new System.EventHandler(this.buttonDisableServices_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.buttonDisableServices);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Service Optimizer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.tabControl.ResumeLayout(false);
            this.tabPageRunning.ResumeLayout(false);
            this.tabPageRunning.PerformLayout();
            this.tabPageStartup.ResumeLayout(false);
            this.tabPageStartup.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageRunning;
        private System.Windows.Forms.TabPage tabPageStartup;
        private System.Windows.Forms.Button buttonDisableServices;
        private System.Windows.Forms.CheckedListBox checkedListBoxRunningServices;
        private System.Windows.Forms.CheckedListBox checkedListBoxStartupServices;
        private System.Windows.Forms.TextBox textBoxSearchRunning;
        private System.Windows.Forms.TextBox textBoxSearchStartup;
        private System.Windows.Forms.Label labelSearchRunning;
        private System.Windows.Forms.Label labelSearchStartup;
    }
}