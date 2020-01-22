using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using HelpInfoManage;
using Huiting.DataEditor;
using Huiting.DBAccess.Entity.Dtos;
using Huiting.DBAccess.Service;
using ReserveCommon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ReserveAnalysis
{
    public partial class FrmMain :XtraForm //Form
    {
        #region Properties & Fields


        FrmLeft frmLeft;
        //工作平台
        FrmWorkbench frmWorkBench;

        EvaluationOptionsDto curEvalOptionDto;

        IAssetsData assetsData;
        
        #endregion

        #region Constructor

        public FrmMain()
        {
            InitializeComponent();
            //必须要设置，否则影响DockPanel的使用
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
            this.barStaticItem_AppInfo.Caption = "";
        }

        #endregion

        #region Event

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


            SwitchControl(true);
        }

        //切换项目目录和项目详细信息
        private void SwitchControl(bool projectsVisible)
        {
            if (projectsVisible)
            {
                this.dockPanel1.Visible = false;
                this.uflpProject.Visible = true;
                this.uflpProject.Dock = DockStyle.Fill;
                this.InitControlEnabled(false);
                this.uflpProject.AsyncLoadData(OpenProject);
            }
            else
            {
                this.uflpProject.Visible = false;
                this.dockPanel1.Dock = DockStyle.Fill;
                this.dockPanel1.Visible = true;
                this.InitControlEnabled(true);
            }
        }

        private void OpenProject(ProjectData data)
        {
            SwitchControl(false);

            ////设置选中的界面
            //DYDAB01Service dyDab01 = new DYDAB01Service();
            //if (dyDab01.ExistAssets(data.ID))
            //    ribbonControl1.SelectedPage = this.rpAnalysis;
            //else
            //    ribbonControl1.SelectedPage = this.rpData;

     
            //先初始化评价年度
            UpdateMainLstFrmForPjndChanged(uflpProject.CurData.ID,  false);
            //再初始化左侧树
            UpdateMainLstFrmForLeftTreeChanged(uflpProject.CurData);
            ////创建窗体间消息通知类
            //if (opNotify == null)
            //    opNotify = new OpNotifyMessageClass(curProData, dockPanel1, frmLeft, barBPJND);
        }

        /// <summary>
        /// 初始化Ribbin的评价年度的下拉框
        /// </summary>
        /// <param name="proID"></param>
        /// <param name="curPjnd"></param>
        /// <param name="isRefreshMainLstFrm"></param>
        private void UpdateMainLstFrmForPjndChanged(string proID, bool isRefreshMainLstFrm)
        {
            //读取用户上次信息
            string curPjnd = ConfigInfo.Instance.GetValue("pjnd");

            this.barBPJND.EditValueChanged -= new System.EventHandler(this.barBPJND_EditValueChanged);
            var evalOptions = new EvaluationOptionService().GetEvaluationOptionsDto(uflpProject.CurData.ID).ToList();

            RepositoryItemComboBox ric = this.barBPJND.Edit as RepositoryItemComboBox;
            ric.Items.Clear();
            foreach (var item in evalOptions)
                ric.Items.Add(item.PJND);

            int index = evalOptions.FindIndex(x => x.PJND == curPjnd);
            if (index >= 0)
            {
                barBPJND.EditValue = curPjnd;
                curEvalOptionDto = evalOptions[index];
            }
            else
            {
                barBPJND.EditValue = evalOptions[0].PJND;
                curEvalOptionDto = evalOptions[0];
            }
                
            //保存用户打开的信息
            ConfigInfo.Instance.SetValue("pjnd", barBPJND.EditValue.ToString());

            this.barBPJND.EditValueChanged += new System.EventHandler(this.barBPJND_EditValueChanged);
        }


        private void barBPJND_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void UpdateMainLstFrmForLeftTreeChanged(ProjectData data)
        {
            //否则是打开工程
            if (frmLeft == null || frmLeft.IsDisposed)
            {
                frmLeft = new FrmLeft();
                //frmLeft.GetLstProjectDataEvent -= frmLeft_GetLstProjectDataEvent;
                //frmLeft.GetLstProjectDataEvent += frmLeft_GetLstProjectDataEvent;
                frmLeft.SwitchProject -= frmLeft_SwitchProject;
                frmLeft.SwitchProject += frmLeft_SwitchProject;
                //frmLeft.AfterSelect -= frmLeft_AfterSelect;
                //frmLeft.AfterSelect += frmLeft_AfterSelect;
                frmLeft.LoadDataCompleted -= frmLeft_LoadDataCompleted;
                frmLeft.LoadDataCompleted += frmLeft_LoadDataCompleted;
                frmLeft.AssetsAdd -= frmLeft_AssetsAdd;
                frmLeft.AssetsAdd += frmLeft_AssetsAdd;
                frmLeft.AssetsEdit -= frmLeft_AssetsEdit;
                frmLeft.AssetsEdit += frmLeft_AssetsEdit;
                frmLeft.AssetsDelete -= frmLeft_AssetsDelete;
                frmLeft.AssetsDelete += frmLeft_AssetsDelete;
                this.frmLeft.Show(this.dockPanel1, DockState.DockLeft);
                this.frmLeft.DockPanel.DockLeftPortion = 0.2;
                this.frmLeft.AutoHidePortion = 0.2;
            }
            else
                frmLeft.Visible = true;
            this.frmLeft.LoadData(data);
        }

        private void frmLeft_SwitchProject(object sender, EventArgs e)
        {
            SwitchControl(true);
        }

        private void frmLeft_LoadDataCompleted(object sender, EventArgs e)
        {
            InitFrmWorkbench(uflpProject.CurData);
            this.frmLeft.SetTreeNodeSelected(GlobalInfo.TreeRootID);

            if (frmLeft != null)
                frmLeft.Focus();
        }

        private void InitFrmWorkbench(IEntityData entityData)
        {
            if (frmWorkBench == null || frmWorkBench.IsDisposed)
            {
                frmWorkBench = new FrmWorkbench();
                this.frmWorkBench.CloseButtonVisible = false;
                this.frmWorkBench.SelectedNodeChanged -= frmWorkBench_SelectedNodeChanged;

                this.frmWorkBench.Show(this.dockPanel1);

                this.frmWorkBench.SelectedNodeChanged += frmWorkBench_SelectedNodeChanged;
            }
            else
                frmWorkBench.Visible = true;
        }

        void frmWorkBench_SelectedNodeChanged(object sender, EventArgs e)
        {
            FunctionData functionData = sender as FunctionData;
            if (functionData != null)
                RunFunction(functionData.FunctionType);
            else
            {
                IEntityData data = sender as IEntityData;
                if (data == null)
                    return;
                frmLeft.SetTreeNodeSelected(data.ID);
            }
        }

        private void RunFunction(UnitFunctionType unitFunctionType)
        {
            switch (unitFunctionType)
            {
                //case UnitFunctionType.JiBenXinXI:
                //    RunUnitBaseInfoEdit();
                //    break;
                //case UnitFunctionType.SQTZJia:
                //    RunSQQX(TechType.TypeA);
                //    break;
                //case UnitFunctionType.SQTZYi:
                //    RunSQQX(TechType.TypeB);
                //    break;
                //case UnitFunctionType.SQTZBing:
                //    RunSQQX(TechType.TypeC);
                //    break;
                //case UnitFunctionType.SQTZDing:
                //    RunSQQX(TechType.TypeD);
                //    break;
                //case UnitFunctionType.LaQiFenXi:
                //    InitFrmLQ(StudyType.LQFX);
                //    break;
                //case UnitFunctionType.DJQXChanLiangDuiShiJian:
                //    InitDYChartWindow();
                //    break;
                //case UnitFunctionType.DJQXYueChanDuiLeiChan:
                //case UnitFunctionType.DJQXHanYouLvDuiLeiChan:
                //case UnitFunctionType.DJQXHanShuiLvDuiLeiChan:
                //case UnitFunctionType.DJQXShuiYouBiDuiLeiChan:
                //    RunLeiChan(unitFunctionType);
                //    break;
                //case UnitFunctionType.YuCeChaLiangShuJu:
                //    InitFromForecastOutPut();
                //    break;
                //case UnitFunctionType.JingJiPingJia:
                //    RunJJPJ();
                //    break;
                //case UnitFunctionType.MinGanXingFenXi:
                //    List<AssetsData> lstAssetsData = frmLeft.GetSelChildAssetsList();
                //    FrmAnalysis3 fa3 = new FrmAnalysis3(curProData, pjnd, frmLeft.SelectedEntityData, lstAssetsData);
                //    fa3.ShowDialog();
                //    break;
                //case UnitFunctionType.DanYuanShuJu:
                //    UnitDevelopMonthInfoForm formDY = new UnitDevelopMonthInfoForm(decParams, localService.DBAccess);
                //    formDY.ShowDialog(this);
                //    if (formDY.IsModify && dyChartWindow != null && dyChartWindow.IsDisposed == false)
                //    {
                //        dyChartWindow.Init(decParams);
                //    }
                //    formDY.Dispose();
                //    break;
                //case UnitFunctionType.DanJingShuJu:
                //    WellDevelopMonthInfoForm formDJ = new WellDevelopMonthInfoForm(decParams, localService.DBAccess);
                //    formDJ.ShowDialog(this);
                //    formDJ.Dispose();
                //    break;
                //case UnitFunctionType.BaoGaoShuChu:
                //    RunSECXJLL();
                //    break;
                //case UnitFunctionType.KPMGBaoBiao:
                //    break;
                //case UnitFunctionType.KaiChuBiao:
                //    break;
                //case UnitFunctionType.TongXianZhangTuBanFa:
                //    break;
                //case UnitFunctionType.JingJiPingJiaCanShu:
                //    barEconomicParam_ItemClick(null, null);
                //    break;
                //case UnitFunctionType.JingYanGongShi:
                //    break;
                //default:
                //    break;
            }
        }

        //初始化Ribbon按钮状态
        private void InitControlEnabled(bool enabled)
        {
            InitRibbonPageGroupEnabled(rpData, enabled);
            InitRibbonPageGroupEnabled(rpAnalysis, enabled);
            InitRibbonPageGroupEnabled(rpEconomic, enabled);
            InitRibbonPageGroupEnabled(rpResult, enabled);
            InitRibbonPageGroupEnabled(rpTool, enabled);
        }

        private void InitRibbonPageGroupEnabled(RibbonPage rp, bool enabled)
        {
            foreach (RibbonPageGroup item in rp.Groups)
            {
                item.Enabled = enabled;
            }
        }

        #endregion
        
        //界面初始化，启动定时器，校验用户
        private void FrmMain_Shown(object sender, EventArgs e)
        {

        }

        #region 菜单栏——数据

        //调用数据导入功能
        private void barFImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDataImport frmDataImport = new FrmDataImport();
            if (frmDataImport.ShowDialog() == DialogResult.OK)
            {

            }

            //using (DataImportForm form = new DataImportForm(curProData, pjnd, localService.DBAccess))
            //{
            //    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            //    {
            //        UpdateMainLstFrmForPjndChanged(curProData.ID, pjnd, true);
            //        UpdateMainLstFrmForLeftTreeChanged(curProData, pjnd);
            //    }
            //}
        }


        //数据导出
        private void barFExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        //单元基础信息数据，批量维护界面
        private void barDDYJCSJ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        //调用单元开发数据维护
        private void barDDYKFSJ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        //调用单井开发数据维护
        private void barDDJSJ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        //数据库备份
        private void bar_DBBackup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        //升级日志
        private void btn_UpdateInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        //系统退出
        private void barFClose_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        #endregion

        #region 菜单栏——预测分析

        //曲线指标项
        private void barBQXYS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barBBTXX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (frmDecSegment == null || frmDecSegment.IsDisposed)
            //    frmDecSegment = new FrmDecSegment();
            //frmDecSegment.Show(this.dockPanel1, DockState.DockBottom);
        }

        //竖选点
        private void barBSXD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }
        //竖删点
        private void barBSSD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        //横选点
        private void barBHXD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        //横删点
        private void barBHSD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
        }

        //框选择点
        private void barBKXD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        //框删点
        private void barBKSD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
    
        }

        //预测线分段
        private void barBYCXFD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        //新增评价年度
        private void barBAddPjnd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
        }

        //删除评价年度
        private void barBDelPjnd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        //应用
        private void barBYingYong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        //标定设置
        private void barBBDSZ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        //编辑历史预测线
        private void barBLSYC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        //构成法
        private void barGCFX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void dockPanel1_ActiveDocumentChanged(object sender, EventArgs e)
        {

        }

        private List<string> GetLstPjnd()
        {
            List<string> lstPjnd = new List<string>();
            RepositoryItemComboBox ric = this.barBPJND.Edit as RepositoryItemComboBox;
            foreach (string item in ric.Items)
            {
                lstPjnd.Add(item);
            }

            return lstPjnd;
        }

        //历史导入
        private void barAHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        //运行单元基本信息维护
        private void RunUnitBaseInfoEdit()
        {
       
        }
        //添加新的单元资产信息
        void frmLeft_AssetsAdd(object sender, EventArgs e)
        {

        }

        //资产删除
        void frmLeft_AssetsDelete(object sender, EventArgs e)
        {
           
        }

        //资产编辑
        void frmLeft_AssetsEdit(object sender, EventArgs e)
        {
            RunUnitBaseInfoEdit();
        }
        //曲线比例调整
        private void barBZYYY_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }
        //曲线比例调整
        private void barBYYYY_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        //曲线比例调整
        private void barBZYYG_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        //曲线比例调整
        private void barBYYYG_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        //曲线比例调整
        private void barBSYYG_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        //曲线比例调整
        private void barBXYYG_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


        }

        bool isScroll = false;
        //滚轮缩放
        private void barBGLSF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        //开发数据
        private void barBSJCK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        //图片另存
        private void barBTTBC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
        }
        //递减段状态
        private void barBDJZT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


           
        }
        //预测线删除
        private void barBShanChu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        //选择
        private void barBXuanZe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        //全选
        private void barBQuanXuan_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        //全删
        private void barBQuanShan_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        //选单点
        private void barBXDD_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        //删单点
        private void barBSDD_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

   
        //打印图片
        private void barBDaYin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        //气油比设置
        private void barQybSet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        //恢复比例
        private void barBHFBL_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        //重置预测结果
        private void barBCZYYJG_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        //刷新历史预测线
        private void barBShuaXin_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        #endregion

        #region 菜单栏——辅助工具

        //默认值
        private void barPDefault_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDefaultValue fdv = new FrmDefaultValue();
            fdv.ShowDialog(this);
        }
        //单位转换工具
        private void btn_ConverTool_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        //产量与时间
        private void barACLVSTIME_ItemClick(object sender, ItemClickEventArgs e)
        {
        }
        //甲型水驱
        private void barASQTZJia_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        //乙型水驱
        private void barASQTZYi_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        //丙型水驱
        private void barASQTZBing_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        //丁型水驱
        private void barASQTZDing_ItemClick(object sender, ItemClickEventArgs e)
        {

        }


        private void bar_FZ_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (DockContent frm in this.dockPanel1.Contents)
            {
                string FormTitle = ((Form)frm).Text;

                if (FormTitle == "井分组分析")//(frm.GetType().Name == "LQMainForm")
                {
                    frm.Activate();
                    //frm.Visible = true;
                    return;
                }
            }

          
        }

        //拉齐分析
        private void barALQFX_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        //失控可采
        private void bar_SK_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        //扶停可采
        private void bar_FT_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        //系统修复
        private void barBSysUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        //修复数据库
        private void barBDBUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        //升级日志
        private void barBLogUpdata_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        //数据库备份
        private void barBBackUp_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }


        #endregion

        #region 菜单栏——经济评价

        private void RunJJPJ()
        {
         
        }
        //经济参数
        private void barEconomicParam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }
        //经济评价
        private void barBJJPJ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RunJJPJ();
        }
        /// <summary>
        /// 现金流量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barRSECXJLL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RunSECXJLL();
        }

        //现金流量
        private void RunSECXJLL()
        {

        }
        //统计表
        private void barButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //HyperbolicAlgorithm ha = new HyperbolicAlgorithm();
            //ha.Test();
        }
        #endregion

        #region 菜单栏——分析结果

        //预测产量数据
        private void barRYCCLSJ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        //图片导出
        private void barRExportImageList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        /// <summary>
        /// 分析结果汇总
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bar_ResultReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        //评估笔记
        private void barBEvalNote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        //分析结果上传
        private void barRUpLoad_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        //分析结果下载
        private void barRDown_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        #endregion

        #region 帮助

        //关于
        private void barHAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmAbout af = new FrmAbout();
            af.ShowDialog(this);
            af.Dispose();
        }

        //帮助
        private void barHHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            HelpInfoManageForm hief = new HelpInfoManageForm();
            hief.StartPosition = FormStartPosition.CenterScreen;
            hief.ShowDialog(this);
        }

        //系统注册
        private void bar_GetRegInfo_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        #endregion

        private void barBMinGanXingFenXi_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void bar_LCXZ_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem44_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barBDecEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        
        private void barBCompress_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

    }
}