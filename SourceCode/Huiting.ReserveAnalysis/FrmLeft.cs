using ReserveCommon;
using ReserveComponents;
using System;
using System.Collections.Generic;
using WeifenLuo.WinFormsUI.Docking;

namespace ReserveAnalysis
{
    public partial class FrmLeft : DockContent
    {
        public IEntityData SelectedEntityData
        {
            get
            {
                return uctTree1.SelectedEntityData;
            }
        }

        public FrmLeft()
        {
            InitializeComponent();
            this.CloseButtonVisible = false;
        }

        public void LoadData(ProjectData Data)
        {
            uctTree1.LoadData(Data);            
            uctTree1.GetLstProjectDataEvent -= uctTree1_GetLstProjectDataEvent;
            uctTree1.GetLstProjectDataEvent += uctTree1_GetLstProjectDataEvent;
            uctTree1.SwitchProject -= uctTree1_SwitchProject;
            uctTree1.SwitchProject += uctTree1_SwitchProject;
            uctTree1.LoadDataCompleted -= uctTree1_LoadDataCompleted;
            uctTree1.LoadDataCompleted += uctTree1_LoadDataCompleted;
            uctTree1.AfterSelect -= uctTree1_AfterSelect;
            uctTree1.AfterSelect += uctTree1_AfterSelect;
            uctTree1.AssetsAdd -= uctTree1_AssetsAdd;
            uctTree1.AssetsAdd += uctTree1_AssetsAdd;
            uctTree1.AssetsDelete -= uctTree1_AssetsDelete;
            uctTree1.AssetsDelete += uctTree1_AssetsDelete;
            uctTree1.AssetsEdit -= uctTree1_AssetsEdit;
            uctTree1.AssetsEdit += uctTree1_AssetsEdit;
        }

        public void RefreshInterface()
        {
            uctTree1.RefreshInterface(); 
        }
        public void RefreshChart()
        {
            uctTree1.RefreshChart();
        }

        public event DlgGetLstProjectData GetLstProjectDataEvent;
        List<ProjectData> uctTree1_GetLstProjectDataEvent()
        {
            if (GetLstProjectDataEvent != null)
                return GetLstProjectDataEvent();
            return null;
        }

        public event EventHandler LoadDataCompleted;
        void uctTree1_LoadDataCompleted(object sender, EventArgs e)
        {
            if (LoadDataCompleted != null)
                LoadDataCompleted(sender, e);
        }

        public event EventHandler SwitchProject;
        void uctTree1_SwitchProject(object sender, EventArgs e)
        {
            if (SwitchProject != null)
                SwitchProject(sender, e);
        }

        public event DlgAfterSelected AfterSelect;

        void uctTree1_AfterSelect(List<IEntityData> lstParent, List<IEntityData> lstChild)
        {
            if (AfterSelect != null)
                AfterSelect(lstParent, lstChild);
        }

        public event EventHandler AssetsAdd;
        public event EventHandler AssetsEdit;
        public event EventHandler AssetsDelete;

        void uctTree1_AssetsAdd(object sender, EventArgs e)
        {
 	        if(AssetsAdd != null)
            {
                AssetsAdd(sender, e);
            }
        }
        void uctTree1_AssetsEdit(object sender, EventArgs e)
        {
            if(AssetsEdit != null)
            {
                AssetsEdit(sender, e);
            }
        }
        void uctTree1_AssetsDelete(object sender, EventArgs e)
        {
           if(AssetsDelete != null)
           {
               AssetsDelete(sender, e);
           }
        }

        public void SetTreeNodeSelected(string ID)
        {
            uctTree1.SetTreeNodeSelected(ID);
        }

        public TreeViewFastEX TreeViewFast
        {
            get
            {
                if (uctTree1 != null)
                    return uctTree1.TreeViewFast;
                return null;
            }
        }

        /// <summary>
        /// 获取用户选择的当前节点下的所有资产列表
        /// </summary>
        /// <returns>资产列表对象</returns>
        public List<AssetsData> GetSelChildAssetsList()
        {
            return uctTree1.GetSelChildAssetsList();
        }

    }
}