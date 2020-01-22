using Huiting.Components;
using Huiting.Components.DrawPanel;
using ReserveCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveAnalysis
{
    class UnitNavigationPanel : NavigationPanel
    {
        public event EventHandler ItemClick;

        public void Init(List<IEntityData> lstEtd)
        {
            this.Controls.Clear();
            foreach (IEntityData item in lstEtd)
            {
                AddControl(item);
                if (item != lstEtd[lstEtd.Count-1])
                    AddControl(" > ");
            }
            //FontMousePanel fmpAll = AddControl(ProjectInnerMethods.RootName);
            //fmpAll.Click -= fmp1_Click;
            //fmpAll.Click += fmp1_Click;
        }

        private void AddControl(IEntityData item)
        {
            FontMousePanel fmp1 = new FontMousePanel();
            fmp1.Tag = item;
            fmp1.Dock = DockStyle.Left;
            fmp1.KeyWorld = item.Text;
            fmp1.Click -= fmp1_Click;
            fmp1.Click += fmp1_Click;
            this.Controls.Add(fmp1);
        }

        private FontMousePanel AddControl(string Text)
        {
            FontMousePanel fmp1 = new FontMousePanel();
            fmp1.Dock = DockStyle.Left;
            fmp1.KeyWorld = Text;
            this.Controls.Add(fmp1);
            return fmp1;
        }

        void fmp1_Click(object sender, EventArgs e)
        {
            FontMousePanel fmp = sender as FontMousePanel;
            IEntityData etd = fmp.Tag as IEntityData;
            if (etd == null)
                return;

            if (ItemClick != null)
            {
                ItemClick(etd, null);
            }

        }
    }
}
