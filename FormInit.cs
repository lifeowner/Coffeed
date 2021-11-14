﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffeed
{
    public partial class FormInit : Form
    {
        public FormInit()
        {
            InitializeComponent();
        }

        string PrivateKeyPath = "";
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog SPrivKey = new SaveFileDialog();
            SPrivKey.Filter = "Private Key | *.xml";
            SPrivKey.DefaultExt = "key";
            SPrivKey.FileName = "PrivateKey";
            if (SPrivKey.ShowDialog() == DialogResult.OK)
            {
                PrivateKeyPath = SPrivKey.FileName;
                privkeypath.Text = SPrivKey.FileName;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            var privsw = new StreamWriter(PrivateKeyPath, false, Encoding.UTF8);
            var publicsw = new StreamWriter("PublicKey.xml", false, Encoding.UTF8);
            if (checkBox1.Checked)
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                using (privsw)
                {

                    privsw.WriteLine(rsa.ToXmlString(true));
                    Properties.Settings.Default.privkeypath = PrivateKeyPath;
                    Properties.Settings.Default.Save();
                }
                using (publicsw)
                {

                    publicsw.WriteLine(rsa.ToXmlString(false));

                }
                Application.Restart();
            }
            else
            {
                MessageBox.Show("You should agree to the terms that you know what you're doing.", "Terms didn't agreed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

    }
}
