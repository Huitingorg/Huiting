using Huiting.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Huiting.Components.DrawPanel
{
    [DefaultProperty("Text"), DefaultEvent("Click")]
    public class IconItemPanel : MousePanel
    {
        #region 属性

        string text = "样品展示";
        [Category("Appearance"), Description("文本"), Browsable(true)]
        public override string Text { get => text; set => text = value; }


        private Bitmap image = Properties.Resources.sample;
        [Category("Appearance"), Description("图形"),]
        public Bitmap Image { get => image; set => image = value; }



        #endregion

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            DrawTopImageBottomWord(e.Graphics);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected int distance = 8;
        protected int minImageWidth = 16;


        private void DrawTopImageBottomWord(Graphics g)
        {
            Brush brush;
            if (this.Enabled == true)
                brush = new SolidBrush(ForeColor);
            else
                brush = Brushes.Gray;

            SizeF sfText = PublicMethods.GetWordSizeF(g, this.Font, this.Text);
            PointF pfText = new PointF(0, this.Height - distance - sfText.Height);
            if (this.Width > sfText.Width)
                pfText.X = (this.Width - sfText.Width) / 2;

            //绘制下边文字
            g.DrawString(this.Text, this.Font, brush, pfText);





            if (this.Width >= distance * 2 || this.Height >= distance * 3 + sfText.Height)
            {
                Bitmap bitmap;
                if (this.Enabled == true)
                    bitmap = this.Image;
                else
                    bitmap = PublicMethods.SetGray(this.Image);

                PointF pfImg = new PointF(distance, distance);
                SizeF sfImg = new SizeF(this.Width - distance * 2, this.Height - distance * 3 - sfText.Height);
                int curMinWidth = this.Width < this.Height ? this.Width : this.Height;
                if (curMinWidth < minImageWidth)
                    curMinWidth = minImageWidth;
                //绘制上边图形
                g.DrawImage(bitmap, pfImg.X, pfImg.Y, sfImg.Width, sfImg.Height);
            }



        }




    }


}
