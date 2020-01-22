namespace ReserveAnalysis
{
    partial class Form8
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
            this.bdNumBoxEx2 = new BDSoft.Components.BDNumBoxEx();
            this.SuspendLayout();
            // 
            // bdNumBoxEx1
            // 
            this.bdNumBoxEx1.EnterAutoSelAllText = true;
            this.bdNumBoxEx1.LineStyle = false;
            this.bdNumBoxEx1.Location = new System.Drawing.Point(76, 105);
            this.bdNumBoxEx1.Name = "bdNumBoxEx1";
            this.bdNumBoxEx1.RealValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.bdNumBoxEx1.ShowDecimalLength = 2;
            this.bdNumBoxEx1.Size = new System.Drawing.Size(100, 21);
            this.bdNumBoxEx1.TabIndex = 0;
            this.bdNumBoxEx1.Text = "0";
            this.bdNumBoxEx1.TextEx = "0";
            // 
            // bdNumBoxEx2
            // 
            this.bdNumBoxEx2.EnterAutoSelAllText = true;
            this.bdNumBoxEx2.LineStyle = false;
            this.bdNumBoxEx2.Location = new System.Drawing.Point(76, 158);
            this.bdNumBoxEx2.Name = "bdNumBoxEx2";
            this.bdNumBoxEx2.RealValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.bdNumBoxEx2.ShowDecimalLength = 2;
            this.bdNumBoxEx2.Size = new System.Drawing.Size(100, 21);
            this.bdNumBoxEx2.TabIndex = 1;
            this.bdNumBoxEx2.Text = "0";
            this.bdNumBoxEx2.TextEx = "0";
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 677);
            this.Controls.Add(this.bdNumBoxEx2);
            this.Controls.Add(this.bdNumBoxEx1);
            this.Name = "Form8";
            this.Text = "Form8";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BDSoft.Components.BDNumBoxEx bdNumBoxEx1;
        private BDSoft.Components.BDNumBoxEx bdNumBoxEx2;
    }
}