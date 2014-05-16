namespace LJH.Inventory.UI.Forms.Inventory.View
{
    partial class FrmProductInventoryItemView
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtKeyword = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.colInventoryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInventorySheet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReserved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliverySheet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.pnlFilter.SuspendLayout();
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
            this.colInventoryDate,
            this.colInventorySheet,
            this.colProductID,
            this.colProductName,
            this.colSpecification,
            this.colCount,
            this.colReserved,
            this.colDeliverySheet});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(821, 309);
            this.dataGridView1.TabIndex = 114;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtKeyword);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(821, 38);
            this.panel5.TabIndex = 7;
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyword.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtKeyword.Location = new System.Drawing.Point(71, 7);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(738, 21);
            this.txtKeyword.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "模糊匹配";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.panel5);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(821, 38);
            this.pnlFilter.TabIndex = 113;
            // 
            // colInventoryDate
            // 
            this.colInventoryDate.HeaderText = "入货日期";
            this.colInventoryDate.Name = "colInventoryDate";
            this.colInventoryDate.ReadOnly = true;
            // 
            // colInventorySheet
            // 
            this.colInventorySheet.HeaderText = "入库单号";
            this.colInventorySheet.Name = "colInventorySheet";
            this.colInventorySheet.ReadOnly = true;
            this.colInventorySheet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInventorySheet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colProductID
            // 
            this.colProductID.HeaderText = "产品编号";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.Width = 80;
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "名称";
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
            // 
            // colCount
            // 
            this.colCount.HeaderText = "数量";
            this.colCount.Name = "colCount";
            this.colCount.ReadOnly = true;
            // 
            // colReserved
            // 
            this.colReserved.HeaderText = "订单编号";
            this.colReserved.Name = "colReserved";
            this.colReserved.ReadOnly = true;
            this.colReserved.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colReserved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDeliverySheet
            // 
            this.colDeliverySheet.HeaderText = "送货单";
            this.colDeliverySheet.Name = "colDeliverySheet";
            this.colDeliverySheet.ReadOnly = true;
            // 
            // FrmProductInventoryItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 369);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnlFilter);
            this.Name = "FrmProductInventoryItemView";
            this.Text = "产品库存明细";
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel5;
        private GeneralLibrary.WinformControl.DBCTextBox txtKeyword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInventoryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInventorySheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReserved;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliverySheet;

    }
}