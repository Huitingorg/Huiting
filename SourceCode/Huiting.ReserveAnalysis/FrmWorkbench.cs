using Huiting.Common;
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

namespace ReserveAnalysis
{
    public partial class FrmWorkbench : DockContent
    {
        UnitNavigationPanel navigationPanel;
        UnitFreeLayoutPanel freeLayoutPanel;
        UnitGroupPanel unitGroupPanel;

        public event EventHandler SelectedNodeChanged;

        public FrmWorkbench()
        {
            InitializeComponent();

            this.Text = "我的办公平台";

            unitGroupPanel = new UnitGroupPanel();
            unitGroupPanel.Visible = false;
            unitGroupPanel.ItemClick += ItemClick;
            this.Controls.Add(unitGroupPanel);

            freeLayoutPanel = new UnitFreeLayoutPanel();
            freeLayoutPanel.ItemClick += ItemClick;
            this.Controls.Add(freeLayoutPanel);

            navigationPanel = new UnitNavigationPanel();
            navigationPanel.ItemClick += ItemClick;
            navigationPanel.Dock = DockStyle.Top;
            this.Controls.Add(navigationPanel);

            this.BackColor = Color.White;
        }

        void ItemClick(object sender, EventArgs e)
        {
            if (SelectedNodeChanged != null)
                SelectedNodeChanged(sender, e);
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="lstDictionary">目录队列</param>
        /// <param name="lstChildData">实体数据</param>
        /// <param name="isGroup">是否分组</param>
        public void LoadData(List<IEntityData> lstDictionary, List<IEntityData> lstChildData, bool isGroup)
        {
            try
            {
                navigationPanel.Init(lstDictionary);
            }
            catch (Exception ex)
            {
                PublicMethods.WarnMessageBox("加载导航异常：" + ex.Message);
            }

            
            try
            {
                if (isGroup)
                {
                    //每个资产使用
                    if (unitGroupPanel.Visible == false)
                    {
                        freeLayoutPanel.Visible = false;
                        unitGroupPanel.Visible = true;
                        unitGroupPanel.Dock = DockStyle.Fill;
                        unitGroupPanel.Init(lstChildData);
                    }
                }
                else
                {
                    //项目队列使用
                    unitGroupPanel.Visible = false;
                    freeLayoutPanel.Visible = true;
                    freeLayoutPanel.Dock = DockStyle.Fill;
                    freeLayoutPanel.InitInterface(lstChildData, IconLayoutType.LeftWordRightImage, false);
                }

            }
            catch (Exception ex)
            {
                WinPublicMethods.WarnMessageBox("加载面板异常：" + ex.Message);
            }
        }
    }
}