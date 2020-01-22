using BDSoft.Common;
using BDSoft.Components;
using ReserveCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveAnalysis
{
    public class IconItemPanel : ItemMousePanel
    {
        #region 属性

        string descipution1 = "共有8个分组";
        string descipution2 = "共有20个单元";

        string tip ;

        public string Tip
        {
            get { return tip; }
            set { tip = value; }
        }

        ITreeNodeData data;

        public ITreeNodeData Data
        {
            get { return data; }
        }

        PointF ptDesc1;
        PointF ptDesc2;

        Color clrDesc1 = Color.DarkGray;
        Color clrDesc2 = Color.DarkGray;

        Brush brushDesc1;
        Brush brushDesc2;
        ToolTip toolTip1;

        int titleBottom;

        #endregion

        public IconItemPanel()
        {
            titleBottom = base.GetTitleBottom();
            this.brushDesc1 = new SolidBrush(clrDesc1);
            this.brushDesc2 = new SolidBrush(clrDesc2);
        }

        public void Init(ITreeNodeData TreeNodeData)
        {
            //this.data = TreeNodeData;
            //this.Title = this.data.NodeText;

            //UnitContentData ucd = this.data as UnitContentData;
            //if (ucd != null)
            //{
            //    base.ItemImage = ucd.Icon;
            //    descipution1 = ucd.SecondInfo;
            //    descipution2 = "修改于" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            //    descipution2 = "";
            //    tip = ucd.Tip;

            //    ptDesc1 = new PointF(base.fontLocation.X, titleBottom + 8);
            //    SizeF sz = PublicMethods.GetWordSizeF(this.Font, descipution2);
            //    ptDesc2 = new PointF(this.Width - base.distance - sz.Width + 8, 80 + (20 - sz.Height) / 2);

            //    if (string.IsNullOrEmpty(tip) == false)
            //    {
            //        this.toolTip1 = new ToolTip();
            //        toolTip1.SetToolTip(this, tip);
            //    }

            //    this.Enabled = ucd.Enabled;
            //    return;
            //}

            //UnitNodeData und = this.data as UnitNodeData;
            //if (und != null)
            //{
            //    switch (und.NodeType)
            //    {
            //        case EnumNodeType.CYC:
            //        case EnumNodeType.YT:
            //        case EnumNodeType.Other:
            //            descipution1 = "共有" + und.ChildPacketCount + "个分组";
            //            descipution2 = "共有" + und.ChildUnitCount + "个单元";
            //            ptDesc1 = new PointF(base.fontLocation.X + 8, titleBottom + 8);
            //            ptDesc2 = new PointF(base.fontLocation.X + 8, titleBottom * 2 - 8);
            //            break;
            //        case EnumNodeType.DY:
            //            this.descipution1 = "";
            //            this.descipution2 = "";
            //            this.ItemImage = Properties.Resources.map2_72;

            //            int leftIndex = this.Title.IndexOf("（", 0);
            //            if (leftIndex > 0)
            //            {
            //                this.descipution1 = this.Title.Substring(leftIndex + 1, this.Title.Length - leftIndex - 1);
            //                if (this.descipution1.EndsWith("）"))
            //                    this.descipution1 = this.descipution1.Substring(0, this.descipution1.Length - 1);
            //                ptDesc1 = new PointF(base.fontLocation.X, titleBottom + 8);
            //                this.Title = this.Title.Substring(0, leftIndex);
            //            }
            //            break;
            //        default:
            //            break;
            //    }
            //}

        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            //PublicMethods.GetLstString(this.Font,)
            g.DrawString(descipution1, this.Font, brushDesc1, ptDesc1);
            g.DrawString(descipution2, this.Font, brushDesc2, ptDesc2);
            //new Font("微软雅黑",9)
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            brushDesc1.Dispose();
            brushDesc2.Dispose();
            this.data.Dispose();
        }
    }
}