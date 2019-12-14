using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDSoft.Components
{
    public class NavigationPanel : DrawPanel
    {
        public NavigationPanel()
        {
            this.Dock = DockStyle.Top;
            this.BorderColor = Color.FromArgb(245, 245, 245);
            this.Height = 30;
            this.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);

            FontMousePanel fmp1 = new FontMousePanel();
            fmp1.Dock = DockStyle.Left;
            fmp1.KeyWorld = "全部单元";
            this.Controls.Add(fmp1);
        }

        public class ItemInfo
        {
            public string ID;
            public string Text;
        }
    }

}
