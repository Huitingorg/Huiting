namespace ReserveAnalysis
{
    partial class FrmDecSegment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDec = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.index2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ksrq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cscl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mqcl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zzrq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jdsykccl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yczqljcl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zzkccl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDec)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDec
            // 
            this.dgvDec.AllowUserToAddRows = false;
            this.dgvDec.AllowUserToDeleteRows = false;
            this.dgvDec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDec.BackgroundColor = System.Drawing.Color.White;
            this.dgvDec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDec.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.unit,
            this.type2,
            this.index2,
            this.dec,
            this.ksrq,
            this.cscl,
            this.mqcl,
            this.zzrq,
            this.endDec,
            this.jdsykccl,
            this.yczqljcl,
            this.zzkccl});
            this.dgvDec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDec.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDec.EnableHeadersVisualStyles = false;
            this.dgvDec.Location = new System.Drawing.Point(0, 0);
            this.dgvDec.Name = "dgvDec";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvDec.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDec.RowTemplate.Height = 17;
            this.dgvDec.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDec.Size = new System.Drawing.Size(1037, 180);
            this.dgvDec.TabIndex = 10;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.name.DataPropertyName = "name";
            this.name.Frozen = true;
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // unit
            // 
            this.unit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.unit.Frozen = true;
            this.unit.HeaderText = "单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Visible = false;
            // 
            // type2
            // 
            this.type2.DataPropertyName = "type2";
            this.type2.HeaderText = "拟合曲线类型";
            this.type2.Name = "type2";
            this.type2.ReadOnly = true;
            // 
            // index2
            // 
            this.index2.DataPropertyName = "index2";
            this.index2.HeaderText = "双曲指数";
            this.index2.Name = "index2";
            this.index2.ReadOnly = true;
            // 
            // dec
            // 
            this.dec.DataPropertyName = "dec";
            this.dec.HeaderText = "初始递减率";
            this.dec.Name = "dec";
            this.dec.ReadOnly = true;
            // 
            // ksrq
            // 
            this.ksrq.DataPropertyName = "ksrq";
            this.ksrq.HeaderText = "开始日期";
            this.ksrq.Name = "ksrq";
            this.ksrq.ReadOnly = true;
            // 
            // cscl
            // 
            this.cscl.DataPropertyName = "cscl";
            this.cscl.HeaderText = "初始产量(吨)";
            this.cscl.Name = "cscl";
            this.cscl.ReadOnly = true;
            // 
            // mqcl
            // 
            this.mqcl.DataPropertyName = "mqcl";
            this.mqcl.HeaderText = "末期产量(吨)";
            this.mqcl.Name = "mqcl";
            this.mqcl.ReadOnly = true;
            // 
            // zzrq
            // 
            this.zzrq.DataPropertyName = "zzrq";
            this.zzrq.HeaderText = "终止日期";
            this.zzrq.Name = "zzrq";
            this.zzrq.ReadOnly = true;
            // 
            // endDec
            // 
            this.endDec.HeaderText = "末期递减率";
            this.endDec.Name = "endDec";
            this.endDec.ReadOnly = true;
            this.endDec.Visible = false;
            // 
            // jdsykccl
            // 
            this.jdsykccl.DataPropertyName = "jdsykccl";
            this.jdsykccl.HeaderText = "阶段剩余可采储量(万吨)";
            this.jdsykccl.Name = "jdsykccl";
            this.jdsykccl.ReadOnly = true;
            // 
            // yczqljcl
            // 
            this.yczqljcl.DataPropertyName = "yczqljcl";
            this.yczqljcl.HeaderText = "预测之前的累计产油量(万吨)";
            this.yczqljcl.Name = "yczqljcl";
            this.yczqljcl.ReadOnly = true;
            // 
            // zzkccl
            // 
            this.zzkccl.DataPropertyName = "zzkccl";
            this.zzkccl.HeaderText = "最终可采储量(万吨)";
            this.zzkccl.Name = "zzkccl";
            this.zzkccl.ReadOnly = true;
            // 
            // FrmDecSegment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 180);
            this.Controls.Add(this.dgvDec);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmDecSegment";
            this.Text = "递减段信息";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDec)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDec;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn type2;
        private System.Windows.Forms.DataGridViewTextBoxColumn index2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ksrq;
        private System.Windows.Forms.DataGridViewTextBoxColumn cscl;
        private System.Windows.Forms.DataGridViewTextBoxColumn mqcl;
        private System.Windows.Forms.DataGridViewTextBoxColumn zzrq;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDec;
        private System.Windows.Forms.DataGridViewTextBoxColumn jdsykccl;
        private System.Windows.Forms.DataGridViewTextBoxColumn yczqljcl;
        private System.Windows.Forms.DataGridViewTextBoxColumn zzkccl;
    }
}