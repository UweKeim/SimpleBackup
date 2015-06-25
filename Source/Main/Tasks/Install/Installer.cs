namespace SimpleBackup.Main.Tasks.Install
{
    using System;
    using System.IO;
    using System.Reflection;
    using Core;

    internal static class Installer
    {
        public static string InstallationFolderPath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Simple Backup");

        public static string InstallationExeFilePath => Path.Combine(InstallationFolderPath, ExeName);

        private static string ExeName => Path.GetFileName(Assembly.GetEntryAssembly().Location);

        public static bool IsInstalled => File.Exists(InstallationExeFilePath);

        public static void Install(
            Cancelable cancelable)
        {
            if (IsInstalled) return;

            Directory.CreateDirectory(InstallationFolderPath);

            File.Copy(
                Assembly.GetEntryAssembly().Location,
                InstallationExeFilePath,
                true);

            ExplorerContextMenuAdder.Register();
        }
    }
}