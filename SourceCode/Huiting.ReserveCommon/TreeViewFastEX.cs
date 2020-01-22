using BDSoft.Common;
using LocalDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReserveCommon
{
    public class TreeViewFastEX : TreeViewFast
    {
        private ImageList imageList1;

        ////添加项目
        //public void LoadItems(IEnumerable<DYDAB01Row> items, List<SortInfo> lstSortInfo)
        //{
        //    Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();

        //    List<string> lstStr;
        //    foreach (DYDAB01Row dr in items)
        //    {
        //        #region 收集每级分组内容


        //        for (int i = 0; i < lstSortInfo.Count; i++)
        //        {
        //            if (!dict.ContainsKey(i))
        //                dict.Add(i, new List<string>());
        //            lstStr = dict[i];
        //            string value = dr.GetPropertyValue(lstSortInfo[i].Type.ToString());
        //            //if(string.IsNullOrEmpty(value))
        //            if (lstStr.Contains(value))
        //                continue;
        //            lstStr.Add(value);
        //        }

        //        #endregion

        //        TreeNode tn = new TreeNode();
        //        tn.Text = dr.DYMC;
        //        tn.Tag = dr;
        //        _treeNodes.Add(dr.DYDM, tn);
        //    }

        //    foreach (KeyValuePair<int, List<string>> item in dict)
        //    {
        //        foreach (string typeValueName in item.Value)
        //        {

        //        }
        //    }
        //}

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeViewFastEX));
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "open_project.png");
            this.imageList1.Images.SetKeyName(1, "oilField.png");
            this.imageList1.Images.SetKeyName(2, "unit.png");
            this.ResumeLayout(false);

        }
    }
}
