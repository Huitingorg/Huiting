using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDSoft.Components
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(TextBox))]
    public class BDNumBox : BDTextBox
    {
        #region  member fields

        private const int m_MaxDecimalLength = 20;  // max dot length
        private const int m_MaxValueLength = 27; // decimal can be 28 bits.

        private const int WM_CHAR = 0x0102; // char key message
        private const int WM_CUT = 0x0300;  // mouse message in ContextMenu
        private const int WM_COPY = 0x0301;
        private const int WM_PASTE = 0x0302;
        private const int WM_CLEAR = 0x0303;

        private int m_decimalLength = 0;
        private bool m_allowNegative = true;
        private string m_valueFormatStr = string.Empty;

        private char m_decimalSeparator = '.';
        private char m_negativeSign = '-';
        private bool showEmptyWhenZero = false;

        public bool IsModify = false;

        /// <summary>
        /// 数字长度限制
        /// </summary>
        private int integerLenth = -1;
        #endregion

        #region  class constructor

        public BDNumBox()
        {
            base.Multiline = false;
            base.TextAlign = HorizontalAlignment.Right;
            base.Text = "0";

            System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
            m_decimalSeparator = ci.NumberFormat.CurrencyDecimalSeparator[0];
            m_negativeSign = ci.NumberFormat.NegativeSign[0];

            this.SetValueFormatStr();
        }

        #endregion

        #region  disabled public properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(typeof(HorizontalAlignment), "Right")]
        public new HorizontalAlignment TextAlign
        {
            get { return base.TextAlign; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new string[] Lines
        {
            get { return base.Lines; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new ImeMode ImeMode
        {
            get { return base.ImeMode; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new char PasswordChar
        {
            get { return base.PasswordChar; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool UseSystemPasswordChar
        {
            get { return base.UseSystemPasswordChar; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool Multiline
        {
            get { return base.Multiline; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return base.AutoCompleteCustomSource; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new AutoCompleteMode AutoCompleteMode
        {
            get { return base.AutoCompleteMode; }
            set { base.AutoCompleteMode = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new AutoCompleteSource AutoCompleteSource
        {
            get { return base.AutoCompleteSource; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new CharacterCasing CharacterCasing
        {
            get { return base.CharacterCasing; }
        }

        #endregion

        #region override public properties

        [DefaultValue("0")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {

                double val;
                if (double.TryParse(value, out val))
                {
                    base.Text = val.ToString(m_valueFormatStr);
                }
                else
                {
                    if (!showEmptyWhenZero)
                    {
                        base.Text = "";
                    }
                    else
                    {

                        base.Text = 0.ToString(m_valueFormatStr);
                    }
                }
                IsModify = false;
            }
        }


        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override int MaxLength
        {
            get
            {
                return base.MaxLength;
            }
        }

        #endregion

        #region  custom public properties

        [Category("扩展")]
        [Description("小数点位数，范围0－10，若为<=0表示无小数位")]
        [DefaultValue(0)]
        public int DecimalLength
        {
            get
            {
                return m_decimalLength;
            }
            set
            {
                if (m_decimalLength != value)
                {
                    if (value < 0 || value > m_MaxDecimalLength)
                    {
                        m_decimalLength = 0;
                    }
                    else
                    {
                        m_decimalLength = value;
                    }
                    this.SetValueFormatStr();
                    base.Text = this.Value.ToString(m_valueFormatStr);
                }
            }
        }

        [Category("扩展")]
        [Description("整数位长度,-1为不限制")]
        [DefaultValue(-1)]
        public int IntegerLength
        {
            get
            {
                return integerLenth;
            }
            set
            {
                integerLenth = value;
            }
        }

        [Category("扩展")]
        [Description("数据是否可被导航.")]
        [DefaultValue(true)]
        public bool AllowNegative
        {
            get { return m_allowNegative; }
            set
            {
                if (m_allowNegative != value)
                {
                    m_allowNegative = value;
                }
            }
        }

        [Category("扩展")]
        [Description("数据为空时显示0")]
        [DefaultValue(true)]
        public bool ShowEmptyWhenZero
        {
            get
            {
                return showEmptyWhenZero;
            }
            set
            {
                showEmptyWhenZero = value;
            }

        }

        [Category("扩展")]
        [Description("获取整数值")]
        public int IntValue
        {
            get
            {
                decimal val = this.Value;
                return (int)val;
            }
        }

        [Category("扩展")]
        [Description("获取值.")]
        public decimal Value
        {
            get
            {
                decimal val;
                if (decimal.TryParse(base.Text, out val))
                {
                    return val;
                }
                return 0;
            }
        }

        #endregion

        #region  override events or methods

        private bool IsNumStr(string Str)
        {
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");
            return reg1.IsMatch(Str);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PASTE)  // mouse paste
            {
                this.ClearSelection();
                string ClipText = Clipboard.GetText();

                //修改，为防止被360截获
                //SendKeys.Send(Clipboard.GetText());
                if (IsNumStr(ClipText))
                {
                    this.Text = ClipText;
                }
                base.OnTextChanged(EventArgs.Empty);
            }
            else if (m.Msg == WM_COPY)  // mouse copy
            {
                Clipboard.SetText(this.SelectedText);
            }
            else if (m.Msg == WM_CUT)  // mouse cut or ctrl+x shortcut
            {
                Clipboard.SetText(this.SelectedText);
                this.ClearSelection();
                base.OnTextChanged(EventArgs.Empty);
            }
            else if (m.Msg == WM_CLEAR)
            {
                this.ClearSelection();
                base.OnTextChanged(EventArgs.Empty);
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys)Shortcut.CtrlV)
            {
                this.ClearSelection();

                string text = Clipboard.GetText();
                //                SendKeys.Send(text);

                for (int k = 0; k < text.Length; k++) // can not use SendKeys.Send
                {
                    SendCharKey(text[k]);
                }
                return true;
            }
            else if (keyData == (Keys)Shortcut.CtrlC)
            {
                if (string.IsNullOrEmpty(this.SelectedText))
                {
                    return true;
                }
                Clipboard.SetText(this.SelectedText);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (!this.ReadOnly)
            {
                if (e.KeyData == Keys.Delete || e.KeyData == Keys.Back)
                {
                    if (this.SelectedText.Length == this.Text.Length)
                    {
                        if (!showEmptyWhenZero)
                        {
                            this.Text = "";
                            return;
                        }
                    }


                    if (this.SelectionLength > 0)
                    {
                        this.ClearSelection();
                    }
                    else
                    {
                        this.DeleteText(e.KeyData);
                    }
                    e.SuppressKeyPress = true;  // does not transform event to KeyPress, but to KeyUp
                }
            }

        }

        private bool IsMuchLong()
        {
            if (integerLenth == -1)
            {
                return true;
            }
            if (!string.IsNullOrEmpty(this.SelectedText))
            {
                return true;
            }
            int BeginIndex = this.SelectionStart;
            int DotIndex = this.Text.IndexOf(".");
            if ((BeginIndex > DotIndex) && (DotIndex != -1))
            {
                return true;
            }

            if (this.Text.IndexOf(".") <= 0)
            {
                if (this.Text.Length >= integerLenth)
                {
                    return false;
                }

                return true;
            }
            else
            {
                if (this.Text.IndexOf(".") >= integerLenth)
                {
                    return false;
                }

            }

            return true;
        }

        private void OpInputData(string Value)
        {
            int SelectIndex = this.SelectionStart;
            int DotIndex = this.Text.IndexOf(".");
            if ((DotIndex == -1) && (this.Text == "0"))
            {
                this.Text = Value;
                return;
            }

            if ((((SelectionStart + 1) == DotIndex) || (SelectionStart == DotIndex)) && (DotIndex == 1) && (this.Text.Substring(0, 1) == "0"))
            {
                this.Text = Value + this.Text.Substring(1);
                return;
            }
            if (this.Text.Length == SelectIndex)
            {
                return;
            }

            if (this.Text.Substring(SelectIndex, 1) == ".")
            {
                return;
            }

            this.Text = this.Text.Substring(0, SelectIndex) + Value + this.Text.Substring(SelectIndex + 1);
            this.SelectionStart = SelectIndex + 1;
        }

        /// <summary>
        /// repostion SelectionStart, recalculate SelectedLength
        /// </summary>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (this.ReadOnly)
            {
                return;
            }


            if (e.KeyChar == (char)13 || e.KeyChar == (char)3 || e.KeyChar == (char)22 || e.KeyChar == (char)24)
            {
                return;
            }

            if (m_decimalLength == 0 && e.KeyChar == m_decimalSeparator)
            {
                e.Handled = true;
                return;
            }

            if (!m_allowNegative && e.KeyChar == m_negativeSign && base.Text.IndexOf(m_negativeSign) < 0)
            {
                e.Handled = true;
                return;
            }

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != m_negativeSign && e.KeyChar != m_decimalSeparator)
            {
                e.Handled = true;
                return;
            }
            //****************************************************************************************
            e.KeyChar = ToDBC(e.KeyChar.ToString()).ToCharArray()[0];

            if ((e.KeyChar.ToString() != ".") && (!IsMuchLong()))
            {
                OpInputData(e.KeyChar.ToString());
                e.Handled = true;
                return;
            }

            IsModify = true;
            if (!showEmptyWhenZero)
            {
                if (this.Text == "")
                {
                    string Str = "0";
                    if (m_decimalLength > 0)
                    {
                        Str += ".";
                    }
                    for (int i = 0; i < m_decimalLength; i++)
                    {
                        Str += "0";
                    }
                    Str = Str.Substring(1);
                    //Str = e.KeyChar.ToString() + Str;
                    this.Text = Str;
                }


            }

            if (base.Text.Length >= m_MaxValueLength && e.KeyChar != m_negativeSign)
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == m_decimalSeparator || e.KeyChar == m_negativeSign)  // will position after dot(.) or first
            {
                this.SelectionLength = 0;
            }
            else
            {
                this.ClearSelection();
            }
            bool isNegative = false;
            if (base.Text == "")
            {
                isNegative = false;
            }
            else
            {
                isNegative = (base.Text[0] == m_negativeSign) ? true : false;
            }


            if (isNegative && this.SelectionStart == 0)
            {
                this.SelectionStart = 1;
            }

            if (e.KeyChar == m_negativeSign)
            {
                int selStart = this.SelectionStart;

                if (!isNegative)
                {
                    base.Text = m_negativeSign + base.Text;
                    this.SelectionStart = selStart + 1;
                }
                else
                {
                    base.Text = base.Text.Substring(1, base.Text.Length - 1);
                    if (selStart >= 1)
                    {
                        this.SelectionStart = selStart - 1;
                    }
                    else
                    {
                        this.SelectionStart = 0;
                    }
                }
                e.Handled = true;  // minus(-) has been handled
                return;
            }

            int dotPos = base.Text.IndexOf(m_decimalSeparator) + 1;

            if (e.KeyChar == m_decimalSeparator)
            {
                if (dotPos > 0)
                {
                    this.SelectionStart = dotPos;
                }
                e.Handled = true;  // dot has been handled 
                return;
            }

            if (base.Text == "0")
            {
                this.SelectionStart = 0;
                this.SelectionLength = 1;  // replace thre first char, ie. 0
            }
            else if (base.Text == m_negativeSign + "0")
            {
                this.SelectionStart = 1;
                this.SelectionLength = 1;  // replace thre first char, ie. 0
            }
            else if (m_decimalLength > 0)
            {
                if (base.Text[0] == '0' && dotPos == 2 && this.SelectionStart <= 1)
                {
                    this.SelectionStart = 0;
                    this.SelectionLength = 1;  // replace thre first char, ie. 0
                }
                else if (base.Text.Substring(0, 2) == m_negativeSign + "0" && dotPos == 3 && this.SelectionStart <= 2)
                {
                    this.SelectionStart = 1;
                    this.SelectionLength = 1;  // replace thre first char, ie. 0
                }
                else if (this.SelectionStart == dotPos + m_decimalLength)
                {
                    e.Handled = true;  // last position after text
                }
                else if (this.SelectionStart >= dotPos)
                {
                    this.SelectionLength = 1;
                }
                else if (this.SelectionStart < dotPos - 1)
                {
                    this.SelectionLength = 0;
                }
            }
        }

        /// <summary> 转半角的函数(DBC case) </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        private string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        /// <summary>
        /// reformat the base.Text
        /// </summary>
        protected override void OnLeave(EventArgs e)
        {
            if (string.IsNullOrEmpty(base.Text))
            {
                if (!showEmptyWhenZero)
                {
                    base.Text = "";
                }
                else
                {
                    base.Text = 0.ToString(m_valueFormatStr);
                }
            }
            else
            {
                base.Text = this.Value.ToString(m_valueFormatStr);
            }
            base.OnLeave(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            if (this.Text == "")
            {
                string Str = "0";
                if (m_decimalLength > 0)
                {
                    Str += ".";
                }
                for (int i = 0; i < m_decimalLength; i++)
                {
                    Str += "0";
                }
                this.Text = Str;

            }

            base.OnEnter(e);
        }

        #endregion

        #region  custom private methods

        private void SetValueFormatStr()
        {
            m_valueFormatStr = "F" + m_decimalLength.ToString();
        }

        private void SendCharKey(char c)
        {
            Message msg = new Message();

            msg.HWnd = this.Handle;
            msg.Msg = WM_CHAR;
            msg.WParam = (IntPtr)c;
            msg.LParam = IntPtr.Zero;

            base.WndProc(ref msg);
        }

        /// <summary>
        /// Delete operator will be changed to BackSpace in order to
        /// uniformly handle the position of deleted digit.
        /// </summary>
        private void DeleteText(Keys key)
        {


            int selStart = this.SelectionStart;  // base.Text will be delete at selStart - 1

            if (key == Keys.Delete)  // Delete key change to BackSpace key, adjust selStart value
            {
                selStart += 1;  // adjust position for BackSpace
                if (selStart > base.Text.Length)  // text end
                {
                    return;
                }

                if (this.IsSeparator(selStart - 1))  // next if delete dot(.) or thousands(;)
                {
                    selStart++;
                }
            }
            else  // BackSpace key
            {
                if (selStart == 0)  // first position
                {
                    return;
                }

                if (this.IsSeparator(selStart - 1)) // char which will be delete is separator
                {
                    selStart--;
                }
            }

            if (selStart == 0 || selStart > base.Text.Length)  // selStart - 1 no digig
            {
                return;
            }

            int dotPos = base.Text.IndexOf(m_decimalSeparator);
            bool isNegative = (base.Text.IndexOf(m_negativeSign) >= 0) ? true : false;

            if (selStart > dotPos && dotPos >= 0)  // delete digit after dot(.)
            {
                base.Text = base.Text.Substring(0, selStart - 1) + base.Text.Substring(selStart, base.Text.Length - selStart) + "0";
                base.SelectionStart = selStart - 1;  // SelectionStart is unchanged
            }
            else // delete digit before dot(.)
            {
                if (selStart == 1 && isNegative)  // delete 1st digit and Text is negative,ie. delete minus(-)
                {
                    if (base.Text.Length == 1)  // ie. base.Text is '-'
                    {
                        base.Text = "0";
                    }
                    else if (dotPos == 1)  // -.* format
                    {
                        base.Text = "0" + base.Text.Substring(1, base.Text.Length - 1);
                    }
                    else
                    {
                        base.Text = base.Text.Substring(1, base.Text.Length - 1);
                    }
                    base.SelectionStart = 0;
                }
                else if (selStart == 1 && (dotPos == 1 || base.Text.Length == 1))  // delete 1st digit before dot(.) or Text.Length = 1
                {
                    base.Text = "0" + base.Text.Substring(1, base.Text.Length - 1);
                    base.SelectionStart = 1;
                }
                else if (isNegative && selStart == 2 && base.Text.Length == 2)  // -* format
                {
                    base.Text = m_negativeSign + "0";
                    base.SelectionStart = 1;
                }
                else if (isNegative && selStart == 2 && dotPos == 2)  // -*.* format
                {
                    base.Text = m_negativeSign + "0" + base.Text.Substring(2, base.Text.Length - 2);
                    base.SelectionStart = 1;
                }
                else  // selStart > 0
                {
                    base.Text = base.Text.Substring(0, selStart - 1) + base.Text.Substring(selStart, base.Text.Length - selStart);
                    base.SelectionStart = selStart - 1;
                }
            }
        }

        /// <summary>
        /// clear base.SelectedText
        /// </summary>
        private void ClearSelection()
        {
            if (this.SelectionLength == 0)
            {
                return;
            }

            if (this.SelectedText.Length == base.Text.Length)
            {
                base.Text = 0.ToString(m_valueFormatStr);
                return;
            }

            int selLength = this.SelectedText.Length;
            if (this.SelectedText.IndexOf(m_decimalSeparator) >= 0)
            {
                selLength--; // selected text contains dot(.), selected length minus 1
            }

            this.SelectionStart += this.SelectedText.Length;  // after selected text
            this.SelectionLength = 0;

            for (int k = 1; k <= selLength; k++)
            {
                this.DeleteText(Keys.Back);
            }
        }

        private bool IsSeparator(int index)
        {
            return this.IsSeparator(base.Text[index]);
        }

        private bool IsSeparator(char c)
        {
            if (c == m_decimalSeparator)
            {
                return true;
            }
            return false;
        }

        #endregion


    }
}
