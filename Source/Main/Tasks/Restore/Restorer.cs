namespace SimpleBackup.Main.Tasks.Restore
{
    using System;
    using System.IO;
    using Backup;
    using Core;

    internal static class Restorer
    {
        public static void Restore(string destinationFolderPath, Cancelable cancelable)
        {
            if (destinationFolderPath.StartsWith(Backuper.BackupStorageBaseFolderPath, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception("Path must be outside of Simple Backup folder.");
            }

            var dst = new DirectoryInfo(destinationFolderPath);
            var src = new DirectoryInfo(Path.Combine(Backuper.BackupStorageBaseFolderPath, Backuper.MakeUnique(dst)));

            if (!src.Exists) throw new MessageBoxException("No backup available for this folder.");
            deleteDirectoryContents(dst, cancelable);

            Backuper.CopyFilesRecursively(src, dst, cancelable);
        }

        private static void deleteDirectoryContents(DirectoryInfo dir, Cancelable cancelable)
        {
            if (!dir.Exists) return;

            foreach (var directory in dir.GetDirectories())
            {
                CancelHelper.CheckThrowCancel(cancelable);
                directory.Delete(true);
            }

            foreach (var file in dir.GetFiles())
            {
                CancelHelper.CheckThrowCancel(cancelable);
                file.Delete();
            }
        }
    }
}