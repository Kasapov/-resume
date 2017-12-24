using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.Net;

namespace WindowsFormsApp9
{
    public partial class CompList : Form
    {
        Process Processes;
        NetworkBrowser network = new NetworkBrowser();
        public CompList()
        {
            InitializeComponent();
            
            LbCompList.Items.Add(Environment.MachineName);

            ArrayList list = network.getNetworkComputers();
            foreach (string name in list)
            {
                LbCompList.Items.Add(name);


            }







        }
        private void ViewAllProcesses_Click_1(object sender, EventArgs e)
        {

            if (LbCompList.SelectedIndex != -1)
            {
                if (LbCompList.SelectedItem.ToString() == Environment.MachineName)
                {
                    Processes = new Process();

                    Processes.Show();
                    Hide();
                    timer1.Interval = 1000;
                    timer1.Start();
                }
                else if (UserName.Text != "" && Password.Text != "")
                {
                    Processes = new Process(LbCompList.SelectedItem.ToString(), UserName.Text, Password.Text);
                    if (!Processes.IsDisposed)
                    {
                        Processes.Show();
                        Hide();
                        timer1.Interval = 1000;
                        timer1.Start();
                    }
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Processes.IsDisposed) {
                Show();
                
                timer1.Stop();
            }


        }
    }
}
