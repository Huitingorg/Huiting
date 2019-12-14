namespace Huiting.DataEditor
{
    partial class FrmDataImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataImport));
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.panel_MainItem = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_BDCL = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_curstom = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Excel = new System.Windows.Forms.Button();
            this.btn_Server = new System.Windows.Forms.Button();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.uC_ExcelFileSel1 = new Huiting.DataEditor.Controls.UC_ExcelFileSel();
            this.windowsUIButtonPanel1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.welcomeWizardPage1.SuspendLayout();
            this.panel_MainItem.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.CancelText = "取消";
            this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage1);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Image = global::Huiting.DataEditor.Properties.Resources.data1;
            this.wizardControl1.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextText = "下一步 >";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.completionWizardPage1});
            this.wizardControl1.PreviousText = "< 上一步";
            this.wizardControl1.Size = new System.Drawing.Size(945, 573);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.Controls.Add(this.windowsUIButtonPanel1);
            this.welcomeWizardPage1.Controls.Add(this.panel_MainItem);
            this.welcomeWizardPage1.IntroductionText = "";
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.ProceedText = "";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(728, 422);
            this.welcomeWizardPage1.Text = "数据来源";
            // 
            // panel_MainItem
            // 
            this.panel_MainItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_MainItem.Controls.Add(this.label5);
            this.panel_MainItem.Controls.Add(this.btn_BDCL);
            this.panel_MainItem.Controls.Add(this.label2);
            this.panel_MainItem.Controls.Add(this.label3);
            this.panel_MainItem.Controls.Add(this.btn_curstom);
            this.panel_MainItem.Controls.Add(this.label1);
            this.panel_MainItem.Controls.Add(this.btn_Excel);
            this.panel_MainItem.Controls.Add(this.btn_Server);
            this.panel_MainItem.Location = new System.Drawing.Point(89, 64);
            this.panel_MainItem.Margin = new System.Windows.Forms.Padding(4);
            this.panel_MainItem.Name = "panel_MainItem";
            this.panel_MainItem.Size = new System.Drawing.Size(545, 138);
            this.panel_MainItem.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 97);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "数据库";
            // 
            // btn_BDCL
            // 
            this.btn_BDCL.BackgroundImage = global::Huiting.DataEditor.Properties.Resources.customize;
            this.btn_BDCL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_BDCL.FlatAppearance.BorderSize = 0;
            this.btn_BDCL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BDCL.ImageIndex = 0;
            this.btn_BDCL.Location = new System.Drawing.Point(413, 23);
            this.btn_BDCL.Margin = new System.Windows.Forms.Padding(4);
            this.btn_BDCL.Name = "btn_BDCL";
            this.btn_BDCL.Size = new System.Drawing.Size(64, 64);
            this.btn_BDCL.TabIndex = 1;
            this.btn_BDCL.UseVisualStyleBackColor = true;
            this.btn_BDCL.Click += new System.EventHandler(this.btn_BDCL_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "专用格式";
            this.label2.Click += new System.EventHandler(this.btn_Excel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Excel格式";
            // 
            // btn_curstom
            // 
            this.btn_curstom.BackgroundImage = global::Huiting.DataEditor.Properties.Resources.db;
            this.btn_curstom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_curstom.FlatAppearance.BorderSize = 0;
            this.btn_curstom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_curstom.ImageIndex = 2;
            this.btn_curstom.Location = new System.Drawing.Point(173, 23);
            this.btn_curstom.Margin = new System.Windows.Forms.Padding(4);
            this.btn_curstom.Name = "btn_curstom";
            this.btn_curstom.Size = new System.Drawing.Size(64, 64);
            this.btn_curstom.TabIndex = 1;
            this.btn_curstom.UseVisualStyleBackColor = true;
            this.btn_curstom.Click += new System.EventHandler(this.btn_curstom_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "成果库";
            // 
            // btn_Excel
            // 
            this.btn_Excel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Excel.BackgroundImage")));
            this.btn_Excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Excel.FlatAppearance.BorderSize = 0;
            this.btn_Excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Excel.ImageIndex = 1;
            this.btn_Excel.Location = new System.Drawing.Point(293, 23);
            this.btn_Excel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Excel.Name = "btn_Excel";
            this.btn_Excel.Size = new System.Drawing.Size(64, 64);
            this.btn_Excel.TabIndex = 1;
            this.btn_Excel.UseVisualStyleBackColor = true;
            this.btn_Excel.Click += new System.EventHandler(this.btn_Excel_Click);
            // 
            // btn_Server
            // 
            this.btn_Server.BackgroundImage = global::Huiting.DataEditor.Properties.Resources.cloud;
            this.btn_Server.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Server.FlatAppearance.BorderSize = 0;
            this.btn_Server.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Server.ImageIndex = 3;
            this.btn_Server.Location = new System.Drawing.Point(53, 23);
            this.btn_Server.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Server.Name = "btn_Server";
            this.btn_Server.Size = new System.Drawing.Size(64, 64);
            this.btn_Server.TabIndex = 1;
            this.btn_Server.UseVisualStyleBackColor = true;
            this.btn_Server.Click += new System.EventHandler(this.btn_Server_Click);
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.Size = new System.Drawing.Size(728, 423);
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.uC_ExcelFileSel1);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(913, 399);
            // 
            // uC_ExcelFileSel1
            // 
            this.uC_ExcelFileSel1.BackColor = System.Drawing.Color.White;
            this.uC_ExcelFileSel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_ExcelFileSel1.Location = new System.Drawing.Point(0, 0);
            this.uC_ExcelFileSel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uC_ExcelFileSel1.Name = "uC_ExcelFileSel1";
            this.uC_ExcelFileSel1.Size = new System.Drawing.Size(913, 399);
            this.uC_ExcelFileSel1.TabIndex = 0;
            this.uC_ExcelFileSel1.Title = "请选择导入Excel文件";
            // 
            // windowsUIButtonPanel1
            // 
            this.windowsUIButtonPanel1.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton(),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton()});
            this.windowsUIButtonPanel1.Location = new System.Drawing.Point(151, 235);
            this.windowsUIButtonPanel1.Name = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel1.Size = new System.Drawing.Size(398, 119);
            this.windowsUIButtonPanel1.TabIndex = 7;
            this.windowsUIButtonPanel1.Text = "windowsUIButtonPanel1";
            // 
            // FrmDataImport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(945, 573);
            this.Controls.Add(this.wizardControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmDataImport";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.welcomeWizardPage1.ResumeLayout(false);
            this.panel_MainItem.ResumeLayout(false);
            this.panel_MainItem.PerformLayout();
            this.wizardPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private System.Windows.Forms.Panel panel_MainItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_curstom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Excel;
        private System.Windows.Forms.Button btn_BDCL;
        private System.Windows.Forms.Button btn_Server;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private Controls.UC_ExcelFileSel uC_ExcelFileSel1;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel1;
    }
}

