using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Huiting.Common;

namespace BDSoft.Components
{
    [Serializable]
    public class FreeLayoutPanel<T> : Panel where T : IFreeLayoutChildControl
    {
        #region 属性

        Size minChildControlSize;

        public Size MinChildControlSize
        {
            get { return minChildControlSize; }
            set { minChildControlSize = value; }
        }

        List<T> childContrls;
        /// <summary>
        /// 数据
        /// </summary>
        public List<T> ChildContrls
        {
            get { return childContrls; }
            set { childContrls = value; }
        }

        int minHorizontalDistance = 10;
        /// <summary>
        /// 最小的水平间隔
        /// </summary>
        public int MinHorizontalDistance
        {
            get { return minHorizontalDistance; }
            set { minHorizontalDistance = value; }
        }

        int realHorizontalDistance = 10;
        /// <summary>
        /// 实际水平间距
        /// </summary>
        public int RealHorizontalDistance
        {
            get { return realHorizontalDistance; }
            set
            {
                if (realHorizontalDistance == value)
                    return;
                if (realHorizontalDistance < minHorizontalDistance)
                    realHorizontalDistance = minHorizontalDistance;
                else
                    realHorizontalDistance = value;
            }
        }

        int realVerticalDistance = 10;
        /// <summary>
        /// 实际垂直间距
        /// </summary>
        public int RealVerticalDistance
        {
            get { return realVerticalDistance; }
            set { realVerticalDistance = value; }
        }

        FreeLayoutType freeLayoutType = FreeLayoutType.AutoCalcMaxColumnsCount;

        public FreeLayoutType FreeLayoutType
        {
            get { return freeLayoutType; }
            set { freeLayoutType = value; }
        }

        int fixedColumnsCount;

        public int FixedColumnsCount
        {
            get { return fixedColumnsCount; }
            set { fixedColumnsCount = value; }
        }

        int realColumnsCount;

        public int RealColumnsCount
        {
            get { return realColumnsCount; }
        }

        int realRowsCount;

        public int RealRowsCount
        {
            get { return realRowsCount; }
            set { realRowsCount = value; }
        }

        //是否带一行中最后一个水平间距
        bool withLastHoriDistance;
        //是否显示垂直滚动条
        bool vertScrollVisble;

        protected int maxWidth
        {
            get
            {
                return this.Width - Padding.Left - Padding.Right;
            }
        }

        protected int maxHeight
        {
            get
            {
                return this.Height - Padding.Top - Padding.Bottom;
            }
        }


        #endregion

        #region 构造方法

        /// <summary>
        /// 构造方法
        /// </summary>
        public FreeLayoutPanel()
        {
            minChildControlSize = new Size(180, 100);
            //this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            this.Padding = new Padding(10);
            this.AutoScroll = true;
            this.DoubleBuffered = true;
        }

        #endregion

        #region 事件

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            RefreshContols();
        }

        #endregion

        #region 方法

        public void Init(List<T> lstControls)
        {
            if (lstControls == null)
                return;
            this.childContrls = lstControls;
            Init();
        }

        private void Init()
        {
            if (childContrls == null)
                return;

            //刷新组件位置
            RefreshContols();
            //添加组件
            AddChildCotnrols(childContrls);
        }

        //刷新组件位置
        public void RefreshContols()
        {
            if (childContrls == null)
                return;

            //先设置不显示垂直滚动条
            vertScrollVisble = false;
            //计算的行列数
            CalcRealColumnsAndRowsCount(childContrls.Count, vertScrollVisble);
            //设置组件的Location
            SetControlsLocation(childContrls, realRowsCount, realColumnsCount, withLastHoriDistance);
        }

        private void CalcRealColumnsAndRowsCount(int childCount, bool vertScrollVisble)
        {
            //可用宽度
            int usedWidth;
            //如果有垂直滚动条，则要去除滚动条宽度
            if (vertScrollVisble == true)
                usedWidth = this.maxWidth - SystemInformation.VerticalScrollBarWidth;
            else
                usedWidth = this.maxWidth;

            CalcRealColumnsAndRowsCount(usedWidth, childCount, vertScrollVisble);
        }

        public int GetCompactHeight()
        {
            return this.realRowsCount * (minChildControlSize.Height + realVerticalDistance) + Padding.Top + Padding.Bottom;
        }

