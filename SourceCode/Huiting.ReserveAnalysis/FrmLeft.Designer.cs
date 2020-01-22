namespace ReserveAnalysis
{
    partial class FrmLeft
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLeft));
            this.uctTree1 = new ReserveComponents.UctTree();
            this.SuspendLayout();
            // 
            // uctTree1
            // 
            this.uctTree1.CheckBoxes = false;
            this.uctTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctTree1.EditButtonVisible = true;
            this.uctTree1.ImmediateSave = true;
            this.uctTree1.ListContextMenuStrip = null;
            this.uctTree1.Location = new System.Drawing.Point(0, 0);
            this.uctTree1.Name = "uctTree1";
            this.uctTree1.Size = new System.Drawing.Size(412, 583);
            this.uctTree1.TabIndex = 0;
            this.uctTree1.TreeContextMenuStrip = null;
            // 
            // FrmLeft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 583);
            this.Controls.Add(this.uctTree1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLeft";
            this.Text = "资产目录";
            this.ResumeLayout(false);

        }



        #endregion

        private ReserveComponents.UctTree uctTree1;


    }
}