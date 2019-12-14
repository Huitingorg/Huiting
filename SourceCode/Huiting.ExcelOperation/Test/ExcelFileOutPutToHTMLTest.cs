using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NPOI.HSSF.Converter;
using System.Xml;
using NPOI.XSSF.Extractor;
using NPOI.OOXML.XSSF.Converter;
using System.IO;
namespace Huiting.ExcelOperation
{
    public partial class ExcelFileOutPutToHTMLTest : Form
    {
        public ExcelFileOutPutToHTMLTest()
        {
            InitializeComponent();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog(this).Equals(DialogResult.OK))
            {

                this.panel1.Controls.Clear();
                List<string> sheetNameList = new List<string>();
                List<XmlDocument> xmlDocList = new List<XmlDocument>();
                GetDocList(ofd.FileName, ref xmlDocList, ref sheetNameList);
                TabControl tb = new TabControl();
                tb.TabPages.Clear();
                int index = 0;
                foreach (XmlDocument curDoc in xmlDocList)
                {
                    TabPage tp = new TabPage();
                    tp.Text = sheetNameList[index];
                    index++;

                    WebBrowser wb = new WebBrowser();
                    wb.Dock = DockStyle.Fill;

                    string savepath = CurrentPath.GetCurRunPath() + "\\exceltohtmls\\" + Guid.NewGuid().ToString() + ".htm";
                    curDoc.Save(savepath);
                   
                    wb.Navigate(savepath);
                    tp.Controls.Add(wb);
                    tb.Dock = DockStyle.Fill;
                    tb.TabPages.Add(tp);
                }
                this.panel1.Controls.Add(tb);



            }
        }

        private void  GetDocList(string ExcelPath,ref List<XmlDocument> doclist,ref List<string> sheetNameList)
        {
            doclist = new List<XmlDocument>();

            if (Path.GetExtension(ExcelPath).Equals(".xls", StringComparison.CurrentCultureIgnoreCase))
            {
                FileInfo fileInfo = new FileInfo(ExcelPath);
                int count = ExcelToHtmlConverter.GetSheetCount(ExcelPath, ref sheetNameList);
                bool NullOrEmptyIgnore = false;
                NullOrEmptyIgnore = true;

                for (int i = 0; i < count; i++)
                {
                    XmlDocument xmlDoc = ExcelToHtmlConverter.ProcessEx(ExcelPath, i);

                    doclist.Add(xmlDoc);

                }
            }
            else if (Path.GetExtension(ExcelPath).Equals(".xlsx", StringComparison.CurrentCultureIgnoreCase))
            {
                FileInfo fileInfo = new FileInfo(ExcelPath);

                int count = XlsxToHtmlConverter.GetSheetCount(ExcelPath, ref sheetNameList);
                for (int i = 0; i < count; i++)
                {
                    XmlDocument xmlDoc = XlsxToHtmlConverter.ProcessEx(ExcelPath, i);
                    doclist.Add(xmlDoc);
                }
            }
            else
            {
                throw new Exception("目前只支持.xls和.xlsx格式的Excel文件解析！");
            }
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog(this).Equals(DialogResult.OK))
            {
               
                this.panel1.Controls.Clear();
                ExcelViewControl evc = new ExcelViewControl();
                try
                {
                    string savepath = evc.ViewExcelFileEx(ofd.FileName);

                    WebBrowser wb = new WebBrowser();
                    wb.Dock = DockStyle.Fill;
                    wb.Navigate(savepath);
                  
                    this.panel1.Controls.Add(wb);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



            }
          
        }
    }
}
