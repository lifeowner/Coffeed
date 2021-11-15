using Microsoft.Win32;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Coffeed
{
    public static class Logging
    {
        static string SUBMIT_LOG_URL = "http://20.107.27.154/logsubmit.php";
        public static string LOG_FILE = Path.Combine(Application.StartupPath, "coffeed.log");
        static string NL = Environment.NewLine;

        public static void InitLog()
        {
            MessageBoxManager.Retry = "Report Error";
            MessageBoxManager.Cancel = "Ignore";
            MessageBoxManager.Register();

            if (!File.Exists(LOG_FILE))
            {
                var WE = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
                File.AppendAllText(LOG_FILE, $"Coffeed - Version {Program.Version}{NL}");
                File.AppendAllText(LOG_FILE, $"Windows:  {WE.GetValue("ProductName")} / x64: {Environment.Is64BitOperatingSystem} {NL}{NL}");
            }
        }

        public static void LogError(Exception err)
        {
            File.AppendAllText(LOG_FILE, $"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()} {NL} {err.Message} {NL} {err.StackTrace} {NL}{NL}");
        }
        public static void M(string Message, string Title)
        {
            if (MessageBox.Show(Message, Title, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
            {
                // upload
                try
                {
                    WebClient c = new WebClient();

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    c.Headers.Add("User-Agent: Other");
                    c.Encoding = Encoding.UTF8;
                    using (c)
                    {
                        string filePath = Logging.LOG_FILE;
                        var serverPath = new Uri(SUBMIT_LOG_URL);
                        c.UploadFile(serverPath, filePath);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }
    }

}
