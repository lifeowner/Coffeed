using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffeed
{
    public partial class FormAdd : Form
    {
        public string _privateKey;
        public string _publicKey;
        private static UnicodeEncoding _encoder = new UnicodeEncoding();

        

        public List<Account> DB = new List<Account>();


        public FormAdd()
        {
            InitializeComponent();

            if (File.Exists("DATA.dat")) DB = LoadDB();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            _publicKey = Application.StartupPath + @"\PublicKey.xml";
            _privateKey = Properties.Settings.Default.privkeypath;

            comboBox2.Items.AddRange(frmAddGroup.groups.Split(','));
        }

        public string Decrypt(string data)
        {
            var rsa = new RSACryptoServiceProvider();
            var dataArray = data.Split(new char[] { ',' });
            byte[] dataByte = new byte[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
            {
                dataByte[i] = Convert.ToByte(dataArray[i]);
            }

            rsa.FromXmlString(System.IO.File.ReadAllText(_privateKey));
            var decryptedByte = rsa.Decrypt(dataByte, false);
            return _encoder.GetString(decryptedByte);
        }

        public string Encrypt(string data)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(System.IO.File.ReadAllText(_publicKey));
            var dataToEncrypt = _encoder.GetBytes(data);
            var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false).ToArray();
            var length = encryptedByteArray.Count();
            var item = 0;
            var sb = new StringBuilder();
            foreach (var x in encryptedByteArray)
            {
                item++;
                sb.Append(x);

                if (item < length)
                    sb.Append(",");
            }

            return sb.ToString();
        }
        /*
         *             MessageBox.Show(Encrypt(textBox1.Text));
         *   Clipboard.SetText(Encrypt(textBox1.Text));
         */
        private bool c(string s)
        {
            bool havingstring = false;
            havingstring = !string.IsNullOrEmpty(s);
            return havingstring;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(c(comboBox1.SelectedIndex.ToString()) && c(textBox4.Text) && c(textBox1.Text) && c(textBox2.Text) && c(textBox3.Text) && c(textBox4.Text) && c(textBox5.Text) && c(comboBox2.SelectedItem.ToString())) {
                var x = new Account();
                x.Type = Encrypt(comboBox1.SelectedItem.ToString());
                x.Name = Encrypt(textBox4.Text);
                x.IP = Encrypt(textBox1.Text);
                x.User = Encrypt(textBox2.Text);
                x.Pass = Encrypt(textBox3.Text);
                x.Port = Encrypt(textBox5.Text);
                x.SFTP = Encrypt(checkFTP.Checked.ToString().ToLowerInvariant());
                x.Group = Encrypt(comboBox2.SelectedItem.ToString());

                DB.Add(x);
                SaveDB(DB);

                this.Close();
            }
            else
            {
                MessageBox.Show("One or more fields are empty, please consider to fill them.", "Oops, fields needs atettion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private List<Account> LoadDB()
        {
            BinaryFormatter bf = new BinaryFormatter();
            return (List<Account>)bf.Deserialize(new MemoryStream(File.ReadAllBytes("DATA.dat")));
        }

        internal void SaveDB(List<Account> dbdata)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, dbdata);
                File.WriteAllBytes("DATA.dat", ms.ToArray());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "FileZilla")
            {
                checkFTP.Visible = true;
                checkFTP.Checked = true;
                label5.Visible = true;
                textBox5.Visible = true;
            }
            else if (comboBox1.SelectedItem.ToString() == "RDP")
            {
                label5.Visible = false;
                textBox5.Visible = false;
                checkFTP.Visible = false;
            }
            else
            {
                checkFTP.Visible = false;
                label5.Visible = true;
                textBox5.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddGroup add_group = new frmAddGroup();
            add_group.ShowDialog();

            frmAddGroup.RefreshGroups();
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(frmAddGroup.groups.Split(','));
        }
        /*
* MessageBox.Show(Decrypt(textBox1.Text));
*/

    }
}
