using Huiting.Common;
using ReserveCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveAnalysis
{
    public interface IGroupPanel
    {
        UnitFunctionGroupType UnitFunctionGroupType { get; set; }
        void DisposeChildControls();
        void Init(UnitFunctionGroupType UnitFunctionGroupType, List<IEntityData> lstData);
        void RestoreAll();
    }

    public class GroupPanel : Panel, IGroupPanel
    {
        GroupTitlePanel titlePanel;
        UnitFreeLayoutPanel unitFreeLayoutPanel;

        //List<ITreeNodeData> lstData;
        public event EventHandler DictionaryChanged;
        public event EventHandler GroupPanelSizeChanged;

        public GroupPanel()
        {
            unitFreeLayoutPanel = new UnitFreeLayoutPanel();
            unitFreeLayoutPanel.Dock = DockStyle.Fill;
            //unitFreeLayoutPanel.ItemClick -= unitFreeLayoutPanel_ItemClick;
            //unitFreeLayoutPanel.ItemClick += unitFreeLayoutPanel_ItemClick;
            unitFreeLayoutPanel.ItemDoubleClick -= unitFreeLayoutPanel_ItemClick;
            unitFreeLayoutPanel.ItemDoubleClick += unitFreeLayoutPanel_ItemClick;
            this.Controls.Add(unitFreeLayoutPanel);
            this.unitFreeLayoutPanel.AutoScroll = false;

            titlePanel = new GroupTitlePanel();
            titlePanel.Dock = DockStyle.Top;
            this.Controls.Add(titlePanel);
        }

        void unitFreeLayoutPanel_ItemClick(object sender, EventArgs e)
        {
            EventArgsForDrawing eafd = new EventArgsForDrawing();
            eafd.Sender = this;

            if (DictionaryChanged != null)
                DictionaryChanged(sender, eafd);
        }

        public void RestoreAll()
        {
            this.unitFreeLayoutPanel.RestoreAll();
        }

        UnitFunctionGroupType unitContentGroupType;
        public UnitFunctionGroupType UnitFunctionGroupType
        {
            get
            {
                return unitContentGroupType;
            }
            set
            {
                unitContentGroupType = value;
            }
        }

        public void DisposeChildControls()
        {
            //this.unitFreeLayoutPanel.Controls.Clear();
            this.unitFreeLayoutPanel.DisposeChildControls();
        }

        public void Init(UnitFunctionGroupType UnitFunctionGroupType, List<IEntityData> lstData)
        {
            this.unitContentGroupType = UnitFunctionGroupType;
            this.titlePanel.Title = EnumDictionary<UnitFunctionGroupType>.Instance.GetDescription(unitContentGroupType);
            this.unitFreeLayoutPanel.InitInterface(lstData, IconLayoutType.LeftWordRightImage, false);
            this.Height = this.unitFreeLayoutPanel.GetCompactHeight() + titlePanel.Height;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Height = this.unitFreeLayoutPanel.GetCompactHeight() + titlePanel.Height;
            if (GroupPanelSizeChanged != null)
                GroupPanelSizeChanged(this, e);
        }
    }
}