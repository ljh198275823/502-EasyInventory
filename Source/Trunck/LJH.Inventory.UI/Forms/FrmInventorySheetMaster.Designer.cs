namespace LJH.Inventory.UI.Forms
{
    partial class FrmInventorySheetMaster
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.btn_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Cancel = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtKeyword = new LJH.Inventory.UI.Controls.TooStripDBCTextBox(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnCanceled = new System.Windows.Forms.Button();
            this.btnClosed = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSheetNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colWareHouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsWithTax = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInventoryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInventoryOperator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menu.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.menu.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Add,
            this.btn_Cancel,
            this.btn_Export,
            this.btn_Fresh,
            this.btn_SelectColumns,
            this.toolStripSeparator1,
            this.txtKeyword,
            this.toolStripSeparator2});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1197, 50);
            this.menu.TabIndex = 26;
            // 
            // btn_Add
            // 
            this.btn_Add.Image = global::LJH.Inventory.UI.Properties.Resources.add;
            this.btn_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(62, 46);
            this.btn_Add.Text = "新建(&N)";
            this.btn_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Image = global::LJH.Inventory.UI.Properties.Resources.delete;
            this.btn_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(60, 46);
            this.btn_Cancel.Text = "取消(&C)";
            this.btn_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Cancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.Image = global::LJH.Inventory.UI.Properties.Resources.export;
            this.btn_Export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(59, 46);
            this.btn_Export.Text = "导出(&E)";
            this.btn_Export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btn_Fresh
            // 
            this.btn_Fresh.Image = global::LJH.Inventory.UI.Properties.Resources.refresh;
            this.btn_Fresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Fresh.Name = "btn_Fresh";
            this.btn_Fresh.Size = new System.Drawing.Size(58, 46);
            this.btn_Fresh.Text = "刷新(&F)";
            this.btn_Fresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btn_SelectColumns
            // 
            this.btn_SelectColumns.Image = global::LJH.Inventory.UI.Properties.Resources.columns;
            this.btn_SelectColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_SelectColumns.Name = "btn_SelectColumns";
            this.btn_SelectColumns.Size = new System.Drawing.Size(70, 46);
            this.btn_SelectColumns.Text = "选择列(&L)";
            this.btn_SelectColumns.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // txtKeyword
            // 
            this.txtKeyword.AutoSize = false;
            this.txtKeyword.Margin = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(200, 30);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 46);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitter1.Location = new System.Drawing.Point(200, 50);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 302);
            this.splitter1.TabIndex = 108;
            this.splitter1.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.btnCanceled);
            this.pnlLeft.Controls.Add(this.btnClosed);
            this.pnlLeft.Controls.Add(this.btnInventory);
            this.pnlLeft.Controls.Add(this.btnApprove);
            this.pnlLeft.Controls.Add(this.btnAdd);
            this.pnlLeft.Controls.Add(this.btnAll);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 50);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(200, 302);
            this.pnlLeft.TabIndex = 107;
            // 
            // btnCanceled
            // 
            this.btnCanceled.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCanceled.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCanceled.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCanceled.ForeColor = System.Drawing.Color.Black;
            this.btnCanceled.Location = new System.Drawing.Point(0, 210);
            this.btnCanceled.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnCanceled.Name = "btnCanceled";
            this.btnCanceled.Size = new System.Drawing.Size(200, 42);
            this.btnCanceled.TabIndex = 25;
            this.btnCanceled.Text = "作废";
            this.btnCanceled.UseVisualStyleBackColor = true;
            // 
            // btnClosed
            // 
            this.btnClosed.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClosed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClosed.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClosed.ForeColor = System.Drawing.Color.Black;
            this.btnClosed.Location = new System.Drawing.Point(0, 168);
            this.btnClosed.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(200, 42);
            this.btnClosed.TabIndex = 24;
            this.btnClosed.Text = "关闭";
            this.btnClosed.UseVisualStyleBackColor = true;
            // 
            // btnInventory
            // 
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInventory.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInventory.ForeColor = System.Drawing.Color.Black;
            this.btnInventory.Location = new System.Drawing.Point(0, 126);
            this.btnInventory.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(200, 42);
            this.btnInventory.TabIndex = 23;
            this.btnInventory.Text = "收货";
            this.btnInventory.UseVisualStyleBackColor = true;
            // 
            // btnApprove
            // 
            this.btnApprove.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnApprove.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApprove.Location = new System.Drawing.Point(0, 84);
            this.btnApprove.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(200, 42);
            this.btnApprove.TabIndex = 20;
            this.btnApprove.Text = "审核";
            this.btnApprove.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(0, 42);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(200, 42);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "新建";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnAll
            // 
            this.btnAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAll.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAll.Location = new System.Drawing.Point(0, 0);
            this.btnAll.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(200, 42);
            this.btnAll.TabIndex = 11;
            this.btnAll.Text = "全部";
            this.btnAll.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSheetNo,
            this.colSupplier,
            this.colWareHouseName,
            this.colIsWithTax,
            this.colAmount,
            this.colState,
            this.colInventoryDate,
            this.colInventoryOperator,
            this.colMemo});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(208, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(989, 302);
            this.dataGridView1.TabIndex = 109;
            // 
            // colSheetNo
            // 
            this.colSheetNo.HeaderText = "收货单号";
            this.colSheetNo.Name = "colSheetNo";
            this.colSheetNo.ReadOnly = true;
            this.colSheetNo.Width = 80;
            // 
            // colSupplier
            // 
            this.colSupplier.HeaderText = "供应商";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.ReadOnly = true;
            this.colSupplier.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSupplier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSupplier.Width = 150;
            // 
            // colWareHouseName
            // 
            this.colWareHouseName.HeaderText = "仓库";
            this.colWareHouseName.Name = "colWareHouseName";
            this.colWareHouseName.ReadOnly = true;
            // 
            // colIsWithTax
            // 
            this.colIsWithTax.HeaderText = "含税";
            this.colIsWithTax.Name = "colIsWithTax";
            this.colIsWithTax.ReadOnly = true;
            this.colIsWithTax.Width = 40;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "金额";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colState
            // 
            this.colState.HeaderText = "状态";
            this.colState.Name = "colState";
            this.colState.ReadOnly = true;
            this.colState.Width = 60;
            // 
            // colInventoryDate
            // 
            dataGridViewCellStyle1.Format = "D";
            dataGridViewCellStyle1.NullValue = null;
            this.colInventoryDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colInventoryDate.HeaderText = "收货日期";
            this.colInventoryDate.Name = "colInventoryDate";
            this.colInventoryDate.ReadOnly = true;
            // 
            // colInventoryOperator
            // 
            this.colInventoryOperator.HeaderText = "收货人员";
            this.colInventoryOperator.Name = "colInventoryOperator";
            this.colInventoryOperator.ReadOnly = true;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            // 
            // FrmInventorySheetMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1197, 374);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.menu);
            this.Name = "FrmInventorySheetMaster";
            this.Text = "收货单资料";
            this.Controls.SetChildIndex(this.menu, 0);
            this.Controls.SetChildIndex(this.pnlLeft, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem btn_Add;
        private System.Windows.Forms.ToolStripMenuItem btn_Cancel;
        private System.Windows.Forms.ToolStripMenuItem btn_Export;
        private System.Windows.Forms.ToolStripMenuItem btn_Fresh;
        private System.Windows.Forms.ToolStripMenuItem btn_SelectColumns;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private LJH.Inventory.UI.Controls.TooStripDBCTextBox txtKeyword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Button btnCanceled;
        private System.Windows.Forms.Button btnClosed;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSheetNo;
        private System.Windows.Forms.DataGridViewLinkColumn colSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWareHouseName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsWithTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInventoryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInventoryOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
    }
}