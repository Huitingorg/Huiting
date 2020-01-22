using LocalDataService;
using ReserveChart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BDSoft.Common;
using BDSoft.Components;

namespace ReserveAnalysis
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string chartTemplateFile = "DYTemplate.xml";
            string seriesOptionsFile = "DYSeriesOptions.xml";

            chartTemplateFile = PublicMethods.GetAbsolutePath(chartTemplateFile);
            seriesOptionsFile = PublicMethods.GetAbsolutePath(seriesOptionsFile);

            DecParams decParams = new DecParams();
            decParams.ProID = "ff2e59ed-76e7-489f-91ed-85e57cd6cc24";
            decParams.PreStartDate = new DateTime(2014, 11, 1);
            DataTable dt = new DYMonthDataService().GetDataTable("2201002", decParams.PreStartDate.ToString("yyyyMM"));
            uctChart1.LoadChart(chartTemplateFile, seriesOptionsFile, dt, decParams);
        }
    }
}
