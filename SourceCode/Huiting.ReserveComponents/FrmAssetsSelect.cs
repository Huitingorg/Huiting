using Huiting.Common;
using Huiting.Components;

using ReserveCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReserveComponents
{
    public partial class FrmAssetsSelect : FrmChild
    {
        List<AssetsData> lstAssetsAdd = new List<AssetsData>();

        public List<AssetsData> LstAssetsAdd
        {
            get { return lstAssetsAdd; }
            set { lstAssetsAdd = value; }
        }

        List<AssetsData> lstAssetsDel = new List<AssetsData>();

        public List<AssetsData> LstAssetsDel
        {
            get { return lstAssetsDel; }
            set { lstAssetsDel = value; }
        }

        public FrmAssetsSelect()
        {
            InitializeComponent();
        }

        public FrmAssetsSelect(List<ProjectData> lstProjectData, ProjectData curData)
        {
            InitializeComponent();
            //this.uctNewTreeByTree1.InitData(lstProjectData, data);
            this.uctNewTreeByTree1.InitFirstData(lstProjectData);
            this.uctNewTreeByTree1.InitSecondData(curData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uctNewTreeByTree1.GetChangedLstAssetsData(out lstAssetsAdd, out lstAssetsDel);
            if (lstAssetsDel != null && lstAssetsDel.Count > 0)
            {
                List<string> lstDydm = PublicMethods.GetLstStringByLstT(lstAssetsDel, "ID");
                string strDydm = PublicMethods.GetStringByLstString(lstDydm);
                if (PublicMethods.AskQuestion(this, "您确定要删除以下单元及该单元在其评价年度下的所有预测信息么?\r\n" + strDydm) == false)
                    return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}