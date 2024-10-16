using D2RBackupBuddy.Properties;
using System.Diagnostics;
using System.Windows.Forms;

namespace D2RBackupBuddy
{
    public partial class Form1 : Form
    {
        string appVersion = "1.0.0";

        public Form1()
        {
            InitializeComponent();
        }

        private void dropModChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.modChoice = dropModChoice.SelectedIndex;
            Properties.Settings.Default.Save();
            populateCharacterChoice();
        }

        private void textD2RPath_Enter(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(folderBrowserDialog.SelectedPath + "/D2R.exe"))
                    MessageBox.Show("D2R.exe not found!");
                else
                {
                    Properties.Settings.Default.gamePath = folderBrowserDialog.SelectedPath;
                    Properties.Settings.Default.Save();
                    textD2RPath.Text = Properties.Settings.Default.gamePath;
                    populateModChoice();
                }
            }
        }

        private void populateModChoice()
        {
            if (Path.Combine(Properties.Settings.Default.gamePath) != "")
            {
                string[] modFolders = Directory.GetDirectories(Path.Combine(Properties.Settings.Default.gamePath, "Mods"));
                dropModChoice.Items.Clear();
                dropModChoice.Items.Add("Retail");
                foreach (string subDirectory in modFolders)
                {
                    dropModChoice.Items.Add(Path.GetFileName(subDirectory));
                }
            }
        }

        private void populateCharacterChoice()
        {
            if (Properties.Settings.Default.savePath != "")
            {
                string[] charFolders = null;

                if (dropModChoice.SelectedIndex > 0)
                {
                    if (!Directory.Exists(Path.Combine(Properties.Settings.Default.savePath, "Mods", dropModChoice.Text, "Backups")))
                        Directory.CreateDirectory(Path.Combine(Properties.Settings.Default.savePath, "Mods", dropModChoice.Text, "Backups"));

                    charFolders = Directory.GetDirectories(Path.Combine(Properties.Settings.Default.savePath, "Mods", dropModChoice.Text, "Backups"));
                }
                else
                {
                    if (!Directory.Exists(Path.Combine(Properties.Settings.Default.savePath, "Backups")))
                        Directory.CreateDirectory(Path.Combine(Properties.Settings.Default.savePath, "Backups"));
                    charFolders = Directory.GetDirectories(Path.Combine(Properties.Settings.Default.savePath, "Backups"));
                }



                dropRestore.Items.Clear();


                foreach (string subDirectory in charFolders)
                {
                    dropRestore.Items.Add(Path.GetFileName(subDirectory));
                }
            }
        }

        private void textSavePath_Enter(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(folderBrowserDialog.SelectedPath + "/Settings.json"))
                    MessageBox.Show("Settings.json file not detected; this is not the correct save location");
                else
                {
                    Properties.Settings.Default.savePath = folderBrowserDialog.SelectedPath;
                    Properties.Settings.Default.Save();
                    textSavePath.Text = Properties.Settings.Default.savePath;
                    populateCharacterChoice();
                }
            }
        }

        private void startTimer()
        {
            int intervalMultiplier = 0;

            if (dropBackupValue.SelectedIndex == 0)
                intervalMultiplier = 1000;
            if (dropBackupValue.SelectedIndex == 1)
                intervalMultiplier = 60000;
            if (dropBackupValue.SelectedIndex == 2)
                intervalMultiplier = 3600000;

            if (timerBackup.Interval != 0 && intervalMultiplier != 0)
            {
                if (textBackupValue.Text != (timerBackup.Interval / intervalMultiplier).ToString())
                {
                    //MessageBox.Show("Not Same\n" + (timerBackup.Interval / intervalMultiplier).ToString());
                    timerBackup.Enabled = false;
                    timerBackup.Interval = Convert.ToInt16(textBackupValue.Text) * intervalMultiplier;
                    timerBackup.Enabled = true;
                }
                else
                {
                    timerBackup.Interval = Convert.ToInt16(textBackupValue.Text) * intervalMultiplier;
                }

                timerBackup.Start();
            }

        }

        private void performBackup()
        {
            string mostRecentCharacterName = null;
            string ActualSaveFilePath = "";
            string ActualBackupPath = "";
            var currentDate = DateTime.Now.ToString("MMMM d, yyyy");
            var currentTime = DateTime.Now.ToString("hh:mm tt");
            long fileSize = 0;

            //Check for retail usage
            if (dropModChoice.SelectedIndex == 0)
            {
                ActualSaveFilePath = Properties.Settings.Default.savePath;
                ActualBackupPath = Properties.Settings.Default.savePath + "/Backups";
            }
            else
            {
                ActualSaveFilePath = Properties.Settings.Default.savePath + "/Mods/" + dropModChoice.Text;
                ActualBackupPath = Properties.Settings.Default.savePath + "/Mods/" + dropModChoice.Text + "/Backups";
            }


            if (new DirectoryInfo(ActualSaveFilePath).GetFiles("*.d2s").Length >= 1)
            {
                // Backup Character
                FileInfo mostRecentCharacterFile = new DirectoryInfo(ActualSaveFilePath).GetFiles("*.d2s").OrderByDescending(o => o.LastWriteTime).First();
                mostRecentCharacterName = Path.GetFileNameWithoutExtension(mostRecentCharacterFile.Name);

                string mostRecentCharacterBackupFolder = Path.Combine(ActualSaveFilePath + "/Backups", mostRecentCharacterName);
                if (!Directory.Exists(mostRecentCharacterBackupFolder))
                    Directory.CreateDirectory(mostRecentCharacterBackupFolder);

                File.Copy(mostRecentCharacterFile.FullName, Path.Combine(mostRecentCharacterBackupFolder, mostRecentCharacterFile.Name + DateTime.Now.ToString("_MM_dd--hh_mmtt") + ".d2s"), true);

                // Backup Stash
                string mostRecentStashFileSC = Path.Combine(ActualSaveFilePath, "SharedStashSoftCoreV2.d2i");
                string mostRecentStashFileHC = Path.Combine(ActualSaveFilePath, "SharedStashHardCoreV2.d2i");
                string stashBackupFolder = Path.Combine(ActualSaveFilePath + "/Backups", "Shared Stash");

                if (!Directory.Exists(stashBackupFolder))
                    Directory.CreateDirectory(stashBackupFolder);

                File.Copy(mostRecentStashFileSC, Path.Combine(stashBackupFolder, "SharedStashSoftCoreV2" + DateTime.Now.ToString("_MM_dd--hh_mmtt") + ".d2i"), true);
                File.Copy(mostRecentStashFileHC, Path.Combine(stashBackupFolder, "SharedStashHardCoreV2" + DateTime.Now.ToString("_MM_dd--hh_mmtt") + ".d2i"), true);

                fileSize = new FileInfo(Path.Combine(mostRecentCharacterBackupFolder, mostRecentCharacterFile.Name + DateTime.Now.ToString("_MM_dd--hh_mmtt") + ".d2s")).Length;
            }

            textBackupLog.SelectionStart = textBackupLog.TextLength;
            textBackupLog.SelectionLength = 0;
            textBackupLog.SelectionColor = Color.Red;
            textBackupLog.SelectionFont = new Font(textBackupLog.Font, FontStyle.Bold);
            textBackupLog.AppendText($"{currentTime}: ");

            textBackupLog.SelectionStart = textBackupLog.TextLength;
            textBackupLog.SelectionLength = 0;
            textBackupLog.SelectionColor = textBackupLog.ForeColor;
            textBackupLog.SelectionFont = new Font(textBackupLog.Font, FontStyle.Regular);
            textBackupLog.AppendText("Backed up ");

            textBackupLog.SelectionStart = textBackupLog.TextLength;
            textBackupLog.SelectionLength = 0;
            textBackupLog.SelectionFont = new Font(textBackupLog.Font, FontStyle.Bold);
            textBackupLog.AppendText($"{mostRecentCharacterName}");

            textBackupLog.SelectionStart = textBackupLog.TextLength;
            textBackupLog.SelectionLength = 0;
            textBackupLog.SelectionFont = new Font(textBackupLog.Font, FontStyle.Regular);
            textBackupLog.AppendText($" ({fileSize}/8192 bytes) -- {dropModChoice.Text}\n");

            if (checkBindD2R.Checked == true)
            {
                Process d2rProcess = FindD2R("D2R.exe");
                if (d2rProcess == null)
                    Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Backup Buddy v" + appVersion;

            if (Properties.Settings.Default.gamePath != "")
                textD2RPath.Text = Properties.Settings.Default.gamePath;
            if (Properties.Settings.Default.savePath != "")
                textSavePath.Text = Properties.Settings.Default.savePath;

            populateModChoice();
            populateCharacterChoice();

            if (Properties.Settings.Default.modChoice != null)
                dropModChoice.SelectedIndex = Properties.Settings.Default.modChoice;
            if (Properties.Settings.Default.backupValue != "")
                textBackupValue.Text = Properties.Settings.Default.backupValue;
            if (Properties.Settings.Default.backupInterval != null)
                dropBackupValue.SelectedIndex = Properties.Settings.Default.backupInterval;
            if (Properties.Settings.Default.backupStatus == false)
                btnUpdateStatus.BackgroundImage = Properties.Resources.BackupDisabled;
            if (Properties.Settings.Default.backupStatus == true)
            {
                btnUpdateStatus.Tag = "Enabled";
                btnUpdateStatus.BackgroundImage = Properties.Resources.BackupEnabled;
                startTimer();
            }
            if (Properties.Settings.Default.gamePath == "")
            {
                textBackupValue.Text = "N/A";
                dropBackupValue.SelectedIndex = 0;
            }
            checkMinimize.Checked = Properties.Settings.Default.minimizeStatus;
            checkBindD2R.Checked = Properties.Settings.Default.bindStatus;

            notifyIcon1.BalloonTipTitle = "Backup Buddy is still open!";
            notifyIcon1.BalloonTipText = "It has been minimized to your system panel";
            notifyIcon1.Icon = Properties.Resources.BackupBuddy1;
            notifyIcon1.Text = "D2R Backup Buddy";
            notifyIcon1.Visible = false;
        }

        private void textBackupValue_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.backupValue = textBackupValue.Text;
            Properties.Settings.Default.Save();

            if (textD2RPath.Text != "" && textSavePath.Text != "" && dropModChoice.SelectedIndex != -1 && textBackupValue.Text != "N/A")
            {
                timerBackup.Stop();
                startTimer();
            }
        }

        private void dropBackupValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.backupInterval = dropBackupValue.SelectedIndex;
            Properties.Settings.Default.Save();

            if (textD2RPath.Text != "" && textSavePath.Text != "" && dropModChoice.SelectedIndex != -1 && textBackupValue.Text != "N/A")
            {
                timerBackup.Stop();
                startTimer();
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (btnUpdateStatus.Tag == "Disabled")
            {
                if (textD2RPath.Text != "" && textSavePath.Text != "" && dropModChoice.SelectedIndex != -1 && textBackupValue.Text != "N/A")
                {
                    Properties.Settings.Default.backupStatus = true;
                    Properties.Settings.Default.Save();
                    startTimer();
                    btnUpdateStatus.Tag = "Enabled";
                    btnUpdateStatus.BackgroundImage = Properties.Resources.BackupEnabled;
                    
                }
                else
                    MessageBox.Show("Unable to perform backups - Missing Field Entries!");
            }
            else if (btnUpdateStatus.Tag == "Enabled")
            {
                Properties.Settings.Default.backupStatus = false;
                Properties.Settings.Default.Save();
                btnUpdateStatus.Tag = "Disabled";
                btnUpdateStatus.BackgroundImage = Properties.Resources.BackupDisabled;
                btnUpdateStatus.Refresh(); // Force a refresh of the button's layout
                
            }
        }


        private void timerBackup_Tick(object sender, EventArgs e)
        {
            performBackup();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (checkMinimize.Checked == true)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    this.ShowInTaskbar = false;
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(1000);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        static Process FindD2R(string processName)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                try
                {
                    if (process.MainModule != null && process.MainModule.FileName.EndsWith(processName, StringComparison.OrdinalIgnoreCase))
                    {
                        return process;
                    }
                }
                catch (Exception)
                {
                    // Ignore exceptions for processes without a main module
                }
            }
            return null;
        }

        private void checkMinimize_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.minimizeStatus = checkMinimize.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBindD2R_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.bindStatus = checkBindD2R.Checked;
            Properties.Settings.Default.Save();
        }

        private void dropRestore_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ActualSaveFilePath = "";
            string ActualBackupPath = "";
            var currentDate = DateTime.Now.ToString("MMMM d, yyyy");
            var currentTime = DateTime.Now.ToString("hh:mm tt");

            //Check for retail usage
            if (dropModChoice.SelectedIndex == 0)
            {
                ActualSaveFilePath = Properties.Settings.Default.savePath;
                ActualBackupPath = Properties.Settings.Default.savePath + @"\Backups";
            }
            else if (dropModChoice.SelectedIndex > 0)
            {
                ActualSaveFilePath = Properties.Settings.Default.savePath + @"\Mods\" + dropModChoice.Text;
                ActualBackupPath = Properties.Settings.Default.savePath + @"\Mods\" + dropModChoice.Text + @"\Backups";
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = ActualBackupPath + @"\" + dropRestore.Text;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (dropRestore.Text != "Shared Stash")
                    File.Copy(openFileDialog.FileName, Path.Combine(ActualSaveFilePath + @"\" + dropRestore.Text + ".d2s"), true);
                else
                    File.Copy(openFileDialog.FileName, Path.Combine(ActualSaveFilePath + @"\" + dropRestore.Text + ".d2i"), true);

                textBackupLog.SelectionStart = textBackupLog.TextLength;
                textBackupLog.SelectionLength = 0;
                textBackupLog.SelectionColor = Color.Green;
                textBackupLog.SelectionFont = new Font(textBackupLog.Font, FontStyle.Bold);
                textBackupLog.AppendText($"{currentTime}: ");

                textBackupLog.SelectionStart = textBackupLog.TextLength;
                textBackupLog.SelectionLength = 0;
                textBackupLog.SelectionColor = textBackupLog.ForeColor;
                textBackupLog.SelectionFont = new Font(textBackupLog.Font, FontStyle.Regular);
                textBackupLog.AppendText("Restored ");

                textBackupLog.SelectionStart = textBackupLog.TextLength;
                textBackupLog.SelectionLength = 0;
                textBackupLog.SelectionFont = new Font(textBackupLog.Font, FontStyle.Bold);
                textBackupLog.AppendText(dropRestore.Text);

                textBackupLog.SelectionStart = textBackupLog.TextLength;
                textBackupLog.SelectionLength = 0;
                textBackupLog.SelectionFont = new Font(textBackupLog.Font, FontStyle.Regular);
                textBackupLog.AppendText(" -- " + dropModChoice.Text + "\n");
            }
        }
    }
}
