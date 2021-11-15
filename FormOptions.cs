using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Coffeed
{
    public partial class FormOptions : Form
    {
        IniFile Settings = new IniFile("coffeed.conf");

        public FormOptions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.File.WriteAllText("coffeed.conf", "");
                Settings.Write("putty_path", puttypath.Text);
                Settings.Write("startup", checkBox1.Checked.ToString());
                if (System.IO.File.Exists("coffeed.conf"))
                {
                    var startup = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    if (Settings.Read("startup").ToLowerInvariant() == "true")
                    {
                        startup.SetValue("Coffeed", Path.Combine(Application.StartupPath, AppDomain.CurrentDomain.FriendlyName));
                    }
                    else if (Settings.Read("startup").ToLowerInvariant() == "false")
                    {
                        startup.DeleteValue("Coffeed", false);
                    }
                }
            }
            catch (Exception err)
            {
                Logging.M(err.Message, "Oops, there's an error that needs special attetion.");
                Logging.LogError(err);

            }
            this.Close();
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            DetectNecessaryApps();

            if (System.IO.File.Exists("coffeed.conf"))
            {
                puttypath.Text = Settings.Read("putty_path");
                checkBox1.Checked = Convert.ToBoolean(Settings.Read("startup"));
            }
        }

        private void DetectNecessaryApps()
        {
            if (!string.IsNullOrEmpty(Program.PuttyDetector()))
            {
                btnInstallPutty.Enabled = false;
                btnInstallPutty.Text = "Installed";
                btnInstallPutty.BackColor = Color.LimeGreen;
            }
            else
            {
                btnInstallPutty.Enabled = true;
                btnInstallPutty.BackColor = Color.Tomato;
                btnInstallPutty.Text = "Install";
            }

            if (!string.IsNullOrEmpty(Program.FileZillaDetector()))
            {
                btnInstallFileZilla.BackColor = Color.LimeGreen;
                btnInstallFileZilla.Enabled = false;
                btnInstallFileZilla.Text = "Installed";
            }
            else
            {
                btnInstallFileZilla.Enabled = true;
                btnInstallFileZilla.BackColor = Color.Tomato;
                btnInstallFileZilla.Text = "Install";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog putty = new OpenFileDialog();
            putty.Filter = "Executable Putty|*.exe";
            putty.DefaultExt = "exe";
            putty.FileName = "Putty.exe";
            putty.Title = "Browse Putty Path";
            if (putty.ShowDialog() == DialogResult.OK)
            {
                puttypath.Text = putty.FileName;
            }
        }

        private void btnInstallFileZilla_Click(object sender, EventArgs e)
        {
            Program.InstallFileZilla();
            DetectNecessaryApps();

        }

        private void btnInstallPutty_Click(object sender, EventArgs e)
        {
            Program.InstallPutty();
            DetectNecessaryApps();
        }
    }
}
