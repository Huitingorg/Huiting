using Huiting.Common;
using ReserveCommon;
using System;
using System.Windows.Forms;

namespace ReserveAnalysis
{
    public partial class FrmDefaultValue : Form
    {
        public FrmDefaultValue()
        {
            InitializeComponent();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            //更新评估选项表
            DefaultConfig.Instance.EvaluationOptions.Nzxl = bdnZXL.Value.ToDouble() / 100;
            DefaultConfig.Instance.EvaluationOptions.YFqcl = bdnWasteOutput.Value.ToDouble();
            DefaultConfig.Instance.EvaluationOptions.LimitedTime = bdnLimitedTime.Value.ToInt();

            //更新参数表
            DefaultConfig.Instance.EconomicParams.Yzzsl = bdnYzzsl.Value.ToDouble();
            DefaultConfig.Instance.EconomicParams.Qzzsl = bdnQzzsl.Value.ToDouble();
            DefaultConfig.Instance.EconomicParams.Zysl = bdnZysl.Value.ToDouble();
            DefaultConfig.Instance.EconomicParams.Qt = bdnQt.Value.ToDouble();
            DefaultConfig.Instance.EconomicParams.Hl = bdnHl.Value.ToDouble();

            //气油比
            DefaultConfig.Instance.QybDefault.MonthsCount = bdQybMonthsCount.Value.ToDouble();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void FrmDefaultValue_Load(object sender, EventArgs e)
        {
            //更新评估选项表
            bdnZXL.Text = (DefaultConfig.Instance.EvaluationOptions.Nzxl * 100).ToString();
            bdnWasteOutput.Text = DefaultConfig.Instance.EvaluationOptions.YFqcl.ToString();
            bdnLimitedTime.Text = DefaultConfig.Instance.EvaluationOptions.LimitedTime.ToString();

            //更新参数表
            bdnYzzsl.Text = DefaultConfig.Instance.EconomicParams.Yzzsl.ToString();
            bdnQzzsl.Text = DefaultConfig.Instance.EconomicParams.Qzzsl.ToString();
            bdnZysl.Text = DefaultConfig.Instance.EconomicParams.Zysl.ToString();
            bdnQt.Text = DefaultConfig.Instance.EconomicParams.Qt.ToString();
            bdnHl.Text = DefaultConfig.Instance.EconomicParams.Hl.ToString();

            //气油比
            bdQybMonthsCount.Text = DefaultConfig.Instance.QybDefault.MonthsCount.ToString();
        }
    }
}