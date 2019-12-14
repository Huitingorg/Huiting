﻿using Huiting.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BDSoft.Components
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(DateTimePicker))]
    public class BD_YearMonthControl:ComboBox
    {
        //DateTime SendEvenTime = DateTime.Now;
        C_YearMonthControl opControl = null;
        public BD_YearMonthControl()
        {
            this.Text = DateTime.Now.ToString("yyyyMM");
            opControl = new C_YearMonthControl(this);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            string curValue = this.Text.Replace(" ", "");
            if(curValue.Length <6)
            {
                return;
            }

            base.OnTextChanged(e);
        }
    }

    public class C_YearMonthControl
    {
        //当前要操作的组合框
        ComboBox curComb;
        //自定义的下拉列表项
        ToolStripControlHost dateTimeHost;
        //下拉控件
        ToolStripDropDown dropDown;
        //指示当前下拉列表是否呈显示状态
        private bool m_blDropShow = false;

        //下拉显示的年月控件
        UC_YearMonthSel curDropListControl = new UC_YearMonthSel();

        public C_YearMonthControl(ComboBox curComb)
        {
            this.curComb = curComb;
            curComb.DropDownHeight = 1;
            Init();
        }

        public void Init()
        {
            DrawDateTimeForm();
            curComb.DropDown += new EventHandler(curComb_DropDown);
            curComb.KeyDown += new KeyEventHandler(curComb_KeyDown);
            curDropListControl.KeyDown += new KeyEventHandler(curDropListControl_KeyDown);
            OPDatetime opTime = new OPDatetime(curComb, "yyyyMM", false);
        }

        /// <summary>
        /// 画下拉选择数据列表
        /// </summary>
        private void DrawDateTimeForm()
        {
            dateTimeHost = new ToolStripControlHost(curDropListControl);
            dateTimeHost.AutoSize = true;
            dropDown = new ToolStripDropDown();
            
            dropDown.Items.Add(dateTimeHost);
            dropDown.Padding = new Padding(1, 0, 1, 0);
            dropDown.Closed += new ToolStripDropDownClosedEventHandler(dropDown_Closed);
        }

        /// <summary>
        /// 下拉列表关闭时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dropDown_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            //设置下拉列表显示状态为否
            m_blDropShow = false;

           curComb.Text = curDropListControl.Value;
        }

        /// <summary>
        /// 组合框下拉事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void curComb_DropDown(object sender, EventArgs e)
        {
            //if (curConfigInfo == null)
            //{
            //    curConfigInfo = new D_DateTimeInfo();

            //}
            //if (!curConfigInfo.DropListEnable)
            //{
            //    return;
            //}
            if (!m_blDropShow)
            {
                if (curComb.Text.Trim() == "")
                {
                    //curDropListControl.monthCalendar_Sel.SelectionStart = DateTime.Now;
                    //curDropListControl.monthCalendar_Sel.SelectionEnd = DateTime.Now;
                }
                else
                {
                    DateTime tempTime;
                    try
                    {
                        if (curComb.Text.Length >= 10)
                        {
                            tempTime = DateTime.Parse(curComb.Text);
                            //curDropListControl.monthCalendar_Sel.SelectionStart = tempTime;
                            //curDropListControl.monthCalendar_Sel.SelectionEnd = tempTime;
                        }
                        else
                        {
                            //curDropListControl.monthCalendar_Sel.SelectionStart = DateTime.Now;
                            //curDropListControl.monthCalendar_Sel.SelectionEnd = DateTime.Now;
                        }

                    }
                    catch
                    {
                        //curDropListControl.monthCalendar_Sel.SelectionStart = DateTime.Now;
                        //curDropListControl.monthCalendar_Sel.SelectionEnd = DateTime.Now;
                    }
                }

                ShowDropDown();
            }
            else
            {
                dropDown.Close();
            }
        }

        void curDropListControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                dropDown.Close();
            }
        }

        void curComb_KeyDown(object sender, KeyEventArgs e)
        {
            //if ((e.KeyData == Keys.Down))// && (curConfigInfo.DropListEnable))
            //{
            //    curComb_DropDown(null, null);
            //    e.Handled = true;
            //}
        }

        /// <summary>
        /// 显示下拉项
        /// </summary>
        private void ShowDropDown()
        {
            if (dropDown == null)
            {
                return;
            }
            //if (curDropListControl != null)
            //{
            //    curDropListControl.Font = new Font("微软雅黑", 12);
            //}

            //curComb.SelectedText = "";

            curDropListControl.Value = curComb.Text;
            Point screenPoint = curComb.Parent.PointToScreen(curComb.Location);

            //判断一下下方是否能显示完整下拉窗体
            int Y = screenPoint.Y + curComb.Height + 1 + curDropListControl.Height;
            if (Y > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height)
            {
                //表示组合框已经非常接近屏幕下方，窗体应在上方显示
                dropDown.Show(curComb, 0, -dropDown.Height - 1);
                dropDown.Focus();
                dateTimeHost.Control.Focus();
                m_blDropShow = true;
                //curDropListControl.timer_CheckCombo.Enabled = true;
                return;
            }
            dropDown.Show(curComb, 0, curComb.Height + 1);
            dropDown.Focus();
            dateTimeHost.Control.Focus();
            m_blDropShow = true;
            curDropListControl.textBox_Focus.Focus();
            curDropListControl.timer_focus.Enabled = true;
            //curDropListControl.timer_CheckCombo.Enabled = true;
        }
    }

    public class OPDatetime
    {

        #region 属性定义
        int YearBeginIndex = -1;
        int MonthBeginIndex = -1;
        int DayBeginIndex = -1;
        int HourBeginIndex = -1;
        int MinuteBeginIndex = -1;
        int SecoudBeginInex = -1;
        DateType curEditDateType = DateType.None;

        DataTable InfoTable = new DataTable();

        ComboBox curCombo;
        string FormatStr;
        public bool DateLock = false;
        public bool TimePriority = false;

        public string NullFillValue = "";

        public string TimeFormt
        {
            get
            {
                return FormatStr;
            }
            set
            {
                if ((value != FormatStr) && (!string.IsNullOrEmpty(value)))
                {
                    FormatStr = value;
                    InitIndexInfo();
                }
                else
                {
                    FormatStr = value;
                }
            }
        }

        public enum DateType { None, Year, Month, Day, Hour, Minite, Secound };


        #endregion

        //构造函数
        public OPDatetime(ComboBox curcontrol, string FormatStr, bool DateLock, bool TimePriority)
        {
            this.DateLock = DateLock;
            this.TimePriority = TimePriority;
            this.curCombo = curcontrol;
            this.FormatStr = FormatStr;
            InfoTable.Columns.Add("Name", typeof(System.Int32));
            InfoTable.Columns.Add("Position", typeof(System.Int32));
            curcontrol.GotFocus += new EventHandler(curcontrol_GotFocus);
            InitEven();
            if (!string.IsNullOrEmpty(FormatStr.Trim()))
            {
                InitIndexInfo();
            }
        }
        public OPDatetime(ComboBox curcontrol, string FormatStr, bool DateLock)
        {
            this.DateLock = DateLock;
            this.curCombo = curcontrol;
            this.FormatStr = FormatStr;
            InfoTable.Columns.Add("Name", typeof(System.Int32));
            InfoTable.Columns.Add("Position", typeof(System.Int32));
            curcontrol.GotFocus += new EventHandler(curcontrol_GotFocus);
            InitEven();
            if (!string.IsNullOrEmpty(FormatStr.Trim()))
            {
                InitIndexInfo();
            }
        }
        /// <summary>
        /// 获取焦点后放置到第一个可修改项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void curcontrol_GotFocus(object sender, EventArgs e)
        {

            curCombo.SelectionStart = 0;
            curCombo.SelectionLength = 0;
            if (DateLock)
            {
                SetNextDatetype();
            }
            else
            {
                if (TimePriority)
                {
                    DateLock = true;
                    SetNextDatetype();
                    DateLock = false;
                }
                else
                {
                    SetNextDatetype();
                    SetPreDatetype();
                }
            }
        }


        //初始化
        private void InitIndexInfo()
        {
            InfoTable.Rows.Clear();

            string Value = FormatStr;
            YearBeginIndex = Value.IndexOf("yyyy", StringComparison.CurrentCulture);

            MonthBeginIndex = Value.IndexOf("MM", StringComparison.CurrentCulture);
            DayBeginIndex = Value.IndexOf("dd", StringComparison.CurrentCulture);

            HourBeginIndex = Value.IndexOf("HH", StringComparison.CurrentCulture);
            if (HourBeginIndex == -1)
            {
                HourBeginIndex = Value.IndexOf("hh", StringComparison.CurrentCulture);
            }
            MinuteBeginIndex = Value.IndexOf("mm", StringComparison.CurrentCulture);
            SecoudBeginInex = Value.IndexOf("ss", StringComparison.CurrentCulture);

            DataRow NewRow = InfoTable.NewRow();
            NewRow["Name"] = (int)DateType.Year;
            NewRow["Position"] = YearBeginIndex;
            InfoTable.Rows.Add(NewRow);

            DataRow NewRow2 = InfoTable.NewRow();
            NewRow2["Name"] = (int)DateType.Month;
            NewRow2["Position"] = MonthBeginIndex;
            InfoTable.Rows.Add(NewRow2);

            DataRow NewRow3 = InfoTable.NewRow();
            NewRow3["Name"] = (int)DateType.Day;
            NewRow3["Position"] = DayBeginIndex;
            InfoTable.Rows.Add(NewRow3);

            DataRow NewRow4 = InfoTable.NewRow();
            NewRow4["Name"] = (int)DateType.Hour;
            NewRow4["Position"] = HourBeginIndex;
            InfoTable.Rows.Add(NewRow4);

            DataRow NewRow5 = InfoTable.NewRow();
            NewRow5["Name"] = (int)DateType.Minite;
            NewRow5["Position"] = MinuteBeginIndex;
            InfoTable.Rows.Add(NewRow5);

            DataRow NewRow6 = InfoTable.NewRow();
            NewRow6["Name"] = (int)DateType.Secound;
            NewRow6["Position"] = SecoudBeginInex;
            InfoTable.Rows.Add(NewRow6);
        }

        #region 事件相关
        bool KeyPressNoOP = false;
        DateTime NullInputTime = DateTime.Now;
        string FirstKeys = "";
        string EnKeyValue = "";

        private void InitEven()
        {
            curCombo.KeyPress += new KeyPressEventHandler(curcontrol_KeyPress);
            curCombo.KeyDown += new KeyEventHandler(curCombo_KeyDown);
            curCombo.MouseClick += new MouseEventHandler(curCombo_MouseClick);
        }

        void curCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                curCombo.Text = "";
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                InutFill();
                return;

            }

            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                return;
            }


            if (curCombo.Text.Trim() == "")
            {
                if ((e.KeyData == Keys.Left) || (e.KeyData == Keys.Right))
                {
                    return;
                }
                KeyPressNoOP = true;
                if (string.IsNullOrEmpty(NullFillValue))
                {
                    NullInputTime = DateTime.Now;
                    if ((e.KeyValue == 97) || (e.KeyData == Keys.D1))
                    {
                        FirstKeys = "1";
                    }
                    else if ((e.KeyValue == 98) || (e.KeyData == Keys.D2))
                    {
                        FirstKeys = "2";
                    }
                    else
                    {
                        FirstKeys = "";
                    }

                    //PublicMethods.WarnMessageBox(FirstKeys);
                    string Houre = e.KeyCode.ToString();
                    if (Houre.StartsWith("Down"))
                    {
                        curCombo.Text = DateTime.Now.ToString(FormatStr);
                    }
                    else if ((Houre.StartsWith("D")) || (Houre.StartsWith("NumPad")))
                    {
                        if (Houre.StartsWith("D"))
                        {
                            Houre = Houre.Substring(1);
                        }
                        else if (Houre.StartsWith("NumPad"))
                        {
                            Houre = Houre.Substring(6);
                        }

                        string ShowValue = "";
                        string TempStr = DateTime.Now.ToString(FormatStr);
                        ShowValue = TempStr;
                        bool NeedJumpNext = false;
                        if (FormatStr == "yyyy-MM-dd HH:mm")
                        {
                            if ((Houre == "0") || (Houre == "1") || (Houre == "2"))
                            {
                                ShowValue = TempStr.Substring(0, 10) + " " + Houre + " :00";
                            }
                            else
                            {
                                ShowValue = TempStr.Substring(0, 10) + " 0" + Houre + ":00";
                                NeedJumpNext = true;
                            }
                        }
                        else if (FormatStr == "yyyy-MM-dd HH:mm:ss")
                        {

                            if ((Houre == "0") || (Houre == "1") || (Houre == "2"))
                            {
                                ShowValue = TempStr.Substring(0, 10) + " " + Houre + " " + TempStr.Substring(13);
                            }
                            else
                            {
                                ShowValue = TempStr.Substring(0, 10) + " 0" + Houre + TempStr.Substring(13);
                                NeedJumpNext = true;
                            }
                        }
                        else if (FormatStr == "HH:mm:ss")
                        {
                            if ((Houre == "0") || (Houre == "1") || (Houre == "2"))
                            {
                                ShowValue = Houre + " " + TempStr.Substring(2);
                            }
                            else
                            {
                                ShowValue = "0" + Houre + TempStr.Substring(2);
                                NeedJumpNext = true;
                            }
                        }

                        curCombo.Text = ShowValue;
                        if (NeedJumpNext)
                        {
                            curCombo.SelectionStart = 12;
                            SetNextDatetype();
                            e.Handled = true;
                            curEditDateType = DateType.Minite;
                            return;
                        }
                    }
                    else
                    {
                        curCombo.Text = DateTime.Now.ToString(FormatStr);
                    }
                    e.Handled = true;
                    curEditDateType = DateType.Year;
                    if (TimePriority)
                    {
                        DateLock = true;
                        SetNextDatetype();
                        DateLock = false;
                    }
                    return;
                }
                else
                {
                    try
                    {
                        string RealValue = NullFillValue;
                       
                        if (string.IsNullOrEmpty(RealValue))
                        {
                            curCombo.Text = DateTime.Now.ToString(FormatStr);
                        }
                        else
                        {
                            DateTime curTime = DateTime.Parse(RealValue);
                            curCombo.Text = curTime.ToString(FormatStr);
                        }
                    }
                    catch
                    {
                        curCombo.Text = DateTime.Now.ToString(FormatStr);
                    }
                    e.Handled = true;
                    curEditDateType = DateType.Year;
                    if (TimePriority)
                    {
                        DateLock = true;
                        SetNextDatetype();
                        DateLock = false;
                    }
                    return;

                }
            }

            if (e.KeyCode == Keys.Right)
            {
                if (curCombo.SelectionLength == curCombo.Text.Length)
                {
                    return;
                }
                InutFill();
                if (SetNextDatetype())
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                InutFill();
                if (SetPreDatetype())
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyCode == Keys.Up)
            {

                if (curCombo.Text.Trim() == "")
                {
                    curCombo.Text = DateTime.Now.ToString(FormatStr);
                    e.Handled = true;
                    curEditDateType = DateType.Year;
                    return;
                }
                if ((curCombo.SelectedText.Length == curCombo.Text.Length) && (curCombo.Text.Length > 4))
                {

                    return;
                }
                UpKeyPress();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                if (curCombo.Text.Trim() == "")
                {
                    curCombo.Text = DateTime.Now.ToString(FormatStr);
                    e.Handled = true;
                    curEditDateType = DateType.Year;
                    return;
                }
                if ((curCombo.SelectedText.Length == curCombo.Text.Length) && (curCombo.Text.Length > 4))
                {

                    return;
                }
                DownKeyPress();
                e.Handled = true;

            }

        }

        void UpKeyPress()
        {
            switch (curEditDateType)
            {
                case DateType.Year:

                    UpYear();
                    break;
                case DateType.Month:

                    UpMonth();
                    break;
                case DateType.Day:

                    UpDay();
                    break;
                case DateType.Hour:
                    UpHour();
                    break;
                case DateType.Minite:
                    UpMiniter();
                    break;
                case DateType.Secound:
                    UpSecond();
                    break;
                case DateType.None:

                    break;

            }

        }

        void DownKeyPress()
        {
            switch (curEditDateType)
            {
                case DateType.Year:
                    DownYear();
                    break;
                case DateType.Month:
                    DownMonth();
                    break;
                case DateType.Day:
                    DownDay();
                    break;
                case DateType.Hour:
                    DownHour();
                    break;
                case DateType.Minite:
                    DownMinute();
                    break;
                case DateType.Secound:
                    DownSencond();
                    break;
                case DateType.None:
                    break;

            }

        }

        void curcontrol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressNoOP)
            {
                KeyPressNoOP = false;
                e.Handled = true;
                return;
            }
            if (e.KeyChar.ToString() == "enter")
            {

                return;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (curCombo.Text.Trim() == "")
            {
                curCombo.Text = DateTime.Now.ToString(FormatStr);
                e.Handled = true;
                curEditDateType = DateType.Year;
                return;
            }
            InputKeyPress(e.KeyChar.ToString());
            e.Handled = true;
            return;
        }

        void InputKeyPress(string Key)
        {

            switch (curEditDateType)
            {
                case DateType.Year:
                    InputYear(Key);
                    break;
                case DateType.Month:
                    InputMonth(Key);
                    break;
                case DateType.Day:
                    InputDay(Key);
                    break;
                case DateType.Hour:
                    InputHour(Key);
                    break;
                case DateType.Minite:
                    InputMinute(Key);
                    break;
                case DateType.Secound:
                    InputSencond(Key);
                    break;
                case DateType.None:
                    break;

            }

        }

        void curCombo_MouseClick(object sender, MouseEventArgs e)
        {
            if (curCombo.SelectedText.Length == curCombo.Text.Length)
            {
                return;
            }
            int curIndex = curCombo.SelectionStart;
            InutFill();

            SetSelState(curIndex);

        }

        #endregion

        #region 鼠标位置处理

        private bool SetNextDatetype()
        {
            if (string.IsNullOrEmpty(curCombo.Text))
            {
                return true;
            }
            int curIndex = curCombo.SelectionStart;
            DataRow[] Rows = InfoTable.Select("Position>" + curIndex.ToString(), "Position");
            if (Rows.Length == 0)
            {
                curCombo.SelectionStart = curCombo.Text.Length;
                return false;
            }

            int NextIndex = int.Parse(Rows[0]["Position"].ToString());
            if (DateLock)
            {
                if ((GetcurSelType(NextIndex) == DateType.Day) || (GetcurSelType(NextIndex) == DateType.Year) || (GetcurSelType(NextIndex) == DateType.Month))
                {
                    curCombo.SelectionStart = NextIndex;
                    SetNextDatetype();

                }
                else
                {
                    SetSelState(NextIndex);

                }
                return true;
            }

            SetSelState(NextIndex);
            return true;
        }

        private bool SetPreDatetype()
        {
            if (string.IsNullOrEmpty(curCombo.Text))
            {
                return true;
            }
            int curIndex = curCombo.SelectionStart;
            DataRow[] Rows = InfoTable.Select("Position<" + curIndex.ToString(), "Position desc");
            if (Rows.Length == 0)
            {
                curCombo.SelectionStart = 0;
                curCombo.SelectionLength = 0;
                return false;
            }

            int NextIndex = int.Parse(Rows[0]["Position"].ToString());
            if (DateLock)
            {
                if ((GetcurSelType(NextIndex) == DateType.Day) || (GetcurSelType(NextIndex) == DateType.Year) || (GetcurSelType(NextIndex) == DateType.Month))
                {
                    curCombo.SelectionStart = 0;
                }
                else
                {
                    SetSelState(NextIndex);
                }
                return true;
            }
            SetSelState(NextIndex);
            return true;
        }

        /// <summary>
        /// 设置选中状态
        /// </summary>
        /// <param name="curIndex"></param>
        private void SetSelState(int curIndex)
        {
            curEditDateType = GetcurSelType(curIndex);
            switch (curEditDateType)
            {
                case DateType.Year:
                    curCombo.SelectionStart = YearBeginIndex;
                    curCombo.SelectionLength = 4;
                    break;
                case DateType.Month:
                    curCombo.SelectionStart = MonthBeginIndex;
                    curCombo.SelectionLength = 2;
                    break;
                case DateType.Day:
                    curCombo.SelectionStart = DayBeginIndex;
                    curCombo.SelectionLength = 2;
                    break;
                case DateType.Hour:
                    curCombo.SelectionStart = HourBeginIndex;
                    curCombo.SelectionLength = 2;
                    break;
                case DateType.Minite:
                    curCombo.SelectionStart = MinuteBeginIndex;
                    curCombo.SelectionLength = 2;
                    break;
                case DateType.Secound:
                    curCombo.SelectionStart = SecoudBeginInex;
                    curCombo.SelectionLength = 2;
                    break;
                case DateType.None:
                    break;

            }

        }

        /// <summary>
        /// 获取当前鼠标类型所在区域
        /// </summary>
        /// <param name="curIndex"></param>
        /// <returns></returns>
        private DateType GetcurSelType(int curIndex)
        {
            if (FormatStr == "yyyyMM")
            {
                if ((curIndex >= YearBeginIndex) && (curIndex < (YearBeginIndex + 4)) && (YearBeginIndex != -1))
                {
                    return DateType.Year;
                }
                if ((curIndex >= MonthBeginIndex) && (curIndex <= (MonthBeginIndex + 2)) && (MonthBeginIndex != -1))
                {
                    return DateType.Month;
                }

            }

            if ((curIndex >= YearBeginIndex) && (curIndex <= (YearBeginIndex + 4)) && (YearBeginIndex != -1))
            {
                return DateType.Year;
            }
            if ((curIndex >= MonthBeginIndex) && (curIndex <= (MonthBeginIndex + 2)) && (MonthBeginIndex != -1))
            {
                return DateType.Month;
            }
            if ((curIndex >= DayBeginIndex) && (curIndex <= (DayBeginIndex + 2)) && (DayBeginIndex != -1))
            {
                return DateType.Day;
            }
            if ((curIndex >= HourBeginIndex) && (curIndex <= (HourBeginIndex + 2)) && (HourBeginIndex != -1))
            {
                return DateType.Hour;
            }

            if ((curIndex >= MinuteBeginIndex) && (curIndex <= (MinuteBeginIndex + 2)) && (MinuteBeginIndex != -1))
            {
                return DateType.Minite;
            }

            if ((curIndex >= SecoudBeginInex) && (curIndex <= (SecoudBeginInex + 2)) && (SecoudBeginInex != -1))
            {
                return DateType.Secound;
            }
            return DateType.None;
        }
        /// <summary>
        /// 输入不足自动补足
        /// </summary>
        private void InutFill()
        {
            //return;
            if (string.IsNullOrEmpty(curCombo.Text.Trim()))
            {
                return;
            }
            switch (curEditDateType)
            {
                case DateType.Year:
                    OPYear();
                    break;
                case DateType.Month:
                    OPMonth();
                    break;
                case DateType.Day:
                    OPDay();
                    break;
                case DateType.Hour:
                    OPHour();
                    break;
                case DateType.Minite:
                    OPMiniter();
                    break;
                case DateType.Secound:
                    OPSecond();
                    break;
                case DateType.None:
                    break;

            }

        }

        #endregion

        #region 年处理

        private void UpYear()
        {
            if (DateLock)
            {
                return;
            }
            if (YearBeginIndex == -1)
            {
                int curIndex = curCombo.SelectionStart;
                SetSelState(curIndex);
                UpKeyPress();
                return;
            }
            int curYear = DateTime.Now.Year;
            try
            {
                curYear = int.Parse(curCombo.Text.Substring(YearBeginIndex, 4));
            }
            catch (Exception E)
            {
                PublicMethods.WarnMessageBox(E.Message);
                curYear = DateTime.Now.Year;
            }
            curYear++;
            if (YearBeginIndex == 0)
            {
                curCombo.Text = curYear.ToString() + curCombo.Text.Substring(4);
            }
            else
            {
                string Info = curCombo.Text.Substring(0, YearBeginIndex) + curYear.ToString() + curCombo.Text.Substring(YearBeginIndex + 4);
                curCombo.Text = Info;
            }
            curCombo.SelectionStart = YearBeginIndex;
            curCombo.SelectionLength = 4;
        }

        private void DownYear()
        {
            if (DateLock)
            {
                return;
            }
            if (YearBeginIndex == -1)
            {
                int curIndex = curCombo.SelectionStart;
                SetSelState(curIndex);
                DownKeyPress();
                return;
            }
            int curYear = DateTime.Now.Year;
            try
            {
                curYear = int.Parse(curCombo.Text.Substring(YearBeginIndex, 4));
            }
            catch (Exception E)
            {
                PublicMethods.WarnMessageBox(E.Message);
                curYear = DateTime.Now.Year;
            }
            curYear--;
            if (YearBeginIndex == 0)
            {
                curCombo.Text = curYear.ToString() + curCombo.Text.Substring(4);
            }
            else
            {
                string Info = curCombo.Text.Substring(0, YearBeginIndex) + curYear.ToString() + curCombo.Text.Substring(YearBeginIndex + 4);
                curCombo.Text = Info;
            }
            curCombo.SelectionStart = YearBeginIndex;
            curCombo.SelectionLength = 4;

        }

        private void InputYear(string Inputstr)
        {
            if (DateLock)
            {
                PublicMethods.WarnMessageBox("日期锁定状态，无法修改日期值");
                return;
            }
            if (YearBeginIndex == -1)
            {
                int curIndex = curCombo.SelectionStart;
                SetSelState(curIndex);
                InputKeyPress(Inputstr);
                return;
            }
            string curStr = curCombo.Text.Substring(YearBeginIndex, 4).Trim();
            string Year = "";
            if (curStr.Length == 4)
            {
                if (string.IsNullOrEmpty(FirstKeys))
                {
                    Year = "   " + Inputstr;
                }
                else
                {
                    DateTime curTime = DateTime.Now;
                    TimeSpan curSpan = curTime - NullInputTime;
                    if (curSpan.TotalSeconds < 3)
                    {
                        Year = "  " + FirstKeys + Inputstr;
                    }
                    else
                    {
                        Year = "   " + Inputstr;

                    }
                }
            }
            else if (curStr.Length == 3)
            {
                Year = curStr + Inputstr;
            }
            else if (curStr.Length == 2)
            {
                Year = " " + curStr + Inputstr;
            }
            else if (curStr.Length == 1)
            {
                Year = "  " + curStr + Inputstr;
            }
            else
            {
                Year = "   " + curStr + Inputstr;
            }
            if (YearBeginIndex == 0)
            {
                curCombo.Text = Year + curCombo.Text.Substring(4);
            }
            else
            {
                string Info = curCombo.Text.Substring(0, YearBeginIndex) + Year + curCombo.Text.Substring(YearBeginIndex + 4);
                curCombo.Text = Info;
            }
            if (Year.Trim().Length == 4)
            {
                SetNextDatetype();
                return;
            }
            curCombo.SelectionStart = YearBeginIndex;
            curCombo.SelectionLength = 4;

        }

        private void OPYear()
        {
            if (YearBeginIndex == -1)
            {
                return;
            }
            string Year = curCombo.Text.Substring(YearBeginIndex, 4).Trim();

            if (Year.Length == 4)
            {
                return;
            }
            if (Year.Length == 3)
            {
                Year = "2" + Year;
            }
            else if (Year.Length == 2)
            {
                Year = "20" + Year;
            }
            else if (Year.Length == 1)
            {
                Year = "201" + Year;
            }
            else
            {
                Year = DateTime.Now.Year.ToString();
            }
            if (YearBeginIndex == 0)
            {
                curCombo.Text = Year + curCombo.Text.Substring(4);
            }
            else
            {
                string Info = curCombo.Text.Substring(0, YearBeginIndex) + Year + curCombo.Text.Substring(YearBeginIndex + 4);
                curCombo.Text = Info;
            }
        }

        #endregion

        #region 月处理

        private void UpMonth()
        {
            if (DateLock)
            {
                return;
            }
            if (MonthBeginIndex == -1)
            {
                int curIndex = curCombo.SelectionStart;
                SetSelState(curIndex);
                UpKeyPress();
                return;
            }
            int curMonth = DateTime.Now.Month;
            try
            {
                curMonth = int.Parse(curCombo.Text.Substring(MonthBeginIndex, 2));
            }
            catch (Exception E)
            {
                PublicMethods.WarnMessageBox(E.Message);
                curMonth = DateTime.Now.Month;
            }
            curMonth++;
            if (curMonth > 12)
            {
                curMonth = 1;
            }
            if (curMonth < 10)
            {
                if (MonthBeginIndex == 0)
                {
                    curCombo.Text = "0" + curMonth.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, MonthBeginIndex) + "0" + curMonth.ToString() + curCombo.Text.Substring(MonthBeginIndex + 2);
                    curCombo.Text = Info;
                }
            }
            else
            {
                if (MonthBeginIndex == 0)
                {
                    curCombo.Text = curMonth.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, MonthBeginIndex) + curMonth.ToString() + curCombo.Text.Substring(MonthBeginIndex + 2);
                    curCombo.Text = Info;
                }

            }
            curCombo.SelectionStart = MonthBeginIndex;
            curCombo.SelectionLength = 2;

        }

        private void DownMonth()
        {
            if (DateLock)
            {
                return;
            }
            if (MonthBeginIndex == -1)
            {
                int curIndex = curCombo.SelectionStart;
                SetSelState(curIndex);
                DownKeyPress();
                return;
            }
            int curMonth = DateTime.Now.Month;
            try
            {
                curMonth = int.Parse(curCombo.Text.Substring(MonthBeginIndex, 2));
            }
            catch (Exception E)
            {
                PublicMethods.WarnMessageBox(E.Message);
                curMonth = DateTime.Now.Month;
            }
            curMonth--;
            if (curMonth < 1)
            {
                curMonth = 12;
            }
            if (curMonth < 10)
            {
                if (MonthBeginIndex == 0)
                {
                    curCombo.Text = "0" + curMonth.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, MonthBeginIndex) + "0" + curMonth.ToString() + curCombo.Text.Substring(MonthBeginIndex + 2);
                    curCombo.Text = Info;
                }
            }
            else
            {
                if (MonthBeginIndex == 0)
                {
                    curCombo.Text = curMonth.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, MonthBeginIndex) + curMonth.ToString() + curCombo.Text.Substring(MonthBeginIndex + 2);
                    curCombo.Text = Info;
                }

            }
            curCombo.SelectionStart = MonthBeginIndex;
            curCombo.SelectionLength = 2;
        }

        private void InputMonth(string Inputstr)
        {
            if (DateLock)
            {
                PublicMethods.WarnMessageBox("日期锁定状态，无法修改日期值");
                return;
            }
            if (Inputstr == "0")
            {
                int a = 1;
            }
            if (MonthBeginIndex == -1)
            {
                int curIndex = curCombo.SelectionStart;
                SetSelState(curIndex);
                InputKeyPress(Inputstr);
                return;
            }
            string curStr = curCombo.Text.Substring(MonthBeginIndex, 2).Trim();
            string Month = "";
            if (curStr.Length == 2)
            {
                if (int.Parse(Inputstr) > 1)
                {
                    Month = "0" + Inputstr;
                }
                else
                {
                    Month = " " + Inputstr;
                }
            }
            else if (curStr.Length == 1)
            {
                if (int.Parse(Inputstr) > 2)
                {
                    Month = "0" + Inputstr;
                }
                else
                {
                    if ((curStr != "0") && (Inputstr != "0"))
                    {
                        Month = curStr + Inputstr;
                    }
                    else
                    {
                        if ((Inputstr == "1") || (Inputstr == "2"))
                        {
                            Month = curStr + Inputstr;
                        }
                        if ((Inputstr == "0") && (curStr.Trim() == "0"))
                        {

                            return;
                        }
                        else
                        {
                            Month = curStr + Inputstr;

                        }
                    }
                }

            }
            else
            {
                if (int.Parse(Inputstr) > 2)
                {
                    Month = "0" + Inputstr;
                }
                else
                {
                    Month = " " + Inputstr;
                }
            }
            if (MonthBeginIndex == 0)
            {
                curCombo.Text = Month + curCombo.Text.Substring(2);
            }
            else
            {
                string Info = curCombo.Text.Substring(0, MonthBeginIndex) + Month + curCombo.Text.Substring(MonthBeginIndex + 2);
                curCombo.Text = Info;
            }

            if (Month.Trim().Length == 2)
            {
                curCombo.SelectionStart = MonthBeginIndex;
                SetNextDatetype();
                return;
            }

            curCombo.SelectionStart = MonthBeginIndex;
            curCombo.SelectionLength = 2;

        }

        private void OPMonth()
        {
            if (MonthBeginIndex == -1)
            {
                return;
            }
            string Month = curCombo.Text.Substring(MonthBeginIndex, 2).Trim();
            if (Month.Length == 2)
            {
                return;
            }

            if (MonthBeginIndex == 0)
            {
                curCombo.Text = "0" + Month + curCombo.Text.Substring(2);
            }
            else
            {
                string Info = curCombo.Text.Substring(0, MonthBeginIndex) + "0" + Month + curCombo.Text.Substring(MonthBeginIndex + 2);
                curCombo.Text = Info;
            }

        }

        #endregion

        #region 日处理
        private void UpDay()
        {
            if (DateLock)
            {
                return;
            }
            if (DayBeginIndex == -1)
            {
                int curIndex = curCombo.SelectionStart;
                SetSelState(curIndex);
                UpKeyPress();
                return;
            }
            int curDay = DateTime.Parse(curCombo.Text).AddDays(1).Day;

            try
            {
                string TempValue;
                if (DayBeginIndex == 0)
                {
                    TempValue = curDay.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    TempValue = curCombo.Text.Substring(0, DayBeginIndex) + curDay.ToString() + curCombo.Text.Substring(DayBeginIndex + 2);
                }
                DateTime.Parse(TempValue);
            }
            catch
            {
                curDay = 1;
            }

            if (curDay < 10)
            {
                if (DayBeginIndex == 0)
                {
                    curCombo.Text = "0" + curDay.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, DayBeginIndex) + "0" + curDay.ToString() + curCombo.Text.Substring(DayBeginIndex + 2);
                    curCombo.Text = Info;
                }
            }
            else
            {
                if (DayBeginIndex == 0)
                {
                    curCombo.Text = curDay.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, DayBeginIndex) + curDay.ToString() + curCombo.Text.Substring(DayBeginIndex + 2);
                    curCombo.Text = Info;
                }

            }
            curCombo.SelectionStart = DayBeginIndex;
            curCombo.SelectionLength = 2;

        }

        private void DownDay()
        {
            if (DateLock)
            {
                return;
            }
            if (DayBeginIndex == -1)
            {
                int curIndex = curCombo.SelectionStart;
                SetSelState(curIndex);
                DownKeyPress();
                return;
            }
            int curDay = DateTime.Parse(curCombo.Text).AddDays(-1).Day;

            int tempindex = 1;
            while (true)
            {
                string Tempvalue = "";
                try
                {
                    if (DayBeginIndex == 0)
                    {
                        Tempvalue = curDay.ToString() + curCombo.Text.Substring(2);
                    }
                    else
                    {
                        Tempvalue = curCombo.Text.Substring(0, DayBeginIndex) + curDay.ToString() + curCombo.Text.Substring(DayBeginIndex + 2);

                    }
                    DateTime.Parse(Tempvalue);
                    break;
                }
                catch
                {
                    tempindex++;
                    curDay = DateTime.Parse(curCombo.Text).AddDays(-1 * tempindex).Day;
                    continue;
                }
            }


            if (curDay < 10)
            {
                if (DayBeginIndex == 0)
                {
                    curCombo.Text = "0" + curDay.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, DayBeginIndex) + "0" + curDay.ToString() + curCombo.Text.Substring(DayBeginIndex + 2);
                    curCombo.Text = Info;
                }
            }
            else
            {
                if (DayBeginIndex == 0)
                {
                    curCombo.Text = curDay.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, DayBeginIndex) + curDay.ToString() + curCombo.Text.Substring(DayBeginIndex + 2);
                    curCombo.Text = Info;
                }

            }
            curCombo.SelectionStart = DayBeginIndex;
            curCombo.SelectionLength = 2;

        }

        private void InputDay(string Inputstr)
        {
            if (DateLock)
            {
                PublicMethods.WarnMessageBox("日期锁定状态，无法修改日期值");
                return;
            }
            if (DayBeginIndex == -1)
            {
                int curIndex = curCombo.SelectionStart;
                SetSelState(curIndex);
                InputKeyPress(Inputstr);
                return;
            }
            string curStr = curCombo.Text.Substring(DayBeginIndex, 2).Trim();
            string Day = "";
            if (curStr.Length == 2)
            {
                if (int.Parse(Inputstr) > 3)
                {
                    Day = "0" + Inputstr;
                }
                else
                {
                    Day = " " + Inputstr;
                }
            }
            else if (curStr.Length == 1)
            {

                if ((curStr == "3") && (int.Parse(Inputstr) > 1))
                {
                    return;
                }
                else
                {
                    if ((curStr == "0") && (Inputstr == "0"))
                    {
                        return;
                    }
                    Day = curStr + Inputstr;
                }


            }
            else
            {
                if (int.Parse(Inputstr) > 3)
                {
                    Day = "0" + Inputstr;
                }
                else
                {
                    Day = " " + Inputstr;
                }
            }
            if (MonthBeginIndex == 0)
            {
                curCombo.Text = Day + curCombo.Text.Substring(2);
            }
            else
            {
                string Info = curCombo.Text.Substring(0, DayBeginIndex) + Day + curCombo.Text.Substring(DayBeginIndex + 2);
                curCombo.Text = Info;
            }
            if (Day.Trim().Length == 2)
            {
                curCombo.SelectionStart = DayBeginIndex;
                SetNextDatetype();
                return;
            }

            curCombo.SelectionStart = DayBeginIndex;
            curCombo.SelectionLength = 2;

        }

        private void OPDay()
        {
            if (DayBeginIndex == -1)
            {
                return;
            }
            if ((curCombo.Text.EndsWith("00")) && (!FormatStr.EndsWith("00")) && (curCombo.Text.Length <= 10))
            {

                curCombo.Text = curCombo.Text.Substring(0, curCombo.Text.Length - 2) + "01";
            }
            string Day = curCombo.Text.Substring(DayBeginIndex, 2).Trim();
            if (Day.Length == 2)
            {
                return;
            }

            if (DayBeginIndex == 0)
            {
                curCombo.Text = "0" + Day + curCombo.Text.Substring(2);
            }
            else
            {
                string Info = curCombo.Text.Substring(0, DayBeginIndex) + "0" + Day + curCombo.Text.Substring(DayBeginIndex + 2);
                if (Info.EndsWith("00"))
                {
                    curCombo.Text = Info.Substring(0, Info.Length - 2) + "01";
                }
                else
                {
                    curCombo.Text = Info;

                }
            }

        }

        #endregion

        #region 时间处理

        private void UpHour()
        {
            if (HourBeginIndex == -1)
            {
                int curIndex = curCombo.SelectionStart;
                SetSelState(curIndex);
                UpKeyPress();
                return;
            }
            int curHour = DateTime.Now.Hour;
            try
            {
                curHour = int.Parse(curCombo.Text.Substring(HourBeginIndex, 2));
            }
            catch (Exception E)
            {
                PublicMethods.WarnMessageBox(E.Message);
                curHour = DateTime.Now.Hour;
            }
            curHour++;
            if (curHour > 23)
            {
                curHour = 0;
            }
            if (curHour < 10)
            {
                if (HourBeginIndex == 0)
                {
                    curCombo.Text = "0" + curHour.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, HourBeginIndex) + "0" + curHour.ToString() + curCombo.Text.Substring(HourBeginIndex + 2);
                    curCombo.Text = Info;
                }
            }
            else
            {
                if (HourBeginIndex == 0)
                {
                    curCombo.Text = curHour.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, HourBeginIndex) + curHour.ToString() + curCombo.Text.Substring(HourBeginIndex + 2);
                    curCombo.Text = Info;
                }

            }
            curCombo.SelectionStart = HourBeginIndex;
            curCombo.SelectionLength = 2;


        }

        private void DownHour()
        {
            if (HourBeginIndex == -1)
            {
                int curIndex = curCombo.SelectionStart;
                SetSelState(curIndex);
                DownKeyPress();
                return;
            }
            int curHour = DateTime.Now.Hour;
            try
            {
                curHour = int.Parse(curCombo.Text.Substring(HourBeginIndex, 2));
            }
            catch (Exception E)
            {
                PublicMethods.WarnMessageBox(E.Message);
                curHour = DateTime.Now.Hour;
            }
            curHour--;
            if (curHour < 0)
            {
                curHour = 23;
            }
            if (curHour < 10)
            {
                if (HourBeginIndex == 0)
                {
                    curCombo.Text = "0" + curHour.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, HourBeginIndex) + "0" + curHour.ToString() + curCombo.Text.Substring(HourBeginIndex + 2);
                    curCombo.Text = Info;
                }
            }
            else
            {
                if (HourBeginIndex == 0)
                {
                    curCombo.Text = curHour.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, HourBeginIndex) + curHour.ToString() + curCombo.Text.Substring(HourBeginIndex + 2);
                    curCombo.Text = Info;
                }

            }
            curCombo.SelectionStart = HourBeginIndex;
            curCombo.SelectionLength = 2;
        }

        private void InputHour(string Inputstr)
        {
            if (HourBeginIndex == -1)
            {
                int curIndex = curCombo.SelectionStart;
                SetSelState(curIndex);
                InputKeyPress(Inputstr);
                return;
            }
            string curStr = curCombo.Text.Substring(HourBeginIndex, 2).Trim();
            string Hour = "";
            if (curStr.Length == 2)
            {
                if (int.Parse(Inputstr) > 2)
                {
                    Hour = "0" + Inputstr;
                }
                else
                {
                    Hour = " " + Inputstr;
                }
            }
            else if (curStr.Length == 1)
            {
                if ((curStr == "2") && (int.Parse(Inputstr) > 3))
                {
                    Hour = "23";
                }
                else
                {
                    Hour = curStr + Inputstr;

                }

            }
            else
            {
                if (int.Parse(Inputstr) > 2)
                {
                    Hour = "0" + Inputstr;
                }
                else
                {
                    Hour = " " + Inputstr;
                }
            }
            if (HourBeginIndex == 0)
            {
                curCombo.Text = Hour + curCombo.Text.Substring(2);
            }
            else
            {
                string Info = curCombo.Text.Substring(0, HourBeginIndex) + Hour + curCombo.Text.Substring(HourBeginIndex + 2);
                curCombo.Text = Info;
            }
            if (Hour.Trim().Length == 2)
            {
                curCombo.SelectionStart = HourBeginIndex;
                SetNextDatetype();
                return;
            }

            curCombo.SelectionStart = HourBeginIndex;
            curCombo.SelectionLength = 2;

        }

        private void OPHour()
        {
            if (HourBeginIndex == -1)
            {
                return;
            }
            string Hour = curCombo.Text.Substring(HourBeginIndex, 2).Trim();
            if (Hour.Length == 2)
            {
                return;
            }

            if (DayBeginIndex == 0)
            {
                curCombo.Text = "0" + Hour + curCombo.Text.Substring(2);
            }
            else
            {
                string Info = curCombo.Text.Substring(0, HourBeginIndex) + "0" + Hour + curCombo.Text.Substring(HourBeginIndex + 2);
                curCombo.Text = Info;
            }

        }

        #endregion

        #region 分钟处理

        private void UpMiniter()
        {
            if (MinuteBeginIndex == -1)
            {
                int curIndex = curCombo.SelectionStart;
                SetSelState(curIndex);
                UpKeyPress();
                return;
            }
            int curMin = DateTime.Now.Minute;
            try
            {
                curMin = int.Parse(curCombo.Text.Substring(MinuteBeginIndex, 2));
            }
            catch (Exception E)
            {
                PublicMethods.WarnMessageBox(E.Message);
                curMin = DateTime.Now.Minute;
            }
            curMin++;
            if (curMin > 59)
            {
                curMin = 0;
            }
            if (curMin < 10)
            {
                if (MinuteBeginIndex == 0)
                {
                    curCombo.Text = "0" + curMin.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, MinuteBeginIndex) + "0" + curMin.ToString() + curCombo.Text.Substring(MinuteBeginIndex + 2);
                    curCombo.Text = Info;
                }
            }
            else
            {
                if (MinuteBeginIndex == 0)
                {
                    curCombo.Text = curMin.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, MinuteBeginIndex) + curMin.ToString() + curCombo.Text.Substring(MinuteBeginIndex + 2);
                    curCombo.Text = Info;
                }

            }
            curCombo.SelectionStart = MinuteBeginIndex;
            curCombo.SelectionLength = 2;

        }

        private void DownMinute()
        {
            if (MinuteBeginIndex == -1)
            {
                int curIndex = curCombo.SelectionStart;
                SetSelState(curIndex);
                DownKeyPress();
                return;
            }
            int curMin = DateTime.Now.Minute;
            try
            {
                curMin = int.Parse(curCombo.Text.Substring(MinuteBeginIndex, 2));
            }
            catch (Exception E)
            {
                PublicMethods.WarnMessageBox(E.Message);
                curMin = DateTime.Now.Minute;
            }
            curMin--;
            if (curMin < 0)
            {
                curMin = 59;
            }
            if (curMin < 10)
            {
                if (MinuteBeginIndex == 0)
                {
                    curCombo.Text = "0" + curMin.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, MinuteBeginIndex) + "0" + curMin.ToString() + curCombo.Text.Substring(MinuteBeginIndex + 2);
                    curCombo.Text = Info;
                }
            }
            else
            {
                if (MinuteBeginIndex == 0)
                {
                    curCombo.Text = curMin.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, MinuteBeginIndex) + curMin.ToString() + curCombo.Text.Substring(MinuteBeginIndex + 2);
                    curCombo.Text = Info;
                }

            }
            curCombo.SelectionStart = MinuteBeginIndex;
            curCombo.SelectionLength = 2;
        }

        private void InputMinute(string Inputstr)
        {
            if (MinuteBeginIndex == -1)
            {
                int curIndex = curCombo.SelectionStart;
                SetSelState(curIndex);
                InputKeyPress(Inputstr);
                return;
            }
            string curStr = curCombo.Text.Substring(MinuteBeginIndex, 2).Trim();
            string Minute = "";
            if (curStr.Length == 2)
            {
                if (int.Parse(Inputstr) > 5)
                {
                    Minute = "0" + Inputstr;
                }
                else
                {
                    Minute = " " + Inputstr;
                }
            }
            else if (curStr.Length == 1)
            {

                Minute = curStr + Inputstr;
            }
            else
            {
                if (int.Parse(Inputstr) > 5)
                {
                    Minute = "0" + Inputstr;
                }
                else
                {
                    Minute = " " + Inputstr;
                }
            }
            if (MinuteBeginIndex == 0)
            {
                curCombo.Text = Minute + curCombo.Text.Substring(2);
            }
            else
            {
                string Info = curCombo.Text.Substring(0, MinuteBeginIndex) + Minute + curCombo.Text.Substring(MinuteBeginIndex + 2);
                curCombo.Text = Info;
            }

            if (Minute.Trim().Length == 2)
            {
                curCombo.SelectionStart = MinuteBeginIndex;
                SetNextDatetype();
                return;
            }
            curCombo.SelectionStart = MinuteBeginIndex;
            curCombo.SelectionLength = 2;

        }

        private void OPMiniter()
        {
            if (MinuteBeginIndex == -1)
            {
                return;
            }
            string Miniter = curCombo.Text.Substring(MinuteBeginIndex, 2).Trim();
            if (Miniter.Length == 2)
            {
                return;
            }

            if (DayBeginIndex == 0)
            {
                curCombo.Text = "0" + Miniter + curCombo.Text.Substring(2);
            }
            else
            {
                string Info = curCombo.Text.Substring(0, MinuteBeginIndex) + "0" + Miniter + curCombo.Text.Substring(MinuteBeginIndex + 2);
                curCombo.Text = Info;
            }

        }

        #endregion

        #region 秒处理

        private void UpSecond()
        {
            if (SecoudBeginInex == -1)
            {
                int curIndex = curCombo.SelectionStart;
                SetSelState(curIndex);
                UpKeyPress();
                return;
            }
            int curSecond = DateTime.Now.Second;
            try
            {
                curSecond = int.Parse(curCombo.Text.Substring(SecoudBeginInex, 2));
            }
            catch (Exception E)
            {
                PublicMethods.WarnMessageBox(E.Message);
                curSecond = DateTime.Now.Minute;
            }
            curSecond++;
            if (curSecond > 59)
            {
                curSecond = 0;
            }
            if (curSecond < 10)
            {
                if (SecoudBeginInex == 0)
                {
                    curCombo.Text = "0" + curSecond.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, SecoudBeginInex) + "0" + curSecond.ToString() + curCombo.Text.Substring(SecoudBeginInex + 2);
                    curCombo.Text = Info;
                }
            }
            else
            {
                if (SecoudBeginInex == 0)
                {
                    curCombo.Text = curSecond.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, SecoudBeginInex) + curSecond.ToString() + curCombo.Text.Substring(SecoudBeginInex + 2);
                    curCombo.Text = Info;
                }

            }
            curCombo.SelectionStart = SecoudBeginInex;
            curCombo.SelectionLength = 2;

        }

        private void DownSencond()
        {
            if (SecoudBeginInex == -1)
            {
                int curIndex = curCombo.SelectionStart;
                SetSelState(curIndex);
                DownKeyPress();
                return;
            }
            int curSecond = DateTime.Now.Second;
            try
            {
                curSecond = int.Parse(curCombo.Text.Substring(SecoudBeginInex, 2));
            }
            catch (Exception E)
            {
                PublicMethods.WarnMessageBox(E.Message);
                curSecond = DateTime.Now.Minute;
            }
            curSecond--;
            if (curSecond < 0)
            {
                curSecond = 59;
            }
            if (curSecond < 10)
            {
                if (SecoudBeginInex == 0)
                {
                    curCombo.Text = "0" + curSecond.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, SecoudBeginInex) + "0" + curSecond.ToString() + curCombo.Text.Substring(SecoudBeginInex + 2);
                    curCombo.Text = Info;
                }
            }
            else
            {
                if (SecoudBeginInex == 0)
                {
                    curCombo.Text = curSecond.ToString() + curCombo.Text.Substring(2);
                }
                else
                {
                    string Info = curCombo.Text.Substring(0, SecoudBeginInex) + curSecond.ToString() + curCombo.Text.Substring(SecoudBeginInex + 2);
                    curCombo.Text = Info;
                }

            }
            curCombo.SelectionStart = SecoudBeginInex;
            curCombo.SelectionLength = 2;

        }

        private void InputSencond(string Inputstr)
        {
            if (SecoudBeginInex == -1)
            {
                int curIndex = curCombo.SelectionStart;
                SetSelState(curIndex);
                InputKeyPress(Inputstr);
                return;
            }
            string curStr = curCombo.Text.Substring(SecoudBeginInex, 2).Trim();
            string Sencond = "";
            if (curStr.Length == 2)
            {
                if (int.Parse(Inputstr) > 5)
                {
                    Sencond = "0" + Inputstr;
                }
                else
                {
                    Sencond = " " + Inputstr;
                }
            }
            else if (curStr.Length == 1)
            {

                Sencond = curStr + Inputstr;
            }
            else
            {
                if (int.Parse(Inputstr) > 5)
                {
                    Sencond = "0" + Inputstr;
                }
                else
                {
                    Sencond = " " + Inputstr;
                }
            }
            //if (HourBeginIndex == 0)
            //{
            //    curCombo.Text = Sencond + curCombo.Text.Substring(2);
            //}
            //else
            //{
            string Info = curCombo.Text.Substring(0, SecoudBeginInex) + Sencond + curCombo.Text.Substring(SecoudBeginInex + 2);
            curCombo.Text = Info;
            //}

            if (Sencond.Trim().Length == 2)
            {
                curCombo.SelectionStart = SecoudBeginInex;
                SetNextDatetype();
                return;
            }
            curCombo.SelectionStart = SecoudBeginInex;
            curCombo.SelectionLength = 2;

        }

        private void OPSecond()
        {
            if (SecoudBeginInex == -1)
            {
                return;
            }
            string Second = curCombo.Text.Substring(SecoudBeginInex, 2).Trim();
            if (Second.Length == 2)
            {
                return;
            }

            if (DayBeginIndex == 0)
            {
                curCombo.Text = "0" + Second + curCombo.Text.Substring(2);
            }
            else
            {
                string Info = curCombo.Text.Substring(0, SecoudBeginInex) + "0" + Second + curCombo.Text.Substring(SecoudBeginInex + 2);
                curCombo.Text = Info;
            }

        }

        #endregion
    }
}