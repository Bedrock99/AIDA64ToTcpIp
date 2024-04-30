namespace AIDA64ToTcpIp_Client
{
    partial class FormSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ipAddressCtrl = new IPAddressControlLib.IPAddressControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nud_Port = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nud_WaitTime = new System.Windows.Forms.NumericUpDown();
            this.cb_StartMinimized = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.flp_AidaItems = new System.Windows.Forms.FlowLayoutPanel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btn_AddAidaItem = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Port)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_WaitTime)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(497, 198);
            // 
            // btn_Abort
            // 
            this.btn_Abort.Location = new System.Drawing.Point(416, 198);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ipAddressCtrl);
            this.groupBox1.Location = new System.Drawing.Point(6, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 40);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP-Adresse:";
            // 
            // ipAddressCtrl
            // 
            this.ipAddressCtrl.AllowInternalTab = true;
            this.ipAddressCtrl.AutoHeight = true;
            this.ipAddressCtrl.BackColor = System.Drawing.SystemColors.Window;
            this.ipAddressCtrl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipAddressCtrl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipAddressCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ipAddressCtrl.Location = new System.Drawing.Point(3, 16);
            this.ipAddressCtrl.MinimumSize = new System.Drawing.Size(87, 20);
            this.ipAddressCtrl.Name = "ipAddressCtrl";
            this.ipAddressCtrl.ReadOnly = false;
            this.ipAddressCtrl.Size = new System.Drawing.Size(153, 20);
            this.ipAddressCtrl.TabIndex = 0;
            this.ipAddressCtrl.Text = "...";
            this.ipAddressCtrl.FieldChangedEvent += new System.EventHandler<IPAddressControlLib.FieldChangedEventArgs>(this.ipAddressCtrl_FieldChangedEvent);
            this.ipAddressCtrl.TextChanged += new System.EventHandler(this.SetModifiedExt);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.nud_Port);
            this.groupBox2.Location = new System.Drawing.Point(6, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 40);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Port:";
            // 
            // nud_Port
            // 
            this.nud_Port.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_Port.Location = new System.Drawing.Point(3, 16);
            this.nud_Port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nud_Port.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nud_Port.Name = "nud_Port";
            this.nud_Port.Size = new System.Drawing.Size(153, 20);
            this.nud_Port.TabIndex = 0;
            this.nud_Port.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nud_Port.ValueChanged += new System.EventHandler(this.SetModifiedExt);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.nud_WaitTime);
            this.groupBox3.Location = new System.Drawing.Point(6, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(159, 40);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Wartezeit zwischen Senden:";
            // 
            // nud_WaitTime
            // 
            this.nud_WaitTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_WaitTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_WaitTime.Location = new System.Drawing.Point(3, 16);
            this.nud_WaitTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_WaitTime.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_WaitTime.Name = "nud_WaitTime";
            this.nud_WaitTime.Size = new System.Drawing.Size(153, 20);
            this.nud_WaitTime.TabIndex = 0;
            this.nud_WaitTime.ThousandsSeparator = true;
            this.nud_WaitTime.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_WaitTime.ValueChanged += new System.EventHandler(this.SetModifiedExt);
            // 
            // cb_StartMinimized
            // 
            this.cb_StartMinimized.AutoSize = true;
            this.cb_StartMinimized.Location = new System.Drawing.Point(6, 19);
            this.cb_StartMinimized.Name = "cb_StartMinimized";
            this.cb_StartMinimized.Size = new System.Drawing.Size(102, 17);
            this.cb_StartMinimized.TabIndex = 5;
            this.cb_StartMinimized.Text = "Minimiert starten";
            this.cb_StartMinimized.UseVisualStyleBackColor = true;
            this.cb_StartMinimized.CheckedChanged += new System.EventHandler(this.SetModifiedExt);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cb_StartMinimized);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(171, 180);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Allgemeines:";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.btn_AddAidaItem);
            this.groupBox5.Controls.Add(this.flp_AidaItems);
            this.groupBox5.Location = new System.Drawing.Point(189, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(383, 180);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "AIDA64 ID Zuordnungen (Für IDs siehe AIDA64):";
            // 
            // flp_AidaItems
            // 
            this.flp_AidaItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flp_AidaItems.AutoScroll = true;
            this.flp_AidaItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flp_AidaItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_AidaItems.Location = new System.Drawing.Point(6, 19);
            this.flp_AidaItems.Name = "flp_AidaItems";
            this.flp_AidaItems.Size = new System.Drawing.Size(342, 155);
            this.flp_AidaItems.TabIndex = 0;
            this.flp_AidaItems.WrapContents = false;
            // 
            // btn_AddAidaItem
            // 
            this.btn_AddAidaItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddAidaItem.Location = new System.Drawing.Point(354, 19);
            this.btn_AddAidaItem.Name = "btn_AddAidaItem";
            this.btn_AddAidaItem.Size = new System.Drawing.Size(23, 23);
            this.btn_AddAidaItem.TabIndex = 1;
            this.btn_AddAidaItem.Text = "+";
            this.btn_AddAidaItem.UseVisualStyleBackColor = true;
            this.btn_AddAidaItem.Click += new System.EventHandler(this.btn_AddAidaItem_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 233);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.MinimumSize = new System.Drawing.Size(600, 272);
            this.Name = "FormSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Controls.SetChildIndex(this.btn_Ok, 0);
            this.Controls.SetChildIndex(this.btn_Abort, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_Port)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_WaitTime)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nud_Port;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nud_WaitTime;
        private IPAddressControlLib.IPAddressControl ipAddressCtrl;
        private System.Windows.Forms.CheckBox cb_StartMinimized;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.FlowLayoutPanel flp_AidaItems;
        private System.Windows.Forms.Button btn_AddAidaItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}