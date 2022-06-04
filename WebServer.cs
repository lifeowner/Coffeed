using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.Sockets;

namespace Coffeed
{
    
    public partial class WebServer : Form
    {
        public string statusTxt
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }
        public WebServer()
        {
            InitializeComponent();
        }
        ProcessStartInfo startInfo = new ProcessStartInfo();
        Process processTemp = new Process();
        private void scanMySQL()
        {
            IPAddress parseip = IPAddress.Parse("127.0.0.1");
            IPEndPoint endpoint = new IPEndPoint(parseip, 3306);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IAsyncResult result = sock.BeginConnect(endpoint, null, null);
            bool success = result.AsyncWaitHandle.WaitOne(5, true);
            if (sock.Connected)
            {
                sock.EndConnect(result);
                label4.ForeColor = Color.LimeGreen;
                label4.Text = "Online";
            }
            else
            {
                label4.ForeColor = Color.Tomato;
                label4.Text = "Offline";
            }

            sock.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            button2.Enabled = false;
            startInfo.FileName = Application.StartupPath + "/MySQL/bin/mysqld.exe";
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            
            processTemp.StartInfo = startInfo;
            processTemp.Start();
            Thread.Sleep(1000);
            scanMySQL();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Task.Run(() =>
            {
                this.Invoke((MethodInvoker)delegate
                 {
                     DownloadFile("https://archive.mariadb.org//mariadb-10.4.12/winx64-packages/mariadb-10.4.12-winx64.zip", Application.StartupPath + "/MySQL.zip");
                 });
            });
        }


        private volatile bool _completed;

        public async void DownloadFile(string address, string location)
        {
            WebClient client = new WebClient();
            Uri Uri = new Uri(address);
            _completed = false;

            client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);

            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgress);
            client.DownloadFileAsync(Uri, location);

        }

        public bool DownloadCompleted { get { return _completed; } }

        private async void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            // Displays the operation identifier, and the transfer progress.
            this.Invoke((MethodInvoker)delegate
            {
                label1.Text = e.ProgressPercentage + "% Downloaded";
                if(e.ProgressPercentage == 100)
                {
                    label1.Text = "Completed!";
                    Thread.Sleep(2000);
                    button1.Enabled = true;
                    //ZipFile.ExtractToDirectory(Application.StartupPath + "/MySQL.zip", Application.StartupPath + "/", Encoding.UTF8);
                    using (ZipArchive source = ZipFile.Open(Application.StartupPath + "/MySQL.zip", ZipArchiveMode.Read, null))
                    {
                        foreach (ZipArchiveEntry entry in source.Entries)
                        {
                            string fullPath = Path.GetFullPath(Path.Combine(Application.StartupPath + "/", entry.FullName));

                            if (Path.GetFileName(fullPath).Length != 0)
                            {
                                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                                
                                entry.ExtractToFile(fullPath, true);
                            }
                        }
                    }
                    

                }
            });
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                Console.WriteLine("Download has been canceled.");
            }
            else
            {
                Console.WriteLine("Download completed!");
            }

            _completed = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Directory.Move("mariadb-10.4.12-winx64", "MySQL");
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Application.StartupPath + "/MySQL/bin/mysql_install_db.exe";
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process processTemp = new Process();
            processTemp.StartInfo = startInfo;
            processTemp.Start();
            processTemp.WaitForExit();
            File.Delete(Application.StartupPath + "/MySQL.zip");
            MessageBox.Show("Succesfully installed!", "MySQL Installed!");
            button1.Visible = false;
            button1.Enabled = false;
            button3.Enabled = false;
            button3.Visible = false;
            label2.Visible = false;
            button2.Enabled = true;
            button2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button1.Visible = true;
            button3.Enabled = false;
            if (File.Exists(Application.StartupPath + "/MySQL/bin/mysqld.exe"))
            {
                MessageBox.Show("Already configured", "MySQL Is already configured!");
                File.Delete(Application.StartupPath + "/MySQL.zip");
            }
            else
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void WebServer_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/MySQL/bin/mysqld.exe"))
            {
                button3.Visible = false;
                button3.Enabled = false;
                button1.Enabled = false;
                button1.Visible = false;
                button2.Visible = true;
                button2.Enabled = true;
                label2.Visible = false;
            }
            else
            {
                button3.Visible = true;
                button3.Enabled = true;
                button1.Enabled = false;
                button1.Visible = true;
                button2.Visible = false;
                button2.Enabled = false;
                label2.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button2.Enabled = true;
            foreach (Process process in Process.GetProcessesByName("mysqld"))
            {
                process.Kill();
            }
            Thread.Sleep(1000);
            scanMySQL();
        }
    }




}
