namespace SimpleBackup.Main.Core
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows.Forms;
    using Tasks;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += applicationThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += currentDomainUnhandledException;

            try
            {
                Application.Run(EntryGate.DecideForm());
            }
            catch (Exception x)
            {
                HandleException(x);
            }
        }

        private static void applicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        private static void currentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        private static bool _insideHandleException;

        public static void HandleException(
            Exception exception)
        {
            Trace.TraceError(
                @"Exception occurred. {0}",
                exception.Message);

            if (!_insideHandleException)
            {
                _insideHandleException = true;
                try
                {
                    var messageBoxException = exception as MessageBoxException;
                    if (messageBoxException != null)
                    {
                        var mbx = messageBoxException;
                        MessageBox.Show(null, mbx.Message, "Simple Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var cancel = exception as OperationCanceledException;
                    if (cancel != null) return;

                    // --

                    if (ErrorForm.IsErrorFormShowing)
                    {
                        Trace.TraceInformation(
                            @"Error form already showing, not showing again. {0}",
                            exception.Message);
                    }
                    else
                    {
                        var result = ErrorForm.DoShow(exception);

                        if (result == DialogResult.Abort)
                        {
                            Process.GetCurrentProcess().Kill();
                            Application.Exit();
                        }
                    }
                }
                finally
                {
                    _insideHandleException = false;
                }
            }
            else
            {
                Trace.TraceError(
                    @"Already inside 'HandleException()', not entering again. {0}",
                    exception.Message);
            }
        }
    }
}