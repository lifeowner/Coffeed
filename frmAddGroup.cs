using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Coffeed
{
    public partial class frmAddGroup : Form
    {
        public static string groups = File.ReadAllText(Path.Combine(Application.StartupPath, "groups.dat"), Encoding.UTF8).TrimEnd(',');
        public frmAddGroup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!GroupExists(groupName.Text))
            {
                File.AppendAllText(Path.Combine(Application.StartupPath, "groups.dat"), groupName.Text + ",");
                this.Close();
            }
        }

        internal static void RefreshGroups()
        {
            try
            {
                if (File.Exists(Path.Combine(Application.StartupPath, "groups.dat"))) groups = File.ReadAllText(Path.Combine(Application.StartupPath, "groups.dat"), Encoding.UTF8).TrimEnd(',');
            }
            catch (Exception err)
            {
                Logging.M(err.Message, "Oops, there's an error that needs special attetion.");
                Logging.LogError(err);
            }

        }

        public bool GroupExists(string groupName)
        {

            var allGroups = groups.Split(',');
            var result = false;
            foreach (var g in allGroups)
            {
                if (g == groupName)
                {
                    result = true;
                    break;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
        public void removeGroup(string key)
        {
            try
            {
                if (File.Exists(Path.Combine(Application.StartupPath, "groups.dat")))
                {
                    var data = File.ReadAllText(Path.Combine(Application.StartupPath, "groups.dat"), Encoding.UTF8).TrimEnd(',');

                    data = data.Replace(key + ",", string.Empty);
                    File.WriteAllText(Path.Combine(Application.StartupPath, "groups.dat"), data, Encoding.UTF8);
                }

            }
            catch (Exception err)
            {
                Logging.M(err.Message, "Oops, there's an error that needs special attetion.");
                Logging.LogError(err);

            }

        }

        private void frmAddGroup_Load(object sender, EventArgs e)
        {

        }
    }

}
