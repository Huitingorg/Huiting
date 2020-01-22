using ReserveCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using LocalDataService;
using DataEdit;
using BDSoft.Common;
using BDSoft.Components;
using AJRChart;
using WaterDriveLib;

namespace ReserveAnalysis
{
    public partial class FrmChart : DockContent
    {
        string fieldY;
        string fieldX = "lcy";
        Color clrAxis = Color.Blue;
        UnitFunctionType unitFunctionType;
        string pjnd;
        string ycqsrq;
        AssetsData assetsData;

        [Description("Y 轴是否使用逻辑比例坐标。")]
        private bool axisYLogarithmic = false;

        DataTable dtPreMonthData;


        public FrmChart(AssetsData assetsData, string pjnd, string ycqsrq, UnitFunctionType UnitFunctionType)
        {
            InitializeComponent();
            this.pjnd = pjnd;
            this.ycqsrq = ycqsrq;
            this.assetsData = assetsData;
            this.unitFunctionType = UnitFunctionType;

            this.CloseButtonVisible = true;
            this.CloseButton = true;
        }

        private string GetTitle()
        {
            return GetTitle2() + " VS 累产";
        }

        private string GetTitle1()
        {
            string title = "";
            switch (unitFunctionType)
            {
                case UnitFunctionType.DJQXYueChanDuiLeiChan:
                    title = "（万吨）";
                    break;
                case UnitFunctionType.DJQXHanYouLvDuiLeiChan:
                    title = "（%）";
                    break;
                case UnitFunctionType.DJQXHanShuiLvDuiLeiChan:
                    title = "（%）";
                    break;
                case UnitFunctionType.DJQXShuiYouBiDuiLeiChan:
                    title = "";
                    break;
                default:
                    break;
            }

            return GetTitle2() + title;
        }

        private string GetTitle2()
        {
            string title = "";
            switch (unitFunctionType)
            {
                case UnitFunctionType.DJQXYueChanDuiLeiChan:
                    title = "月产";
                    break;
                case UnitFunctionType.DJQXHanYouLvDuiLeiChan:
                    title = "含油率";
                    break;
                case UnitFunctionType.DJQXHanShuiLvDuiLeiChan:
                    title = "含水率";
                    break;
                case UnitFunctionType.DJQXShuiYouBiDuiLeiChan:
                    title = "水油比";
                    break;
                default:
                    break;
            }

            return title;
        }

        private string GetFieldY()
        {
            string title = "";
            switch (unitFunctionType)
            {
                case UnitFunctionType.DJQXYueChanDuiLeiChan:
                    title = "ycy";
                    break;
                case UnitFunctionType.DJQXHanYouLvDuiLeiChan:
                    title = "syshyl";
                    break;
                case UnitFunctionType.DJQXHanShuiLvDuiLeiChan:
                    title = "syshsl";
                    break;
                case UnitFunctionType.DJQXShuiYouBiDuiLeiChan:
                    title = "syssyb";
                    break;
                default:
                    break;
            }

            return title;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadChart();
        }

        public void LoadChart(AssetsData assetsData, string pjnd, string ycqsrq, UnitFunctionType UnitFunctionType)
        {
            this.pjnd = pjnd;
            this.ycqsrq = ycqsrq;
            this.assetsData = assetsData;
            this.unitFunctionType = UnitFunctionType;

            this.LoadChart();
        }

        private void LoadChart()
        {
            this.fieldY = GetFieldY();
            this.Text = this.GetTitle();

            ResFormulaService resFormulaService = new ResFormulaService();
            DataTable dtHistoryMonthData = resFormulaService.GetDYMonthDataTable(assetsData.DYDM, ycqsrq);
            dtHistoryMonthData = DealDataSource(dtHistoryMonthData);
            
            List<NodeEnity> lstNE = assetsData.GetLstNodeEntity();
            PreMonthDataService pmds = new PreMonthDataService();
            dtPreMonthData = pmds.GetDataTable(assetsData.ProID, pjnd, lstNE);

            DYMonthDataService dds = new DYMonthDataService();
            double ljcy = dds.GetLJCL(assetsData.DYDM, ycqsrq);
            DoWithDT(ref dtPreMonthData, ljcy);
            
            #region 图形加载

            try
            {
                ChartData chartdata = getDefaultData("累产油（万吨）", new List<DataTable>() { dtHistoryMonthData, dtPreMonthData });
                CInitializeChart initailize = new CInitializeChart();
                initailize.InitializeChart(jrChart1, chartdata);

                ((OprtFitting)jrChart1.oprt).PredictionEvent += new OprtFitting.Event_Prediction(jrChart1_PredictionEvent);

                ChartSeries sr_In = jrChart1.chartdata.serieslst[0];
                jrChart1.AllowMouseWheelZoom = true;//鼠标可缩放。
                jrChart1.AllowDrop = false;
                sr_In.bkclr = Color.White;
                sr_In.VLineColor = Color.Black;
                sr_In.HLineColor = Color.Black;
                this.jrChart1.RepaintAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "数据有误不能加载数据");
                return;
            }
            #endregion
        }

