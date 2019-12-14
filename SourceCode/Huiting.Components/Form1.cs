using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BDSoft.Common;

namespace BDSoft.Components
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FreeLayoutPanel<IFreeLayoutChildControl> flp;

        private void Form1_Load(object sender, EventArgs e)
        {
            RoundedTabControl myTabCtrl = new RoundedTabControl();

            TabPage tp = new TabPage();
            tp.ToolTipText = "Hello,wold!";
            myTabCtrl.TabPages.Add(tp);

            myTabCtrl.TabPages.Add("0", "fdsfs");
            myTabCtrl.Dock = DockStyle.Fill;
            groupBox1.Controls.Add(myTabCtrl);

            flp = new FreeLayoutPanel<IFreeLayoutChildControl>();
            groupBox2.Controls.Add(flp);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<IFreeLayoutChildControl> lstCtrl = new List<IFreeLayoutChildControl>();
            for (int i = 0; i < 50; i++)
            {
                //PacketMousePanel imp = new PacketMousePanel();
                //UnitMousePanel imp = new UnitMousePanel();
                ItemMousePanel imp = new ItemMousePanel();
                imp.Title += i.ToString();
                lstCtrl.Add(imp);
            }

            try
            {
                flp.Init(lstCtrl);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ItemMousePanel imp = new ItemMousePanel();
            imp.Location = new Point(50,50);
            this.groupBox3.Controls.Add(imp);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FontMousePanel fmp = new FontMousePanel();
            fmp.Location = new Point(340, 50);
            this.groupBox3.Controls.Add(fmp);
        }
    }
}
