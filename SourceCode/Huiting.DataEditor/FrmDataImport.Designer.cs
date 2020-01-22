namespace Huiting.DataEditor
{
    partial class FrmDataImport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.pnlFormat = new Huiting.Components.DrawPanel.IconItemPanel();
            this.pnlExcel = new Huiting.Components.DrawPanel.IconItemPanel();
            this.pnlDB = new Huiting.Components.DrawPanel.IconItemPanel();
            this.pnlResult = new Huiting.Components.DrawPanel.IconItemPanel();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.uC_ExcelFileSel1 = new Huiting.DataEditor.Controls.UC_ExcelFileSel();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wizardPage2 = new DevExpress.XtraWizard.WizardPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgressTip = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.welcomeWizardPage1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            this.completionWizardPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.CancelText = "取消";
            this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage1);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage2);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Image = global::Huiting.DataEditor.Properties.Resources.data;
            this.wizardControl1.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextText = "下一步 >";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.wizardPage2,
            this.completionWizardPage1});
            this.wizardControl1.PreviousText = "< 上一部";
            this.wizardControl1.Size = new System.Drawing.Size(1021, 598);
            this.wizardControl1.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wizardControl1_NextClick);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.Controls.Add(this.pnlFormat);
            this.welcomeWizardPage1.Controls.Add(this.pnlExcel);
            this.welcomeWizardPage1.Controls.Add(this.pnlDB);
            this.welcomeWizardPage1.Controls.Add(this.pnlResult);
            this.welcomeWizardPage1.IntroductionText = "该向导引导用户，根据不同的数据形式，选择对应的数据类型，实现数据导入。";
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.ProceedText = "";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(804, 447);
            this.welcomeWizardPage1.Text = "待导入数据类型选择";
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
            this.pnlFormat.Location = new System.Drawing.Point(536, 160);
            this.pnlFormat.Name = "pnlFormat";
            this.pnlFormat.Size = new System.Drawing.Size(79, 105);
            this.pnlFormat.TabIndex = 9;
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
            this.pnlExcel.Location = new System.Drawing.Point(130, 160);
            this.pnlExcel.Name = "pnlExcel";
            this.pnlExcel.Size = new System.Drawing.Size(79, 105);
            this.pnlExcel.TabIndex = 10;
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
            this.pnlDB.Location = new System.Drawing.Point(268, 160);
            this.pnlDB.Name = "pnlDB";
            this.pnlDB.Size = new System.Drawing.Size(79, 105);
            this.pnlDB.TabIndex = 11;
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
            this.pnlResult.Location = new System.Drawing.Point(405, 160);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(79, 105);
            this.pnlResult.TabIndex = 12;
            this.pnlResult.Text = "成果库";
            this.pnlResult.Click += new System.EventHandler(this.pnlResult_Click);
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.uC_ExcelFileSel1);
            this.wizardPage1.DescriptionText = "用户可以下载Excel业务模板，整理数据，亦可做字段映射；建议使用前者。";
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(989, 424);
            this.wizardPage1.Text = "Excel数据导入";
            // 
            // uC_ExcelFileSel1
            // 
            this.uC_ExcelFileSel1.BackColor = System.Drawing.Color.Transparent;
            this.uC_ExcelFileSel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_ExcelFileSel1.Location = new System.Drawing.Point(0, 0);
            this.uC_ExcelFileSel1.Margin = new System.Windows.Forms.Padding(4);
            this.uC_ExcelFileSel1.Name = "uC_ExcelFileSel1";
            this.uC_ExcelFileSel1.Size = new System.Drawing.Size(989, 424);
            this.uC_ExcelFileSel1.TabIndex = 0;
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Controls.Add(this.progressBar1);
            this.completionWizardPage1.Controls.Add(this.lblProgressTip);
            this.completionWizardPage1.FinishText = "";
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.ProceedText = "";
            this.completionWizardPage1.Size = new System.Drawing.Size(804, 448);
            // 
            // wizardPage2
            // 
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(989, 424);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(38, 221);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(733, 34);
            this.progressBar1.TabIndex = 4;
            // 
            // lblProgressTip
            // 
            this.lblProgressTip.AutoSize = true;
            this.lblProgressTip.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressTip.Location = new System.Drawing.Point(33, 193);
            this.lblProgressTip.Name = "lblProgressTip";
            this.lblProgressTip.Size = new System.Drawing.Size(67, 25);
            this.lblProgressTip.TabIndex = 3;
            this.lblProgressTip.Text = "label3";
            // 
            // FrmDataImport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1021, 598);
            this.Controls.Add(this.wizardControl1);
            this.Name = "FrmDataImport";
            this.ShowIcon = false;
            this.Text = "数据导入";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.welcomeWizardPage1.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            this.completionWizardPage1.ResumeLayout(false);
            this.completionWizardPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage2;
        private Components.DrawPanel.IconItemPanel pnlFormat;
        private Components.DrawPanel.IconItemPanel pnlExcel;
        private Components.DrawPanel.IconItemPanel pnlDB;
        private Components.DrawPanel.IconItemPanel pnlResult;
        private Controls.UC_ExcelFileSel uC_ExcelFileSel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgressTip;
    }
}