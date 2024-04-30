#region Using...

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace AIDA64ToTcpIp_Client
{
    public class CAidaIdData
    {
        #region --- Variablen ---

        public string ID { get; set; }
        public string Label4Digit { get; set; }
        public Color Color { get; set; }

        #endregion

        #region --- Konstruktor ---

        public CAidaIdData(string id_, string label4digit_, Color color_)
        {
            ID = id_;
            Label4Digit = label4digit_;
            Color = color_;
        }

        #endregion
    }
}
