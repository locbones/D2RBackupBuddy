namespace D2RBackupBuddy
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dropModChoice = new ComboBox();
            textD2RPath = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textSavePath = new TextBox();
            timerBackup = new System.Windows.Forms.Timer(components);
            label6 = new Label();
            textBackupValue = new TextBox();
            dropBackupValue = new ComboBox();
            textBackupLog = new RichTextBox();
            label7 = new Label();
            btnUpdateStatus = new Button();
            label8 = new Label();
            label9 = new Label();
            dropRestore = new ComboBox();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            openToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            checkMinimize = new CheckBox();
            checkBindD2R = new CheckBox();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dropModChoice
            // 
            dropModChoice.FormattingEnabled = true;
            dropModChoice.Items.AddRange(new object[] { "Retail" });
            dropModChoice.Location = new Point(23, 137);
            dropModChoice.Name = "dropModChoice";
            dropModChoice.Size = new Size(121, 23);
            dropModChoice.TabIndex = 0;
            dropModChoice.SelectedIndexChanged += dropModChoice_SelectedIndexChanged;
            // 
            // textD2RPath
            // 
            textD2RPath.Location = new Point(112, 12);
            textD2RPath.Name = "textD2RPath";
            textD2RPath.Size = new Size(417, 23);
            textD2RPath.TabIndex = 1;
            textD2RPath.Enter += textD2RPath_Enter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(9, 16);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 2;
            label1.Text = "My D2R Location:";
            // 
            // label2
            // 
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(517, 15);
            label2.TabIndex = 3;
            label2.Text = "(Please choose the folder location where D2R.exe exists)";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(23, 119);
            label3.Name = "label3";
            label3.Size = new Size(121, 15);
            label3.TabIndex = 4;
            label3.Text = "My Mod:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Location = new Point(12, 91);
            label4.Name = "label4";
            label4.Size = new Size(517, 15);
            label4.TabIndex = 7;
            label4.Text = "(Please choose the base folder location where your save files exist)";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(9, 69);
            label5.Name = "label5";
            label5.Size = new Size(107, 15);
            label5.TabIndex = 6;
            label5.Text = "My Save Location:";
            // 
            // textSavePath
            // 
            textSavePath.Location = new Point(112, 65);
            textSavePath.Name = "textSavePath";
            textSavePath.Size = new Size(417, 23);
            textSavePath.TabIndex = 5;
            textSavePath.Enter += textSavePath_Enter;
            // 
            // timerBackup
            // 
            timerBackup.Tick += timerBackup_Tick;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(14, 170);
            label6.Name = "label6";
            label6.Size = new Size(142, 15);
            label6.TabIndex = 8;
            label6.Text = "Backup Frequency:";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBackupValue
            // 
            textBackupValue.BorderStyle = BorderStyle.FixedSingle;
            textBackupValue.Location = new Point(23, 188);
            textBackupValue.Name = "textBackupValue";
            textBackupValue.Size = new Size(40, 23);
            textBackupValue.TabIndex = 9;
            textBackupValue.TextAlign = HorizontalAlignment.Center;
            textBackupValue.TextChanged += textBackupValue_TextChanged;
            // 
            // dropBackupValue
            // 
            dropBackupValue.FormattingEnabled = true;
            dropBackupValue.Items.AddRange(new object[] { "Second(s)", "Minute(s)", "Hour(s)" });
            dropBackupValue.Location = new Point(69, 188);
            dropBackupValue.Name = "dropBackupValue";
            dropBackupValue.Size = new Size(75, 23);
            dropBackupValue.TabIndex = 10;
            dropBackupValue.SelectedIndexChanged += dropBackupValue_SelectedIndexChanged;
            // 
            // textBackupLog
            // 
            textBackupLog.Location = new Point(9, 257);
            textBackupLog.Name = "textBackupLog";
            textBackupLog.Size = new Size(526, 204);
            textBackupLog.TabIndex = 11;
            textBackupLog.Text = "";
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(9, 239);
            label7.Name = "label7";
            label7.Size = new Size(526, 15);
            label7.TabIndex = 12;
            label7.Text = "My Backup Log";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.BackColor = Color.Transparent;
            btnUpdateStatus.BackgroundImage = Properties.Resources.BackupDisabled;
            btnUpdateStatus.BackgroundImageLayout = ImageLayout.Stretch;
            btnUpdateStatus.Location = new Point(242, 141);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new Size(53, 51);
            btnUpdateStatus.TabIndex = 13;
            btnUpdateStatus.Tag = "Disabled";
            btnUpdateStatus.UseVisualStyleBackColor = false;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(244, 119);
            label8.Name = "label8";
            label8.Size = new Size(51, 15);
            label8.TabIndex = 14;
            label8.Text = "Status:";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(383, 119);
            label9.Name = "label9";
            label9.Size = new Size(146, 15);
            label9.TabIndex = 15;
            label9.Text = "Restore Character:";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dropRestore
            // 
            dropRestore.FormattingEnabled = true;
            dropRestore.Items.AddRange(new object[] { "Retail" });
            dropRestore.Location = new Point(395, 141);
            dropRestore.Name = "dropRestore";
            dropRestore.Size = new Size(121, 23);
            dropRestore.TabIndex = 16;
            dropRestore.SelectedIndexChanged += dropRestore_SelectedIndexChanged;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipText = "Test";
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(104, 48);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(103, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(103, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // checkMinimize
            // 
            checkMinimize.AutoSize = true;
            checkMinimize.CheckAlign = ContentAlignment.TopCenter;
            checkMinimize.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkMinimize.Location = new Point(383, 169);
            checkMinimize.Name = "checkMinimize";
            checkMinimize.Size = new Size(147, 33);
            checkMinimize.TabIndex = 17;
            checkMinimize.Text = "Minimize to System Tray";
            checkMinimize.UseVisualStyleBackColor = true;
            checkMinimize.CheckedChanged += checkMinimize_CheckedChanged;
            // 
            // checkBindD2R
            // 
            checkBindD2R.AutoSize = true;
            checkBindD2R.CheckAlign = ContentAlignment.TopCenter;
            checkBindD2R.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBindD2R.Location = new Point(417, 208);
            checkBindD2R.Name = "checkBindD2R";
            checkBindD2R.Size = new Size(78, 33);
            checkBindD2R.TabIndex = 18;
            checkBindD2R.Text = "Bind to D2R";
            checkBindD2R.UseVisualStyleBackColor = true;
            checkBindD2R.CheckedChanged += checkBindD2R_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 470);
            Controls.Add(checkBindD2R);
            Controls.Add(checkMinimize);
            Controls.Add(dropRestore);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(btnUpdateStatus);
            Controls.Add(label7);
            Controls.Add(textBackupLog);
            Controls.Add(dropBackupValue);
            Controls.Add(textBackupValue);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(textSavePath);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textD2RPath);
            Controls.Add(dropModChoice);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "D2R Backup Buddy";
            Load += Form1_Load;
            Resize += Form1_Resize;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox dropModChoice;
        private TextBox textD2RPath;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textSavePath;
        private System.Windows.Forms.Timer timerBackup;
        private Label label6;
        private TextBox textBackupValue;
        private ComboBox dropBackupValue;
        private RichTextBox textBackupLog;
        private Label label7;
        private Button btnUpdateStatus;
        private Label label8;
        private Label label9;
        private ComboBox dropRestore;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private CheckBox checkMinimize;
        private CheckBox checkBindD2R;
    }
}
