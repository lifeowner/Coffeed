using System;
using System.Windows.Forms;

namespace Coffeed
{
    public partial class FormPrivKey : Form
    {
        public FormPrivKey()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Private Key | *.xml";
            ofd.DefaultExt = "xml";
            ofd.FileName = "PrivateKey";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                privkeypath.Text = ofd.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(privkeypath.Text))
            {
                Properties.Settings.Default.privkeypath = privkeypath.Text;
                Properties.Settings.Default.Save();
                this.Close();
            }
            else
            {
                MessageBox.Show("This file doesn't seem to exists, please search for your private key.", "That file doesn't exists!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            privkeypath.Text = Properties.Settings.Default.privkeypath;
        }
    }
}
