#region Using...

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

#endregion

namespace AIDA64ToTcpIp_Client
{
    public partial class Form1 : Form
    {
        #region --- Variablen ---

        bool m_bWantDisconnect = false;
        bool m_bIsRunning = false;
        string m_strLastAIDARaw = "";
        BindingList<CAIDAItem> m_AidaItemlist = new BindingList<CAIDAItem>();
        List<NotifyIcon> m_NotifyIconlist = new List<NotifyIcon>();

        #endregion

        #region --- Konstruktor ---

        public Form1()
        {
            InitializeComponent();
            Icon = Properties.Resources.AIDA64ToTcpIp_Client;
            Text = Text + " - v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            dgv_AidaItems.DataSource = m_AidaItemlist;
            dgv_AidaItems.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_AidaItems.Columns[0].Width = 50;
            dgv_AidaItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_AidaItems.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_AidaItems.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_AidaItems.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_AidaItems.Columns[4].Width = 75;
            dgv_AidaItems.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_AidaItems.Columns[5].Width = 50;

            //Load config
            CConfig.Load();

            CConfig.LoadWindow(this);

            if (CConfig.m_bStartMinimized)
                HideDlgToTray();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //Starten
            DoTask();
        }

        #endregion

        #region --- "Destruktor" ---

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Save Config
            CConfig.Save();
            CConfig.SaveWindow(this);

            //Exit
            if (e.CloseReason == CloseReason.WindowsShutDown || !m_bIsRunning)
            {
                foreach (NotifyIcon icon in m_NotifyIconlist)
                    icon.Dispose();
                return;
            }

            //Only Hide
            e.Cancel = true;
            HideDlgToTray();
        }

        #endregion

        #region --- DoTask ---

        void DoTask()
        {
            new Task(() =>
            {
                m_bIsRunning = true;

                SetStatus("Verbinde zu " + CConfig.m_pIpAdress.ToString() + ":" + CConfig.m_iPort.ToString() + "...");
                TcpClient tcpClient = new TcpClient();
                while(!tcpClient.Connected)
                    try { tcpClient.Connect(CConfig.m_pIpAdress, CConfig.m_iPort); } catch { }
                
                SetStatus("Verbunden zu " + CConfig.m_pIpAdress.ToString() + ":" + CConfig.m_iPort.ToString());

                while(tcpClient.Connected && ! m_bWantDisconnect)
                {
                    NetworkStream nsClient = tcpClient.GetStream();

                    string strRead = "";
                    while (nsClient.DataAvailable)
                    {
                        byte[] bb = new byte[100];
                        int k = nsClient.Read(bb, 0, 100);

                        for (int i = 0; i < k; i++)
                            strRead += Convert.ToChar(bb[i]);
                    }

                    if (!string.IsNullOrWhiteSpace(strRead))
                    {
                        strRead = strRead.Substring(strRead.LastIndexOf("<main>"));
                        ReadAidaXml(strRead);
                    }

                    UpdateNotifyIcons();
                    Thread.Sleep(CConfig.m_iWaitTimeMs);
                }

                tcpClient.Close();
                Invoke((MethodInvoker)delegate
                {
                    m_AidaItemlist.Clear();
                    dgv_AidaItems.Invalidate();
                });
                SetStatus("Nicht verbunden!");
                m_bIsRunning = false;
            }).Start();
        }

        private void ReadAidaXml(string strXml_)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(strXml_);
                m_strLastAIDARaw = XDocument.Parse(strXml_).ToString();

