using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Huiting.Common;

namespace Huiting.Components.DrawPanel
{
    public class FontMousePanel : MousePanel
    {
        PointF fontLocation;
        Brush fontBrush;
        FontMouseWidthType fontMouseWidthType = FontMouseWidthType.AutoWidth;
        internal FontMouseWidthType FontMouseWidthType
        {
            get { return fontMouseWidthType; }
            set { fontMouseWidthType = value; }
        }

        string keyWorld = "文件路径";

        public string KeyWorld
        {
            get { return keyWorld; }
            set
            {
                if (keyWorld == value)
                    return;
                keyWorld = value;
                RefreshControl();
            }
        }

        public FontMousePanel()
        {
            
            this.Font = System.Drawing.SystemFonts.DefaultFont;
            this.ForeColor = Color.Black;
            RefreshControl();
        }

        #region Methods
        
        private void RefreshControl()
        {
            fontBrush = new SolidBrush(this.ForeColor);
            SizeF minSF = PublicMethods.GetWordSizeF(this.Font, keyWorld);
            SetPanelWidth(minSF);
            fontLocation = GetFontLocation(minSF);
            this.Invalidate();
        }

        private void SetPanelWidth(SizeF sf)
        {
            if (FontMouseWidthType == FontMouseWidthType.AutoWidth)
                this.Width = (int)sf.Width + 5;
        }

        private PointF GetFontLocation(SizeF sf)
        {
            PointF pf = new PointF();
            pf.X = (this.Width - sf.Width) / 2;
            pf.Y = (this.Height - sf.Height) / 2;
            return pf;
        }

        #endregion


        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            RefreshControl();
        }
        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            RefreshControl();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            RefreshControl();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.DrawString(keyWorld, this.Font, fontBrush, fontLocation);
        }

    }


    enum FontMouseWidthType
    {
        AutoWidth,
        FixWidth
    }

}
