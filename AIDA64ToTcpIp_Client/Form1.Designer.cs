namespace AIDA64ToTcpIp_Client
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alleVerbindungenTrennenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zeigeLetzeAIDAAntwortRAWAnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.cms_NotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.anzeigenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCloseFromTray = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv_AidaItems = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.cms_NotifyIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AidaItems)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.einstellungenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alleVerbindungenTrennenToolStripMenuItem,
            this.zeigeLetzeAIDAAntwortRAWAnToolStripMenuItem,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // alleVerbindungenTrennenToolStripMenuItem
            // 
            this.alleVerbindungenTrennenToolStripMenuItem.Name = "alleVerbindungenTrennenToolStripMenuItem";
            this.alleVerbindungenTrennenToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.alleVerbindungenTrennenToolStripMenuItem.Text = "Neu verbinden...";
            this.alleVerbindungenTrennenToolStripMenuItem.Click += new System.EventHandler(this.VerbindungTrennenToolStripMenuItem_Click);
            // 
            // zeigeLetzeAIDAAntwortRAWAnToolStripMenuItem
            // 
            this.zeigeLetzeAIDAAntwortRAWAnToolStripMenuItem.Name = "zeigeLetzeAIDAAntwortRAWAnToolStripMenuItem";
            this.zeigeLetzeAIDAAntwortRAWAnToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.zeigeLetzeAIDAAntwortRAWAnToolStripMenuItem.Text = "Zeige letze AIDA-Antwort RAW an...";
            this.zeigeLetzeAIDAAntwortRAWAnToolStripMenuItem.Click += new System.EventHandler(this.zeigeLetzeAIDAAntwortRAWAnToolStripMenuItem_Click);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenToolStripMenuItem1});
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            // 
            // einstellungenToolStripMenuItem1
            // 
            this.einstellungenToolStripMenuItem1.Name = "einstellungenToolStripMenuItem1";
            this.einstellungenToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.einstellungenToolStripMenuItem1.Text = "Einstellungen...";
            this.einstellungenToolStripMenuItem1.Click += new System.EventHandler(this.einstellungenToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 239);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_Status
            // 
            this.tssl_Status.Name = "tssl_Status";
            this.tssl_Status.Size = new System.Drawing.Size(62, 17);
            this.tssl_Status.Text = "Verbinde...";
            // 
            // cms_NotifyIcon
            // 
            this.cms_NotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anzeigenToolStripMenuItem,
            this.toolStripMenuItemCloseFromTray});
            this.cms_NotifyIcon.Name = "contextMenuStrip1";
            this.cms_NotifyIcon.Size = new System.Drawing.Size(138, 48);
            // 
            // anzeigenToolStripMenuItem
            // 
            this.anzeigenToolStripMenuItem.Name = "anzeigenToolStripMenuItem";
            this.anzeigenToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.anzeigenToolStripMenuItem.Text = "Ausblenden";
            this.anzeigenToolStripMenuItem.Click += new System.EventHandler(this.anzeigenToolStripMenuItem_Click);
            // 
            // toolStripMenuItemCloseFromTray
            // 
            this.toolStripMenuItemCloseFromTray.Name = "toolStripMenuItemCloseFromTray";
            this.toolStripMenuItemCloseFromTray.Size = new System.Drawing.Size(137, 22);
            this.toolStripMenuItemCloseFromTray.Text = "Beenden";
            this.toolStripMenuItemCloseFromTray.Click += new System.EventHandler(this.toolStripMenuItemCloseFromTray_Click);
            // 
            // dgv_AidaItems
            // 
            this.dgv_AidaItems.AllowUserToAddRows = false;
            this.dgv_AidaItems.AllowUserToDeleteRows = false;
            this.dgv_AidaItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_AidaItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AidaItems.Location = new System.Drawing.Point(12, 27);
            this.dgv_AidaItems.Name = "dgv_AidaItems";
            this.dgv_AidaItems.Size = new System.Drawing.Size(560, 209);
            this.dgv_AidaItems.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.dgv_AidaItems);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "Form1";
            this.Text = "AIDA64 to TCP/IP Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.cms_NotifyIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AidaItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alleVerbindungenTrennenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Status;
        private System.Windows.Forms.ContextMenuStrip cms_NotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem anzeigenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCloseFromTray;
        private System.Windows.Forms.DataGridView dgv_AidaItems;
        private System.Windows.Forms.ToolStripMenuItem zeigeLetzeAIDAAntwortRAWAnToolStripMenuItem;
    }
}

