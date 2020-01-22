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
using ReserveAnalysisResult;

namespace ReserveAnalysis
{
    public partial class DYChartWindow : DockContent
    {
        int curRowIndex = -1;
        public event EventHandler SelectedObjectChanged;

        public DYChartWindow()
        {
            InitializeComponent();

            this.uctChart1.RefreshUctLstDecLine += uctChart1_RefreshUctLstDecLine;
            this.uctChart1.RefreshUctDecLine += uctChart1_RefreshUctDecLine;
            this.uctChart1.CompareHistoryData += uctChart1_CompareHistoryData;

            this.uctChart1.EditHistoryPreLineVisible += uctChart1_EditHistoryPreLineVisible;
            this.uctChart1.DecParamsSelectedItemChanged += uctChart1_DecParamsSelectedItemChanged;
            this.uctChart1.SetPreLinesVisible += uctChart1_SetPreLinesVisible;
            this.uctChart1.SetBiaoDingVisible += uctChart1_SetBiaoDingVisible;
            this.uctChart1.SetLstBiaoDingResultVisible += uctChart1_SetLstBiaoDingResultVisible;
            this.uctChart1.SelectedObjectChanged += SelectedObjectChanged;   
            this.collapsibleSplitter1.InitCtrl();
            this.collapsibleSplitter1.CtrlCollapsed += collapsibleSplitter1_CtrlCollapsed;
            this.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

            this.uctDecStatus1.SavePage += UctDecStatus1_SavePage;
        }

        public event EventHandler SavePage;
        private void UctDecStatus1_SavePage(object sender, EventArgs e)
        {
            if (SavePage != null)
                SavePage(null,null);
        }

        void uctChart1_CompareHistoryData(object sender, EventArgs e)
        {
            string pjndWithCompared = sender as string;
            if (string.IsNullOrEmpty(pjndWithCompared))
                return;
            Frm_ResultCompare frmResultCompare = new Frm_ResultCompare(this.uctChart1.decParams.ProID, pjndWithCompared, this.uctChart1.decParams.Dydm);
            frmResultCompare.ShowDialog();
        }

        void uctChart1_SetPreLinesVisible(object sender, EventArgs e)
        {
            if (sender == null)
                return;
            SetHistorySelect(sender.ToString());
        }

        void uctChart1_SetBiaoDingVisible(object sender, EventArgs e)
        {
            string pjndDeleted = sender as string;
            if (string.IsNullOrEmpty(pjndDeleted))
                return;

            //从图形上删除1条标定信息
            List<string> lstNeedDelPjnd = new List<string>() { pjndDeleted };
            uctChart1.RemoveLstBiaoDing(lstNeedDelPjnd);
            //从数据表中删除一条记录
            DecParams decParams = this.uctChart1.decParams;
            BiaoDingStatusService bdss = new BiaoDingStatusService();
            bdss.Update(decParams.ProID, decParams.Pjnd, decParams.Dydm, pjndDeleted);
        }

        public void SetHistorySelect(string title)
        {
            List<string> lstExistPjnd = this.uctChart1.GetLstExistedPjnd();
            List<string> lstExistPjndCopy = new List<string>();
            lstExistPjndCopy.AddRange(lstExistPjnd);
            FrmHistoryPreline frmHistoryPreline = new FrmHistoryPreline(uctChart1.decParams.ProID, uctChart1.decParams.Pjnd, uctChart1.decParams.Dydm, uctChart1.StudyType, lstExistPjndCopy);
            frmHistoryPreline.Text = title;
            if (frmHistoryPreline.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                //先删除n条（n∈[0,+∞)）预测线
                List<string> lstNeedDelPjnd = GetOnlyBelongA(lstExistPjnd, frmHistoryPreline.LstNeedAddPjnd);
                if (lstNeedDelPjnd != null && lstNeedDelPjnd.Count > 0)
                    uctChart1.RemovePreLinesByChart(lstNeedDelPjnd);

                //再添加n条（n∈[0,+∞)）预测线
                List<string> lstNeedAddPjnd = GetOnlyBelongA(frmHistoryPreline.LstNeedAddPjnd, lstExistPjnd);
                if (lstNeedAddPjnd != null && lstNeedAddPjnd.Count > 0)
                    uctChart1.AppendPreLinesByChart(lstNeedAddPjnd);
  

                uctDecStatus1_VisibleChanged(null, null);

                this.RefreshBDChart();
            }
        }