        #region MyRegion

        private ChartData getDefaultData(string hTitle, List<DataTable> lstDataTable)
        {
            ChartData chartdata = new ChartData();

            chartdata.IsBkColor_jb = true;
            chartdata.sc_bkColor = Color.Red;
            ChartTitle title = new Title();
            title.title = "";
            title.titleFont.size = 12;
            title.titleFont.clr = Color.Red;
            title.pos = new ChartPoint(40, 96);
            chartdata.title = title;

            ChartAxis hA = GetHorizChartAxis(hTitle);
            chartdata.axislst.Add(hA);

            ChartAxis vA = GetVerticalChartAxis(GetTitle1());
            chartdata.axislst.Add(vA);

            for (int i = 0; i < lstDataTable.Count; i++)
            {
                Color clrSeries = i == 0 ? Color.Red : Color.Green;
                DataTable dt = lstDataTable[i];
                ChartSeries sr = GetChartSeries(dt, hA, vA, clrSeries);
                chartdata.serieslst.Add(sr);
            }

            return chartdata;
        }

        //WaterFitItem data;
        /// 预测事件
        bool jrChart1_PredictionEvent(List<SeriesPoint> list_sp, int Idx_s, int Idx_e, double preDate_s, ref ChartSeries fitSeries, ref ChartLinkBrokenline preLine)
        {
            foreach (ChartAxis item in jrChart1.chartdata.axislst)
            {
                if (item.isHorAxis)
                    continue;
                item.isMaxMinAuto = false;
            }

            double a, b, r;
            a = b = r = 0;
            double[] dblOilAry, dblOtherAry;
            Analyze(list_sp, out dblOilAry, out dblOtherAry);
            //拟合,求Di
            LinearFitting.CalLinearSimulateKB(dblOilAry, dblOtherAry, ref b, ref a, ref r);
            //计算拟合线的两端点
            //fitSeries.pointlst = GetLstSP(list_sp, a, b);
            fitSeries.pointlst = GetLstSP(jrChart1.chartdata.serieslst[0], a, b);
            AddListPointLst(dtPreMonthData, ref fitSeries.pointlst, a, b);

            return true;
        }

        private void AddListPointLst(DataTable dt, ref List<SeriesPoint> list_sp, double a, double b)
        {
            foreach (DataRow dr in dt.Rows)
            {
                SeriesPoint cp = new SeriesPoint();
                cp.xValue = dr["xx"].ToDouble();
                cp.yValue = a + b * cp.xValue;
                list_sp.Add(cp);
            }
        }

        private void Analyze(List<SeriesPoint> list_sp, out double[] dblOilAry, out double[] dblOtherAry)
        {
            dblOilAry = new double[list_sp.Count];
            dblOtherAry = new double[list_sp.Count];

            for (int i = 0; i < list_sp.Count; i++)
            {
                dblOilAry[i] = list_sp[i].xValue;
                dblOtherAry[i] = list_sp[i].yValue;
            }
        }

        private ChartAxis GetHorizChartAxis(string title)
        {
            ChartAxis hA = new Axis(true);
            hA.title = title;
            hA.hdt = HorAxisDataType.HDT_VALUE;
            //hA.dateSpec = DateSpec.DS_None;
            //hA.specValue = 50;
            hA.ckd_width = 1;
            hA.isShowCKD = true;
            hA.ckd_spec = 10;
            hA.ckd_color = Color.Green;

            //hA.ckd_length = 500;

            //hA.offsetAxis = 0;
            hA.HorAxis_Title_pos = HAlignStyle.RIGHT;
            hA.titleFont.clr = Color.Black;
            hA.titleFont.size = 8;
            //hA.position = 10;
            //hA.startPosition = 10;
            //hA.endPosition = 90;
            //hA.isShowDay = false;
            //hA.NPos = 2;
            //hA.is_kd_ShowOnRightSide = false;
            //hA.is_AxisTitle_ShowOnRightSide = false;
            //hA.is_AxisLabel_ShowOnRightSide = false;
            hA.ClipAtNoZoomPosition = true;
            hA.isAutoShowLabel = true;
            hA.isMaxMinAuto = true;
            //hA.maxValue = 100;
            //hA.minValue = 0;

            return hA;
        }

        private ChartAxis GetVerticalChartAxis(string title)
        {
            ChartAxis vA = new Axis(false);
            vA.isLogValue = axisYLogarithmic;
            vA.title = title;
            vA.titleFont.size = 8;
            vA.titleFont.clr = clrAxis;
            vA.pillarWidth = 0;

            //vA.position = 4.42;
            //vA.startPosition = 6.48;
            //vA.endPosition = 91.41;
            //vA.ckd_color = Color.Red;
            //vA.ckd_width = 1;
            //vA.title = title;
            //vA.offsetAxis = 0;

            //vA.titleFont.size = 10;
            //vA.isAutoShowLabel = true;

            //vA.isMaxMinAuto = true;
            //vA.specValue = 20;


            vA.lableFont.clr = vA.axis_color = vA.titleFont.clr = clrAxis;

            return vA;
        }

