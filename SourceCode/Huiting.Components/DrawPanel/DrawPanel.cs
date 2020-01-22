using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huiting.Components.DrawPanel
{
    [Serializable]
    public class DrawPanel : Panel
    {
        Color borderColor;

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                if (SetBorderColor(value))
                    this.Invalidate();
            }
        }

        Color fillColor;
        public Color FillColor
        {
            get { return fillColor; }
            set
            {
                if (SetFillColor(value))
                    this.Invalidate();
            }
        }

        Pen borderPen;
        private System.ComponentModel.IContainer components;
        SolidBrush fillBrush;

        Rectangle rectBorder;
        public DrawPanel()
        {
            SetColor(this.BackColor, this.BackColor);
            this.DoubleBuffered = true;
            rectBorder = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
        }

        public void SetColor(Color BorderColor, Color FillColor)
        {
            bool borderColorChanged = SetBorderColor(BorderColor);
            bool fillColorChanged = SetFillColor(FillColor);
            if (borderColorChanged || fillColorChanged)
                this.Invalidate();
        }

        private bool SetBorderColor(Color BorderColor)
        {
            if (this.borderColor == BorderColor)
                return false;

            this.borderColor = BorderColor;
            if (borderPen == null)
                borderPen = new Pen(borderColor);
            else
                borderPen.Color = borderColor;
            return true;
        }

        private bool SetFillColor(Color FillColor)
        {
            if (this.fillColor == FillColor)
                return false;

            this.fillColor = FillColor;
            if (fillBrush == null)
                fillBrush = new SolidBrush(fillColor);
            else
                fillBrush.Color = fillColor;

            return true;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            rectBorder = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (fillColor != BackColor && fillBrush != null)
                g.FillRectangle(fillBrush, this.ClientRectangle);

            if (borderColor != this.BackColor && borderPen != null)
                g.DrawRectangle(borderPen, rectBorder);

            base.OnPaint(e);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.borderPen.Dispose();
            this.fillBrush.Dispose();
        }
    }
}
