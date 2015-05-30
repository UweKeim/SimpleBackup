namespace SimpleBackup.Main.Tasks.Backup
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Core;

    public partial class BackupForm : Form
    {
        private string _sourceFolderPath;

        public BackupForm()
        {
            InitializeComponent();
        }

        public void Initialize(string sourceFolderPath)
        {
            _sourceFolderPath = sourceFolderPath;
        }

        private void BackupForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void BackupForm_Shown(object sender, EventArgs e)
        {
            processingBackgroundWorker.RunWorkerAsync();
        }

        private void processingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Backuper.Backup(
                _sourceFolderPath,
                userState => processingBackgroundWorker.CancellationPending ? CancelMode.Cancel : CancelMode.Continue);
        }

        private void processingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Hide();
            if (e.Error != null) Program.HandleException(e.Error);

            Application.Exit();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonCancel.Enabled = false;
            processingBackgroundWorker.CancelAsync();
        }

        private void BackupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (processingBackgroundWorker.CancellationPending)
            {
                e.Cancel = true;
            }
            else if (processingBackgroundWorker.IsBusy)
            {
                processingBackgroundWorker.CancelAsync();
                e.Cancel = true;
            }
        }
    }
}
