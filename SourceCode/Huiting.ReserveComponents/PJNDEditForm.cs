using BDSoft.DBAccess;
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
using ReserveCommon;

namespace ReserveComponents
{
    public partial class PJNDEditForm : Form
    {
        bool isModify = false;
        public bool IsModify
        {
            get { return isModify; }
        }
        DBAccessEx dbAccess = null;
        int DelCount = 0;
        string curPjnd;
        DataTable dtOptions;

        public PJNDEditForm(string CurPjnd)
        {
            InitializeComponent();
            this.curPjnd = CurPjnd;
        }

        private void PJNDEditForm_Load(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            dbAccess = new DBAccessEx(GlobalInfo.Instance.LocalDBFile);
            //InternalMethods.UpdateDTOptions(dbAccess);
            this.dtOptions = dbAccess.GetDataTable("select * from EvaluationOptions where nodeid ='0'");
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                WinPublicMethods.WarnMessageBox(this, "异常：" + e.Error.Message);
                return;
            }

            lvPjnd.BeginUpdate();
            lvPjnd.Items.Clear();

            foreach (DataRow dr in dtOptions.Rows)
            {
                ListViewItem lvi = AddListViewItem(dr);
                if (lvi.Text == this.curPjnd)
                    lvi.ForeColor = Color.Blue;
            }

            lvPjnd.EndUpdate();
        }

        private ListViewItem AddListViewItem(DataRow dr)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = dr["pjnd"].ToString();
            lvi.SubItems.Add(dr["startNY"].ToString());
            lvi.SubItems.Add(dr["EndNY"].ToString());
            lvi.SubItems.Add(dr["zxNY"].ToString());
            lvi.SubItems.Add(dr["nzxl"].ToString());
            lvi.SubItems.Add(dr["WasteOutput"].ToString());
            lvi.Tag = dr;
            lvPjnd.Items.Add(lvi);

