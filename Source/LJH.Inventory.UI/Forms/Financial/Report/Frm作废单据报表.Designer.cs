namespace LJH.Inventory.UI.Forms.Financial.Report
{
    partial class Frm作废单据报表
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucDateTimeInterval1 = new LJH.GeneralLibrary.WinformControl.UCDateTimeInterval();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col作废日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col单据类别 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSheetID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col操作员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col作废原因 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk客户应收款 = new System.Windows.Forms.CheckBox();
            this.chk供应商应付款 = new System.Windows.Forms.CheckBox();
            this.chk客户应开增值税 = new System.Windows.Forms.CheckBox();
            this.chk供应商应开增值税 = new System.Windows.Forms.CheckBox();
            this.chk供应商增值税发票 = new System.Windows.Forms.CheckBox();
            this.chk客户增值税发票 = new System.Windows.Forms.CheckBox();
            this.chk供应商付款 = new System.Windows.Forms.CheckBox();
            this.chk客户收款 = new System.Windows.Forms.CheckBox();
            this.chk退款 = new System.Windows.Forms.CheckBox();
            this.chk账户转账 = new System.Windows.Forms.CheckBox();
            this.chk其它收款 = new System.Windows.Forms.CheckBox();
            this.chk公司管理费用 = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.pnlDocType = new System.Windows.Forms.Panel();
            this.chk送货单 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlDocType.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(943, 19);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(943, 48);
            // 
            // btnColumn
            // 
            this.btnColumn.Location = new System.Drawing.Point(943, 77);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucDateTimeInterval1);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 90);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "作废日期";
            // 
            // ucDateTimeInterval1
            // 
            this.ucDateTimeInterval1.EndDateTime = new System.DateTime(2012, 6, 2, 10, 42, 8, 482);
            this.ucDateTimeInterval1.Location = new System.Drawing.Point(4, 14);
            this.ucDateTimeInterval1.Name = "ucDateTimeInterval1";
            this.ucDateTimeInterval1.ShowTime = false;
            this.ucDateTimeInterval1.Size = new System.Drawing.Size(221, 74);
            this.ucDateTimeInterval1.StartDateTime = new System.DateTime(2012, 6, 2, 10, 42, 8, 482);
            this.ucDateTimeInterval1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col作废日期,
            this.col单据类别,
            this.colSheetID,
            this.col操作员,
            this.col作废原因});
            this.dataGridView1.Location = new System.Drawing.Point(2, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1081, 261);
            this.dataGridView1.TabIndex = 40;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // col作废日期
            // 
            this.col作废日期.HeaderText = "作废日期";
            this.col作废日期.Name = "col作废日期";
            this.col作废日期.ReadOnly = true;
            this.col作废日期.Width = 130;
            // 
            // col单据类别
            // 
            this.col单据类别.HeaderText = "单据类别";
            this.col单据类别.Name = "col单据类别";
            this.col单据类别.ReadOnly = true;
            // 
            // colSheetID
            // 
            this.colSheetID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSheetID.HeaderText = "单据编号";
            this.colSheetID.MinimumWidth = 100;
            this.colSheetID.Name = "colSheetID";
            this.colSheetID.ReadOnly = true;
            this.colSheetID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // col操作员
            // 
            this.col操作员.HeaderText = "操作员";
            this.col操作员.Name = "col操作员";
            this.col操作员.ReadOnly = true;
            // 
            // col作废原因
            // 
            this.col作废原因.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col作废原因.HeaderText = "作废原因";
            this.col作废原因.Name = "col作废原因";
            this.col作废原因.ReadOnly = true;
            // 
            // chk客户应收款
            // 
            this.chk客户应收款.AutoSize = true;
            this.chk客户应收款.Checked = true;
            this.chk客户应收款.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk客户应收款.Location = new System.Drawing.Point(9, 8);
            this.chk客户应收款.Name = "chk客户应收款";
            this.chk客户应收款.Size = new System.Drawing.Size(84, 16);
            this.chk客户应收款.TabIndex = 0;
            this.chk客户应收款.Text = "客户应收款";
            this.chk客户应收款.UseVisualStyleBackColor = true;
            // 
            // chk供应商应付款
            // 
            this.chk供应商应付款.AutoSize = true;
            this.chk供应商应付款.Checked = true;
            this.chk供应商应付款.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk供应商应付款.Location = new System.Drawing.Point(9, 39);
            this.chk供应商应付款.Name = "chk供应商应付款";
            this.chk供应商应付款.Size = new System.Drawing.Size(96, 16);
            this.chk供应商应付款.TabIndex = 4;
            this.chk供应商应付款.Text = "供应商应付款";
            this.chk供应商应付款.UseVisualStyleBackColor = true;
            // 
            // chk客户应开增值税
            // 
            this.chk客户应开增值税.AutoSize = true;
            this.chk客户应开增值税.Checked = true;
            this.chk客户应开增值税.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk客户应开增值税.Location = new System.Drawing.Point(113, 8);
            this.chk客户应开增值税.Name = "chk客户应开增值税";
            this.chk客户应开增值税.Size = new System.Drawing.Size(108, 16);
            this.chk客户应开增值税.TabIndex = 1;
            this.chk客户应开增值税.Text = "客户应开增值税";
            this.chk客户应开增值税.UseVisualStyleBackColor = true;
            // 
            // chk供应商应开增值税
            // 
            this.chk供应商应开增值税.AutoSize = true;
            this.chk供应商应开增值税.Checked = true;
            this.chk供应商应开增值税.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk供应商应开增值税.Location = new System.Drawing.Point(235, 39);
            this.chk供应商应开增值税.Name = "chk供应商应开增值税";
            this.chk供应商应开增值税.Size = new System.Drawing.Size(120, 16);
            this.chk供应商应开增值税.TabIndex = 6;
            this.chk供应商应开增值税.Text = "供应商应开增值税";
            this.chk供应商应开增值税.UseVisualStyleBackColor = true;
            // 
            // chk供应商增值税发票
            // 
            this.chk供应商增值税发票.AutoSize = true;
            this.chk供应商增值税发票.Checked = true;
            this.chk供应商增值税发票.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk供应商增值税发票.Location = new System.Drawing.Point(367, 39);
            this.chk供应商增值税发票.Name = "chk供应商增值税发票";
            this.chk供应商增值税发票.Size = new System.Drawing.Size(120, 16);
            this.chk供应商增值税发票.TabIndex = 7;
            this.chk供应商增值税发票.Text = "供应商增值税发票";
            this.chk供应商增值税发票.UseVisualStyleBackColor = true;
            // 
            // chk客户增值税发票
            // 
            this.chk客户增值税发票.AutoSize = true;
            this.chk客户增值税发票.Checked = true;
            this.chk客户增值税发票.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk客户增值税发票.Location = new System.Drawing.Point(367, 8);
            this.chk客户增值税发票.Name = "chk客户增值税发票";
            this.chk客户增值税发票.Size = new System.Drawing.Size(108, 16);
            this.chk客户增值税发票.TabIndex = 3;
            this.chk客户增值税发票.Text = "客户增值税发票";
            this.chk客户增值税发票.UseVisualStyleBackColor = true;
            // 
            // chk供应商付款
            // 
            this.chk供应商付款.AutoSize = true;
            this.chk供应商付款.Checked = true;
            this.chk供应商付款.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk供应商付款.Location = new System.Drawing.Point(113, 39);
            this.chk供应商付款.Name = "chk供应商付款";
            this.chk供应商付款.Size = new System.Drawing.Size(84, 16);
            this.chk供应商付款.TabIndex = 5;
            this.chk供应商付款.Text = "供应商付款";
            this.chk供应商付款.UseVisualStyleBackColor = true;
            // 
            // chk客户收款
            // 
            this.chk客户收款.AutoSize = true;
            this.chk客户收款.Checked = true;
            this.chk客户收款.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk客户收款.Location = new System.Drawing.Point(235, 8);
            this.chk客户收款.Name = "chk客户收款";
            this.chk客户收款.Size = new System.Drawing.Size(72, 16);
            this.chk客户收款.TabIndex = 2;
            this.chk客户收款.Text = "客户收款";
            this.chk客户收款.UseVisualStyleBackColor = true;
            // 
            // chk退款
            // 
            this.chk退款.AutoSize = true;
            this.chk退款.Checked = true;
            this.chk退款.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk退款.Location = new System.Drawing.Point(235, 70);
            this.chk退款.Name = "chk退款";
            this.chk退款.Size = new System.Drawing.Size(48, 16);
            this.chk退款.TabIndex = 10;
            this.chk退款.Text = "退款";
            this.chk退款.UseVisualStyleBackColor = true;
            // 
            // chk账户转账
            // 
            this.chk账户转账.AutoSize = true;
            this.chk账户转账.Checked = true;
            this.chk账户转账.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk账户转账.Location = new System.Drawing.Point(367, 70);
            this.chk账户转账.Name = "chk账户转账";
            this.chk账户转账.Size = new System.Drawing.Size(72, 16);
            this.chk账户转账.TabIndex = 11;
            this.chk账户转账.Text = "账户转账";
            this.chk账户转账.UseVisualStyleBackColor = true;
            // 
            // chk其它收款
            // 
            this.chk其它收款.AutoSize = true;
            this.chk其它收款.Checked = true;
            this.chk其它收款.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk其它收款.Location = new System.Drawing.Point(111, 70);
            this.chk其它收款.Name = "chk其它收款";
            this.chk其它收款.Size = new System.Drawing.Size(72, 16);
            this.chk其它收款.TabIndex = 9;
            this.chk其它收款.Text = "其它收款";
            this.chk其它收款.UseVisualStyleBackColor = true;
            // 
            // chk公司管理费用
            // 
            this.chk公司管理费用.AutoSize = true;
            this.chk公司管理费用.Checked = true;
            this.chk公司管理费用.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk公司管理费用.Location = new System.Drawing.Point(9, 70);
            this.chk公司管理费用.Name = "chk公司管理费用";
            this.chk公司管理费用.Size = new System.Drawing.Size(96, 16);
            this.chk公司管理费用.TabIndex = 8;
            this.chk公司管理费用.Text = "公司管理费用";
            this.chk公司管理费用.UseVisualStyleBackColor = true;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Location = new System.Drawing.Point(257, 46);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 54;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // pnlDocType
            // 
            this.pnlDocType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDocType.Controls.Add(this.chk送货单);
            this.pnlDocType.Controls.Add(this.chk客户应收款);
            this.pnlDocType.Controls.Add(this.chk供应商应付款);
            this.pnlDocType.Controls.Add(this.chk公司管理费用);
            this.pnlDocType.Controls.Add(this.chk客户应开增值税);
            this.pnlDocType.Controls.Add(this.chk退款);
            this.pnlDocType.Controls.Add(this.chk供应商应开增值税);
            this.pnlDocType.Controls.Add(this.chk账户转账);
            this.pnlDocType.Controls.Add(this.chk客户收款);
            this.pnlDocType.Controls.Add(this.chk其它收款);
            this.pnlDocType.Controls.Add(this.chk供应商付款);
            this.pnlDocType.Controls.Add(this.chk供应商增值税发票);
            this.pnlDocType.Controls.Add(this.chk客户增值税发票);
            this.pnlDocType.Location = new System.Drawing.Point(278, 5);
            this.pnlDocType.Name = "pnlDocType";
            this.pnlDocType.Size = new System.Drawing.Size(634, 95);
            this.pnlDocType.TabIndex = 55;
            // 
            // chk送货单
            // 
            this.chk送货单.AutoSize = true;
            this.chk送货单.Checked = true;
            this.chk送货单.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk送货单.Location = new System.Drawing.Point(493, 70);
            this.chk送货单.Name = "chk送货单";
            this.chk送货单.Size = new System.Drawing.Size(60, 16);
            this.chk送货单.TabIndex = 12;
            this.chk送货单.Text = "送货单";
            this.chk送货单.UseVisualStyleBackColor = true;
            // 
            // Frm作废单据报表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 392);
            this.Controls.Add(this.pnlDocType);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm作废单据报表";
            this.Text = "单据作废记录报表";
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnSaveAs, 0);
            this.Controls.SetChildIndex(this.btnColumn, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.chkAll, 0);
            this.Controls.SetChildIndex(this.pnlDocType, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlDocType.ResumeLayout(false);
            this.pnlDocType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private GeneralLibrary.WinformControl.UCDateTimeInterval ucDateTimeInterval1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col作废日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn col单据类别;
        private System.Windows.Forms.DataGridViewLinkColumn colSheetID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col操作员;
        private System.Windows.Forms.DataGridViewTextBoxColumn col作废原因;
        private System.Windows.Forms.CheckBox chk客户应收款;
        private System.Windows.Forms.CheckBox chk供应商应付款;
        private System.Windows.Forms.CheckBox chk客户应开增值税;
        private System.Windows.Forms.CheckBox chk供应商应开增值税;
        private System.Windows.Forms.CheckBox chk供应商增值税发票;
        private System.Windows.Forms.CheckBox chk客户增值税发票;
        private System.Windows.Forms.CheckBox chk供应商付款;
        private System.Windows.Forms.CheckBox chk客户收款;
        private System.Windows.Forms.CheckBox chk退款;
        private System.Windows.Forms.CheckBox chk账户转账;
        private System.Windows.Forms.CheckBox chk其它收款;
        private System.Windows.Forms.CheckBox chk公司管理费用;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Panel pnlDocType;
        private System.Windows.Forms.CheckBox chk送货单;
    }
}