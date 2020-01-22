using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Huiting.Common;

namespace ReserveAnalysis
{
    public class GroupTitlePanel : Panel
    {
        #region Properties
        
        string title = "分组";
        //分组标题
        public string Title
        {
            get { return title; }
            set {
                if (title == value)
                    return;
                title = value;
                Init();
            }
        }

        Color dividerColor = Color.LightGray;
        //分隔线颜色
        public Color DividerColor
        {
            get { return dividerColor; }
            set
            {
                if (dividerColor != value)
                    return;
                dividerColor = value;
                Init();
            }
        }

        Color titleColor = Color.FromArgb(31, 90, 197);
        //标题颜色
        public Color TitleColor
        {
            get { return titleColor; }
            set {
                if (titleColor == value)
                    return;
                titleColor = value;
                Init();
            }
        }

        Pen dividerPen;
        PointF titleLocation;
        PointF ptStart;
        PointF ptEnd;
        SolidBrush brush;

        #endregion

        public GroupTitlePanel()
        {
            Init();
        }
        public GroupTitlePanel(string title)
        {
            this.title = title;
            Init();
        }

        private void Init()
        {
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            Size size = PublicMethods.GetWordSize(this.Font, title);
            this.Height = this.Padding.Top + this.Padding.Bottom + size.Height;
            titleLocation = new PointF(Padding.Left, Padding.Top);
            ptStart = new PointF(Padding.Left + size.Width + 10, Padding.Top + (size.Height - 1) / 2);
            ptEnd = new PointF(this.Width, Padding.Top + (size.Height - 1) / 2);
            if (dividerPen == null)
                dividerPen = new Pen(dividerColor);
            else
                dividerPen.Color = dividerColor;
            brush = new SolidBrush(titleColor);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawString(title, this.Font, brush, titleLocation);
            e.Graphics.DrawLine(dividerPen, ptStart, ptEnd);
        }
    }

    //public enum GroupDividerType
    //{
    //    ToEnd,
    //}
}