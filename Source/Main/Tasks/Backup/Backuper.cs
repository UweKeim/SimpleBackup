namespace SimpleBackup.Main.Tasks.Backup
{
    using System;
    using System.IO;
    using Core;
    using Install;

    internal static class Backuper
    {
        public static string BackupStorageBaseFolderPath
        {
            get { return Path.Combine(Installer.InstallationFolderPath, @"Backups"); }
        }

        public static void Backup(string sourceFolderPath, Cancelable cancelable)
        {
            if (sourceFolderPath.StartsWith(BackupStorageBaseFolderPath, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception("Path must be outside of Simple Backup folder.");
            }

            var src = new DirectoryInfo(sourceFolderPath);
            var dst = new DirectoryInfo(Path.Combine(BackupStorageBaseFolderPath, MakeUnique(src)));

            if( dst.Exists)dst.Delete();
            dst.Create();

            CopyFilesRecursively(src, dst, cancelable);
        }

        public static string MakeUnique(FileSystemInfo src)
        {
            return string.Format(@"{0} ({1:X})", src.Name, src.FullName.GetHashCode());
        }

        public static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target, Cancelable cancelable)
        {
            foreach (var dir in source.GetDirectories())
            {
                CancelHelper.CheckThrowCancel(cancelable);
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name), cancelable);
            }

            foreach (var file in source.GetFiles())
            {
                CancelHelper.CheckThrowCancel(cancelable);
                file.CopyTo(Path.Combine(target.FullName, file.Name));
            }
        }
    }
}