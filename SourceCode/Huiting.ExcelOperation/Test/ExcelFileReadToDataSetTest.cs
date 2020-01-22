using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HSSF.Converter;
using System.Net;
using System.Text.RegularExpressions;

namespace Huiting.ExcelOperation
{
    public partial class ExcelFileReadToDataSetTest : Form
    {
        public ExcelFileReadToDataSetTest()
        {
            InitializeComponent();
        }


        string FilePath = "";
        //选择文件
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog(this).Equals(DialogResult.OK))
            {
                this.FilePath = ofd.FileName;
                //获取数据集
                ExcelReadClass m_ExcelReadClass = new ExcelReadClass();
                DataSet ds = m_ExcelReadClass.GetExcelDataSet(this.FilePath);
                //展示数据集
                this.tabControl1.TabPages.Clear();
                foreach (DataTable dt in ds.Tables)
                {
                    TabPage tp = new TabPage(dt.TableName);
                    DataGridView dgv = new DataGridView();
                    dgv.DataSource = dt;
                    dgv.Dock = DockStyle.Fill;
                    tp.Controls.Add(dgv);
                    this.tabControl1.TabPages.Add(tp);

                }
                
            }
        }






    }
}