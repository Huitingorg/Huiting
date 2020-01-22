
using DataEdit;
using DevExpress.XtraBars;
using LocalDataService;
using ReserveChart;
using ReserveCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;

namespace ReserveAnalysis
{
    class OpNotifyMessageClass
    {
        DockPanel curDocPanel;
        FrmLeft curTreeForm;
        DevExpress.XtraBars.BarEditItem barBPJND;
        ProjectData curProData;
        public OpNotifyMessageClass(ProjectData curProData, DockPanel curDocPanel, FrmLeft curTreeForm, DevExpress.XtraBars.BarEditItem barBPJND)
        {
            this.curProData = curProData;
            this.curDocPanel = curDocPanel;
            this.curTreeForm = curTreeForm;
            this.barBPJND = barBPJND;
            InitEnvent();
        }

        private void InitEnvent()
        {
            curDocPanel.ActiveDocumentChanged += curDocPanel_ActiveDocumentChanged;
            barBPJND.EditValueChanged -= barBPJND_EditValueChanged;
            barBPJND.EditValueChanged += barBPJND_EditValueChanged;
            curTreeForm.AfterSelect -= curTreeForm_AfterSelect;
            curTreeForm.AfterSelect += curTreeForm_AfterSelect;
        }

        void curTreeForm_AfterSelect(List<ReserveCommon.IEntityData> lstParent, List<ReserveCommon.IEntityData> lstChild)
        {
            foreach (DockContent frm in this.curDocPanel.Contents)
            {
                if (lstParent.Count <= 0)
                    continue;

                if (frm is FormBaseClass)
                {
                    FormBaseClass curForm = (FormBaseClass)frm;
                    //当前用户选中的资产(可能为null,即是分类)
                    curForm.CurEntityData = curTreeForm.SelectedEntityData;
                    curForm.SelectedLstAssets = curTreeForm.GetSelChildAssetsList();
                    curForm.AssetChangedTrigger = true;
                }
            }

            CheckCurActiveDocment();
        }

        void barBPJND_EditValueChanged(object sender, EventArgs e)
        {
            if (barBPJND.EditValue == null)
                return;

            foreach (DockContent frm in this.curDocPanel.Contents)
            {
                if (frm is FormBaseClass)
                {
                    FormBaseClass curForm = (FormBaseClass)frm;
                    //当前用户选中的资产(可能为null,即是分类)
                    curForm.CurPJND = barBPJND.EditValue.ToString();
                    curForm.PjndChangedTrigger = true;
                }
            }
            CheckCurActiveDocment();
        }

        void curDocPanel_ActiveDocumentChanged(object sender, EventArgs e)
        {
            CheckCurActiveDocment();
        }

        void CheckCurActiveDocment()
        {
            FormBaseClass curForm = curDocPanel.ActiveDocument as FormBaseClass;
            if (curForm == null)
                return;

            if (curForm.AssetChangedTrigger||curForm.PjndChangedTrigger)
            {
                curForm.TriggerEven();
                curForm.AssetChangedTrigger = false;
                curForm.PjndChangedTrigger = false;
            }
        }
    }
}
