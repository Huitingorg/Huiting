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
    public partial class UctToolBar : UserControl
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
            }
        }

        public UctToolBar()
        {
            InitializeComponent();
            this.Height = this.statusStrip1.Height;
            this.Dock = DockStyle.Bottom;
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
            Calc(dgv.SelectedCells, out counter, out avg, out sum);
            this.tsslCount.Text = "计数：" + counter.ToString();
            if (dgv.SelectedCells.Count <= 1)
                return;

            if (sum != null)
                this.tsslSum.Text = "求和：" + sum.ToString();

            int decimalPlace;
            string sumStr = sum.ToString();
            int index = sumStr.LastIndexOf('.');
            if (index < 0)
                decimalPlace = 0;
            else
                decimalPlace = sumStr.Length - index;
            string format = "f" + decimalPlace;
            if (avg != null)
                this.tssLAvg.Text = "平均值：" + avg.Value.ToString(format);
            
        }

        private void Calc(DataGridViewSelectedCellCollection SelectedCells, out int? counter, out double? avg, out double? sum)
        {
            counter = 0;
            avg = null;
            sum = null;

            if (SelectedCells == null || SelectedCells.Count <= 0)
                return;

            List<double> lstValues = new List<double>();
            counter = SelectedCells.Count;
            foreach (DataGridViewCell item in SelectedCells)
            {
                if (item.Value == null)
                    continue;
                double temp;
                if (double.TryParse(item.Value.ToString(), out temp))
                    lstValues.Add(temp);
            }

            sum = lstValues.Sum();
            avg = lstValues.Average();
        }


    }
}