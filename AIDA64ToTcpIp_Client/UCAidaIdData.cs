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

namespace AIDA64ToTcpIp_Client
{
    public partial class UCAidaIdData : UserControl
    {
        #region --- Variablen ---

        public CAidaIdData AID;
        public event EventHandler DeletePressed;

        #endregion

        #region --- Konstruktor ---

        public UCAidaIdData(CAidaIdData aid_)
        {
            InitializeComponent();
            AID = aid_;
            tb_Id.Text = AID.ID;
            tb_label.Text = AID.Label4Digit;
            panel_Color.BackColor = AID.Color;
        }

        #endregion

        #region --- Buttons ---

        private void btn_ChangeColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = AID.Color;
            dlg.AnyColor = true;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                AID.Color = dlg.Color;
                panel_Color.BackColor = AID.Color;
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DeletePressed?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region --- Events ---

        private void tb_label_TextChanged(object sender, EventArgs e)
        {
            AID.Label4Digit = tb_label.Text.PadLeft(4, ' ');
        }

        private void tb_Id_TextChanged(object sender, EventArgs e)
        {
            AID.ID = tb_Id.Text;
        }

        #endregion
    }
}
