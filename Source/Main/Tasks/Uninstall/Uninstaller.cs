namespace SimpleBackup.Main.Tasks.Uninstall
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using Core;
    using Install;

    internal static class Uninstaller
    {
        public static void Uninstall(Cancelable cancelable)
        {
            ExplorerContextMenuAdder.Unregister();

            // --

            var baseFolderPath = Installer.InstallationFolderPath;
            if (!Directory.Exists(baseFolderPath)) return;

            foreach (var directory in Directory.GetDirectories(baseFolderPath))
            {
                CancelHelper.CheckThrowCancel(cancelable);
                Directory.Delete(directory, true);
            }

            foreach (var file in Directory.GetFiles(baseFolderPath))
            {
                if (!string.Equals(Installer.InstallationExeFilePath, file, StringComparison.InvariantCultureIgnoreCase))
                {
                    CancelHelper.CheckThrowCancel(cancelable);
                    File.Delete(file);
                }
            }

            // --

            try
            {
                File.Delete(Installer.InstallationExeFilePath);
            }
            catch (Exception)
            {
                postPoneDeleteFile(Installer.InstallationExeFilePath);
            }

            try
            {
                Directory.Delete(Installer.InstallationFolderPath);
            }
            catch (Exception)
            {
                postPoneDeleteFile(Installer.InstallationFolderPath);
            }
        }

        private static void postPoneDeleteFile(string filePath)
        {
            /*
            // http://stackoverflow.com/questions/2245201/how-can-i-make-my-net-application-erase-itself
            // http://stackoverflow.com/questions/1305428/self-deletable-application-in-c-sharp-in-one-executable

            var info = new ProcessStartInfo
            {
                Arguments = string.Format(@"/C choice /C Y /N /D Y /T 3 & Del ""{0}""", filePath),
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = @"cmd.exe"
            };

            Process.Start(info);
            */

            // http://stackoverflow.com/a/6077952/107625
            if (!NativeMethods.MoveFileEx(filePath, null, MoveFileFlags.DelayUntilReboot))
            {
                Trace.TraceWarning(@"Unable to schedule '{0}' for deletion.", filePath);
            }
        }

        [Flags]
        private enum MoveFileFlags
        {
            None = 0,
            ReplaceExisting = 1,
            CopyAllowed = 2,
            DelayUntilReboot = 4,
            WriteThrough = 8,
            CreateHardlink = 16,
            FailIfNotTrackable = 32,
        }

        private static class NativeMethods
        {
            [DllImport(@"kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool MoveFileEx(
                string lpExistingFileName,
                string lpNewFileName,
                MoveFileFlags dwFlags);
        }
    }
}