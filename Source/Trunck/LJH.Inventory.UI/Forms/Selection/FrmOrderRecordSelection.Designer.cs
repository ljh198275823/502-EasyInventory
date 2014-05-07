namespace LJH.Inventory.UI.Forms
{
    partial class FrmOrderRecordSelection
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDemandDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrepared = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotPurchased = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderID,
            this.colProductName,
            this.colSpecification,
            this.colDemandDate,
            this.colCount,
            this.colPrepared,
            this.colNotPurchased,
            this.colMemo});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(804, 344);
            this.dataGridView1.TabIndex = 98;
            // 
            // colOrderID
            // 
            this.colOrderID.HeaderText = "合同编号";
            this.colOrderID.Name = "colOrderID";
            this.colOrderID.ReadOnly = true;
            this.colOrderID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOrderID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "商品";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colProductName.Width = 120;
            // 
            // colSpecification
            // 
            this.colSpecification.HeaderText = "规格";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            this.colSpecification.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSpecification.Visible = false;
            this.colSpecification.Width = 80;
            // 
            // colDemandDate
            // 
            this.colDemandDate.HeaderText = "出货日期";
            this.colDemandDate.Name = "colDemandDate";
            this.colDemandDate.ReadOnly = true;
            // 
            // colCount
            // 
            dataGridViewCellStyle1.NullValue = "0";
            this.colCount.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCount.HeaderText = "合同数量";
            this.colCount.Name = "colCount";
            this.colCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCount.Width = 80;
            // 
            // colPrepared
            // 
            this.colPrepared.HeaderText = "已备货";
            this.colPrepared.Name = "colPrepared";
            this.colPrepared.ReadOnly = true;
            // 
            // colNotPurchased
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colNotPurchased.DefaultCellStyle = dataGridViewCellStyle2;
            this.colNotPurchased.HeaderText = "还需采购";
            this.colNotPurchased.Name = "colNotPurchased";
            this.colNotPurchased.ReadOnly = true;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            this.colMemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMemo.Width = 200;
            // 
            // FrmOrderRecordSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 366);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmOrderRecordSelection";
            this.Text = "选择销售订单项";
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDemandDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrepared;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotPurchased;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
    }
}