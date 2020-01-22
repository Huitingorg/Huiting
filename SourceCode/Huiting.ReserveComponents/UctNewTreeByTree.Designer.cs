namespace ReserveComponents
{
    partial class UctNewTreeByTree
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.uctTree1 = new ReserveComponents.UctTree();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uctTree2 = new ReserveComponents.UctTree();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "可选工程：";
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMiddle.Location = new System.Drawing.Point(334, 5);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(12, 457);
            this.pnlMiddle.TabIndex = 6;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.SystemColors.Control;
            this.pnlLeft.Controls.Add(this.label3);
            this.pnlLeft.Controls.Add(this.comboBox1);
            this.pnlLeft.Controls.Add(this.uctTree1);
            this.pnlLeft.Controls.Add(this.label1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(5, 5);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(329, 457);
            this.pnlLeft.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "可选资产：";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 12;
            this.comboBox1.Location = new System.Drawing.Point(74, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(249, 20);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // uctTree1
            // 
            this.uctTree1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctTree1.CheckBoxes = false;
            this.uctTree1.EditButtonVisible = false;
            this.uctTree1.ImmediateSave = false;
            this.uctTree1.ListContextMenuStrip = null;
            this.uctTree1.Location = new System.Drawing.Point(0, 60);
            this.uctTree1.Name = "uctTree1";
            this.uctTree1.Size = new System.Drawing.Size(329, 394);
            this.uctTree1.TabIndex = 0;
            this.uctTree1.TreeContextMenuStrip = null;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.SystemColors.Control;
            this.pnlRight.Controls.Add(this.txtProject);
            this.pnlRight.Controls.Add(this.label6);
            this.pnlRight.Controls.Add(this.uctTree2);
            this.pnlRight.Controls.Add(this.label2);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRight.Location = new System.Drawing.Point(346, 5);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(332, 457);
            this.pnlRight.TabIndex = 8;
            // 
            // txtProject
            // 
            this.txtProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtProject.Location = new System.Drawing.Point(75, 2);
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(249, 21);
            this.txtProject.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "当前工程：";
            // 
            // uctTree2
            // 
            this.uctTree2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctTree2.CheckBoxes = false;
            this.uctTree2.EditButtonVisible = false;
            this.uctTree2.ImmediateSave = false;
            this.uctTree2.ListContextMenuStrip = null;
            this.uctTree2.Location = new System.Drawing.Point(0, 60);
            this.uctTree2.Name = "uctTree2";
            this.uctTree2.Size = new System.Drawing.Size(332, 394);
            this.uctTree2.TabIndex = 0;
            this.uctTree2.TreeContextMenuStrip = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "已选资产：";
            // 
            // UctNewTreeByTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlLeft);
            this.Name = "UctNewTreeByTree";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(685, 467);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UctTree uctTree1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private UctTree uctTree2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProject;
    }
}