        //计算出真实的行列总数
        private void CalcRealColumnsAndRowsCount(int usedWidth, int childCount, bool vertScrollVisble)
        {
            //自动计算最大列宽
            int maxColumnsCount = CalcMaxColumnsCount(usedWidth, vertScrollVisble);
            switch (freeLayoutType)
            {
                case FreeLayoutType.AutoCalcMaxColumnsCount:
                    realColumnsCount = maxColumnsCount;
                    break;
                case FreeLayoutType.FixedColumnsCount:
                    //如果用户指定列宽大于计算列宽
                    if (fixedColumnsCount > maxColumnsCount)
                    {
                        realColumnsCount = maxColumnsCount;
                        //修改用户指定列宽
                        fixedColumnsCount = maxColumnsCount;
                    }
                    //如果用户指定列宽小于计算列宽
                    else
                        //修改计算列宽,为用户指定列宽
                        realColumnsCount = fixedColumnsCount;
                    break;
                default:
                    break;
            }
            //最大行高
            int maxRowsCount = childCount % realColumnsCount == 0 ? childCount / realColumnsCount : childCount / realColumnsCount + 1;
            //如果有垂直滚动条
            if (vertScrollVisble == false && AutoScroll == true)
            {
                //获取虚拟高度
                int virtualHeight = maxRowsCount * (minChildControlSize.Height + realVerticalDistance);
                //需要添加垂直滚动条，再计算一遍
                if (virtualHeight > maxHeight)
                {
                    //再设置显示垂直滚动条
                    vertScrollVisble = true;
                    CalcRealColumnsAndRowsCount(childCount, vertScrollVisble);
                    return;
                }
            }

            realRowsCount = maxRowsCount;
        }

        //计算最大列数，并判断出是否添加最后一个水平滚动条
        private int CalcMaxColumnsCount(int givenWidth, bool vertScrollVisble)
        {
            //一个循环单位 
            int cellWidth = (minChildControlSize.Width + realHorizontalDistance);
            //最大列数 = （最大可用宽度+真实水平间距）/循环单位宽度
            int maxColumnsCount = (givenWidth + realHorizontalDistance) / cellWidth;
            if (maxColumnsCount <= 0)
            {
                maxColumnsCount = 1;
                withLastHoriDistance = false;
            }

            //如何剩下的空间还能放开模块，但放不开 模块+间隔了，就置最后一个间隔为false 
            if (maxColumnsCount * cellWidth + minChildControlSize.Width < givenWidth)
            {
                maxColumnsCount += 1;
                withLastHoriDistance = false;
            }
            else
                withLastHoriDistance = true;
            return maxColumnsCount;
        }

        private void SetControlsLocation(List<T> lstControls, int rowsCount, int columnsCount, bool withLastHoriDistance)
        {
            switch (freeLayoutType)
            {
                case FreeLayoutType.AutoCalcMaxColumnsCount:
                    UpdateControlsByAutoCalc(lstControls, rowsCount, columnsCount);
                    break;
                //固定列需要居中显示，要考虑是缩放 组件宽度还是缩放间隔宽度，现在用不到，暂时先不实现
                case FreeLayoutType.FixedColumnsCount:
                    break;
                default:
                    break;
            }
        }

        private void UpdateControlsByAutoCalc(List<T> lstControls, int rowsCount, int columnsCount)
        {
            int itemWidth = (minChildControlSize.Width + realHorizontalDistance);
            int rowHeight = (minChildControlSize.Height + realVerticalDistance);
            Point ptS = new Point(Padding.Left, Padding.Top);

            bool flag = false;
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    IFreeLayoutChildControl ctrl = lstControls[i * columnsCount + j];
                    ctrl.Location = new Point(ptS.X + itemWidth * j, ptS.Y + rowHeight * i);

                    if (i * columnsCount + j == lstControls.Count - 1)
                    {
                        flag = true;
                        break;
                    }

                }

                if (flag == true)
                    break;
            }
        }

        private void AddChildCotnrols(List<T> lstControls)
        {
            foreach (T item in lstControls)
            {
                this.Controls.Add(item as Control);
            }
        }
        #endregion
    }

    [Serializable]
    public enum FreeLayoutType
    {
        /// <summary>
        /// 自动计算最大列数，即能放开几列，放几列
        /// </summary>
        AutoCalcMaxColumnsCount,
        /// <summary>
        /// 固定总列数（但若是 固定总列数 大于 自动计算最大列数，则修改前进的值为后者）
        /// </summary>
        FixedColumnsCount,
    }

    ////如果FreeLayoutType类型为FixedColumnsCount时，此类型才有效
    //public enum FreeLayoutZoomType
    //{
    //    //缩放水平间隔
    //    ZoomHorizontalDistance,
    //    //缩放组件宽度
    //    ZoomChildControlWidth
    //}

    public interface IFreeLayoutChildControl
    {
        Point Location { get; set; }
        Size Size { get; set; }
    }

}