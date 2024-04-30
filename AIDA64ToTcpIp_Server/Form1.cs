#region Using...

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

#endregion

namespace AIDA64ToTcpIp_Server
{
    public partial class Form1 : Form
    {
        #region --- Variablen ---

        string m_strStateText = "Starte Server...";
        bool m_bCanClose = false;
        bool m_bIsRunning = false;

        BindingList<MyTcpClient> m_tcpClients = new BindingList<MyTcpClient>();

        #endregion

        #region --- Konstruktor ---

        public Form1()
        {
            InitializeComponent();
            Icon = Properties.Resources.AIDA64ToTcpIp_Server_Icon;
            notifyIcon1.Icon = Properties.Resources.AIDA64ToTcpIp_Server_Icon;
            Text = Text + " - v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            //Load config
            CConfig.Load();

            CConfig.LoadWindow(this);

            if (CConfig.m_bStartMinimized)
                HideDlgToTray();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            dataGridView1.DataSource = m_tcpClients;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[1].Width = 75;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].Width = 75;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //Starten
            timer1.Start();
            DoTask();
        }

        #endregion

        #region --- "Destruktor" ---

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Save Config
            CConfig.Save();
            CConfig.SaveWindow(this);

            //Exit?
            if (e.CloseReason == CloseReason.WindowsShutDown || m_bCanClose)
                return;

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

                //Variablen
                SharedMemSaver pSharedMemSaver = new SharedMemSaver();

                //Start Server
                TcpListener tcpServer;
                try
                {
                    tcpServer = new TcpListener(CConfig.m_pIpAdress, CConfig.m_iPort);
                    tcpServer.Start();
                    m_strStateText = "Server auf " + CConfig.m_pIpAdress.ToString() + ":" + CConfig.m_iPort.ToString() + " gestartet...";
                }
                catch (Exception ex)
                {
                    m_bIsRunning = false;
                    m_strStateText = "Server konnte nicht gestartet werden!";
                    MessageBox.Show(ex.Message, "Server konnte nicht gestartet werden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Open Shared Memory
#if (!DEBUG)
                if (!pSharedMemSaver.OpenView("Global\\AIDA64_SensorValues"))
                {
                    MessageBox.Show("Verbindung zu AIDA64 fehlgeschlagen!\r\nDas Programm wird mit dem Klick auf 'OK' beendet.",
                        "Verbindung zu AIDA64 fehlgeschlagen!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_bCanClose = true;
                    Invoke((MethodInvoker)delegate
                    {
                        Close();
                    });
                }

#endif

                //Loop
                while (!m_bCanClose)
                {
                    try
                    {
                        //AIDA64 auslesen
#if (DEBUG)
                        Random r = new Random();
                        string strXmlData = "";
                        strXmlData += "  <sys>";
                        strXmlData += "    <id>STIME</id>";
                        strXmlData += "    <label>Time</label>";
                        strXmlData += "    <value>15:42:21</value>";
                        strXmlData += "  </sys>";
                        strXmlData += "  <sys>";
                        strXmlData += "    <id>SCPUCLK</id>";
                        strXmlData += "    <label>CPU Clock</label>";
                        strXmlData += "    <value>4290</value>";
                        strXmlData += "  </sys>";
                        strXmlData += "  <sys>";
                        strXmlData += "    <id>SCPUUTI</id>";
                        strXmlData += "    <label>CPU Utilization</label>";
                        strXmlData += "    <value>4</value>";
                        strXmlData += "  </sys>";
                        strXmlData += "  <sys>";
                        strXmlData += "    <id>SMEMUTI</id>";
                        strXmlData += "    <label>Memory Utilization</label>";
                        strXmlData += "    <value>75</value>";
                        strXmlData += "  </sys>";
                        strXmlData += "  <sys>";
                        strXmlData += "    <id>SUSEDMEM</id>";
                        strXmlData += "    <label>Used Memory</label>";
                        strXmlData += "    <value>24389</value>";
                        strXmlData += "  </sys>";
                        strXmlData += "  <temp>";
                        strXmlData += "    <id>TCPU</id>";
                        strXmlData += "    <label>CPU</label>";
                        strXmlData += "    <value>42</value>";
                        strXmlData += "  </temp>";
                        strXmlData += "  <pwr>";
                        strXmlData += "    <id>PCPUPKG</id>";
                        strXmlData += "    <label>CPU Package</label>";
                        strXmlData += "    <value>22.79</value>";
                        strXmlData += "  </pwr>";
#else
                        string strXmlData = pSharedMemSaver.GetData();
#endif
                        string strSend = "<main>" + strXmlData + "</main>";

                        //Tcp Clients annehmen
                        if (tcpServer.Pending())
                        {
                            TcpClient tcpClient = tcpServer.AcceptTcpClient();
                            Invoke((MethodInvoker)delegate
                            {
                                m_tcpClients.Add(new MyTcpClient(tcpClient));
                            });
                        }

                        //Tote Clients löschen
                        for(int i = 0; i < m_tcpClients.Count; i++)
                        {
                            if (!m_tcpClients[i].Client.Connected)
                            {
                                Invoke((MethodInvoker)delegate
                                {
                                    m_tcpClients.RemoveAt(i);
                                });
                                i--;
                            }
                        }

                        //Daten and Tcp Clients senden
                        foreach (MyTcpClient tcpClient in m_tcpClients)
                        {
                            NetworkStream nsClient = tcpClient.Client.GetStream();
                            byte[] aida_data = Encoding.Default.GetBytes(strSend); 
                            nsClient.Write(aida_data, 0, aida_data.Length);
                        }

                        //Updaten, dann warten damit nicht zu viel wird
                        Invoke((MethodInvoker)delegate
                        {
                            dataGridView1.Invalidate();
                        });
                        Thread.Sleep(CConfig.m_iWaitTimeMs);
                    }
                    catch { }
                }

                //Stop Server
                m_strStateText = "Stoppe den Server...";
                tcpServer.Stop();

                m_bIsRunning = false;
            }).Start();
        }

        #endregion

        #region --- Timer Tick ---

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = m_strStateText;
            dataGridView1.Invalidate();
        }

        #endregion

        #region --- MenüItems ---

        private void alleVerbindungenTrennenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisconnectAll();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopAndClose();  
        }

        private void einstellungenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FormSettings().ShowDialog();

            toolStripStatusLabel1.Text = m_strStateText = "Trenne alle Verbindungen...";
            DisconnectAll();
            timer1.Stop();
            menuStrip1.Enabled = false;
          
            m_bCanClose = true;
            while (m_bIsRunning) Application.DoEvents();

            toolStripStatusLabel1.Text = m_strStateText = "Starte Server neu...";
            m_bCanClose = false;
            timer1.Start();
            DoTask();
            menuStrip1.Enabled = true;
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

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Visible && this.WindowState == FormWindowState.Normal)
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
            timer1.Stop();
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
            timer1_Tick(null, null);
            timer1.Start();
        }

        #endregion

        #region --- Hilfsfunktionen ---

        private void StopAndClose()
        {
            toolStripStatusLabel1.Text = m_strStateText = "Warte auf Stoppen des Servers...";
            timer1.Stop();
            menuStrip1.Enabled = false;
            m_bCanClose = true;
            while (m_bIsRunning) Application.DoEvents();
            Close();
        }

        void DisconnectAll()
        {
            while (m_tcpClients.Count > 0)
            {
                m_tcpClients[0].Client.Close();
                m_tcpClients.RemoveAt(0);
            }
            dataGridView1.Invalidate();
        }

        #endregion
    }
}
