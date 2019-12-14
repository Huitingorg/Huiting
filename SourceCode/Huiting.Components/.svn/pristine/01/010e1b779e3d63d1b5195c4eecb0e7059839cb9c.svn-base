using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BDSoft.Components
{
    public class TreeHeadDataGridView : DataGridView
    {
        #region Fields

        /// <summary>
        /// 基础行高
        /// </summary>
        const int basicHeadCellHeight = 25;
        /// <summary>
        /// 表头实际行高
        /// </summary>
        private int realHeadCellHeight = basicHeadCellHeight;
        /// <summary>
        /// 表头实际行高
        /// </summary>
        public int RealHeadCellHeight
        {
            get
            {
                if (realHeadCellHeight < basicHeadCellHeight)
                    return basicHeadCellHeight;
                return realHeadCellHeight;
            }
            set
            {
                if (realHeadCellHeight == value)
                    return;
                if (realHeadCellHeight < basicHeadCellHeight)
                    realHeadCellHeight = basicHeadCellHeight;
                else
                    realHeadCellHeight = value;
            }
        }
        /// <summary>
        /// 列表头深度
        /// </summary>
        private int columnDeep = 1;
        /// <summary>
        /// 叶子节点队列
        /// </summary>
        List<DataGridViewColumnNode> lstLeafColumn = null;

        Pen gridLinePen;
        SolidBrush gridBrush;

        #endregion

        #region  Properties

        public bool ChangeRow = false;
        public event EventHandler DataGridViewEnterKeyEvent;//表保存触发
        public bool LastRowColumnOpEnterFocusEven = false;
        /// <summary>
        /// 树形表头根列，注：根列不会参与表头绘制，而是子节点集合会。
        /// </summary>
        DataGridViewColumnNode treeHeadRootColumn = new DataGridViewColumnNode();
        /// <summary>
        /// 树形表头根列，注：根列不会参与表头绘制，而是子节点集合会。
        /// </summary>
        public DataGridViewColumnNode TreeHeadRootColumn
        {
            get { return treeHeadRootColumn; }
        }

        #endregion

        #region Constructor

        public TreeHeadDataGridView()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw |  
               ControlStyles.OptimizedDoubleBuffer |  
               ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles(); ;

            base.AutoGenerateColumns = false;
            gridBrush = new SolidBrush(this.GridColor);
            gridLinePen = new Pen(gridBrush, 1);
            //多维列必须的，
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //this.BackgroundColor = Color.White;
        }

        #endregion

        #region Component Designer Generated Code

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // TreeHeadDataGridView
            // 
            this.ColumnHeadersHeight = 36;
            this.RowTemplate.Height = 23;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Methodes

        public DataGridViewColumnNode GetParent(int levelIndex)
        {
            DataGridViewColumnNode dgvcn = treeHeadRootColumn.GetParent(levelIndex);
            return dgvcn;
        }

        public DataGridViewColumnNode GetDataGridViewColumnNode(string columnName)
        {
            return treeHeadRootColumn.GetLstLeafColumn().Find(x => x.DataPropertyName.ToLower() == columnName.ToLower());
        }

        public string GetHeaderText(string columnName)
        {
            DataGridViewColumnNode dgvcn2 = GetDataGridViewColumnNode(columnName);
            if (dgvcn2 != null)
                return dgvcn2.Text;

            return null;
        }


        public void SetHeaderText(string columnName, string newColumnText)
        {
            DataGridViewColumnNode dgvcn2 = GetDataGridViewColumnNode(columnName);
            if (dgvcn2 != null)
                dgvcn2.Text = newColumnText;
        }

        public void SetTreeHeadRootColumn(DataGridViewColumnNode TreeHeadRootColumn)
        {
            this.treeHeadRootColumn = TreeHeadRootColumn;
            this.InitTreeHeadRootColumn();
        }

        /// <summary>
        /// 添加复杂表头信息
        /// </summary>
        /// <param name="rootHwvDgvColumn"></param>
        private void InitTreeHeadRootColumn()
        {
            try
            {
                this.SuspendLayout();
                //以下两个参数与数据源有关，但不能每次都从数据源获取，效率问题
                lstLeafColumn = treeHeadRootColumn.GetLstLeafColumn();
                if (lstLeafColumn.Count <= 0)
                    return;

                this.Columns.Clear();
                for (int i = 0; i < lstLeafColumn.Count; i++)
                {
                    DataGridViewColumn dgvc;
                    if (lstLeafColumn[i].CellType == DataGridViewCellType.Text)
                    {
                        dgvc = new DataGridViewTextBoxColumn();
                        if (!string.IsNullOrEmpty(lstLeafColumn[i].Format))
                            dgvc.DefaultCellStyle.Format = lstLeafColumn[i].Format;
                    }
                    else
                    {
                        dgvc = new DataGridViewCheckBoxColumn();
                        ((DataGridViewCheckBoxColumn)dgvc).TrueValue = 1;
                    }

                    this.Columns.Add(dgvc);

                    ////如果缺少列，则自动补充
                    //if (this.Columns.Count <= i)
                    //{
                    //    DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
                    //    //dgvc.HeaderText = dgvc.Name = Guid.NewGuid().ToString();
                    //    //dgvc.CellTemplate = new DataGridViewTextBoxCell();
                    //    if (!string.IsNullOrEmpty(lstLeafColumn[i].Format))
                    //        dgvc.DefaultCellStyle.Format = lstLeafColumn[i].Format;
                    //    this.Columns.Add(dgvc);
                    //}

                    this.Columns[i].Name = lstLeafColumn[i].DataPropertyName;
                    this.Columns[i].DataPropertyName = lstLeafColumn[i].DataPropertyName;
                    this.Columns[i].Frozen = lstLeafColumn[i].Frozen;
                    this.Columns[i].ReadOnly = lstLeafColumn[i].ReadOnly;
                    this.Columns[i].DefaultCellStyle.BackColor = lstLeafColumn[i].BackColor;
                    this.Columns[i].Width = lstLeafColumn[i].Width;
                    this.Columns[i].DefaultCellStyle.Alignment = lstLeafColumn[i].Alignment;
                    this.Columns[i].DefaultCellStyle.Format = lstLeafColumn[i].Format;
                    this.Columns[i].Visible = lstLeafColumn[i].Visible;
                }

                columnDeep = treeHeadRootColumn.Deep;
                if (columnDeep == 0)
                    columnDeep = 1;
                this.ColumnHeadersHeight = columnDeep * basicHeadCellHeight;
                if (treeHeadRootColumn.ChildColumns.Count > 0)
                {
                    this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    //为了背景颜色一致
                    this.EnableHeadersVisualStyles = false;
                }

                this.ResumeLayout(false);
            }
            catch (Exception ex)
            {
            }
        }

        ///<summary>
        ///绘制合并表头--绘制表头思路改进
        ///</summary>
        ///<param name="node">合并表头节点</param>
        ///<param name="e">绘图参数集</param>
        ///<param name="level">结点深度</param>
        ///<remarks></remarks>
        private void PaintUnitHeader(DataGridViewColumnNode node, System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
        {
            bool columnVisible = this.Columns[e.ColumnIndex].Visible;

            Rectangle uhRectangle;
            SolidBrush backColorBrush = new SolidBrush(e.CellStyle.BackColor);

            int fakeLevel = node.FakeLevel;
            if (node.ChildColumns.Count == 0)
            {
                if (e.ColumnIndex == 1)
                {

                }
                if (e.ColumnIndex == 2)
                {

                }

                #region 叶子

                //此列没有子列，且是顶级列
                if (fakeLevel == 0)
                {
                    uhRectangle = new Rectangle(e.CellBounds.Left - 1,
                                e.CellBounds.Top + fakeLevel * realHeadCellHeight - 1,
                                e.CellBounds.Width,
                                this.ColumnHeadersHeight);
                }
                //此列是最后一列
                else if (fakeLevel == columnDeep - 1)
                {
                    uhRectangle = new Rectangle(e.CellBounds.Left - 1,
                                e.CellBounds.Top + fakeLevel * realHeadCellHeight - 1,
                                e.CellBounds.Width,
                                this.ColumnHeadersHeight - realHeadCellHeight * (columnDeep - 1));
                }
                //其它情况
                else
                {
                    uhRectangle = new Rectangle(e.CellBounds.Left - 1,
                                e.CellBounds.Top + fakeLevel * realHeadCellHeight - 1,
                                e.CellBounds.Width,
                                realHeadCellHeight * (columnDeep - fakeLevel));
                }

                if (e.ColumnIndex == 2)
                {

                }

                DrawCell(node, e, uhRectangle);

                #endregion
            }
            else
            {
                #region 非叶子

                //取得最左叶子节点
                DataGridViewColumnNode newtreenode1 = node;
                while (newtreenode1.FristColumn != null)
                {
                    newtreenode1 = newtreenode1.FristColumn;
                }
                //取得最左叶子节点列号
                int leftindex = GetColumnListNodeIndex(newtreenode1);

                //计算要减去的距离   
                int leftrangge = 0;

                for (int i = leftindex; i < e.ColumnIndex; i++)
                {
                    leftrangge += this.Columns[i].Width;
                }

                //int visibleColumnsCount = GetVisibleColumnsCount();
                //得到给节点对应的宽度
                int nodewidth = GetUnitHeaderWidth(node);
                //得到矩形区域
                uhRectangle = new Rectangle(e.CellBounds.Left - leftrangge - 1,
                         e.CellBounds.Top + fakeLevel * realHeadCellHeight,
                         nodewidth,
                         realHeadCellHeight);

                DrawCell(node, e, uhRectangle);

                #endregion
            }

            #region 递归

            //递归调用 使得每列触发该列上所有节点的重绘
            if (node.Parent != null)
            {
                PaintUnitHeader(node.Parent, e);
            }

            #endregion
        }

        private void DrawCell(DataGridViewColumnNode node, DataGridViewCellPaintingEventArgs e, Rectangle uhRectangle)
        {
            //Color clr = this.Columns[e.ColumnIndex].HeaderCell.Style.BackColor;
            ////DataGridView1.Columns[0].HeaderCell.Style.BackColor = Color.Blue;
            //if (e.CellStyle.BackColor == this.ColumnHeadersDefaultCellStyle.BackColor)
            //{
            //}

            //DataGridView1.ColumnHeadersDefaultCellStyle.BackColor 
            SolidBrush backColorBrush = new SolidBrush(e.CellStyle.BackColor);
            //if (e.ColumnIndex == 2)
            //    backColorBrush = new SolidBrush(Color.Pink);
            //SolidBrush backColorBrush = new SolidBrush(clr);
            // 画矩形 
            e.Graphics.FillRectangle(backColorBrush, uhRectangle);
            //画边框
            e.Graphics.DrawRectangle(gridLinePen, uhRectangle);

            string[] Ctext;//存放分组字符串
            if (node.Text.Contains(","))
            {
                Ctext = node.Text.Split(new char[] { ',' });
                int zhs = Ctext.Length;//字符串要显示的总行数
                for (int i = 0; i < zhs; i++)
                {
                    SizeF sf = e.Graphics.MeasureString(Ctext[i], this.Font);
                    e.Graphics.DrawString(Ctext[i], this.Font, new SolidBrush(e.CellStyle.ForeColor)
                                     , uhRectangle.Left + uhRectangle.Width / 2 - 1.0f * sf.Width / 2 + 2
                                     , uhRectangle.Top + uhRectangle.Height / 2 - 1.0f * sf.Height * zhs / 2 + 1.0f * sf.Height * i + 2);
                }

            }
            else
            {
                SizeF sf = e.Graphics.MeasureString(node.Text, this.Font);
                e.Graphics.DrawString(node.Text, this.Font, new SolidBrush(e.CellStyle.ForeColor)
                                       , uhRectangle.Left + uhRectangle.Width / 2 - 1.0f * sf.Width / 2 + 2
                                       , uhRectangle.Top + uhRectangle.Height / 2 - 1.0f * sf.Height / 2 + 2);
            }
        }

        private int GetVisibleColumnsCount()
        {
            int intCount = 0;
            foreach (DataGridViewColumn item in this.Columns)
            {
                if (item.Visible == true)
                    intCount++;
            }

            return intCount;
        }

        ///// <summary>
        ///// 获得合并标题字段的宽度--获得组合节点对应宽度
        ///// </summary>
        ///// <param name="node">字段节点</param>
        ///// <returns>字段宽度</returns>
        ///// <remarks></remarks>
        //private int GetUnitHeaderWidth(DataGridViewColumnNode node, int VisibleColumnsCount)
        //{
        //    //获得非最底层字段的宽度
        //    int uhWidth = 0;
        //    //获得最底层字段的宽度
        //    if (node.IsLeafColumn)
        //    {
        //        //当前序号
        //        int index = lstLeafColumn.IndexOf(node);
        //        int index2 = GetColumnListNodeIndex(node);
        //        //if (index < VisibleColumnsCount)
        //        uhWidth = this.Columns[index2].Width;

        //        return uhWidth;
        //    }

        //    for (int i = 0; i < node.ChildColumns.Count; i++)
        //    {
        //        uhWidth += GetUnitHeaderWidth(node.ChildColumns[i], VisibleColumnsCount);
        //    }
        //    return uhWidth;
        //}

        /// <summary>
        /// 获得合并标题字段的宽度--获得组合节点对应宽度
        /// </summary>
        /// <param name="node">字段节点</param>
        /// <returns>字段宽度</returns>
        /// <remarks></remarks>
        private int GetUnitHeaderWidth(DataGridViewColumnNode node)
        {
            //获得非最底层字段的宽度
            int uhWidth = 0;
            //获得最底层字段的宽度
            if (node.IsLeafColumn)
            {
                //当前序号
                //int index = lstLeafColumn.IndexOf(node);
                int index2 = GetColumnListNodeIndex(node);
                if (index2 < this.Columns.Count)
                    uhWidth = this.Columns[index2].Width;

                return uhWidth;
            }

            for (int i = 0; i < node.ChildColumns.Count; i++)
            {
                uhWidth += GetUnitHeaderWidth(node.ChildColumns[i]);
            }
            return uhWidth;
        }

        /// <summary>
        /// 获得底层节点对应的索引
        /// </summary>
        ///' <param name="node">底层字段节点</param>
        /// <returns>索引</returns>
        /// <remarks></remarks>
        private int GetColumnListNodeIndex(DataGridViewColumnNode node)
        {
            //for (int i = 0; i <= _columnList.Count - 1; i++)
            for (int i = 0; i < lstLeafColumn.Count; i++)
            {
                if (lstLeafColumn[i].Equals(node))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// 列宽度改变的重写
        /// </summary>
        /// <param name="e"></param>
        protected override void OnColumnWidthChanged(DataGridViewColumnEventArgs e)
        {
            try
            {
                base.OnColumnWidthChanged(e);
                //this.Refresh();
                if (lstLeafColumn == null || lstLeafColumn.Count == 0)
                    return;
                Graphics g = Graphics.FromHwnd(this.Handle);
                string text = "";
                if (e.Column.Index < lstLeafColumn.Count)
                    text = lstLeafColumn[e.Column.Index].Text;

                ////改进
                string[] HeaderTextMuliLine = text.Split(new char[] { ',' });
                string TextLongLine = HeaderTextMuliLine[0];
                for (int i = 0; i < HeaderTextMuliLine.Length; i++)
                {
                    if (HeaderTextMuliLine[i].Length > TextLongLine.Length)
                    {
                        TextLongLine = HeaderTextMuliLine[i];
                    }
                }
                float uwh = g.MeasureString(TextLongLine, this.Font).Width;

                //  float uwh = g.MeasureString(text, this.Font).Width;
                if (uwh >= e.Column.Width)
                {
                    e.Column.Width = Convert.ToInt16(uwh);
                }

                this.Refresh();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        /// <summary>
        /// 单元格绘制(重写)
        /// </summary>
        /// <param name="e"></param>
        /// <remarks></remarks>
        protected override void OnCellPainting(System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == -1 || lstLeafColumn == null || lstLeafColumn.Count<=0)
            {
                base.OnCellPainting(e);
                return;
            }

            //列标题重写
            if (e.RowIndex == -1 && e.ColumnIndex >= 0 && e.ColumnIndex < lstLeafColumn.Count)
            {
                PaintUnitHeader(lstLeafColumn[e.ColumnIndex], e);
                e.Handled = true;
            }
            else
            {
                //需要写，否则以后使用控件时不能触发单元格的刷新事件
                base.OnCellPainting(e);
            }
        }

        /// <summary>
        /// 列高改变
        /// </summary>
        /// <param name="e"></param>
        protected override void OnColumnHeadersHeightChanged(EventArgs e)
        {
            try
            {
                base.OnColumnHeadersHeightChanged(e);
                RealHeadCellHeight = this.ColumnHeadersHeight / columnDeep;

                this.Refresh();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 另存为(当前)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lcwexceldq(object sender, EventArgs e)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "保存EXECL文件";
            kk.Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                string FileName = kk.FileName;
                if (File.Exists(FileName))
                    File.Delete(FileName);//若该文件存在，删出该文件
                FileStream objFileStream;
                StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
                for (int i = 0; i < this.Columns.Count; i++)
                {
                    if (this.Columns[i].Visible == true)
                    {
                        strLine = strLine + this.Columns[i].HeaderText.ToString() + Convert.ToChar(9);
                    }
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";
                for (int i = 0; i < this.Rows.Count; i++)
                {
                    if (this.Rows[i].Visible == true)//打印呈现的
                    {
                        if (this.Columns[0].Visible == true)
                        {
                            if (this.Rows[i].Cells[0].Value == null)
                                strLine = strLine + " " + Convert.ToChar(9);
                            else
                                strLine = strLine + this.Rows[i].Cells[0].Value.ToString() + Convert.ToChar(9);
                        }
                        for (int j = 1; j < this.Columns.Count; j++)
                        {
                            if (this.Columns[j].Visible == true)
                            {
                                if (this.Rows[i].Cells[j].Value == null)
                                    strLine = strLine + " " + Convert.ToChar(9);
                                else
                                {
                                    string rowstr = "";
                                    rowstr = this.Rows[i].Cells[j].Value.ToString();
                                    if (rowstr.IndexOf("\r\n") > 0)
                                        rowstr = rowstr.Replace("\r\n", " ");
                                    if (rowstr.IndexOf("\t") > 0)
                                        rowstr = rowstr.Replace("\t", " ");
                                    strLine = strLine + rowstr + Convert.ToChar(9);
                                }
                            }
                        }
                        objStreamWriter.WriteLine(strLine);
                        strLine = "";
                    }
                }
                objStreamWriter.Close();
                objFileStream.Close();
                MessageBox.Show(this, "保存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        /// <summary>
        /// 另存为execel(全部)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lcwexcelqb(object sender, EventArgs e)
        {

            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "保存EXECL文件";
            kk.Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                string FileName = kk.FileName;
                if (File.Exists(FileName))
                    File.Delete(FileName);//若该文件存在，删出该文件
                FileStream objFileStream;
                StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
                for (int i = 0; i < this.Columns.Count; i++)
                {
                    if (this.Columns[i].Visible == true)
                    {
                        strLine = strLine + this.Columns[i].HeaderText.ToString() + Convert.ToChar(9);
                    }
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";
                for (int i = 0; i < this.Rows.Count; i++)
                {
                    if (this.Columns[0].Visible == true)
                    {
                        if (this.Rows[i].Cells[0].Value == null)
                            strLine = strLine + " " + Convert.ToChar(9);
                        else
                            strLine = strLine + this.Rows[i].Cells[0].Value.ToString() + Convert.ToChar(9);
                    }
                    for (int j = 1; j < this.Columns.Count; j++)
                    {
                        if (this.Columns[j].Visible == true)
                        {
                            if (this.Rows[i].Cells[j].Value == null)
                                strLine = strLine + " " + Convert.ToChar(9);
                            else
                            {
                                string rowstr = "";
                                rowstr = this.Rows[i].Cells[j].Value.ToString();
                                if (rowstr.IndexOf("\r\n") > 0)
                                    rowstr = rowstr.Replace("\r\n", " ");
                                if (rowstr.IndexOf("\t") > 0)
                                    rowstr = rowstr.Replace("\t", " ");
                                strLine = strLine + rowstr + Convert.ToChar(9);
                            }
                        }
                    }
                    objStreamWriter.WriteLine(strLine);
                    strLine = "";
                }
                objStreamWriter.Close();
                objFileStream.Close();
                MessageBox.Show(this, "保存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public void lcwexcelqb()
        {
            lcwexcelqb(null, null);
        }

        public void lcwexceldq()
        {
            lcwexceldq(null, null);
        }

        #endregion

        #region OverrideEnter

        protected override bool ProcessDialogKey(Keys keyData)
        {

            if ((keyData == Keys.Enter))
            {
                if (DataGridViewEnterKeyEvent != null)
                {
                    EventArgs newArgs = new EventArgs();
                    DataGridViewEnterKeyEvent(null, newArgs);
                    if (LastRowColumnOpEnterFocusEven)
                    {
                        LastRowColumnOpEnterFocusEven = false;
                        return true;
                    }
                }
                if (JugeEnternKey())
                {
                    //return base.ProcessDialogKey(keyData);
                    OPEnternKeyMsg();

                    return true;
                }

                if ((this.CurrentRow.Index + 1) == this.Rows.Count)
                {
                    if ((this.CurrentCell.ColumnIndex + 1) == this.Columns.Count)
                    {
                        MessageBox.Show("已到网格数据结尾。");

                        return true;
                    }
                    else
                    {
                        bool NeeHit = true;
                        for (int i = (this.CurrentCell.ColumnIndex + 1); i < this.Columns.Count; i++)
                        {
                            if (this.Columns[i].Visible)
                            {
                                NeeHit = false;
                                break;
                            }
                        }
                        if (NeeHit)
                        {
                            MessageBox.Show("已到网格数据结尾。");
                            return true;
                        }
                    }

                }

                SendKeys.Send("{Tab}");
                //EnterToNextOrPreColumn();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        public bool JugeEnternKey()
        {
            int index = this.CurrentCell.RowIndex;


            if (this.Columns[CurrentCell.ColumnIndex].DefaultCellStyle.BackColor == Color.Cornsilk)
            {
                if (this.Rows.Count == (index + 1))
                {
                    ChangeRow = false;
                }
                else
                {
                    ChangeRow = true;
                    return true;
                }

            }

            if (this.Columns[CurrentCell.ColumnIndex].DefaultCellStyle.BackColor == Color.MintCream)
            {
                //自动跳转到下一行
                if (this.Rows.Count == (index + 1))
                {

                }
                else
                {
                    this.CurrentCell = this.Rows[index + 1].Cells[CurrentCell.ColumnIndex];

                    return true;
                }
            }

            if (this.CurrentCell.ColumnIndex < (this.Columns.Count - 1))
            {
                ChangeRow = false;
                return false;
            }
            ChangeRow = true;


            return true;
        }

        public bool OPEnternKeyMsg()
        {
            if (!ChangeRow)
            {
                return true;
            }
            int index = this.CurrentCell.RowIndex;
            ChangeRow = false;
            if (this.Columns[CurrentCell.ColumnIndex].DefaultCellStyle.BackColor == Color.Cornsilk)
            {
                if (this.Rows.Count == (index + 1))
                {

                }
                else
                {
                    try
                    {

                        int selIndex = GetFirstEditControlIndex();
                        this.CurrentCell = this.Rows[index + 1].Cells[selIndex];
                    }
                    catch (Exception E)
                    {

                    }
                    return true;
                }

            }
            if (this.CurrentCell.ColumnIndex < (this.Columns.Count - 1))
            {
                return false;
            }
            try
            {
                if (this.Rows.Count == (index + 1))
                {
                    //说明这是最后一行，此时跳转到本行第一格
                    this.CurrentCell = this.CurrentRow.Cells[GetFirstEditControlIndex()];
                }
                else
                {
                    this.CurrentCell = this.Rows[index + 1].Cells[GetFirstEditControlIndex()];
                }

            }
            catch (System.Exception ex)
            {
                string Err = ex.Message;
            }

            return true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (this.Columns[CurrentCell.ColumnIndex].ReadOnly)
                {
                    int index = this.CurrentCell.RowIndex;
                    if (this.Columns[CurrentCell.ColumnIndex].DefaultCellStyle.BackColor == Color.Cornsilk)
                    {
                        //列固定回行(下一行第一个可编辑列)
                        if (this.Rows.Count != (index + 1))
                        {
                            this.CurrentCell = this.Rows[index + 1].Cells[GetFirstEditControlIndex()];
                            e.Handled = true;
                            return;
                        }

                    }
                    else if (this.Columns[CurrentCell.ColumnIndex].DefaultCellStyle.BackColor == Color.MintCream)
                    {
                        //自动跳转到下一行（下一行的该列单元格）
                        if (this.Rows.Count != (index + 1))
                        {
                            this.CurrentCell = this.Rows[index + 1].Cells[CurrentCell.ColumnIndex];
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        if (this.Rows.Count > (index + 1))
                        {
                            //SendKeys.Send("{Tab}");
                            EnterToNextOrPreColumn();
                            e.Handled = true;
                        }
                    }
                }
            }
            base.OnKeyDown(e);
        }

        private void EnterToNextOrPreColumn()
        {
            //向前找同行的第一个可编辑列
            int curIndex = this.CurrentCell.ColumnIndex;
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                if (curIndex == 0)
                {
                    return;
                }
                curIndex--;
                while (curIndex >= 0)
                {
                    if (!this.Columns[curIndex].Visible)
                    {
                        curIndex--;
                    }
                    else
                    {
                        break;
                    }
                }
                if (curIndex < 0)
                {
                    return;
                }
                this.CurrentCell = this.CurrentRow.Cells[curIndex];

                return;
            }

            //向后找同行的第一个可编辑列
            if (curIndex == this.Columns.Count)
            {
                return;
            }
            curIndex++;

            while (curIndex < this.Columns.Count)
            {
                if (!this.Columns[curIndex].Visible)
                {
                    curIndex++;
                }
                else
                {
                    break;
                }
            }
            if (curIndex >= this.Columns.Count)
            {
                return;
            }


            this.CurrentCell = this.CurrentRow.Cells[curIndex];
        }

        /// <summary>
        /// 获取第一个可编辑列的索引
        /// </summary>
        /// <returns>第一个可编辑列的索引</returns>
        private int GetFirstEditControlIndex()
        {
            int Index = -1;
            foreach (DataGridViewColumn curColumn in this.Columns)
            {
                Index++;
                if ((!curColumn.ReadOnly) && (curColumn.Visible))
                {
                    return Index;
                }

            }
            return 0;
        }

        #endregion

        protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (this.CurrentCell != this.Rows[e.RowIndex].Cells[e.ColumnIndex])
                        this.CurrentCell = this.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    ////若行已是选中状态就不再进行设置  
                    //if (this.Rows[e.RowIndex].Selected == false)
                    //{
                    //    this.ClearSelection();
                    //    this.Rows[e.RowIndex].Selected = true;
                    //}
                    ////只选中一行时设置活动单元格  
                    //if (this.SelectedRows.Count == 1)
                    //{
                    //    this.CurrentCell = this.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    //}
                    //弹出操作菜单  
                    //contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }

            base.OnCellMouseDown(e);

        }

        public void Paste()
        {
            string PasterStr = Clipboard.GetText();
            if (string.IsNullOrEmpty(PasterStr))
            {
                return;
            }

            int BeginRowIndex = this.CurrentCell.RowIndex;
            int BeginColumnIndex = this.CurrentCell.ColumnIndex;

            string[] PasterRows = PasterStr.Split('\r');
            foreach (string curRowStr in PasterRows)
            {
                string[] RowsList = curRowStr.Split('\t');
                foreach (string curCellValue in RowsList)
                {
 
                }
            }
        }

        private Point GetFirstCellLocation()
        {
            Point ptLocation;
            if (this.SelectedCells.Count <= 0)
            {
                ptLocation = new Point(0,0);
                return ptLocation;
            }
            else if (this.SelectedCells.Count == 1)
            {
                ptLocation = new Point(this.SelectedCells[0].RowIndex,this.SelectedCells[0].ColumnIndex);
            }
            else
            {
                //int rowInded this.SelectedCells[0].RowIndex;

                ptLocation = new Point(this.SelectedCells[0].RowIndex, this.SelectedCells[0].ColumnIndex);
            }

            return ptLocation;
        }
    }
}
