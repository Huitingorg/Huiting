using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using BDSoft.Common;

namespace BDSoft.Components
{
    class PacketMousePanel  : ItemMousePanel
    {
        string descipution1 = "共有8个分组";

        public string Descipution1
        {
            get { return descipution1; }
            set
            {
                if (descipution1 == value)
                    return;
                descipution1 = value;
                init();
            }
        }

        string descipution2 = "共有20个单元";

        public string Descipution2
        {
            get { return descipution2; }
            set
            {
                if (descipution2 == value)
                    return;
                descipution2 = value;
                init();
            }
        }

        PointF ptDesc1;
        PointF ptDesc2;

        Color descColor = Color.DarkGray;

        public Color DescColor
        {
            get { return descColor; }
            set { descColor = value; }
        }

        Brush brushDesc;
        public PacketMousePanel()
        {
            this.AutoScroll = true;
            init();
        }

        protected override void init()
        {
            int titleBottom = base.GetTitleBottom();
            ptDesc1 = new PointF(base.fontLocation.X + 8, titleBottom + 8);
            ptDesc2 = new PointF(base.fontLocation.X + 8, titleBottom * 2 - 8);

            brushDesc = new SolidBrush(this.descColor);
            base.init();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.DrawString(descipution1, this.Font, brushDesc, ptDesc1);
            g.DrawString(descipution2, this.Font, brushDesc, ptDesc2);
        }
    }
}