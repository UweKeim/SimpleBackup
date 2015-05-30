namespace SimpleBackup.Main.Core
{
    using System;
    using System.ComponentModel;

    public enum CancelMode
    {
        Continue,
        Cancel
    }

    public delegate CancelMode Cancelable(object userState);

    public static class CancelHelper
    {
        private const string Magic = @"3472389472389";

        public static void CheckThrowCancel(Cancelable cancelable, object userState = null)
        {
            if (cancelable != null && cancelable(userState) == CancelMode.Cancel)
            {
                throw new OperationCanceledException(Magic);
            }
        }

        public static void CheckThrowCancel(BackgroundWorker bw)
        {
            if (bw != null && bw.IsBusy && bw.CancellationPending)
            {
                throw new OperationCanceledException(Magic);
            }
        }
    }
}