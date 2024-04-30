#region Using...

using AIDA64ToTcpIp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace AIDA64ToTcpIp_Client
{
    public partial class FormSettings : FormSettingsBase
    {
        #region --- Konstruktor ---

        public FormSettings() : base()
        {
            InitializeComponent();
            CConfig.LoadWindow(this);
        }

        #endregion

        #region --- FormClosing ---

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            CConfig.SaveWindow(this);
        }

        #endregion

        #region --- Load ---

        public override void LoadData()
        {
            cb_StartMinimized.Checked = CConfig.m_bStartMinimized;
            ipAddressCtrl.IPAddress = CConfig.m_pIpAdress;
            nud_Port.Value = CConfig.m_iPort;
            nud_WaitTime.Value = CConfig.m_iWaitTimeMs;
            foreach(CAidaIdData data in CConfig.m_lstAidaIdTo4DigitName)
                AddAidaItem(data);
        }

        #endregion

        #region --- Save ---

        public override bool SaveData()
        {
            CConfig.m_bStartMinimized = cb_StartMinimized.Checked;
            CConfig.m_pIpAdress = ipAddressCtrl.IPAddress;
            CConfig.m_iPort = Convert.ToInt32(nud_Port.Value);
            CConfig.m_iWaitTimeMs = Convert.ToInt32(nud_WaitTime.Value);
            CConfig.m_lstAidaIdTo4DigitName.Clear();
            foreach (UCAidaIdData ucData in flp_AidaItems.Controls)
                CConfig.m_lstAidaIdTo4DigitName.Add(ucData.AID);

            ResetModified();
            return true;
        }

        #endregion

        #region --- SetModified ---

        private void SetModifiedExt(object sender, EventArgs e)
        {
            SetModified(sender, e);
        }

        private void ipAddressCtrl_FieldChangedEvent(object sender, IPAddressControlLib.FieldChangedEventArgs e)
        {
            SetModifiedExt(sender, e);
        }

        #endregion

        #region --- Events ---

        private void btn_AddAidaItem_Click(object sender, EventArgs e)
        {
            AddAidaItem(new CAidaIdData("", "", Color.Gray));
        }

        private void UcData_DeletePressed(object sender, EventArgs e)
        {
            flp_AidaItems.Controls.Remove((UCAidaIdData)sender);
        }

        #endregion

        #region --- AddAidaItem ---

        private void AddAidaItem(CAidaIdData data_)
        {
            UCAidaIdData ucData = new UCAidaIdData(data_);
            ucData.DeletePressed += UcData_DeletePressed;
            flp_AidaItems.Controls.Add(ucData);
        }

        #endregion
    }
}
