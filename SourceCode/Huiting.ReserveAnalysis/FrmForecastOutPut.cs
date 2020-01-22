using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using BDSoft.Common;
using ReserveChart;
using LocalDataService;
using BDSoft.DBAccess;
using ReserveChartExpand;
using ReserveCommon;
using BDSoft.Components;
using BDControl;

namespace ReserveAnalysis
{
    public partial class FrmForecastOutPut : FrmChild //DockContent
    {
        UnitType unitType = UnitType.CnUnit;
        DecParams decParams;
        List<AssetsData> lstAssetsData;
        IEntityData entityData;
        public FrmForecastOutPut()
        {
            InitializeComponent();
        }

        public void InitFrom(DecParams decParams, List<AssetsData> lstAssetsData, IEntityData entityData)
        {
            if (this.decParams != decParams)
                this.decParams = decParams;
            if (this.lstAssetsData != lstAssetsData)
                this.lstAssetsData = lstAssetsData;
            if (this.entityData != entityData)
                this.entityData = entityData;
            this.Text = entityData.Text + "预测产量";
         
            if (entityData != lstAssetsData[0]) 
            {
                this.tsbSave.Visible = false;
                this.treeHeadDataGridView1.ReadOnly = true;
            }
            else
            {
                this.tsbSave.Visible = true;
                this.treeHeadDataGridView1.ReadOnly = false;
            }
            unitType = UnitType.CnUnit;
            InitUnit(UnitType.CnUnit);
        }

        void bgwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            UnitType unitType = (UnitType)e.Argument;
            List<string> lstdydm = PublicMethods.GetLstStringByLstT(lstAssetsData, "ID");

            DBAccessEx dbAccess = localService.GetNewDBAccessEx();
            dbAccess.BeginTransaction();
            if (unitType == UnitType.EnUnit)
            {
                DYDAB01Service dyDAB01Service = new DYDAB01Service(dbAccess);
                DataTable dtDydmWithOutYymd = dyDAB01Service.GetDataTableWithOutYYMD(decParams.ProID, decParams.Pjnd, OrganizationType.Dydm, lstdydm);
                if (dtDydmWithOutYymd != null && dtDydmWithOutYymd.Rows.Count > 0)
                {
                    dtDydmWithOutYymd.TableName = "yymd";
                    e.Result = dtDydmWithOutYymd;
                    return;
                }
            }

            DataTable dtPreMonthData;
            PreMonthDataService preMonthDataService = new PreMonthDataService(dbAccess);
            if (unitType == UnitType.CnUnit)
                dtPreMonthData = preMonthDataService.GetDataTableCN(decParams.ProID, decParams.Pjnd, lstdydm);
            else
                dtPreMonthData = preMonthDataService.GetDataTableEN(decParams.ProID, decParams.Pjnd, lstdydm);

            dbAccess.Commit();

            DataTable dtEmpty= dtPreMonthData.Clone();
            GetEmptyDataTable(ref dtEmpty);
            MergerDataTable(ref dtEmpty, dtPreMonthData);
            e.Result = dtEmpty;
        }

        private void GetEmptyDataTable(ref DataTable dtEmpty)
        {
            if (decParams.PreEndDate <= decParams.PreStartDate)
                throw new Exception("");

            DateTime curDt=decParams.PreStartDate;
            while (curDt <= decParams.PreEndDate)
            {
                DataRow dr = dtEmpty.NewRow();
                dr[0] = curDt.ToString("yyyyMM");
                dtEmpty.Rows.Add(dr);

                curDt = curDt.AddMonths(1);
            }
        }

        private void MergerDataTable(ref DataTable dtEmpty, DataTable dtData)
        {
            foreach (DataRow dr in dtEmpty.Rows)
            {
                string ny = dr[0].ToString();
                DataRow[] drAry = dtData.Select("ny='" + ny + "'", "");
                if (drAry.Length <= 0)
                    continue;

                dr[1] = drAry[0][1];
                dr[2] = drAry[0][2];
            }
        }

