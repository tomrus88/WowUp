﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace WowUp.WPF.Utilities
{
    public static class AppUtilities
    {
        public static string LongVersionName => FileVersionInfo.GetVersionInfo(ApplicationFilePath).ProductVersion;
        public static bool IsBetaBuild => LongVersionName.Contains("beta", StringComparison.OrdinalIgnoreCase);
        public static Version CurrentVersion => typeof(App).Assembly.GetName().Version;
        public static string CurrentVersionString => CurrentVersion.ToString();
        public static string ApplicationFilePath => Process.GetCurrentProcess().MainModule.FileName;
        public static string ApplicationFileName => Path.GetFileName(ApplicationFilePath);
        public static int ApplicationProcessId => Environment.ProcessId;
        public static string ApplicationProcessName => Process.GetCurrentProcess().ProcessName;

        public static void ShutdownApplication()
        {
            Application.Current.MainWindow?.Close();
            Application.Current.Shutdown();
        }

        public static void RestartApplication()
        {
            ShutdownApplication();
            Process.Start(FileUtilities.ExecutablePath);
        }
    }
}
