namespace Huiting.DataEditor.ExcelHelper
{
    partial class ExcelFiledMappingConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelFiledMappingConfig));
            this.btn_AutoPP = new System.Windows.Forms.Button();
            this.num_ColumnRowsCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comb_Sheets = new System.Windows.Forms.ComboBox();
            this.tabControlEx1 = new BDSoft.Components.RoundedTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView_FieldList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_ColumnRowsCount)).BeginInit();
            this.tabControlEx1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_AutoPP
            // 
            this.btn_AutoPP.Location = new System.Drawing.Point(412, 4);
            this.btn_AutoPP.Name = "btn_AutoPP";
            this.btn_AutoPP.Size = new System.Drawing.Size(75, 23);
            this.btn_AutoPP.TabIndex = 11;
            this.btn_AutoPP.Text = "自动匹配";
            this.btn_AutoPP.UseVisualStyleBackColor = true;
            this.btn_AutoPP.Click += new System.EventHandler(this.btn_AutoPP_Click);
            // 
            // num_ColumnRowsCount
            // 
            this.num_ColumnRowsCount.Location = new System.Drawing.Point(336, 5);
            this.num_ColumnRowsCount.Name = "num_ColumnRowsCount";
            this.num_ColumnRowsCount.Size = new System.Drawing.Size(70, 21);
            this.num_ColumnRowsCount.TabIndex = 10;
            this.num_ColumnRowsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "表头所占行数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "选择sheet页：";
            // 
            // comb_Sheets
            // 
            this.comb_Sheets.FormattingEnabled = true;
            this.comb_Sheets.Location = new System.Drawing.Point(100, 6);
            this.comb_Sheets.Name = "comb_Sheets";
            this.comb_Sheets.Size = new System.Drawing.Size(121, 20);
            this.comb_Sheets.TabIndex = 7;
            // 
            // tabControlEx1
            // 
            this.tabControlEx1.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(79)))), ((int)(((byte)(125)))));
            this.tabControlEx1.BackColor = System.Drawing.Color.Transparent;
            this.tabControlEx1.BaseColor = System.Drawing.Color.White;
            this.tabControlEx1.Controls.Add(this.tabPage2);
            this.tabControlEx1.Location = new System.Drawing.Point(12, 33);
            this.tabControlEx1.Name = "tabControlEx1";
            this.tabControlEx1.SelectedIndex = 0;
            this.tabControlEx1.Size = new System.Drawing.Size(698, 368);
            this.tabControlEx1.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView_FieldList);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(690, 338);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "字段对应设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView_FieldList
            // 
            this.listView_FieldList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView_FieldList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_FieldList.FullRowSelect = true;
            this.listView_FieldList.Location = new System.Drawing.Point(3, 3);
            this.listView_FieldList.Name = "listView_FieldList";
            this.listView_FieldList.Size = new System.Drawing.Size(684, 332);
            this.listView_FieldList.SmallImageList = this.imageList1;
            this.listView_FieldList.TabIndex = 0;
            this.listView_FieldList.UseCompatibleStateImageBehavior = false;
            this.listView_FieldList.View = System.Windows.Forms.View.Details;
            this.listView_FieldList.SelectedIndexChanged += new System.EventHandler(this.listView_FieldList_SelectedIndexChanged);
            this.listView_FieldList.Click += new System.EventHandler(this.listView_FieldList_Click);
            this.listView_FieldList.DoubleClick += new System.EventHandler(this.listView_FieldList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "数据列名";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "匹配Excel列名";
            this.columnHeader3.Width = 260;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "当前文件数据单位";
            this.columnHeader4.Width = 120;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "diamonds_1.png");
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(282, 410);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 13;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(363, 410);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 14;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(19, 408);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "附：红色项必须设置对应关系";
            // 
            // ExcelFiledMappingConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(721, 456);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.tabControlEx1);
            this.Controls.Add(this.btn_AutoPP);
            this.Controls.Add(this.num_ColumnRowsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comb_Sheets);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExcelFiledMappingConfig";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "字段映射配置";
            this.Shown += new System.EventHandler(this.ExcelFiledMappingConfig_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.num_ColumnRowsCount)).EndInit();
            this.tabControlEx1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_AutoPP;
        private System.Windows.Forms.NumericUpDown num_ColumnRowsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comb_Sheets;
        private BDSoft.Components.RoundedTabControl tabControlEx1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ListView listView_FieldList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label3;
    }
}