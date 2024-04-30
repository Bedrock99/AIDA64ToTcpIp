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
    public partial class FormInfoBox : Form
    {
        #region --- Konstruktor ---

        public FormInfoBox(string strTitle_, string strContent_)
        {
            InitializeComponent();
            Text = strTitle_;
            textBox1.Text = strContent_;
        }

        #endregion

        #region --- Button Ok Click ---

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
