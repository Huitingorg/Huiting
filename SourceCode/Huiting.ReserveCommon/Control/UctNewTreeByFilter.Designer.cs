namespace ReserveCommon
{
    partial class UctNewTreeByFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctNewTreeByFilter));
            this.pnlRight = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.uctTree1 = new ReserveCommon.UctTree();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.uctSqlFilter1 = new ReserveCommon.UctSqlFilter();
            this.pnlRight.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.label4);
            this.pnlRight.Controls.Add(this.uctTree1);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(318, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(258, 516);
            this.pnlRight.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "检索内容：";
            // 
            // uctTree1
            // 
            this.uctTree1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctTree1.EditButtonVisible = false;
            this.uctTree1.Location = new System.Drawing.Point(3, 44);
            this.uctTree1.Name = "uctTree1";
            this.uctTree1.Size = new System.Drawing.Size(252, 469);
            this.uctTree1.TabIndex = 2;
            this.uctTree1.TreeContextMenuStrip = null;
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.button3);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMiddle.Location = new System.Drawing.Point(233, 0);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(85, 516);
            this.pnlMiddle.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(4, 242);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 40);
            this.button3.TabIndex = 2;
            this.button3.Text = "应用";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.label1);
            this.pnlLeft.Controls.Add(this.uctSqlFilter1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(233, 516);
            this.pnlLeft.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "过滤条件：";
            // 
            // uctSqlFilter1
            // 
            this.uctSqlFilter1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctSqlFilter1.BackColor = System.Drawing.Color.White;
            this.uctSqlFilter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uctSqlFilter1.BackgroundImage")));
            this.uctSqlFilter1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.uctSqlFilter1.Location = new System.Drawing.Point(3, 44);
            this.uctSqlFilter1.Name = "uctSqlFilter1";
            this.uctSqlFilter1.Size = new System.Drawing.Size(227, 469);
            this.uctSqlFilter1.TabIndex = 0;
            // 
            // UctNewTreeByFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlLeft);
            this.Name = "UctNewTreeByFilter";
            this.Size = new System.Drawing.Size(576, 516);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label label4;
        private UctTree uctTree1;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label label1;
        private UctSqlFilter uctSqlFilter1;
    }
}
