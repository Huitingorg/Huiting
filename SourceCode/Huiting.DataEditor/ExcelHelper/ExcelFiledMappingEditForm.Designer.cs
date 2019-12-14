namespace Huiting.DataEditor.ExcelHelper
{
    partial class ExcelFiledMappingEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelFiledMappingEditForm));
            this.tree_ExcelColumn = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_CancelMapping = new System.Windows.Forms.Button();
            this.UC_UnitSel = new Controls.UC_DataUnitSel();
            this.SuspendLayout();
            // 
            // tree_ExcelColumn
            // 
            this.tree_ExcelColumn.ImageIndex = 0;
            this.tree_ExcelColumn.ImageList = this.imageList1;
            this.tree_ExcelColumn.ItemHeight = 20;
            this.tree_ExcelColumn.Location = new System.Drawing.Point(13, 13);
            this.tree_ExcelColumn.Name = "tree_ExcelColumn";
            this.tree_ExcelColumn.SelectedImageIndex = 0;
            this.tree_ExcelColumn.Size = new System.Drawing.Size(460, 385);
            this.tree_ExcelColumn.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "table_rotate_16px_1086854_easyicon.net.png");
            this.imageList1.Images.SetKeyName(1, "项目2.bmp");
            this.imageList1.Images.SetKeyName(2, "green_marker_rounded_yellow_16px_2571_easyicon.net.png");
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(149, 427);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 15;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(230, 427);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 16;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_CancelMapping
            // 
            this.btn_CancelMapping.Location = new System.Drawing.Point(397, 404);
            this.btn_CancelMapping.Name = "btn_CancelMapping";
            this.btn_CancelMapping.Size = new System.Drawing.Size(75, 23);
            this.btn_CancelMapping.TabIndex = 15;
            this.btn_CancelMapping.Text = "清除定义";
            this.btn_CancelMapping.UseVisualStyleBackColor = true;
            this.btn_CancelMapping.Click += new System.EventHandler(this.btn_CancelMapping_Click);
            // 
            // UC_UnitSel
            // 
            this.UC_UnitSel.BackColor = System.Drawing.Color.White;
            this.UC_UnitSel.Location = new System.Drawing.Point(10, 395);
            this.UC_UnitSel.Name = "UC_UnitSel";
            this.UC_UnitSel.SelUnit = "";
            this.UC_UnitSel.Size = new System.Drawing.Size(401, 26);
            this.UC_UnitSel.TabIndex = 17;
            this.UC_UnitSel.UnitStrList = "";
            // 
            // ExcelFiledMappingEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 475);
            this.Controls.Add(this.btn_CancelMapping);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.tree_ExcelColumn);
            this.Controls.Add(this.UC_UnitSel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExcelFiledMappingEditForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "字段映射选择";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tree_ExcelColumn;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ImageList imageList1;
        private Controls.UC_DataUnitSel UC_UnitSel;
        private System.Windows.Forms.Button btn_CancelMapping;
    }
}