namespace LJH.Inventory.UI.Forms
{
    partial class FrmPurchaseRecordMaster
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
            this.btn_WaitPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtKeyword = new LJH.Inventory.UI.Controls.TooStripDBCTextBox(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnReceivedAll = new System.Windows.Forms.Button();
            this.btnOverDate = new System.Windows.Forms.Button();
            this.btnAlert = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSheetNo = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDemandDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMissing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuyer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.menu.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Add,
            this.btn_WaitPurchase,
            this.btnCancel,
            this.btn_Export,
            this.btn_Fresh,
            this.btn_SelectColumns,
            this.toolStripSeparator1,
            this.txtKeyword,
            this.toolStripSeparator2});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(892, 50);
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
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_WaitPurchase
            // 
            this.btn_WaitPurchase.Image = global::LJH.Inventory.UI.Properties.Resources.refresh;
            this.btn_WaitPurchase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_WaitPurchase.Name = "btn_WaitPurchase";
            this.btn_WaitPurchase.Size = new System.Drawing.Size(76, 46);
            this.btn_WaitPurchase.Text = "待采购(&W)";
            this.btn_WaitPurchase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_WaitPurchase.Click += new System.EventHandler(this.btn_WaitPurchase_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::LJH.Inventory.UI.Properties.Resources.delete;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 46);
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            this.splitter1.Size = new System.Drawing.Size(8, 280);
            this.splitter1.TabIndex = 106;
            this.splitter1.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.btnReceivedAll);
            this.pnlLeft.Controls.Add(this.btnOverDate);
            this.pnlLeft.Controls.Add(this.btnAlert);
            this.pnlLeft.Controls.Add(this.btnNormal);
            this.pnlLeft.Controls.Add(this.btnAll);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 50);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(200, 280);
            this.pnlLeft.TabIndex = 105;
            // 
            // btnReceivedAll
            // 
            this.btnReceivedAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReceivedAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReceivedAll.ForeColor = System.Drawing.Color.Blue;
            this.btnReceivedAll.Location = new System.Drawing.Point(0, 168);
            this.btnReceivedAll.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnReceivedAll.Name = "btnReceivedAll";
            this.btnReceivedAll.Size = new System.Drawing.Size(200, 42);
            this.btnReceivedAll.TabIndex = 15;
            this.btnReceivedAll.Text = "已全部到货项";
            this.btnReceivedAll.UseVisualStyleBackColor = true;
            // 
            // btnOverDate
            // 
            this.btnOverDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOverDate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOverDate.ForeColor = System.Drawing.Color.Red;
            this.btnOverDate.Location = new System.Drawing.Point(0, 126);
            this.btnOverDate.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnOverDate.Name = "btnOverDate";
            this.btnOverDate.Size = new System.Drawing.Size(200, 42);
            this.btnOverDate.TabIndex = 14;
            this.btnOverDate.Text = "逾期未到货项";
            this.btnOverDate.UseVisualStyleBackColor = true;
            // 
            // btnAlert
            // 
            this.btnAlert.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAlert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAlert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAlert.Location = new System.Drawing.Point(0, 84);
            this.btnAlert.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnAlert.Name = "btnAlert";
            this.btnAlert.Size = new System.Drawing.Size(200, 42);
            this.btnAlert.TabIndex = 13;
            this.btnAlert.Text = "即将交货采购项";
            this.btnAlert.UseVisualStyleBackColor = true;
            // 
            // btnNormal
            // 
            this.btnNormal.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNormal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNormal.Location = new System.Drawing.Point(0, 42);
            this.btnNormal.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(200, 42);
            this.btnNormal.TabIndex = 12;
            this.btnNormal.Text = "非紧急采购项";
            this.btnNormal.UseVisualStyleBackColor = true;
            // 
            // btnAll
            // 
            this.btnAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
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
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSheetNo,
            this.colProduct,
            this.colSpecification,
            this.colDemandDate,
            this.colCount,
            this.colReceived,
            this.colMissing,
            this.colBuyer,
            this.colMemo});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(208, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(684, 280);
            this.dataGridView1.TabIndex = 107;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colSheetNo
            // 
            this.colSheetNo.HeaderText = "合同编号";
            this.colSheetNo.Name = "colSheetNo";
            this.colSheetNo.ReadOnly = true;
            this.colSheetNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSheetNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colProduct
            // 
            this.colProduct.HeaderText = "商品";
            this.colProduct.Name = "colProduct";
            this.colProduct.ReadOnly = true;
            this.colProduct.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colProduct.Width = 120;
            // 
            // colSpecification
            // 
            this.colSpecification.HeaderText = "规格";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            this.colSpecification.Width = 80;
            // 
            // colDemandDate
            // 
            this.colDemandDate.HeaderText = "到货日期";
            this.colDemandDate.Name = "colDemandDate";
            this.colDemandDate.ReadOnly = true;
            // 
            // colCount
            // 
            dataGridViewCellStyle1.NullValue = "0";
            this.colCount.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCount.HeaderText = "采购数量";
            this.colCount.Name = "colCount";
            this.colCount.Width = 80;
            // 
            // colReceived
            // 
            this.colReceived.HeaderText = "已到货数";
            this.colReceived.Name = "colReceived";
            this.colReceived.ReadOnly = true;
            // 
            // colMissing
            // 
            this.colMissing.HeaderText = "采购在途";
            this.colMissing.Name = "colMissing";
            this.colMissing.ReadOnly = true;
            // 
            // colBuyer
            // 
            this.colBuyer.HeaderText = "采购";
            this.colBuyer.Name = "colBuyer";
            this.colBuyer.ReadOnly = true;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            this.colMemo.Width = 200;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMnu_Fresh,
            this.cMnu_Add,
            this.cMnu_Delete,
            this.cMnu_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(110, 92);
            // 
            // cMnu_Fresh
            // 
            this.cMnu_Fresh.Name = "cMnu_Fresh";
            this.cMnu_Fresh.Size = new System.Drawing.Size(109, 22);
            this.cMnu_Fresh.Text = "刷新";
            // 
            // cMnu_Add
            // 
            this.cMnu_Add.Name = "cMnu_Add";
            this.cMnu_Add.Size = new System.Drawing.Size(109, 22);
            this.cMnu_Add.Text = "新建";
            // 
            // cMnu_Delete
            // 
            this.cMnu_Delete.Name = "cMnu_Delete";
            this.cMnu_Delete.Size = new System.Drawing.Size(109, 22);
            this.cMnu_Delete.Text = "删除";
            // 
            // cMnu_Export
            // 
            this.cMnu_Export.Name = "cMnu_Export";
            this.cMnu_Export.Size = new System.Drawing.Size(109, 22);
            this.cMnu_Export.Text = "导出...";
            // 
            // FrmPurchaseRecordMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 352);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.menu);
            this.Name = "FrmPurchaseRecordMaster";
            this.Text = "采购订单跟踪管理";
            this.Controls.SetChildIndex(this.menu, 0);
            this.Controls.SetChildIndex(this.pnlLeft, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem btn_Add;
        private System.Windows.Forms.ToolStripMenuItem btnCancel;
        private System.Windows.Forms.ToolStripMenuItem btn_Export;
        private System.Windows.Forms.ToolStripMenuItem btn_Fresh;
        private System.Windows.Forms.ToolStripMenuItem btn_SelectColumns;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controls.TooStripDBCTextBox txtKeyword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btn_WaitPurchase;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAlert;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnReceivedAll;
        private System.Windows.Forms.Button btnOverDate;
        private System.Windows.Forms.DataGridViewLinkColumn colSheetNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDemandDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMissing;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuyer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Fresh;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Add;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Delete;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
    }
}