#region Using...

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIDA64ToTcpIp;

#endregion


namespace AIDA64ToTcpIp_Client
{
    public static class CConfig
    {
        #region --- Variablen ---

        public static CRegistryConfig pConfig = new CRegistryConfig("AIDA64ToTcpIp_Client");

        public static bool m_bStartMinimized;

        public static IPAddress m_pIpAdress;
        public static int m_iPort;
        public static int m_iWaitTimeMs;
        public static List<CAidaIdData> m_lstAidaIdTo4DigitName = new List<CAidaIdData>(); //ALWAYS 4 CHARS
        public static List<string> m_lstActiveAidaItemIds = new List<string>();

        #endregion

        #region --- Load ---

        public static void Load()
        {
            m_bStartMinimized = pConfig.ReadBool("m_bStartMinimized", false);

            string strIp = pConfig.Read("m_pIpAdress", "127.0.0.1");
            if (!IPAddress.TryParse(strIp, out m_pIpAdress))
                m_pIpAdress = IPAddress.Any;
            m_iPort = pConfig.ReadInt("m_iPort", 9865);
            m_iWaitTimeMs = pConfig.ReadInt("m_iWaitTimeMs", 1000);

            int iCount = pConfig.ReadInt("AIDA_TO_4DIGIT_NAME", "Count", 0);
            for(int i = 0; i < iCount; i++)
            {
                string strId = pConfig.Read("AIDA_TO_4DIGIT_NAME", "Item" + i.ToString(), "ID", "");
                string Label4Digit = pConfig.Read("AIDA_TO_4DIGIT_NAME", "Item" + i.ToString(), "Label4Digit", "UNKN");
                int iColor = pConfig.ReadInt("AIDA_TO_4DIGIT_NAME", "Item" + i.ToString(), "Color", Color.Gray.ToArgb());
                if(!string.IsNullOrWhiteSpace(strId))
                    m_lstAidaIdTo4DigitName.Add(new CAidaIdData(strId, Label4Digit, Color.FromArgb(iColor)));
            }

            iCount = pConfig.ReadInt("ACTIVE_AIDA_ITEM_IDS", "Count", 0);
            for (int i = 0; i < iCount; i++)
            {
                string strId = pConfig.Read("ACTIVE_AIDA_ITEM_IDS", "Item" + i.ToString(), "");
                if (!string.IsNullOrWhiteSpace(strId))
                    m_lstActiveAidaItemIds.Add(strId);
            }

            if (m_lstAidaIdTo4DigitName.Count == 0)
            {
                m_lstAidaIdTo4DigitName.Add(new CAidaIdData("TCPU", "Temp", Color.FromArgb(255, 32, 32)));
                m_lstAidaIdTo4DigitName.Add(new CAidaIdData("SCPUUTI", "Load", Color.Yellow));
                m_lstAidaIdTo4DigitName.Add(new CAidaIdData("SCPUCLK", "Freq", Color.Cyan));
                m_lstAidaIdTo4DigitName.Add(new CAidaIdData("PCPUPKG", "Pwr ", Color.Magenta));
            }

            if (m_lstActiveAidaItemIds.Count == 0)
            {
                m_lstActiveAidaItemIds.Add("SCPUCLK");
                m_lstActiveAidaItemIds.Add("SCPUUTI");
                m_lstActiveAidaItemIds.Add("TCPU");
                m_lstActiveAidaItemIds.Add("PCPUPKG");
            }
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

            pConfig.Write("AIDA_TO_4DIGIT_NAME", "Count", m_lstAidaIdTo4DigitName.Count.ToString());
            for(int i = 0; i < m_lstAidaIdTo4DigitName.Count; i++)
            {
                pConfig.Write("AIDA_TO_4DIGIT_NAME", "Item" + i.ToString(), "ID", m_lstAidaIdTo4DigitName[i].ID);
                pConfig.Write("AIDA_TO_4DIGIT_NAME", "Item" + i.ToString(), "Label4Digit", m_lstAidaIdTo4DigitName[i].Label4Digit);
                pConfig.Write("AIDA_TO_4DIGIT_NAME", "Item" + i.ToString(), "Color", m_lstAidaIdTo4DigitName[i].Color.ToArgb().ToString());
            }

            pConfig.Write("ACTIVE_AIDA_ITEM_IDS", "Count", m_lstActiveAidaItemIds.Count.ToString());
            for (int i = 0; i < m_lstActiveAidaItemIds.Count; i++)
            {
                pConfig.Write("ACTIVE_AIDA_ITEM_IDS", "Item" + i.ToString(), m_lstActiveAidaItemIds[i]);
            }
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
