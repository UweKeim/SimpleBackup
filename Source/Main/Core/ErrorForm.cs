namespace SimpleBackup.Main.Core
{
    using System;
    using System.Windows.Forms;

    public partial class ErrorForm : Form
    {
        private Exception _exception;

        public static DialogResult DoShow(Exception x)
        {
            IsErrorFormShowing = true;
            try
            {
                using (var form = new ErrorForm())
                {
                    form._exception = x;
                    return form.ShowDialog(ActiveForm);
                }
            }
            finally
            {
                IsErrorFormShowing = false;
            }
        }

        public ErrorForm()
        {
            InitializeComponent();
        }

        public static bool IsErrorFormShowing { get; private set; }

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            errorLogTextBox.Text = _exception.Message;
        }

        private void quitLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
    }
}