                XmlNode xmlMain = xmlDoc.SelectSingleNode("main");
                foreach (XmlNode xmlSys in xmlMain.ChildNodes)
                {
                    string id = xmlSys.SelectSingleNode("id").InnerText;
                    string label = xmlSys.SelectSingleNode("label").InnerText;
                    string value = xmlSys.SelectSingleNode("value").InnerText;
                    bool bFound = false;
                    Invoke((MethodInvoker)delegate
                    {
                        foreach (CAIDAItem item in m_AidaItemlist)
                        {
                            if (item.Id == id)
                            {
                                item.UpdateData(label, value);
                                bFound = true;
                            }
                        }
                        if (!bFound)
                            m_AidaItemlist.Add(new CAIDAItem(id, label, value));
                    });
                }
                Invoke((MethodInvoker)delegate
                {
                    dgv_AidaItems.Invalidate();
                });
                SetStatus("Letztes Update von AIDA: " + DateTime.Now.ToString("HH:mm:ss"));
            }
            catch (Exception ex)
            {
                SetStatus("Fehler in der von AIDA empofangenen XML-Datei: " + ex.Message);
            }
        }

        private void UpdateNotifyIcons()
        {
            foreach (CAIDAItem item in m_AidaItemlist)
            {
                int iFound = -1;
                for(int i = 0; i < m_NotifyIconlist.Count; i++)
                {
                    if(m_NotifyIconlist[i].BalloonTipText == item.Id)
                    {
                        if(item.Active) //Update NotifyIcon
                        {
                            m_NotifyIconlist[i].Text = item.Label + ": " + item.GetFormattedValue();
                            UpdateNotifyIcon(m_NotifyIconlist[i], item.Icon);
                        }

                        iFound = i;
                        break;
                    }
                }
                if (iFound == -1 && item.Active) //Create NotifyIcon
                {
                    Invoke((MethodInvoker)delegate
                    {
                        NotifyIcon ni = new NotifyIcon();
                        ni.MouseDoubleClick += notifyIcon_MouseDoubleClick;
                        ni.ContextMenuStrip = cms_NotifyIcon;
                        ni.BalloonTipText = item.Id;
                        ni.Text = item.Label + ": " + item.GetFormattedValue();
                        UpdateNotifyIcon(ni, item.Icon);
                        ni.Visible = true;
                        m_NotifyIconlist.Add(ni);
                    });
                }
                else if(iFound != -1 && !item.Active) //Delete NotifyIcon
                {
                    m_NotifyIconlist[iFound].Dispose();
                    m_NotifyIconlist.RemoveAt(iFound);
                }
            }
        }

        private void UpdateNotifyIcon(NotifyIcon ni_, Bitmap bmp_)
        {
            if (ni_.Icon != null)
                ni_.Icon.Dispose();
            if (bmp_ != null)
                ni_.Icon = FlimFlan.IconEncoder.Converter.BitmapToIcon(bmp_);
            else
                ni_.Icon = SystemIcons.Error;
        }

        #endregion

        #region --- MenüItems ---

        private void VerbindungTrennenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Enabled = false;
            Reconnect();
            menuStrip1.Enabled = true;
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Enabled = false;
            StopAndClose();
        }

        private void einstellungenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            menuStrip1.Enabled = false;
            new FormSettings().ShowDialog();

            foreach(CAIDAItem item in m_AidaItemlist)
                item.UpdateNotifyData();

            Reconnect();
            menuStrip1.Enabled = true;
        }

        private void zeigeLetzeAIDAAntwortRAWAnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(m_strLastAIDARaw))
                new AIDA64ToTcpIp.FormInfoBox("RAW AIDA", m_strLastAIDARaw).ShowDialog();
        }

        #endregion

        #region --- NotifyIcon und Events ---

        private void anzeigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Visible && WindowState == FormWindowState.Normal)
                HideDlgToTray();
            else
                ShowDlgFromTray();
        }

        private void toolStripMenuItemCloseFromTray_Click(object sender, EventArgs e)
        {
            StopAndClose();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Visible && WindowState == FormWindowState.Normal)
                    HideDlgToTray();
                else
                    ShowDlgFromTray();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                HideDlgToTray();
        }

        #endregion

        #region --- Hide/Show Window From Tray ---

        private void HideDlgToTray()
        {
            anzeigenToolStripMenuItem.Text = "Einblenden";
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            Visible = false;
        }

        private void ShowDlgFromTray()
        {
            anzeigenToolStripMenuItem.Text = "Ausblenden";
            Visible = true;
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            TopMost = true;
            TopMost = false;
            Focus();
        }

        #endregion

        #region --- Hilfsfunktionen ---

        void Reconnect()
        {
            m_bWantDisconnect = true;
            while (m_bIsRunning) Application.DoEvents();
            m_bWantDisconnect = false;
            DoTask();
        }

        private void SetStatus(string str_)
        {
            Invoke((MethodInvoker)delegate
            {
                tssl_Status.Text = str_;
            });
        }

        private void StopAndClose()
        {
            SetStatus("Warte auf Stoppen des Servers...");
            menuStrip1.Enabled = false;
            m_bWantDisconnect = true;
            while (m_bIsRunning) Application.DoEvents();
            Close();
        }

        #endregion
    }
}