        void uctChart1_SetLstBiaoDingResultVisible(object sender, EventArgs e)
        {
            List<string> lstExistPjnd = this.uctChart1.GetLstExistedPjndFromLstBiaoDing();
            List<string> lstExistPjndCopy = new List<string>();
            lstExistPjndCopy.AddRange(lstExistPjnd);
            FrmHistoryPreline frmHistoryPreline = new FrmHistoryPreline(uctChart1.decParams.ProID, uctChart1.decParams.Pjnd, uctChart1.decParams.Dydm, uctChart1.StudyType, lstExistPjndCopy);
            if (sender != null)
                frmHistoryPreline.Text = sender.ToString();
            if (frmHistoryPreline.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                //删除n条（n∈[0,+∞)）标定信息
                List<string> lstNeedDelPjnd = GetOnlyBelongA(lstExistPjnd, frmHistoryPreline.LstNeedAddPjnd);
                if (lstNeedDelPjnd != null && lstNeedDelPjnd.Count > 0)
                    uctChart1.RemoveLstBiaoDing(lstNeedDelPjnd);

                //添加n条（n∈[0,+∞)）标定信息
                List<string> lstNeedAddPjnd = GetOnlyBelongA(frmHistoryPreline.LstNeedAddPjnd, lstExistPjnd);
                if (lstNeedAddPjnd != null && lstNeedAddPjnd.Count > 0)
                    uctChart1.AppendLstBiaoDing(lstNeedAddPjnd);
            }
        }


        void uctChart1_EditHistoryPreLineVisible(object sender, EventArgs e)
        {
            SetHistorySelect(sender.ToString());
        }

