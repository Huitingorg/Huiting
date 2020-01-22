using Huiting.Common;
using Huiting.DBAccess.Entity.Dtos;
using Huiting.DBAccess.Service;
using ReserveCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ReserveComponents
{
    public partial class UctTree : UserControl
    {
        List<IEntityData> old_parnode;//记录上次
        List<IEntityData> old_childnode;

        private ProjectData data;
        //string pjnd;//评价年度
        //string keyWord;
        public bool ISRerfsh = false;
        //string remove_dydm = string.Empty;     
        List<AssetsData> lstExcludeAssets;
        List<AssetsData> lstAllAssetsData = null;
        private IAssetsControl assetsControl;
        //标识:是不是要进行保存，属性ImmediateSave为真时有效
        private bool willSave = false;
        //即时保存
        private bool immediateSave = false;

        public bool ImmediateSave
        {
            get { return immediateSave; }
            set { immediateSave = value; }
        }

        //DBAccessEx dbAccess = null;

        public bool CheckBoxes
        {
            get
            {
                if (assetsControl == treeViewFast1)
                    return treeViewFast1.CheckBoxes;
                else
                    return treeListView1.CheckBoxes == CheckBoxesTypes.Simple;
            }
            set
            {
                treeViewFast1.CheckBoxes = value;
                treeListView1.CheckBoxes = value ? CheckBoxesTypes.Simple : CheckBoxesTypes.None;
            }
        }

        public IEntityData SelectedEntityData
        {
            get
            {
                if (assetsControl == null)
                    return null;
                return assetsControl.GetSelectedEntityData();
            }
        }

        public bool EditButtonVisible
        {
            get
            {
                return tsbAdd.Visible;
            }
            set
            {
                tsbSelect.Visible = tsbReturn.Visible = tsbAdd.Visible = tsbDel.Visible = toolStripSeparator3.Visible = value;
            }
        }

        public event EventHandler LoadDataCompleted;
        public event EventHandler SwitchProject;
        public event DlgGetLstProjectData GetLstProjectDataEvent;
        public event DlgAfterSelected AfterSelect;
        public event DlgAfterChecked AfterCheck;
        public event EventHandler AssetsAdd; //用户点击资产添加按钮触发
        public event EventHandler AssetsDelete;//用户点击删除按钮
        public event EventHandler AssetsEdit;//用户点击编辑按钮
        public UctTree()
        {
            InitializeComponent();
            treeViewFast1.CheckAllChildNodes = true;
            InitVisibleContol(treeViewFast1);
            //treeViewFast1.ContextMenuStrip = this.contextMenuStrip1;
        }

        private void tsbOrder_Click(object sender, EventArgs e)
        {
            tsmAssetCustom.PerformClick();
        }

        private void tsbGroup_Click(object sender, EventArgs e)
        {
            tsmAssetSort.PerformClick();
        }

        public void LoadData(ProjectData Data)
        {
            if (this.data != Data)
                this.data = Data;
            RefreshControl();
        }

        public void LoadData(ProjectData Data, List<AssetsData> lstExcludeAssets)
        {
            this.lstExcludeAssets = lstExcludeAssets;
            if (data != Data)
                this.data = Data;
            RefreshControl();
        }


        public void RefreshInterface()
        {
            RefreshControl();
        }

        private void RefreshControl()
        {
            BackgroundWorker bgwLoad = new BackgroundWorker();
            bgwLoad.DoWork -= bgwLoad_DoWork;
            bgwLoad.RunWorkerCompleted -= bgwLoad_RunWorkerCompleted;
            bgwLoad.DoWork += bgwLoad_DoWork;
            bgwLoad.RunWorkerCompleted += bgwLoad_RunWorkerCompleted;
            bgwLoad.RunWorkerAsync(txtQuery.Text.Trim());
        }

        private Color GetForeColor(IEntityData entityData)
        {
            AssetsData x = entityData as AssetsData;
            if (x != null)
                return dtData.Select("dydm='" + x.ID + "'").Length > 0 ? Color.Black : Color.Blue;
            return Color.Black;
        }

        private Color GetForeColor2(IEntityData entityData)
        {
            //参与经济评价的，字体默认为黑色；不参与经济评价的，特殊标识，默认为红色
            AssetsData x = entityData as AssetsData;
            if (x == null || (x.InvolvedEconEval != null && x.InvolvedEconEval == 1))
                return Color.Black;
            return Color.Red;
        }

        private int GetImgIndex(IEntityData entityData)
        {
            int imgageIndex = 0;

            if (entityData is ProjectData)
                imgageIndex = 0;
            else if (entityData is GroupData)
                imgageIndex = 1;
            else if (entityData is IAssetsData)
            {
                AssetsData assetsData = entityData as AssetsData;
                if (assetsData.MainProduct.Contains("油"))
                    imgageIndex = 4;
                else
                    imgageIndex = 5;
            }

            return imgageIndex;
        }

        private int GetImgIndex(EntityType type)
        {
            int imgageIndex;
            switch (type)
            {
                case EntityType.Project:
                    imgageIndex = 0;
                    break;
                case EntityType.Group:
                    imgageIndex = 1;
                    break;
                case EntityType.Unit:
                    imgageIndex = 2;
                    break;
                case EntityType.Function:
                default:
                    imgageIndex = 2;
                    break;
            }

            return imgageIndex;
        }

        public void RemoveParts(List<AssetsData> lstDyDab01)
        {
            List<IEntityData> lstEntityData = GetLstEntityData(data.GroupList, lstDyDab01);
            Func<IEntityData, string> getId = (x => x.ID);

            if (treeViewFast1 == assetsControl)
            {
                treeViewFast1.RemoveTreeNode(lstEntityData, getId);
                treeViewFast1.ExpandAll();
                if (treeViewFast1.Nodes.Count > 0)
                    treeViewFast1.Nodes[0].EnsureVisible();
            }
            else
            {
                treeListView1.RemoveTreeListViewItem(lstEntityData, getId);
                treeListView1.ExpandAll();
                if (treeListView1.Items.Count > 0)
                    treeListView1.Items[0].EnsureVisible();
            }
        }

        public void AppendParts(List<AssetsData> lstDyDab01)
        {
            List<IEntityData> lstEntityData = GetLstEntityDataForTree(data.GroupList, lstDyDab01);
            Func<IEntityData, string> getId = (x => x.ID);
            Func<IEntityData, string> getParentId = (x => x.PID.ToString());
            Func<IEntityData, string> getDisplayName;
            Func<IEntityData, int> getImageIndex = (x => GetImgIndex(x));
            Func<IEntityData, Color> getForeColor = (x => GetForeColor(x));

            if (treeViewFast1 == assetsControl)
            {
                getDisplayName = (x => GetText(x, data.SortList));
                treeViewFast1.LoadPartItems(lstEntityData, getId, getParentId, getDisplayName, getImageIndex, getForeColor);
                treeViewFast1.ExpandAll();
                if (treeViewFast1.Nodes.Count > 0)
                    treeViewFast1.Nodes[0].EnsureVisible();
            }
            else
            {
                getDisplayName = (x => x.Text);
                Dictionary<string, string> dictPropertyName = data.SortList.GetDictPropertyName();
                treeListView1.LoadPartItems<IEntityData, IAssetsData>(lstEntityData, getId, getParentId, getDisplayName, dictPropertyName, getImageIndex, getForeColor);
                treeListView1.ExpandAll();
                if (treeListView1.Items.Count > 0)
                    treeListView1.Items[0].EnsureVisible();
            }
        }
        //获取标题名称
        private string GetText(IEntityData entity, SortInfoQueue SortList)
        {
            IAssetsData assetsData = entity as IAssetsData;
            if (assetsData == null)
                return entity.Text;
            return assetsData.GetText(SortList);
        }

        internal DataTable dtData;

        void bgwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            var var1 = data;
            string keyWord = e.Argument as string;

            string sqlPart=string.Empty;
            //将要排除的单元，组织成sql
            List<string> lstIDs = PublicMethods.GetLstStringByLstT(this.lstExcludeAssets, "ID");
            string sqlPartByIn = PublicMethods.GetSqlPartByIn("dydm", lstIDs, false);
            if (string.IsNullOrWhiteSpace(sqlPartByIn) == false)
                sqlPart = sqlPartByIn;

            //如果有要模糊匹配的关键字
            if (string.IsNullOrWhiteSpace(keyWord) == false)
            {            
                //将要模糊匹配的单元，组织成sql
                var lstSort = data.SortList.Select(x => x.Type.ToString()).ToList();
                string sqlPartByLike = PublicMethods.GetSqlPartByLike(keyWord, lstSort);
                if (string.IsNullOrEmpty(sqlPartByLike) == false && string.IsNullOrEmpty(sqlPart) == false)
                    sqlPart = $"{sqlPart} and {sqlPartByLike}";
            }

            UnitBasicDataDtoService unitBasicDataDtoService = new UnitBasicDataDtoService();
            var unitBasicDataDtos = unitBasicDataDtoService.GetUnitBasicDataDto(data.ID.ToInt(), sqlPart).ToList();

            //获取队列
            List<AssetsData> lstDyDab01 = new List<AssetsData>();
            unitBasicDataDtos.ForEach(x => lstDyDab01.Add(new AssetsData(x)));

            e.Result = lstDyDab01;
        }

        void bgwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                PublicMethods.WarnMessageBox("加载功能树异常：" + e.Error.Message);
                return;
            }

            List<AssetsData> lstAssetsData = e.Result as List<AssetsData>;

            if (lstAllAssetsData == null)
                lstAllAssetsData = lstAssetsData;

            InitAssetsControl(lstAssetsData);

            //如果是即时保存，则保存
            Save();

            if (LoadDataCompleted != null)
                LoadDataCompleted(data, null);
            //ISRerfsh = false;
            tsbSearch.Enabled = true;
        }

        //初始化资产
        private void InitAssetsControl(List<AssetsData> lstAssetsData)
        {
            //整理分组的顺序
            List<IEntityData> lstTreeData;
            if (string.IsNullOrEmpty(txtQuery.Text.Trim()))
                lstTreeData = GetLstEntityDataForTree(data.GroupList, lstAssetsData);
            else
                lstTreeData = GetLstEntityDataForTree(new GroupInfoQueue(), lstAssetsData);
            //插入根节点
            ProjectData root = new ProjectData();
            root.ID = GlobalInfo.TreeRootID;
            root.Text = data.Text;
            root.Desciption = data.Desciption;
            lstTreeData.Insert(0, root);

            Func<IEntityData, string> getId = (x => x.ID);
            Func<IEntityData, string> getParentId = (x => x.PID);
            Func<IEntityData, string> getDisplayName;
            Func<IEntityData, int> getImageIndex = (x => GetImgIndex(x));
            Func<IEntityData, Color> getForeColor = (x => GetForeColor2(x));

            if (treeViewFast1 == assetsControl)
            {
                getDisplayName = (x => GetText(x, data.SortList));
                treeViewFast1.LoadItems(lstTreeData, getId, getParentId, getDisplayName, getImageIndex, getForeColor);
                if (treeViewFast1.Nodes.Count > 0)
                {
                    treeViewFast1.Nodes[0].EnsureVisible();
                    treeViewFast1.Nodes[0].Expand();
                    //treeViewFast1.Nodes[0].ExpandAll();
                }
            }
            else
            {
                getDisplayName = (x => x.Text);
                Dictionary<string, string> dictPropertyName = data.SortList.GetDictPropertyName();
                treeListView1.LoadItems<IEntityData, IAssetsData>(lstTreeData, getId, getParentId, getDisplayName, dictPropertyName, getImageIndex, getForeColor);
                if (treeListView1.Items.Count > 0)
                {
                    treeListView1.Items[0].EnsureVisible();
                    treeListView1.Items[0].Expand();
                    //treeListView1.Items[0].ExpandAll();
                }
            }
        }

        public string Save()
        {
            string err = null;
            //如果是即时保存，则保存
            if (willSave && immediateSave)
            {
                //ProjectInfoService service = new ProjectInfoService();
                //err = service.SaveProjectData(data);
            }
            return err;
        }

        private void Append(Dictionary<string, IEntityData> dictAll, Dictionary<string, IEntityData> dictPart)
        {
            if (dictAll == null)
                dictAll = new Dictionary<string, IEntityData>();

            foreach (KeyValuePair<string, IEntityData> item in dictPart)
            {
                if (!dictAll.ContainsKey(item.Key))
                    dictAll.Add(item.Key, item.Value);
            }
        }

        private string GetPID(AssetsData dr, GroupInfoQueue lstGroupInfo)
        {
            return GetPID(dr, lstGroupInfo, lstGroupInfo.Count - 1);
        }

        private string GetPID(AssetsData dr, GroupInfoQueue lstGroupInfo, int index)
        {
            string result = GlobalInfo.TreeRootID;
            for (int i = 0; i <= index; i++)
            {
                GroupInfo item = lstGroupInfo[i];
                string fieldValue = GetID(dr, item);
                if (!string.IsNullOrEmpty(result))
                    result += "_";
                result += fieldValue;
            }

            return result;
        }

        private string GetID(AssetsData dr, GroupInfo item)
        {
            string fieldName = item.GetFieldName();
            object objValue = PublicMethods.GetPropertyValue(dr, fieldName);
            string fieldValue = objValue == null ? "" : objValue.ToString();
            if (string.IsNullOrEmpty(fieldValue))
                fieldValue = GlobalInfo.Undefined;

            return fieldValue;
        }

        public List<IEntityData> GetLstEntityData(GroupInfoQueue lstGroupInfo, List<AssetsData> lstRows)
        {
            Dictionary<string, IEntityData> dictAll = new Dictionary<string, IEntityData>();
            //详细的追加已有序的数据行
            foreach (AssetsData dr in lstRows)
            {
                if (dictAll.ContainsKey(dr.ID))
                    continue;

                dr.PID = GetPID(dr, lstGroupInfo);
                dictAll.Add(dr.ID, dr);
            }

            return dictAll.Values.ToList<IEntityData>();
        }

        //将分组及数据，组织成IP、PID、Text的接口队列
        public List<IEntityData> GetLstEntityDataForTree(GroupInfoQueue lstGroupInfo, List<AssetsData> lstRows)
        {
            Dictionary<string, IEntityData> dictAll = new Dictionary<string, IEntityData>();
            //先遍历层级,并升降排序
            for (int i = 0; i < lstGroupInfo.Count; i++)
            {
                GroupInfo item = lstGroupInfo[i];

                #region 获取每一级的内容

                Dictionary<string, IEntityData> dictLevel = new Dictionary<string, IEntityData>();
                foreach (AssetsData dr in lstRows)
                {
                    //当前的层级的PID
                    string level_PID = GetPID(dr, lstGroupInfo, i - 1);
                    GroupData td = new GroupData();
                    td.SortType = item.Type;
                    td.PID = level_PID;

                    //当前的层级的值
                    string fieldValue = GetID(dr, item);

                    //当前的层级的PID
                    string level_ID = null;

                    //组装PID
                    if (!string.IsNullOrEmpty(level_PID))
                        level_ID = level_PID + "_";
                    level_ID += fieldValue;
                    //如果已经包含此键
                    if (dictLevel.ContainsKey(level_ID))
                        continue;

                    td.ID = level_ID;
                    td.Text = fieldValue;
                    dictLevel.Add(level_ID, td);
                }

                #endregion

                //对每一级内容进行排序
                if (item.Asc)
                    dictLevel = dictLevel.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
                else
                    dictLevel = dictLevel.OrderByDescending(o => o.Key).ToDictionary(o => o.Key, p => p.Value);

                //追加到主队列中
                Append(dictAll, dictLevel);
            }

            //详细的追加已有序的数据行
            foreach (AssetsData dr in lstRows)
            {
                if (dictAll.ContainsKey(dr.ID))
                    continue;

                dr.PID = GetPID(dr, lstGroupInfo);
                dictAll.Add(dr.ID, dr);
            }

            return dictAll.Values.ToList<IEntityData>();
        }

        private string GetFieldBySortType(GroupInfo sortType)
        {
            //暂时是枚举类型等于字段名
            return sortType.Type.ToString();
        }

        public ContextMenuStrip TreeContextMenuStrip
        {
            get
            {
                return this.treeViewFast1.ContextMenuStrip;
            }
            set
            {
                this.treeViewFast1.ContextMenuStrip = value;
            }
        }

        public ContextMenuStrip ListContextMenuStrip
        {
            get
            {
                return this.treeListView1.ContextMenuStrip;
            }
            set
            {
                this.treeListView1.ContextMenuStrip = value;
            }
        }

        public TreeViewFastEX TreeViewFast
        {
            get
            {
                return treeViewFast1;
            }
        }

        private void InitVisibleContol(Control ctrl)
        {
            assetsControl = ctrl as IAssetsControl;
            if (assetsControl == treeListView1)
            {
                treeListView1.ContextMenuStrip = this.contextMenuStrip1;

                treeListView1.Visible = true;
                treeViewFast1.Visible = false;
                tsbSwitch.ToolTipText = "切换成树形模式";
            }
            else
            {
                treeViewFast1.ContextMenuStrip = this.contextMenuStrip1;

                treeViewFast1.Visible = true;
                treeListView1.Visible = false;
                tsbSwitch.ToolTipText = "切换成列表模式";
            }

            ctrl.BringToFront();
            ctrl.Dock = DockStyle.Fill;
//            ctrl.Location = new Point(0, toolStrip1.Height);
//            ctrl.Size = new Size(this.Width, this.Height - 6 - toolStrip1.Height);
//            ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//| System.Windows.Forms.AnchorStyles.Left)
//| System.Windows.Forms.AnchorStyles.Right)));
        }

        private void tsbSwitch_Click(object sender, EventArgs e)
        {
            //先获取叶子队列
            List<AssetsData> lstAssetsData = assetsControl.GetLstLeafData();
            //切换组件
            Control visualCtrl = treeViewFast1.Visible ? (Control)treeListView1 : (Control)treeViewFast1;
            InitVisibleContol(visualCtrl);

            //初始化新组件
            InitAssetsControl(lstAssetsData);
        }

        private void tsbReturn_Click(object sender, EventArgs e)
        {
            if (SwitchProject != null)
                SwitchProject(sender, e);
        }

        private void tsbSelect_Click(object sender, EventArgs e)
        {
            tsmSelectAssets.PerformClick();
        }

        private void tsbFilter_Click(object sender, EventArgs e)
        {
            FrmAssetsFilter frmAF = new FrmAssetsFilter();
            if (frmAF.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void treeViewFast1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
            {
                IEntityData entityData = e.Node.Tag as IEntityData;
                if (entityData == null)
                    return;
                List<AssetsData> lstAD = treeViewFast1.GetLstLeafData(e.Node);
                if (AfterCheck != null)
                    AfterCheck(lstAD, e.Node.Checked);
            }
        }

        private void treeListView1_AfterCheck(object sender, TreeListViewEventArgs e)
        {
            if (e.Action == TreeListViewAction.ByMouse || e.Action == TreeListViewAction.ByKeyboard)
            {
                IEntityData entityData;
                if (treeListView1.SelectedItems.Count <= 0)
                    return;
                TreeListViewItem tlvi = treeListView1.SelectedItems[0];
                entityData = tlvi.Tag as IEntityData;
                if (entityData == null)
                    return;

                List<AssetsData> lstAD = treeListView1.GetLstLeafData();
                if (AfterCheck != null)
                    AfterCheck(lstAD, tlvi.Checked);
            }
        }

        //获取所有节点的数据队列
        public List<AssetsData> GetLstAssetsData()
        {
            List<AssetsData> lstAssetsData = assetsControl.GetLstLeafData();
            foreach (AssetsData item in lstAssetsData)
            {
               // item.ProID = data.ID;
            }

            return lstAssetsData;
        }

        public void GetChangedLstAssetsData(out List<AssetsData> lstAdd, out List<AssetsData> lstDel)
        {
            lstAdd = new List<AssetsData>();
            lstDel = new List<AssetsData>();

            List<AssetsData> lstAssetsData = GetLstAssetsData();
            foreach (AssetsData item in lstAssetsData)
            {
                if (dtData.Select("dydm='" + item.DYDM + "'").Length <= 0)
                    lstAdd.Add(item);
            }

            foreach (DataRow dr in dtData.Rows)
            {
                AssetsData result = lstAssetsData.Find(delegate(AssetsData a) { return a.DYDM == dr["dydm"].ToString(); });
                if (result == null)
                {
                    //AssetsData dyDab01 = AssetsData.GetModel<AssetsData>(dr);
                    //lstDel.Add(dyDab01);
                }

            }
        }

        //设置节点处于选中状态
        public void SetLstAssetsData(List<AssetsData> lstAssetsData)
        {
            assetsControl.SetContrlItemChecked(lstAssetsData);
        }

        private void treeViewFast1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            List<IEntityData> lstParent = treeViewFast1.GetLstTreeDataToUp(e.Node);
            List<IEntityData> lstChild = treeViewFast1.GetLstDataToDown(e.Node);
            old_parnode = lstParent;
            old_childnode = lstChild;
            if (AfterSelect != null)
                AfterSelect(lstParent, lstChild);
        }
        public void RefreshChart()
        {
            if (old_parnode != null)
                AfterSelect(old_parnode, old_childnode);
        }

        private void treeListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (treeListView1.SelectedItems.Count <= 0)
                return;

            TreeListViewItem tlvi = treeListView1.SelectedItems[0];
            List<IEntityData> lstParent = treeListView1.GetLstTreeDataToUp(tlvi);
            List<IEntityData> lstChild = treeListView1.GetLstDataToDown(tlvi);
            old_parnode = lstParent;
            old_childnode = lstChild;
            if (AfterSelect != null)
                AfterSelect(lstParent, lstChild);
        }

        public void SetTreeNodeSelected(string id)
        {
            if (assetsControl == null)
                return;

            object obj = assetsControl.GetControlItem(id);
            if (obj == null)
                return;
            assetsControl.SetContrlItemSelected(obj);
        }

        //获取用户选择节点下的所有资产
        public List<AssetsData> GetSelChildAssetsList()
        {
            List<AssetsData> lst_Sel = new List<AssetsData>();

            if (treeViewFast1.SelectedNode == null)
            {
                return lst_Sel;
            }

            if (treeViewFast1.SelectedNode.Tag as AssetsData != null)
            {
                lst_Sel.Add((AssetsData)treeViewFast1.SelectedNode.Tag);
            }


            foreach (TreeNode curNode in treeViewFast1.SelectedNode.Nodes)
            {
                if (curNode.Tag as AssetsData != null)
                {
                    lst_Sel.Add((AssetsData)curNode.Tag);
                }

                GetChildTreeNode(curNode, ref lst_Sel);
            }


            return lst_Sel;
        }

        //递归所有子级节点
        private void GetChildTreeNode(TreeNode ParentNode, ref List<AssetsData> lst_Sel)
        {
            foreach (TreeNode curNode in ParentNode.Nodes)
            {
                if (curNode.Tag as AssetsData != null)
                    lst_Sel.Add((AssetsData)curNode.Tag);

                GetChildTreeNode(curNode, ref lst_Sel);
            }
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            txtQuery.Text = "";
            //RefreshControl();
            if (lstAllAssetsData != null)
                InitAssetsControl(lstAllAssetsData);
        }

        private void txtQuery_TextChanged(object sender, EventArgs e)
        {
            if (lstAllAssetsData == null) return;

            List<AssetsData> lstSelected = GetLstAssetsDataByKeyWord(lstAllAssetsData, txtQuery.Text.ToString());
            InitAssetsControl(lstSelected);
        }

        private List<AssetsData> GetLstAssetsDataByKeyWord(List<AssetsData> lstAssetsData, string keyWord)
        {
            List<AssetsData> lstSelected = new List<AssetsData>();
            foreach (AssetsData assetsData in lstAssetsData)
            {
                if (assetsData.DYMC.Contains(keyWord) || assetsData.DYDM.Contains(keyWord))
                    lstSelected.Add(assetsData);
            }
            return lstSelected;
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            //ISRerfsh = true;
            this.lstAllAssetsData = null;
            RefreshControl();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            tsmAddAssets.PerformClick();
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            tsmDelAssets.PerformClick();
        }

        private void tsmDelAssets_Click(object sender, EventArgs e)
        {
            if (AssetsDelete != null)
            {
                AssetsDelete(this, new EventArgs());
            }
            //RefreshInterface();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (AssetsEdit != null)
            {
                AssetsEdit(this, new EventArgs());
            }
        }

        private void treeViewFast1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(this, new Point(e.Location.X, e.Location.Y + 30));
            }
        }
        /// <summary>
        /// 展开下一层节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmShowNext_Click(object sender, EventArgs e)
        {
            if (assetsControl == treeViewFast1)
            {
                if (this.treeViewFast1.SelectedNode != null)
                {
                    this.treeViewFast1.SelectedNode.Expand();
                }
            }
            else
            {
                if (this.treeListView1.SelectedItems.Count > 0)
                {
                    this.treeListView1.SelectedItems[0].Expand();
                }

            }
        }
        /// <summary>
        /// 收起下一层节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmHideNext_Click(object sender, EventArgs e)
        {
            if (assetsControl == treeViewFast1)
            {
                if (this.treeViewFast1.SelectedNode != null)
                {
                    this.treeViewFast1.SelectedNode.Collapse();
                }
            }
            else
            {
                if (this.treeListView1.SelectedItems.Count > 0)
                {
                    this.treeListView1.SelectedItems[0].Collapse();
                }
            }

            //if (assetsControl == treeViewFast1)
            //{
            //    TreeNode tnSelected = this.treeViewFast1.SelectedNode;
            //    if (tnSelected == null)
            //        return;
            //    foreach (TreeNode tnChild in tnSelected.Nodes)
            //    {
            //        tnChild.Collapse();
            //    }
            //}
            //else
            //{
            //    if (this.treeListView1.SelectedItems.Count <= 0)
            //        return;

            //    foreach (TreeListViewItem tlvi in this.treeListView1.SelectedItems[0].Items)
            //    {
            //        tlvi.Collapse();
            //    }
            //}

        }
        /// <summary>
        /// 展开全部节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmShowAll_Click(object sender, EventArgs e)
        {
            if (assetsControl == treeViewFast1)
            {
                this.treeViewFast1.ExpandAll();
                if (treeViewFast1.SelectedNode != null)
                    treeViewFast1.SelectedNode.EnsureVisible();
                else if (treeViewFast1.Nodes.Count > 0)
                    treeViewFast1.Nodes[0].EnsureVisible();
            }
            else
            {
                this.treeListView1.ExpandAll();
                if (treeListView1.SelectedItems.Count > 0)
                    treeListView1.SelectedItems[0].EnsureVisible();
                else if (treeListView1.Items.Count > 0)
                    treeListView1.Items[0].EnsureVisible();
            }


            //if (assetsControl == treeViewFast1)
            //{
            //    if (treeViewFast1.Nodes.Count<=0)
            //        return;
            //    foreach (TreeNode tnChild in treeViewFast1.Nodes[0].Nodes)
            //    {
            //        tnChild.ExpandAll();
            //    }
            //}
            //else
            //{
            //    if (this.treeListView1.SelectedItems.Count <= 0)
            //        return;

            //    foreach (TreeListViewItem tlvi in this.treeListView1.SelectedItems[0].Items)
            //    {
            //        tlvi.Collapse();
            //    }
            //}
        }
        /// <summary>
        /// 收起全部节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmHideAll_Click(object sender, EventArgs e)
        {
            if (assetsControl == treeViewFast1)
            {
                if (treeViewFast1.Nodes.Count <= 0)
                    return;
                foreach (TreeNode tnChild in treeViewFast1.Nodes[0].Nodes)
                {
                    tnChild.Collapse();
                }

                if (treeViewFast1.SelectedNode != null)
                    treeViewFast1.SelectedNode.EnsureVisible();
                else if (treeViewFast1.Nodes.Count > 0)
                    treeViewFast1.Nodes[0].EnsureVisible();
            }
            else
            {
                if (this.treeListView1.Items.Count <= 0)
                    return;

                foreach (TreeListViewItem tlvi in this.treeListView1.Items[0].Items)
                {
                    tlvi.Collapse();
                }

                TreeListViewItem tlviSelected;
                if (this.treeListView1.SelectedItems.Count > 0)
                    tlviSelected = this.treeListView1.SelectedItems[0];
                else if (treeListView1.Items.Count > 0)
                    tlviSelected = this.treeListView1.Items[0];
                else
                    tlviSelected = null;

                if (tlviSelected != null)
                    tlviSelected.EnsureVisible();
            }
        }

        private void tsmAddAssets_Click(object sender, EventArgs e)
        {
            if (AssetsAdd != null)
                AssetsAdd(this, new EventArgs());
            //RefreshInterface();
        }

        private void tsmSelectAssets_Click(object sender, EventArgs e)
        {
            if (GetLstProjectDataEvent == null)
                return;
            List<ProjectData> lstProjectData = GetLstProjectDataEvent();
            if (lstProjectData == null || lstProjectData.Count <= 0)
            {
                PublicMethods.WarnMessageBox(this, "尚没有项目可以供选择资源");
                return;
            }
            //FrmAssetsSelect frmAS = new FrmAssetsSelect(lstProjectData, data);
            //if (frmAS.ShowDialog(this) != DialogResult.OK)
            //    return;

            //DYDAB01Service dYDAB01Service = new DYDAB01Service();

            //string err;
            //err = dYDAB01Service.Delete(data.ID, frmAS.LstAssetsDel);
            //err = dYDAB01Service.Insert(data.ID, frmAS.LstAssetsAdd);

            //if (!string.IsNullOrEmpty(err))
            //{
            //    PublicMethods.WarnMessageBox(this, "资源筛选异常：" + err);
            //    return;
            //}
            //LoadData(data);
        }

        private void tsmAssetSort_Click(object sender, EventArgs e)
        {
            FrmAssetsGroup frmLevel = new FrmAssetsGroup(data.GroupList);
            if (frmLevel.ShowDialog(this) != DialogResult.OK)
                return;

            willSave = true;
            data.GroupList = frmLevel.SortInfoQueue;
            Save();

            List<AssetsData> lstAssetsData = assetsControl.GetLstLeafData();
            InitAssetsControl(lstAssetsData);
        }

        private void tsmAssetCustom_Click(object sender, EventArgs e)
        {
            FrmAssetsSort frmSort = new FrmAssetsSort(data.SortList);
            if (frmSort.ShowDialog(this) != DialogResult.OK)
                return;

            willSave = true;
            data.SortList = frmSort.SortInfoQueue;
            Save();

            if (assetsControl == treeViewFast1)
                assetsControl.UpdateItems(data.SortList);
            else
            {
                List<AssetsData> lstAssetsData = assetsControl.GetLstLeafData();
                InitAssetsControl(lstAssetsData);
            }
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtQuery.Text.Trim()))
            //    return;
            tsbSearch.Enabled = false;
            RefreshControl();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            IEntityData entityData= this.assetsControl.GetSelectedEntityData();
            if (entityData is ProjectData)
                tsmDelAssets.Enabled = false;
            else
                tsmDelAssets.Enabled = true;
        }

    }

    public delegate List<ProjectData> DlgGetLstProjectData();

    public delegate void DlgAfterChecked(List<AssetsData> lst, bool checkedState);

    public delegate void DlgAfterSelected(List<IEntityData> lstParent, List<IEntityData> lstChild);

}