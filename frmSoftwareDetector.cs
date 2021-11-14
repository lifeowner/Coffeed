using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffeed
{
    public partial class frmSoftwareDetector : Form
    {
        public frmSoftwareDetector()
        {
            InitializeComponent();
        }

        private void btnInstallPutty_Click(object sender, EventArgs e)
        {
            Program.InstallPutty();
            DetectNecessaryApps();
            areBothInstalled();
        }

        private void btnInstallFileZilla_Click(object sender, EventArgs e)
        {
            Program.InstallFileZilla();
            DetectNecessaryApps();
            areBothInstalled();
        }

        private void frmSoftwareDetector_Load(object sender, EventArgs e)
        {
            DetectNecessaryApps();
        }
        private void areBothInstalled()
        {
            if (!string.IsNullOrEmpty(Program.PuttyDetector()) && !string.IsNullOrEmpty(Program.FileZillaDetector()))
            {
                Application.Restart();
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
    }
}
