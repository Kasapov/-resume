using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Management.Infrastructure;
using Microsoft.Management.Infrastructure.Options;
using System.Security;


namespace WindowsFormsApp9
{
    public partial class Process : Form
    {
        string _name = "";     
        ManagementScope scope;

        public Process()
        {
           
            InitializeComponent();
            ConnectionOptions options = new ConnectionOptions();
          
            _name = Environment.MachineName;

            scope = new ManagementScope("\\\\" + _name + "\\root\\cimv2", options);
            scope.Connect();

            timer1.Interval = 1000;
            timer1.Start();
            timer2.Interval = 1000;
            timer2.Start();
            notifyIcon1.Visible = false;
      
            this.Resize += new System.EventHandler(this.Process_Resize);
          

        }
        public Process(string name, string username, string password)
        {
            InitializeComponent();
            _name = name;
             
           
            ConnectionOptions options = new ConnectionOptions();
             options.Impersonation = ImpersonationLevel.Impersonate;
           
            options.EnablePrivileges = true;
            options.Username = username;
            options.Password = password;

            notifyIcon1.Visible = false;
            
            this.Resize += new System.EventHandler(this.Process_Resize);

            scope = new ManagementScope("\\\\" + _name + "\\root\\cimv2", options);
            try
            {
                scope.Connect();

            }
            catch (System.UnauthorizedAccessException)
            {
                MessageBox.Show("Ошибка доступа");

               Close();
            }
            



            timer1.Interval = 1000;
            timer1.Start();
            timer2.Interval = 1000;
            timer2.Start();


        }
       

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Interval = 60000;
            Processes.Items.Clear();

            ObjectQuery query = new ObjectQuery("select name from win32_process");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection queryCollection = searcher.Get();
            foreach (ManagementObject m in queryCollection)
            {
                Processes.Items.Add(m["Name"]);
            }


        }

        

        private void KillProcess_Click(object sender, EventArgs e)
        {if (Processes.SelectedIndex != -1)
            {
                ObjectQuery theQuery = new ObjectQuery("SELECT * FROM Win32_Process WHERE Name=" + "'" + (Processes.SelectedItem.ToString()) + "'");

                using (ManagementObjectSearcher theSearcher = new ManagementObjectSearcher(scope, theQuery))
                {

                    ManagementObjectCollection theCollection = theSearcher.Get();

                    foreach (ManagementObject theCurObject in theCollection)

                    {

                        theCurObject.InvokeMethod("Terminate", null);

                    }
                }
            }
            else
            {

                MessageBox.Show("Выберите процесс");

            }
            
        }

      

        private void AddProcess_Click(object sender, EventArgs e)
        {
            ManagementPath path = new ManagementPath("Win32_Process");
            ManagementClass classObj = new ManagementClass(scope, path, null);
           ManagementBaseObject inParams = null;
            inParams = classObj.GetMethodParameters("Create");
            inParams["CommandLine"] = AddProcessBox.Text;
            inParams["CurrentDirectory"] = "C:\\WINDOWS\\system32\\";
            ManagementBaseObject outParams = classObj.InvokeMethod("Create", inParams, null);


        }

        private void AddToBlackList_Click(object sender, EventArgs e)
        {
            BlackList.Items.Add(ProcessBox1.Text);
            ProcessBox1.Clear();


        }

        private void timer2_Tick(object sender, EventArgs e)
        { 
            for(int i = 0; i < BlackList.Items.Count; i++)
            {
                if (Processes.Items.Contains(BlackList.Items[i]))
                {
                    ObjectQuery theQuery = new ObjectQuery("SELECT * FROM Win32_Process WHERE Name=" + "'" + (BlackList.Items[i]) + "'");

                    using (ManagementObjectSearcher theSearcher = new ManagementObjectSearcher(scope, theQuery))
                    {

                        ManagementObjectCollection theCollection = theSearcher.Get();

                        foreach (ManagementObject theCurObject in theCollection)

                        {

                            theCurObject.InvokeMethod("Terminate", null);

                        }
                    }

                }

            }
        }

   
        private void Process_Resize(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;

            }
        }

    

        private void RemoveFromBlackList_Click(object sender, EventArgs e)
        {
            if(BlackList.SelectedIndex!=-1)
            {
                BlackList.Items.RemoveAt(BlackList.SelectedIndex);

            }
            else
            {
                MessageBox.Show("Выберите процесс");

            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Show();
                this.WindowState = FormWindowState.Normal;
                
                
                notifyIcon1.Visible = false;
            }
        }

       

     
    }
}
