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
    public partial class ExcelViewControl : UserControl
    {
               
        static DateTime date = DateTime.Now;
  
        public ExcelViewControl()
        {
            InitializeComponent();
             DateTime today = DateTime.Now.Date;
            if (date.Date != today.Date)
            {
                //新的一天，清空缓存
                date = today;
                DeleteAllBufferSection();
            }
            
        }
        /// <summary>
        /// 是否是网站引用,如果是网站方式，缓存目录为网站目录(bin的上级目录)/exceltohtmls/，
        /// 如果是非网站方式，缓存目录为程序集目录/exceltohtmls/
        /// </summary>
        public bool IsWebSite = false;
        /// <summary>
        /// excel文件及html文件缓存相对路径
        /// </summary>
       string relativePath = @"\exceltohtmls\";
       //  @"\..\exceltohtmls\"
       private string bufferFolder = "";
        /// <summary>
        /// excel文件及html文件缓存目录
        /// </summary>
         string BufferFolder
        {
            get
            {
                if (IsWebSite)
                {
                    return CurrentPath.GetCurRunPath() + @"..\exceltohtmls\";
                }
                else
                {
                   // ConfigFilePath = ConfigFilePath.Substring(0, ConfigFilePath.LastIndexOf("\\"));
                    string path = CurrentPath.GetCurRunPath();
                    path = path.Substring(0, path.LastIndexOf("\\"));
                    return path + @"\exceltohtmls\";
                }
            }
           
        }
         bool DeleteAllBufferSection()
        {
            //string BufferFolder = @"\exceltohtmls\";
           // string ExcelPath =CurrentPath.GetCurRunPath() + BufferFolder;
            string ExcelPath = BufferFolder;
            try
            {
                Directory.Delete(ExcelPath, true);
                Directory.Delete(ExcelPath);
                if (!Directory.Exists(ExcelPath))
                {
                    Directory.CreateDirectory(ExcelPath);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
        }
        #region 一个sheet一个doc的方式先不用，采用一个sheet一个doc加一个综合html的方式
        ///// <summary>
        ///// 预览excel文件。（xls、xlsx格式文件）
        ///// </summary>
        ///// <param name="excelFilePath"></param>
        //public void ViewExcelFile(string excelFilePath)
        //{
        //    this.Controls.Clear();
        //    List<string> sheetNameList = new List<string>();
        //    List<XmlDocument> xmlDocList = new List<XmlDocument>();
        //    GetDocList(excelFilePath, ref xmlDocList, ref sheetNameList);
        //    TabControl tb = new TabControl();
           
        //    tb.TabPages.Clear();
        //    int index = 0;
        //    foreach (XmlDocument curDoc in xmlDocList)
        //    {
        //        TabPage tp = new TabPage();
                
               
        //        //tp.Text = "sheet" + index.ToString();
        //        tp.Text = sheetNameList[index];
        //        index++;

        //        WebBrowser wb = new WebBrowser();
        //        wb.Dock = DockStyle.Fill;
        //        string savepath =CurrentPath.GetCurRunPath() + "\\exceltohtmls\\" + Guid.NewGuid().ToString() + ".htm";
        //        curDoc.Save(savepath);
        //        wb.Navigate(savepath);
        //        tp.Controls.Add(wb);
        //        tb.Dock = DockStyle.Fill;
        //        tb.TabPages.Add(tp);
        //    }
        //    this.Controls.Add(tb);
        //}
        #endregion
        /// <summary>
        /// 预览excel文件。（xls、xlsx格式文件）
        /// 搞成一个html页，用ifram来动态加载各个html页面
        /// </summary>
        /// <param name="excelFilePath"></param>
        public string ViewExcelFileEx(string excelFilePath)
        {
            if (!Directory.Exists(BufferFolder))
            {
                Directory.CreateDirectory(BufferFolder);
            }
            Directory.CreateDirectory(BufferFolder);
            string htmlStr1 = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">";
            string htmlStr2 = "<html><head><title>excel</title> <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/><style type=\"text/css\">ul{list-style:none;margin:1px;padding:1px;}.sp_ul li{float:left;}body,html{overflow:hidden;margin:0px;padding:0px; background-color:Gray;}</style> <script type=\"text/javascript\"> function navigage(url) {document.getElementById(\"ifrmam1\").src = url;}</script></head><body >";
            string defalutsrc = "#";
            string appendStr = "";


            List<string> sheetNameList = new List<string>();
            List<XmlDocument> xmlDocList = new List<XmlDocument>();
            //获取每个页的问题
            GetDocList(excelFilePath, ref xmlDocList, ref sheetNameList);
            int index = 0;
            foreach (XmlDocument curDoc in xmlDocList)
            {

                string sheetText = sheetNameList[index];
                index++;
                string guidFileName = Guid.NewGuid().ToString() + ".htm";
                string savepath = BufferFolder + guidFileName;
                //保存单个sheet页为html文档
                curDoc.Save(savepath);
                if (index == 1)
                {
                    defalutsrc = guidFileName;
                }
                savepath = savepath.Replace("\\", "/");
                appendStr += "<li><button onclick=navigage(\"" + guidFileName + "\")>" + sheetText + "</button></li>";
            }
            string htmlStr3 = "<body ><table cellpadding=0 cellspacing=0 border=0 style=\" height:100%; width:100%; border-collapse:collapse\"><tr><td> <iframe id=\"ifrmam1\"  width=\"100%\"  style=\"height:100%\" src=\"" + defalutsrc + "\"></iframe> </td></tr> <tr><td style=\"height:30px\"><ul class=\"sp_ul\">";
            string htmlEnd = "</ul></td></tr></table></body></html>";
            //总的html文件
            string resultHtml = htmlStr1 + htmlStr2 + htmlStr3 + appendStr + htmlEnd;
    
              string filePath =BufferFolder+ Guid.NewGuid().ToString() + ".htm";

            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            fs.SetLength(0);
            sw.Write(resultHtml);
            sw.Close();
            return filePath;
        }


        /// <summary>
        ///重载ViewExcelFileEx，返回所有文件
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <param name="MainHtmlFilePath"></param>
        /// <param name="sheetHtmlPath"></param>
        public void ViewExcelFileEx(string excelFilePath, ref string MainHtmlFilePath,ref List<string> sheetHtmlPath)
        {
            if (sheetHtmlPath == null)
                sheetHtmlPath = new List<string>();
            sheetHtmlPath.Clear();
            if (!Directory.Exists(BufferFolder))
            {
                Directory.CreateDirectory(BufferFolder);
            }
            Directory.CreateDirectory(BufferFolder);
            string htmlStr1 = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">";
            string htmlStr2 = "<html><head><title>excel</title> <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/><style type=\"text/css\">ul{list-style:none;margin:1px;padding:1px;}.sp_ul li{float:left;}body,html{overflow:hidden;margin:0px;padding:0px; background-color:Gray;}</style> <script type=\"text/javascript\"> function navigage(url) {document.getElementById(\"ifrmam1\").src = url;}</script></head><body >";
            string defalutsrc = "#";
            string appendStr = "";


            List<string> sheetNameList = new List<string>();
            List<XmlDocument> xmlDocList = new List<XmlDocument>();
            //获取每个页的问题
            GetDocList(excelFilePath, ref xmlDocList, ref sheetNameList);
            int index = 0;
            foreach (XmlDocument curDoc in xmlDocList)
            {

                string sheetText = sheetNameList[index];
                index++;
                string guidFileName = Guid.NewGuid().ToString() + ".htm";
                string savepath = BufferFolder + guidFileName;

                //保存单个sheet页为html文档
                curDoc.Save(savepath);
                sheetHtmlPath.Add(savepath);
                if (index == 1)
                {
                    defalutsrc = guidFileName;
                }
                savepath = savepath.Replace("\\", "/");
                appendStr += "<li><button onclick=navigage(\"" + guidFileName + "\")>" + sheetText + "</button></li>";
              
            }
      
            string htmlStr3 = "<body ><table cellpadding=0 cellspacing=0 border=0 style=\" height:100%; width:100%; border-collapse:collapse\"><tr><td> <iframe  id=\"ifrmam1\"  width=\"100%\"  style=\"height:100%\" src=\"" +  defalutsrc + "\"></iframe> </td></tr> <tr><td style=\"height:30px\"><ul class=\"sp_ul\">";
            string htmlEnd = "</ul></td></tr></table></body></html>";
            //总的html文件
            string resultHtml = htmlStr1 + htmlStr2 + htmlStr3 + appendStr + htmlEnd;

             string filePath =BufferFolder + Guid.NewGuid().ToString() + ".htm";

            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            fs.SetLength(0);
            sw.Write(resultHtml);
            sw.Close();
            MainHtmlFilePath = filePath;
        }


      
        #region excel文件流保存为本地文件
        static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }                
                return ms.ToArray();
            }
        }
        /// <summary>
        /// excel文件流保存为本地文件
        /// </summary>
        /// <param name="ExcelFileSteam"></param>
        /// <param name="fileFormat">xls/xlsx/</param>
        /// <param name="serverExcelFilePath"></param>
        /// <returns></returns>
        public bool ExcelFileSteamSaveToFile(System.IO.Stream ExcelFileSteam, string fileFormat, ref string serverExcelFilePath)
        {
            string directory = BufferFolder+ Guid.NewGuid().ToString();

            if (fileFormat.ToString().ToLower() == ".xls" || fileFormat.ToLower().ToString() == "xls")
            {
                directory += ".xls";
            }
            else if (fileFormat.ToString().ToLower() == ".xlsx" || fileFormat.ToLower().ToString() == "xlsx")
            {
                directory += ".xlsx";
            }
            else
            {
                throw (new Exception("不能识别的类型:" + fileFormat));
            }
            try
            {
                byte[] data = ReadFully(ExcelFileSteam);
                using (FileStream fs = new FileStream(directory, FileMode.OpenOrCreate))
                {

                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                    fs.Close();
                    fs.Dispose();
                }

            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            serverExcelFilePath = directory;
            return true;
        }
        #endregion 


        public void GetDocList(string ExcelPath, ref List<XmlDocument> doclist, ref List<string> sheetNameList)
        {
            doclist = new List<XmlDocument>();

            if (Path.GetExtension(ExcelPath).Equals(".xls", StringComparison.CurrentCultureIgnoreCase))
            {
                int count = ExcelToHtmlConverter.GetSheetCount(ExcelPath, ref sheetNameList);
                for (int i = 0; i < count; i++)
                {
                    XmlDocument xmlDoc = ExcelToHtmlConverter.ProcessEx(ExcelPath, i);

                    doclist.Add(xmlDoc);

                }
            }
            else if (Path.GetExtension(ExcelPath).Equals(".xlsx", StringComparison.CurrentCultureIgnoreCase))
            {

                int count = XlsxToHtmlConverter.GetSheetCount(ExcelPath, ref sheetNameList);
                for (int i = 0; i < count; i++)
                {
               
                    XmlDocument xmlDoc = XlsxToHtmlConverter.ProcessEx(ExcelPath, i);
                    doclist.Add(xmlDoc);


                }
            }
            else
            {
                throw new Exception("只支持.xls和.xlsx格式的Excel文件解析！");
            }

        }
    }
}