        void uctChart1_DecParamsSelectedItemChanged(object sender, EventArgs e)
        {
            DrawPreResultLinePart linePart = sender as DrawPreResultLinePart;
            if (linePart == null)
                return;

            string prelineID = linePart.DrawPreResultLine.DrawPreLine.ID;
            string csrq = linePart.StartDate;

            dataGridView1.SelectionChanged -= dataGridView1_SelectionChanged;
            dataGridView1.ClearSelection();

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells["prelineID"].Value.ToString() == prelineID && item.Cells["csrq"].Value.ToString() == csrq)
                    item.Selected = true;
            }
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            string preLineID = dataGridView1.CurrentRow.Cells["prelineID"].Value.ToString();
            string csrq = dataGridView1.CurrentRow.Cells["csrq"].Value.ToString();
            if (dataGridView1.CurrentRow.Index != curRowIndex)
            {
                uctChart1.SetSelectedObject(preLineID, csrq);
                curRowIndex = dataGridView1.CurrentRow.Index;
            }
        }

        void collapsibleSplitter1_CtrlCollapsed(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void RefreshBDChart()
        {
            this.uctChart1.Refresh();
        }

        private void RefreshDataGridView()
        {
            //如果不折叠起来
            if (collapsibleSplitter1.IsCollapse == true && collapsibleSplitter1.CollapseState == false)
            {
                DataTable dt = GetDTDecParamsInfo();
                dataGridView1.DataSource = dt;
            }
        }

        void uctChart1_RefreshUctDecLine(object sender, EventArgs e)
        {
            this.uctDecStatus1.VisibleChanged -= uctDecStatus1_VisibleChanged;
            this.uctDecStatus1.VisibleChanged += uctDecStatus1_VisibleChanged;
            this.uctDecStatus1.SelectedObjectChanged -= uctDecStatus1_SelectedObjectChanged;
            this.uctDecStatus1.SelectedObjectChanged += uctDecStatus1_SelectedObjectChanged;
            if (this.uctDecStatus1.Visible == true)
                this.uctDecStatus1.Init(this.uctChart1.BDChart);
        }

        void uctDecStatus1_SelectedObjectChanged(object sender, EventArgs e)
        {
            this.uctChart1.SetSelectedObject(sender as IDrawElement);
        }

        void uctChart1_RefreshUctLstDecLine(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        public void Init(DecParams decParams)
        {
            Log.Info("开始初始化DYChartWindow...") ;
            if (uctChart1.Visible == false)
                uctChart1.Visible = true;

            ResFormulaService resFormulaService = new ResFormulaService();
            DataTable dtDyKFSJ = resFormulaService.GetDYMonthDataTable(decParams.Dydm, decParams.Ycqsrq);
            VertAxisStateService vass = new VertAxisStateService();
            DataTable dtVertAxisState = vass.GetDataTable(decParams.ProID, decParams.Pjnd, decParams.Dydm, StudyType.DYFX);

            this.uctChart1.LoadChart(GlobalInfo.DYTemplate, GlobalInfo.DYSeriesOptions, GlobalInfo.DYBDTemplate, dtDyKFSJ, dtVertAxisState, decParams, StudyType.DYFX, null);
            uctChart1_RefreshUctDecLine(null, null);
            //有可能要刷新网格
            this.RefreshDataGridView();
            this.RefreshBDChart();

            Log.Info("结束初始化DYChartWindow...");
        }

        void uctDecStatus1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.uctDecStatus1.Visible == true)
                this.uctDecStatus1.Init(this.uctChart1.BDChart);
        }

        public void Save()
        {
            uctChart1.Save();
        }

        public void SetDrawSeriesOptions()
        {
            uctChart1.SetDrawSeriesOptions();
            uctChart1.RefreshBDControl(false);
        }

        public List<string> GetOnlyBelongA(List<string> lstA, List<string> lstB)
        {
            List<string> lstR = new List<string>();
            foreach (string item in lstA)
            {
                if (lstB.Contains(item)) continue;
                lstR.Add(item);
            }

            return lstR;
        }

        public void MoveUpOrDown(bool ToUp)
        {
            this.uctChart1.MoveUpOrDown(ToUp);
        }

        public void MoveLeftOrRight(bool toLeft, bool isSmall)
        {
            this.uctChart1.MoveLeftOrRight(toLeft, isSmall);
        }

        public void SetScroll(bool isScroll)
        {
            this.uctChart1.SetScroll(isScroll);
        }

        public Bitmap GetBitmap(Size size)
        {
            return uctChart1.GetBitmap(size);
        }

        /// <summary>
        /// 删除预测线
        /// </summary>
        /// <returns></returns>
        public void DeletePreLine()
        {
            uctChart1.DeletePreLine();
        }

        public void SetBiaoDingForm()
        {
            //this.uctChart1.SetPreLinePartStatusForm();
            collapsibleSplitter2.CollapseState = !collapsibleSplitter2.CollapseState;
        }

        public DataTable GetEmptyDataTable()
        {
            DataTable dtEmpty = new DataTable();
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                if (item.HeaderText.EndsWith("数") || item.HeaderText.EndsWith("量"))
                {

                    item.DefaultCellStyle.Format = "f4";
                    dtEmpty.Columns.Add(item.DataPropertyName, typeof(double));
                }

                else
                    dtEmpty.Columns.Add(item.DataPropertyName, typeof(string));
            }

            return dtEmpty;
        }

        public DataTable GetDTDecParamsInfo()
        {
            DataTable dtEmpty = GetEmptyDataTable();
            uctChart1.GetDataTable("ycy", ref dtEmpty);
            uctChart1.GetDataTable("ycq", ref dtEmpty);

            return dtEmpty;
        }

        public void SetQyb()
        {
            Frm_QYB frm_QYB = new Frm_QYB(uctChart1.decParams.ProID, uctChart1.decParams.Pjnd, uctChart1.decParams.Dydm);
            if (frm_QYB.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                if (frm_QYB.UseQyb)
                {
                    uctChart1.SetQyb(frm_QYB.Qyb);
                    uctChart1.Refresh();
                }
                    
            }
        }

        public void SetHoriAxisTotalInterval()
        {
            this.uctChart1.SetHoriAxisTotalInterval();
        }

        public void ReSetPreLine()
        {
            this.uctChart1.ReSetPreLine();
            this.uctChart1.RefreshBDControl(true);
        }

        public void RefreshBDControl()
        {
            this.uctChart1.RefreshBDControl(true);
        }

        public void SetFittingByAllPoints()
        {
            this.uctChart1.SetFittingByAllPoints();
        }

        public void SetFittingByNonAllPoints()
        {
            this.uctChart1.SetFittingByNonAllPoints();
        }

        public void EditPreLine()
        {
            FrmFastSetDecStatus ffsds = new FrmFastSetDecStatus(uctChart1.decParams, this.uctChart1.BDChart.DrawChart);
            if (ffsds.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.uctChart1.Refresh();
            }
        }
    }
}