using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffeed
{
    public partial class bugfinder : Form
    {
        public bugfinder()
        {
            InitializeComponent();
        }

        private void bugfinder_Load(object sender, EventArgs e)
        {
            listBox4.Enabled = false;
        }
        bool continues = true;
        void runScan(int iStartPort, int iEndPort)
        {
            for (int i = iStartPort; i <= iEndPort; i++)
            {
                Scann(hostinput.Text, i);
            }
            listBox3.BeginInvoke(new Action(() => {
                listBox3.Items.Add(hostinput.Text + " - " + DateTime.Now.ToString());
            }));
        }
        void Scann(string ipaddress, int port)
        {
            IPAddress ipo = IPAddress.Parse(ipaddress);
            IPEndPoint ipEo = new IPEndPoint(ipo, port);
            try
            {
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  // Verbindung vorbereiten
                IAsyncResult result = sock.BeginConnect(ipEo,null,null);
                bool success = result.AsyncWaitHandle.WaitOne(100, true);
                if (sock.Connected)
                {
                    sock.EndConnect(result);
                    listBox2.BeginInvoke(new Action(() => {
                        listBox1.Items.Add(port);
                    }));
                }
                else
                {
                    listBox2.BeginInvoke(new Action(() =>
                    {
                        listBox2.Items.Add(port);
                    }));
                }

                sock.Close();
            }
            catch
            {
                listBox2.BeginInvoke(new Action(() =>
                {
                    listBox2.Items.Add(port);
                }));
                
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            runScan(int.Parse(intstartport.Text), int.Parse(intstopport.Text));
        }
        int curms;
        int pastms;
        private void button2_Click(object sender, EventArgs e)
        {
            pastms = DateTime.Now.Millisecond;
            continues = true;
            backgroundWorker2.RunWorkerAsync();
        }

        void runPing(string ipaddress, int port)
        {
            IPAddress ipo = IPAddress.Parse(ipaddress);
            IPEndPoint ipEo = new IPEndPoint(ipo, port);
            try
            {
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  // Verbindung vorbereiten
                IAsyncResult result = sock.BeginConnect(ipEo, null, null);
                bool success = result.AsyncWaitHandle.WaitOne(1000, true);
                if (sock.Connected)
                {
                    curms = DateTime.Now.Millisecond;
                    listBox4.BeginInvoke(new Action(() =>
                    {
                        int milisecond = (curms-pastms);
                        listBox4.Items.Add("Host " + ipaddress + ":"+ port +" took " + milisecond.ToString() + " ms");
                    }));
                }
                else
                {
                    listBox4.BeginInvoke(new Action(() =>
                    {
                        listBox4.Items.Add("Host " + ipaddress + ":"+ port + " is unreachable.");
                    }));
                }

                sock.Close();
            }
            catch
            {
                listBox2.BeginInvoke(new Action(() =>
                {
                    listBox2.Items.Add(port);
                }));

            }
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            int lport = 0;
            listBox1.BeginInvoke(new Action(() =>
            {
                lport = int.Parse(listBox1.GetItemText(listBox1.SelectedItem));
            }));
        loopit:
            if (continues)
            {
                listBox4.BeginInvoke(new Action(() =>
                {
                    int visibleItems = listBox4.ClientSize.Height / listBox4.ItemHeight;
                    listBox4.TopIndex = Math.Max(listBox4.Items.Count - visibleItems + 1, 0);
                }));
                runPing(hostinput.Text, lport);
                System.Threading.Thread.Sleep(1500);
                pastms = DateTime.Now.Millisecond;
                goto loopit;
            }
            else
            {
                backgroundWorker2.CancelAsync();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            continues = false;
        }
    }
}
