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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucDateTimeInterval1 = new LJH.GeneralLibrary.WinformControl.UCDateTimeInterval();
            this.lnkCustomer = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chk支 = new System.Windows.Forms.CheckBox();
            this.chk收 = new System.Windows.Forms.CheckBox();
            this.txtSupplier = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkSupplier = new System.Windows.Forms.LinkLabel();
            this.txtCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSheetDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSheetID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaymentMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssigned = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colRemain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStackSheetID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAccount = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkAccout = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(827, 8);
            this.btnSearch.Size = new System.Drawing.Size(142, 23);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(827, 37);
            this.btnSaveAs.Size = new System.Drawing.Size(142, 23);
            // 
            // btnColumn
            // 
            this.btnColumn.Location = new System.Drawing.Point(827, 66);
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
            this.groupBox1.Text = "付款日期";
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
            this.groupBox3.Controls.Add(this.txtAccount);
            this.groupBox3.Controls.Add(this.lnkAccout);
            this.groupBox3.Controls.Add(this.chk支);
            this.groupBox3.Controls.Add(this.chk收);
            this.groupBox3.Controls.Add(this.txtSupplier);
            this.groupBox3.Controls.Add(this.lnkSupplier);
            this.groupBox3.Controls.Add(this.txtCustomer);
            this.groupBox3.Controls.Add(this.lnkCustomer);
            this.groupBox3.Location = new System.Drawing.Point(242, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(564, 90);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其它";
            // 
            // chk支
            // 
            this.chk支.AutoSize = true;
            this.chk支.Checked = true;
            this.chk支.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk支.Location = new System.Drawing.Point(457, 57);
            this.chk支.Name = "chk支";
            this.chk支.Size = new System.Drawing.Size(72, 16);
            this.chk支.TabIndex = 76;
            this.chk支.Text = "付款流水";
            this.chk支.UseVisualStyleBackColor = true;
            // 
            // chk收
            // 
            this.chk收.AutoSize = true;
            this.chk收.Checked = true;
            this.chk收.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk收.Location = new System.Drawing.Point(456, 23);
            this.chk收.Name = "chk收";
            this.chk收.Size = new System.Drawing.Size(72, 16);
            this.chk收.TabIndex = 75;
            this.chk收.Text = "收款流水";
            this.chk收.UseVisualStyleBackColor = true;
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
            this.colMemo});
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
            dataGridViewCellStyle13.Format = "D";
            dataGridViewCellStyle13.NullValue = null;
            this.colSheetDate.DefaultCellStyle = dataGridViewCellStyle13;
            this.colSheetDate.HeaderText = "日期";
            this.colSheetDate.Name = "colSheetDate";
            this.colSheetDate.ReadOnly = true;
            this.colSheetDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colClass
            // 
            this.colClass.HeaderText = "类别";
            this.colClass.Name = "colClass";
            this.colClass.ReadOnly = true;
            this.colClass.Width = 60;
            // 
            // colSheetID
            // 
            this.colSheetID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSheetID.HeaderText = "单据编号";
            this.colSheetID.MinimumWidth = 100;
            this.colSheetID.Name = "colSheetID";
            this.colSheetID.ReadOnly = true;
            this.colSheetID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSheetID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.colAccount.HeaderText = "到款账号";
            this.colAccount.MinimumWidth = 100;
            this.colAccount.Name = "colAccount";
            this.colAccount.ReadOnly = true;
            // 
            // colPayer
            // 
            this.colPayer.HeaderText = "付款单位";
            this.colPayer.Name = "colPayer";
            this.colPayer.ReadOnly = true;
            // 
            // colAmount
            // 
            dataGridViewCellStyle14.Format = "C2";
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle14;
            this.colAmount.HeaderText = "金额";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAssigned
            // 
            dataGridViewCellStyle15.Format = "C2";
            this.colAssigned.DefaultCellStyle = dataGridViewCellStyle15;
            this.colAssigned.HeaderText = "核销";
            this.colAssigned.Name = "colAssigned";
            this.colAssigned.ReadOnly = true;
            // 
            // colRemain
            // 
            dataGridViewCellStyle16.Format = "C2";
            this.colRemain.DefaultCellStyle = dataGridViewCellStyle16;
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
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnSaveAs, 0);
            this.Controls.SetChildIndex(this.btnColumn, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
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
        private System.Windows.Forms.CheckBox chk支;
        private System.Windows.Forms.CheckBox chk收;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSheetDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSheetID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewLinkColumn colAssigned;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemain;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStackSheetID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        private GeneralLibrary.WinformControl.DBCTextBox txtAccount;
        private System.Windows.Forms.LinkLabel lnkAccout;
    }
}