#region Using...

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace AIDA64ToTcpIp_Client
{
    public class CAIDAItem
    {
        #region --- Variablen ---

        private bool m_bActive;
        public bool Active 
        {
            get { return m_bActive; }
            set 
            { 
                m_bActive = value;
                if (m_bActive && !CConfig.m_lstActiveAidaItemIds.Contains(Id))
                    CConfig.m_lstActiveAidaItemIds.Add(Id);
                else if(!m_bActive && CConfig.m_lstActiveAidaItemIds.Contains(Id))
                    CConfig.m_lstActiveAidaItemIds.Remove(Id);
            }
        }
        public string Id { get; private set; }
        public string Label { get; private set; }
        public string Value { get; private set; }
        public string NotifyLabel { get; private set; }
        [Browsable(false)]
        public Color NotifyColor{ get; private set; }
        public Bitmap Icon { get; private set; }

        #endregion

        #region --- Konstruktor ---

        public CAIDAItem(string id, string label, string value)
        {
            if(CConfig.m_lstActiveAidaItemIds.Contains(id))
                m_bActive = true;
            else
                m_bActive = false;
            Id = id;
            Label = label;
            Value = value;
            Icon = null;
            UpdateNotifyData();
        }

        #endregion

        #region --- UpdateData ---

        public void UpdateData(string label_, string value_)
        {
            if(Label != label_)
                Label = label_;
            if (Value != value_)
                Value = value_;
            UpdateNotifiyIcon();
        }

        public void UpdateNotifyData()
        {
            foreach (var item in CConfig.m_lstAidaIdTo4DigitName)
            {
                if (item.ID.ToUpper() == Id.ToUpper())
                {
                    NotifyLabel = item.Label4Digit;
                    NotifyColor = item.Color;
                    return;
                }
            }
            NotifyLabel = "UNKN";
            NotifyColor = Color.DarkGray;
        }

        #endregion

        #region --- Update Icon ---

        private void UpdateNotifiyIcon()
        {
            switch (Id)
            {
                case "SCPUCLK": //CPU Clock
                    Icon = CreateBitmap(NotifyLabel, 
                        (Convert.ToInt32(Value) / 1000.0).ToString("0.0", CultureInfo.InvariantCulture).Replace(".", ""),
                        NotifyColor,
                        true); 
                    break;
                case "PCPUPKG": //CPU Power
                    Icon = CreateBitmap(NotifyLabel,
                       Convert.ToDouble(Value, CultureInfo.InvariantCulture).ToString("0"),
                       NotifyColor);
                    break;
                case "TCPU": //CPU Temperature
                case "SCPUUTI": //CPU Load
                default:
                    Icon = CreateBitmap(NotifyLabel, 
                        Value,
                        NotifyColor);
                    break;
            }
        }

        #endregion

        #region --- GetFormattedValue ---

        public string GetFormattedValue()
        {
            switch (Id)
            {
                case "TCPU": //CPU Temperature
                    return Value + " °C";
                case "SCPUUTI": //CPU Load
                    return Value + " %";
                case "SCPUCLK": //CPU Clock
                    return (Convert.ToInt32(Value) / 1000.0).ToString("0.0", CultureInfo.InvariantCulture) + " Ghz";
                case "PCPUPKG": //CPU Power
                    return Value + " W";
                default:
                    return Value;
            }
        }

        #endregion

        #region --- CreateBitmap ---

        public Bitmap CreateBitmap(string name_, string text_, Color col_, bool bAddPoint_ = false)
        {
            try
            {
                int iTextSize = 9;
                int iTextPos = 5;
                if (text_.Length > 2 && !bAddPoint_)
                {
                    iTextSize = 6;
                    iTextPos = 8;
                }

                Bitmap bmp = new Bitmap(16, 16);
                Font f1 = new Font("Consolas", 5);
                Font f2 = new Font("Consolas", iTextSize);
                SolidBrush b = new SolidBrush(col_);
                Graphics g = Graphics.FromImage(bmp);

                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.None;
                g.Clear(Color.Black);
                g.DrawString(name_, f1, b, -1, -1);
                g.DrawString(text_, f2, b, -1, iTextPos-1);
                if (bAddPoint_)
                    g.DrawLine(new Pen(col_, 1), 7, 14, 7, 16);

                f1.Dispose();
                f2.Dispose();
                b.Dispose();
                g.Dispose();
                return bmp;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion
    }
}
