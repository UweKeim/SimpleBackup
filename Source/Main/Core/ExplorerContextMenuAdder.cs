namespace SimpleBackup.Main.Core
{
    using System;
    using System.Reflection;
    using Microsoft.Win32;
    using Tasks.Install;

    internal static class ExplorerContextMenuAdder
    {
        public static void Register()
        {
            var key1 = Registry.CurrentUser.CreateSubKey(@"Software\Classes\Directory\shell\Simple Backup - Backup");
            key1.SetValue(null, "Backup - [Simple Backup]");

            var key2 = key1.CreateSubKey(@"command");
            key2.SetValue(null, $@"""{Installer.InstallationExeFilePath}"" -b ""%1""");

            key1.Close();
            key2.Close();

            // --

            key1 = Registry.CurrentUser.CreateSubKey(@"Software\Classes\Directory\shell\Simple Backup - Restore");
            key1.SetValue(null, "Restore - [Simple Backup]");

            key2 = key1.CreateSubKey(@"command");
            key2.SetValue(null, $@"""{Installer.InstallationExeFilePath}"" -r ""%1""");

            key1.Close();
            key2.Close();

            // --

            // http://stackoverflow.com/a/11821952/107625
            using (var key = Registry.CurrentUser.CreateSubKey(
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Simple Backup"))
            {
                var asm = Assembly.GetExecutingAssembly();
                var v = asm.GetName().Version;

                key.SetValue(@"DisplayName", "Simple Backup");
                key.SetValue(@"ApplicationVersion", v.ToString());
                key.SetValue(@"Publisher", "Zeta Software GmbH");
                key.SetValue(@"DisplayIcon", Installer.InstallationExeFilePath);
                key.SetValue(@"DisplayVersion", v.ToString(2));
                key.SetValue(@"URLInfoAbout", "https://github.com/UweKeim/SimpleBackup");
                key.SetValue(@"Contact", "info@zeta-producer.com");
                key.SetValue(@"InstallDate", DateTime.Now.ToString(@"yyyyMMdd"));
                key.SetValue(@"UninstallString", $@"""{Installer.InstallationExeFilePath}"" -u");
            }
        }

        public static void Unregister()
        {
            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Classes\Directory\shell\Simple Backup - Backup");
            }
            catch (Exception)
            {
            }

            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Classes\Directory\shell\Simple Backup - Restore");
            }
            catch (Exception)
            {
            }

            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Simple Backup");
            }
            catch (Exception)
            {
            }
        }
    }
}