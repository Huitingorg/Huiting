using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BDSoft.Components
{
    public partial class UC_YearMonthSel : UserControl
    {
        public string Value
        {
            get
            {
                if (panel_Month.Tag.ToString().Length == 2)
                {
                    return panel_Year.Tag.ToString() + panel_Month.Tag.ToString();

                }
                else
                {
                    return panel_Year.Tag.ToString() + "0" + panel_Month.Tag.ToString();
                }
            }
            set
            {
                string Year = "";
                string Month = "";
                if (value.Length == 6)
                {
                    Year = value.Substring(0, 4);
                    Month = value.Substring(4, 2);
                }
                else
                {
                    Year = DateTime.Now.Year.ToString();
                    Month = DateTime.Now.Month.ToString();
                }
                if (Month.StartsWith("0"))
                {
                    Month = Month.Substring(1);
                }
                panel_Year.Tag = Year;
                panel_Month.Tag = Month;

                label_SelYear.Text = Year + "年";
                label_SelMonth.Text = Month + "月";
                //}
                //else
                //{
                //    MessageBox.Show(this, "年月录入格式错误！", "错误");
                //}

                SetYear(Year);
                SetMonth(Month);

            }
        }

        public UC_YearMonthSel()
        {
            InitializeComponent();
            textBox_Focus.Width = 0;
        }

        private void panel_NextMonth_Click(object sender, EventArgs e)
        {
           
        }

        private void panel_PreMonth_Click(object sender, EventArgs e)
        {
           
        }

        private void SetMonth(string Month)
        {
            try
            {
                SetMonth(int.Parse(Month));
            }
            catch
            { }
        }

        private void SetMonth(int Month)
        {
            //设置当前月
            if(Month>=10)
                label_SelMonth.Text = Month.ToString() + "月";
            else
                label_SelMonth.Text = "0" + Month.ToString() + "月";
            panel_Month.Tag = Month;

            //设置下一月
            int NextMonth = Month + 1;
            if(NextMonth>12)
            {
                NextMonth = 1;
            }
            if (NextMonth >= 10)
                label_NextMonth.Text = NextMonth.ToString() + "月";
            else
                label_NextMonth.Text = "0" + NextMonth.ToString() + "月";

            //设置上一月
            int PreMonth = Month - 1;
            if (PreMonth <=0)
            {
                PreMonth = 12;
            }
            if (PreMonth >= 10)
                label_PreMonth.Text = PreMonth.ToString() + "月";
            else
                label_PreMonth.Text = "0" + PreMonth.ToString() + "月";
        }

        private void panel_NextYear_Click(object sender, EventArgs e)
        {
            

        }

        private void panel_PreYear_Click(object sender, EventArgs e)
        {
            
        }
       
        private void SetYear(string Year)
        {
            try
            {
                SetYear(int.Parse(Year));
            }
            catch
            {

            }
        }

        private void SetYear(int Year)
        {
            //设置当前年
            label_SelYear.Text = Year.ToString() + "年";

            panel_Year.Tag = Year;

            //设置下一年
            int NextMonth = Year + 1;

            label_NextYear.Text = NextMonth.ToString() + "年";

            //设置上一年
            int PreYear = Year - 1;

            label_PreYear.Text = PreYear.ToString() + "月";
        }

        private void panel_Month_MouseEnter(object sender, EventArgs e)
        {
            panel_PreMonth.BackgroundImage = imageList1.Images[0];
            label_PreMonth.Visible = false;

            panel_NextMonth.BackgroundImage = imageList1.Images[1];
            label_NextMonth.Visible = false;
        }

        private void panel_Month_MouseLeave(object sender, EventArgs e)
        {
            panel_PreMonth.BackgroundImage = null;
            label_PreMonth.Visible = true;

            panel_NextMonth.BackgroundImage = null;
            label_NextMonth.Visible = true;
        }

        private void panel_NextMonth_MouseEnter(object sender, EventArgs e)
        {
            panel_NextMonth.BackgroundImage = imageList1.Images[1];
            label_NextMonth.Visible = false;
        }

        private void panel_NextMonth_MouseLeave(object sender, EventArgs e)
        {
            panel_NextMonth.BackgroundImage = null;
            label_NextMonth.Visible = true;
        }

        private void panel_PreMonth_MouseEnter(object sender, EventArgs e)
        {
            panel_PreMonth.BackgroundImage = imageList1.Images[0];
            label_PreMonth.Visible = false;
        }

        private void panel_PreMonth_MouseLeave(object sender, EventArgs e)
        {
            panel_PreMonth.BackgroundImage = null;
            label_PreMonth.Visible = true;
        }

        private void panel_Year_MouseEnter(object sender, EventArgs e)
        {
            panel_PreYear.BackgroundImage = imageList1.Images[0];
            label_PreYear.Visible = false;

            panel_NextYear.BackgroundImage = imageList1.Images[1];
            label_NextYear.Visible = false;
        }

        private void panel_Year_MouseLeave(object sender, EventArgs e)
        {
            panel_PreYear.BackgroundImage = null;
            label_PreYear.Visible = true;

            panel_NextYear.BackgroundImage = null;
            label_NextYear.Visible = true;
        }

        private void panel_PreYear_MouseEnter(object sender, EventArgs e)
        {
            panel_PreYear.BackgroundImage = imageList1.Images[0];
            label_PreYear.Visible = false;
        }

        private void panel_PreYear_MouseLeave(object sender, EventArgs e)
        {
            panel_PreYear.BackgroundImage = null;
            label_PreYear.Visible = true;
        }

        private void panel_NextYear_MouseEnter(object sender, EventArgs e)
        {
            panel_NextYear.BackgroundImage = imageList1.Images[1];
            label_NextYear.Visible = false;
        }

        private void panel_NextYear_MouseLeave(object sender, EventArgs e)
        {
            panel_NextYear.BackgroundImage = null;
            label_NextYear.Visible = true;
        }

        #region 暂时不用

        Panel curShowPicPanel = null;
        Panel curClosePicPanel = null;

        private void ShowControlPic(Panel curPanel)
        {
            curShowPicPanel = curPanel;
            timer_ShowPic.Enabled = true;
        }

        private void CloseControlPic(Panel curPanel)
        {
            curClosePicPanel = curPanel;
            timer_ClosePic.Enabled = true;
        }

        private void timer_ShowPic_Tick(object sender, EventArgs e)
        {
            timer_ShowPic.Enabled = false;



        }

        private void timer_ClosePic_Tick(object sender, EventArgs e)
        {
            timer_ClosePic.Enabled = false;
        }

        #endregion

        private void btn_Today_Click(object sender, EventArgs e)
        {
            int Year = DateTime.Now.Year;
            int Month = DateTime.Now.Month;
            SetYear(Year);
            SetMonth(Month);
            SendKeys.Send("{ESC}");
        }

        private void timer_focus_Tick(object sender, EventArgs e)
        {
            timer_focus.Enabled = false;
            this.ActiveControl = btn_Today;
            textBox_Focus.Focus();
        }

        private void panel_NextMonth_MouseDown(object sender, MouseEventArgs e)
        {
            int Month = int.Parse(panel_Month.Tag.ToString());
            Month++;
            if (Month > 12)
            {
                Month = 1;
            }

            SetMonth(Month);
        }

        private void panel_PreMonth_MouseDown(object sender, MouseEventArgs e)
        {
            int Month = int.Parse(panel_Month.Tag.ToString());
            Month--;
            if (Month <= 0)
            {
                Month = 12;
            }

            SetMonth(Month);
        }

        private void panel_PreYear_MouseDown(object sender, MouseEventArgs e)
        {
            int Year = int.Parse(panel_Year.Tag.ToString());
            Year--;


            SetYear(Year);
        }

        private void panel_NextYear_MouseDown(object sender, MouseEventArgs e)
        {
            int Year = int.Parse(panel_Year.Tag.ToString());
            Year++;


            SetYear(Year);
        }

        private void panel_Year_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{ESC}");
        }
    }
}
