namespace ReserveAnalysis
{
    partial class Form3
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
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnLoadSeries = new System.Windows.Forms.Button();
            this.btnReadXml = new System.Windows.Forms.Button();
            this.btnWriteXml = new System.Windows.Forms.Button();
            this.bdToolBar1 = new ReserveChart.BDToolBar();
            this.bdChart1 = new ReserveChart.BDChart();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadData
            // 
            this.btnLoadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadData.Location = new System.Drawing.Point(729, 12);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 9;
            this.btnLoadData.Text = "加载数据";
            this.btnLoadData.UseVisualStyleBackColor = true;
            // 
            // btnLoadSeries
            // 
            this.btnLoadSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadSeries.Location = new System.Drawing.Point(1007, 12);
            this.btnLoadSeries.Name = "btnLoadSeries";
            this.btnLoadSeries.Size = new System.Drawing.Size(75, 23);
            this.btnLoadSeries.TabIndex = 8;
            this.btnLoadSeries.Text = "加载曲线";
            this.btnLoadSeries.UseVisualStyleBackColor = true;
            // 
            // btnReadXml
            // 
            this.btnReadXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadXml.Location = new System.Drawing.Point(905, 12);
            this.btnReadXml.Name = "btnReadXml";
            this.btnReadXml.Size = new System.Drawing.Size(75, 23);
            this.btnReadXml.TabIndex = 6;
            this.btnReadXml.Text = "读XML";
            this.btnReadXml.UseVisualStyleBackColor = true;
            this.btnReadXml.Click += new System.EventHandler(this.btnReadXml_Click);
            // 
            // btnWriteXml
            // 
            this.btnWriteXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWriteXml.Location = new System.Drawing.Point(824, 12);
            this.btnWriteXml.Name = "btnWriteXml";
            this.btnWriteXml.Size = new System.Drawing.Size(75, 23);
            this.btnWriteXml.TabIndex = 7;
            this.btnWriteXml.Text = "写XML";
            this.btnWriteXml.UseVisualStyleBackColor = true;
            this.btnWriteXml.Click += new System.EventHandler(this.btnWriteXml_Click);
            // 
            // bdToolBar1
            // 
            this.bdToolBar1.BDChart = null;
            this.bdToolBar1.IsCutVisible = true;
            this.bdToolBar1.Location = new System.Drawing.Point(12, 41);
            this.bdToolBar1.Name = "bdToolBar1";
            this.bdToolBar1.Size = new System.Drawing.Size(1072, 25);
            this.bdToolBar1.TabIndex = 11;
            // 
            // bdChart1
            // 
            this.bdChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bdChart1.BackColor = System.Drawing.Color.White;
            this.bdChart1.CursorTipVisible = true;
            this.bdChart1.Location = new System.Drawing.Point(12, 65);
            this.bdChart1.Name = "bdChart1";
            this.bdChart1.ReCalcLayout = false;
            this.bdChart1.SelectedObject = null;
            this.bdChart1.Size = new System.Drawing.Size(1072, 660);
            this.bdChart1.TabIndex = 10;
            this.bdChart1.ToolBar = null;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(627, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "焦点控件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 737);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bdToolBar1);
            this.Controls.Add(this.bdChart1);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.btnLoadSeries);
            this.Controls.Add(this.btnReadXml);
            this.Controls.Add(this.btnWriteXml);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnLoadSeries;
        private System.Windows.Forms.Button btnReadXml;
        private System.Windows.Forms.Button btnWriteXml;
        private ReserveChart.BDChart bdChart1;
        private ReserveChart.BDToolBar bdToolBar1;
        private System.Windows.Forms.Button button1;
    }
}