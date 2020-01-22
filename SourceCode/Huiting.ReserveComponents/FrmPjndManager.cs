

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Huiting.Common;
using ReserveCommon;

namespace ReserveComponents
{
    public partial class FrmPjndManager : Form
    {
        bool isModify = false;
        public bool IsModify
        {
            get
            {
                return isModify;
            }
        }

        public bool CurPjndDelete
        {
            get
            {
                return curPjndDelete;
            }
        }

        bool curPjndDelete = false;

        string curPjnd;
        string proID;
        DataTable dtOptions;

        public string NewPjnd
        {
            get
            {
                if (lvPjnd.Items.Count > 0)
                    return lvPjnd.Items[0].Text;
                return null;
            }
        }

        public string CurPjnd
        {
            get
            {
                return curPjnd;
            }
        }

        public FrmPjndManager(string proID, string CurPjnd)
        {
            InitializeComponent();
            this.proID = proID;
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
            EvaluationOptionsService eos = new EvaluationOptionsService();
            this.dtOptions = eos.GetDictPjnd(proID);
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
                ListViewItem lvi = new ListViewItem(dr[0].ToString());
                if (lvi.Text == this.CurPjnd)
                    lvi.ForeColor = Color.Blue;
                lvPjnd.Items.Add(lvi);
            }

            lvPjnd.EndUpdate();
        }

        private bool DeletePJND(string proID, string pjnd)
        {
            if (curPjndDelete == false && pjnd == CurPjnd)
                curPjndDelete = true;

            //string err;
            //EvaluationOptionsService eos = new EvaluationOptionsService();
            //err = eos.DeleteAllPjndInfo(proID, pjnd);
            //if (string.IsNullOrEmpty(err) == false)
            //{
            //    PublicMethods.WarnMessageBox("删除评价年度数据失败，原因：\n" + err);
            //    return false;
            //}
            EvaluationOptionsService eos = new EvaluationOptionsService();
            C_DeletePJNDInfo opDelPJND = new C_DeletePJNDInfo(this, proID, pjnd, eos.DBAccessEx);
            opDelPJND.DeletePJND();

            return true;
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (lvPjnd.Items.Count <= 1)
            {
                PublicMethods.WarnMessageBox(this, "必须保留一个评价年度，若想全部删除可以删除项目！");
                return;
            }

            List<string> lstPjnd = GetLstPjnd();
            if (WinPublicMethods.AskQuestion(this, "是否删除评价年度 " + PublicMethods.GetStringByLstString(lstPjnd) + "及其相关数据？"))
            {
                foreach (string item in lstPjnd)
                    DeletePJND(proID, item);

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

    }

    public class C_DeletePJNDInfo
    {
        string ProID = "";
        string PJND = "";
        Form parentForm = null;
        string ErrMsg = "";
        int TableCount = 0;
        int RowsCount = 0;
        bool ShowMessage = true;
        public C_DeletePJNDInfo(Form parentForm, string ProID, string PJND, DbAccess opDB)
        {
            this.parentForm = parentForm;
            this.ProID = ProID;
            this.PJND = PJND;
            this.opDB = opDB;
        }

        public void DeletePJND()
        {
            curPForm = new ProgressForm("正在删除评价年度数据……");
            curPForm.Show(parentForm);

            BackgroundWorker curWork = new BackgroundWorker();
            curWork.WorkerSupportsCancellation = true;
            curWork.DoWork += curWork_DoWork;
            curWork.RunWorkerAsync();
            while (curWork.IsBusy)
            {
                try
                {
                    Application.DoEvents();
                }
                catch (Exception E)
                { }

            }

            curPForm.Close();
            if (!ShowMessage)
                return;
            string Msg = "";
            Msg = "共删除了 " + TableCount.ToString() + " 张表，" + RowsCount.ToString() + " 条数据。";

            if (string.IsNullOrEmpty(ErrMsg))
            {
                Msg = "删除成功！\n" + Msg;
            }
            else
            {
                Msg += "\n中间出现错误：" + ErrMsg;
            }
            MessageBox.Show(parentForm, Msg);

        }



        void curWork_DoWork(object sender, DoWorkEventArgs e)
        {
            opDB.BeginTransaction();
            DeleteTable("BiaoDingStatus", ProID, PJND);
            DeleteTable("BiaoDingValue", ProID, PJND);
            //DeleteTable("DYDAB01", ProID, PJND);



            DeleteTable("EconomicCZCB", ProID, PJND);
            DeleteTable("EconomicParams", ProID, PJND);
            DeleteTable("EconomicParamSet", ProID, PJND);
            DeleteTable("EconomicPFCB", ProID, PJND);



            DeleteTable("EconomicTZ", ProID, PJND);
            DeleteTable("EconParams", ProID, PJND);



            DeleteTable("EvaluationOptions", ProID, PJND);
            DeleteTable("EvaluationResult", ProID, PJND);

            string CondtionStr = "select GCID from GCGroupCondition where ProID='" + ProID + "' and PJND='" + PJND + "'";
            string StrSQL = "delete from GCGroupData where GCID in(" + CondtionStr + ")";
            DeleteSQL(StrSQL);
            StrSQL = "delete from GroupJH where GCID in(" + CondtionStr + ")";
            DeleteSQL(StrSQL);

            DeleteTable("GCGroupCondition", ProID, PJND);



            CondtionStr = "select prelineID from PreLine where ProID='" + ProID + "' and PJND='" + PJND + "'";
            StrSQL = "delete from PreLinePart where preLineID in(" + CondtionStr + ")";
            DeleteSQL(StrSQL);
            StrSQL = "delete from PreMonthData where preLineID in(" + CondtionStr + ")";
            DeleteSQL(StrSQL);

            DeleteTable("PreLine", ProID, PJND);
            opDB.Commit();
        }




        private void DeleteTable(string TableName, string ProID, string PJND)
        {
            TableCount++;
            string strSQL = "delete from " + TableName + " where ProID='" + ProID + "' and PJND='" + PJND + "'";
            try
            {
                RowsCount += opDB.ExecSqlReturnCount(strSQL);
            }
            catch (Exception E)
            {
                ErrMsg += "\n更新表：" + TableName + " 失败，错误：" + E.Message;
            }

        }


        private void DeleteSQL(string StrSQL)
        {
            try
            {
                RowsCount += opDB.ExecSqlReturnCount(StrSQL);

            }
            catch (Exception E)
            {

                ErrMsg += "\n执行SQL[ " + StrSQL + "] 失败，错误：" + E.Message;

            }
        }
    }
}