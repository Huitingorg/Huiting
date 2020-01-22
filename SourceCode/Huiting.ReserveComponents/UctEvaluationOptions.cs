using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReserveCommon;
using Huiting.Common;
using Huiting.DBAccess.Entity.Dtos;

namespace ReserveComponents
{
    public partial class UctEvaluationOptions : UserControl
    {



        EvaluationOptionsDto data;

        public UctEvaluationOptions()
        {
            InitializeComponent();
            txtPjnd.Text = bdStartDate.Text;
        }

        public void InitControl(EvaluationOptionsDto evaluationOptionsDto,bool isAdd=true)
        {
            if (isAdd==false)
                txtPjnd.Enabled = Enabled;

            this.data = evaluationOptionsDto;

            this.bdStartDate.TextChanged -= bdStartDate_TextChanged;
            this.bdEndDate.TextChanged -= bdEndDate_TextChanged;

            this.txtPjnd.Text = data.PJND;
            this.bdStartDate.Text = data.StartNY;
            this.bdEndDate.Text = data.EndNY;
            this.bnbWasteOutput.Text = data.YFQCL.ToString();
            this.bnbQFqcl.Text = data.QFQCL.ToString();
            this.bnbZXL.Text = (data.NZXL * 100).ToString();
            this.bdZxrq.Text = data.ZXNY;

            this.bdEndDate.TextChanged += bdEndDate_TextChanged;
            this.bdStartDate.TextChanged += bdStartDate_TextChanged;
        }

        public EvaluationOptionsDto GetData()
        {
            data.PJND = txtPjnd.Text.Trim();
            data.StartNY = bdStartDate.Text.Trim();
            data.EndNY = bdEndDate.Text.Trim();
            data.YFQCL = bnbWasteOutput.Value.ToDouble();
            data.QFQCL = bnbQFqcl.Value.ToDouble();
            data.NZXL = bnbZXL.Value.ToDouble();
            data.ZXNY = bdZxrq.Text.Trim();

            return data;
        }


        public void Check(Action action)
        {
            if (string.IsNullOrWhiteSpace(txtPjnd.Text))
            {
                PublicMethods.WarnMessageBox(this, "评价年度不能为空！");
                if (action != null)
                    action();
                txtPjnd.Focus();
            }

            if (string.IsNullOrWhiteSpace(bnbWasteOutput.Text))
            {
                PublicMethods.WarnMessageBox(this, "油废弃产量不能为空！");
                if (action != null)
                    action();
                bnbWasteOutput.Focus();
            }

            if (string.IsNullOrWhiteSpace(bnbQFqcl.Text))
            {
                PublicMethods.WarnMessageBox(this, "气废弃产量不能为空！");
                if (action != null)
                    action();
                bnbQFqcl.Focus();
            }

            if (string.IsNullOrWhiteSpace(bnbZXL.Text))
            {
                PublicMethods.WarnMessageBox(this, "年折现率不能为空！");
                if (action != null)
                    action();
                bnbZXL.Focus();
            }

            if (string.IsNullOrWhiteSpace(bdZxrq.Text))
            {
                PublicMethods.WarnMessageBox(this, "年折日期不能为空！");
                if (action != null)
                    action();
                bdZxrq.Focus();
            }

            if (string.IsNullOrWhiteSpace(bdStartDate.Text))
            {
                PublicMethods.WarnMessageBox(this, "预测起始日期不能为空！");
                if (action != null)
                    action();
                bdStartDate.Focus();
            }

            if (string.IsNullOrWhiteSpace(bdEndDate.Text))
            {
                PublicMethods.WarnMessageBox(this, "预测结束日期不能为空！");
                if (action != null)
                    action();
                bdEndDate.Focus();
            }
        }

        void bdStartDate_TextChanged(object sender, EventArgs e)
        {
            DateTime ycqsrq = bdStartDate.Text.ToDateTime();
            Init2(ycqsrq);

            bdEndDate_TextChanged(null, null);
        }

        void bdEndDate_TextChanged(object sender, EventArgs e)
        {
            DateTime dtS = bdStartDate.Text.ToDateTime();
            DateTime dtE = bdEndDate.Text.ToDateTime();

            int monthCount = PublicMethods.GetMonthDiff(dtE, dtS) + 1;
            if (monthCount % 12 == 0)
                label12.Text = "* 共计" + monthCount / 12 + "年";
            else
                label12.Text = "* 共计" + monthCount / 12 + "年" + monthCount % 12 + "月";

            //label12.Text
        }


        private void Init2(DateTime ycqsrq)
        {
            //EvaluationOptionsService evalOptionService = new EvaluationOptionsService();
            //DataTable dtDictPjnd = evalOptionService.GetDictPjnd(proID);
            //List<string> lstPjnd = PublicMethods.GetLstStringByDataTable(dtDictPjnd, "pjnd");
            //string strPjnd = ycqsrq.ToString("yyyyMM");
            //if (lstPjnd.Contains(strPjnd))
            //    strPjnd = PublicMethods.CreateNewName(lstPjnd, strPjnd + "_");

            //this.txtPjnd.Text = strPjnd;
            //this.bdEndDate.Text = ycqsrq.AddMonths(DefaultConfig.Instance.EvaluationOptions.LimitedTime * 12 - 1).ToString("yyyyMM");
            //this.bnbWasteOutput.Text = DefaultConfig.Instance.EvaluationOptions.Fqcl.ToString();
            //this.bnbZXL.Text = (DefaultConfig.Instance.EvaluationOptions.Nzxl * 100).ToString();
            //this.bdZxrq.Text = ycqsrq.AddMonths(-1).ToString("yyyyMM");
        }
    }
}