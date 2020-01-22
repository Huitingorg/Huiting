using DevExpress.XtraEditors;
using Huiting.Common;
using Huiting.DBAccess;
using Huiting.DBAccess.Entity.Dtos;
using Huiting.DBAccess.Helpers;
using ReserveCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;

namespace ReserveAnalysis
{
    public partial class FrmNewProject : XtraForm
    {
        ProjectData curData;
        List<ProjectData> lstProjectData;

        public ProjectData CurData { get => curData; set => curData = value; }

        public FrmNewProject(List<ProjectData> LstProjectData)
        {
            InitializeComponent();

            this.ShowIcon = false;
            this.StartPosition = FormStartPosition.CenterParent;

            this.curData = CurData;
            this.lstProjectData = LstProjectData;

            InitProject(lstProjectData, ref this.curData);
        }

        private void InitControls(List<ProjectData> lstProjectData)
        {
            this.txtName.Text = curData.Text;
            if (string.IsNullOrWhiteSpace(curData.Desciption))
                this.txtBZ.Text = $"这是{curData.Text}的注释";
            else
                this.txtBZ.Text = curData.Desciption;

            this.uctEvaluationOptions1.InitControl();
            this.uctNewTreeByTree1.InitFirstData(lstProjectData);
        }

        /// <summary>
        /// 初始化新增项目时的状态
        /// </summary>
        /// <param name="lstProjectData"></param>
        /// <param name="curData"></param>
        /// <returns></returns>
        private void InitProject(List<ProjectData> lstProjectData, ref ProjectData curData)
        {
            this.Text = "新建工程";
            this.checkBox1.Visible = lstProjectData.Count >= 1;

            //新工程默认名
            var projectNameAry = lstProjectData.Select(x => x.Text).ToArray();
            int id = PublicMethods.CreateNewNameIndex(projectNameAry, "工程");
            //新的数据对象
            curData = ProjectData.GetNewProjectData(id);

            InitControls(lstProjectData);
        }

        private ProjectInfoDto GetProjectInfoDtoByControls(ProjectData data)
        {
            data.Text = this.txtName.Text;
            data.Desciption = this.txtBZ.Text;

            return data.GetProjectInfoDto();
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private async void AsyncSaveProjectData(Action<bool> action)
        {
            CancellationTokenSource linkedTokenSource = new CancellationTokenSource();
            Func<bool> func = () =>
            {
                bool result = DapperHelper.SQLLiteSession<bool>((conn, trans) =>
                {
                    if (linkedTokenSource.IsCancellationRequested)
                    {
                        trans.Rollback();
                        return false;
                    }

                    //获取项目sql
                    var typeProj = typeof(ProjectInfoDto);
                    string sqlProj = SqlGenerator.GetInsertSqlByModel(typeProj, true);
                    //获取项目数据
                    ProjectInfoDto projectInfoDto = GetProjectInfoDtoByControls(this.curData);

                    //返回项目ID
                    long proID = DapperHelper.ExecuteScalar<long>(conn, sqlProj, projectInfoDto, trans);

                    if (linkedTokenSource.IsCancellationRequested)
                    {
                        trans.Rollback();
                        return false;
                    }

                    //获取评估sql
                    var typeEval = typeof(EvaluationOptionsDto);
                    string sqlEval = SqlGenerator.GetInsertSqlByModel(typeEval);
                    EvaluationOptionsDto evalOptionDto = uctEvaluationOptions1.GetData();
                    DapperHelper.ExecuteScalar<long>(conn, sqlEval, evalOptionDto, trans);

                    if (linkedTokenSource.IsCancellationRequested)
                    {
                        trans.Rollback();
                        return false;
                    }

                    return true;
                });
                return result;
            };

            var result2 = await TaskEx.Run<bool>(func, linkedTokenSource.Token);
            if (action != null)
                action(result2);
        }

        private void wizardControl1_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (e.Page == wpBasicInfo)
            {
                string newProjectName = txtName.Text.Trim().ToUpper();
                if (string.IsNullOrWhiteSpace(newProjectName))
                {
                    PublicMethods.TipsMessageBox(this, "请输入工程名！");
                    e.Handled = true;
                    txtName.Focus();
                    return;
                }

                if (lstProjectData.Exists(x => x.Text.ToUpper() == newProjectName))
                {
                    PublicMethods.TipsMessageBox(this, $"该工程名“{txtName.Text.Trim()}”已存在");
                    e.Handled = true;
                    txtName.Focus();
                    return;
                }
            }
            else if (e.Page == wpEval)
            {
                this.uctEvaluationOptions1.Check(() => e.Handled = true);

                #region 是否从其他工程导入资产

                if (this.checkBox1.Visible)
                {
                    if (this.checkBox1.Checked)
                    {
                        this.wizardControl1.SelectedPage = wpImport;
                        this.uctNewTreeByTree1.InitSecondData(curData);
                    }
                    else
                    {
                        this.wizardControl1.SelectedPage = wpFinished;
                        //this.SaveProjectData();
                    }
                    e.Handled = true;
                }
                else
                {
                    this.wizardControl1.SelectedPage = wpFinished;

                    Action<bool> action = (result) =>
                    {
                        if (result)
                        {
                            progressPanel1.Caption = "项目创建成功";
         
                        }
                           
                        else
                            progressPanel1.Caption = "项目创建失败";
                    };

                    this.AsyncSaveProjectData(action);

                    BackgroundWorker bgwSave = new BackgroundWorker();
                    bgwSave.DoWork += BgwSave_DoWork;
                    bgwSave.RunWorkerCompleted += BgwSave_RunWorkerCompleted;
                    bgwSave.RunWorkerAsync();
                }

                #endregion
            }
        }

        private void BgwSave_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = DapperHelper.SQLLiteSession<bool>((conn, trans) =>
            {
                //获取项目sql
                var typeProj = typeof(ProjectInfoDto);
                string sqlProj = SqlGenerator.GetInsertSqlByModel(typeProj, true);
                //获取项目数据
                ProjectInfoDto projectInfoDto = GetProjectInfoDtoByControls(this.curData);

                //返回项目ID
                long proID = DapperHelper.ExecuteScalar<long>(conn, sqlProj, projectInfoDto, trans);

                //获取评估sql
                var typeEval = typeof(EvaluationOptionsDto);
                string sqlEval = SqlGenerator.GetInsertSqlByModel(typeEval);
                EvaluationOptionsDto evalOptionDto = uctEvaluationOptions1.GetData();
                DapperHelper.ExecuteScalar<long>(conn, sqlEval, evalOptionDto, trans);

                return true;
            });
        }

        private void BgwSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool result = (bool)e.Result;
            if (result)
            {
                progressPanel1.Caption = "项目创建成功";

            }

            else
                progressPanel1.Caption = "项目创建失败";
        }

        private void wizardControl1_PrevClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (e.Page == wpFinished)
            {
                //如果选中
                if (this.checkBox1.Checked)
                    this.wizardControl1.SelectedPage = wpImport;
                else
                    this.wizardControl1.SelectedPage = wpEval;

                e.Handled = true;
            }
        }

        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void wizardControl1_CancelClick(object sender, CancelEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
