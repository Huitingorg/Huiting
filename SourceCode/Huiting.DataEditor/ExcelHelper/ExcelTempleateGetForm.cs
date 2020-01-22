
using DevExpress.XtraEditors;
using Huiting.Common;
using Huiting.DevComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Huiting.DataEditor.ExcelHelper
{
    public partial class ExcelTempleateGetForm : DevXtraForm //Form
    {
        public string SavePath = string.Empty;
        public ExcelTempleateGetForm()
        {
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            SavePath = PublicMethods.GetFolderPath(this);
            if(string.IsNullOrEmpty(SavePath))
            {
                return;
            }
            string sourcePath=string.Empty;
            //单元资产
            if(checkBox1.Checked)
            {
                sourcePath = Application.StartupPath + "//DataTemplates//模板_单元基本信息.xls";
                File.Copy(sourcePath, SavePath+"//模板_单元基本信息.xls", true);
            }
            //单元开发数据
            if (checkBox2.Checked)
            {
                sourcePath = Application.StartupPath + "//DataTemplates//模板_单元开发数据.xls";
                File.Copy(sourcePath, SavePath + "//模板_单元开发数据.xls", true);
            }
            //开井开发数据
            if (checkBox3.Checked)
            {
                sourcePath = Application.StartupPath + "//DataTemplates//模板_单井开发数据.xls";
                File.Copy(sourcePath, SavePath + "//模板_单井开发数据.xls", true);
            }
            PublicMethods.TipsMessageBox(this, "保存成功！");
        }
    }
}
