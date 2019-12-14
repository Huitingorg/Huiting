using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Huiting.DataEditor.Controls
{
    public partial class UC_DataUnitSel : UserControl
    {
        private string selUnit = "";
        public string SelUnit
        {
            get
            {
                return selUnit;
            }
            set
            {
                selUnit = value;

                foreach(Control curCon in Panel_Base.Controls)
                {
                    if(string.IsNullOrEmpty(selUnit))
                    {
                        if(curCon.Text == "无")
                        {
                            ((RadioButton)curCon).Checked = true;

                        }
                        
                    }
                    else
                    {
                        if (curCon.Text == selUnit)
                        {
                            ((RadioButton)curCon).Checked = true;

                        }
                    }
                }
            }

        }

        private string unitStrList = "";

        public string UnitStrList
        {
            get
            {
                return unitStrList;
            }
            set
            {
                unitStrList = value;
                InitSelItem();
            }
        }

        public UC_DataUnitSel()
        {
            InitializeComponent();
        }

        private void InitSelItem()
        {
            foreach (Control curCon in Panel_Base.Controls)
            {
                curCon.Parent = null;
                curCon.Visible = false;
                curCon.Dispose();
            }

            RadioButton noneRadio = new RadioButton();
            noneRadio.Text = "无";
            noneRadio.Parent = Panel_Base;
            noneRadio.AutoSize = true;
            noneRadio.Click += NoneRadio_Click;
            
            if (string.IsNullOrEmpty(UnitStrList))
            {
                return;
            }

            string[] UnitList = UnitStrList.Split('|');
            foreach(string curStr in UnitList)
            {
                RadioButton NewRadio = new RadioButton();
                NewRadio.Text = curStr;
                NewRadio.AutoSize = true;
                NewRadio.Parent = Panel_Base;
                NewRadio.Click += NoneRadio_Click;
            }
        }

        private void NoneRadio_Click(object sender, EventArgs e)
        {
            SelUnit = ((RadioButton)sender).Text;
            if(SelUnit == "无")
            {
                SelUnit = "";
            }
        }
    }
}
