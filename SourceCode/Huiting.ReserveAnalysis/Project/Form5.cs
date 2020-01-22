using BDSoft.Chart;
using LocalDataService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BDSoft.Common;

namespace ReserveAnalysis
{
    public partial class Form5 : Form
    {
        string fileName = "Config.xml";
        
        public Form5()
        {
            InitializeComponent();
            this.bdToolBar1.BDChart = this.bdChart1;
        }

        private void btnWriteXml_Click(object sender, EventArgs e)
        {
            ChartTemplate chartTemplate = bdChart1.GetChartTemplate();
            chartTemplate.WriteXmlFile(fileName);
        }

        private void btnReadXml_Click(object sender, EventArgs e)
        {
            ChartTemplate chartTemplate = new ChartTemplate();
            chartTemplate.ReadXmlFile(fileName);

            DataTable dt = new DYMonthDataService().GetDataTable("1201032");
            this.bdChart1.LoadTemplateAndData(chartTemplate, dt);
            this.bdChart1.Refresh();
        }

        private void btnLoadSeries_Click(object sender, EventArgs e)
        {
            DataTable dt = new DYMonthDataService().GetDataTable("1201032");
            ChartPointQueue cpq = GetChartPointQueue(dt);

            ChartTemplate chartTemplate = new ChartTemplate();
            chartTemplate.Title.Text = "测试标题";
            chartTemplate.LoadChartTemplate(cpq);

            this.bdChart1.SetChartTemplate(chartTemplate);
            this.bdChart1.Refresh();
        }

        private ChartPointQueue GetChartPointQueue(DataTable dt)
        {
            ChartPointQueue cpq = new ChartPointQueue();

            foreach (DataRow dr in dt.Rows)
            {
                double ny = dr["ny"].ToDateTime().ToDouble();
                double ycy = dr["ycy"].ToDouble();
                cpq.Add(new ChartPoint() { X = ny, Y = ycy });
            }

            return cpq;
        }

        private List<PointF> GetLstPointF(DataTable dt)
        {
            List<PointF> lstPF = new List<PointF>();
            foreach (DataRow dr in dt.Rows)
            {
                double ny = dr["ny"].ToDateTime().ToDouble();
                double ycy = dr["ycy"].ToDouble();

                lstPF.Add(new PointF((float)ny, (float)ycy));
            }

            return lstPF;
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            ChartTemplate chartTemplate = new ChartTemplate();
            chartTemplate.LoadChartTemplate();

            this.bdChart1.SetChartTemplate(chartTemplate);
            this.bdChart1.Refresh();

        }
    }
}