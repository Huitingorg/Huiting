namespace ReserveAnalysis
{
    partial class FrmNewProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewProject));
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.wpBasicInfo = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.txtBZ = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wpEval = new DevExpress.XtraWizard.WizardPage();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.uctEvaluationOptions1 = new ReserveComponents.UctEvaluationOptions();
            this.wpFinished = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wpImport = new DevExpress.XtraWizard.WizardPage();
            this.uctNewTreeByTree1 = new ReserveComponents.UctNewTreeByTree();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.wpBasicInfo.SuspendLayout();
            this.wpEval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.wpFinished.SuspendLayout();
            this.wpImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.AllowAutoScaling = DevExpress.Utils.DefaultBoolean.False;
            this.wizardControl1.CancelText = "取消";
            this.wizardControl1.Controls.Add(this.wpBasicInfo);
            this.wizardControl1.Controls.Add(this.wpEval);
            this.wizardControl1.Controls.Add(this.wpFinished);
            this.wizardControl1.Controls.Add(this.wpImport);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.FinishText = "完成";
            this.wizardControl1.Image = global::ReserveAnalysis.Properties.Resources.data;
            this.wizardControl1.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextText = "下一步";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.wpBasicInfo,
            this.wpEval,
            this.wpImport,
            this.wpFinished});
            this.wizardControl1.PreviousText = "上一步";
            this.wizardControl1.Size = new System.Drawing.Size(1048, 677);
            this.wizardControl1.CancelClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_CancelClick);
            this.wizardControl1.FinishClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_FinishClick);
            this.wizardControl1.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wizardControl1_NextClick);
            this.wizardControl1.PrevClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wizardControl1_PrevClick);
            // 
            // wpBasicInfo
            // 
            this.wpBasicInfo.Controls.Add(this.txtBZ);
            this.wpBasicInfo.Controls.Add(this.label2);
            this.wpBasicInfo.Controls.Add(this.txtName);
            this.wpBasicInfo.Controls.Add(this.label1);
            this.wpBasicInfo.IntroductionText = "";
            this.wpBasicInfo.Name = "wpBasicInfo";
            this.wpBasicInfo.ProceedText = "";
            this.wpBasicInfo.Size = new System.Drawing.Size(831, 537);
            this.wpBasicInfo.Text = "基础信息";
            // 
            // txtBZ
            // 
            this.txtBZ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBZ.Location = new System.Drawing.Point(127, 75);
            this.txtBZ.Margin = new System.Windows.Forms.Padding(4);
            this.txtBZ.Multiline = true;
            this.txtBZ.Name = "txtBZ";
            this.txtBZ.Size = new System.Drawing.Size(674, 436);
            this.txtBZ.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "备注：";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(127, 23);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(674, 26);
            this.txtName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "工程名：";
            // 
            // wpEval
            // 
            this.wpEval.Controls.Add(this.label4);
            this.wpEval.Controls.Add(this.pictureBox1);
            this.wpEval.Controls.Add(this.checkBox1);
            this.wpEval.Controls.Add(this.uctEvaluationOptions1);
            this.wpEval.DescriptionText = "工程的评估选项";
            this.wpEval.Name = "wpEval";
            this.wpEval.Size = new System.Drawing.Size(1016, 530);
            this.wpEval.Text = "评估选项";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(671, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(293, 134);
            this.label4.TabIndex = 13;
            this.label4.Text = "      软件以油气井属性为基础，开展油气藏开发规律分析，进一步评价油气藏剩余可采储量及可采储量。同时可以通过对比不同时间段可采储量变化，结合开发行为，分析各种" +
    "开发工作对应的增储效果。";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(674, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(290, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(46, 358);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(180, 22);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "从现有项目中导入资产";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // uctEvaluationOptions1
            // 
            this.uctEvaluationOptions1.Location = new System.Drawing.Point(37, 20);
            this.uctEvaluationOptions1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uctEvaluationOptions1.Name = "uctEvaluationOptions1";
            this.uctEvaluationOptions1.Size = new System.Drawing.Size(535, 281);
            this.uctEvaluationOptions1.TabIndex = 1;
            // 
            // wpFinished
            // 
            this.wpFinished.Controls.Add(this.progressPanel1);
            this.wpFinished.FinishText = "";
            this.wpFinished.Name = "wpFinished";
            this.wpFinished.ProceedText = "";
            this.wpFinished.Size = new System.Drawing.Size(831, 537);
            this.wpFinished.Text = "工程创建成功";
            // 
            // wpImport
            // 
            this.wpImport.Controls.Add(this.uctNewTreeByTree1);
            this.wpImport.DescriptionText = "将其他工程中的资产导入到本工程中";
            this.wpImport.Name = "wpImport";
            this.wpImport.Size = new System.Drawing.Size(1016, 530);
            this.wpImport.Text = "资产导入";
            // 
            // uctNewTreeByTree1
            // 
            this.uctNewTreeByTree1.BackColor = System.Drawing.SystemColors.Control;
            this.uctNewTreeByTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctNewTreeByTree1.Location = new System.Drawing.Point(0, 0);
            this.uctNewTreeByTree1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uctNewTreeByTree1.Name = "uctNewTreeByTree1";
            this.uctNewTreeByTree1.NewProjectName = null;
            this.uctNewTreeByTree1.Padding = new System.Windows.Forms.Padding(7);
            this.uctNewTreeByTree1.Size = new System.Drawing.Size(1016, 530);
            this.uctNewTreeByTree1.TabIndex = 7;
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.BarAnimationElementThickness = 2;
            this.progressPanel1.Caption = "请稍等...";
            this.progressPanel1.Description = "正在保存数据";
            this.progressPanel1.Location = new System.Drawing.Point(134, 157);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(481, 137);
            this.progressPanel1.TabIndex = 6;
            this.progressPanel1.Text = "progressPanel1";
            // 
            // FrmNewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 677);
            this.Controls.Add(this.wizardControl1);
            this.Name = "FrmNewProject";
            this.Text = "新建工程";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.wpBasicInfo.ResumeLayout(false);
            this.wpBasicInfo.PerformLayout();
            this.wpEval.ResumeLayout(false);
            this.wpEval.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.wpFinished.ResumeLayout(false);
            this.wpImport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage wpBasicInfo;
        private DevExpress.XtraWizard.WizardPage wpEval;
        private DevExpress.XtraWizard.CompletionWizardPage wpFinished;
        private System.Windows.Forms.TextBox txtBZ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private ReserveComponents.UctEvaluationOptions uctEvaluationOptions1;
        private System.Windows.Forms.CheckBox checkBox1;
        private DevExpress.XtraWizard.WizardPage wpImport;
        private ReserveComponents.UctNewTreeByTree uctNewTreeByTree1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
    }
}