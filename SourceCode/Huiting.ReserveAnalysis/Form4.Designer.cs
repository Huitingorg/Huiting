namespace ReserveAnalysis
{
    partial class Form4
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
            this.uctNewTreeByTree1 = new ReserveComponents.UctNewTreeByTree();
            this.SuspendLayout();
            // 
            // uctNewTreeByTree1
            // 
            this.uctNewTreeByTree1.BackColor = System.Drawing.SystemColors.Control;
            this.uctNewTreeByTree1.Location = new System.Drawing.Point(21, 55);
            this.uctNewTreeByTree1.Name = "uctNewTreeByTree1";
            this.uctNewTreeByTree1.NewProjectName = null;
            this.uctNewTreeByTree1.Padding = new System.Windows.Forms.Padding(5);
            this.uctNewTreeByTree1.Size = new System.Drawing.Size(799, 530);
            this.uctNewTreeByTree1.TabIndex = 0;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 640);
            this.Controls.Add(this.uctNewTreeByTree1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);

        }

        #endregion

        private ReserveComponents.UctNewTreeByTree uctNewTreeByTree1;
    }
}