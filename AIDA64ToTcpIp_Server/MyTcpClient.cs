#region Using...

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace AIDA64ToTcpIp_Server
{
    public class MyTcpClient
    {
        #region --- Variablen ---

        [DisplayName("Status")]
        public Bitmap State { get { return GetState(); } }

        [DisplayName("IP-Adresse")]
        public string IP_Adress { get { return GetIP(); } }

        [DisplayName("Port")]
        public string Port { get { return GetPort(); } }

        [Browsable(false)]
        public TcpClient Client;

        #endregion

        #region --- Konstruktor ---

        public MyTcpClient(TcpClient c_)
        {
            Client = c_;
            GetState();
            GetIP();
            GetPort();
        }

        #endregion

        #region --- Interne Get-Funktionen ---

        #region -- GetState --

        private Bitmap GetState()
        {
            Bitmap bmp = new Bitmap(16, 16);
            FillBmp(ref bmp, Color.Red);
            try
            {
                if (Client.Client.Connected)
                    FillBmp(ref bmp, Color.Lime);
            }
            catch { }
            return bmp;
        }

        private void FillBmp(ref Bitmap bmp_, Color clr_)
        {
            for(int x = 0; x < bmp_.Width; x++)
                for(int y = 0; y < bmp_.Height; y++)
                    bmp_.SetPixel(x, y, clr_);
        }

        #endregion

        private string GetIP()
        {
            if(Client == null || !Client.Connected)
                return "Unbekannt";

            try
            {
                return Client.Client.RemoteEndPoint.ToString().Split(':')[0];
            }
            catch
            {
                return "Fehler";
            }
        }

        private string GetPort()
        {
            if (Client == null || !Client.Connected)
                return "Unbekannt";

            try
            {
                return Client.Client.RemoteEndPoint.ToString().Split(':')[1];
            }
            catch
            {
                return "Fehler";
            }
        }

        #endregion
    }
}
