namespace LJH.Inventory.UI.Forms.Financial
{
    partial class FrmCustomerFinancialStateMaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerFinancialStateMaster));
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.categoryTree = new LJH.Inventory.UI.Controls.CustomerTree(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_AddRecievable = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_AddPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_新增客户退款 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_客户往来报表 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_UpdateCreditLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_SetFileID = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_设置税务归档码 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_AddTax = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_AddTaxBill = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cMnu_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblOriginalTotal = new System.Windows.Forms.Label();
            this.lblTotalWeight = new System.Windows.Forms.Label();
            this.chkOnlyHasRecievables = new System.Windows.Forms.CheckBox();
            this.txtKeyword = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreditLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaxFileID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceivable = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colPrepay = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colTax = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colTaxBill = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col对公已付金额 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col发票已核销对公已付金额 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLinker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLinkerPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlLeft.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.categoryTree);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(194, 367);
            this.pnlLeft.TabIndex = 110;
            // 
            // categoryTree
            // 
            this.categoryTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryTree.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.categoryTree.HideSelection = false;
            this.categoryTree.ItemHeight = 20;
            this.categoryTree.LoadCustomer = false;
            this.categoryTree.Location = new System.Drawing.Point(0, 0);
            this.categoryTree.Name = "categoryTree";
            this.categoryTree.Size = new System.Drawing.Size(194, 367);
            this.categoryTree.TabIndex = 2;
            this.categoryTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FreshData_Clicked);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitter1.Location = new System.Drawing.Point(194, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 367);
            this.splitter1.TabIndex = 111;
            this.splitter1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMnu_Fresh,
            this.mnu_AddRecievable,
            this.mnu_AddPayment,
            this.mnu_新增客户退款,
            this.toolStripSeparator2,
            this.mnu_客户往来报表,
            this.mnu_UpdateCreditLine,
            this.mnu_SetFileID,
            this.mnu_设置税务归档码,
            this.toolStripSeparator1,
            this.mnu_AddTax,
            this.mnu_AddTaxBill,
            this.toolStripSeparator3,
            this.cMnu_SelectColumns,
            this.cMnu_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 286);
            // 
            // cMnu_Fresh
            // 
            this.cMnu_Fresh.Name = "cMnu_Fresh";
            this.cMnu_Fresh.Size = new System.Drawing.Size(160, 22);
            this.cMnu_Fresh.Text = "刷新";
            // 
            // mnu_AddRecievable
            // 
            this.mnu_AddRecievable.Name = "mnu_AddRecievable";
            this.mnu_AddRecievable.Size = new System.Drawing.Size(160, 22);
            this.mnu_AddRecievable.Text = "新增应收账款";
            this.mnu_AddRecievable.Click += new System.EventHandler(this.mnu_AddRecievable_Click);
            // 
            // mnu_AddPayment
            // 
            this.mnu_AddPayment.Name = "mnu_AddPayment";
            this.mnu_AddPayment.Size = new System.Drawing.Size(160, 22);
            this.mnu_AddPayment.Text = "新增付款流水";
            this.mnu_AddPayment.Click += new System.EventHandler(this.mnu_AddPayment_Click);
            // 
            // mnu_新增客户退款
            // 
            this.mnu_新增客户退款.Name = "mnu_新增客户退款";
            this.mnu_新增客户退款.Size = new System.Drawing.Size(160, 22);
            this.mnu_新增客户退款.Text = "新增客户退款";
            this.mnu_新增客户退款.Click += new System.EventHandler(this.mnu_新增客户退款_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // mnu_客户往来报表
            // 
            this.mnu_客户往来报表.Name = "mnu_客户往来报表";
            this.mnu_客户往来报表.Size = new System.Drawing.Size(160, 22);
            this.mnu_客户往来报表.Text = "客户往来报表";
            this.mnu_客户往来报表.Click += new System.EventHandler(this.mnu_客户往来报表_Click);
            // 
            // mnu_UpdateCreditLine
            // 
            this.mnu_UpdateCreditLine.Name = "mnu_UpdateCreditLine";
            this.mnu_UpdateCreditLine.Size = new System.Drawing.Size(160, 22);
            this.mnu_UpdateCreditLine.Text = "修改信用额度";
            this.mnu_UpdateCreditLine.Click += new System.EventHandler(this.mnu_UpdateCreditLine_Click);
            // 
            // mnu_SetFileID
            // 
            this.mnu_SetFileID.Name = "mnu_SetFileID";
            this.mnu_SetFileID.Size = new System.Drawing.Size(160, 22);
            this.mnu_SetFileID.Text = "设置归档号";
            this.mnu_SetFileID.Click += new System.EventHandler(this.mnu_SetFileID_Click);
            // 
            // mnu_设置税务归档码
            // 
            this.mnu_设置税务归档码.Name = "mnu_设置税务归档码";
            this.mnu_设置税务归档码.Size = new System.Drawing.Size(160, 22);
            this.mnu_设置税务归档码.Text = "设置税务归档码";
            this.mnu_设置税务归档码.Click += new System.EventHandler(this.mnu_设置税务归档码_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // mnu_AddTax
            // 
            this.mnu_AddTax.Name = "mnu_AddTax";
            this.mnu_AddTax.Size = new System.Drawing.Size(160, 22);
            this.mnu_AddTax.Text = "新增应开税额";
            this.mnu_AddTax.Click += new System.EventHandler(this.mnu_AddTax_Click);
            // 
            // mnu_AddTaxBill
            // 
            this.mnu_AddTaxBill.Name = "mnu_AddTaxBill";
            this.mnu_AddTaxBill.Size = new System.Drawing.Size(160, 22);
            this.mnu_AddTaxBill.Text = "新增增值税发票";
            this.mnu_AddTaxBill.Click += new System.EventHandler(this.mnu_AddTaxBill_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // cMnu_SelectColumns
            // 
            this.cMnu_SelectColumns.Name = "cMnu_SelectColumns";
            this.cMnu_SelectColumns.Size = new System.Drawing.Size(160, 22);
            this.cMnu_SelectColumns.Text = "选择列...";
            // 
            // cMnu_Export
            // 
            this.cMnu_Export.Name = "cMnu_Export";
            this.cMnu_Export.Size = new System.Drawing.Size(160, 22);
            this.cMnu_Export.Text = "导出...";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblOriginalTotal);
            this.panel5.Controls.Add(this.lblTotalWeight);
            this.panel5.Controls.Add(this.chkOnlyHasRecievables);
            this.panel5.Controls.Add(this.txtKeyword);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(202, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1038, 71);
            this.panel5.TabIndex = 113;
            // 
            // lblOriginalTotal
            // 
            this.lblOriginalTotal.AutoSize = true;
            this.lblOriginalTotal.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOriginalTotal.ForeColor = System.Drawing.Color.Blue;
            this.lblOriginalTotal.Location = new System.Drawing.Point(697, 13);
            this.lblOriginalTotal.Name = "lblOriginalTotal";
            this.lblOriginalTotal.Size = new System.Drawing.Size(17, 16);
            this.lblOriginalTotal.TabIndex = 96;
            this.lblOriginalTotal.Text = "0";
            this.lblOriginalTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalWeight
            // 
            this.lblTotalWeight.AutoSize = true;
            this.lblTotalWeight.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalWeight.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalWeight.Location = new System.Drawing.Point(697, 41);
            this.lblTotalWeight.Name = "lblTotalWeight";
            this.lblTotalWeight.Size = new System.Drawing.Size(17, 16);
            this.lblTotalWeight.TabIndex = 95;
            this.lblTotalWeight.Text = "0";
            this.lblTotalWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkOnlyHasRecievables
            // 
            this.chkOnlyHasRecievables.AutoSize = true;
            this.chkOnlyHasRecievables.Location = new System.Drawing.Point(20, 26);
            this.chkOnlyHasRecievables.Name = "chkOnlyHasRecievables";
            this.chkOnlyHasRecievables.Size = new System.Drawing.Size(156, 16);
            this.chkOnlyHasRecievables.TabIndex = 2;
            this.chkOnlyHasRecievables.Text = "只显示有应收账款的客户";
            this.chkOnlyHasRecievables.UseVisualStyleBackColor = true;
            this.chkOnlyHasRecievables.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyword.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtKeyword.Location = new System.Drawing.Point(262, 24);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(252, 21);
            this.txtKeyword.TabIndex = 1;
            this.txtKeyword.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "模糊匹配";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImage,
            this.colID,
            this.colName,
            this.colCategory,
            this.colCreditLine,
            this.colFileID,
            this.colTaxFileID,
            this.colReceivable,
            this.colPrepay,
            this.colTax,
            this.colTaxBill,
            this.col对公已付金额,
            this.col发票已核销对公已付金额,
            this.colPhone,
            this.colLinker,
            this.colLinkerPhone});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(202, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1038, 296);
            this.dataGridView1.TabIndex = 114;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colImage
            // 
            this.colImage.HeaderText = "";
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            this.colImage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colImage.Width = 30;
            // 
            // colID
            // 
            this.colID.HeaderText = "客户编号";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.HeaderText = "公司名称";
            this.colName.MinimumWidth = 180;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 180;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "类别";
            this.colCategory.MinimumWidth = 120;
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 120;
            // 
            // colCreditLine
            // 
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.colCreditLine.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCreditLine.HeaderText = "信用额度";
            this.colCreditLine.Name = "colCreditLine";
            this.colCreditLine.ReadOnly = true;
            // 
            // colFileID
            // 
            this.colFileID.HeaderText = "归档码";
            this.colFileID.Name = "colFileID";
            this.colFileID.ReadOnly = true;
            // 
            // colTaxFileID
            // 
            this.colTaxFileID.HeaderText = "税务归档码";
            this.colTaxFileID.Name = "colTaxFileID";
            this.colTaxFileID.ReadOnly = true;
            // 
            // colReceivable
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.colReceivable.DefaultCellStyle = dataGridViewCellStyle2;
            this.colReceivable.HeaderText = "应收账款";
            this.colReceivable.Name = "colReceivable";
            this.colReceivable.ReadOnly = true;
            this.colReceivable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colReceivable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colPrepay
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.colPrepay.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPrepay.HeaderText = "未核消收款";
            this.colPrepay.Name = "colPrepay";
            this.colPrepay.ReadOnly = true;
            this.colPrepay.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPrepay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colTax
            // 
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.colTax.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTax.HeaderText = "应开增值税";
            this.colTax.Name = "colTax";
            this.colTax.ReadOnly = true;
            this.colTax.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colTaxBill
            // 
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.colTaxBill.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTaxBill.HeaderText = "已开增值税发票";
            this.colTaxBill.Name = "colTaxBill";
            this.colTaxBill.ReadOnly = true;
            this.colTaxBill.Width = 120;
            // 
            // col对公已付金额
            // 
            dataGridViewCellStyle6.Format = "C2";
            this.col对公已付金额.DefaultCellStyle = dataGridViewCellStyle6;
            this.col对公已付金额.HeaderText = "对公已付金额";
            this.col对公已付金额.Name = "col对公已付金额";
            this.col对公已付金额.ReadOnly = true;
            // 
            // col发票已核销对公已付金额
            // 
            dataGridViewCellStyle7.Format = "C2";
            this.col发票已核销对公已付金额.DefaultCellStyle = dataGridViewCellStyle7;
            this.col发票已核销对公已付金额.HeaderText = "发票已核销对公已付金额";
            this.col发票已核销对公已付金额.Name = "col发票已核销对公已付金额";
            this.col发票已核销对公已付金额.ReadOnly = true;
            // 
            // colPhone
            // 
            this.colPhone.HeaderText = "电话";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            // 
            // colLinker
            // 
            this.colLinker.HeaderText = "联系人";
            this.colLinker.Name = "colLinker";
            this.colLinker.ReadOnly = true;
            // 
            // colLinkerPhone
            // 
            this.colLinkerPhone.HeaderText = "联系人电话";
            this.colLinkerPhone.Name = "colLinkerPhone";
            this.colLinkerPhone.ReadOnly = true;
            // 
            // FrmCustomerFinancialStateMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 389);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCustomerFinancialStateMaster";
            this.Text = "客户财务管理";
            this.Controls.SetChildIndex(this.pnlLeft, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.pnlLeft.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private Controls.CustomerTree categoryTree;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Fresh;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddPayment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cMnu_SelectColumns;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
        private System.Windows.Forms.ToolStripMenuItem mnu_UpdateCreditLine;
        private System.Windows.Forms.Panel panel5;
        private GeneralLibrary.WinformControl.DBCTextBox txtKeyword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem mnu_SetFileID;
        private System.Windows.Forms.CheckBox chkOnlyHasRecievables;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddRecievable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddTax;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddTaxBill;
        private System.Windows.Forms.Label lblOriginalTotal;
        private System.Windows.Forms.Label lblTotalWeight;
        private System.Windows.Forms.ToolStripMenuItem mnu_客户往来报表;
        private System.Windows.Forms.ToolStripMenuItem mnu_新增客户退款;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreditLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaxFileID;
        private System.Windows.Forms.DataGridViewLinkColumn colReceivable;
        private System.Windows.Forms.DataGridViewLinkColumn colPrepay;
        private System.Windows.Forms.DataGridViewLinkColumn colTax;
        private System.Windows.Forms.DataGridViewLinkColumn colTaxBill;
        private System.Windows.Forms.DataGridViewLinkColumn col对公已付金额;
        private System.Windows.Forms.DataGridViewLinkColumn col发票已核销对公已付金额;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLinker;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLinkerPhone;
        private System.Windows.Forms.ToolStripMenuItem mnu_设置税务归档码;
    }
}