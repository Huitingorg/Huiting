using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Huiting.Common
{
    public class DataGridViewBehaviors
    {
        /// <summary>
        /// 格式化复制
        /// </summary>
        /// <param name="DataGridView_cur">目标DataGridView对象</param>
        public static void CopyFromDataGridView(DataGridView DataGridView_cur)
        {
            DataGridViewSelectedCellCollection selCells = DataGridView_cur.SelectedCells;
            if (selCells.Count <= 0)
                return;
            int BeginRowIndex = selCells[0].RowIndex;
            int BeginColumnIndex = selCells[0].ColumnIndex;

            int EndRowIndex = selCells[selCells.Count - 1].RowIndex;
            int EndColumnIndex = selCells[selCells.Count - 1].ColumnIndex;


            foreach (DataGridViewCell curCell in selCells)
            {
                if (curCell.RowIndex < BeginRowIndex)
                {
                    BeginRowIndex = curCell.RowIndex;
                }
                if (curCell.RowIndex > EndRowIndex)
                {
                    EndRowIndex = curCell.RowIndex;
                }

                if (curCell.ColumnIndex < BeginColumnIndex)
                {
                    BeginColumnIndex = curCell.ColumnIndex;
                }
                if (curCell.ColumnIndex > EndColumnIndex)
                {
                    EndColumnIndex = curCell.ColumnIndex;
                }

            }

            string RealStr = "";
            string TempRowsStr = "";
            string Value = "";
            for (int i = BeginRowIndex; i <= EndRowIndex; i++)
            {
                if (!string.IsNullOrEmpty(RealStr))
                {
                    RealStr += "\r\n";
                }
                TempRowsStr = "";
                for (int a = BeginColumnIndex; a <= EndColumnIndex; a++)
                {
                    DataRowView curRow = (DataRowView)DataGridView_cur.Rows[i].DataBoundItem;
                    if (curRow == null)
                    {
                        continue;
                    }
                    if (curRow.Row.RowState == DataRowState.Detached)
                    {
                        continue;
                    }

                    if (!string.IsNullOrEmpty(TempRowsStr))
                    {
                        TempRowsStr += "\t";
                    }

                    Value = DataGridView_cur.Rows[i].Cells[a].Value.ToString();
                    if (!string.IsNullOrEmpty(Value))
                    {
                        TempRowsStr += Value;
                    }
                }

                RealStr += TempRowsStr;
            }

            Clipboard.SetText(RealStr);

        }

        /// <summary>
        /// 格式化粘贴
        /// </summary>
        /// <param name="sender">目标DataGridView对象</param>
        /// <param name="e">如果走出目前行总数，是否自动追加行</param>
        public static void PasterToDataGridView(DataGridView DataGridView_cur, bool EnAutoAddRow)
        {
            string PasterStr = Clipboard.GetText();
            DataTable dt_CurDataSouce = null;
            switch (DataGridView_cur.DataSource.GetType().Name)
            {
                case "DataTable":
                    dt_CurDataSouce = (DataTable)DataGridView_cur.DataSource;
                    break;
                case "BindingSource":
                    dt_CurDataSouce = (DataTable)((BindingSource)DataGridView_cur.DataSource).DataSource;
                    break;
                default:
                    throw new Exception("未处理的数据源类型");
            }

            if (string.IsNullOrEmpty(PasterStr))
            {
                return;
            }
            if (DataGridView_cur.SelectedCells.Count == 0)
            {
                PublicMethods.WarnMessageBox(DataGridView_cur.FindForm(), "请选择要粘贴的单元格！");
                //MyMethod.ShowMessage(DataGridView_cur.FindForm(), "请选择要粘贴的单元格！");
                return;
            }

            //int BeginRowIndex = DataGridView_cur.CurrentCell.RowIndex;
            //int BeginColumnIndex = DataGridView_cur.CurrentCell.ColumnIndex;
            int BeginRowIndex = DataGridView_cur.SelectedCells[0].RowIndex;
            int BeginColumnIndex = DataGridView_cur.SelectedCells[0].ColumnIndex;
            string[] PasterRows = PasterStr.Split('\r');

            int RowsAddCount = -1;
            int ColumnsAddCount = -1;
            string ErrMsg = "";
            DataGridView_cur.CurrentCell = null;
            foreach (string curRowStr in PasterRows)
            {
                if (curRowStr == "\n")
                {
                    continue;
                }
                RowsAddCount++;
                DataRow curRow = null;
                if (((BeginRowIndex + RowsAddCount) >= DataGridView_cur.Rows.Count) || ((DataRowView)DataGridView_cur.Rows[BeginRowIndex + RowsAddCount].DataBoundItem == null))
                {
                    if (!EnAutoAddRow)
                    {
                        break;
                    }
                    curRow = dt_CurDataSouce.NewRow();

                    dt_CurDataSouce.Rows.Add(curRow);

                }
                else
                {

                    curRow = ((DataRowView)DataGridView_cur.Rows[BeginRowIndex + RowsAddCount].DataBoundItem).Row;

                }
                string[] RowsList = curRowStr.Split('\t');

                ColumnsAddCount = -1;
                string RealValue = "";
                string strCurColumnName = "";
                foreach (string curCellValue in RowsList)
                {
                    ColumnsAddCount++;
                    if ((BeginColumnIndex + ColumnsAddCount) >= DataGridView_cur.ColumnCount)
                    {
                        break;
                    }
                    RealValue = curCellValue.Replace("\n", "");
                    try
                    {
                        strCurColumnName = DataGridView_cur.Columns[BeginColumnIndex + ColumnsAddCount].DataPropertyName;
                        if (string.IsNullOrEmpty(RealValue))
                        {

                            curRow[strCurColumnName] = DBNull.Value;
                        }
                        else
                        {
                            curRow[strCurColumnName] = RealValue;

                        }



                    }
                    catch (System.Exception ex)
                    {
                        if (!string.IsNullOrEmpty(ErrMsg))
                        {
                            ErrMsg += "\n";
                        }
                        ErrMsg += "粘贴第" + (RowsAddCount + 1).ToString() + "行数据的[" + DataGridView_cur.Columns[BeginColumnIndex + ColumnsAddCount].HeaderText + "]列时出错，错误：" + ex.Message;

                    }
                    curRow.EndEdit();

                }

            }
            try
            {
                DataGridView_cur.CurrentCell = DataGridView_cur.Rows[BeginRowIndex].Cells[BeginColumnIndex];

            }
            catch
            {

            }
            if (!string.IsNullOrEmpty(ErrMsg))
            {
                MessageBox.Show(ErrMsg);
            }


        }
    }
}
