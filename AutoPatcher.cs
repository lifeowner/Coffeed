using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Coffeed
{
    internal static class AutoPatcher
    {
        static WebClient client = new WebClient();

        internal static void Patch()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            client.Headers.Add("User-Agent: Other");
            client.Encoding = Encoding.UTF8;

            try
            {
                double newVersion = Convert.ToDouble(client.DownloadString("https://raw.githubusercontent.com/lifeowner/Coffeed/main/version.txt"));

                if (Program.Version < newVersion)
                {
                    string dlLink = $"https://github.com/lifeowner/Coffeed/releases/download/{newVersion}/Coffeed.exe";
                    

                    // backup current version
                    string file = Path.Combine(Application.StartupPath, Assembly.GetExecutingAssembly().GetName().Name);
                    string extension = ".exe";

                    client.DownloadFile(dlLink, file + "_tmp" + extension);

                    if (File.Exists(file + "_old" + extension)) File.Delete(file + "_old" + extension);
                    File.Move(file + extension, file + "_old" + extension);

                    File.Move(file + "_tmp" + extension, file + extension);

                    Thread.Sleep(1000);

                    Application.Restart();
                    Environment.Exit(0);
                }
            }
            catch (Exception err)
            {
                Logging.M(err.Message, "Oops, there's an error that needs special attetion.");
                Logging.LogError(err);
            }
        }
    }
}
