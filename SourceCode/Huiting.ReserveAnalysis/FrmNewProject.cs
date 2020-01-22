﻿using DevExpress.XtraEditors;
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

            var evalOption = InitEvaluationOptionsDto( DateTime.Now);
            this.uctEvaluationOptions1.InitControl(evalOption);
            this.uctNewTreeByTree1.InitFirstData(lstProjectData);
        }

        /// <summary>
        /// 初始化评估选项
        /// </summary>
        /// <param name="proID"></param>
        /// <param name="ycqsrq"></param>
        /// <returns></returns>
        private EvaluationOptionsDto InitEvaluationOptionsDto(DateTime ycqsrq)
        {
            EvaluationOptionsDto evaluationOptionsDto = new EvaluationOptionsDto();
            evaluationOptionsDto.PJND = ycqsrq.ToString("yyyyMM");
            evaluationOptionsDto.StartNY = ycqsrq.ToString("yyyyMM");
            evaluationOptionsDto.EndNY = ycqsrq.AddMonths(DefaultConfig.Instance.EvaluationOptions.LimitedTime * 12 - 1).ToString("yyyyMM");
            evaluationOptionsDto.ZXNY = ycqsrq.AddMonths(-1).ToString("yyyyMM");
            evaluationOptionsDto.NZXL = DefaultConfig.Instance.EvaluationOptions.Nzxl;
            evaluationOptionsDto.YFQCL = DefaultConfig.Instance.EvaluationOptions.YFqcl;
            evaluationOptionsDto.QFQCL = DefaultConfig.Instance.EvaluationOptions.QFqcl;

            return evaluationOptionsDto;
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

                    //获取项目数据
                    ProjectInfoDto projectInfoDto = GetProjectInfoDtoByControls(this.curData);
                    EvaluationOptionsDto evalOptionDto = uctEvaluationOptions1.GetData();

                    BackgroundWorker bgwSave = new BackgroundWorker();
                    bgwSave.WorkerReportsProgress = true;
                    bgwSave.DoWork += BgwSave_DoWork;
                    bgwSave.ProgressChanged += BgwSave_ProgressChanged;
                    bgwSave.RunWorkerCompleted += BgwSave_RunWorkerCompleted;
                    bgwSave.RunWorkerAsync(Tuple.Create<ProjectInfoDto, EvaluationOptionsDto>(projectInfoDto, evalOptionDto));
                }

                #endregion
            }
        }

        private void BgwSave_DoWork(object sender, DoWorkEventArgs e)
        {
            var paramValue = e.Argument as Tuple<ProjectInfoDto, EvaluationOptionsDto>;
            var bgwSave = sender as BackgroundWorker;
            e.Result = DapperHelper.SQLLiteSession<bool>((conn, trans) =>
            {
                //获取项目sql
                var typeProj = typeof(ProjectInfoDto);
                string sqlProj = SqlGenerator.GetInsertSqlByModel(typeProj, true);

                //返回项目ID
                long proID = DapperHelper.ExecuteScalar<long>(conn, sqlProj, paramValue.Item1, trans);
                bgwSave.ReportProgress(50, "项目的信息录入成功");

                //获取评估sql
                var typeEval = typeof(EvaluationOptionsDto);
                string sqlEval = SqlGenerator.GetInsertSqlByModel(typeEval);

                paramValue.Item2.ProID = proID;

                DapperHelper.ExecuteScalar<long>(conn, sqlEval, paramValue.Item2, trans);
                bgwSave.ReportProgress(100, "项目的评估信息录入成功");

                return true;
            });
        }

        private void BgwSave_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProgressTip.Text = e.UserState.ToString();
            progressBar1.Value = e.ProgressPercentage;
        }

        private void BgwSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool result = (bool)e.Result;
            if (result)
                lblProgressTip.Text = "项目创建成功";
            else
                lblProgressTip.Text = "项目创建失败";
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