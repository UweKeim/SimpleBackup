namespace SimpleBackup.Main.Tasks.Install
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Core;

    public partial class InstallForm : Form
    {
        public InstallForm()
        {
            InitializeComponent();
        }

        private void InstallForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void InstallForm_Shown(object sender, EventArgs e)
        {
            processingBackgroundWorker.RunWorkerAsync();
        }

        private void processingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Installer.Install(
                userState => processingBackgroundWorker.CancellationPending ? CancelMode.Cancel : CancelMode.Continue);
        }

        private void processingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Hide();
            Program.HandleException(e.Error ??
                                    new MessageBoxException(
                                        "Successfully installed.\r\n\r\nRight-click a folder in Windows Explorer and select 'Backup' or 'Restore'."));

            Application.Exit();
        }

        private void InstallForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (processingBackgroundWorker.IsBusy)
            {
                processingBackgroundWorker.CancelAsync();
                e.Cancel = true;
            }
        }
    }
}