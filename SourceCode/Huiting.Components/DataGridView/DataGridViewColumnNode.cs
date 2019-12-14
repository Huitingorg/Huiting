using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BDSoft.Components
{

    [Serializable]
    [TypeConverter(typeof(HWVDataGridViewColumnConverter))]
    [Editor(typeof(HWVDataGridViewColumnEditor), typeof(UITypeEditor))]
    public class DataGridViewColumnNode
    {
        #region Properties

        bool visible = true;

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        string format;

        public string Format
        {
            get { return format; }
            set { format = value; }
        } 

        int width = 100;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        bool frozen = false;

        public bool Frozen
        {
            get { return frozen; }
            set { frozen = value; }
        }

        bool readOnly = false;

        public bool ReadOnly
        {
            get { return readOnly; }
            set { readOnly = value; }
        }

        Color foreColor=Color.Black;
        public Color ForeColor
        {
            get { return foreColor; }
            set { foreColor = value; }
        }

        Color backColor=Color.White;

        DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleRight;

        public DataGridViewContentAlignment Alignment
        {
            get { return alignment; }
            set { alignment = value; }
        }

        public Color BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }

        //名字
        string name = "";
        //[HWVProperty(DisplayName = "列名称", Category = "数据", Description = "列名称")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //显示值
        string text = "";
        //[HWVProperty(DisplayName = "显示文本", Category = "数据", Description = "显示文本")]
        public string Text
        {
            get
            {
                if (string.IsNullOrEmpty(text))
                    text = name;
                return text;
            }
            set { text = value; }
        }

        string dataPropertyName = "";
        /// <summary>
        /// 数据属性
        /// </summary>
        public string DataPropertyName
        {
            get { return dataPropertyName; }
            set { dataPropertyName = value; }
        }

        ///私有字段
        List<DataGridViewColumnNode> childColumns = new List<DataGridViewColumnNode>();
        public List<DataGridViewColumnNode> ChildColumns
        {
            get { return childColumns; }
            set { childColumns = value; }
        }
        //拥有者
        DataGridViewColumnNode parent = null;
        public DataGridViewColumnNode Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        DataGridViewCellType cellType = DataGridViewCellType.Text;

        public DataGridViewCellType CellType
        {
            get { return cellType; }
            set { cellType = value; }
        }



        //是否是叶子列
        //[HWVProperty(DisplayName = "叶子节点", Category = "数据", Description = "是否是叶子列")]
        public bool IsLeafColumn
        {
            get
            {
                if (childColumns == null)
                    return true;
                return childColumns.Count <= 0;
            }
        }
        //层级
        //[HWVProperty(DisplayName = "虚假层级", Category = "数据", Description = "虚假层级，比真实层级小1")]
        public int FakeLevel
        {
            get
            {
                return RealLevel - 1;
            }
        }

        //[HWVProperty(DisplayName = "真实层级", Category = "数据", Description = "真实层级")]
        public int RealLevel
        {
            get
            {
                return GetLevel(this);
            }
        }

        public DataGridViewColumnNode GetParent(int levelIndex)
        {
            int rLevel = RealLevel;
            if (rLevel == levelIndex)
                return this;
            else if (rLevel < levelIndex)
            {
                foreach (DataGridViewColumnNode item in this.childColumns)
                    return item.GetParent(levelIndex);
            }

            return null;
        }

        //第一个子列
        public DataGridViewColumnNode FristColumn
        {
            get
            {
                if (childColumns.Count <= 0)
                    return null;
                return childColumns[0];
            }
        }

        public int Deep
        {
            get
            {
                int deep = getDepth(this);
                return deep;
            }
        }

        int getDepth(DataGridViewColumnNode dgvc)
        {
            int max = 0;
            if (dgvc.childColumns == null || dgvc.childColumns.Count == 0)
                return 0;
            else
            {
                for (int i = 0; i < dgvc.childColumns.Count; i++)
                {
                    DataGridViewColumnNode item = dgvc.ChildColumns[i];
                    if (getDepth(item) > max)
                        max = getDepth(item);
                }
                return max + 1;
            }
        }

        #endregion

        #region Constructor

        public DataGridViewColumnNode()
        {

        }
        public DataGridViewColumnNode(string text)
        {
            this.name = Guid.NewGuid().ToString() ;
            this.text = text;
        }

        #endregion

        #region Event

        public event EventHandler TreeHeadColumnChanged;

        #endregion

        #region Methodes

        public void AddChildColumn(string text)
        {
            DataGridViewColumnNode hwvDgvc = new DataGridViewColumnNode();
            hwvDgvc.text = text;
            hwvDgvc.name = text;
            this.childColumns.Add(hwvDgvc);
        }

        public void AddChildColumn(DataGridViewColumnNode hwvDgvc)
        {
            if (hwvDgvc == null)
                return;
            if (childColumns.Contains(hwvDgvc))
                return;
            childColumns.Add(hwvDgvc);

            if (hwvDgvc.parent != this)
                hwvDgvc.parent = this;
        }

        public void AddChildColums(DataGridViewColumnNode[] hwvDgvcAry)
        {
            foreach (DataGridViewColumnNode item in hwvDgvcAry)
            {
                this.AddChildColumn(item);
            }
        }


        public void RemoveChildColumn(DataGridViewColumnNode hwvDgvc)
        {
            if (!childColumns.Contains(hwvDgvc))
                return;

            childColumns.Remove(hwvDgvc);
            if (TreeHeadColumnChanged != null)
                TreeHeadColumnChanged(null, null);
        }

        private int GetLevel(DataGridViewColumnNode columnInfo)
        {
            int level = 0;
            SubGetLevel(columnInfo, ref level);
            return level;
        }

        private void SubGetLevel(DataGridViewColumnNode columnInfo, ref int level)
        {
            if (columnInfo.parent == null)
                return;

            level++;
            SubGetLevel(columnInfo.parent, ref level);
        }

        #region 获取叶子节点列

        public List<DataGridViewColumnNode> GetLstLeafColumn()
        {
            List<DataGridViewColumnNode> lstLeafColumn = new List<DataGridViewColumnNode>();
            SubGetLstLeafColumn(this, ref lstLeafColumn);
            return lstLeafColumn;
        }
        private void SubGetLstLeafColumn(DataGridViewColumnNode dgvc, ref List<DataGridViewColumnNode> lstLeafColumn)
        {
            if (dgvc.IsLeafColumn)
            {
                lstLeafColumn.Add(dgvc);
                return;
            }
            for (int i = 0; i < dgvc.childColumns.Count; i++)
            {
                DataGridViewColumnNode item = dgvc.ChildColumns[i];
                SubGetLstLeafColumn(item, ref lstLeafColumn);
            }
        }

        #endregion

        /// <summary>
        /// 浅复制
        /// </summary>
        /// <returns></returns>
        public DataGridViewColumnNode Clone()
        {
            DataGridViewColumnNode hwvDGVC = new DataGridViewColumnNode();
            hwvDGVC.text = this.text;
            hwvDGVC.name = this.name;

            return hwvDGVC;
        }

        public override string ToString()
        {
            return this.text;
        }

        #endregion
    }

    public enum DataGridViewCellType
    {
        Text,
        CheckBox,
    }

}
