using Huiting.Common;
using ReserveCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveAnalysis
{
    public class UnitGroupPanel : Panel
    {
        List<IEntityData> lstAllData;
        Dictionary<UnitFunctionGroupType, List<IEntityData>> groupData;
        Dictionary<UnitFunctionGroupType, IGroupPanel> groupPanel;

        Panel panelContent;

        public event EventHandler ItemClick;

        public UnitGroupPanel()
        {
            this.Dock = DockStyle.Fill;
            //this.BackColor = Color.LightGreen;
            this.AutoScroll = true;
            this.AutoScroll = true;

            panelContent = new Panel();
            panelContent.Location = new Point(0, 0);
            panelContent.Width = this.Width - 16;
            //panelContent.Size = new Size(this.Width - 16, this.Height);
            //panelContent.Size = new Size(this.Width - 16, this.Height);
            panelContent.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            panelContent.Anchor = ((AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right));
            //panelContent.BackColor = Color.LightBlue;
            this.Controls.Add(panelContent);
        }

        public void Init(List<IEntityData> lstAllData)
        {
            this.lstAllData = lstAllData;
            groupData = GetNewDataStructure(lstAllData);
            InitControls(groupData);
        }

        //换一种数据结构存储
        private Dictionary<UnitFunctionGroupType, List<IEntityData>> GetNewDataStructure(List<IEntityData> lstAllData)
        {
            Dictionary<UnitFunctionGroupType, List<IEntityData>> groupData = null;
            if (groupData == null)
                groupData = new Dictionary<UnitFunctionGroupType, List<IEntityData>>();
            else
                groupData.Clear();

            foreach (int enumIndex in Enum.GetValues(typeof(UnitFunctionGroupType)))
            {
                UnitFunctionGroupType unitContentGroupType = (UnitFunctionGroupType)enumIndex;
                List<IEntityData> lstData = null;
                foreach (IEntityData item in lstAllData)
                {
                    if (lstData == null)
                        lstData = new List<IEntityData>();

                    FunctionData data= item as FunctionData;
                    if (data != null && unitContentGroupType == InternalMethods.GetUnitFunctionGroupType(data.FunctionType))
                        lstData.Add(item);
                }

                if (lstData == null || lstData.Count <= 0)
                    continue;

                groupData.Add(unitContentGroupType, lstData);
            }

            return groupData;
        }

        bool flag = false;
        private void InitControls(Dictionary<UnitFunctionGroupType, List<IEntityData>> groupData)
        {
            flag = false;
            if (groupPanel == null)
                groupPanel = new Dictionary<UnitFunctionGroupType, IGroupPanel>();
            DisposeChildControls();

            foreach (KeyValuePair<UnitFunctionGroupType, List<IEntityData>> item in groupData)
            {
                if (groupPanel.ContainsKey(item.Key) == false)
                {
                    GroupPanel gp = new GroupPanel();
                    gp.Dock = DockStyle.Top;
                    gp.GroupPanelSizeChanged -= gp_GroupPanelSizeChanged;
                    gp.GroupPanelSizeChanged += gp_GroupPanelSizeChanged;
                    gp.DictionaryChanged -= gp_DictionaryChanged;
                    gp.DictionaryChanged += gp_DictionaryChanged;
                    panelContent.Controls.Add(gp);

                    groupPanel.Add(item.Key, gp);

                    gp.BringToFront();
                }

                groupPanel[item.Key].Init(item.Key, item.Value);
            }

            flag = true;
            ReSetHeight();
        }

        /// <summary>
        /// 擦出其它面板的选中状态
        /// </summary>
        /// <param name="oneGroupPanel"></param>
        private void RestoreExceptOne(IGroupPanel oneGroupPanel)
        {
            foreach (KeyValuePair<UnitFunctionGroupType, IGroupPanel> item in groupPanel)
            {
                if (item.Value == oneGroupPanel)
                    continue;
                item.Value.RestoreAll();
            }
        }

        void gp_DictionaryChanged(object sender, EventArgs e)
        {
            if (ItemClick != null)
            {
                EventArgsForDrawing eafd = e as EventArgsForDrawing;
                if (eafd != null)
                {
                    IGroupPanel oneGroupPanel = eafd.Sender as IGroupPanel;
                    RestoreExceptOne(oneGroupPanel);
                }

                ItemClick(sender, e);
            }
        }

        void gp_GroupPanelSizeChanged(object sender, EventArgs e)
        {
            if (flag == true)
                ReSetHeight();
        }

        private void ReSetHeight()
        {
            int maxBottom = 0;
            foreach (KeyValuePair<UnitFunctionGroupType, List<IEntityData>> item in groupData)
            {
                Control ctrl = groupPanel[item.Key] as Control;
                if (maxBottom < ctrl.Bottom)
                    maxBottom = ctrl.Bottom;
            }

            this.panelContent.Height = maxBottom;
        }

        private void DisposeChildControls()
        {
            if (groupData == null || groupData.Count <= 0 || groupPanel == null)
                return;

            foreach (KeyValuePair<UnitFunctionGroupType, IGroupPanel> item in groupPanel)
            {
                if (item.Value != null)
                    item.Value.DisposeChildControls();
            }
        }
    }
}