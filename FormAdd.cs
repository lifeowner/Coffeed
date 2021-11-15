using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Coffeed
{
    public partial class FormAdd : Form
    {
        public string _privateKey;
        public string _publicKey;
        private static UnicodeEncoding _encoder = new UnicodeEncoding();



        public List<Account> DB = new List<Account>();
        int _MODIFY_INDEX;

        public FormAdd(int modifyIndex = -99)
        {
            InitializeComponent();
            try
            {
                _publicKey = Application.StartupPath + @"\PublicKey.xml";
                _privateKey = Properties.Settings.Default.privkeypath;
                _MODIFY_INDEX = modifyIndex;

                if (File.Exists("DATA.dat")) DB = LoadDB();



                if (modifyIndex != -99)
                {
                    frmAddGroup add_group = new frmAddGroup();
                    frmAddGroup.RefreshGroups();
                    groupBox.Items.Clear();
                    groupBox.Items.AddRange(frmAddGroup.groups.Split(','));

                    typeBox.SelectedItem = Decrypt(DB[modifyIndex].Type);
                    groupBox.SelectedItem = Decrypt(DB[modifyIndex].Group);
                    txtFriendly.Text = Decrypt(DB[modifyIndex].Name);
                    txtIP.Text = Decrypt(DB[modifyIndex].IP);
                    txtUser.Text = Decrypt(DB[modifyIndex].User);
                    txtPass.Text = Decrypt(DB[modifyIndex].Pass);
                    txtPort.Text = Decrypt(DB[modifyIndex].Port);
                    if (Decrypt(DB[modifyIndex].SFTP).ToLowerInvariant() == "true")
                    {
                        checkFTP.Checked = true;
                    }
                    else
                    {
                        checkFTP.Checked = false;
                    }
                    //checkFTP.Enabled = bool.Parse());
                }
            }
            catch (Exception err)
            {
                Logging.M(err.Message, "Oops, there's an error that needs special attetion.");
                Logging.LogError(err);
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            _publicKey = Application.StartupPath + @"\PublicKey.xml";
            _privateKey = Properties.Settings.Default.privkeypath;

            groupBox.Items.AddRange(frmAddGroup.groups.Split(','));
        }

        public string Decrypt(string data)
        {
            try
            {

                var rsa = new RSACryptoServiceProvider();
                var dataArray = data.Split(new char[] { ',' });
                byte[] dataByte = new byte[dataArray.Length];
                for (int i = 0; i < dataArray.Length; i++)
                {
                    dataByte[i] = Convert.ToByte(dataArray[i]);
                }

                rsa.FromXmlString(File.ReadAllText(_privateKey));
                var decryptedByte = rsa.Decrypt(dataByte, false);
                return _encoder.GetString(decryptedByte);
            }
            catch (Exception err)
            {
                Logging.M(err.Message, "Oops, there's an error that needs special attetion.");
                Logging.LogError(err);
                return string.Empty;
            }

        }

        public string Encrypt(string data)
        {
            try
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
            catch (Exception err)
            {
                Logging.M(err.Message, "Oops, there's an error that needs special attetion.");
                Logging.LogError(err);
                return string.Empty;
            }

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
            if (c(typeBox.SelectedIndex.ToString()) && c(txtFriendly.Text) && c(txtIP.Text) && c(txtUser.Text) && c(txtPass.Text) && c(txtFriendly.Text) && c(txtPort.Text) && c(groupBox.SelectedItem.ToString()))
            {
                // MODIFY
                if (_MODIFY_INDEX != -99)
                {
                    DB[_MODIFY_INDEX].Type = Encrypt(typeBox.SelectedItem.ToString());
                    DB[_MODIFY_INDEX].Name = Encrypt(txtFriendly.Text);
                    DB[_MODIFY_INDEX].IP = Encrypt(txtIP.Text);
                    DB[_MODIFY_INDEX].User = Encrypt(txtUser.Text);
                    DB[_MODIFY_INDEX].Pass = Encrypt(txtPass.Text);
                    DB[_MODIFY_INDEX].Port = Encrypt(txtPort.Text);
                    DB[_MODIFY_INDEX].SFTP = Encrypt(checkFTP.Checked.ToString().ToLowerInvariant());
                    DB[_MODIFY_INDEX].Group = Encrypt(groupBox.SelectedItem.ToString());
                }
                // ADD NEW
                else
                {
                    var x = new Account();
                    x.Type = Encrypt(typeBox.SelectedItem.ToString());
                    x.Name = Encrypt(txtFriendly.Text);
                    x.IP = Encrypt(txtIP.Text);
                    x.User = Encrypt(txtUser.Text);
                    x.Pass = Encrypt(txtPass.Text);
                    x.Port = Encrypt(txtPort.Text);
                    x.SFTP = Encrypt(checkFTP.Checked.ToString().ToLowerInvariant());
                    x.Group = Encrypt(groupBox.SelectedItem.ToString());

                    DB.Add(x);
                }

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
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (List<Account>)bf.Deserialize(new MemoryStream(File.ReadAllBytes("DATA.dat")));
            }
            catch (Exception err)
            {
                Logging.M(err.Message, "Oops, there's an error that needs special attetion.");
                Logging.LogError(err);
                return new List<Account>();
            }
        }

        internal void SaveDB(List<Account> dbdata)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (var ms = new MemoryStream())
                {
                    bf.Serialize(ms, dbdata);
                    File.WriteAllBytes("DATA.dat", ms.ToArray());
                }
            }
            catch (Exception err)
            {
                Logging.M(err.Message, "Oops, there's an error that needs special attetion.");
                Logging.LogError(err);
                return;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeBox.SelectedItem.ToString() == "FileZilla")
            {
                checkFTP.Visible = true;
                checkFTP.Checked = true;
                label5.Visible = true;
                txtPort.Visible = true;
            }
            else if (typeBox.SelectedItem.ToString() == "RDP")
            {
                label5.Visible = false;
                txtPort.Visible = false;
                checkFTP.Visible = false;
            }
            else
            {
                checkFTP.Visible = false;
                label5.Visible = true;
                txtPort.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddGroup add_group = new frmAddGroup();
            add_group.ShowDialog();

            frmAddGroup.RefreshGroups();
            groupBox.Items.Clear();
            
            groupBox.Items.AddRange(frmAddGroup.groups.Split(','));
        }
        /*
* MessageBox.Show(Decrypt(textBox1.Text));
*/

    }
}
