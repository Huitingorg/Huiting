namespace Huiting.DataEditor
{
    partial class FrmDataImport2
    {
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataImport2));
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.pnlFormat = new Huiting.Components.DrawPanel.IconItemPanel();
            this.pnlExcel = new Huiting.Components.DrawPanel.IconItemPanel();
            this.pnlDB = new Huiting.Components.DrawPanel.IconItemPanel();
            this.pnlResult = new Huiting.Components.DrawPanel.IconItemPanel();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.uC_ExcelFileSel1 = new Huiting.DataEditor.Controls.UC_ExcelFileSel();
            this.wizardPage2 = new DevExpress.XtraWizard.WizardPage();
            this.bdNumBox1 = new Huiting.Components.BDNumBox();
            this.wizardPage3 = new DevExpress.XtraWizard.WizardPage();
            this.iconItemPanel1 = new Huiting.Components.DrawPanel.IconItemPanel();
            this.tabFormControl1 = new DevExpress.XtraBars.TabFormControl();
            this.tabFormPage1 = new DevExpress.XtraBars.TabFormPage();
            this.tabFormContentContainer1 = new DevExpress.XtraBars.TabFormContentContainer();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.welcomeWizardPage1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            this.wizardPage2.SuspendLayout();
            this.wizardPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.CancelText = "取消";
            this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage2);
            this.wizardControl1.Controls.Add(this.wizardPage3);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Image = global::Huiting.DataEditor.Properties.Resources.data1;
            this.wizardControl1.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.wizardControl1.Location = new System.Drawing.Point(0, 62);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextText = "下一步 >";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.wizardPage2,
            this.wizardPage3,
            this.completionWizardPage1});
            this.wizardControl1.PreviousText = "< 上一步";
            this.wizardControl1.Size = new System.Drawing.Size(945, 511);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.Controls.Add(this.pnlFormat);
            this.welcomeWizardPage1.Controls.Add(this.pnlExcel);
            this.welcomeWizardPage1.Controls.Add(this.pnlDB);
            this.welcomeWizardPage1.Controls.Add(this.pnlResult);
            this.welcomeWizardPage1.IntroductionText = "";
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.ProceedText = "";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(728, 360);
            this.welcomeWizardPage1.Text = "数据来源";
            // 
            // pnlFormat
            // 
            this.pnlFormat.BorderColor = System.Drawing.Color.White;
            this.pnlFormat.BorderColorWithMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(160)))), ((int)(((byte)(218)))));
            this.pnlFormat.BorderColorWithMouseIn = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(192)))), ((int)(((byte)(231)))));
            this.pnlFormat.BorderColorWithMouseOut = System.Drawing.Color.White;
            this.pnlFormat.FillColor = System.Drawing.Color.White;
            this.pnlFormat.FillColorWithMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.pnlFormat.FillColorWithMouseIn = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.pnlFormat.FillColorWithMouseOut = System.Drawing.Color.White;
            this.pnlFormat.Image = global::Huiting.DataEditor.Properties.Resources.customize;
            this.pnlFormat.Location = new System.Drawing.Point(508, 115);
            this.pnlFormat.Name = "pnlFormat";
            this.pnlFormat.Size = new System.Drawing.Size(79, 105);
            this.pnlFormat.TabIndex = 8;
            this.pnlFormat.Text = "专用格式";
            this.pnlFormat.Click += new System.EventHandler(this.pnlFormat_Click);
            // 
            // pnlExcel
            // 
            this.pnlExcel.BorderColor = System.Drawing.Color.White;
            this.pnlExcel.BorderColorWithMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(160)))), ((int)(((byte)(218)))));
            this.pnlExcel.BorderColorWithMouseIn = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(192)))), ((int)(((byte)(231)))));
            this.pnlExcel.BorderColorWithMouseOut = System.Drawing.Color.White;
            this.pnlExcel.FillColor = System.Drawing.Color.White;
            this.pnlExcel.FillColorWithMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.pnlExcel.FillColorWithMouseIn = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.pnlExcel.FillColorWithMouseOut = System.Drawing.Color.White;
            this.pnlExcel.Image = global::Huiting.DataEditor.Properties.Resources.excel;
            this.pnlExcel.Location = new System.Drawing.Point(374, 115);
            this.pnlExcel.Name = "pnlExcel";
            this.pnlExcel.Size = new System.Drawing.Size(79, 105);
            this.pnlExcel.TabIndex = 8;
            this.pnlExcel.Text = "Excel格式";
            this.pnlExcel.Click += new System.EventHandler(this.pnlExcel_Click);
            // 
            // pnlDB
            // 
            this.pnlDB.BorderColor = System.Drawing.Color.White;
            this.pnlDB.BorderColorWithMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(160)))), ((int)(((byte)(218)))));
            this.pnlDB.BorderColorWithMouseIn = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(192)))), ((int)(((byte)(231)))));
            this.pnlDB.BorderColorWithMouseOut = System.Drawing.Color.White;
            this.pnlDB.FillColor = System.Drawing.Color.White;
            this.pnlDB.FillColorWithMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.pnlDB.FillColorWithMouseIn = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.pnlDB.FillColorWithMouseOut = System.Drawing.Color.White;
            this.pnlDB.Image = global::Huiting.DataEditor.Properties.Resources.db;
            this.pnlDB.Location = new System.Drawing.Point(240, 115);
            this.pnlDB.Name = "pnlDB";
            this.pnlDB.Size = new System.Drawing.Size(79, 105);
            this.pnlDB.TabIndex = 8;
            this.pnlDB.Text = "数据库";
            this.pnlDB.Click += new System.EventHandler(this.pnlDB_Click);
            // 
            // pnlResult
            // 
            this.pnlResult.BorderColor = System.Drawing.Color.White;
            this.pnlResult.BorderColorWithMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(160)))), ((int)(((byte)(218)))));
            this.pnlResult.BorderColorWithMouseIn = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(192)))), ((int)(((byte)(231)))));
            this.pnlResult.BorderColorWithMouseOut = System.Drawing.Color.White;
            this.pnlResult.FillColor = System.Drawing.Color.White;
            this.pnlResult.FillColorWithMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.pnlResult.FillColorWithMouseIn = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.pnlResult.FillColorWithMouseOut = System.Drawing.Color.White;
            this.pnlResult.Image = global::Huiting.DataEditor.Properties.Resources.cloud;
            this.pnlResult.Location = new System.Drawing.Point(106, 115);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(79, 105);
            this.pnlResult.TabIndex = 8;
            this.pnlResult.Text = "成果库";
            this.pnlResult.Click += new System.EventHandler(this.pnlResult_Click);
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.Size = new System.Drawing.Size(728, 361);
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.uC_ExcelFileSel1);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(913, 337);
            // 
            // uC_ExcelFileSel1
            // 
            this.uC_ExcelFileSel1.BackColor = System.Drawing.Color.White;
            this.uC_ExcelFileSel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_ExcelFileSel1.Location = new System.Drawing.Point(0, 0);
            this.uC_ExcelFileSel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uC_ExcelFileSel1.Name = "uC_ExcelFileSel1";
            this.uC_ExcelFileSel1.Size = new System.Drawing.Size(913, 337);
            this.uC_ExcelFileSel1.TabIndex = 0;
            this.uC_ExcelFileSel1.Title = "请选择导入Excel文件";
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.bdNumBox1);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(913, 337);
            // 
            // bdNumBox1
            // 
            this.bdNumBox1.BackColor = System.Drawing.SystemColors.Window;
            this.bdNumBox1.Location = new System.Drawing.Point(415, 137);
            this.bdNumBox1.ModifierColor = System.Drawing.SystemColors.WindowText;
            this.bdNumBox1.Name = "bdNumBox1";
            this.bdNumBox1.ShowEmptyWhenZero = false;
            this.bdNumBox1.Size = new System.Drawing.Size(100, 26);
            this.bdNumBox1.TabIndex = 0;
            this.bdNumBox1.Text = "";
            // 
            // wizardPage3
            // 
            this.wizardPage3.Controls.Add(this.iconItemPanel1);
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.Size = new System.Drawing.Size(913, 337);
            // 
            // iconItemPanel1
            // 
            this.iconItemPanel1.BorderColor = System.Drawing.Color.White;
            this.iconItemPanel1.BorderColorWithMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(160)))), ((int)(((byte)(218)))));
            this.iconItemPanel1.BorderColorWithMouseIn = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(192)))), ((int)(((byte)(231)))));
            this.iconItemPanel1.BorderColorWithMouseOut = System.Drawing.Color.White;
            this.iconItemPanel1.FillColor = System.Drawing.Color.White;
            this.iconItemPanel1.FillColorWithMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.iconItemPanel1.FillColorWithMouseIn = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.iconItemPanel1.FillColorWithMouseOut = System.Drawing.Color.White;
            this.iconItemPanel1.Image = ((System.Drawing.Bitmap)(resources.GetObject("iconItemPanel1.Image")));
            this.iconItemPanel1.Location = new System.Drawing.Point(271, 76);
            this.iconItemPanel1.Name = "iconItemPanel1";
            this.iconItemPanel1.Size = new System.Drawing.Size(193, 208);
            this.iconItemPanel1.TabIndex = 0;
            this.iconItemPanel1.Text = "iconItemPanel1";
            // 
            // tabFormControl1
            // 
            this.tabFormControl1.Location = new System.Drawing.Point(0, 0);
            this.tabFormControl1.Name = "tabFormControl1";
            this.tabFormControl1.Pages.Add(this.tabFormPage1);
            this.tabFormControl1.SelectedPage = this.tabFormPage1;
            this.tabFormControl1.Size = new System.Drawing.Size(945, 62);
            this.tabFormControl1.TabForm = this;
            this.tabFormControl1.TabIndex = 1;
            this.tabFormControl1.TabStop = false;
            // 
            // tabFormPage1
            // 
            this.tabFormPage1.ContentContainer = this.tabFormContentContainer1;
            this.tabFormPage1.Name = "tabFormPage1";
            this.tabFormPage1.Text = "Page 0";
            // 
            // tabFormContentContainer1
            // 
            this.tabFormContentContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFormContentContainer1.Location = new System.Drawing.Point(0, 62);
            this.tabFormContentContainer1.Name = "tabFormContentContainer1";
            this.tabFormContentContainer1.Size = new System.Drawing.Size(945, 511);
            this.tabFormContentContainer1.TabIndex = 2;
            // 
            // FrmDataImport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(945, 573);
            this.Controls.Add(this.wizardControl1);
            this.Controls.Add(this.tabFormContentContainer1);
            this.Controls.Add(this.tabFormControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmDataImport";
            this.ShowIcon = false;
            this.TabFormControl = this.tabFormControl1;
            this.Text = "数据导入";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.welcomeWizardPage1.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage2.ResumeLayout(false);
            this.wizardPage2.PerformLayout();
            this.wizardPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabFormControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private Controls.UC_ExcelFileSel uC_ExcelFileSel1;
        private Components.DrawPanel.IconItemPanel pnlResult;
        private Components.DrawPanel.IconItemPanel pnlFormat;
        private Components.DrawPanel.IconItemPanel pnlExcel;
        private Components.DrawPanel.IconItemPanel pnlDB;
        private DevExpress.XtraWizard.WizardPage wizardPage2;
        private DevExpress.XtraWizard.WizardPage wizardPage3;
        private Components.DrawPanel.IconItemPanel iconItemPanel1;
        private Components.BDNumBox bdNumBox1;
        private DevExpress.XtraBars.TabFormControl tabFormControl1;
        private DevExpress.XtraBars.TabFormPage tabFormPage1;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer1;
    }
}

