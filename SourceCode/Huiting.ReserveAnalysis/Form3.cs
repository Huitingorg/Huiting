using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BDSoft.Common;
using LocalDataService;
using ReserveChart;

namespace ReserveAnalysis
{
    public partial class Form3 : Form
    {
        string fileName = "DYTemplate.xml";
        public Form3()
        {
            InitializeComponent();
            this.bdToolBar1.BDChart = bdChart1;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            btnReadXml_Click(btnReadXml, null);
        }

        private void btnWriteXml_Click(object sender, EventArgs e)
        {
            try
            {
                bdChart1.WriteTemplateFile(fileName);
                //PublicMethods.TipsMessageBox("成功！");
            }
            catch (Exception ex)
            {
                PublicMethods.WarnMessageBox("失败：" + ex.Message);
            }
        }

        private void btnReadXml_Click(object sender, EventArgs e)
        {
            try
            {
                //获取模板
                DrawChart drawChart = new DrawChart();
                drawChart.ReadTemplateFile(fileName);

                DecParams decParams = new DecParams();
                decParams.ProID = "ff2e59ed-76e7-489f-91ed-85e57cd6cc24";
                decParams.PreStartDate = new DateTime(2014,11,1);
                DataTable dt = new DYMonthDataService().GetDataTable("2201002", decParams.PreStartDate.ToString("yyyyMM"));
                drawChart.Init(dt, decParams, "单元名称");
                bdChart1.LoadTemplateAndData(drawChart);
            }
            catch (Exception ex)
            {
                PublicMethods.WarnMessageBox("失败：" + ex.Message);
            }
        }

        private void RefreshLstBiaoDing(DrawChart drawChart)
        {
            //List<string> lstPjnd = drawChart.GetLstPjnd();
            //if(lstPjnd.Contains())
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if(item.Focused)
                {
                    MessageBox.Show(item.Name);
                }
            }
        }
    }
}
