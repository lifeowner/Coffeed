using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

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
            if (!GroupExists(groupName.Text)) {
                File.AppendAllText("groups.dat", groupName.Text + ",");
                this.Close();
            }
        }

        internal static void RefreshGroups()
        {
            groups = File.ReadAllText("groups.dat", Encoding.UTF8).TrimEnd(',');
        }
 
        public bool GroupExists(string groupName)
        {
            
            var allGroups = groups.Split(',');
            var result = false;
            foreach(var g in allGroups)
            {
                if(g == groupName)
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
            if (File.Exists("groups.dat"))
            {
                var data = File.ReadAllText("groups.dat", Encoding.UTF8).TrimEnd(',');

                data = data.Replace(key + ",", string.Empty);
                File.WriteAllText("groups.dat", data, Encoding.UTF8);
            }
        }



    }

}
