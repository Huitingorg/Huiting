using Huiting.Common;
using Huiting.Components;
using ReserveCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Huiting.Components.DrawPanel;
using Huiting.Components;

namespace ReserveAnalysis
{
    public class IconItemPanel : MousePanel, IFreeLayoutChildControl
    {
        #region 属性

        IconLayoutType iconLayoutType = IconLayoutType.LeftWordRightImage;

        public IconLayoutType IconLayoutType
        {
            get { return iconLayoutType; }
            set { iconLayoutType = value; }
        }

        IEntityData dataConverter;

        public IEntityData DataConverter
        {
            get { return dataConverter; }
            set { dataConverter = value; }
        }

        IconItemData data;
        ToolTip toolTip1;

        #endregion

        public IconItemPanel()
        {
            this.BackColor = Color.Transparent;
        }

        public void Init(IEntityData dataConverter, IconLayoutType IconLayoutType, Size Size)
        {
            this.Size = Size;
            this.iconLayoutType = IconLayoutType;
            this.dataConverter = dataConverter;
            data = dataConverter.Convert();
            if (!string.IsNullOrEmpty(this.data.Tip))
            {
                this.toolTip1 = new ToolTip();
                toolTip1.SetToolTip(this, this.data.Tip);
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            switch (iconLayoutType)
            {
                case IconLayoutType.LeftWordRightImage:
                    DrawLeftWordRightImage(e.Graphics);
                    break;
                case IconLayoutType.TopImageBottomWord:
                    DrawTopImageBottomWord(e.Graphics);
                    break;
                default:
                    break;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.data.Dispose();
        }

        protected int distance = 16;
        protected int imageWidth = 64;

        private void DrawLeftWordRightImage(Graphics g)
        {
            Brush brush;
            Bitmap bitmap;

            if (this.Enabled == true)
            {
                brush = Brushes.Black;
                bitmap = data.Image;
            }
            else
            {
                brush = Brushes.Gray;
                bitmap = PublicMethods.SetGray(data.Image);
            }

            PointF pfText = new PointF(distance / 2, distance);
            SizeF sfText = PublicMethods.GetWordSizeF(g, this.Font, "测");
            //绘制左边文字
            g.DrawString(data.Text, this.Font, brush, pfText);

            #region 绘制注释信息

            if (!string.IsNullOrEmpty(data.Desc1) || !string.IsNullOrEmpty(data.Desc2))
            {
                PointF pfDesc = new PointF(pfText.X + sfText.Width, pfText.Y + sfText.Height);
                if (!string.IsNullOrEmpty(data.Desc1))
                {
                    g.DrawString(data.Desc1, this.Font, brush, pfDesc);
                    pfDesc = new PointF(pfDesc.X, pfDesc.Y + sfText.Height);
                    if (!string.IsNullOrEmpty(data.Desc2))
                        g.DrawString(data.Desc2, this.Font, brush, pfDesc);
                }
            }

            #endregion

            //绘制右边图形
            g.DrawImage(bitmap, this.Width - distance - imageWidth, distance, imageWidth, imageWidth);
        }

        private void DrawTopImageBottomWord(Graphics g)
        {
            Brush brush;
            Bitmap bitmap;

            if (this.Enabled == true)
            {
                brush = Brushes.Black;
                bitmap = data.Image;
            }
            else
            {
                brush = Brushes.Gray;
                bitmap = PublicMethods.SetGray(data.Image);
            }

            PointF pfImg = new PointF(distance, distance);
            SizeF sfImg = new SizeF(imageWidth, imageWidth);

            //绘制上边图形
            g.DrawImage(bitmap, pfImg.X, pfImg.Y, sfImg.Width, sfImg.Height);

            PointF pfText = new PointF(0, pfImg.Y + sfImg.Height + distance);
            SizeF sfText = PublicMethods.GetWordSizeF(g, this.Font, data.Text);
            if (this.Width > sfText.Width)
                pfText.X = (this.Width - sfText.Width) / 2;

            //绘制下边文字
            g.DrawString(data.Text, this.Font, brush, pfText);

            PointF pfDesc = new PointF(0, pfText.Y + sfText.Height);
            if (!string.IsNullOrEmpty(data.Desc1))
                g.DrawString(data.Desc1, this.Font, Brushes.Gray, pfDesc);
        }
    }

    [Serializable]
    [Description("图标类型")]
    public enum IconLayoutType
    {
        LeftWordRightImage,
        LeftImageRightWord,
        TopWordBottomImage,
        TopImageBottomWord,
    }
}