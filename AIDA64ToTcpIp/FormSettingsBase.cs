#region Using...

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

namespace AIDA64ToTcpIp
{
    public partial class FormSettingsBase : Form
    {
        #region --- Variablen ---

        bool m_bModified;

        #endregion

        #region --- Konstruktor ---

        public FormSettingsBase()
        {
            InitializeComponent();
            DialogResult = DialogResult.Abort;
        }

        private void FormSettingsBase_Load(object sender, EventArgs e)
        {
            LoadData();
            m_bModified = false;
        }

        #endregion

        #region --- "Destruktor" ---

        private void FormSettingsBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bModified)
            {
                if (MessageBox.Show("Möchten Sie den Dialog wirklich ohne zu speichern schließen?" +
                    "\r\nNicht gespeicherte Änderungen gehen verloren!", "Sicher?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        #endregion

        #region --- Buttons Ok/Abort ---

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btn_Abort_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region --- Modified Events ---

        public void SetModified(object sender = null, EventArgs e = null)
        {
            m_bModified = true;
        }

        public void ResetModified()
        {
            m_bModified = false;
        }

        #endregion

        #region --- Save/Load Data Vorlagen ---

        public virtual bool SaveData()
        {
            return false;
        }
        public virtual void LoadData()
        {

        }

        #endregion
    }
}
