using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDSoft.Components
{
    [Serializable]
    public class MousePanel : DrawPanel
    {
        Color borderColorWithMouseOut;

        public Color BorderColorWithMouseOut
        {
            get { return borderColorWithMouseOut; }
            set { borderColorWithMouseOut = value; }
        }
        Color borderColorWithMouseIn;

        public Color BorderColorWithMouseIn
        {
            get { return borderColorWithMouseIn; }
            set { borderColorWithMouseIn = value; }
        }
        Color borderColorWithMouseDown;

        public Color BorderColorWithMouseDown
        {
            get { return borderColorWithMouseDown; }
            set { borderColorWithMouseDown = value; }
        }

        Color fillColorWithMouseOut;

        public Color FillColorWithMouseOut
        {
            get { return fillColorWithMouseOut; }
            set { fillColorWithMouseOut = value; }
        }
        Color fillColorWithMouseIn;

        public Color FillColorWithMouseIn
        {
            get { return fillColorWithMouseIn; }
            set {
                fillColorWithMouseIn = value;
            }
        }

        Color fillColorWithMouseDown;

        public Color FillColorWithMouseDown
        {
            get { return fillColorWithMouseDown; }
            set
            {
                fillColorWithMouseDown = value;
            }
        }

        private new Color BorderColor { get; set; }
        private new Color FillColor { get; set; }


        private Timer timer1;
        private System.ComponentModel.IContainer components;

        int showCount = 5;
        int tmpCount = 0;
        Color tmpClrBorder;
        Color tmpClrFill;
        int redBlock1, greenBlock1, blueBlock1;
        int redBlock2, greenBlock2, blueBlock2;

        public MousePanel()
        {
            borderColorWithMouseOut = Color.White; 
            borderColorWithMouseIn = Color.FromArgb(112, 192, 231);
            borderColorWithMouseDown = Color.FromArgb(38, 160, 218);

            fillColorWithMouseOut = Color.White;
            fillColorWithMouseIn = Color.FromArgb(229, 243, 251);
            fillColorWithMouseDown = Color.FromArgb(203, 232, 246);

            InitializeComponent();

            this.SetColor(borderColorWithMouseOut, fillColorWithMouseOut);
        }

        #region Events

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (timer1.Enabled)
                return;
            base.SetColor(borderColorWithMouseIn, fillColorWithMouseIn);
        }

        public void Restore()
        {
            if (this.BorderColor != borderColorWithMouseOut || this.FillColor != fillColorWithMouseOut)
                base.SetColor(this.borderColorWithMouseOut, this.fillColorWithMouseOut);
            this.Update();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (timer1.Enabled)
                return;
            base.SetColor(borderColorWithMouseDown, fillColorWithMouseDown);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (timer1.Enabled)
                return;
            
            base.SetColor(borderColorWithMouseIn, fillColorWithMouseIn);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (timer1.Enabled)
                return;

            redBlock1 = (this.borderColorWithMouseIn.R - this.borderColorWithMouseOut.R) / showCount;
            greenBlock1 = (this.borderColorWithMouseIn.G - this.borderColorWithMouseOut.G) / showCount;
            blueBlock1 = (this.borderColorWithMouseIn.B - this.borderColorWithMouseOut.B) / showCount;

            redBlock2 = (this.fillColorWithMouseIn.R - this.fillColorWithMouseOut.R) / showCount;
            greenBlock2 = (this.fillColorWithMouseIn.G - this.fillColorWithMouseOut.G) / showCount;
            blueBlock2 = (this.fillColorWithMouseIn.B - this.fillColorWithMouseOut.B) / showCount;

            timer1.Start();
        }

        #endregion

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            this.ResumeLayout(false);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tmpCount < showCount)
            {
                if (tmpCount == 0)
                {
                    tmpClrBorder = borderColorWithMouseIn;
                    tmpClrFill = fillColorWithMouseIn;
                }

                tmpClrBorder = Color.FromArgb(tmpClrBorder.R - redBlock1, tmpClrBorder.G - greenBlock1, tmpClrBorder.B - blueBlock1);
                tmpClrFill = Color.FromArgb(tmpClrFill.R - redBlock2, tmpClrFill.G - greenBlock2, tmpClrFill.B - blueBlock2);
                base.SetColor(tmpClrBorder, tmpClrFill);
                tmpCount++;
            }
            else
            {
                base.SetColor(this.borderColorWithMouseOut, this.fillColorWithMouseOut);
                timer1.Enabled = false;
                tmpCount = 0;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            timer1.Dispose();
        }

    }
}