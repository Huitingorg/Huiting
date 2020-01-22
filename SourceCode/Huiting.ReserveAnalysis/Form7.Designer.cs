namespace ReserveAnalysis
{
    partial class Form7
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
            this.bdNumBoxEx1 = new BDSoft.Components.BDNumBoxEx();
            this.SuspendLayout();
            // 
            // bdNumBoxEx1
            // 
            this.bdNumBoxEx1.LineStyle = false;
            this.bdNumBoxEx1.Location = new System.Drawing.Point(88, 120);
            this.bdNumBoxEx1.Name = "bdNumBoxEx1";
            this.bdNumBoxEx1.RealValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.bdNumBoxEx1.ShowDecimalLength = 2;
            this.bdNumBoxEx1.Size = new System.Drawing.Size(100, 21);
            this.bdNumBoxEx1.TabIndex = 0;
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 383);
            this.Controls.Add(this.bdNumBoxEx1);
            this.Name = "Form7";
            this.Text = "Form7";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BDSoft.Components.BDNumBoxEx bdNumBoxEx1;

    }
}