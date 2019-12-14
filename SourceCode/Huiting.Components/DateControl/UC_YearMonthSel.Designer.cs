namespace BDSoft.Components
{
    partial class UC_YearMonthSel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_YearMonthSel));
            this.panel_PreYear = new System.Windows.Forms.Panel();
            this.textBox_Focus = new System.Windows.Forms.TextBox();
            this.label_PreYear = new System.Windows.Forms.Label();
            this.panel_PreMonth = new System.Windows.Forms.Panel();
            this.label_PreMonth = new System.Windows.Forms.Label();
            this.panel_Year = new System.Windows.Forms.Panel();
            this.btn_Today = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.label_SelYear = new System.Windows.Forms.Label();
            this.panel_Month = new System.Windows.Forms.Panel();
            this.label_SelMonth = new System.Windows.Forms.Label();
            this.panel_NextYear = new System.Windows.Forms.Panel();
            this.label_NextYear = new System.Windows.Forms.Label();
            this.panel_NextMonth = new System.Windows.Forms.Panel();
            this.label_NextMonth = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer_ShowPic = new System.Windows.Forms.Timer(this.components);
            this.timer_ClosePic = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer_focus = new System.Windows.Forms.Timer(this.components);
            this.panel_PreYear.SuspendLayout();
            this.panel_PreMonth.SuspendLayout();
            this.panel_Year.SuspendLayout();
            this.panel_Month.SuspendLayout();
            this.panel_NextYear.SuspendLayout();
            this.panel_NextMonth.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_PreYear
            // 
            this.panel_PreYear.BackColor = System.Drawing.Color.White;
            this.panel_PreYear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel_PreYear.Controls.Add(this.textBox_Focus);
            this.panel_PreYear.Controls.Add(this.label_PreYear);
            this.panel_PreYear.Location = new System.Drawing.Point(3, 3);
            this.panel_PreYear.Name = "panel_PreYear";
            this.panel_PreYear.Size = new System.Drawing.Size(152, 25);
            this.panel_PreYear.TabIndex = 0;
            this.panel_PreYear.Click += new System.EventHandler(this.panel_PreYear_Click);
            this.panel_PreYear.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_PreYear_MouseDown);
            this.panel_PreYear.MouseEnter += new System.EventHandler(this.panel_PreYear_MouseEnter);
            this.panel_PreYear.MouseLeave += new System.EventHandler(this.panel_PreYear_MouseLeave);
            // 
            // textBox_Focus
            // 
            this.textBox_Focus.Location = new System.Drawing.Point(1, 4);
            this.textBox_Focus.Name = "textBox_Focus";
            this.textBox_Focus.Size = new System.Drawing.Size(16, 21);
            this.textBox_Focus.TabIndex = 1;
            // 
            // label_PreYear
            // 
            this.label_PreYear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_PreYear.AutoSize = true;
            this.label_PreYear.BackColor = System.Drawing.Color.Transparent;
            this.label_PreYear.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_PreYear.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label_PreYear.Location = new System.Drawing.Point(62, 6);
            this.label_PreYear.Name = "label_PreYear";
            this.label_PreYear.Size = new System.Drawing.Size(41, 12);
            this.label_PreYear.TabIndex = 0;
            this.label_PreYear.Text = "2013年";
            this.label_PreYear.Click += new System.EventHandler(this.panel_PreYear_Click);
            this.label_PreYear.MouseEnter += new System.EventHandler(this.panel_PreYear_MouseEnter);
            // 
            // panel_PreMonth
            // 
            this.panel_PreMonth.BackColor = System.Drawing.Color.White;
            this.panel_PreMonth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel_PreMonth.Controls.Add(this.label_PreMonth);
            this.panel_PreMonth.Location = new System.Drawing.Point(161, 3);
            this.panel_PreMonth.Name = "panel_PreMonth";
            this.panel_PreMonth.Size = new System.Drawing.Size(152, 25);
            this.panel_PreMonth.TabIndex = 0;
            this.panel_PreMonth.Click += new System.EventHandler(this.panel_PreMonth_Click);
            this.panel_PreMonth.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_PreMonth_MouseDown);
            this.panel_PreMonth.MouseEnter += new System.EventHandler(this.panel_PreMonth_MouseEnter);
            this.panel_PreMonth.MouseLeave += new System.EventHandler(this.panel_PreMonth_MouseLeave);
            // 
            // label_PreMonth
            // 
            this.label_PreMonth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_PreMonth.AutoSize = true;
            this.label_PreMonth.BackColor = System.Drawing.Color.Transparent;
            this.label_PreMonth.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_PreMonth.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label_PreMonth.Location = new System.Drawing.Point(58, 6);
            this.label_PreMonth.Name = "label_PreMonth";
            this.label_PreMonth.Size = new System.Drawing.Size(29, 12);
            this.label_PreMonth.TabIndex = 0;
            this.label_PreMonth.Text = "09月";
            this.label_PreMonth.Click += new System.EventHandler(this.panel_PreMonth_Click);
            this.label_PreMonth.MouseEnter += new System.EventHandler(this.panel_PreMonth_MouseEnter);
            // 
            // panel_Year
            // 
            this.panel_Year.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.panel_Year.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Year.Controls.Add(this.btn_Today);
            this.panel_Year.Controls.Add(this.label_SelYear);
            this.panel_Year.Location = new System.Drawing.Point(4, 34);
            this.panel_Year.Name = "panel_Year";
            this.panel_Year.Size = new System.Drawing.Size(152, 29);
            this.panel_Year.TabIndex = 0;
            this.panel_Year.Tag = "2015";
            this.panel_Year.Click += new System.EventHandler(this.panel_Year_Click);
            this.panel_Year.MouseEnter += new System.EventHandler(this.panel_Year_MouseEnter);
            this.panel_Year.MouseLeave += new System.EventHandler(this.panel_Year_MouseLeave);
            // 
            // btn_Today
            // 
            this.btn_Today.BackColor = System.Drawing.Color.Transparent;
            this.btn_Today.FlatAppearance.BorderSize = 0;
            this.btn_Today.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Today.ImageIndex = 0;
            this.btn_Today.ImageList = this.imageList2;
            this.btn_Today.Location = new System.Drawing.Point(-1, -1);
            this.btn_Today.Name = "btn_Today";
            this.btn_Today.Size = new System.Drawing.Size(18, 18);
            this.btn_Today.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btn_Today, "设置为当前年月!");
            this.btn_Today.UseVisualStyleBackColor = false;
            this.btn_Today.Click += new System.EventHandler(this.btn_Today_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "today_16px_35162_easyicon.net.png");
            // 
            // label_SelYear
            // 
            this.label_SelYear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_SelYear.AutoSize = true;
            this.label_SelYear.BackColor = System.Drawing.Color.Transparent;
            this.label_SelYear.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SelYear.Location = new System.Drawing.Point(56, 5);
            this.label_SelYear.Name = "label_SelYear";
            this.label_SelYear.Size = new System.Drawing.Size(48, 17);
            this.label_SelYear.TabIndex = 0;
            this.label_SelYear.Text = "2015年";
            this.label_SelYear.Click += new System.EventHandler(this.panel_Year_Click);
            this.label_SelYear.MouseEnter += new System.EventHandler(this.panel_Year_MouseEnter);
            this.label_SelYear.MouseLeave += new System.EventHandler(this.panel_Year_MouseLeave);
            // 
            // panel_Month
            // 
            this.panel_Month.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.panel_Month.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Month.Controls.Add(this.label_SelMonth);
            this.panel_Month.Location = new System.Drawing.Point(161, 34);
            this.panel_Month.Name = "panel_Month";
            this.panel_Month.Size = new System.Drawing.Size(152, 29);
            this.panel_Month.TabIndex = 0;
            this.panel_Month.Tag = "10";
            this.panel_Month.Click += new System.EventHandler(this.panel_Year_Click);
            this.panel_Month.MouseEnter += new System.EventHandler(this.panel_Month_MouseEnter);
            this.panel_Month.MouseLeave += new System.EventHandler(this.panel_Month_MouseLeave);
            // 
            // label_SelMonth
            // 
            this.label_SelMonth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_SelMonth.AutoSize = true;
            this.label_SelMonth.BackColor = System.Drawing.Color.Transparent;
            this.label_SelMonth.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SelMonth.Location = new System.Drawing.Point(54, 5);
            this.label_SelMonth.Name = "label_SelMonth";
            this.label_SelMonth.Size = new System.Drawing.Size(34, 17);
            this.label_SelMonth.TabIndex = 0;
            this.label_SelMonth.Text = "10月";
            this.label_SelMonth.Click += new System.EventHandler(this.panel_Year_Click);
            this.label_SelMonth.MouseEnter += new System.EventHandler(this.panel_Month_MouseEnter);
            // 
            // panel_NextYear
            // 
            this.panel_NextYear.BackColor = System.Drawing.Color.White;
            this.panel_NextYear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel_NextYear.Controls.Add(this.label_NextYear);
            this.panel_NextYear.Location = new System.Drawing.Point(3, 69);
            this.panel_NextYear.Name = "panel_NextYear";
            this.panel_NextYear.Size = new System.Drawing.Size(152, 25);
            this.panel_NextYear.TabIndex = 0;
            this.panel_NextYear.Click += new System.EventHandler(this.panel_NextYear_Click);
            this.panel_NextYear.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_NextYear_MouseDown);
            this.panel_NextYear.MouseEnter += new System.EventHandler(this.panel_NextYear_MouseEnter);
            this.panel_NextYear.MouseLeave += new System.EventHandler(this.panel_NextYear_MouseLeave);
            // 
            // label_NextYear
            // 
            this.label_NextYear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_NextYear.AutoSize = true;
            this.label_NextYear.BackColor = System.Drawing.Color.Transparent;
            this.label_NextYear.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_NextYear.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label_NextYear.Location = new System.Drawing.Point(62, 6);
            this.label_NextYear.Name = "label_NextYear";
            this.label_NextYear.Size = new System.Drawing.Size(41, 12);
            this.label_NextYear.TabIndex = 0;
            this.label_NextYear.Text = "2016年";
            this.label_NextYear.Click += new System.EventHandler(this.panel_NextYear_Click);
            this.label_NextYear.MouseEnter += new System.EventHandler(this.panel_NextYear_MouseEnter);
            // 
            // panel_NextMonth
            // 
            this.panel_NextMonth.BackColor = System.Drawing.Color.White;
            this.panel_NextMonth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel_NextMonth.Controls.Add(this.label_NextMonth);
            this.panel_NextMonth.Location = new System.Drawing.Point(161, 69);
            this.panel_NextMonth.Name = "panel_NextMonth";
            this.panel_NextMonth.Size = new System.Drawing.Size(152, 25);
            this.panel_NextMonth.TabIndex = 0;
            this.panel_NextMonth.Click += new System.EventHandler(this.panel_NextMonth_Click);
            this.panel_NextMonth.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_NextMonth_MouseDown);
            this.panel_NextMonth.MouseEnter += new System.EventHandler(this.panel_NextMonth_MouseEnter);
            this.panel_NextMonth.MouseLeave += new System.EventHandler(this.panel_NextMonth_MouseLeave);
            // 
            // label_NextMonth
            // 
            this.label_NextMonth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_NextMonth.AutoSize = true;
            this.label_NextMonth.BackColor = System.Drawing.Color.Transparent;
            this.label_NextMonth.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_NextMonth.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label_NextMonth.Location = new System.Drawing.Point(58, 6);
            this.label_NextMonth.Name = "label_NextMonth";
            this.label_NextMonth.Size = new System.Drawing.Size(29, 12);
            this.label_NextMonth.TabIndex = 0;
            this.label_NextMonth.Text = "11月";
            this.label_NextMonth.Click += new System.EventHandler(this.panel_NextMonth_Click);
            this.label_NextMonth.MouseEnter += new System.EventHandler(this.panel_NextMonth_MouseEnter);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "arrow_up_44px_548408_easyicon.net.png");
            this.imageList1.Images.SetKeyName(1, "arrow_down_44px_548405_easyicon.net.png");
            // 
            // timer_ShowPic
            // 
            this.timer_ShowPic.Interval = 300;
            this.timer_ShowPic.Tick += new System.EventHandler(this.timer_ShowPic_Tick);
            // 
            // timer_ClosePic
            // 
            this.timer_ClosePic.Interval = 300;
            this.timer_ClosePic.Tick += new System.EventHandler(this.timer_ClosePic_Tick);
            // 
            // timer_focus
            // 
            this.timer_focus.Interval = 500;
            this.timer_focus.Tick += new System.EventHandler(this.timer_focus_Tick);
            // 
            // UC_YearMonthSel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel_Month);
            this.Controls.Add(this.panel_NextMonth);
            this.Controls.Add(this.panel_PreMonth);
            this.Controls.Add(this.panel_NextYear);
            this.Controls.Add(this.panel_Year);
            this.Controls.Add(this.panel_PreYear);
            this.DoubleBuffered = true;
            this.Name = "UC_YearMonthSel";
            this.Size = new System.Drawing.Size(317, 101);
            this.panel_PreYear.ResumeLayout(false);
            this.panel_PreYear.PerformLayout();
            this.panel_PreMonth.ResumeLayout(false);
            this.panel_PreMonth.PerformLayout();
            this.panel_Year.ResumeLayout(false);
            this.panel_Year.PerformLayout();
            this.panel_Month.ResumeLayout(false);
            this.panel_Month.PerformLayout();
            this.panel_NextYear.ResumeLayout(false);
            this.panel_NextYear.PerformLayout();
            this.panel_NextMonth.ResumeLayout(false);
            this.panel_NextMonth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel_PreYear;
        public System.Windows.Forms.Label label_PreYear;
        public System.Windows.Forms.Panel panel_PreMonth;
        public System.Windows.Forms.Label label_PreMonth;
        public System.Windows.Forms.Panel panel_Year;
        public System.Windows.Forms.Label label_SelYear;
        public System.Windows.Forms.Panel panel_Month;
        public System.Windows.Forms.Label label_SelMonth;
        public System.Windows.Forms.Panel panel_NextYear;
        public System.Windows.Forms.Label label_NextYear;
        public System.Windows.Forms.Panel panel_NextMonth;
        public System.Windows.Forms.Label label_NextMonth;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer_ShowPic;
        private System.Windows.Forms.Timer timer_ClosePic;
        public System.Windows.Forms.TextBox textBox_Focus;
        private System.Windows.Forms.Button btn_Today;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Timer timer_focus;

    }
}
