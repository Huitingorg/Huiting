using DevExpress.XtraEditors;
using Huiting.DevComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Huiting.DataEditor
{
    public partial class FrmDataImport :XtraForm//Form
    {
        public FrmDataImport()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }



        private void pnlExcel_Click(object sender, EventArgs e)
        {
            this.wizardControl1.SelectedPageIndex = 1;
        }

        private void pnlDB_Click(object sender, EventArgs e)
        {
            ShowMsg(this, "暂未开发");
        }

        private void pnlResult_Click(object sender, EventArgs e)
        {
            ShowMsg(this, "暂未开发");
        }

                private void pnlFormat_Click(object sender, EventArgs e)
        {
            ShowMsg(this, "暂未开发");
        }

        private void wizardControl1_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
        }

        /// <summary>
        /// 显示提示消息
        /// </summary>
        /// <param name="msg">需要显示的信息</param>
        public static void ShowMsg(System.Windows.Forms.IWin32Window window, string msg)
        {
            XtraMessageBoxForm form = new XtraMessageBoxForm();
            form.ShowMessageBoxDialog(new XtraMessageBoxArgs(window, msg, "提示信息", new DialogResult[] { DialogResult.OK }, System.Drawing.Icon.FromHandle(System.Drawing.SystemIcons.Information.Handle), 0));
        }
    }
}
