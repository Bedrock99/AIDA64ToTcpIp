namespace AIDA64ToTcpIp_Client
{
    partial class UCAidaIdData
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_Id = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_label = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel_Color = new System.Windows.Forms.Panel();
            this.btn_ChangeColor = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tb_Id);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 41);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AIDA64 Id:";
            // 
            // tb_Id
            // 
            this.tb_Id.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Id.Location = new System.Drawing.Point(3, 16);
            this.tb_Id.Name = "tb_Id";
            this.tb_Id.Size = new System.Drawing.Size(116, 20);
            this.tb_Id.TabIndex = 0;
            this.tb_Id.TextChanged += new System.EventHandler(this.tb_Id_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tb_label);
            this.groupBox2.Location = new System.Drawing.Point(131, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 41);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Label (max. 4 Zeichen):";
            // 
            // tb_label
            // 
            this.tb_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_label.Location = new System.Drawing.Point(3, 16);
            this.tb_label.MaxLength = 4;
            this.tb_label.Name = "tb_label";
            this.tb_label.Size = new System.Drawing.Size(130, 20);
            this.tb_label.TabIndex = 0;
            this.tb_label.TextChanged += new System.EventHandler(this.tb_label_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btn_ChangeColor);
            this.groupBox3.Controls.Add(this.panel_Color);
            this.groupBox3.Location = new System.Drawing.Point(273, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(68, 41);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Farbe:";
            // 
            // panel_Color
            // 
            this.panel_Color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Color.Location = new System.Drawing.Point(6, 16);
            this.panel_Color.Name = "panel_Color";
            this.panel_Color.Size = new System.Drawing.Size(20, 20);
            this.panel_Color.TabIndex = 0;
            // 
            // btn_ChangeColor
            // 
            this.btn_ChangeColor.Location = new System.Drawing.Point(32, 15);
            this.btn_ChangeColor.Name = "btn_ChangeColor";
            this.btn_ChangeColor.Size = new System.Drawing.Size(27, 22);
            this.btn_ChangeColor.TabIndex = 1;
            this.btn_ChangeColor.Text = "...";
            this.btn_ChangeColor.UseVisualStyleBackColor = true;
            this.btn_ChangeColor.Click += new System.EventHandler(this.btn_ChangeColor_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Delete.Location = new System.Drawing.Point(345, 1);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(41, 41);
            this.btn_Delete.TabIndex = 2;
            this.btn_Delete.Text = "X";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // UCAidaIdData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UCAidaIdData";
            this.Size = new System.Drawing.Size(389, 46);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_Id;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_label;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_ChangeColor;
        private System.Windows.Forms.Panel panel_Color;
        private System.Windows.Forms.Button btn_Delete;
    }
}
