using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BDSoft.Components
{
    public class TreeViewWithData<T>:TreeViewByRightSelected
    {
        private void LoadTreeView(DataTable dt)
        {
            this.Nodes.Clear();

            #region 添加根节点

            TreeNode tnRoot = new TreeNode();
            tnRoot.Text = "全部单元";
            tnRoot.Tag = null;
            tnRoot.SelectedImageIndex = 0;
            tnRoot.ImageIndex = 0;

            this.Nodes.Add(tnRoot);

            #endregion

            SubAddTreeNode(tnRoot, "0", dt);

            tnRoot.Expand();
        }

        private void SubAddTreeNode(TreeNode tnParent, string ParentID, DataTable dt)
        {
            #region 数据准备

            //得到子节点信息   
            DataRow[] DataChild = dt.Select("ParentID ='" + ParentID + "'");
            if (DataChild.Length <= 0)
                return;

            List<DataRow> list = new List<DataRow>();
            foreach (DataRow row in DataChild)
                list.Add(row);
            IEnumerable<DataRow> rows = list.OrderBy(
      t =>
      {
          if (!string.IsNullOrEmpty(t["DYDM"].ConvertString()))
          {
              return t["DYDM"];
          }
          else if (!string.IsNullOrEmpty("ID"))
          {
              return t["ID"];
          }
          else
              return t["ParentID"];
      }
          );

            #endregion

            #region 添加子节点

            //循环遍历子节点信息   
            foreach (DataRow drChild in rows)
            {
                //加载子节点   
                TreeNode tnChild = new TreeNode();
                EntityTreeData et = this.GetEntityItem(drChild);
                tnChild.Text = et.NodeText;
                tnChild.Name = et.ID.ToString();
                tnChild.Tag = et;

                if (string.IsNullOrEmpty(et.DYDM))
                    tnChild.SelectedImageIndex = tnChild.ImageIndex = 1;
                else
                {
                    tnChild.ImageIndex = 2;
                    tnChild.SelectedImageIndex = 3;
                }

                tnParent.Nodes.Add(tnChild);
                //形成递归   
                SubAddTreeNode(tnChild, et.ID, dt);
            }

            #endregion
        }
    }
}
