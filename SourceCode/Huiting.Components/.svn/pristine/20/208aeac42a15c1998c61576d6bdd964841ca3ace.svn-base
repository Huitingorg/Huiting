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
    class UnitMousePanel : ItemMousePanel
    {
        #region 属性
        
        string descipution1 = "水驱特征曲线";

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

        //string descipution2 = "已于 2014-12-01 9:05:01 修改";
        string descipution2 = "改于14-12-01 9:05:01";

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
        Brush brushDefault;

        #endregion


        public UnitMousePanel()
        {
            this.AutoScroll = true;
            this.Title = "营8浅";
            int titleBottom = base.GetTitleBottom();
            ptDesc1 = new PointF(base.fontLocation.X, titleBottom + 8);

            init();
        }

        protected override void init()
        {
            SizeF sz = PublicMethods.GetWordSizeF(this.Font, descipution2);
            ptDesc2 = new PointF(this.Width - base.distance - sz.Width + 8, 80 + (20 - sz.Height) / 2);
            brushDesc = new SolidBrush(this.descColor);
            brushDefault = new SolidBrush(this.ForeColor);
            base.init();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.DrawString(descipution1, this.Font, brushDefault, ptDesc1);
            g.DrawString(descipution2, this.Font, brushDesc, ptDesc2);
        }
    }
}
