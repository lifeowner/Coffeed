using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Coffeed
{
    public partial class frmAddGroup : Form
    {
        public static string groups = File.ReadAllText("groups.dat", Encoding.UTF8).TrimEnd(',');
        public frmAddGroup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!GroupExists(groupName.Text))
            {
                File.AppendAllText("groups.dat", groupName.Text + ",");
                this.Close();
            }
        }

        internal static void RefreshGroups()
        {
            try
            {
                if (File.Exists("groups.dat")) groups = File.ReadAllText("groups.dat", Encoding.UTF8).TrimEnd(',');
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
                if (File.Exists("groups.dat"))
                {
                    var data = File.ReadAllText("groups.dat", Encoding.UTF8).TrimEnd(',');

                    data = data.Replace(key + ",", string.Empty);
                    File.WriteAllText("groups.dat", data, Encoding.UTF8);
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
