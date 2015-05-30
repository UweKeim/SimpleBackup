namespace SimpleBackup.Main.Tasks.Uninstall
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Core;

    public partial class UninstallForm : Form
    {
        public UninstallForm()
        {
            InitializeComponent();
        }

        private void UninstallForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void UninstallForm_Shown(object sender, EventArgs e)
        {
            processingBackgroundWorker.RunWorkerAsync();
        }

        private void processingBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Uninstaller.Uninstall(
                userState => processingBackgroundWorker.CancellationPending ? CancelMode.Cancel : CancelMode.Continue);
        }

        private void processingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Hide();
            if (e.Error != null) Program.HandleException(e.Error);

            Application.Exit();
        }

        private void UninstallForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (processingBackgroundWorker.IsBusy)
            {
                processingBackgroundWorker.CancelAsync();
                e.Cancel = true;
            }
        }
    }
}