namespace LJH.Inventory.UI.Forms.Financial
{
    partial class FrmSupplierFinancialStateMaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Payment = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cMnu_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkOnlyHasRecievables = new System.Windows.Forms.CheckBox();
            this.txtKeyword = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceivable = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colPrepay = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colTax = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colTaxBill = new System.Windows.Forms.DataGridViewLinkColumn();
            this.mnu_AddRecievable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_AddTax = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_AddTaxBill = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryTree = new LJH.Inventory.UI.Controls.SupplierTree(this.components);
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
            this.pnlLeft.Size = new System.Drawing.Size(194, 366);
            this.pnlLeft.TabIndex = 111;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitter1.Location = new System.Drawing.Point(194, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 366);
            this.splitter1.TabIndex = 112;
            this.splitter1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMnu_Fresh,
            this.mnu_AddRecievable,
            this.cMnu_Payment,
            this.toolStripSeparator3,
            this.mnu_AddTax,
            this.mnu_AddTaxBill,
            this.toolStripSeparator1,
            this.cMnu_SelectColumns,
            this.cMnu_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 192);
            // 
            // cMnu_Fresh
            // 
            this.cMnu_Fresh.Name = "cMnu_Fresh";
            this.cMnu_Fresh.Size = new System.Drawing.Size(160, 22);
            this.cMnu_Fresh.Text = "刷新";
            // 
            // cMnu_Payment
            // 
            this.cMnu_Payment.Name = "cMnu_Payment";
            this.cMnu_Payment.Size = new System.Drawing.Size(160, 22);
            this.cMnu_Payment.Text = "新增付款流水";
            this.cMnu_Payment.Click += new System.EventHandler(this.mnu_Payment_Click);
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
            this.panel5.Controls.Add(this.chkOnlyHasRecievables);
            this.panel5.Controls.Add(this.txtKeyword);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(202, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(862, 36);
            this.panel5.TabIndex = 114;
            // 
            // chkOnlyHasRecievables
            // 
            this.chkOnlyHasRecievables.AutoSize = true;
            this.chkOnlyHasRecievables.Location = new System.Drawing.Point(20, 10);
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
            this.txtKeyword.Location = new System.Drawing.Point(262, 8);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(535, 21);
            this.txtKeyword.TabIndex = 1;
            this.txtKeyword.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 12);
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
            this.colReceivable,
            this.colPrepay,
            this.colTax,
            this.colTaxBill});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(202, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(862, 330);
            this.dataGridView1.TabIndex = 115;
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
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colName.HeaderText = "公司名称";
            this.colName.MinimumWidth = 150;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 150;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "类别";
            this.colCategory.MinimumWidth = 120;
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 120;
            // 
            // colReceivable
            // 
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.colReceivable.DefaultCellStyle = dataGridViewCellStyle5;
            this.colReceivable.HeaderText = "应付账款";
            this.colReceivable.Name = "colReceivable";
            this.colReceivable.ReadOnly = true;
            this.colReceivable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colReceivable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colPrepay
            // 
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.colPrepay.DefaultCellStyle = dataGridViewCellStyle6;
            this.colPrepay.HeaderText = "未核销应付款";
            this.colPrepay.Name = "colPrepay";
            this.colPrepay.ReadOnly = true;
            this.colPrepay.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPrepay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colTax
            // 
            dataGridViewCellStyle7.Format = "C2";
            this.colTax.DefaultCellStyle = dataGridViewCellStyle7;
            this.colTax.HeaderText = "应开增值税额";
            this.colTax.Name = "colTax";
            this.colTax.ReadOnly = true;
            // 
            // colTaxBill
            // 
            dataGridViewCellStyle8.Format = "C2";
            this.colTaxBill.DefaultCellStyle = dataGridViewCellStyle8;
            this.colTaxBill.HeaderText = "已开增值税发票";
            this.colTaxBill.Name = "colTaxBill";
            this.colTaxBill.ReadOnly = true;
            // 
            // mnu_AddRecievable
            // 
            this.mnu_AddRecievable.Name = "mnu_AddRecievable";
            this.mnu_AddRecievable.Size = new System.Drawing.Size(160, 22);
            this.mnu_AddRecievable.Text = "新增应收账款";
            this.mnu_AddRecievable.Click += new System.EventHandler(this.mnu_AddRecievable_Click);
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
            // categoryTree
            // 
            this.categoryTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryTree.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.categoryTree.HideSelection = false;
            this.categoryTree.ItemHeight = 20;
            this.categoryTree.LoadSupplier = false;
            this.categoryTree.Location = new System.Drawing.Point(0, 0);
            this.categoryTree.Name = "categoryTree";
            this.categoryTree.Size = new System.Drawing.Size(194, 366);
            this.categoryTree.TabIndex = 2;
            this.categoryTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.categoryTree_NodeMouseClick);
            // 
            // FrmSupplierFinancialStateMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 388);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlLeft);
            this.Name = "FrmSupplierFinancialStateMaster";
            this.Text = "供应商应付账款";
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
        private Controls.SupplierTree categoryTree;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Fresh;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Payment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cMnu_SelectColumns;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox chkOnlyHasRecievables;
        private GeneralLibrary.WinformControl.DBCTextBox txtKeyword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewLinkColumn colReceivable;
        private System.Windows.Forms.DataGridViewLinkColumn colPrepay;
        private System.Windows.Forms.DataGridViewLinkColumn colTax;
        private System.Windows.Forms.DataGridViewLinkColumn colTaxBill;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddRecievable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddTax;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddTaxBill;
    }
}