using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BDSoft.Components
{
    public class CollapsibleSplitter : Splitter
    {
        const double pi = 3.14;
        int angle = 60;
        int longer = 150;
        int shorter = 50;
        Point[] ptAry = new Point[4];
        Color clr1 = Color.FromArgb(150, 81, 160, 255);


        public event EventHandler CollapseEvent;

        public new DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                base.Dock = value;
                longer = GetLonger();
                ptAry = GetPointAry(collapseState);
                this.Invalidate();
            }
        }

        #region Properties

        /// <summary>
        /// 直角边
        /// </summary>
        int SideLength
        {
            get
            {
                if (base.Dock == DockStyle.Left || base.Dock == DockStyle.Right)
                    return base.Width;
                else
                    return base.Height;
            }
        }

        /// <summary>
        /// 是否折叠,为真表示可以折叠，反之，不可以折叠
        /// </summary>
        bool isCollapse = false;

        /// <summary>
        /// 是否折叠,为真表示可以折叠，反之，不可以折叠
        /// </summary>
        [DefaultValueAttribute(false)]
        public bool IsCollapse
        {
            get
            {
                return isCollapse;
            }
            set
            {
                if (isCollapse == value)
                    return;
                isCollapse = value;
                Invalidate();
                //是否立刻起作用
                if (isCollapse == false)
                    return;

                CollapseControls(collapseState);
                ptAry = GetPointAry(collapseState);
                Invalidate();
            }
        }

        /// <summary>
        /// 折叠状态，为真表示，正处于折叠状态
        /// 如果isCollapse为真，此属性才有意义
        /// </summary>
        bool collapseState = false;

        [DefaultValueAttribute(false)]
        public bool CollapseState
        {
            get { return collapseState; }
            set
            {
                if (collapseState == value)
                    return;
                collapseState = value;
                if (CtrlCollapsed != null)
                    CtrlCollapsed(collapseState, null);
                //是否立刻起作用
                if (isCollapse == false)
                    return;
                CollapseControls(collapseState);
                ptAry = GetPointAry(collapseState);
                this.Invalidate();
            }
        }

        public event EventHandler CtrlCollapsed;

        #endregion

        #region Constructor

        public CollapsibleSplitter()
            : base()
        {
            this.DoubleBuffered = true;
            CollapseState = false;
        }

        #endregion

        #region Methods

        private int GetLonger()
        {
            //换算成弧度
            double radian = angle * pi / 180;
            //计算出longer比shorter多出的一半
            double extraHalf = SideLength * Math.Tan(radian);
            return (int)extraHalf * 2 + shorter;
        }

        public void InitCtrl()
        {
            CollapseControls(collapseState);
            ptAry = GetPointAry(collapseState);
            this.Invalidate();
        }

        /// <summary>
        /// 收缩组件
        /// </summary>
        /// <param name="collapseState"></param>
        private void CollapseControls(bool collapseState)
        {
            bool expandState = !collapseState;
            if (base.Parent == null)
                return;
            //int intCount = base.Parent.Controls.Count;
            for (int i = base.Parent.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = base.Parent.Controls[i];
                string name = ctrl.Name;
                if (ctrl == this)
                    break;

                //窗体未显示前，Visible为false,但真实为true,为了防止这种情况，必须先设置为false
                //if (ctrl.Visible != expandState)
                    ctrl.Visible = expandState;
            }

            base.Parent.Invalidate(true);
        }

        #region 获取绘制的区域的点

        private Point[] GetPointAry(bool collapseState)
        {
            Point[] ptAry = new Point[4];
            //折叠状态
            if (collapseState)
            {
                switch (base.Dock)
                {
                    case DockStyle.Bottom:
                        ptAry = GetPointAryToTop();
                        break;
                    case DockStyle.Left:
                        ptAry = GetPointAryToRight();
                        break;
                    case DockStyle.Right:
                        ptAry = GetPointAryToLeft();
                        break;
                    case DockStyle.Top:
                        ptAry = GetPointAryToDown();
                        break;
                    case DockStyle.Fill:
                    case DockStyle.None:
                    default:
                        break;
                }
            }
            else
            {
                switch (base.Dock)
                {
                    case DockStyle.Bottom:
                        ptAry = GetPointAryToDown();
                        break;
                    case DockStyle.Left:
                        ptAry = GetPointAryToLeft();
                        break;
                    case DockStyle.Right:
                        ptAry = GetPointAryToRight();
                        break;
                    case DockStyle.Top:
                        ptAry = GetPointAryToTop();
                        break;
                    case DockStyle.Fill:
                    case DockStyle.None:
                    default:
                        break;
                }
            }

            return ptAry;
        }

        private Rectangle GetRectangle()
        {
            Rectangle rect = new Rectangle();
            switch (base.Dock)
            {
                case DockStyle.Top:
                case DockStyle.Bottom:
                    Point[] ptAryDown = GetPointAryToDown();
                    rect = new Rectangle(ptAryDown[0], new Size(longer, base.Height));
                    break;
                case DockStyle.Left:
                case DockStyle.Right:
                    Point[] ptAryRight = GetPointAryToRight();
                    rect = new Rectangle(ptAryRight[0], new Size(base.Width, longer));
                    break;
                case DockStyle.Fill:
                case DockStyle.None:
                default:
                    break;
            }

            return rect;
        }

        private Point[] GetPointAryToLeft()
        {
            Point[] ptAry = new Point[4];
            ptAry[0] = new Point(0, (longer - shorter) / 2);
            ptAry[1] = new Point(0, longer - (longer - shorter) / 2);
            ptAry[2] = new Point(base.Width, longer);
            ptAry[3] = new Point(base.Width, 0);

            if (base.Height > longer)
            {
                int diffY = (base.Height - longer) / 2;
                int diffX = 0;

                for (int i = 0; i < ptAry.Length; i++)
                {
                    Point item = ptAry[i];
                    item.Offset(diffX, diffY);
                    ptAry[i] = item;
                }
            }

            return ptAry;
        }

        private Point[] GetPointAryToRight()
        {
            Point[] ptAry = new Point[4];
            ptAry[0] = new Point(0, 0);
            ptAry[1] = new Point(0, longer);
            ptAry[2] = new Point(base.Width, longer - (longer - shorter) / 2);
            ptAry[3] = new Point(base.Width, (longer - shorter) / 2);

            if (base.Height > longer)
            {
                int diffY = (base.Height - longer) / 2;
                int diffX = 0;

                for (int i = 0; i < ptAry.Length; i++)
                {
                    Point item = ptAry[i];
                    item.Offset(diffX, diffY);
                    ptAry[i] = item;
                }
            }

            return ptAry;
        }

        private Point[] GetPointAryToTop()
        {
            Point[] ptAry = new Point[4];
            ptAry[0] = new Point((longer - shorter) / 2, 0);
            ptAry[1] = new Point(0, base.Height);
            ptAry[2] = new Point(longer, base.Height);
            ptAry[3] = new Point(longer - (longer - shorter) / 2, 0);

            if (base.Width > longer)
            {
                int diffX = (base.Width - longer) / 2;
                int diffY = 0;

                for (int i = 0; i < ptAry.Length; i++)
                {
                    Point item = ptAry[i];
                    item.Offset(diffX, diffY);
                    ptAry[i] = item;
                }
            }

            return ptAry;
        }

        private Point[] GetPointAryToDown()
        {
            Point[] ptAry = new Point[4];
            ptAry[0] = new Point(0, 0);
            ptAry[1] = new Point((longer - shorter) / 2, base.Height);
            ptAry[2] = new Point(longer - (longer - shorter) / 2, base.Height);
            ptAry[3] = new Point(longer, 0);

            if (base.Width > longer)
            {
                int diffX = (base.Width - longer) / 2;
                int diffY = 0;

                for (int i = 0; i < ptAry.Length; i++)
                {
                    Point item = ptAry[i];
                    item.Offset(diffX, diffY);
                    ptAry[i] = item;
                }
            }

            return ptAry;
        }

        #endregion

        #endregion

        #region Events

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            GraphicsPath gp = new GraphicsPath();
            gp.StartFigure();
            gp.AddPolygon(ptAry);
            gp.CloseFigure();

            if (gp.IsVisible(e.X, e.Y))
            {
                CollapseState = !collapseState;
                if (CollapseEvent != null)
                    CollapseEvent(this, null);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            longer = GetLonger();
            ptAry = GetPointAry(collapseState);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (isCollapse)
            {
                if (ptAry.Length <= 0)
                    return;

                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.HighQuality;

                GraphicsPath myPath = new GraphicsPath();
                myPath.StartFigure();
                myPath.AddPolygon(ptAry);
                myPath.CloseFigure();

                g.FillPath(new SolidBrush(clr1), myPath);
            }

        }

        #endregion
    }
}