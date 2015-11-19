namespace LJH.Inventory.UI.Forms.Inventory.View
{
    partial class FrmSteelRollSliceView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colInventoryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealThick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInventorySheet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliverySheet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_Check = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_UnReserve = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cMnu_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_CreateInventory = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.colCategory,
            this.colSpecification,
            this.colWeight,
            this.colLength,
            this.colRealThick,
            this.colCount,
            this.colCustomer,
            this.colInventorySheet,
            this.colOrderID,
            this.colDeliverySheet,
            this.colMemo});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1160, 347);
            this.dataGridView1.TabIndex = 114;
            // 
            // colInventoryDate
            // 
            this.colInventoryDate.HeaderText = "日期";
            this.colInventoryDate.Name = "colInventoryDate";
            this.colInventoryDate.ReadOnly = true;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "类别";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            // 
            // colSpecification
            // 
            this.colSpecification.HeaderText = "规格";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            this.colSpecification.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colWeight
            // 
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            this.colWeight.DefaultCellStyle = dataGridViewCellStyle1;
            this.colWeight.HeaderText = "重量(吨)";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            // 
            // colLength
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colLength.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLength.HeaderText = "长度(米)";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            // 
            // colRealThick
            // 
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.colRealThick.DefaultCellStyle = dataGridViewCellStyle3;
            this.colRealThick.HeaderText = "厚度";
            this.colRealThick.Name = "colRealThick";
            this.colRealThick.ReadOnly = true;
            // 
            // colCount
            // 
            this.colCount.HeaderText = "数量";
            this.colCount.Name = "colCount";
            this.colCount.ReadOnly = true;
            // 
            // colCustomer
            // 
            this.colCustomer.HeaderText = "客户";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            // 
            // colInventorySheet
            // 
            this.colInventorySheet.HeaderText = "入库单";
            this.colInventorySheet.Name = "colInventorySheet";
            this.colInventorySheet.ReadOnly = true;
            this.colInventorySheet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInventorySheet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colOrderID
            // 
            this.colOrderID.HeaderText = "订单";
            this.colOrderID.Name = "colOrderID";
            this.colOrderID.ReadOnly = true;
            this.colOrderID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOrderID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colOrderID.Visible = false;
            // 
            // colDeliverySheet
            // 
            this.colDeliverySheet.HeaderText = "送货单";
            this.colDeliverySheet.Name = "colDeliverySheet";
            this.colDeliverySheet.ReadOnly = true;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            this.colMemo.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_CreateInventory,
            this.mnu_Check,
            this.mnu_UnReserve,
            this.toolStripSeparator3,
            this.cMnu_SelectColumns,
            this.cMnu_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 142);
            // 
            // mnu_Check
            // 
            this.mnu_Check.Name = "mnu_Check";
            this.mnu_Check.Size = new System.Drawing.Size(152, 22);
            this.mnu_Check.Text = "盘点";
            this.mnu_Check.Click += new System.EventHandler(this.mnu_Check_Click);
            // 
            // mnu_UnReserve
            // 
            this.mnu_UnReserve.Name = "mnu_UnReserve";
            this.mnu_UnReserve.Size = new System.Drawing.Size(152, 22);
            this.mnu_UnReserve.Text = "取消订单备货";
            this.mnu_UnReserve.Click += new System.EventHandler(this.mnu_UnReserve_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // cMnu_SelectColumns
            // 
            this.cMnu_SelectColumns.Name = "cMnu_SelectColumns";
            this.cMnu_SelectColumns.Size = new System.Drawing.Size(152, 22);
            this.cMnu_SelectColumns.Text = "选择列...";
            // 
            // cMnu_Export
            // 
            this.cMnu_Export.Name = "cMnu_Export";
            this.cMnu_Export.Size = new System.Drawing.Size(152, 22);
            this.cMnu_Export.Text = "导出...";
            // 
            // mnu_CreateInventory
            // 
            this.mnu_CreateInventory.Name = "mnu_CreateInventory";
            this.mnu_CreateInventory.Size = new System.Drawing.Size(152, 22);
            this.mnu_CreateInventory.Text = "新建库存";
            this.mnu_CreateInventory.Click += new System.EventHandler(this.mnu_CreateInventory_Click);
            // 
            // FrmSteelRollSliceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 369);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmSteelRollSliceView";
            this.Text = "小件库存明细";
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cMnu_SelectColumns;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
        private System.Windows.Forms.ToolStripMenuItem mnu_UnReserve;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInventoryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealThick;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInventorySheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliverySheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        private System.Windows.Forms.ToolStripMenuItem mnu_Check;
        private System.Windows.Forms.ToolStripMenuItem mnu_CreateInventory;

    }
}