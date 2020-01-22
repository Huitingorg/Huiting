namespace Huiting.Components
{
    partial class FrmTreeHeadColumnsEdit
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("复杂表头");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTreeHeadColumnsEdit));
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new Huiting.Components.TreeViewByRightSelected();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnDelete2 = new System.Windows.Forms.Button();
            this.btnAddSub = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCollapse = new System.Windows.Forms.LinkLabel();
            this.lblExpand = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnSure = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 411);
            this.panel1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(0, 43);
            this.treeView1.Name = "treeView1";
            treeNode2.Name = "节点0";
            treeNode2.Text = "复杂表头";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeView1.Size = new System.Drawing.Size(226, 325);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnDelete2);
            this.panel5.Controls.Add(this.btnAddSub);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 368);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(226, 43);
            this.panel5.TabIndex = 7;
            // 
            // btnDelete2
            // 
            this.btnDelete2.Location = new System.Drawing.Point(115, 9);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(105, 28);
            this.btnDelete2.TabIndex = 3;
            this.btnDelete2.Text = "删除(&D)";
            this.btnDelete2.UseVisualStyleBackColor = true;
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // btnAddSub
            // 
            this.btnAddSub.Location = new System.Drawing.Point(4, 9);
            this.btnAddSub.Name = "btnAddSub";
            this.btnAddSub.Size = new System.Drawing.Size(105, 28);
            this.btnAddSub.TabIndex = 4;
            this.btnAddSub.Text = "添加子级(&A)";
            this.btnAddSub.UseVisualStyleBackColor = true;
            this.btnAddSub.Click += new System.EventHandler(this.btnAddSub_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblCollapse);
            this.panel3.Controls.Add(this.lblExpand);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(226, 43);
            this.panel3.TabIndex = 1;
            // 
            // lblCollapse
            // 
            this.lblCollapse.AutoSize = true;
            this.lblCollapse.Location = new System.Drawing.Point(164, 16);
            this.lblCollapse.Name = "lblCollapse";
            this.lblCollapse.Size = new System.Drawing.Size(29, 12);
            this.lblCollapse.TabIndex = 4;
            this.lblCollapse.TabStop = true;
            this.lblCollapse.Text = "折叠";
            this.lblCollapse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCollapse_LinkClicked);
            // 
            // lblExpand
            // 
            this.lblExpand.AutoSize = true;
            this.lblExpand.Location = new System.Drawing.Point(105, 16);
            this.lblExpand.Name = "lblExpand";
            this.lblExpand.Size = new System.Drawing.Size(53, 12);
            this.lblExpand.TabIndex = 3;
            this.lblExpand.TabStop = true;
            this.lblExpand.Text = "展开节点";
            this.lblExpand.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblExpand_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "成员(&M)";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.propertyGrid1);
            this.panel4.Controls.Add(this.btnCancle);
            this.panel4.Controls.Add(this.btnSure);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(277, 8);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(266, 411);
            this.panel4.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "属性(&P)：";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(2, 31);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(264, 340);
            this.propertyGrid1.TabIndex = 0;
            // 
            // btnCancle
            // 
            this.btnCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancle.Location = new System.Drawing.Point(178, 377);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(88, 28);
            this.btnCancle.TabIndex = 3;
            this.btnCancle.Text = "取消(&C)";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnSure
            // 
            this.btnSure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSure.Location = new System.Drawing.Point(84, 377);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(88, 28);
            this.btnSure.TabIndex = 2;
            this.btnSure.Text = "确定(&S)";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnDown);
            this.panel2.Controls.Add(this.btnUp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(234, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(43, 411);
            this.panel2.TabIndex = 7;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageIndex = 2;
            this.btnDelete.ImageList = this.imageList1;
            this.btnDelete.Location = new System.Drawing.Point(3, 95);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(30, 26);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDown
            // 
            this.btnDown.ImageIndex = 1;
            this.btnDown.ImageList = this.imageList1;
            this.btnDown.Location = new System.Drawing.Point(3, 63);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(30, 26);
            this.btnDown.TabIndex = 3;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.ImageIndex = 0;
            this.btnUp.ImageList = this.imageList1;
            this.btnUp.Location = new System.Drawing.Point(3, 31);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(30, 26);
            this.btnUp.TabIndex = 2;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Up10.png");
            this.imageList1.Images.SetKeyName(1, "Down10.png");
            this.imageList1.Images.SetKeyName(2, "delete22.png");
            this.imageList1.Images.SetKeyName(3, "delete22.png");
            this.imageList1.Images.SetKeyName(4, "delete22.png");
            this.imageList1.Images.SetKeyName(5, "Delete_black_32x32_2.png");
            // 
            // FrmTreeHeadColumnsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 427);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Name = "FrmTreeHeadColumnsEdit";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.ShowIcon = false;
            this.Text = "网格复杂表头编辑器";
            this.Load += new System.EventHandler(this.FrmTreeHeadColumnsEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private Huiting.Components.TreeViewByRightSelected treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddSub;
        private System.Windows.Forms.Button btnDelete2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.LinkLabel lblCollapse;
        private System.Windows.Forms.LinkLabel lblExpand;
        private System.Windows.Forms.ImageList imageList1;
    }
}