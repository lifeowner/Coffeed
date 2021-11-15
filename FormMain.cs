using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Coffeed
{
    public partial class FormMain : Form
    {
        IniFile settings = new IniFile("coffeed.conf");
        readonly string FileZillaClient = string.Empty;
        bool isRealExit = false;

        public FormMain()
        {
            InitializeComponent();

            this.listMenu.Renderer = new MyRenderer();
            this.trayMenu.Renderer = new MyRenderer();

            this.Text = "Coffeed " + Program.Version;

            FileZillaClient = Program.FileZillaDetector();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAdd NewCon = new FormAdd();
            NewCon.ShowDialog();

            LoadDataToUI();
        }
        string pubKey = "";
        string privKey = "";
        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                if (!File.Exists("groups.dat")) File.WriteAllText("groups.dat", string.Empty);

                if (System.IO.File.Exists("coffeed.conf"))
                {
                    var startup = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    if (settings.Read("startup").ToLowerInvariant() == "true")
                    {
                        startup.SetValue("Coffeed", Path.Combine(Application.StartupPath, AppDomain.CurrentDomain.FriendlyName));
                    }
                    else if (settings.Read("startup").ToLowerInvariant() == "false")
                    {
                        startup.DeleteValue("Coffeed", false);
                    }
                }


                if (File.Exists(Application.StartupPath + @"\PublicKey.xml"))
                {
                    pubKey = File.ReadAllText(Application.StartupPath + @"\PublicKey.xml");
                }
                if (File.Exists(Properties.Settings.Default.privkeypath))
                {
                    privKey = File.ReadAllText(Properties.Settings.Default.privkeypath);

                }
                else
                {
                    MessageBox.Show("Your private key couldn't be found, please set the proper path to your Private Key.", "Oops, private key wasn't found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FormPrivKey PrivKeyBrowser = new FormPrivKey();
                    PrivKeyBrowser.ShowDialog();
                }

                LoadDataToUI();
            }
            catch (Exception err)
            {
                Logging.M(err.Message, "Oops, there's an error that needs special attetion.");
                Logging.LogError(err);

            }
        }

        private void LoadDataToUI()
        {
            serverBox.Items.Clear();

            FormAdd AddNew = new FormAdd();
            AddNew._publicKey = Application.StartupPath + @"\PublicKey.xml";
            AddNew._privateKey = Properties.Settings.Default.privkeypath;

            ToolStripMenuItem item;
            ToolStripMenuItem subItem;

            ToolStripMenuItem exitItem = new ToolStripMenuItem
            {
                ForeColor = Color.Tomato,
                Text = "Exit"
            };

            exitItem.Click += ExitItem_Click;

            trayMenu.Items.Clear();

            frmAddGroup.RefreshGroups();
            foreach (string g in frmAddGroup.groups.Split(','))
            {
                item = new ToolStripMenuItem(g);
                item.ForeColor = Color.Silver;

                var z = AddNew.DB.FindAll(x => AddNew.Decrypt(x.Group) == g);
                foreach (var q in z)
                {
                    subItem = new ToolStripMenuItem(AddNew.Decrypt(q.Name));
                    subItem.ForeColor = Color.LimeGreen;
                    subItem.Click += Item_Click;

                    item.DropDownItems.Add(subItem);

                    trayMenu.Items.Add(item);
                    serverBox.Items.Add(AddNew.Decrypt(q.Name));
                }
            }



            trayMenu.Items.Add(exitItem);
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            isRealExit = true;
            Application.Exit();
        }

        private void Item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem x = (ToolStripMenuItem)(sender);
            ProcessItem(x.Text);
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (serverBox.SelectedIndex >= 0) ProcessItem(serverBox.SelectedItem.ToString());
        }

        private void ProcessItem(string name)
        {
            FormAdd AddNew = new FormAdd();
            AddNew._publicKey = Application.StartupPath + @"\PublicKey.xml";
            AddNew._privateKey = Properties.Settings.Default.privkeypath;

            var acc = AddNew.DB.Find(x => AddNew.Decrypt(x.Name) == name);
            if (acc != null)
            {
                switch (AddNew.Decrypt(acc.Type))
                {
                    case "RDP":
                        Process rdcProcess = new Process();
                        rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmd.exe");
                        rdcProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        rdcProcess.StartInfo.Arguments = "/c cmdkey.exe /generic:" + AddNew.Decrypt(acc.IP) + " /user:" + AddNew.Decrypt(acc.User) + " /pass:" + AddNew.Decrypt(acc.Pass) + " & mstsc.exe /v " + AddNew.Decrypt(acc.IP);
                        rdcProcess.Start();
                        break;
                    case "FileZilla":
                        if (string.IsNullOrEmpty(FileZillaClient))
                        {
                            MessageBox.Show("Please install FileZilla Client to connect.");
                            return;
                        }

                        Process sftpprocess = new Process();
                        string sftpFlag = "ftp";
                        if (AddNew.Decrypt(acc.SFTP) == "true") sftpFlag = "sftp";

                        sftpprocess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmd.exe");
                        sftpprocess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        sftpprocess.StartInfo.Arguments = $"/c \"{FileZillaClient}\" {sftpFlag}://{AddNew.Decrypt(acc.User)}:{AddNew.Decrypt(acc.Pass)}@{AddNew.Decrypt(acc.IP)}:{AddNew.Decrypt(acc.Port)}";
                        sftpprocess.Start();
                        break;
                    case "Putty":
                        Process puttylogin = new Process();
                        if (System.IO.File.Exists("coffeed.conf"))
                        {
                            if (string.IsNullOrEmpty(settings.Read("putty_path")))
                            {
                                puttylogin.StartInfo.FileName = Application.StartupPath + @"\putty.exe";
                            }
                            else
                            {
                                puttylogin.StartInfo.FileName = settings.Read("putty_path");
                            }
                        }
                        else
                        {
                            puttylogin.StartInfo.FileName = Application.StartupPath + @"\putty.exe";
                        }
                        puttylogin.StartInfo.Arguments = "-ssh " + AddNew.Decrypt(acc.User) + "@" + AddNew.Decrypt(acc.IP) + " -pw " + AddNew.Decrypt(acc.Pass) + " -P " + AddNew.Decrypt(acc.Port);
                        puttylogin.Start();

                        break;
                    default:
                        break;
                }
                //MessageBox.Show(AddNew.Decrypt(acc.Pass));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !isRealExit;
            this.Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.Focus();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isRealExit = true;
            Application.Exit();
        }

        internal static IEnumerable<Account> findIt(string filter)
        {
            FormAdd AddNew = new FormAdd();
            AddNew._publicKey = Application.StartupPath + @"\PublicKey.xml";
            AddNew._privateKey = Properties.Settings.Default.privkeypath;
            var byName = AddNew.DB.FindAll(x => AddNew.Decrypt(x.Name).ToLowerInvariant().Contains(filter.ToLowerInvariant()));
            var byGroup = AddNew.DB.FindAll(c => AddNew.Decrypt(c.Group).ToLowerInvariant().Contains(filter.ToLowerInvariant()));
            var byIP = AddNew.DB.FindAll(d => AddNew.Decrypt(d.IP).ToLowerInvariant().Contains(filter.ToLowerInvariant()));

            List<Account> allFilters = new List<Account>();
            allFilters.AddRange(byName);
            allFilters.AddRange(byGroup);
            allFilters.AddRange(byIP);


            return allFilters.Distinct();
        }
        private void removeCredsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        private void DeleteItem()
        {
            if (serverBox.SelectedIndex >= 0)
            {
                if (MessageBox.Show($"Are you sure you want to remove {serverBox.SelectedItem.ToString()} ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FormAdd AddNew = new FormAdd();
                    AddNew._publicKey = Application.StartupPath + @"\PublicKey.xml";
                    AddNew._privateKey = Properties.Settings.Default.privkeypath;

                    int toDelete = AddNew.DB.FindIndex(x => AddNew.Decrypt(x.Name) == serverBox.SelectedItem.ToString());

                    if (toDelete >= 0) AddNew.DB.RemoveAt(toDelete);

                    AddNew.SaveDB(AddNew.DB);
                    LoadDataToUI();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormOptions o = new FormOptions();
            o.ShowDialog();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            txtIP.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtGroup.Text = string.Empty;
            btnTrash.Visible = false;
            btnModify.Visible = false;

            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                FormAdd AddNew = new FormAdd();
                AddNew._publicKey = Application.StartupPath + @"\PublicKey.xml";
                AddNew._privateKey = Properties.Settings.Default.privkeypath;

                serverBox.Items.Clear();

                foreach (var x in findIt(textBox5.Text))
                {
                    serverBox.Items.Add(AddNew.Decrypt(x.Name));
                }


            }
            else
            {
                LoadDataToUI();
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        private void serverBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serverBox.SelectedIndex < 0) return; //exiame

            FormAdd AddNew = new FormAdd();
            AddNew._publicKey = Application.StartupPath + @"\PublicKey.xml";
            AddNew._privateKey = Properties.Settings.Default.privkeypath;

            var x = AddNew.DB.Find(y => AddNew.Decrypt(y.Name) == serverBox.SelectedItem.ToString());
            txtIP.Text = "IP Address: " + AddNew.Decrypt(x.IP);
            txtUsername.Text = "Username: " + AddNew.Decrypt(x.User);
            txtGroup.Text = "In Group: " + AddNew.Decrypt(x.Type);

            txtIP.Visible = true;
            txtUsername.Visible = true;
            txtGroup.Visible = true;
            btnTrash.Visible = true;
            btnModify.Visible = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            new frmAbout().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (serverBox.SelectedIndex >= 0)
            {
                // des ithele 2 init to AddNew me th mpakalia what?????? des kalutera.. OOOOOOOOOOOOOOOXI RE MALAKAAAA
                FormAdd AddNew = new FormAdd();
                AddNew._publicKey = Application.StartupPath + @"\PublicKey.xml";
                AddNew._privateKey = Properties.Settings.Default.privkeypath;

                int toModify = AddNew.DB.FindIndex(x => AddNew.Decrypt(x.Name) == serverBox.SelectedItem.ToString());
                AddNew = new FormAdd(toModify);
                AddNew.ShowDialog();

                LoadDataToUI();

            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DialogResult coffee;
            do
            {
                coffee = MessageBox.Show("You can drink more coffee from now on, using this application, with peace of mind!", "Do you want more coffee?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            while (coffee != DialogResult.Yes);
        }
    }


    [Serializable]
    public class Account
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Port { get; set; }
        public string SFTP { get; set; }
        public string Group { get; set; }
    }
}

public class MyColorTable : ProfessionalColorTable
{
    public override Color MenuItemBorder
    {
        get { return Color.FromArgb(1, 1, 1); }
    }
    public override Color MenuItemSelected
    {
        get { return Color.FromArgb(20, 20, 20); }
    }
    public override Color ToolStripDropDownBackground
    {
        get { return Color.FromArgb(1, 1, 1); }
    }
    public override Color ImageMarginGradientBegin
    {
        get { return Color.FromArgb(1, 1, 1); }
    }
    public override Color ImageMarginGradientMiddle
    {
        get { return Color.FromArgb(1, 1, 1); }
    }
    public override Color ImageMarginGradientEnd
    {
        get { return Color.FromArgb(1, 1, 1); }
    }

}
public class MyRenderer : ToolStripProfessionalRenderer
{
    public MyRenderer() : base(new MyColorTable())
    {
    }
    protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
    {

        var tsMenuItem = e.Item as ToolStripMenuItem;
        if (tsMenuItem != null)
            e.ArrowColor = Color.DodgerBlue;
        base.OnRenderArrow(e);
        //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        //var r = new Rectangle(e.ArrowRectangle.Location, e.ArrowRectangle.Size);
        //r.Inflate(-2, -6);
        //e.Graphics.DrawLines(Pens.Black, new Point[]{
        //new Point(r.Left, r.Top),
        //new Point(r.Right, r.Top + r.Height /2),
        //new Point(r.Left, r.Top+ r.Height)});
    }

    protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        var r = new Rectangle(e.ImageRectangle.Location, e.ImageRectangle.Size);
        r.Inflate(-4, -6);
        e.Graphics.DrawLines(Pens.Black, new Point[]{
        new Point(r.Left, r.Bottom - r.Height /2),
        new Point(r.Left + r.Width /3,  r.Bottom),
        new Point(r.Right, r.Top)});
    }
}
