using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;


namespace Coffeed
{
    static class Program
    {
        public static double Version = 0.2;

        static WebClient client;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AutoPatcher.Patch();
            Logging.InitLog();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            client = new WebClient()
            {
                Encoding = System.Text.Encoding.UTF8,
            };

            client.Headers.Add("User-Agent: Other");

            if (!string.IsNullOrEmpty(PuttyDetector()) && !string.IsNullOrEmpty(FileZillaDetector()))
            {
                if (File.Exists(Path.Combine(Application.StartupPath, "PublicKey.xml")))
                {
                    Application.Run(new FormMain());
                }
                else
                {
                    Application.Run(new FormInit());
                }
            }
            else
            {
                Application.Run(new frmSoftwareDetector());
            }

        }

        public static string PuttyDetector()
        {
            var result = string.Empty;

            try
            {
                RegistryView rv = RegistryView.Registry32;
                if (Environment.Is64BitOperatingSystem) rv = RegistryView.Registry64;
                var keyView = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, rv);

                var key32 = keyView.OpenSubKey(@"SOFTWARE\WOW6432Node\SimonTatham\PuTTY\CHMPath", false);
                var key64 = keyView.OpenSubKey(@"SOFTWARE\SimonTatham\PuTTY64\CHMPath", false);

                if (key32 != null)
                {
                    var puttyPath = Path.Combine(Path.GetDirectoryName(key32.GetValue("").ToString()), "putty.exe");
                    if (File.Exists(puttyPath))
                    {
                        result = puttyPath;
                    }
                    else
                    {
                        result = string.Empty;
                    }
                }

                if (key64 != null)
                {

                    var puttyPath = Path.Combine(Path.GetDirectoryName(key64.GetValue("").ToString()), "putty.exe");
                    if (File.Exists(puttyPath))
                    {
                        result = puttyPath;
                    }
                    else
                    {
                        result = string.Empty;
                    }
                }
            }
            catch (Exception err)
            {
                Logging.M(err.Message, "Oops, there's an error that needs special attetion.");
                Logging.LogError(err);
                return string.Empty;
            }

            return result;
        }

        public static string FileZillaDetector()
        {
            string result = string.Empty;

            try
            {
                RegistryView rv = RegistryView.Registry32;
                if (Environment.Is64BitOperatingSystem) rv = RegistryView.Registry64;
                var key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, rv);
                var fzkey = key.OpenSubKey(@"SOFTWARE\WOW6432Node\FileZilla Client", false);
                if (fzkey != null)
                {
                    string path = (string)fzkey.GetValue("", string.Empty);

                    if (System.IO.File.Exists(Path.Combine(path, "filezilla.exe")))
                    {
                        result = Path.Combine(path, "filezilla.exe");
                    }
                    else
                    {
                        result = string.Empty;
                    }
                }
                
            }
            catch (Exception err)
            {
                Logging.M(err.Message, "Oops, there's an error that needs special attetion.");
                Logging.LogError(err);
                return string.Empty;
            }

            return result;
        }

        public static void InstallFileZilla()
        {
            try
            {
                string link = "http://185.138.43.38/plesk-site-preview/xostme.gr/https/185.138.43.38/FileZilla_3.56.2_win32-setup.exe";
                if (Environment.Is64BitOperatingSystem) link = "http://185.138.43.38/plesk-site-preview/xostme.gr/https/185.138.43.38/FileZilla_3.56.2_win64-setup.exe";

                client.DownloadFile(link, Path.Combine(Path.GetTempPath(), "FileZillaSetup.exe"));

                Process p = new Process();
                p.StartInfo.WorkingDirectory = Path.GetTempPath();
                p.StartInfo.FileName = Path.Combine(Path.GetTempPath(), "FileZillaSetup.exe");
                p.Start();
                p.WaitForExit();
            }
            catch (Exception err)
            {
                Logging.M(err.Message, "Oops, there's an error that needs special attetion.");
                Logging.LogError(err);
            }
        }
        public static void InstallPutty()
        {
            try
            {
                string link = "https://the.earth.li/~sgtatham/putty/latest/w32/putty-0.76-installer.msi";
                if (Environment.Is64BitOperatingSystem) link = "https://the.earth.li/~sgtatham/putty/latest/w64/putty-64bit-0.76-installer.msi";

                client.DownloadFile(link, Path.Combine(Path.GetTempPath(), "PuttySetup.msi"));
                Process p = new Process();
                p.StartInfo.WorkingDirectory = Path.GetTempPath();
                p.StartInfo.FileName = Path.Combine(Path.GetTempPath(), "PuttySetup.msi");
                p.Start();
                p.WaitForExit();
            }
            catch (Exception err)
            {
                Logging.M(err.Message, "Oops, there's an error that needs special attetion.");
                Logging.LogError(err);
            }
        }
    }
}
