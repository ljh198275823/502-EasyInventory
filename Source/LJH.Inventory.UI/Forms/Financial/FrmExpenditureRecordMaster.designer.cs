namespace LJH.Inventory.UI.Forms.Financial
{
    partial class FrmExpenditureRecordMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExpenditureRecordMaster));
            this.CategoryMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_AddExpenditure = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_AddCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_DeleteCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_CategoryProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_新建管理费用 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_新建管理费用退款 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cMnu_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSheetDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col退款 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAdded = new System.Windows.Forms.CheckBox();
            this.txtKeyword = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.chkApproved = new System.Windows.Forms.CheckBox();
            this.lbl合计 = new System.Windows.Forms.Label();
            this.chkNullify = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.categoryTree = new LJH.Inventory.UI.Controls.ExpenditureTypeTree(this.components);
            this.ucDateTimeInterval1 = new LJH.Inventory.UI.Controls.UCDateTimeInterval();
            this.lbl退款 = new System.Windows.Forms.Label();
            this.lbl结余 = new System.Windows.Forms.Label();
            this.CategoryMenu.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // CategoryMenu
            // 
            this.CategoryMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_AddExpenditure,
            this.mnu_AddCategory,
            this.mnu_DeleteCategory,
            this.mnu_CategoryProperty});
            this.CategoryMenu.Name = "contextMenuStrip1";
            this.CategoryMenu.Size = new System.Drawing.Size(125, 92);
            // 
            // mnu_AddExpenditure
            // 
            this.mnu_AddExpenditure.Name = "mnu_AddExpenditure";
            this.mnu_AddExpenditure.Size = new System.Drawing.Size(124, 22);
            this.mnu_AddExpenditure.Text = "新建支出";
            this.mnu_AddExpenditure.Click += new System.EventHandler(this.mnu_AddExpenditure_Click);
            // 
            // mnu_AddCategory
            // 
            this.mnu_AddCategory.Name = "mnu_AddCategory";
            this.mnu_AddCategory.Size = new System.Drawing.Size(124, 22);
            this.mnu_AddCategory.Text = "增加类别";
            this.mnu_AddCategory.Click += new System.EventHandler(this.mnu_AddCategory_Click);
            // 
            // mnu_DeleteCategory
            // 
            this.mnu_DeleteCategory.Name = "mnu_DeleteCategory";
            this.mnu_DeleteCategory.Size = new System.Drawing.Size(124, 22);
            this.mnu_DeleteCategory.Text = "删除";
            this.mnu_DeleteCategory.Click += new System.EventHandler(this.mnu_DeleteCategory_Click);
            // 
            // mnu_CategoryProperty
            // 
            this.mnu_CategoryProperty.Name = "mnu_CategoryProperty";
            this.mnu_CategoryProperty.Size = new System.Drawing.Size(124, 22);
            this.mnu_CategoryProperty.Text = "属性";
            this.mnu_CategoryProperty.Click += new System.EventHandler(this.mnu_CategoryProperty_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.panel5);
            this.pnlFilter.Controls.Add(this.panel4);
            this.pnlFilter.Controls.Add(this.panel3);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1265, 113);
            this.pnlFilter.TabIndex = 113;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(1, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 113);
            this.panel4.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 113);
            this.panel3.TabIndex = 3;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.categoryTree);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 113);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(224, 235);
            this.pnlLeft.TabIndex = 114;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitter1.Location = new System.Drawing.Point(224, 113);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 235);
            this.splitter1.TabIndex = 115;
            this.splitter1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colSheetDate,
            this.colCategory,
            this.colAmount,
            this.col退款,
            this.colAccount,
            this.colPayer,
            this.colRequest,
            this.colState,
            this.colMemo});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(232, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1033, 235);
            this.dataGridView1.TabIndex = 116;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMnu_Fresh,
            this.mnu_新建管理费用,
            this.mnu_新建管理费用退款,
            this.toolStripSeparator3,
            this.cMnu_SelectColumns,
            this.cMnu_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 120);
            // 
            // cMnu_Fresh
            // 
            this.cMnu_Fresh.Name = "cMnu_Fresh";
            this.cMnu_Fresh.Size = new System.Drawing.Size(172, 22);
            this.cMnu_Fresh.Text = "刷新";
            // 
            // mnu_新建管理费用
            // 
            this.mnu_新建管理费用.Name = "mnu_新建管理费用";
            this.mnu_新建管理费用.Size = new System.Drawing.Size(172, 22);
            this.mnu_新建管理费用.Text = "新建管理费用";
            this.mnu_新建管理费用.Click += new System.EventHandler(this.mnu_新建管理费用_Click);
            // 
            // mnu_新建管理费用退款
            // 
            this.mnu_新建管理费用退款.Name = "mnu_新建管理费用退款";
            this.mnu_新建管理费用退款.Size = new System.Drawing.Size(172, 22);
            this.mnu_新建管理费用退款.Text = "新建管理费用退款";
            this.mnu_新建管理费用退款.Click += new System.EventHandler(this.mnu_新建管理费用退款_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // cMnu_SelectColumns
            // 
            this.cMnu_SelectColumns.Name = "cMnu_SelectColumns";
            this.cMnu_SelectColumns.Size = new System.Drawing.Size(172, 22);
            this.cMnu_SelectColumns.Text = "选择列...";
            // 
            // cMnu_Export
            // 
            this.cMnu_Export.Name = "cMnu_Export";
            this.cMnu_Export.Size = new System.Drawing.Size(172, 22);
            this.cMnu_Export.Text = "导出...";
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colID.HeaderText = "支出单号";
            this.colID.MinimumWidth = 100;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colSheetDate
            // 
            this.colSheetDate.HeaderText = "日期";
            this.colSheetDate.Name = "colSheetDate";
            this.colSheetDate.ReadOnly = true;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "费用类别";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            // 
            // colAmount
            // 
            dataGridViewCellStyle1.Format = "C2";
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.colAmount.HeaderText = "支出";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // col退款
            // 
            dataGridViewCellStyle2.Format = "C2";
            this.col退款.DefaultCellStyle = dataGridViewCellStyle2;
            this.col退款.HeaderText = "退款";
            this.col退款.Name = "col退款";
            this.col退款.ReadOnly = true;
            // 
            // colAccount
            // 
            this.colAccount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAccount.HeaderText = "付款账号";
            this.colAccount.Name = "colAccount";
            this.colAccount.ReadOnly = true;
            this.colAccount.Width = 78;
            // 
            // colPayer
            // 
            this.colPayer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colPayer.HeaderText = "对方账号";
            this.colPayer.Name = "colPayer";
            this.colPayer.ReadOnly = true;
            this.colPayer.Visible = false;
            this.colPayer.Width = 78;
            // 
            // colRequest
            // 
            this.colRequest.HeaderText = "申请人";
            this.colRequest.Name = "colRequest";
            this.colRequest.ReadOnly = true;
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
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(285, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "状态";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "模糊匹配";
            // 
            // chkAdded
            // 
            this.chkAdded.AutoSize = true;
            this.chkAdded.Checked = true;
            this.chkAdded.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAdded.Location = new System.Drawing.Point(323, 55);
            this.chkAdded.Name = "chkAdded";
            this.chkAdded.Size = new System.Drawing.Size(48, 16);
            this.chkAdded.TabIndex = 1;
            this.chkAdded.Text = "新建";
            this.chkAdded.UseVisualStyleBackColor = true;
            this.chkAdded.CheckedChanged += new System.EventHandler(this.chkState_CheckedChanged);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtKeyword.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtKeyword.Location = new System.Drawing.Point(321, 22);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(162, 21);
            this.txtKeyword.TabIndex = 1;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            // 
            // chkApproved
            // 
            this.chkApproved.AutoSize = true;
            this.chkApproved.Checked = true;
            this.chkApproved.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkApproved.Location = new System.Drawing.Point(381, 55);
            this.chkApproved.Name = "chkApproved";
            this.chkApproved.Size = new System.Drawing.Size(48, 16);
            this.chkApproved.TabIndex = 2;
            this.chkApproved.Text = "审核";
            this.chkApproved.UseVisualStyleBackColor = true;
            this.chkApproved.CheckedChanged += new System.EventHandler(this.chkState_CheckedChanged);
            // 
            // lbl合计
            // 
            this.lbl合计.AutoSize = true;
            this.lbl合计.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl合计.ForeColor = System.Drawing.Color.Blue;
            this.lbl合计.Location = new System.Drawing.Point(577, 20);
            this.lbl合计.Name = "lbl合计";
            this.lbl合计.Size = new System.Drawing.Size(17, 16);
            this.lbl合计.TabIndex = 2;
            this.lbl合计.Text = "0";
            // 
            // chkNullify
            // 
            this.chkNullify.AutoSize = true;
            this.chkNullify.Location = new System.Drawing.Point(435, 55);
            this.chkNullify.Name = "chkNullify";
            this.chkNullify.Size = new System.Drawing.Size(48, 16);
            this.chkNullify.TabIndex = 3;
            this.chkNullify.Text = "作废";
            this.chkNullify.UseVisualStyleBackColor = true;
            this.chkNullify.CheckedChanged += new System.EventHandler(this.chkState_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucDateTimeInterval1);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 95);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "开单日期";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbl结余);
            this.panel5.Controls.Add(this.lbl退款);
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Controls.Add(this.chkNullify);
            this.panel5.Controls.Add(this.lbl合计);
            this.panel5.Controls.Add(this.chkApproved);
            this.panel5.Controls.Add(this.txtKeyword);
            this.panel5.Controls.Add(this.chkAdded);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(2, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1263, 113);
            this.panel5.TabIndex = 6;
            // 
            // categoryTree
            // 
            this.categoryTree.ContextMenuStrip = this.CategoryMenu;
            this.categoryTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryTree.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.categoryTree.HideSelection = false;
            this.categoryTree.ItemHeight = 20;
            this.categoryTree.Location = new System.Drawing.Point(0, 0);
            this.categoryTree.Name = "categoryTree";
            this.categoryTree.Size = new System.Drawing.Size(224, 235);
            this.categoryTree.TabIndex = 0;
            this.categoryTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.category_NodeMouseClick);
            // 
            // ucDateTimeInterval1
            // 
            this.ucDateTimeInterval1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDateTimeInterval1.EndDateTime = new System.DateTime(2015, 11, 19, 10, 3, 12, 722);
            this.ucDateTimeInterval1.Location = new System.Drawing.Point(4, 15);
            this.ucDateTimeInterval1.Name = "ucDateTimeInterval1";
            this.ucDateTimeInterval1.ShowTime = true;
            this.ucDateTimeInterval1.Size = new System.Drawing.Size(223, 74);
            this.ucDateTimeInterval1.StartDateTime = new System.DateTime(2015, 11, 19, 10, 3, 12, 722);
            this.ucDateTimeInterval1.TabIndex = 135;
            this.ucDateTimeInterval1.ValueChanged += new System.EventHandler(this.ucDateTimeInterval1_ValueChanged);
            // 
            // lbl退款
            // 
            this.lbl退款.AutoSize = true;
            this.lbl退款.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl退款.ForeColor = System.Drawing.Color.Red;
            this.lbl退款.Location = new System.Drawing.Point(577, 49);
            this.lbl退款.Name = "lbl退款";
            this.lbl退款.Size = new System.Drawing.Size(17, 16);
            this.lbl退款.TabIndex = 39;
            this.lbl退款.Text = "0";
            // 
            // lbl结余
            // 
            this.lbl结余.AutoSize = true;
            this.lbl结余.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl结余.ForeColor = System.Drawing.Color.Blue;
            this.lbl结余.Location = new System.Drawing.Point(577, 78);
            this.lbl结余.Name = "lbl结余";
            this.lbl结余.Size = new System.Drawing.Size(17, 16);
            this.lbl结余.TabIndex = 40;
            this.lbl结余.Text = "0";
            // 
            // FrmExpenditureRecordMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1265, 370);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlFilter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmExpenditureRecordMaster";
            this.Text = "公司管理费用";
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            this.Controls.SetChildIndex(this.pnlLeft, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.CategoryMenu.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip CategoryMenu;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddCategory;
        private System.Windows.Forms.ToolStripMenuItem mnu_DeleteCategory;
        private System.Windows.Forms.ToolStripMenuItem mnu_CategoryProperty;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Fresh;
        private System.Windows.Forms.ToolStripMenuItem mnu_新建管理费用;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cMnu_SelectColumns;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
        private Controls.ExpenditureTypeTree categoryTree;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddExpenditure;
        private System.Windows.Forms.ToolStripMenuItem mnu_新建管理费用退款;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.UCDateTimeInterval ucDateTimeInterval1;
        private System.Windows.Forms.CheckBox chkNullify;
        private System.Windows.Forms.Label lbl合计;
        private System.Windows.Forms.CheckBox chkApproved;
        private GeneralLibrary.WinformControl.DBCTextBox txtKeyword;
        private System.Windows.Forms.CheckBox chkAdded;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSheetDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col退款;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        private System.Windows.Forms.Label lbl退款;
        private System.Windows.Forms.Label lbl结余;
    }
}