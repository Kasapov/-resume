namespace WindowsFormsApp9
{
    partial class Process
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Process));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Processes = new System.Windows.Forms.ListBox();
            this.BlackList = new System.Windows.Forms.ListBox();
            this.ProcessBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddToBlackList = new System.Windows.Forms.Button();
            this.KillProcess = new System.Windows.Forms.Button();
            this.AddProcess = new System.Windows.Forms.Button();
            this.AddProcessBox = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.RemoveFromBlackList = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Processes
            // 
            this.Processes.FormattingEnabled = true;
            this.Processes.Location = new System.Drawing.Point(41, 17);
            this.Processes.Name = "Processes";
            this.Processes.Size = new System.Drawing.Size(472, 251);
            this.Processes.TabIndex = 1;
            // 
            // BlackList
            // 
            this.BlackList.FormattingEnabled = true;
            this.BlackList.Location = new System.Drawing.Point(586, 12);
            this.BlackList.Name = "BlackList";
            this.BlackList.Size = new System.Drawing.Size(214, 238);
            this.BlackList.TabIndex = 2;
            // 
            // ProcessBox1
            // 
            this.ProcessBox1.Location = new System.Drawing.Point(719, 298);
            this.ProcessBox1.Name = "ProcessBox1";
            this.ProcessBox1.Size = new System.Drawing.Size(137, 20);
            this.ProcessBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(536, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите запрещенный процесс";
            // 
            // AddToBlackList
            // 
            this.AddToBlackList.Location = new System.Drawing.Point(751, 324);
            this.AddToBlackList.Name = "AddToBlackList";
            this.AddToBlackList.Size = new System.Drawing.Size(75, 23);
            this.AddToBlackList.TabIndex = 5;
            this.AddToBlackList.Text = "Ок";
            this.AddToBlackList.UseVisualStyleBackColor = true;
            this.AddToBlackList.Click += new System.EventHandler(this.AddToBlackList_Click);
            // 
            // KillProcess
            // 
            this.KillProcess.Location = new System.Drawing.Point(41, 274);
            this.KillProcess.Name = "KillProcess";
            this.KillProcess.Size = new System.Drawing.Size(135, 23);
            this.KillProcess.TabIndex = 6;
            this.KillProcess.Text = "Завершить процесс";
            this.KillProcess.UseVisualStyleBackColor = true;
            this.KillProcess.Click += new System.EventHandler(this.KillProcess_Click);
            // 
            // AddProcess
            // 
            this.AddProcess.Location = new System.Drawing.Point(400, 277);
            this.AddProcess.Name = "AddProcess";
            this.AddProcess.Size = new System.Drawing.Size(113, 23);
            this.AddProcess.TabIndex = 7;
            this.AddProcess.Text = "Запустить процесс";
            this.AddProcess.UseVisualStyleBackColor = true;
            this.AddProcess.Click += new System.EventHandler(this.AddProcess_Click);
            // 
            // AddProcessBox
            // 
            this.AddProcessBox.Location = new System.Drawing.Point(182, 277);
            this.AddProcessBox.Name = "AddProcessBox";
            this.AddProcessBox.Size = new System.Drawing.Size(200, 20);
            this.AddProcessBox.TabIndex = 9;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // RemoveFromBlackList
            // 
            this.RemoveFromBlackList.Location = new System.Drawing.Point(610, 256);
            this.RemoveFromBlackList.Name = "RemoveFromBlackList";
            this.RemoveFromBlackList.Size = new System.Drawing.Size(152, 23);
            this.RemoveFromBlackList.TabIndex = 10;
            this.RemoveFromBlackList.Text = "Убрать из  черного списка";
            this.RemoveFromBlackList.UseVisualStyleBackColor = true;
            this.RemoveFromBlackList.Click += new System.EventHandler(this.RemoveFromBlackList_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Process Manager";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_Click);
            // 
            // Process
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(970, 352);
            this.Controls.Add(this.RemoveFromBlackList);
            this.Controls.Add(this.AddProcessBox);
            this.Controls.Add(this.AddProcess);
            this.Controls.Add(this.KillProcess);
            this.Controls.Add(this.AddToBlackList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProcessBox1);
            this.Controls.Add(this.BlackList);
            this.Controls.Add(this.Processes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Process";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox Processes;
        private System.Windows.Forms.ListBox BlackList;
        private System.Windows.Forms.TextBox ProcessBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddToBlackList;
        private System.Windows.Forms.Button KillProcess;
        private System.Windows.Forms.Button AddProcess;
        private System.Windows.Forms.TextBox AddProcessBox;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button RemoveFromBlackList;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}