using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BDSoft.Common;
using LocalDataService;
using BDSoft.Components;

namespace ReserveCommon
{
    public partial class UctTree : UserControl
    {
        ItemData data;

        Control visualCtrl;

        public bool EditButtonVisible
        {
            get
            {
                return tsbAdd.Visible;
            }
            set
            {
                tsbAdd.Visible = tsbDel.Visible = tsbEdit.Visible = toolStripSeparator3.Visible = value;
            }
        }

        public UctTree()
        {
            InitializeComponent();
            InitContol(treeViewFast1);
        }

        private void tsbTree_Click(object sender, EventArgs e)
        {
            //this.FillData();

            FrmLevel frmLevel = new FrmLevel();
            if (frmLevel.ShowDialog(this) != DialogResult.OK)
                return;

            List<SortInfo> lstSortInfo = frmLevel.LstSortInfo;
            if (treeViewFast1.SelectedNode != null && treeViewFast1.SelectedNode.Level == 0)
                tnProject = treeViewFast1.SelectedNode;
            LoadFast(lstSortInfo);
        }

        private List<SortInfo> GetLstSortInfo()
        {
            List<SortInfo> lstSortInfo = new List<SortInfo>();
            lstSortInfo.Add(new SortInfo() { Type = SortType.CYCMC });
            lstSortInfo.Add(new SortInfo() { Type = SortType.YTMC });

            return lstSortInfo;
        }

        private List<SortType> GetLstSortType()
        {
            List<SortType> lstSortInfo = new List<SortType>();
            lstSortInfo.Add(SortType.CYCMC);
            lstSortInfo.Add(SortType.YTMC);

            return lstSortInfo;
        }

        public void LoadFast(ItemData Data)
        {
            this.data = Data;
            List<SortInfo> lstSortInfo = GetLstSortInfo();

            if (treeViewFast1 == visualCtrl)
            {
                treeViewFast1.Nodes.Clear();
                TreeNode tn = new TreeNode();
                tn.ImageIndex = 0;
                tn.SelectedImageIndex = 0;
                tn.Text = data.Text;
                treeViewFast1.Nodes.Add(tn);

                tnProject = tn;
            }
            else
            {
                treeListView1.Items.Clear();
                TreeListViewItem tlvi = new TreeListViewItem();
                tlvi.ImageIndex = 0;
                tlvi.Text = data.Text;
                treeListView1.Items.Add(tlvi);

                tlviProject = tlvi;
            }
            LoadFast(lstSortInfo);
        }

        TreeNode tnProject;
        TreeListViewItem tlviProject;

        /// <summary>
        /// 填充数据，刚开始数据不全时调用
        /// </summary>
        private void FillData()
        {
            DYDAB01Service dyDab01Service = new DYDAB01Service();
            DataTable dt = dyDab01Service.GetDataTable(null);

            Random rd = new Random();
            //遍历行
            foreach (DataRow dr in dt.Rows)
            {
                string filedName;
                //遍历排序类型
                foreach (SortType item in Enum.GetValues(typeof(SortType)))
                {
                    int curIndex;
                    Array array;
                    filedName = item.ToString();

                    switch (item)
                    {
                        case SortType.YQCLX:
                            array = Enum.GetValues(typeof(EnumYQCLX));
                            curIndex = rd.Next(array.Length);
                            EnumYQCLX yqclx = (EnumYQCLX)curIndex;
                            dr[filedName] = EnumDictionary<EnumYQCLX>.Instance.GetDescription(yqclx);
                            break;
                        case SortType.QDLX:
                            array = Enum.GetValues(typeof(EnumQDLX));
                            curIndex = rd.Next(array.Length);
                            EnumQDLX qdlx = (EnumQDLX)curIndex;
                            dr[filedName] = EnumDictionary<EnumQDLX>.Instance.GetDescription(qdlx);
                            break;
                        case SortType.QBLX:
                            array = Enum.GetValues(typeof(EnumQBLX));
                            curIndex = rd.Next(array.Length);
                            EnumQBLX qblx = (EnumQBLX)curIndex;
                            dr[filedName] = EnumDictionary<EnumQBLX>.Instance.GetDescription(qblx);
                            break;
                        case SortType.KFFS:
                            array = Enum.GetValues(typeof(EnumKFFS));
                            curIndex = rd.Next(array.Length);
                            EnumKFFS kffs = (EnumKFFS)curIndex;
                            dr[filedName] = EnumDictionary<EnumKFFS>.Instance.GetDescription(kffs);
                            break;
                        case SortType.CLLB:
                            array = Enum.GetValues(typeof(EnumCLLB));
                            curIndex = rd.Next(array.Length);
                            EnumCLLB cllb = (EnumCLLB)curIndex;
                            dr[filedName] = EnumDictionary<EnumCLLB>.Instance.GetDescription(cllb);
                            break;
                        case SortType.KFZT:
                            array = Enum.GetValues(typeof(EnumKFZT));
                            curIndex = rd.Next(array.Length);
                            EnumKFZT kfzt = (EnumKFZT)curIndex;
                            dr[filedName] = EnumDictionary<EnumKFZT>.Instance.GetDescription(kfzt);
                            break;
                        default:
                            break;
                    }
                }
            }

            dyDab01Service.DBAccess.UpdateDateTable(dt, "select * from DYDAB01");
        }

