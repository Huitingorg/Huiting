namespace BDSoft.Components
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.button1 = new System.Windows.Forms.Button();
            this.treeHeadDataGridView1 = new BDSoft.Components.TreeHeadDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.treeHeadDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(460, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeHeadDataGridView1
            // 
            this.treeHeadDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.treeHeadDataGridView1.Location = new System.Drawing.Point(44, 48);
            this.treeHeadDataGridView1.Name = "treeHeadDataGridView1";
            this.treeHeadDataGridView1.RealHeadCellHeight = 25;
            this.treeHeadDataGridView1.RowTemplate.Height = 23;
            this.treeHeadDataGridView1.Size = new System.Drawing.Size(521, 267);
            this.treeHeadDataGridView1.TabIndex = 2;
            this.treeHeadDataGridView1.TreeHeadRootColumn = ((BDSoft.Components.DataGridViewColumnNode)(resources.GetObject("treeHeadDataGridView1.TreeHeadRootColumn")));
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 524);
            this.Controls.Add(this.treeHeadDataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.treeHeadDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private TreeHeadDataGridView treeHeadDataGridView1;


    }
}