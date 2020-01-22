using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Huiting.Components
{
    public partial class UctStatusBar : UserControl
    {
        DataGridView dgv;

        public DataGridView DataGridView
        {
            get { return dgv; }
            set
            {
                if (dgv == value)
                    return;
                dgv = value;
                if (dgv == null)
                    return;
                dgv.SelectionChanged -= dgv_SelectionChanged;
                dgv.SelectionChanged += dgv_SelectionChanged;
                dgv.DataSourceChanged -= dgv_DataSourceChanged;
                dgv.DataSourceChanged += dgv_DataSourceChanged;
            }
        }

        void dgv_DataSourceChanged(object sender, EventArgs e)
        {
            dgv_SelectionChanged(sender, e);
        }

        bool isCounter = false;
        [Description("计数")]
        public bool IsCounter
        {
            get
            {
                return isCounter;
            }
            set
            {
                isCounter = value;
                tsslCount.Visible = value;
            }
        }

        bool isSum = false;
        [Description("求和")]
        public bool IsSum
        {
            get
            {
                return isSum;
            }
            set
            {
                isSum = value;
                tsslSum.Visible = value;
            }
        }

        bool isAvg = false;
        [Description("平均值")]
        public bool IsAvg
        {
            get
            {
                return isAvg;
            }
            set
            {
                isAvg = value;
                tssLAvg.Visible = value;
            }
        }

        bool isRowsCount = false;
        [Description("行数")]
        public bool IsRowsCount
        {
            get
            {
                return isRowsCount;
            }
            set
            {
                isRowsCount = value;
                tssRowsCount.Visible = value;
            }
        }

        bool isSelectedRowsCount = false;
        [Description("选中的行数")]
        public bool IsSelectedRowsCount
        {
            get
            {
                return isSelectedRowsCount;
            }
            set
            {
                isSelectedRowsCount = value;
                tssSelectedRowsCount.Visible = value;
            }
        }

        private int decimalPlace = 5;

        public int DecimalPlace
        {
            get { return decimalPlace; }
            set { decimalPlace = value; }
        }

        bool fixDecimalPlace = false;

        public bool FixDecimalPlace
        {
            get { return fixDecimalPlace; }
            set { fixDecimalPlace = value; }
        }

        public UctStatusBar()
        {
            InitializeComponent();
            this.Height = this.statusStrip1.Height;
            this.Dock = DockStyle.Bottom;

            foreach (ToolStripItem item in statusStrip1.Items)
            {
                ToolStripStatusLabel tsl = item as ToolStripStatusLabel;
                if (tsl == null)
                    continue;
                tsl.Text = "";
            }
        }

        void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedCells == null || dgv.SelectedCells.Count <= 0)
            {
                tssLAvg.Text = "";
                tsslCount.Text = "";
                tsslSum.Text = "";
                return;
            }

            int? counter;
            double? avg;
            double? sum;
            int? decPlace;
            this.Calc(dgv.SelectedCells, out counter, out avg, out sum, out decPlace);
            this.tsslCount.Text = "计数：" + counter.ToString();
            if (dgv.SelectedCells.Count <= 0)
                return;
            
            string format;
            //是否固定小数位数
            if (fixDecimalPlace)
                format = "f" + decimalPlace;
            else
                format = "f" + decPlace;

            if (sum != null)
                this.tsslSum.Text = "求和：" + sum.Value.ToString(format);
            if (avg != null)
                this.tssLAvg.Text = "平均值：" + avg.Value.ToString(format);

            DataTable dt = dgv.DataSource as DataTable;
            if (dt == null)
            {
                BindingSource bds = dgv.DataSource as BindingSource;
                if (bds == null)
                    return;
                dt = bds.DataSource as DataTable;
            }
            this.tssRowsCount.Text = "总行数：" + dt.Rows.Count;
            this.tssSelectedRowsCount.Text = "选中行数：" + dgv.SelectedRows.Count;
        }

        private void Calc(DataGridViewSelectedCellCollection SelectedCells, out int? counter, out double? avg, out double? sum, out int? decimalPlace)
        {
            counter = 0;
            avg = null;
            sum = null;
            decimalPlace = 0;

            if (SelectedCells == null || SelectedCells.Count <= 0)
                return;

            List<double> lstValues = new List<double>();
            counter = SelectedCells.Count;
            bool haveDecimalPlace = false;
            foreach (DataGridViewCell item in SelectedCells)
            {
                if (item.Value == null)
                    continue;
                double temp;
                if (double.TryParse(item.Value.ToString(), out temp))
                    lstValues.Add(temp);

                #region 获取最大小数位数

                string strFormat = dgv.Columns[item.ColumnIndex].DefaultCellStyle.Format;
                if (string.IsNullOrEmpty(strFormat) || strFormat.Length < 2)
                    continue;
                if (haveDecimalPlace == false)
                    haveDecimalPlace = true;
                strFormat = strFormat.Substring(1, strFormat.Length - 1);
                int decPlace = 0;
                if (int.TryParse(strFormat, out decPlace))
                {
                    if (decPlace > decimalPlace)
                        decimalPlace = decPlace;
                }

                #endregion
            }

            sum = lstValues.Sum();
            if (haveDecimalPlace == false)
            {
                string strSum = sum.ToString();
                int curIndex = strSum.LastIndexOf('.');
                if (curIndex >= 0)
                    decimalPlace = strSum.Length - curIndex - 1;
                if (decimalPlace < 0)
                    decimalPlace = 0;
            }
            if (lstValues.Count <= 0)
                avg = 0;
            else
                avg = lstValues.Average();
        }
    }
}