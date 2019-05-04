namespace Proxy_Server
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TBMyIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBMyPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBRedirectIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TBRedirectPort = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTNStart = new System.Windows.Forms.Button();
            this.LBStatus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LBClients = new System.Windows.Forms.ListBox();
            this.BTNKickClient = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.BTNDisconnectAll = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LBStatus);
            this.groupBox1.Controls.Add(this.BTNStart);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.TBRedirectPort);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TBRedirectIP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TBMyPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TBMyIP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 167);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Confs";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // TBMyIP
            // 
            this.TBMyIP.Location = new System.Drawing.Point(32, 19);
            this.TBMyIP.Name = "TBMyIP";
            this.TBMyIP.Size = new System.Drawing.Size(149, 20);
            this.TBMyIP.TabIndex = 1;
            this.TBMyIP.Text = "192.168.42.164";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // TBMyPort
            // 
            this.TBMyPort.Location = new System.Drawing.Point(234, 19);
            this.TBMyPort.Name = "TBMyPort";
            this.TBMyPort.Size = new System.Drawing.Size(73, 20);
            this.TBMyPort.TabIndex = 3;
            this.TBMyPort.Text = "7000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Redirect IP: ";
            // 
            // TBRedirectIP
            // 
            this.TBRedirectIP.Location = new System.Drawing.Point(78, 102);
            this.TBRedirectIP.Name = "TBRedirectIP";
            this.TBRedirectIP.Size = new System.Drawing.Size(229, 20);
            this.TBRedirectIP.TabIndex = 5;
            this.TBRedirectIP.Text = "158.69.63.181";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Port:  ";
            // 
            // TBRedirectPort
            // 
            this.TBRedirectPort.Location = new System.Drawing.Point(78, 134);
            this.TBRedirectPort.Name = "TBRedirectPort";
            this.TBRedirectPort.Size = new System.Drawing.Size(62, 20);
            this.TBRedirectPort.TabIndex = 7;
            this.TBRedirectPort.Text = "80";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(-31, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 10);
            this.panel1.TabIndex = 8;
            // 
            // BTNStart
            // 
            this.BTNStart.Location = new System.Drawing.Point(328, 12);
            this.BTNStart.Name = "BTNStart";
            this.BTNStart.Size = new System.Drawing.Size(116, 33);
            this.BTNStart.TabIndex = 9;
            this.BTNStart.Text = "Start";
            this.BTNStart.UseVisualStyleBackColor = true;
            this.BTNStart.Click += new System.EventHandler(this.BTNStart_Click);
            // 
            // LBStatus
            // 
            this.LBStatus.AutoSize = true;
            this.LBStatus.Location = new System.Drawing.Point(6, 58);
            this.LBStatus.Name = "LBStatus";
            this.LBStatus.Size = new System.Drawing.Size(89, 13);
            this.LBStatus.TabIndex = 10;
            this.LBStatus.Text = "Status: Parado ...";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BTNDisconnectAll);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.BTNKickClient);
            this.groupBox2.Controls.Add(this.LBClients);
            this.groupBox2.Location = new System.Drawing.Point(4, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 274);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clients";
            // 
            // LBClients
            // 
            this.LBClients.FormattingEnabled = true;
            this.LBClients.Location = new System.Drawing.Point(6, 19);
            this.LBClients.Name = "LBClients";
            this.LBClients.Size = new System.Drawing.Size(301, 238);
            this.LBClients.TabIndex = 0;
            // 
            // BTNKickClient
            // 
            this.BTNKickClient.Location = new System.Drawing.Point(313, 19);
            this.BTNKickClient.Name = "BTNKickClient";
            this.BTNKickClient.Size = new System.Drawing.Size(137, 27);
            this.BTNKickClient.TabIndex = 1;
            this.BTNKickClient.Text = "Kick client";
            this.BTNKickClient.UseVisualStyleBackColor = true;
            this.BTNKickClient.Click += new System.EventHandler(this.BTNKickClient_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(313, 62);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(137, 29);
            this.button3.TabIndex = 2;
            this.button3.Text = "Ban client IP";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // BTNDisconnectAll
            // 
            this.BTNDisconnectAll.Location = new System.Drawing.Point(313, 218);
            this.BTNDisconnectAll.Name = "BTNDisconnectAll";
            this.BTNDisconnectAll.Size = new System.Drawing.Size(137, 39);
            this.BTNDisconnectAll.TabIndex = 3;
            this.BTNDisconnectAll.Text = "Disconnect all";
            this.BTNDisconnectAll.UseVisualStyleBackColor = true;
            this.BTNDisconnectAll.Click += new System.EventHandler(this.BTNDisconnectAll_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 462);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(211, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "@ Proxy simples, feito para intuito de testes";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 479);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proxy Server - version 1.0";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LBStatus;
        private System.Windows.Forms.Button BTNStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TBRedirectPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBRedirectIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBMyPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBMyIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BTNDisconnectAll;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button BTNKickClient;
        private System.Windows.Forms.ListBox LBClients;
        private System.Windows.Forms.Label label6;
    }
}

