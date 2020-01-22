using BDSoft.Common;
using BDSoft.Components;
using ReserveCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReserveAnalysis
{
    public class IconItemPanel2 : ItemMousePanel
    {
        #region 属性

        IconItemType type;

        public IconItemType Type
        {
            get { return type; }
            set { type = value; }
        }

        IconItemData data;

        public IconItemData Data
        {
            get { return data; }
        }

        PointF ptDesc;
        ToolTip toolTip;

        int titleBottom;

        #endregion

        public IconItemPanel2()
        {
            titleBottom = base.GetTitleBottom();
        }

        public void Init(ITreeNodeData TreeNodeData)
        {
            //this.data = TreeNodeData;
            //this.Title = this.data.NodeText;

            //UnitContentData ucd = this.data as UnitContentData;
            //if (ucd != null)
            //{
            //    base.ItemImage = ucd.Icon;
            //    descipution = ucd.SecondInfo;
            //    tip = ucd.Tip;

            //    ptDesc = new PointF(base.fontLocation.X, titleBottom + 8);

            //    if (string.IsNullOrEmpty(tip) == false)
            //    {
            //        this.toolTip = new ToolTip();
            //        toolTip.SetToolTip(this, tip);
            //    }

            //    this.Enabled = ucd.Enabled;
            //    return;
            //}

            //UnitNodeData und = this.data as UnitNodeData;
            //if (und != null)
            //{
                //switch (und.NodeType)
                //{
                //    case EnumNodeType.CYC:
                //    case EnumNodeType.YT:
                //    case EnumNodeType.Other:
                //        descipution1 = "共有" + und.ChildPacketCount + "个分组";
                //        descipution2 = "共有" + und.ChildUnitCount + "个单元";
                //        ptDesc1 = new PointF(base.fontLocation.X + 8, titleBottom + 8);
                //        ptDesc2 = new PointF(base.fontLocation.X + 8, titleBottom * 2 - 8);
                //        break;
                //    case EnumNodeType.DY:
                //        this.descipution1 = "";
                //        this.descipution2 = "";
                //        this.ItemImage = Properties.Resources.map2_72;

                //        int leftIndex = this.Title.IndexOf("（", 0);
                //        if (leftIndex > 0)
                //        {
                //            this.descipution1 = this.Title.Substring(leftIndex + 1, this.Title.Length - leftIndex - 1);
                //            if (this.descipution1.EndsWith("）"))
                //                this.descipution1 = this.descipution1.Substring(0, this.descipution1.Length - 1);
                //            ptDesc1 = new PointF(base.fontLocation.X, titleBottom + 8);
                //            this.Title = this.Title.Substring(0, leftIndex);
                //        }
                //        break;
                //    default:
                //        break;
                //}
            //}

        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            //g.DrawString(descipution, this.Font, brushDesc, ptDesc);
        }



        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            //brushDesc.Dispose();
            this.data.Dispose();
        }
    }


}