        private void LoadFast(List<SortInfo> lstSortInfo)
        {
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += bgw_DoWork;
            bgw.RunWorkerCompleted += bgw_RunWorkerCompleted;
            bgw.RunWorkerAsync(lstSortInfo);
        }

        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            List<SortInfo> lstSortInfo = e.Argument as List<SortInfo>;
            DYDAB01Service dyDab01Service = new DYDAB01Service();
            DataTable dt = dyDab01Service.GetDataTable(data.ID);

            List<DYDAB01Row> lstDyDab01 = new List<DYDAB01Row>();
            foreach (DataRow dr in dt.Rows)
            {
                DYDAB01Row dyDab01 = DYDAB01Row.GetModel(dr);
                lstDyDab01.Add(dyDab01);
            }

            e.Result = GetLstDYDAB01Row(lstSortInfo, lstDyDab01);
        }

        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<ITreeData> lstTreeData = e.Result as List<ITreeData>;

            Func<ITreeData, string> getId = (x => x.ID);
            Func<ITreeData, string> getParentId = (x => x.PID);
            Func<ITreeData, string> getDisplayName = (x => x.Text);
            Func<ITreeData, int> getImageIndex = (x => x.ImageIndex);

            if (treeViewFast1.Visible)
            {
                treeViewFast1.BeginUpdate();
                if (tnProject == null)
                    treeViewFast1.LoadItems(lstTreeData, getId, getParentId, getDisplayName, getImageIndex);
                else
                    treeViewFast1.LoadItems(lstTreeData, tnProject.Nodes, getId, getParentId, getDisplayName, getImageIndex);
                treeViewFast1.ExpandAll();

                if (treeViewFast1.Nodes.Count > 0)
                    treeViewFast1.Nodes[0].EnsureVisible();
                treeViewFast1.EndUpdate();
            }
            else
            {
                List<string> lstPropertyName = new List<string>();
                lstPropertyName.Add(SortType.YQCLX.ToString());
                lstPropertyName.Add(SortType.KFFS.ToString());

                treeListView1.BeginUpdate();
                if (tlviProject == null)
                    treeListView1.LoadItems(lstTreeData, getId, getParentId, getDisplayName, getImageIndex, lstPropertyName);
                else
                    treeListView1.LoadItems(lstTreeData, tlviProject.Items, getId, getParentId, getDisplayName, getImageIndex, lstPropertyName);
                treeListView1.ExpandAll();
                if (treeListView1.Items.Count > 0)
                    treeListView1.Items[0].EnsureVisible();
                treeListView1.EndUpdate();
            }
        }

        //组织成IP、PID、Text的接口队列
        public List<ITreeData> GetLstDYDAB01Row(List<SortInfo> lstSortInfo, List<DYDAB01Row> lstRows)
        {
            Dictionary<string, ITreeData> dict = new Dictionary<string, ITreeData>();
            foreach (DYDAB01Row dr in lstRows)
            {
                string tagStr = null;
                for (int i = 0; i < lstSortInfo.Count; i++)
                {
                    TreeData td = new TreeData();
                    td.PID = tagStr;

                    string fieldName = GetFieldBySortType(lstSortInfo[i].Type);
                    object objValue = PublicMethods.GetPropertyValue(dr, fieldName);
                    string fieldValue = objValue == null ? "" : objValue.ToString();
                    if (string.IsNullOrEmpty(fieldValue))
                        fieldValue = "其它";

                    if (!string.IsNullOrEmpty(tagStr))
                        tagStr += "_";
                    tagStr += fieldValue;
                    //如果已经包含此键
                    if (dict.ContainsKey(tagStr))
                        continue;

                    td.ID = tagStr;
                    td.ImageIndex = 1;
                    td.Text = fieldValue;
                    dict.Add(tagStr, td); //lstTreeData.Add(td);
                }

                dr.PID = tagStr;
                dr.ImageIndex = 2;
                dict.Add(dr.ID, dr);
            }

            return dict.Values.ToList<ITreeData>();
        }

        private string GetFieldBySortType(SortType sortType)
        {
            //暂时是枚举类型等于字段名
            return sortType.ToString();
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

        public TreeViewFast TreeViewFast
        {
            get
            {
                return treeViewFast1;
            }
        }

        private void tsbNodeText_Click(object sender, EventArgs e)
        {
            FrmSplitText fst = new FrmSplitText();
            if (fst.ShowDialog(this) != DialogResult.OK)
                return;
        }

        private void InitContol(Control ctrl)
        {
            visualCtrl = ctrl;
            if (visualCtrl == treeListView1)
            {
                treeListView1.Visible = true;
                treeViewFast1.Visible = false;
            }
            else
            {
                treeViewFast1.Visible = true;
                treeListView1.Visible = false;
            }

            ctrl.Location = new Point(0, toolStrip1.Height);
            ctrl.Size = new Size(this.Width, this.Height - 6 - toolStrip1.Height);
            ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
| System.Windows.Forms.AnchorStyles.Left)
| System.Windows.Forms.AnchorStyles.Right)));
        }

        private void tsbSwitch_Click(object sender, EventArgs e)
        {
            //Control ctrl = treeViewFast1.Visible ? treeListView1 : treeViewFast1;
            //Control ctrl;
            //if (treeViewFast1.Visible)
            //    ctrl = treeListView1;
            //else
            //    ctrl = treeViewFast1;
            //InitContol(ctrl);

            //LoadFast();
        }

        public event EventHandler SwitchProject;
        private void tsbReturn_Click(object sender, EventArgs e)
        {
            if (SwitchProject != null)
                SwitchProject(sender, e);
        }
    }
}
