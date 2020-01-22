using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReserveComponents
{
    public partial class MyDateTimePicker : DateTimePicker
    {
        Color clrBlue;
        Color clrGray;
        Color clrFill;

        public new Color CalendarForeColor
        {
            get
            {
                return base.CalendarForeColor;
            }
            set
            {
                base.CalendarForeColor = value;
                this.Invalidate();
            }
        }

        public MyDateTimePicker()
        {
            InitializeComponent();
            clrBlue = Color.FromArgb(126, 180, 234);
            clrGray = Color.FromArgb(171,173,179);
            clrFill = Color.FromArgb(100,222,238,252);

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.ResizeRedraw |
                    ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.CalendarForeColor), 0, 3);
            Image img = Properties.Resources.downBlack;
            Point ptImage = new Point(this.ClientRectangle.X + this.ClientRectangle.Width - 16 + (16 - img.Width) / 2, this.ClientRectangle.Y + (this.Height - img.Height) / 2);

            Rectangle rect = this.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;
            if (flag){
                e.Graphics.DrawRectangle(new Pen(clrBlue), rect);

                Rectangle rect2 = new Rectangle(this.ClientRectangle.X + this.ClientRectangle.Width - 17, 0, 16, this.Height-1);
                e.Graphics.DrawRectangle(new Pen(clrBlue), rect2);
                rect2.X += 1;
                rect2.Y += 1;
                rect2.Width -= 1;
                rect2.Height -= 1;
                e.Graphics.FillRectangle(new SolidBrush(clrFill),rect2);

                e.Graphics.DrawImage(Properties.Resources.downBlack, ptImage);
            }
            else
            {
                e.Graphics.DrawRectangle(new Pen(clrGray), rect);
                e.Graphics.DrawImage(Properties.Resources.downGray, ptImage);
            }
        }

        bool flag = false;
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            flag = true;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            flag = false;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MyDateTimePicker
            // 
            this.CustomFormat = "yyyyMM";
            this.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ResumeLayout(false);

        }

    }
}
