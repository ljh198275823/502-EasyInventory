namespace LJH.Inventory.UI.Forms.Financial.Report
{
    partial class FrmCustomerPaymentReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucDateTimeInterval1 = new LJH.GeneralLibrary.WinformControl.UCDateTimeInterval();
            this.lnkCustomer = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkl转账 = new System.Windows.Forms.CheckBox();
            this.chk转公账 = new System.Windows.Forms.CheckBox();
            this.chk退款 = new System.Windows.Forms.CheckBox();
            this.chk费用支出 = new System.Windows.Forms.CheckBox();
            this.chk其它收款 = new System.Windows.Forms.CheckBox();
            this.txtAccount = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkAccout = new System.Windows.Forms.LinkLabel();
            this.chk供应商付款 = new System.Windows.Forms.CheckBox();
            this.chk客户收款 = new System.Windows.Forms.CheckBox();
            this.txtSupplier = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkSupplier = new System.Windows.Forms.LinkLabel();
            this.txtCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSheetDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSheetID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colPaymentMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssigned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStackSheetID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col到款日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col作废原因 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1022, 8);
            this.btnSearch.Size = new System.Drawing.Size(142, 23);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(1022, 37);
            this.btnSaveAs.Size = new System.Drawing.Size(142, 23);
            // 
            // btnColumn
            // 
            this.btnColumn.Location = new System.Drawing.Point(1022, 66);
            this.btnColumn.Size = new System.Drawing.Size(142, 23);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucDateTimeInterval1);
            this.groupBox1.Location = new System.Drawing.Point(5, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 90);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "录单日期";
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
            // lnkCustomer
            // 
            this.lnkCustomer.AutoSize = true;
            this.lnkCustomer.Location = new System.Drawing.Point(12, 25);
            this.lnkCustomer.Name = "lnkCustomer";
            this.lnkCustomer.Size = new System.Drawing.Size(29, 12);
            this.lnkCustomer.TabIndex = 33;
            this.lnkCustomer.TabStop = true;
            this.lnkCustomer.Text = "客户";
            this.lnkCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomer_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkAll);
            this.groupBox3.Controls.Add(this.chkl转账);
            this.groupBox3.Controls.Add(this.chk转公账);
            this.groupBox3.Controls.Add(this.chk退款);
            this.groupBox3.Controls.Add(this.chk费用支出);
            this.groupBox3.Controls.Add(this.chk其它收款);
            this.groupBox3.Controls.Add(this.txtAccount);
            this.groupBox3.Controls.Add(this.lnkAccout);
            this.groupBox3.Controls.Add(this.chk供应商付款);
            this.groupBox3.Controls.Add(this.chk客户收款);
            this.groupBox3.Controls.Add(this.txtSupplier);
            this.groupBox3.Controls.Add(this.lnkSupplier);
            this.groupBox3.Controls.Add(this.txtCustomer);
            this.groupBox3.Controls.Add(this.lnkCustomer);
            this.groupBox3.Location = new System.Drawing.Point(242, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(761, 90);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其它";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Location = new System.Drawing.Point(456, 26);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 108;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkl转账
            // 
            this.chkl转账.AutoSize = true;
            this.chkl转账.Checked = true;
            this.chkl转账.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkl转账.Location = new System.Drawing.Point(543, 56);
            this.chkl转账.Name = "chkl转账";
            this.chkl转账.Size = new System.Drawing.Size(48, 16);
            this.chkl转账.TabIndex = 107;
            this.chkl转账.Text = "转账";
            this.chkl转账.UseVisualStyleBackColor = true;
            // 
            // chk转公账
            // 
            this.chk转公账.AutoSize = true;
            this.chk转公账.Checked = true;
            this.chk转公账.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk转公账.Location = new System.Drawing.Point(477, 56);
            this.chk转公账.Name = "chk转公账";
            this.chk转公账.Size = new System.Drawing.Size(60, 16);
            this.chk转公账.TabIndex = 106;
            this.chk转公账.Text = "转公账";
            this.chk转公账.UseVisualStyleBackColor = true;
            // 
            // chk退款
            // 
            this.chk退款.AutoSize = true;
            this.chk退款.Checked = true;
            this.chk退款.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk退款.Location = new System.Drawing.Point(672, 55);
            this.chk退款.Name = "chk退款";
            this.chk退款.Size = new System.Drawing.Size(48, 16);
            this.chk退款.TabIndex = 105;
            this.chk退款.Text = "退款";
            this.chk退款.UseVisualStyleBackColor = true;
            // 
            // chk费用支出
            // 
            this.chk费用支出.AutoSize = true;
            this.chk费用支出.Checked = true;
            this.chk费用支出.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk费用支出.Location = new System.Drawing.Point(594, 56);
            this.chk费用支出.Name = "chk费用支出";
            this.chk费用支出.Size = new System.Drawing.Size(72, 16);
            this.chk费用支出.TabIndex = 104;
            this.chk费用支出.Text = "费用支出";
            this.chk费用支出.UseVisualStyleBackColor = true;
            // 
            // chk其它收款
            // 
            this.chk其它收款.AutoSize = true;
            this.chk其它收款.Checked = true;
            this.chk其它收款.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk其它收款.Location = new System.Drawing.Point(648, 25);
            this.chk其它收款.Name = "chk其它收款";
            this.chk其它收款.Size = new System.Drawing.Size(72, 16);
            this.chk其它收款.TabIndex = 103;
            this.chk其它收款.Text = "其它收款";
            this.chk其它收款.UseVisualStyleBackColor = true;
            // 
            // txtAccount
            // 
            this.txtAccount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAccount.Location = new System.Drawing.Point(275, 21);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.ReadOnly = true;
            this.txtAccount.Size = new System.Drawing.Size(163, 21);
            this.txtAccount.TabIndex = 102;
            this.txtAccount.DoubleClick += new System.EventHandler(this.txtAccount_DoubleClick);
            // 
            // lnkAccout
            // 
            this.lnkAccout.Location = new System.Drawing.Point(210, 23);
            this.lnkAccout.Name = "lnkAccout";
            this.lnkAccout.Size = new System.Drawing.Size(60, 17);
            this.lnkAccout.TabIndex = 101;
            this.lnkAccout.TabStop = true;
            this.lnkAccout.Text = "到款账号";
            this.lnkAccout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkAccout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAccout_LinkClicked);
            // 
            // chk供应商付款
            // 
            this.chk供应商付款.AutoSize = true;
            this.chk供应商付款.Checked = true;
            this.chk供应商付款.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk供应商付款.Location = new System.Drawing.Point(558, 25);
            this.chk供应商付款.Name = "chk供应商付款";
            this.chk供应商付款.Size = new System.Drawing.Size(84, 16);
            this.chk供应商付款.TabIndex = 76;
            this.chk供应商付款.Text = "供应商付款";
            this.chk供应商付款.UseVisualStyleBackColor = true;
            // 
            // chk客户收款
            // 
            this.chk客户收款.AutoSize = true;
            this.chk客户收款.Checked = true;
            this.chk客户收款.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk客户收款.Location = new System.Drawing.Point(477, 25);
            this.chk客户收款.Name = "chk客户收款";
            this.chk客户收款.Size = new System.Drawing.Size(72, 16);
            this.chk客户收款.TabIndex = 75;
            this.chk客户收款.Text = "客户收款";
            this.chk客户收款.UseVisualStyleBackColor = true;
            // 
            // txtSupplier
            // 
            this.txtSupplier.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSupplier.Location = new System.Drawing.Point(48, 53);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(153, 21);
            this.txtSupplier.TabIndex = 74;
            this.txtSupplier.DoubleClick += new System.EventHandler(this.txtSupplier_DoubleClick);
            // 
            // lnkSupplier
            // 
            this.lnkSupplier.AutoSize = true;
            this.lnkSupplier.Location = new System.Drawing.Point(6, 57);
            this.lnkSupplier.Name = "lnkSupplier";
            this.lnkSupplier.Size = new System.Drawing.Size(41, 12);
            this.lnkSupplier.TabIndex = 73;
            this.lnkSupplier.TabStop = true;
            this.lnkSupplier.Text = "供应商";
            this.lnkSupplier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSupplier_LinkClicked);
            // 
            // txtCustomer
            // 
            this.txtCustomer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCustomer.Location = new System.Drawing.Point(48, 21);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(153, 21);
            this.txtCustomer.TabIndex = 37;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
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
            this.colSheetDate,
            this.colClass,
            this.colSheetID,
            this.colPaymentMode,
            this.colAccount,
            this.colPayer,
            this.colAmount,
            this.colAssigned,
            this.colRemain,
            this.colCustomer,
            this.colStackSheetID,
            this.col到款日期,
            this.colMemo,
            this.col作废原因});
            this.dataGridView1.Location = new System.Drawing.Point(5, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1212, 439);
            this.dataGridView1.TabIndex = 39;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colSheetDate
            // 
            dataGridViewCellStyle1.Format = "D";
            dataGridViewCellStyle1.NullValue = null;
            this.colSheetDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colSheetDate.HeaderText = "录单日期";
            this.colSheetDate.Name = "colSheetDate";
            this.colSheetDate.ReadOnly = true;
            this.colSheetDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colClass
            // 
            this.colClass.HeaderText = "类别";
            this.colClass.Name = "colClass";
            this.colClass.ReadOnly = true;
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
            // colPaymentMode
            // 
            this.colPaymentMode.HeaderText = "付款方式";
            this.colPaymentMode.Name = "colPaymentMode";
            this.colPaymentMode.ReadOnly = true;
            this.colPaymentMode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPaymentMode.Width = 80;
            // 
            // colAccount
            // 
            this.colAccount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAccount.HeaderText = "公司账号";
            this.colAccount.MinimumWidth = 100;
            this.colAccount.Name = "colAccount";
            this.colAccount.ReadOnly = true;
            // 
            // colPayer
            // 
            this.colPayer.HeaderText = "对方账号";
            this.colPayer.Name = "colPayer";
            this.colPayer.ReadOnly = true;
            // 
            // colAmount
            // 
            dataGridViewCellStyle2.Format = "C2";
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAmount.HeaderText = "金额";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAssigned
            // 
            dataGridViewCellStyle3.Format = "C2";
            this.colAssigned.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAssigned.HeaderText = "核销";
            this.colAssigned.Name = "colAssigned";
            this.colAssigned.ReadOnly = true;
            this.colAssigned.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAssigned.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colRemain
            // 
            dataGridViewCellStyle4.Format = "C2";
            this.colRemain.DefaultCellStyle = dataGridViewCellStyle4;
            this.colRemain.HeaderText = "未核销";
            this.colRemain.Name = "colRemain";
            this.colRemain.ReadOnly = true;
            // 
            // colCustomer
            // 
            this.colCustomer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colCustomer.HeaderText = "客户";
            this.colCustomer.MinimumWidth = 100;
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            // 
            // colStackSheetID
            // 
            this.colStackSheetID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colStackSheetID.HeaderText = "送货单";
            this.colStackSheetID.MinimumWidth = 100;
            this.colStackSheetID.Name = "colStackSheetID";
            this.colStackSheetID.ReadOnly = true;
            this.colStackSheetID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStackSheetID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col到款日期
            // 
            this.col到款日期.HeaderText = "到款日期";
            this.col到款日期.Name = "col到款日期";
            this.col到款日期.ReadOnly = true;
            // 
            // colMemo
            // 
            this.colMemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMemo.HeaderText = "备注";
            this.colMemo.MinimumWidth = 100;
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            this.colMemo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col作废原因
            // 
            this.col作废原因.HeaderText = "作废原因";
            this.col作废原因.Name = "col作废原因";
            this.col作废原因.ReadOnly = true;
            // 
            // FrmCustomerPaymentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 566);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "FrmCustomerPaymentReport";
            this.Text = "收付款流水报表";
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnSaveAs, 0);
            this.Controls.SetChildIndex(this.btnColumn, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private GeneralLibrary.WinformControl.UCDateTimeInterval ucDateTimeInterval1;
        private System.Windows.Forms.LinkLabel lnkCustomer;
        private System.Windows.Forms.GroupBox groupBox3;
        private GeneralLibrary.WinformControl.DBCTextBox txtCustomer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private GeneralLibrary.WinformControl.DBCTextBox txtSupplier;
        private System.Windows.Forms.LinkLabel lnkSupplier;
        private System.Windows.Forms.CheckBox chk供应商付款;
        private System.Windows.Forms.CheckBox chk客户收款;
        private GeneralLibrary.WinformControl.DBCTextBox txtAccount;
        private System.Windows.Forms.LinkLabel lnkAccout;
        private System.Windows.Forms.CheckBox chk费用支出;
        private System.Windows.Forms.CheckBox chk其它收款;
        private System.Windows.Forms.CheckBox chk退款;
        private System.Windows.Forms.CheckBox chkl转账;
        private System.Windows.Forms.CheckBox chk转公账;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSheetDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClass;
        private System.Windows.Forms.DataGridViewLinkColumn colSheetID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssigned;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemain;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStackSheetID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col到款日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col作废原因;
    }
}