        private ChartSeries GetChartSeries(DataTable dtTable, ChartAxis hA, ChartAxis vA, Color clrSeries)
        {
            ChartSeries sr = new Series();
            sr.VLineColor = Color.Black;
            sr.HLineColor = Color.Black;
            sr.horAxis = hA;
            sr.verAxis = vA;
            sr.Movable_SP = true;
            sr.isShowNet = true;
            sr.VKDSpac = 1;
            sr.seriesType = SeriesType.ST_LINE;
            sr.pointStyle = PointStyle.PS_STAR;
            sr.isMarkOn = false;
            sr.lineWidth = 1;
            sr.pointSize = 3;
            sr.clr = clrSeries;
            vA.serieslst.Add(sr);
            hA.serieslst.Add(sr);

            sr.pointlst = GetLstSeriesPoint(dtTable);
            sr.cx_spec = 2;

            return sr;
        }

        private List<SeriesPoint> GetLstSeriesPoint(DataTable dtTable)
        {
            List<SeriesPoint> lstSP = new List<SeriesPoint>();
            for (int j = 0; j < dtTable.Rows.Count; j++)
            {
                SeriesPoint sp = new SeriesPoint();
                sp.xValue = Convert.ToDouble(dtTable.Rows[j]["xx"].ToString());
                sp.yValue = Convert.ToDouble(dtTable.Rows[j]["yy"].ToString());
                lstSP.Add(sp);
            }

            return lstSP;
        }

        private SeriesPoint GetNewSeriesPoint(SeriesPoint sp, double a, double b)
        {
            SeriesPoint cp = new SeriesPoint();
            cp.xValue = sp.xValue;

            double y = a + b * sp.xValue;
            cp.isNullData = double.IsNaN(y);
            if (this.axisYLogarithmic)
                y = Math.Pow(10, y);
            cp.yValue = y;

            return cp;
        }

        private List<SeriesPoint> GetLstSP(ChartSeries mainseries, double a, double b)
        {
            List<SeriesPoint> list_P_fitSr = new List<SeriesPoint>();
            foreach (SeriesPoint sp in mainseries.pointlst)
            {
                SeriesPoint cp = GetNewSeriesPoint(sp, a, b);
                list_P_fitSr.Add(cp);
            }

            return list_P_fitSr;
        }

        private DataTable GetDataTable(ChartSeries mainseries, double a, double b)
        {
            DataRow rows = null;
            DataTable dtfit = new DataTable();
            dtfit.Columns.Add(new DataColumn("X"));
            dtfit.Columns.Add(new DataColumn("Y"));
            foreach (SeriesPoint sp in mainseries.pointlst)
            {
                rows = dtfit.NewRow();
                SeriesPoint cp = GetNewSeriesPoint(sp, a, b);

                rows[0] = cp.xValue;
                rows[1] = cp.yValue;
                dtfit.Rows.Add(rows);
            }

            return dtfit;
        }

        private List<SeriesPoint> GetLstSP(List<SeriesPoint> list_sp, double a, double b)
        {
            List<SeriesPoint> list_P_fitSr = new List<SeriesPoint>();

            foreach (SeriesPoint sp in list_sp)
            {
                SeriesPoint cp = GetNewSeriesPoint(sp, a, b);
                list_P_fitSr.Add(cp);
            }

            return list_P_fitSr;
        }

        #endregion

        private DataTable DealDataSource(DataTable dtDeal)
        {
            DataTable dtValue = new DataTable();
            dtValue.Columns.Add("date", typeof(DateTime));
            dtValue.Columns.Add("xx", typeof(double));
            dtValue.Columns.Add("yy", typeof(double));

            foreach (DataRow row in dtDeal.Rows)
            {
                if (string.IsNullOrEmpty(row[fieldX].ToString()) && string.IsNullOrEmpty(row[fieldY].ToString()))
                    continue;
                DataRow newRow = dtValue.NewRow();
                newRow["date"] = row["ny"].ToString().ToDateTime();
                newRow["xx"] = row[fieldX].ToDouble();
                newRow["yy"] = row[fieldY].ToDouble();
                dtValue.Rows.Add(newRow);
            }

            return dtValue;
        }

        private void DoWithDT(ref DataTable dt, double dblLCY)
        {
            dt.Columns["ycy"].ColumnName = "yy";
            if (dt.Columns.Contains("xx")==false)
                dt.Columns.Add("xx", typeof(double));

            double lcy = dblLCY;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                double ycy = dr["yy"].ToDouble();
                lcy += ycy;
                dr["xx"] = lcy;
            }
        }
    }
}
