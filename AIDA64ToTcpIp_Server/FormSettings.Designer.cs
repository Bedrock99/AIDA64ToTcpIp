namespace AIDA64ToTcpIp_Server
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Port)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_WaitTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(94, 173);
            // 
            // btn_Abort
            // 
            this.btn_Abort.Location = new System.Drawing.Point(13, 173);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ipAddressCtrl);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 40);
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
            this.ipAddressCtrl.Size = new System.Drawing.Size(151, 20);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 40);
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
            this.nud_Port.Size = new System.Drawing.Size(151, 20);
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
            this.groupBox3.Location = new System.Drawing.Point(12, 127);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(157, 40);
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
            this.nud_WaitTime.Size = new System.Drawing.Size(151, 20);
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
            this.cb_StartMinimized.Location = new System.Drawing.Point(12, 12);
            this.cb_StartMinimized.Name = "cb_StartMinimized";
            this.cb_StartMinimized.Size = new System.Drawing.Size(102, 17);
            this.cb_StartMinimized.TabIndex = 5;
            this.cb_StartMinimized.Text = "Minimiert starten";
            this.cb_StartMinimized.UseVisualStyleBackColor = true;
            this.cb_StartMinimized.CheckedChanged += new System.EventHandler(this.SetModifiedExt);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 208);
            this.Controls.Add(this.cb_StartMinimized);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(9999, 247);
            this.MinimumSize = new System.Drawing.Size(197, 247);
            this.Name = "FormSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Controls.SetChildIndex(this.btn_Ok, 0);
            this.Controls.SetChildIndex(this.btn_Abort, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.cb_StartMinimized, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_Port)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_WaitTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nud_Port;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nud_WaitTime;
        private IPAddressControlLib.IPAddressControl ipAddressCtrl;
        private System.Windows.Forms.CheckBox cb_StartMinimized;
    }
}