        void bgwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                PublicMethods.WarnMessageBox(this, "加载窗体异常：" + e.Error.Message);
                return;
            }

            DataTable dt = e.Result as DataTable;
            if (dt == null)
                return;

            if (dt.TableName == "yymd")
            {
                List<string> lstDydm = PublicMethods.GetLstStringByDataTable(dt, "dydm");
                string strDydm = PublicMethods.GetStringByLstString(lstDydm);
                if (string.IsNullOrEmpty(strDydm)==false)
                {
                    PublicMethods.WarnMessageBox(this, "以下单元因为缺少原油密度，无法转换成英式单元：\r\n" + strDydm);
                    return;
                }
            }

            this.unitType = this.unitType == UnitType.CnUnit ? UnitType.EnUnit : UnitType.CnUnit;
            this.treeHeadDataGridView1.DataSource = null;
            if (unitType == UnitType.EnUnit)
            {
                this.tsmUnitSwitch.Text = "切换为英式单位";
                this.tsbUnitSwich.Text = "切换为英式单位";
                this.InitTreeHeadDataGridViewCN();
            }
            else
            {
                this.tsmUnitSwitch.Text = "切换为中式单位";
                this.tsbUnitSwich.Text = "切换为中式单位";
                this.InitTreeHeadDataGridViewEN();
            }

            treeHeadDataGridView1.CellValueChanged -= treeHeadDataGridView1_CellValueChanged;
            treeHeadDataGridView1.DataSource = dt;

            //dt.Columns[1].DataType;
            treeHeadDataGridView1.CellValueChanged += treeHeadDataGridView1_CellValueChanged;
        }

        void treeHeadDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (tsbSave.Enabled == false)
                tsbSave.Enabled = true;
        }

        private void InitTreeHeadDataGridViewCN()
        {
            DataGridViewColumnNode dgcnTemp;
            DataGridViewColumnNode dgcnRoot = new DataGridViewColumnNode();

            DataGridViewColumnNode dgcnNY= new DataGridViewColumnNode("年月");
            dgcnNY.DataPropertyName = "ny";
            dgcnNY.ReadOnly = true;
            dgcnNY.BackColor = Color.FromArgb(240,240,240);
            dgcnRoot.AddChildColumn(dgcnNY);

            DataGridViewColumnNode dgcnYJ = new DataGridViewColumnNode("月产油");
            dgcnTemp = new DataGridViewColumnNode("万吨");
            dgcnTemp.DataPropertyName = "ycy";
            dgcnTemp.Format = "f4";
            dgcnYJ.AddChildColumn(dgcnTemp);
            dgcnRoot.AddChildColumn(dgcnYJ);

            DataGridViewColumnNode dgcnQJ = new DataGridViewColumnNode("月产气");
            dgcnTemp = new DataGridViewColumnNode("万方");
            dgcnTemp.DataPropertyName = "ycq";
            dgcnTemp.Format = "f4";
            dgcnQJ.AddChildColumn(dgcnTemp);
            dgcnRoot.AddChildColumn(dgcnQJ);

            this.treeHeadDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.treeHeadDataGridView1.SetTreeHeadRootColumn(dgcnRoot);
            this.treeHeadDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //int columnCount = treeHeadDataGridView1.Columns.Count;
            //int columnWidth = this.treeHeadDataGridView1.Width / columnCount;
            //foreach (DataGridViewColumn item in treeHeadDataGridView1.Columns)
            //{
            //    if (item == treeHeadDataGridView1.Columns[treeHeadDataGridView1.Columns.Count - 1])
            //        continue;
            //    item.Width = columnWidth;
            //}
        }

        private void InitTreeHeadDataGridViewEN()
        {
            DataGridViewColumnNode dgcnTemp;
            DataGridViewColumnNode dgcnRoot = new DataGridViewColumnNode();

            DataGridViewColumnNode dgcnNY = new DataGridViewColumnNode("年月");
            dgcnNY.DataPropertyName = "ny";
            dgcnNY.ReadOnly = true;
            dgcnNY.BackColor = Color.FromArgb(240, 240, 240);
            dgcnRoot.AddChildColumn(dgcnNY);

            DataGridViewColumnNode dgcnYJ = new DataGridViewColumnNode("月产油");
            dgcnTemp = new DataGridViewColumnNode("千桶");
            dgcnTemp.DataPropertyName = "ycy";
            dgcnTemp.Format = "f4";
            dgcnYJ.AddChildColumn(dgcnTemp);
            dgcnRoot.AddChildColumn(dgcnYJ);

            DataGridViewColumnNode dgcnQJ = new DataGridViewColumnNode("月产气");
            dgcnTemp = new DataGridViewColumnNode("千立方英尺");
            dgcnTemp.DataPropertyName = "ycq";
            dgcnTemp.Format = "f4";
            dgcnQJ.AddChildColumn(dgcnTemp);
            dgcnRoot.AddChildColumn(dgcnQJ);

            this.treeHeadDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.treeHeadDataGridView1.SetTreeHeadRootColumn(dgcnRoot);
            this.treeHeadDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //int columnCount = treeHeadDataGridView1.Columns.Count;
            //int columnWidth = this.treeHeadDataGridView1.Width / columnCount;
            //foreach (DataGridViewColumn item in treeHeadDataGridView1.Columns)
            //{
            //    //最后一列不用再赋值
            //    if (item == treeHeadDataGridView1.Columns[treeHeadDataGridView1.Columns.Count - 1])
            //        continue;
            //    item.Width = columnWidth;
            //}
        }

        private void tsbCut_Click(object sender, EventArgs e)
        {
            tsm3Cut.PerformClick();
        }

        private void tsbPaste_Click(object sender, EventArgs e)
        {
            tsm3Paste.PerformClick();
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            tsm3Copy.PerformClick();
        }

        private void tsm3Cut_Click(object sender, EventArgs e)
        {
            int selCount = treeHeadDataGridView1.SelectedCells.Count;
            if (!MyMethod.GetUserSel("确定要剪切用户所选的" + selCount.ToString() + "个单元格数据吗？"))
            {
                return;
            }
            MyMethod.CopyFromDataGridView(treeHeadDataGridView1);
            MyMethod.ClearDataGridViewSelCell(treeHeadDataGridView1);

            tsbSave.Enabled = true;
        }

        private void tsm3Copy_Click(object sender, EventArgs e)
        {
            MyMethod.CopyFromDataGridView(treeHeadDataGridView1);
        }

        private void tsm3Paste_Click(object sender, EventArgs e)
        {
            MyMethod.PasterToDataGridView(treeHeadDataGridView1, true);
            //treeHeadDataGridView1.Text = "单元开发数据共：" + curTable.Rows.Count.ToString() + " 条";
            tsbSave.Enabled = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            DataTable dt = treeHeadDataGridView1.DataSource as DataTable;
            if (dt == null)
                return;

            if (tsbSave.Enabled==true)
            {
                if (PublicMethods.AskQuestion(this, "预测产量数据已经被修改，是否保存？")==false)
                    return;

                tsbSave.PerformClick();
                e.Cancel = true;
            }
        }

        private void tsbExcelEdit_Click(object sender, EventArgs e)
        {
            string excelFileName = entityData.Text;
            C_DataGridViewToExcelEdit opExcel = new C_DataGridViewToExcelEdit(treeHeadDataGridView1, this, excelFileName);
            opExcel.BeginEdit();
            if (opExcel.RefreshTable)
            {

            }
        }

        private void tsbExcelExport_Click(object sender, EventArgs e)
        {
            string excelFileName = entityData.Text;
            excelFileName=  PublicMethods.SetFilePath("*..xlsx|*..xlsx", excelFileName);
            if (string.IsNullOrEmpty(excelFileName))
                return;
            if (MyMethod.GetUserSel("文件保存成功，是否打开？"))
                MyMethod.RunApp(excelFileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSave_Click(object sender, EventArgs e)
        {
            tsbSave.Enabled = false;
            DataTable dtData = treeHeadDataGridView1.DataSource as DataTable;
            if (dtData.GetChanges() != null)
                dtData.AcceptChanges();
            BackgroundWorker bgwSave = new BackgroundWorker();
            bgwSave.DoWork -= bgwSave_DoWork;
            bgwSave.DoWork += bgwSave_DoWork;
            bgwSave.RunWorkerCompleted -= bgwSave_RunWorkerCompleted;
            bgwSave.RunWorkerCompleted += bgwSave_RunWorkerCompleted;
            bgwSave.RunWorkerAsync(dtData);
        }

        void bgwSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                PublicMethods.WarnMessageBox(this, "保存失败：" + e.Error.Message);
                return;
            }

            string err = e.Result as string;
            if (string.IsNullOrEmpty(err) == false)
            {
                PublicMethods.WarnMessageBox(this, "保存失败：" + err);
                return;
            }

            PublicMethods.TipsMessageBox(this, "保存成功！");
        }

        void bgwSave_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dtData = e.Argument as DataTable;

            DBAccessEx dbAccess = localService.GetNewDBAccessEx();
            dbAccess.BeginTransaction();
            //首先删除表中数据，删除数据分主表和字表，主表为preline,字表为premonthdata
            PreLineService m_PreLineService = new PreLineService(dbAccess);
            m_PreLineService.Delete(decParams.ProID, decParams.Pjnd, decParams.Dydm, StudyType.DYFX);
            PreMonthDataService m_PreMonthDataService = new PreMonthDataService(dbAccess);
            m_PreMonthDataService.Delete(decParams.ProID, decParams.Pjnd, decParams.Dydm);
            //插入线数据  
            string prelineID_YCY = Guid.NewGuid().ToString();//月产油
            string prelineID_YCQ = Guid.NewGuid().ToString();//月产气
            DataTable dt_preline = m_PreLineService.GetEmptyDataTable();
            //插入月产油数据
            DataRow dr_line_ycy = dt_preline.NewRow();
            dr_line_ycy["prelineID"] = prelineID_YCY;
            dr_line_ycy["proID"] = decParams.ProID;
            dr_line_ycy["pjnd"] = decParams.Pjnd;
            dr_line_ycy["dydm"] = decParams.Dydm;
            dr_line_ycy["studyType"] = "DYFX";
            dr_line_ycy["seriesName"] = "ycy";
            dt_preline.Rows.Add(dr_line_ycy);
            //插入月产气数据
            DataRow dr_line_ycq = dt_preline.NewRow();
            dr_line_ycq["prelineID"] = prelineID_YCQ;
            dr_line_ycq["proID"] = decParams.ProID;
            dr_line_ycq["pjnd"] = decParams.Pjnd;
            dr_line_ycq["dydm"] = decParams.Dydm;
            dr_line_ycq["studyType"] = "DYFX";
            dr_line_ycq["seriesName"] = "ycq";
            dt_preline.Rows.Add(dr_line_ycq);
            m_PreLineService.Insert(dt_preline);
            //插入预测数据
            DataTable dt_data = m_PreMonthDataService.GetEmptyDataTable();
            foreach (DataRow dr in dtData.Rows)
            {
                //添加月产油
                DataRow dr_data_ycy = dt_data.NewRow();
                dr_data_ycy["prelineID"] = prelineID_YCY;
                dr_data_ycy["NY"] = dr["NY"];
                double ycy = dr["YCY"].ToDouble();
                if (tsbUnitSwich.Text == "切换为英式单位")
                {
                    DYDAB01Service M_DYDAB01Service = new DYDAB01Service();
                    double YYMD = M_DYDAB01Service.GetYYMD(decParams.ProID, decParams.Dydm);
                    ycy = InternalMethods.GetWTonByMBBL(ycy, YYMD);
                }
                dr_data_ycy["YCValue"] = dr["YCY"];
                dt_data.Rows.Add(dr_data_ycy);
                //添加月产气
                DataRow dr_data_ycq = dt_data.NewRow();
                dr_data_ycq["prelineID"] = prelineID_YCQ;
                dr_data_ycq["NY"] = dr["NY"];
                double YCQ = dr["YCQ"].ToDouble();
                if (tsbUnitSwich.Text == "切换为英式单位")
                {
                    DYDAB01Service M_DYDAB01Service = new DYDAB01Service();
                    YCQ = InternalMethods.GetM3ByMCF(YCQ);
                }
                dr_data_ycq["YCValue"] = YCQ;
                dt_data.Rows.Add(dr_data_ycq);
            }
            e.Result = m_PreMonthDataService.Insert(dt_data);

            dbAccess.Commit();
        }

        private void tsmUnitSwitch_Click(object sender, EventArgs e)
        {
            if (this.tsbUnitSwich.Text == "切换为中式单位")
            {
                InitUnit(UnitType.CnUnit);
            }
            else
            {
                InitUnit(UnitType.EnUnit);
               
            }
            //if (this.unitType == UnitType.CnUnit)
            //    InitUnit(UnitType.CnUnit);
            //else
            //    InitUnit(UnitType.EnUnit);
        }

        private void InitUnit(UnitType unitType)
        {
            BackgroundWorker bgwLoad = new BackgroundWorker();
            bgwLoad.DoWork += bgwLoad_DoWork;
            bgwLoad.RunWorkerCompleted += bgwLoad_RunWorkerCompleted;
            bgwLoad.RunWorkerAsync(unitType);
        }

        private void tsbUnitSwich_Click(object sender, EventArgs e)
        {
            tsmUnitSwitch.PerformClick();
        }
      
    }
}
