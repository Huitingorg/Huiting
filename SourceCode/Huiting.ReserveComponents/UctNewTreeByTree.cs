using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReserveCommon;

using Huiting.Common;

namespace ReserveComponents
{
    public partial class UctNewTreeByTree : UserControl
    {
        ProjectData showData;

        List<ProjectData> lstProjectData = new List<ProjectData>();

        public List<ProjectData> LstProjectData
        {
            get { return lstProjectData; }
        }

        string newProjectName;

        public string NewProjectName
        {
            get { return newProjectName; }
            set { newProjectName = value; }
        }

        public UctNewTreeByTree()
        {
            InitializeComponent();
            InitControls();
            this.uctTree1.CheckBoxes = true;
        }

        public void InitFirstData(List<ProjectData> lstProjectData)
        {
            this.lstProjectData = lstProjectData;

            //绑定事件
            uctTree1.AfterCheck -= uctTree1_AfterCheck;
            uctTree1.AfterCheck += uctTree1_AfterCheck;
            uctTree1.LoadDataCompleted -= new System.EventHandler(this.uctTree1_LoadDataCompleted);
            uctTree1.LoadDataCompleted += new System.EventHandler(this.uctTree1_LoadDataCompleted);
            uctTree2.LoadDataCompleted -= uctTree2_LoadDataCompleted;
            uctTree2.LoadDataCompleted += uctTree2_LoadDataCompleted;
            uctTree2.AfterSelect -= uctTree2_AfterSelect;
            uctTree2.AfterSelect += uctTree2_AfterSelect;
            uctTree1.AfterSelect -= uctTree1_AfterSelect;
            uctTree1.AfterSelect += uctTree1_AfterSelect;
        }

        void uctTree1_AfterSelect(List<IEntityData> lstParent, List<IEntityData> lstChild)
        {
            if (lstParent.Count <= 0)
                return;

            uctTree2.AfterSelect -= uctTree2_AfterSelect;
            uctTree2.SetTreeNodeSelected(lstParent[0].ID);
            uctTree2.AfterSelect += uctTree2_AfterSelect;
        }

        void uctTree2_AfterSelect(List<IEntityData> lstParent, List<IEntityData> lstChild)
        {
            if (lstParent.Count <= 0)
                return;

            uctTree1.AfterSelect -= uctTree1_AfterSelect;
            uctTree1.SetTreeNodeSelected(lstParent[0].ID);
            uctTree1.AfterSelect += uctTree1_AfterSelect;
        }

        public void InitSecondData(ProjectData showData)
        {
            this.txtProject.Text = showData.Text;
            this.showData = showData;
            //先uctTree2加载数据，完成后，再加载uctTree1的数据，之后再初始化uctTree1的节点状态
            this.uctTree2.LoadData(showData);
        }

        void uctTree2_LoadDataCompleted(object sender, EventArgs e)
        {
            if (!InitCombox()) return;
            //ProjectData itemData = comboBox1.SelectedItem as ProjectData;
            //List<AssetsData> lstAssetsData = uctTree2.GetLstAssetsData();
            //List<string> lstIDs = PublicMethods.GetLstStringByLstT(lstAssetsData, "ID");
            //string sqlPart = PublicMethods.GetSqlPart("dydm", lstIDs, false);
            //uctTree1.LoadData(itemData, sqlPart);
        }      

        public bool HaveOptionalItems()
        {
            if (lstProjectData == null || lstProjectData.Count <= 0)
                return false;
            return true;
        }

        public List<string> GetLstProjectName()
        {
            return PublicMethods.GetLstString(this.lstProjectData, "Text");
        }

        private void InitControls()
        {
            int w = (this.Width - pnlMiddle.Width - Padding.Left - Padding.Right) / 2;
            this.pnlLeft.Width = w;
            this.pnlRight.Width = w;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            InitControls();
        }

        private bool InitCombox()
        {
            foreach (ProjectData m_data in lstProjectData)
            {
                if (m_data.Text == this.txtProject.Text)
                {
                    lstProjectData.Remove(m_data);
                    break;
                }
            }


            if (lstProjectData.Count <= 0)
                return false;

            this.comboBox1.DataSource = null;
            this.comboBox1.Items.Clear();

            this.comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            this.comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            //数据绑定
            this.comboBox1.DisplayMember = "Text";
            this.comboBox1.ValueMember = "ID";
            this.comboBox1.DataSource = lstProjectData;

            //选中第一个节点
            if (comboBox1.Items.Count > 0)
            {
                int index = lstProjectData.IndexOf(showData);
                if (index < 0)
                    this.comboBox1.SelectedIndex = 0;
                else
                    this.comboBox1.SelectedIndex = index;
            }
            return true;
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count <= 0)
                return;
            ProjectData itemData = comboBox1.SelectedItem as ProjectData;
            if (itemData == null)
                return;

            List<AssetsData> lstAssetsData = uctTree2.GetLstAssetsData();

            uctTree1.LoadData(itemData, lstAssetsData);       

            //uctTree1.LoadData(itemData);
        }

        void uctTree1_AfterCheck(List<AssetsData> lstAssets, bool checkedState)
        {
            if (checkedState)
                uctTree2.AppendParts(lstAssets);
            else
                uctTree2.RemoveParts(lstAssets);
        }

        //private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    if (e.Index < 0)
        //        return;
        //    e.DrawBackground();
        //    e.DrawFocusRectangle();
        //    ProjectData itemData = comboBox1.Items[e.Index] as ProjectData;
        //    e.Graphics.DrawString(itemData.Text, e.Font, new SolidBrush(e.ForeColor), e.Bounds.X, e.Bounds.Y + 3);
        //}

        private void uctTree1_LoadDataCompleted(object sender, EventArgs e)
        {
            List<AssetsData> lstAssetsData = uctTree2.GetLstAssetsData();
            uctTree1.SetLstAssetsData(lstAssetsData);
        }

        public void GetChangedLstAssetsData(out List<AssetsData> lstAdd, out List<AssetsData> lstDel)
        {
            uctTree2.GetChangedLstAssetsData(out lstAdd, out lstDel);
        }

        public List<AssetsData> GetLstAssetsData()
        {
            List<AssetsData> lstAssetsDatas = uctTree2.GetLstAssetsData();
            return lstAssetsDatas;
        }

        public ProjectData GetProjectData()
        {
            ProjectData proData = new ProjectData();
            //proData.bz
            return proData;
        }
    }
}