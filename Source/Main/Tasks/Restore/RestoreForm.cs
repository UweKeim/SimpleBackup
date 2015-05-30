namespace SimpleBackup.Main.Tasks.Restore
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Core;

    public partial class RestoreForm : Form
    {
        private string _destinationFolderPath;

        public RestoreForm()
        {
            InitializeComponent();
        }

        public void Initialize(string destinationFolderPath)
        {
            _destinationFolderPath = destinationFolderPath;
        }

        private void RestoreForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void RestoreForm_Shown(object sender, EventArgs e)
        {
            processingBackgroundWorker.RunWorkerAsync();
        }

        private void processingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Restorer.Restore(
                _destinationFolderPath,
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

        private void RestoreForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (processingBackgroundWorker.CancellationPending)
            {
                e.Cancel = true;
            }
            else if ( processingBackgroundWorker.IsBusy)
            {
                processingBackgroundWorker.CancelAsync();
                e.Cancel = true;
            }
        }
    }
}
