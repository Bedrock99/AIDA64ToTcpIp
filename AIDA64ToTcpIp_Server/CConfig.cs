#region Using...

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIDA64ToTcpIp;

#endregion

namespace AIDA64ToTcpIp_Server
{
    public static class CConfig
    {
        #region --- Variablen ---

        public static CRegistryConfig pConfig = new CRegistryConfig("AIDA64ToTcpIp_Server");

        public static bool m_bStartMinimized;

        public static IPAddress m_pIpAdress;
        public static int m_iPort;
        public static int m_iWaitTimeMs;

        #endregion

        #region --- Load ---

        public static void Load()
        {
            m_bStartMinimized = pConfig.ReadBool("m_bStartMinimized", false);

            string strIp = pConfig.Read("m_pIpAdress", "0.0.0.0");
            if (!IPAddress.TryParse(strIp, out m_pIpAdress))
                m_pIpAdress = IPAddress.Any;
            m_iPort = pConfig.ReadInt("m_iPort", 9865);
            m_iWaitTimeMs = pConfig.ReadInt("m_iWaitTimeMs", 1000);
        }

        public static void LoadWindow(Form f_)
        {
            pConfig.LoadWindow(f_, "WINDOWS", true, true);
        }

        public static void LoadWindow(Form f_, SplitContainer[] scs_)
        {
            pConfig.LoadWindow(f_, "WINDOWS", true, true, scs_);
        }

        #endregion

        #region --- Save ---

        public static void Save()
        {
            pConfig.Write("m_bStartMinimized", m_bStartMinimized.ToString());

            pConfig.Write("m_pIpAdress", m_pIpAdress.ToString());
            pConfig.Write("m_iPort", m_iPort.ToString());
            pConfig.Write("m_iWaitTimeMs", m_iWaitTimeMs.ToString());
        }

        public static void SaveWindow(Form f_)
        {
            pConfig.SaveWindow(f_, "WINDOWS");
        }
        public static void SaveWindow(Form f_, SplitContainer[] scs_)
        {
            pConfig.SaveWindow(f_, "WINDOWS", scs_);
        }

        #endregion
    }
}
