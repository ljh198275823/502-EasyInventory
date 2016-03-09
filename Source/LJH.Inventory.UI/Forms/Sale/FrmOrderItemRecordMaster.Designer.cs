namespace LJH.Inventory.UI.Forms.Sale
{
    partial class FrmOrderItemRecordMaster
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Reserve = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_CreateDeliverySheet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cMnu_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtKeyword = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkPatialShipped = new System.Windows.Forms.CheckBox();
            this.chkAllShipped = new System.Windows.Forms.CheckBox();
            this.chkNoneShipped = new System.Windows.Forms.CheckBox();
            this.lable6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkNullify = new System.Windows.Forms.CheckBox();
            this.chkApproved = new System.Windows.Forms.CheckBox();
            this.chkAdded = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.customerTree1 = new LJH.Inventory.UI.Controls.CustomerTree(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInventory = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colOnway = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colShipped = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colValidInventory = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colNotPurchased = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDemandDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMnu_Fresh,
            this.cMnu_Reserve,
            this.mnu_CreateDeliverySheet,
            this.toolStripSeparator3,
            this.cMnu_SelectColumns,
            this.cMnu_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 120);
            // 
            // cMnu_Fresh
            // 
            this.cMnu_Fresh.Name = "cMnu_Fresh";
            this.cMnu_Fresh.Size = new System.Drawing.Size(148, 22);
            this.cMnu_Fresh.Text = "刷新";
            // 
            // cMnu_Reserve
            // 
            this.cMnu_Reserve.Name = "cMnu_Reserve";
            this.cMnu_Reserve.Size = new System.Drawing.Size(148, 22);
            this.cMnu_Reserve.Text = "库存转为备货";
            this.cMnu_Reserve.Click += new System.EventHandler(this.cMnu_Reserve_Click);
            // 
            // mnu_CreateDeliverySheet
            // 
            this.mnu_CreateDeliverySheet.Name = "mnu_CreateDeliverySheet";
            this.mnu_CreateDeliverySheet.Size = new System.Drawing.Size(148, 22);
            this.mnu_CreateDeliverySheet.Text = "创建送货单...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
            // 
            // cMnu_SelectColumns
            // 
            this.cMnu_SelectColumns.Name = "cMnu_SelectColumns";
            this.cMnu_SelectColumns.Size = new System.Drawing.Size(148, 22);
            this.cMnu_SelectColumns.Text = "选择列...";
            // 
            // cMnu_Export
            // 
            this.cMnu_Export.Name = "cMnu_Export";
            this.cMnu_Export.Size = new System.Drawing.Size(148, 22);
            this.cMnu_Export.Text = "导出...";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.panel5);
            this.pnlFilter.Controls.Add(this.panel4);
            this.pnlFilter.Controls.Add(this.panel2);
            this.pnlFilter.Controls.Add(this.panel3);
            this.pnlFilter.Controls.Add(this.panel1);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1107, 33);
            this.pnlFilter.TabIndex = 110;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtKeyword);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(523, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(584, 33);
            this.panel5.TabIndex = 6;
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyword.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtKeyword.Location = new System.Drawing.Point(69, 7);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(503, 21);
            this.txtKeyword.TabIndex = 1;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "模糊匹配";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(522, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 33);
            this.panel4.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkPatialShipped);
            this.panel2.Controls.Add(this.chkAllShipped);
            this.panel2.Controls.Add(this.chkNoneShipped);
            this.panel2.Controls.Add(this.lable6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(223, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 33);
            this.panel2.TabIndex = 4;
            // 
            // chkPatialShipped
            // 
            this.chkPatialShipped.AutoSize = true;
            this.chkPatialShipped.Checked = true;
            this.chkPatialShipped.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPatialShipped.Location = new System.Drawing.Point(134, 9);
            this.chkPatialShipped.Name = "chkPatialShipped";
            this.chkPatialShipped.Size = new System.Drawing.Size(72, 16);
            this.chkPatialShipped.TabIndex = 3;
            this.chkPatialShipped.Text = "部分出货";
            this.chkPatialShipped.UseVisualStyleBackColor = true;
            this.chkPatialShipped.CheckedChanged += new System.EventHandler(this.chkState_CheckedChanged);
            // 
            // chkAllShipped
            // 
            this.chkAllShipped.AutoSize = true;
            this.chkAllShipped.Location = new System.Drawing.Point(214, 9);
            this.chkAllShipped.Name = "chkAllShipped";
            this.chkAllShipped.Size = new System.Drawing.Size(72, 16);
            this.chkAllShipped.TabIndex = 2;
            this.chkAllShipped.Text = "全部出货";
            this.chkAllShipped.UseVisualStyleBackColor = true;
            this.chkAllShipped.CheckedChanged += new System.EventHandler(this.chkState_CheckedChanged);
            // 
            // chkNoneShipped
            // 
            this.chkNoneShipped.AutoSize = true;
            this.chkNoneShipped.Checked = true;
            this.chkNoneShipped.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoneShipped.Location = new System.Drawing.Point(68, 9);
            this.chkNoneShipped.Name = "chkNoneShipped";
            this.chkNoneShipped.Size = new System.Drawing.Size(60, 16);
            this.chkNoneShipped.TabIndex = 1;
            this.chkNoneShipped.Text = "未出货";
            this.chkNoneShipped.UseVisualStyleBackColor = true;
            this.chkNoneShipped.CheckedChanged += new System.EventHandler(this.chkState_CheckedChanged);
            // 
            // lable6
            // 
            this.lable6.AutoSize = true;
            this.lable6.Location = new System.Drawing.Point(9, 11);
            this.lable6.Name = "lable6";
            this.lable6.Size = new System.Drawing.Size(53, 12);
            this.lable6.TabIndex = 0;
            this.lable6.Text = "出货情况";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(222, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 33);
            this.panel3.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkNullify);
            this.panel1.Controls.Add(this.chkApproved);
            this.panel1.Controls.Add(this.chkAdded);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 33);
            this.panel1.TabIndex = 1;
            // 
            // chkNullify
            // 
            this.chkNullify.AutoSize = true;
            this.chkNullify.Location = new System.Drawing.Point(159, 9);
            this.chkNullify.Name = "chkNullify";
            this.chkNullify.Size = new System.Drawing.Size(48, 16);
            this.chkNullify.TabIndex = 3;
            this.chkNullify.Text = "作废";
            this.chkNullify.UseVisualStyleBackColor = true;
            this.chkNullify.CheckedChanged += new System.EventHandler(this.chkState_CheckedChanged);
            // 
            // chkApproved
            // 
            this.chkApproved.AutoSize = true;
            this.chkApproved.Checked = true;
            this.chkApproved.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkApproved.Location = new System.Drawing.Point(105, 9);
            this.chkApproved.Name = "chkApproved";
            this.chkApproved.Size = new System.Drawing.Size(48, 16);
            this.chkApproved.TabIndex = 2;
            this.chkApproved.Text = "审核";
            this.chkApproved.UseVisualStyleBackColor = true;
            this.chkApproved.CheckedChanged += new System.EventHandler(this.chkState_CheckedChanged);
            // 
            // chkAdded
            // 
            this.chkAdded.AutoSize = true;
            this.chkAdded.Checked = true;
            this.chkAdded.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAdded.Location = new System.Drawing.Point(47, 9);
            this.chkAdded.Name = "chkAdded";
            this.chkAdded.Size = new System.Drawing.Size(48, 16);
            this.chkAdded.TabIndex = 1;
            this.chkAdded.Text = "新建";
            this.chkAdded.UseVisualStyleBackColor = true;
            this.chkAdded.CheckedChanged += new System.EventHandler(this.chkState_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "状态";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.customerTree1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 33);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(223, 335);
            this.pnlLeft.TabIndex = 112;
            // 
            // customerTree1
            // 
            this.customerTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerTree1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.customerTree1.HideSelection = false;
            this.customerTree1.ItemHeight = 20;
            this.customerTree1.LoadCustomer = true;
            this.customerTree1.Location = new System.Drawing.Point(0, 0);
            this.customerTree1.Name = "customerTree1";
            this.customerTree1.Size = new System.Drawing.Size(223, 335);
            this.customerTree1.TabIndex = 1;
            this.customerTree1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.customerTree1_NodeMouseClick);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitter1.Location = new System.Drawing.Point(223, 33);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 335);
            this.splitter1.TabIndex = 113;
            this.splitter1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderID,
            this.colCustomer,
            this.colProduct,
            this.colUnit,
            this.colCount,
            this.colInventory,
            this.colOnway,
            this.colShipped,
            this.colValidInventory,
            this.colNotPurchased,
            this.colDemandDate,
            this.colSales,
            this.colState,
            this.colMemo});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(231, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(876, 335);
            this.dataGridView1.TabIndex = 114;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colOrderID
            // 
            this.colOrderID.HeaderText = "订单编号";
            this.colOrderID.Name = "colOrderID";
            this.colOrderID.ReadOnly = true;
            this.colOrderID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colCustomer
            // 
            this.colCustomer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colCustomer.HeaderText = "客户";
            this.colCustomer.MinimumWidth = 150;
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCustomer.Width = 150;
            // 
            // colProduct
            // 
            this.colProduct.HeaderText = "产品";
            this.colProduct.Name = "colProduct";
            this.colProduct.ReadOnly = true;
            this.colProduct.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colUnit
            // 
            this.colUnit.HeaderText = "单位";
            this.colUnit.Name = "colUnit";
            this.colUnit.ReadOnly = true;
            this.colUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colUnit.Width = 40;
            // 
            // colCount
            // 
            this.colCount.HeaderText = "订单数量";
            this.colCount.Name = "colCount";
            this.colCount.ReadOnly = true;
            this.colCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCount.Width = 80;
            // 
            // colInventory
            // 
            this.colInventory.HeaderText = "已备货";
            this.colInventory.Name = "colInventory";
            this.colInventory.ReadOnly = true;
            this.colInventory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInventory.Width = 80;
            // 
            // colOnway
            // 
            this.colOnway.HeaderText = "采购在途";
            this.colOnway.Name = "colOnway";
            this.colOnway.ReadOnly = true;
            this.colOnway.Width = 80;
            // 
            // colShipped
            // 
            this.colShipped.HeaderText = "已发货";
            this.colShipped.Name = "colShipped";
            this.colShipped.ReadOnly = true;
            this.colShipped.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colShipped.Width = 80;
            // 
            // colValidInventory
            // 
            this.colValidInventory.HeaderText = "可用库存";
            this.colValidInventory.Name = "colValidInventory";
            this.colValidInventory.ReadOnly = true;
            this.colValidInventory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colValidInventory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colNotPurchased
            // 
            this.colNotPurchased.HeaderText = "待采购";
            this.colNotPurchased.Name = "colNotPurchased";
            this.colNotPurchased.ReadOnly = true;
            this.colNotPurchased.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colNotPurchased.Width = 80;
            // 
            // colDemandDate
            // 
            dataGridViewCellStyle1.Format = "D";
            this.colDemandDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDemandDate.HeaderText = "交货日期";
            this.colDemandDate.Name = "colDemandDate";
            this.colDemandDate.ReadOnly = true;
            // 
            // colSales
            // 
            this.colSales.HeaderText = "业务";
            this.colSales.Name = "colSales";
            this.colSales.ReadOnly = true;
            // 
            // colState
            // 
            this.colState.HeaderText = "状态";
            this.colState.Name = "colState";
            this.colState.ReadOnly = true;
            // 
            // colMemo
            // 
            this.colMemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMemo.HeaderText = "备注";
            this.colMemo.MinimumWidth = 100;
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            // 
            // FrmOrderItemRecordMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 390);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlFilter);
            this.Name = "FrmOrderItemRecordMaster";
            this.Text = "订单跟踪管理";
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            this.Controls.SetChildIndex(this.pnlLeft, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Fresh;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Reserve;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cMnu_SelectColumns;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlLeft;
        private Controls.CustomerTree customerTree1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkNullify;
        private System.Windows.Forms.CheckBox chkApproved;
        private System.Windows.Forms.CheckBox chkAdded;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkPatialShipped;
        private System.Windows.Forms.CheckBox chkAllShipped;
        private System.Windows.Forms.CheckBox chkNoneShipped;
        private System.Windows.Forms.Label lable6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private GeneralLibrary.WinformControl.DBCTextBox txtKeyword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem mnu_CreateDeliverySheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewLinkColumn colInventory;
        private System.Windows.Forms.DataGridViewLinkColumn colOnway;
        private System.Windows.Forms.DataGridViewLinkColumn colShipped;
        private System.Windows.Forms.DataGridViewLinkColumn colValidInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotPurchased;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDemandDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;

    }
}