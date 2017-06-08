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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colInventoryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWareHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriginalThick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealThick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceRoll = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colSourceRollWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliverySheet = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col含税出单位成本 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col不含税出单位成本 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_CreateInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Check = new System.Windows.Forms.ToolStripMenuItem();
            this.折包ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更换仓库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cMnu_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
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
            this.colWareHouse,
            this.colCategory,
            this.colSpecification,
            this.colWeight,
            this.colLength,
            this.colOriginalThick,
            this.colRealThick,
            this.colCount,
            this.colCustomer,
            this.colSourceRoll,
            this.colSourceRollWeight,
            this.colDeliverySheet,
            this.col含税出单位成本,
            this.col不含税出单位成本,
            this.colMemo});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1341, 576);
            this.dataGridView1.TabIndex = 114;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // colInventoryDate
            // 
            this.colInventoryDate.HeaderText = "日期";
            this.colInventoryDate.Name = "colInventoryDate";
            this.colInventoryDate.ReadOnly = true;
            // 
            // colWareHouse
            // 
            this.colWareHouse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colWareHouse.HeaderText = "仓库";
            this.colWareHouse.Name = "colWareHouse";
            this.colWareHouse.ReadOnly = true;
            this.colWareHouse.Width = 51;
            // 
            // colCategory
            // 
            this.colCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colCategory.HeaderText = "类别";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 51;
            // 
            // colSpecification
            // 
            this.colSpecification.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSpecification.HeaderText = "规格";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            this.colSpecification.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSpecification.Width = 32;
            // 
            // colWeight
            // 
            dataGridViewCellStyle9.Format = "N3";
            dataGridViewCellStyle9.NullValue = null;
            this.colWeight.DefaultCellStyle = dataGridViewCellStyle9;
            this.colWeight.HeaderText = "重量(吨)";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            this.colWeight.Width = 80;
            // 
            // colLength
            // 
            dataGridViewCellStyle10.Format = "N3";
            dataGridViewCellStyle10.NullValue = null;
            this.colLength.DefaultCellStyle = dataGridViewCellStyle10;
            this.colLength.HeaderText = "长度(米)";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.Width = 80;
            // 
            // colOriginalThick
            // 
            dataGridViewCellStyle11.Format = "N3";
            this.colOriginalThick.DefaultCellStyle = dataGridViewCellStyle11;
            this.colOriginalThick.HeaderText = "入库厚度";
            this.colOriginalThick.Name = "colOriginalThick";
            this.colOriginalThick.ReadOnly = true;
            this.colOriginalThick.Width = 80;
            // 
            // colRealThick
            // 
            dataGridViewCellStyle12.Format = "N3";
            dataGridViewCellStyle12.NullValue = null;
            this.colRealThick.DefaultCellStyle = dataGridViewCellStyle12;
            this.colRealThick.HeaderText = "开平厚度";
            this.colRealThick.Name = "colRealThick";
            this.colRealThick.ReadOnly = true;
            this.colRealThick.Width = 80;
            // 
            // colCount
            // 
            dataGridViewCellStyle13.Format = "N0";
            dataGridViewCellStyle13.NullValue = "?";
            this.colCount.DefaultCellStyle = dataGridViewCellStyle13;
            this.colCount.HeaderText = "数量";
            this.colCount.Name = "colCount";
            this.colCount.ReadOnly = true;
            this.colCount.Width = 80;
            // 
            // colCustomer
            // 
            this.colCustomer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colCustomer.HeaderText = "客户";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.Width = 51;
            // 
            // colSourceRoll
            // 
            this.colSourceRoll.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSourceRoll.HeaderText = "来源卷";
            this.colSourceRoll.Name = "colSourceRoll";
            this.colSourceRoll.ReadOnly = true;
            this.colSourceRoll.Width = 42;
            // 
            // colSourceRollWeight
            // 
            dataGridViewCellStyle14.Format = "N3";
            this.colSourceRollWeight.DefaultCellStyle = dataGridViewCellStyle14;
            this.colSourceRollWeight.HeaderText = "来源卷重";
            this.colSourceRollWeight.Name = "colSourceRollWeight";
            this.colSourceRollWeight.ReadOnly = true;
            this.colSourceRollWeight.Width = 80;
            // 
            // colDeliverySheet
            // 
            this.colDeliverySheet.HeaderText = "送货单";
            this.colDeliverySheet.Name = "colDeliverySheet";
            this.colDeliverySheet.ReadOnly = true;
            this.colDeliverySheet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDeliverySheet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col含税出单位成本
            // 
            dataGridViewCellStyle15.Format = "C2";
            this.col含税出单位成本.DefaultCellStyle = dataGridViewCellStyle15;
            this.col含税出单位成本.HeaderText = "含税出单位成本";
            this.col含税出单位成本.Name = "col含税出单位成本";
            this.col含税出单位成本.ReadOnly = true;
            this.col含税出单位成本.Width = 80;
            // 
            // col不含税出单位成本
            // 
            dataGridViewCellStyle16.Format = "C2";
            this.col不含税出单位成本.DefaultCellStyle = dataGridViewCellStyle16;
            this.col不含税出单位成本.HeaderText = "不含税出单位成本";
            this.col不含税出单位成本.Name = "col不含税出单位成本";
            this.col不含税出单位成本.ReadOnly = true;
            this.col不含税出单位成本.Width = 80;
            // 
            // colMemo
            // 
            this.colMemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            this.colMemo.Width = 51;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_CreateInventory,
            this.mnu_Check,
            this.折包ToolStripMenuItem,
            this.更换仓库ToolStripMenuItem,
            this.toolStripSeparator3,
            this.cMnu_SelectColumns,
            this.cMnu_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 142);
            // 
            // mnu_CreateInventory
            // 
            this.mnu_CreateInventory.Name = "mnu_CreateInventory";
            this.mnu_CreateInventory.Size = new System.Drawing.Size(152, 22);
            this.mnu_CreateInventory.Text = "新建库存";
            this.mnu_CreateInventory.Click += new System.EventHandler(this.mnu_CreateInventory_Click);
            // 
            // mnu_Check
            // 
            this.mnu_Check.Name = "mnu_Check";
            this.mnu_Check.Size = new System.Drawing.Size(152, 22);
            this.mnu_Check.Text = "盘点";
            this.mnu_Check.Click += new System.EventHandler(this.mnu_Check_Click);
            // 
            // 折包ToolStripMenuItem
            // 
            this.折包ToolStripMenuItem.Name = "折包ToolStripMenuItem";
            this.折包ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.折包ToolStripMenuItem.Text = "拆包";
            this.折包ToolStripMenuItem.Click += new System.EventHandler(this.折包ToolStripMenuItem_Click);
            // 
            // 更换仓库ToolStripMenuItem
            // 
            this.更换仓库ToolStripMenuItem.Name = "更换仓库ToolStripMenuItem";
            this.更换仓库ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.更换仓库ToolStripMenuItem.Text = "更换仓库";
            this.更换仓库ToolStripMenuItem.Click += new System.EventHandler(this.更换仓库ToolStripMenuItem_Click);
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
            // FrmSteelRollSliceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 598);
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
        private System.Windows.Forms.ToolStripMenuItem mnu_Check;
        private System.Windows.Forms.ToolStripMenuItem mnu_CreateInventory;
        private System.Windows.Forms.ToolStripMenuItem 折包ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更换仓库ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInventoryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWareHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriginalThick;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealThick;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewLinkColumn colSourceRoll;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceRollWeight;
        private System.Windows.Forms.DataGridViewLinkColumn colDeliverySheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn col含税出单位成本;
        private System.Windows.Forms.DataGridViewTextBoxColumn col不含税出单位成本;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;

    }
}