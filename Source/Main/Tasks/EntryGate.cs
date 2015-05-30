namespace SimpleBackup.Main.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Backup;
    using Install;
    using Restore;
    using Uninstall;

    /// <summary>
    /// Entscheidet wohin gesprungen werden soll.
    /// </summary>
    internal static class EntryGate
    {
        public static Form DecideForm()
        {
            var args = new List<string>(Environment.GetCommandLineArgs());

            // TODO.

            if (args.Contains(@"-i") || args.Count <= 1 && !Installer.IsInstalled)
            {
                return new InstallForm();
            }
            else if (args.Contains(@"-u") || args.Count <= 1 && Installer.IsInstalled)
            {
                return new UninstallForm();
            }
            else if (args.Contains(@"-b") && args.Count == 3)
            {
                var r = new BackupForm();
                r.Initialize(args[2]);
                return r;
            }
            else if (args.Contains(@"-r") && args.Count == 3)
            {
                var r = new RestoreForm();
                r.Initialize(args[2]);
                return r;
            }
            else
            {
                throw new Exception("Unknown/invalid command line arguments.");
            }
        }
    }
}