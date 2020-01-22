namespace ReserveComponents
{
    partial class FrmPjndEdit
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
            this.uctEvaluationOptions1 = new ReserveComponents.UctEvaluationOptions();
            this.btnSure = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uctEvaluationOptions1
            // 
            this.uctEvaluationOptions1.Fqcl = 10D;
            this.uctEvaluationOptions1.Location = new System.Drawing.Point(12, 12);
            this.uctEvaluationOptions1.Name = "uctEvaluationOptions1";
            this.uctEvaluationOptions1.Nzxl = 10D;
            this.uctEvaluationOptions1.Pjnd = "201604";
            this.uctEvaluationOptions1.ProID = null;
            this.uctEvaluationOptions1.QFqcl = 10D;
            this.uctEvaluationOptions1.Size = new System.Drawing.Size(391, 199);
            this.uctEvaluationOptions1.TabIndex = 0;
            this.uctEvaluationOptions1.Ycjsrq = "201604";
            this.uctEvaluationOptions1.Ycqsrq = "201604";
            this.uctEvaluationOptions1.Zxrq = "201605";
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(239, 217);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 1;
            this.btnSure.Text = "确定(&S)";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(320, 217);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 2;
            this.btnCancle.Text = "取消(&C)";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // FrmPjndEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 252);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.uctEvaluationOptions1);
            this.Name = "FrmPjndEdit";
            this.Text = "添加评价年月";
            this.Load += new System.EventHandler(this.FrmPjndEdit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UctEvaluationOptions uctEvaluationOptions1;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Button btnCancle;
    }
}