            return lvi;
        }

        private void UpdateListViewItem(ListViewItem lvi, DataRow dr)
        {
            lvi.Text = dr["pjnd"].ToString();
            lvi.SubItems[1].Text = dr["startNY"].ToString();
            lvi.SubItems[2].Text = dr["EndNY"].ToString();
            lvi.SubItems[3].Text = dr["zxNY"].ToString();
            lvi.SubItems[4].Text = dr["nzxl"].ToString();
            lvi.SubItems[5].Text = dr["WasteOutput"].ToString();
            lvi.Tag = dr;
        }

        private bool JugeExist(string NewPJND)
        {
            foreach (ListViewItem curItem in lvPjnd.Items)
            {
                if (curItem.Text == NewPJND)
                {
                    return true;
                }
            }

            return false;
        }

        private bool DelPJND(string DelPJND)
        {
            dbAccess.BeginTransaction();
            string strSQl = "";
            DelCount = 0;

            try
            {
                strSQl = "delete from DYResult where pjnd='" + DelPJND + "'";
                DelCount += dbAccess.ExecSqlReturnCount(strSQl);

                strSQl = "delete from DyBaseInfo where pjnd='" + DelPJND + "'";
                DelCount += dbAccess.ExecSqlReturnCount(strSQl);

                strSQl = "delete from EconEvalResult where pjnd='" + DelPJND + "'";
                DelCount += dbAccess.ExecSqlReturnCount(strSQl);

                strSQl = "delete from EconEvalResultByDy where pjnd='" + DelPJND + "'";
                DelCount += dbAccess.ExecSqlReturnCount(strSQl);

                strSQl = "delete from EconomicParams where pjnd='" + DelPJND + "'";
                DelCount += dbAccess.ExecSqlReturnCount(strSQl);

                strSQl = "delete from EconomicParamSet where pjnd='" + DelPJND + "'";
                DelCount += dbAccess.ExecSqlReturnCount(strSQl);

                strSQl = "delete from EconomicQYB where pjnd='" + DelPJND + "'";
                DelCount += dbAccess.ExecSqlReturnCount(strSQl);

                strSQl = "delete from EconParamCZCB where pjnd='" + DelPJND + "'";
                DelCount += dbAccess.ExecSqlReturnCount(strSQl);

                strSQl = "delete from EvaluationOptions where pjnd='" + DelPJND + "'";
                DelCount += dbAccess.ExecSqlReturnCount(strSQl);

                strSQl = "delete from Res_Series_YCData where pjnd='" + DelPJND + "'";
                DelCount += dbAccess.ExecSqlReturnCount(strSQl);

                strSQl = "delete from YCData where pjnd='" + DelPJND + "'";
                DelCount += dbAccess.ExecSqlReturnCount(strSQl);

                strSQl = "delete from YCLBData where pjnd='" + DelPJND + "'";
                DelCount += dbAccess.ExecSqlReturnCount(strSQl);

                strSQl = "delete from DYKCCLGuide where pjnd='" + DelPJND + "'";
                DelCount += dbAccess.ExecSqlReturnCount(strSQl);
                dbAccess.Commit();
            }
            catch (Exception E)
            {
                dbAccess.RollBack();
                PublicMethods.WarnMessageBox("删除评价年度数据失败，原因：\n" + E.Message);
                return false;
            }

            return true;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            DateTime dtNext = FrmPjndEdit.SubGetNewPjnd(dtOptions, DateTime.Now);
            DataRow dr = dtOptions.NewRow();

            dr["nodeid"] = "0";
            dr["pjnd"] = dr["startNY"] = dtNext.ToString("yyyyMM");
            //int limitedTime = ConfigInfo.Instance.GetValue(ConfigKey.LimitedTime).ToInt();
            int limitedTime ;//= ConfigInfo.Instance.GetValue(ConfigKey.LimitedTime).ToInt();
            //if (limitedTime <= 0)
                limitedTime = 100;
            dr["EndNY"] = dtNext.AddYears(limitedTime).AddMonths(-1).ToString("yyyyMM");
            dr["zxNY"] = dtNext.AddMonths(-1).ToString("yyyyMM");

            DataTable dtOptionDefault = this.dbAccess.GetDataTable("select * from EvaluationOptionsDefault");
            if (dtOptionDefault == null || dtOptionDefault.Rows.Count <= 0)
            {
                dr["nzxl"] = 10;
                dr["WasteOutput"] = 10;
            }
            else
            {
                dr["nzxl"] = dtOptionDefault.Rows[0]["nzxl"];
                dr["WasteOutput"] = dtOptionDefault.Rows[0]["WasteOutput"];
            }


            FrmPjndEdit fpe = new FrmPjndEdit(dr, dtOptions);
            if (fpe.ShowDialog(this) == DialogResult.OK)
            {
                dtOptions.Rows.Add(dr);

                dbAccess.CurUpdateType = UpdateTableType.Normal;
                if (dbAccess.UpdateDateTable(dtOptions, "select * from EvaluationOptions"))
                {
                    isModify = true;
                    lvPjnd.SelectedItems.Clear();
                    ListViewItem lvi = AddListViewItem(dr);
                    lvi.Selected = true;
                }

                dtOptions.AcceptChanges();
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (lvPjnd.SelectedItems.Count <= 0)
                return;

            DataRow dr = lvPjnd.SelectedItems[0].Tag as DataRow;
            FrmPjndEdit fpe = new FrmPjndEdit(dr, dtOptions);
            if (fpe.ShowDialog(this) == DialogResult.OK)
            {
                dbAccess.CurUpdateType = UpdateTableType.Normal;
                if (dbAccess.UpdateDateTable(dtOptions, "select * from EvaluationOptions"))
                {
                    isModify = true;
                    UpdateListViewItem(lvPjnd.SelectedItems[0], dr);
                }

                dtOptions.AcceptChanges();
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (lvPjnd.SelectedItems.Count <= 0)
            {
                return;
            }

            List<string> lstPjnd = GetLstPjnd();
            if (WinPublicMethods.AskQuestion(this, "是否删除评价年度 " + PublicMethods.GetStringByLstString(lstPjnd) + "及其相关数据？"))
            {
                foreach (string item in lstPjnd)
                    DelPJND(item);

                //MyMethod.ShowMessage(this, "删除评价年度成功，同时删除相关数据：" + DelCount.ToString() + "条。");
                for (int i = lvPjnd.SelectedItems.Count - 1; i >= 0; i--)
                    lvPjnd.SelectedItems[i].Remove();

                isModify = true;
            }
        }

        private List<string> GetLstPjnd()
        {
            List<string> lstPjnd = new List<string>();
            foreach (ListViewItem item in lvPjnd.SelectedItems)
            {
                lstPjnd.Add(item.Text);
            }

            return lstPjnd;
        }

        private void lvPjnd_DoubleClick(object sender, EventArgs e)
        {
            if (lvPjnd.SelectedItems.Count <= 0)
                return;

            tsbEdit.PerformClick();
        }

        private void tsbDelPjnd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tstPjnd.Text))
            {
                WinPublicMethods.WarnMessageBox(this, "指定的评价年度为空无法清除！");
                return;
            }

            string pjnd = tstPjnd.Text.Trim();
            if (WinPublicMethods.AskQuestion(this, "是否删除评价年度 " + pjnd + " 及其相关数据？"))
            {
                DelPJND(pjnd);
                isModify = true;
            }
        }
    }
}