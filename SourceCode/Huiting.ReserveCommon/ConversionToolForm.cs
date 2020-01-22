using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BDControl
{
    public partial class ConversionToolForm : Form
    {
        OpConfigFileClass opconfigFile = null;
        string ConfigFilePath = "";
        string curCLEditControlName = "";
        string curTJEditControlName = "";
        string curHBEditControlName = "";
        bool IsLoadingUI = true;
        public ConversionToolForm()
        {
            InitializeComponent();
            ConfigFilePath = Application.StartupPath + "\\Temp\\";
            MyMethod.CheckDectoryExists(ConfigFilePath);
            ConfigFilePath += "ConverToolConfig.bd";
            opconfigFile = new OpConfigFileClass(ConfigFilePath);
            Init();
        }

        private void Init()
        {
            string TempValue = opconfigFile.GetConfigItem("YYMD");
            if(!string.IsNullOrEmpty(TempValue))
                text_MD.Text = TempValue;
            TempValue = opconfigFile.GetConfigItem("TJXS");
            if (!string.IsNullOrEmpty(TempValue))
                text_TJ_XS.Text = TempValue;
            TempValue = opconfigFile.GetConfigItem("RMBHL");
            if (!string.IsNullOrEmpty(TempValue))
                text_HL.Text = TempValue;
            //opconfigFile.SetConfigItem("RMBHL", text_HL.Text);

        }

        #region 产量相关转换
        private void text_CL_D_TextChanged(object sender, EventArgs e)
        {
            if(((TextBox)sender).Name != curCLEditControlName)
            {
                return;
            }
            double TempValue = 0;
            double curValue = 0;
            if (string.IsNullOrEmpty(text_CL_D.Text))
            {
                text_CL_D.Text = "";
                text_CL_WD.Text = "";
                text_CL_T.Text = "";
                text_CL_KT.Text = "";
            }

            try
            {
                curValue = double.Parse(text_CL_D.Text);

            }
            catch
            {
                return;
            }
            TempValue = curValue / 10000;
            text_CL_WD.Text = TempValue.ToString();
            TempValue = (curValue * 6.2898) / (double.Parse(text_MD.Text));
            text_CL_T.Text = TempValue.ToString();
            text_CL_KT.Text = (TempValue / 1000).ToString();

        }

        private void text_CL_WD_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name != curCLEditControlName)
            {
                return;
            }
            double TempValue = 0;
            if (string.IsNullOrEmpty(text_CL_WD.Text))
            {
                text_CL_D.Text = "";
                text_CL_WD.Text = "";
                text_CL_T.Text = "";
                text_CL_KT.Text = "";
            }
            double curValue = 0;
            try
            {
                curValue = double.Parse(text_CL_WD.Text);

            }
            catch
            {
                return;
            }

            TempValue = curValue * 10000;
            text_CL_D.Text = TempValue.ToString();
            //text_CL_WD.Text = TempValue.ToString();
            TempValue = (TempValue * 6.2898) / (double.Parse(text_MD.Text));
            text_CL_T.Text = TempValue.ToString();
            text_CL_KT.Text = (TempValue / 1000).ToString();
        }

        private void text_CL_T_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name != curCLEditControlName)
            {
                return;
            }
            double TempValue = 0;
            double curValue = 0;
            if (string.IsNullOrEmpty(text_CL_T.Text))
            {
                text_CL_D.Text = "";
                text_CL_WD.Text = "";
                text_CL_T.Text = "";
                text_CL_KT.Text = "";
            }
            try
            {
                curValue = double.Parse(text_CL_T.Text);

            }
            catch
            {
                return;
            }
            text_CL_KT.Text = (curValue / 1000).ToString();
            double d_MD = double.Parse(text_MD.Text);
            TempValue = curValue * d_MD/6.2898;
            text_CL_D.Text = TempValue.ToString();
            text_CL_WD.Text = (TempValue/10000).ToString();
            
            //text_CL_T.Text = TempValue.ToString();
            //text_CL_KT.Text = (TempValue / 1000).ToString();
        }

        private void text_CL_KT_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name != curCLEditControlName)
            {
                return;
            }
            double curValue = 0;
            double d_MD = double.Parse(text_MD.Text);
            if (string.IsNullOrEmpty(text_CL_KT.Text))
            {
                text_CL_D.Text = "";
                text_CL_WD.Text = "";
                text_CL_T.Text = "";
                text_CL_KT.Text = "";
            }
            try
            {
                curValue = double.Parse(text_CL_KT.Text);

            }
            catch
            {
                return;
            }
            double TempValue = curValue*1000;
            text_CL_T.Text = TempValue.ToString();
            TempValue = TempValue * d_MD / 6.2898;
            text_CL_D.Text = TempValue.ToString();
            text_CL_WD.Text = (TempValue / 10000).ToString();

            
        }

        private void text_CL_D_Enter(object sender, EventArgs e)
        {
            curCLEditControlName = ((TextBox)sender).Name;
            SetControlBackColor(tabPage_CL);
            ((TextBox)sender).BackColor = System.Drawing.Color.PaleGreen; ;
        }

        private void SetControlBackColor(Control ParentControl)
        {
            foreach(Control curControl in ParentControl.Controls)
            {
                curControl.BackColor = Color.White;
            }
        }

        private void text_MD_TextChanged(object sender, EventArgs e)
        {
            if(IsLoadingUI)
            {
                return;
            }
            if((string.IsNullOrEmpty(text_MD.Text))||(text_MD.Text.Trim() == "0"))
            {
                //text_CL_T.Text = "";
                //text_CL_WD.Text = "";
                return;
            }
            switch(curCLEditControlName)
            {
                case "text_CL_D":
                    text_CL_D_TextChanged(text_CL_D, null);
                    break;
                case "text_CL_WD":
                    text_CL_WD_TextChanged(text_CL_WD, null);
                    break;
                case "text_CL_T":
                    text_CL_T_TextChanged(text_CL_T, null);
                    break;
                case "text_CL_KT":
                    text_CL_KT_TextChanged(text_CL_KT, null);
                    break;
                default:
                    break;


            }
            //double TempValue = 0;
            //double curValue = 0;
            //curValue = double.Parse(text_CL_D.Text);
            //TempValue = (curValue * 6.2898) / (double.Parse(text_MD.Text));
            //text_CL_T.Text = TempValue.ToString();
            //text_CL_KT.Text = (TempValue / 1000).ToString();

        }
        private void text_MD_Leave(object sender, EventArgs e)
        {
            opconfigFile.SetConfigItem("YYMD", text_MD.Text);
            
        }

        #endregion

        #region 体积相关转换

        private void text_TJ_F_Enter(object sender, EventArgs e)
        {
            curTJEditControlName = ((TextBox)sender).Name;

            SetControlBackColor(tabPage_TJ);
            ((TextBox)sender).BackColor = System.Drawing.Color.PaleGreen; ;
        }

        private void text_TJ_F_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name != curTJEditControlName)
            {
                return;
            }
            double TempValue = 0;
            double curValue = 0;
            double XS = double.Parse(text_TJ_XS.Text);
            if (string.IsNullOrEmpty(text_TJ_F.Text))
            {
                text_TJ_F.Text = "";
                text_TJ_WF.Text = "";
                text_TJ_MCF.Text = "";
                text_TJ_YC.Text = "";
            }

            try
            {
                curValue = double.Parse(text_TJ_F.Text);

            }
            catch
            {
                return;
            }

            text_TJ_WF.Text = (curValue / 10000).ToString();
            TempValue = curValue * XS;

            text_TJ_YC.Text = TempValue.ToString();
            text_TJ_MCF.Text = (TempValue / 1000).ToString();
        }

        private void ConversionToolForm_Shown(object sender, EventArgs e)
        {
            IsLoadingUI = false;
        }

        private void text_TJ_XS_Leave(object sender, EventArgs e)
        {
            opconfigFile.SetConfigItem("TJXS", text_TJ_XS.Text);
        }

        private void text_TJ_XS_TextChanged(object sender, EventArgs e)
        {
            if(IsLoadingUI)
            {
                return;
            }
            if ((string.IsNullOrEmpty(text_TJ_XS.Text)) || (text_TJ_XS.Text.Trim() == "0"))
            {
                //text_TJ_YC.Text = "";
                //text_TJ_MCF.Text = "";
                return;
            }

            switch (curTJEditControlName)
            {
                case "text_TJ_F":
                    text_TJ_F_TextChanged(text_TJ_F, null);
                    break;
                case "text_TJ_WF":
                    text_TJ_WF_TextChanged(text_TJ_WF, null);
                    break;
                case "text_TJ_YC":
                    text_TJ_YC_TextChanged(text_TJ_YC, null);
                    break;
                case "text_TJ_MCF":
                    text_TJ_MCF_TextChanged(text_TJ_MCF, null);
                    break;
                default:
                    break;


            }

            //double TempValue = 0;
            //double curValue = 0;
            //double XS = double.Parse(text_TJ_XS.Text);

            //if (string.IsNullOrEmpty(text_TJ_F.Text))
            //{
            //    return;
            //}
            //curValue = double.Parse(text_TJ_F.Text);

            //TempValue = curValue * XS;

            //text_TJ_YC.Text = TempValue.ToString();
            //text_TJ_MCF.Text = (TempValue / 1000).ToString();
        }

        private void text_TJ_WF_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name != curTJEditControlName)
            {
                return;
            }
            double TempValue = 0;
            double curValue = 0;
            double XS = double.Parse(text_TJ_XS.Text);
            if (string.IsNullOrEmpty(text_TJ_WF.Text))
            {
                text_TJ_F.Text = "";
                text_TJ_WF.Text = "";
                text_TJ_MCF.Text = "";
                text_TJ_YC.Text = "";
            }

            try
            {
                curValue = double.Parse(text_TJ_WF.Text);

            }
            catch
            {
                return;
            }
            TempValue =  curValue * 10000;
            text_TJ_F.Text = TempValue.ToString();

            //text_TJ_WF.Text = (curValue / 1000).ToString();
            TempValue = TempValue * XS;

            text_TJ_YC.Text = TempValue.ToString();
            text_TJ_MCF.Text = (TempValue / 1000).ToString();
        }

        private void text_TJ_YC_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name != curTJEditControlName)
            {
                return;
            }
            double TempValue = 0;
            double curValue = 0;
            double XS = double.Parse(text_TJ_XS.Text);
            if (string.IsNullOrEmpty(text_TJ_YC.Text))
            {
                text_TJ_F.Text = "";
                text_TJ_WF.Text = "";
                text_TJ_MCF.Text = "";
                text_TJ_YC.Text = "";
            }

            try
            {
                curValue = double.Parse(text_TJ_YC.Text);

            }
            catch
            {
                return;
            }
            TempValue = curValue /XS;

            text_TJ_F.Text = TempValue.ToString();

            text_TJ_WF.Text = (TempValue / 10000).ToString();
            

            //text_TJ_YC.Text = TempValue.ToString();
            text_TJ_MCF.Text = (curValue / 1000).ToString();
        }

        private void text_TJ_MCF_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name != curTJEditControlName)
            {
                return;
            }
            double TempValue = 0;
            double curValue = 0;
            double XS = double.Parse(text_TJ_XS.Text);
            if (string.IsNullOrEmpty(text_TJ_MCF.Text))
            {
                text_TJ_F.Text = "";
                text_TJ_WF.Text = "";
                text_TJ_MCF.Text = "";
                text_TJ_YC.Text = "";
            }

            try
            {
                curValue = double.Parse(text_TJ_MCF.Text);

            }
            catch
            {
                return;
            }
            TempValue = curValue*1000;
            text_TJ_YC.Text = TempValue.ToString();


            TempValue = TempValue / XS;

            text_TJ_F.Text = TempValue.ToString();

            text_TJ_WF.Text = (TempValue / 10000).ToString();
        }

        private void btn_TJ_DefaultValue_Click(object sender, EventArgs e)
        {
            text_TJ_XS.Text = "35.3147248";
        }

        #endregion

        private void text_HB_RY_Enter(object sender, EventArgs e)
        {
            curHBEditControlName = ((TextBox)sender).Name;

            SetControlBackColor(tabPage_HB);
            ((TextBox)sender).BackColor = System.Drawing.Color.PaleGreen; ;
        }

        private void text_HB_RY_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name != curHBEditControlName)
            {
                return;
            }
            double TempValue = 0;
            double curValue = 0;
            double XS = double.Parse(text_HL.Text);
            if (string.IsNullOrEmpty(text_HB_RY.Text))
            {
                text_HB_RY.Text = "";
                text_HB_RWY.Text = "";
                text_HB_MY.Text = "";
                text_HB_MWY.Text = "";
            }

            try
            {
                curValue = double.Parse(text_HB_RY.Text);

            }
            catch
            {
                return;
            }
            TempValue = curValue / 10000;
            text_HB_RWY.Text = TempValue.ToString();
            TempValue = curValue/XS;
            text_HB_MY.Text = TempValue.ToString();
            text_HB_MWY.Text = (TempValue/10000).ToString();
        }

        private void text_HB_RWY_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name != curHBEditControlName)
            {
                return;
            }
            double TempValue = 0;
            double curValue = 0;
            double XS = double.Parse(text_HL.Text);
            if (string.IsNullOrEmpty(text_HB_RWY.Text))
            {
                text_HB_RY.Text = "";
                text_HB_RWY.Text = "";
                text_HB_MY.Text = "";
                text_HB_MWY.Text = "";
            }

            try
            {
                curValue = double.Parse(text_HB_RWY.Text);

            }
            catch
            {
                return;
            }
            TempValue = curValue * 10000;
            text_HB_RY.Text = TempValue.ToString();
            TempValue = TempValue / XS;
            text_HB_MY.Text = TempValue.ToString();
            text_HB_MWY.Text = (TempValue / 10000).ToString();
        }

        private void text_HB_MY_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name != curHBEditControlName)
            {
                return;
            }
            double TempValue = 0;
            double curValue = 0;
            double XS = double.Parse(text_HL.Text);
            if (string.IsNullOrEmpty(text_HB_MY.Text))
            {
                text_HB_RY.Text = "";
                text_HB_RWY.Text = "";
                text_HB_MY.Text = "";
                text_HB_MWY.Text = "";
            }

            try
            {
                curValue = double.Parse(text_HB_MY.Text);

            }
            catch
            {
                return;
            }
            text_HB_MWY.Text = (curValue / 10000).ToString();

            TempValue = curValue *XS;
            text_HB_RY.Text = TempValue.ToString();
            text_HB_RWY.Text = (TempValue / 10000).ToString();
            
        }

        private void text_HB_MWY_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name != curHBEditControlName)
            {
                return;
            }
            double TempValue = 0;
            double curValue = 0;
            double XS = double.Parse(text_HL.Text);
            if (string.IsNullOrEmpty(text_HB_MWY.Text))
            {
                text_HB_RY.Text = "";
                text_HB_RWY.Text = "";
                text_HB_MY.Text = "";
                text_HB_MWY.Text = "";
            }

            try
            {
                curValue = double.Parse(text_HB_MWY.Text);

            }
            catch
            {
                return;
            }
            TempValue = curValue * 10000;
            text_HB_MY.Text = TempValue.ToString();

            TempValue = TempValue * XS;
            text_HB_RY.Text = TempValue.ToString();
            text_HB_RWY.Text = (TempValue / 10000).ToString();
        }

        private void text_HL_TextChanged(object sender, EventArgs e)
        {
            if (IsLoadingUI)
            {
                return;
            }
            if ((string.IsNullOrEmpty(text_HL.Text)) || (text_HL.Text.Trim() == "0"))
            {
                //text_HB_MY.Text = "";
                //text_HB_MWY.Text = "";
                return;
            }
            switch (curHBEditControlName)
            {
                case "text_HB_RY":
                    text_HB_RY_TextChanged(text_HB_RY, null);
                    break;
                case "text_HB_RWY":
                    text_HB_RWY_TextChanged(text_HB_RWY, null);
                    break;
                case "text_HB_MY":
                    text_HB_MY_TextChanged(text_HB_MY, null);
                    break;
                case "text_HB_MWY":
                    text_HB_MWY_TextChanged(text_HB_MWY, null);
                    break;
                default:
                    break;


            }

            //double TempValue = 0;
            //double curValue = 0;
            //double XS = double.Parse(text_HL.Text);


            //try
            //{
            //    curValue = double.Parse(text_HB_RY.Text);

            //}
            //catch
            //{
            //    return;
            //}
           
            //TempValue = curValue / XS;
            //text_HB_MY.Text = TempValue.ToString();
            //text_HB_MWY.Text = (TempValue / 10000).ToString();
        }

        private void text_HL_Leave(object sender, EventArgs e)
        {
            opconfigFile.SetConfigItem("RMBHL", text_HL.Text);
        }


    }
}
