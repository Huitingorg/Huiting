namespace ReserveAnalysis
{
    partial class FrmChart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChart));
            this.jrChart1 = new AJRChart.JRChart();
            this.SuspendLayout();
            // 
            // jrChart1
            // 
            this.jrChart1.AxisFormatEvent = null;
            this.jrChart1.ChartDataStruct = ((AJRChart.ChartData)(resources.GetObject("jrChart1.ChartDataStruct")));
            this.jrChart1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jrChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jrChart1.Location = new System.Drawing.Point(0, 0);
            this.jrChart1.ModeType = AJRChart.DecChartModeType.Defuault;
            this.jrChart1.Name = "jrChart1";
            this.jrChart1.SBarEnable = true;
            this.jrChart1.Size = new System.Drawing.Size(694, 697);
            this.jrChart1.TabIndex = 13;
            // 
            // FrmChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 697);
            this.Controls.Add(this.jrChart1);
            this.Name = "FrmChart";
            this.Text = "FrmChart";
            this.ResumeLayout(false);

        }

        #endregion

        private AJRChart.JRChart jrChart1;
    }
}