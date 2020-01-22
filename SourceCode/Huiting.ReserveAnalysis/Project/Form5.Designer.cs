namespace ReserveAnalysis
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.btnWriteXml = new System.Windows.Forms.Button();
            this.btnLoadSeries = new System.Windows.Forms.Button();
            this.btnReadXml = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.bdChart1 = new BDSoft.Chart.BDChart();
            this.bdToolBar1 = new BDSoft.Chart.BDToolBar();
            this.SuspendLayout();
            // 
            // btnWriteXml
            // 
            this.btnWriteXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWriteXml.Location = new System.Drawing.Point(651, 12);
            this.btnWriteXml.Name = "btnWriteXml";
            this.btnWriteXml.Size = new System.Drawing.Size(75, 23);
            this.btnWriteXml.TabIndex = 1;
            this.btnWriteXml.Text = "写XML";
            this.btnWriteXml.UseVisualStyleBackColor = true;
            this.btnWriteXml.Click += new System.EventHandler(this.btnWriteXml_Click);
            // 
            // btnLoadSeries
            // 
            this.btnLoadSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadSeries.Location = new System.Drawing.Point(834, 12);
            this.btnLoadSeries.Name = "btnLoadSeries";
            this.btnLoadSeries.Size = new System.Drawing.Size(75, 23);
            this.btnLoadSeries.TabIndex = 3;
            this.btnLoadSeries.Text = "加载曲线";
            this.btnLoadSeries.UseVisualStyleBackColor = true;
            this.btnLoadSeries.Click += new System.EventHandler(this.btnLoadSeries_Click);
            // 
            // btnReadXml
            // 
            this.btnReadXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadXml.Location = new System.Drawing.Point(732, 12);
            this.btnReadXml.Name = "btnReadXml";
            this.btnReadXml.Size = new System.Drawing.Size(75, 23);
            this.btnReadXml.TabIndex = 1;
            this.btnReadXml.Text = "读XML";
            this.btnReadXml.UseVisualStyleBackColor = true;
            this.btnReadXml.Click += new System.EventHandler(this.btnReadXml_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadData.Location = new System.Drawing.Point(556, 12);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 5;
            this.btnLoadData.Text = "加载数据";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // bdChart1
            // 
            this.bdChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bdChart1.BackColor = System.Drawing.Color.White;
            this.bdChart1.CursorTipVisible = true;
            this.bdChart1.Location = new System.Drawing.Point(12, 72);
            this.bdChart1.Name = "bdChart1";
            this.bdChart1.SelectedObject = null;
            this.bdChart1.Size = new System.Drawing.Size(897, 553);
            this.bdChart1.TabIndex = 2;
            this.bdChart1.ToolBar = null;
            // 
            // bdToolBar1
            // 
            this.bdToolBar1.BDChart = null;
            this.bdToolBar1.Location = new System.Drawing.Point(12, 41);
            this.bdToolBar1.Name = "bdToolBar1";
            this.bdToolBar1.Size = new System.Drawing.Size(621, 25);
            this.bdToolBar1.TabIndex = 6;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(921, 637);
            this.Controls.Add(this.bdToolBar1);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.btnLoadSeries);
            this.Controls.Add(this.bdChart1);
            this.Controls.Add(this.btnReadXml);
            this.Controls.Add(this.btnWriteXml);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form5";
            this.Text = "测试5";
            this.ResumeLayout(false);

        }

        #endregion

        private BDSoft.Chart.BDChart bdChart1;
        private System.Windows.Forms.Button btnLoadSeries;
        private System.Windows.Forms.Button btnWriteXml;
        private System.Windows.Forms.Button btnReadXml;
        private System.Windows.Forms.Button btnLoadData;
        private BDSoft.Chart.BDToolBar bdToolBar1;
    }
}