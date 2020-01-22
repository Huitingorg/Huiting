using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;

namespace Huiting.Components
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(TextBox))]
    public class BDTextBox : TextBox
    {
        //可写背景色
        private Color writableBackColor;
        //只读背景色
        private Color readOnlyBackColor;
        //BorderStyle.Fixed3D高度
        private int singleLineMaxHeight = 21;
        //BorderStyle.None高度
        private int singleLineMinHeight = 14;
        //字符宽度
        int charWidth = 11;

        bool useWritableBackColor = true;
        [Category("扩展")]
        [Description("使用可写背景色")]
        [DefaultValue(true)]
        public bool UseWritableBackColor
        {
            get { return useWritableBackColor; }
            set { useWritableBackColor = value; }
        }

        HWTextBoxDisplayStyle displayStyle = HWTextBoxDisplayStyle.Normal;
        [Category("扩展")]
        [Description("文本框界面展示风格")]
        [DefaultValue(HWTextBoxDisplayStyle.Normal)]
        public HWTextBoxDisplayStyle DisplayStyle
        {
            get { return displayStyle; }
            set
            {
                if (displayStyle == value)
                    return;

                if (base.Multiline == false)
                {
                    //先使用背景刷新一下
                    FillParentBackColor();

                    if (value == HWTextBoxDisplayStyle.Normal)
                    {
                        if (base.BorderStyle != BorderStyle.Fixed3D)
                            base.BorderStyle = BorderStyle.Fixed3D;
                    }
                    else
                    {
                        if (base.BorderStyle != BorderStyle.None)
                            base.BorderStyle = BorderStyle.None;
                    }

                    //DisplayType oldValue = GetHWTextBoxDisplayStyle(displayStyle);
                    //DisplayType newValue = GetHWTextBoxDisplayStyle(value);
                    //SetLocationAndSize(oldValue,newValue);

                    displayStyle = value;
                }
                this.Refresh();
            }
        }

        Color modifierColor;
        [Category("扩展")]
        [Description("修饰符颜色。修饰符是指展示风格中的下划线、中括号等符号颜色。")]
        [DefaultValue(typeof(Color), "Black")]
        public Color ModifierColor
        {
            get { return modifierColor; }
            set
            {
                if (modifierColor == value)
                    return;
                modifierColor = value;
                this.Refresh();
            }
        }

        DashStyle lineStyle = DashStyle.Solid;
        [Category("扩展")]
        [Description("下划线的样式")]
        [DefaultValue(DashStyle.Solid)]
        public DashStyle LineStyle
        {
            get { return lineStyle; }
            set
            {
                if (lineStyle == value)
                    return;
                lineStyle = value;
                //if (this.BorderStyle != BorderStyle.None)
                FillParentBackColor();
                if (displayStyle != HWTextBoxDisplayStyle.Underline)
                    displayStyle = HWTextBoxDisplayStyle.Underline;


                this.Refresh();
            }
        }

        //private int limitLength = -1;
        ///// <summary>
        ///// 长度限制
        ///// </summary>
        //[Category("扩展")]
        //[Description("长度限制，小于0表示无限制")]
        //[DefaultValue(-1)]
        //public int LimitLength
        //{
        //    get { return limitLength; }
        //    set { limitLength = value; }
        //}
        //protected override void OnTextChanged(EventArgs e)
        //{
        //    if (limitLength>1)
        //    base.OnTextChanged(e);

        //}

        public BDTextBox()
        {
            base.ReadOnly = false;
            writableBackColor = base.BackColor;
            base.ReadOnly = true;
            readOnlyBackColor = base.BackColor;
            base.ReadOnly = false;

            base.BorderStyle = BorderStyle.Fixed3D;
            singleLineMaxHeight = base.Height;
            base.BorderStyle = BorderStyle.None;
            singleLineMinHeight = base.Height;
            base.BorderStyle = BorderStyle.Fixed3D;

            modifierColor = base.ForeColor;
        }

        #region 本想让文本框居中，不发生肉眼看到的组件变化 ，但是时间不够了，代码先放这儿

        private enum DisplayType
        {
            Normal,
            Underline,
            Other,
        }

        private DisplayType GetHWTextBoxDisplayStyle(HWTextBoxDisplayStyle oldValue)
        {
            DisplayType displayStyle = DisplayType.Normal;
            switch (oldValue)
            {
                case HWTextBoxDisplayStyle.Normal:
                    displayStyle = DisplayType.Normal;
                    break;
                case HWTextBoxDisplayStyle.Underline:
                    displayStyle = DisplayType.Underline;
                    break;
                default:
                    displayStyle = DisplayType.Other;
                    break;
            }
            return displayStyle;
        }

        private void SetLocationAndSize(DisplayType oldValue, DisplayType newValue)
        {
            lockLocationChanged = true;
            lockSizeChanged = true;

            switch (oldValue)
            {
                case DisplayType.Normal:
                    OldValueIsNormal(newValue);
                    break;
                case DisplayType.Underline:
                    OldValueIsUnderline(newValue);
                    break;
                case DisplayType.Other:
                default:
                    OldValueIsOther(newValue);
                    break;
            }

            lockLocationChanged = false;
            lockSizeChanged = false;
        }

        //如果原类型是Normal
        private void OldValueIsNormal(DisplayType newValue)
        {
            switch (newValue)
            {
                case DisplayType.Underline:
                    ModifyLocationY(true);
                    break;
                case DisplayType.Other:
                    ModifySizeWidth(false);
                    ModifyLocationY(true);
                    ModifyLocationX(true);
                    break;
                default:
                    break;
            }
        }

        //如果原类型是Underline
        private void OldValueIsUnderline(DisplayType newValue)
        {
            switch (newValue)
            {
                case DisplayType.Normal:
                    ModifyLocationY(false);
                    break;
                case DisplayType.Other:
                    ModifySizeWidth(false);
                    ModifyLocationX(true);
                    break;
                default:
                    break;
            }
        }

        //如果原类型是Other
        private void OldValueIsOther(DisplayType newValue)
        {
            switch (newValue)
            {
                case DisplayType.Normal:
                    ModifySizeWidth(true);
                    ModifyLocationY(false);
                    ModifyLocationX(false);
                    break;
                case DisplayType.Underline:
                    ModifySizeWidth(true);
                    ModifyLocationX(false);
                    break;
                default:
                    break;
            }
        }

        private void ModifyLocationY(bool LagerOrSmall)
        {
            int diff = (singleLineMaxHeight - singleLineMinHeight) / 2;

            if (LagerOrSmall)
                this.Location = new Point(base.Location.X, base.Location.Y + diff);
            else
                this.Location = new Point(base.Location.X, base.Location.Y - diff);
        }

        private void ModifyLocationX(bool LagerOrSmall)
        {
            int diff = charWidth / 2;

            if (LagerOrSmall)
                this.Location = new Point(base.Location.X + diff, base.Location.Y);
            else
                this.Location = new Point(base.Location.X - diff, base.Location.Y);
        }

        private void ModifySizeWidth(bool LagerOrSmall)
        {
            if (LagerOrSmall)
                this.Width = base.Width + charWidth * 2;
            else
                this.Width = base.Width - charWidth * 2;
        }

        bool lockSizeChanged = false;
        protected override void OnSizeChanged(EventArgs e)
        {
            if (lockSizeChanged == true)
                return;
            base.OnSizeChanged(e);
        }

        bool lockLocationChanged = false;
        protected override void OnLocationChanged(EventArgs e)
        {
            if (lockLocationChanged == true)
                return;
            base.OnLocationChanged(e);
        }

        #endregion

        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
            set
            {
                if (base.BorderStyle == value)
                    return;

                base.BorderStyle = value;
                if (displayStyle != HWTextBoxDisplayStyle.Normal)
                    FillParentBackColor();
                if (base.BorderStyle != BorderStyle.None)
                    this.displayStyle = HWTextBoxDisplayStyle.Normal;
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);

            if (this.ReadOnly)
            {
                if (useWritableBackColor)
                    base.BackColor = writableBackColor;
                else
                    base.BackColor = readOnlyBackColor;
            }
            else
                base.BackColor = writableBackColor;
            this.Invalidate();
        }

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                writableBackColor = value;
                base.BackColor = value;
            }
        }

        //使用父控件背景色刷新组件区域
        private void FillParentBackColor()
        {
            if (this.Parent == null)
                return;
            Graphics g = Graphics.FromHwnd(this.Parent.Handle);
            FillParentBackColor(g);
            g.Dispose();
        }

        int maxExpandWidth = 11;
        int maxHeight = 21;
        private void FillParentBackColor(Graphics g)
        {
            SolidBrush sbParentColor = new SolidBrush(this.Parent.BackColor);
            //SolidBrush sbParentColor = new SolidBrush(Color.Red);
            g.FillRectangle(sbParentColor, new Rectangle(-1 * maxExpandWidth + base.Location.X, base.Location.Y, base.Width + maxExpandWidth * 2, maxHeight));
            sbParentColor.Dispose();
        }

        //绘制修饰符
        private void DrawModifier(string prefix, string suffix)
        {
            Graphics g = Graphics.FromHwnd(this.Parent.Handle);
            SizeF sfPrefix = g.MeasureString(prefix, base.Font);
            SizeF sfSuffix = g.MeasureString(suffix, base.Font);

            int intPrefix = (int)Math.Ceiling(sfPrefix.Width);
            int intSuffix = (int)Math.Ceiling(sfPrefix.Width);

            //使用控件背景色刷新一下
            SolidBrush sbBackColor;
            if (useWritableBackColor)
                sbBackColor = new SolidBrush(writableBackColor);
            else
                sbBackColor = new SolidBrush(readOnlyBackColor);
            g.FillRectangle(sbBackColor, new Rectangle(-intPrefix + base.Location.X, base.Location.Y, base.Width + intPrefix + intSuffix, base.Height));

            SolidBrush sb = new SolidBrush(this.modifierColor);
            g.DrawString(prefix, this.Font, sb, new PointF(0 - sfPrefix.Width + base.Location.X, base.Location.Y));
            g.DrawString(suffix, this.Font, sb, new PointF(base.Width + base.Location.X, base.Location.Y));
            sb.Dispose();
            g.Dispose();
        }

        //绘制线
        private void DrawUnderLine()
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;

            if (this.Enabled)
            {
                Pen pen = new Pen(modifierColor);
                pen.DashStyle = this.lineStyle;
                g.DrawLine(pen, new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - 1), new Point(this.ClientRectangle.Width, this.ClientRectangle.Height - 1));
            }
            else
            {
                Pen pen = new Pen(Color.LightGray);
                pen.DashStyle = this.lineStyle;
                g.DrawLine(pen, new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - 1), new Point(this.ClientRectangle.Width, this.ClientRectangle.Height - 1));
            }
            g.Dispose();
        }

        const int WM_PAINT = 0x000F;
        protected override void WndProc(ref   Message m)
        {
            base.WndProc(ref   m);
            //如果是多行
            if (base.Multiline == true)
                return;
            //如果是正常显示网格，则返回 
            if (this.displayStyle == HWTextBoxDisplayStyle.Normal)
                return;

            if (m.Msg == WM_PAINT)
            {
                if (this.displayStyle == HWTextBoxDisplayStyle.Underline)
                {
                    DrawUnderLine();
                }
                else if (this.DisplayStyle == HWTextBoxDisplayStyle.RoundBracket)
                {
                    DrawModifier("(", ")");
                }
                else if (this.displayStyle == HWTextBoxDisplayStyle.SquareBracket)
                {
                    DrawModifier("[", "]");
                }
                else if (this.displayStyle == HWTextBoxDisplayStyle.AngleBracket)
                {
                    DrawModifier("<", ">");
                }
            }

        }

    }

    /// <summary>
    /// 文本框界面展示风格
    /// </summary>
    public enum HWTextBoxDisplayStyle
    {
        /// <summary>
        /// 普通文本框界面
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 下划线文本框界面
        /// </summary>
        Underline = 1,
        /// <summary>
        /// 圆括号文本框界面
        /// </summary>
        RoundBracket = 2,
        /// <summary>
        /// 中括号文本框界面
        /// </summary>
        SquareBracket = 3,
        /// <summary>
        /// 尖括号文本框界面
        /// </summary>
        AngleBracket = 4
    }
}
