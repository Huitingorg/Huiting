using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Huiting.Components;

using Huiting.Common;

namespace ReserveComponents
{
    public partial class FrmPjndEdit : FrmChildWithOutMinAndMax
    {
        public string Pjnd
        {
            get
            {
                return uctEvaluationOptions1.Pjnd;
            }
        }

        string proID;
        EvaluationOptionsService eos;

        public FrmPjndEdit()
        {
            InitializeComponent();
        }

        public FrmPjndEdit(string proID)
        {
            InitializeComponent();
            this.proID = proID;
            this.uctEvaluationOptions1.ProID = proID;
        }


        //获取新的预测起始日期
        private DateTime SubGetNewYcqsrq(DataTable dt, DateTime refYcqsrq)
        {
            DateTime dtNew = refYcqsrq.AddMonths(1);
            DataRow[] drAry = dt.Select("startNy='{" + dtNew.ToString("yyyyMM") + "}'");
            if (drAry.Length > 0)
                return SubGetNewYcqsrq(dt, dtNew);
            return dtNew;
        }

        private string GetNewPjnd(DataTable dt)
        {
            List<string> lstPjnd = PublicMethods.GetLstStringByDataTable(dt, "pjnd");
            string pjndTemplate = DateTime.Now.ToString("yyyyMM");
            DataRow[] drAry = dt.Select("pjnd='" + pjndTemplate + "'");
            if (drAry.Length <= 0)
                return pjndTemplate;

            string newPjnd = PublicMethods.CreateNewName(lstPjnd, pjndTemplate + "_");
            return newPjnd;
        }

        private void FrmPjndEdit_Load(object sender, EventArgs e)
        {
            if (eos == null)
                eos = new EvaluationOptionsService();
            DataTable dtData = eos.GetDataTable(proID);

            string newPjnd = GetNewPjnd(dtData);
            DateTime dtNewYcqsrq = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.uctEvaluationOptions1.Init(newPjnd, dtNewYcqsrq);
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            string err = uctEvaluationOptions1.GetWarnString();
            if (string.IsNullOrEmpty(err) == false)
            {
                PublicMethods.WarnMessageBox(this, err);
                return;
            }

            if (eos.ExistPjnd(proID, Pjnd))
            {
                PublicMethods.WarnMessageBox(this, "评价年度已经存在，请重命名！");
                return;
            }

            err = eos.UpdateTable(proID, uctEvaluationOptions1.Pjnd, uctEvaluationOptions1.Ycqsrq, uctEvaluationOptions1.Ycjsrq, uctEvaluationOptions1.Nzxl, uctEvaluationOptions1.Zxrq, uctEvaluationOptions1.Fqcl, uctEvaluationOptions1.QFqcl);
            if (string.IsNullOrEmpty(err) == false)
            {
                PublicMethods.WarnMessageBox(this, "添加评估选项失败：" + err);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}