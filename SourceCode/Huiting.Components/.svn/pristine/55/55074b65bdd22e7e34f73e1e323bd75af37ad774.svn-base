using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using BDSoft.Common;
using System.ComponentModel;

namespace BDSoft.Components
{
    public class ItemMousePanel : MousePanel, IFreeLayoutChildControl
    {
        protected int distance = 16;
        protected PointF fontLocation;
        Rectangle rectPic;
        string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        Bitmap itemImage;

        public Bitmap ItemImage
        {
            get { return itemImage; }
            set { itemImage = value; }
        }

        Brush brush;
        Brush brush2;

        public ItemMousePanel()
        {
            title = "全部单元";
            base.BorderColorWithMouseOut = Color.FromArgb(215, 228, 242);
            brush = new SolidBrush(this.ForeColor);
            brush2 = new SolidBrush(Color.Gray);
            this.Size = new Size(180, 100);
            this.fontLocation = new PointF(distance / 2, distance);

            itemImage = Properties.Resources.purple_64;
            this.rectPic = new Rectangle(100, distance, 64, 64);

            this.AutoScroll = true;

            base.SetColor(base.BorderColorWithMouseOut, base.FillColorWithMouseOut);
        }

        public override void Refresh()
        {
            base.SetColor(base.BorderColorWithMouseOut, base.FillColorWithMouseOut);
            base.Refresh();
        }

        protected virtual void init()
        {
            this.Invalidate();
        }

        protected int GetTitleBottom()
        {
            Size sz = PublicMethods.GetWordSize(this.Font, this.title);
            return sz.Height + this.distance;
        }




        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.init();
        }

        Font fontTitle = new Font("微软雅黑", 9);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            //g.DrawImage(itemImage, rectPic, rectPic2, GraphicsUnit.Pixel);
            if (itemImage == null)
                g.DrawImage(Properties.Resources.chart_72, rectPic);
            else
                g.DrawImage(itemImage, rectPic);

            if (this.Enabled == true)
                g.DrawString(title, fontTitle, brush, fontLocation);
            else
                g.DrawString(title, fontTitle, brush2, fontLocation);
        }





    }
}