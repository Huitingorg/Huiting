using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BDSoft.Components
{
    public class BDNumBoxEx : TTextBoxEx
    {
        #region  属性

        private const int m_MaxDecimalLength = 10;  // max dot length
        private const int m_MaxValueLength = 27; // decimal can be 28 bits.

        private const int WM_CHAR = 0x0102; // char key message
        private const int WM_CUT = 0x0300;  // mouse message in ContextMenu
        private const int WM_COPY = 0x0301;
        private const int WM_PASTE = 0x0302;
        private const int WM_CLEAR = 0x0303;

        private int m_decimalLength = -1;
        private bool m_allowNegative = true;
        private string m_valueFormatStr = string.Empty;

        private char m_decimalSeparator = '.';
        private char m_negativeSign = '-';
        private bool m_showZeroWhenNull = false;

        public bool IsModify = false;

        /// <summary>
        /// 数字长度限制
        /// </summary>
        private int m_DataLenth = -1;

        private int showDecimalLength = 2;
        private int enterShowDecimalLength = 5;
        private decimal realvalue = 0;
        private bool entenAutoSelAllText = true;
        private bool IsEnten = false;
        private DateTime EnterTime = DateTime.Now;
        //Timer FocusTime = null;
        #endregion

        private int DataLength
        {
            get
            {
                return m_DataLenth;
            }
            set
            {
                m_DataLenth = value;

            }
        }

        private int DecimalLength
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
                    base.Text = this.realvalue.ToString(m_valueFormatStr);
                }
            }
        }

        [Category("新增属性")]
        [Description("当前实际存储取值")]
        public decimal RealValue
        {
            get
            {
               
                return realvalue;
            }
            set
            {
                if(RealValue == value)
                {
                    if ((!string.IsNullOrEmpty(this.Text)) && (realvalue != -99999))
                    {
                        return;
                    }
                    
                }
                realvalue = value;
                if (realvalue == -99999)
                {
                    this.Text = "";
                }
                else
                {
                    int dotIndex = value.ToString().IndexOf(".");
                    if(dotIndex == -1)
                    {
                        this.Text = value.ToString();
                    }
                    else
                    {
                        string TempValue = value.ToString();
                        int DecimalLength = TempValue.Length - dotIndex - 1;
                        if (DecimalLength > showDecimalLength)
                        {
                            this.Text = Math.Round(realvalue, ShowDecimalLength).ToString();

                        }
                        else
                        {
                            this.Text = value.ToString();
                            IsModify = true;
                            base.OnTextChanged(new EventArgs());
                        }

                    }

                }
            }
        }

        //{
        //    get
        //    {
        //        decimal val;
        //        if (decimal.TryParse(base.Text, out val))
        //        {
        //            return val;
        //        }
        //        return 0;
        //    }
        //}
        [Category("新增属性")]
        [Description("设置要显示的小数点位数，0－10")]
        [DefaultValue(0)]
        public int ShowDecimalLength
        {
            get
            {
                return showDecimalLength;
            }
            set
            {
                showDecimalLength = value;
            }
        }


        [Category("新增属性")]
        [Description("控件获取焦点后设置要显示的小数点位数，-1－10，-1为不控制")]
        [DefaultValue(0)]
        public int EnterShowDecimalLength
        {
            get
            {
                return enterShowDecimalLength;
            }
            set
            {
                enterShowDecimalLength = value;
            }
        }

       
        [Category("新增属性")]
        [Description("当前的值的文本形势")]
        public string TextEx
        {
            get
            {
                if (realvalue == -99999)
                {
                    return "";
                }
                return RealValue.ToString();
            }
            set
            {
                SetText(value);
            }
        }

        [Category("新增属性")]
        [Description("控件获取焦点后默认全选")]
        public bool EnterAutoSelAllText
        {
            get
            {
                return entenAutoSelAllText;
            }
            set
            {
                entenAutoSelAllText = value;
            }
        }






        private bool IsNumStr(string Str)
        {
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");
            return reg1.IsMatch(Str);
        }

        private bool IsMuchLong()
        {
            if (DataLength == -1)
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
                if (this.Text.Length >= DataLength)
                {
                    return false;
                }

                return true;
            }
            else
            {
                if (this.Text.IndexOf(".") >= DataLength)
                {
                    return false;
                }

            }

            return true;
        }

        public void SetText(object Value)
        {
            if((Value == null)||(Value.ToString() == "NaN")||(string.IsNullOrEmpty(Value.ToString())))
            {
                if (RealValue != -99999)
                {
                    IsModify = true;
                }
                RealValue = -99999;
               

                return;
            }
            try
            {
                if(decimal.Parse(Value.ToString()) == RealValue)
                {

                    if (!string.IsNullOrEmpty(this.Text))
                    {
                        IsModify = false;
                        return;
                    }
                    
                }

                if (RealValue.ToString() != Value.ToString())
                {
                    IsModify = true;
                }

                RealValue = decimal.Parse(Value.ToString());
            }
            catch(Exception E)
            {
                RealValue = -99999;
            }

            //decimal? dec = null;
        }


        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == WM_PASTE)  // mouse paste
        //    {
        //        this.ClearSelection();
        //        string ClipText = Clipboard.GetText();

        //        //修改，为防止被360截获
        //        //SendKeys.Send(Clipboard.GetText());
        //        if (IsNumStr(ClipText))
        //        {
        //            this.Text = ClipText;

        //        }
        //        base.OnTextChanged(EventArgs.Empty);
        //    }
        //    else if (m.Msg == WM_COPY)  // mouse copy
        //    {
        //        Clipboard.SetText(this.SelectedText);
        //    }
        //    else if (m.Msg == WM_CUT)  // mouse cut or ctrl+x shortcut
        //    {
        //        Clipboard.SetText(this.SelectedText);
        //        this.ClearSelection();
        //        base.OnTextChanged(EventArgs.Empty);
        //    }
        //    else if (m.Msg == WM_CLEAR)
        //    {
        //        this.ClearSelection();
        //        base.OnTextChanged(EventArgs.Empty);
        //    }
        //    else
        //    {
        //        base.WndProc(ref m);
        //    }
        //}

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (this.ReadOnly)
            {
                return;
            }

            string abc = e.KeyChar.ToString();

            if (e.KeyChar.ToString() == "\b")
            {
                IsModify = true;
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

            
            if (e.KeyChar == m_decimalSeparator)
            {
                int dotPos1 = base.Text.IndexOf(m_decimalSeparator) + 1;
                if (dotPos1 == 0)
                {
                   

                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }
            return;
            //****************************************************************************************
            e.KeyChar = ToDBC(e.KeyChar.ToString()).ToCharArray()[0];

            if ((e.KeyChar.ToString() != ".") && (!IsMuchLong()))
            {
                OpInputData(e.KeyChar.ToString());
                e.Handled = true;
                return;
            }

            IsModify = true;
            if (!m_showZeroWhenNull)
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
                if (dotPos == 0)
                {
                    base.Text = base.Text.Insert(this.SelectionStart, ".");
                    dotPos = base.Text.Length + 1;

                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }


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

        //处理第一次进行全选状态
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (entenAutoSelAllText)
            {
                TimeSpan curSpan = DateTime.Now - EnterTime;

                if (curSpan.TotalMilliseconds < 100)
                {
                    this.SelectAll();

                }

            }

        }
        

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (!this.ReadOnly)
            {
                //if (e.KeyData == Keys.Delete || e.KeyData == Keys.Back)
                //{
                //    if (this.SelectedText.Length == this.Text.Length)
                //    {
                //        if (!m_showZeroWhenNull)
                //        {
                //            this.Text = "";
                //            return;
                //        }
                //    }


                //    if (this.SelectionLength > 0)
                //    {
                //        this.ClearSelection();
                //    }
                //    else
                //    {
                //        this.DeleteText(e.KeyData);
                //    }
                //    e.SuppressKeyPress = true;  // does not transform event to KeyPress, but to KeyUp
                //}
            }

        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    //bool Value = base.ProcessCmdKey(ref msg, keyData);
        //    if (keyData == (Keys)Shortcut.CtrlV)
        //    {
        //        if (this.Text != realvalue.ToString())
        //        {
        //            IsModify = true;
        //        }
        //        //this.ClearSelection();

        //        //string text = Clipboard.GetText();
        //        ////                SendKeys.Send(text);
        //        //IsModify = true;
        //        //for (int k = 0; k < text.Length; k++) // can not use SendKeys.Send
        //        //{
        //        //    SendCharKey(text[k]);
        //        //}
        //        //return true;
        //    }
        //    else if (keyData == (Keys)Shortcut.CtrlC)
        //    {
        //        //if (string.IsNullOrEmpty(this.SelectedText))
        //        //{
        //        //    return true;
        //        //}
        //        //Clipboard.SetText(this.SelectedText);
        //        //return true;
        //    }
        //    else if (keyData == (Keys)Shortcut.CtrlX)
        //    {
        //        if (this.Text != realvalue.ToString())
        //        {
        //            IsModify = true;
        //        }
        //        //if (string.IsNullOrEmpty(this.SelectedText))
        //        //{
        //        //    return true;
        //        //}
        //        //Clipboard.SetText(this.SelectedText);
        //        //return true;
        //    }
        //    else if (keyData == Keys.Delete)
        //    {
        //        if (this.SelectionStart < this.Text.Length)
        //        {
        //            IsModify = true;
        //        }
        //    }
        //    return  base.ProcessCmdKey(ref msg, keyData);
        //}

        protected override void OnEnter(EventArgs e)
        {
            
            if ((realvalue != 0)&&(realvalue !=-99999))
            {
                if (enterShowDecimalLength == -1)
                {
                    //没有设置进入后格式化显示功能
                    this.Text = realvalue.ToString();
             
                }
                else
                {
                    this.Text = Math.Round(realvalue, enterShowDecimalLength).ToString();
                }

            }
            else
                this.Text = "";
            IsEnten = true;
            base.OnEnter(e);
            if(entenAutoSelAllText)
            {
                this.SelectAll();
            }
            EnterTime = DateTime.Now;

            //this.SelectionStart = 0;
            //this.SelectionLength = this.Text.Length;
        }

        protected override void OnLeave(EventArgs e)
        {
            IsEnten = false;
            if (IsModify)
            {
                if (this.Text == "")
                {
                    this.realvalue = -99999;
                }
                else
                {
                    this.realvalue = decimal.Parse(this.Text);

                }
            }
            if (this.Text != "")
            {
                if (this.Text == realvalue.ToString())
                {
                    IsModify = false;
                    this.Text = Math.Round(realvalue, ShowDecimalLength).ToString();
                }
                else
                {
                    this.Text = Math.Round(realvalue, ShowDecimalLength).ToString();

                }

            }
            else
            {
                if ((string.IsNullOrEmpty(this.Text)) && (realvalue != -99999))
                {
                    IsModify = true;
                }
                this.realvalue = -99999;

            }
            base.OnLeave(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if(this.Text == realvalue.ToString())
            {
                return;
            }
            try
            {
                if(decimal.Parse(this.Text) == realvalue)
                {
                    return;
                }
            }
            catch
            {

            }
            if ((string.IsNullOrEmpty(this.Text)) && (realvalue != -99999))
            {
                base.OnTextChanged(e);
                return;
            }

            if(IsEnten)
            {
                if(this.Text.EndsWith("."))
                {
                    return;
                }
                if (this.Text != realvalue.ToString())
                {
                    try
                    {
                        this.realvalue = decimal.Parse(this.Text);
                    }
                    catch(Exception EE)
                    {

                    }
                    base.OnTextChanged(e);

                    return;
                }
            }

            if (!IsModify)
            {
                return;
            }
            base.OnTextChanged(e);
        }

        private void ClearSelection()
        {
            return;
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

        private void DeleteText(Keys key)
        {

            //return;
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
                string TempValue = this.Text;
                string TempValue2 = base.Text;
                base.Text = base.Text.Substring(0, selStart - 1) + base.Text.Substring(selStart, base.Text.Length - selStart) + "0";
                string TempValue3 = base.Text;
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

        private void SendCharKey(char c)
        {
            Message msg = new Message();

            msg.HWnd = this.Handle;
            msg.Msg = WM_CHAR;
            msg.WParam = (IntPtr)c;
            msg.LParam = IntPtr.Zero;

            base.WndProc(ref msg);
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

        private void SetValueFormatStr()
        {
            m_valueFormatStr = "F" + m_decimalLength.ToString();
        }
    }

    public class TTextBoxEx : TextBox
    {
        private string m_version;
        private bool m_keepBackColorWhenReadOnly = true;
        private Color m_backColor;
        private Color m_backColorWhenReadOnly;
        private bool lineStyle;
        public TTextBoxEx()
        {
            this.m_version = "1.0";
            this.ForeColor = Color.Blue;

            m_backColor = base.BackColor;
            base.ReadOnly = true;
            m_backColorWhenReadOnly = base.BackColor;
            base.ReadOnly = false;


            lineStyle = false;
        }

        [DefaultValue(typeof(Color), "Blue")]
        public new Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        [DefaultValue(typeof(Color), "Window")]
        public new Color BackColor
        {
            get { return m_backColor; }
            set
            {
                if (m_backColor != value)
                {
                    m_backColor = value;
                    base.BackColor = value;
                    this.OnBackColorChanged(EventArgs.Empty);
                }
            }
        }

        [Category("新增属性")]
        [Description("Set/Get if keep backcolor when textbox is readonly.")]
        [DefaultValue(true)]
        public bool KeepBackColorWhenReadOnly
        {
            get { return m_keepBackColorWhenReadOnly; }
            set
            {
                if (m_keepBackColorWhenReadOnly != value)
                {
                    m_keepBackColorWhenReadOnly = value;
                    this.OnBackColorChanged(EventArgs.Empty);
                }
            }
        }

        [Category("新增属性")]
        [Description("Get TNumEditBox Version.")]
        public string Version
        {
            get { return m_version; }
            protected set { m_version = value; }
        }

        public new bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                if (base.ReadOnly != value)
                {
                    base.ReadOnly = value;
                    this.OnBackColorChanged(EventArgs.Empty);
                }
            }
        }

        [Category("新增属性")]
        [Description("是否为线型模式")]
        public bool LineStyle
        {
            get
            {
                return lineStyle;
            }
            set
            {

                lineStyle = value;
                if (value)
                {
                    this.BorderStyle = BorderStyle.None;

                }
                //else
                //{

                //    this.BorderStyle = BorderStyle.Fixed3D;
                //}
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);

            if (this.ReadOnly)
            {
                if (m_keepBackColorWhenReadOnly)
                {
                    base.BackColor = m_backColor;
                }
                else
                {
                    base.BackColor = m_backColorWhenReadOnly;
                }
            }
            else
            {
                base.BackColor = m_backColor;
            }
            this.Invalidate();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (!LineStyle)
            {
                return;
            }
            const int WM_PAINT = 0x000F;

            //this.BorderStyle = BorderStyle.None;

            if (m.Msg == WM_PAINT)
            {
                Graphics g = Graphics.FromHwnd(this.Handle);

                //g.DrawRectangle(Pens.DarkBlue, this.ClientRectangle.Left, this.ClientRectangle.Top, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
                if (this.Enabled)
                {
                    g.DrawLine(Pens.Black, new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - 1), new Point(this.ClientRectangle.Width, this.ClientRectangle.Height - 1));
                }
                else
                {
                    //this.BackColor = Color.White;
                    g.DrawLine(Pens.LightGray, new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - 1), new Point(this.ClientRectangle.Width, this.ClientRectangle.Height - 1));

                }
                g.Dispose();
            }

        }
    }
}
