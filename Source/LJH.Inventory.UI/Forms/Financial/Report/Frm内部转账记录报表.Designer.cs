namespace LJH.Inventory.UI.Forms.Financial.Report
{
    partial class Frm内部转账记录报表
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucDateTimeInterval1 = new LJH.GeneralLibrary.WinformControl.UCDateTimeInterval();
            this.lnkCustomer = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt转出账号 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnk转出账号 = new System.Windows.Forms.LinkLabel();
            this.txt转入账号 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnk转入账号 = new System.Windows.Forms.LinkLabel();
            this.txtSupplier = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkSupplier = new System.Windows.Forms.LinkLabel();
            this.txtCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSheetDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSheetID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnSearch.Location = new System.Drawing.Point(752, 16);
            this.btnSearch.Size = new System.Drawing.Size(165, 23);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(752, 45);
            this.btnSaveAs.Size = new System.Drawing.Size(165, 23);
            // 
            // btnColumn
            // 
            this.btnColumn.Location = new System.Drawing.Point(752, 74);
            this.btnColumn.Size = new System.Drawing.Size(165, 23);
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
            this.groupBox3.Controls.Add(this.txt转出账号);
            this.groupBox3.Controls.Add(this.lnk转出账号);
            this.groupBox3.Controls.Add(this.txt转入账号);
            this.groupBox3.Controls.Add(this.lnk转入账号);
            this.groupBox3.Controls.Add(this.txtSupplier);
            this.groupBox3.Controls.Add(this.lnkSupplier);
            this.groupBox3.Controls.Add(this.txtCustomer);
            this.groupBox3.Controls.Add(this.lnkCustomer);
            this.groupBox3.Location = new System.Drawing.Point(243, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(492, 90);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其它";
            // 
            // txt转出账号
            // 
            this.txt转出账号.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txt转出账号.Location = new System.Drawing.Point(300, 53);
            this.txt转出账号.Name = "txt转出账号";
            this.txt转出账号.ReadOnly = true;
            this.txt转出账号.Size = new System.Drawing.Size(182, 21);
            this.txt转出账号.TabIndex = 104;
            this.txt转出账号.DoubleClick += new System.EventHandler(this.txt转出账号_DoubleClick);
            // 
            // lnk转出账号
            // 
            this.lnk转出账号.AutoSize = true;
            this.lnk转出账号.Location = new System.Drawing.Point(241, 57);
            this.lnk转出账号.Name = "lnk转出账号";
            this.lnk转出账号.Size = new System.Drawing.Size(53, 12);
            this.lnk转出账号.TabIndex = 103;
            this.lnk转出账号.TabStop = true;
            this.lnk转出账号.Text = "转出账号";
            this.lnk转出账号.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnk转出账号.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk转出账号_LinkClicked);
            // 
            // txt转入账号
            // 
            this.txt转入账号.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txt转入账号.Location = new System.Drawing.Point(300, 22);
            this.txt转入账号.Name = "txt转入账号";
            this.txt转入账号.ReadOnly = true;
            this.txt转入账号.Size = new System.Drawing.Size(182, 21);
            this.txt转入账号.TabIndex = 102;
            this.txt转入账号.DoubleClick += new System.EventHandler(this.txtAccount_DoubleClick);
            // 
            // lnk转入账号
            // 
            this.lnk转入账号.AutoSize = true;
            this.lnk转入账号.Location = new System.Drawing.Point(241, 26);
            this.lnk转入账号.Name = "lnk转入账号";
            this.lnk转入账号.Size = new System.Drawing.Size(53, 12);
            this.lnk转入账号.TabIndex = 101;
            this.lnk转入账号.TabStop = true;
            this.lnk转入账号.Text = "转入账号";
            this.lnk转入账号.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnk转入账号.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAccout_LinkClicked);
            // 
            // txtSupplier
            // 
            this.txtSupplier.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSupplier.Location = new System.Drawing.Point(48, 53);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(177, 21);
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
            this.txtCustomer.Size = new System.Drawing.Size(177, 21);
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
            this.colSheetID,
            this.colClass,
            this.colAccount,
            this.colPayer,
            this.colAmount,
            this.colCustomer,
            this.col到款日期,
            this.colMemo,
            this.col作废原因});
            this.dataGridView1.Location = new System.Drawing.Point(5, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1347, 437);
            this.dataGridView1.TabIndex = 39;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colSheetDate
            // 
            dataGridViewCellStyle3.Format = "D";
            dataGridViewCellStyle3.NullValue = null;
            this.colSheetDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colSheetDate.HeaderText = "录单日期";
            this.colSheetDate.Name = "colSheetDate";
            this.colSheetDate.ReadOnly = true;
            this.colSheetDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // colClass
            // 
            this.colClass.HeaderText = "类别";
            this.colClass.Name = "colClass";
            this.colClass.ReadOnly = true;
            // 
            // colAccount
            // 
            this.colAccount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAccount.HeaderText = "转入账号";
            this.colAccount.MinimumWidth = 100;
            this.colAccount.Name = "colAccount";
            this.colAccount.ReadOnly = true;
            // 
            // colPayer
            // 
            this.colPayer.HeaderText = "转出账号";
            this.colPayer.Name = "colPayer";
            this.colPayer.ReadOnly = true;
            // 
            // colAmount
            // 
            dataGridViewCellStyle4.Format = "C2";
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAmount.HeaderText = "金额";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCustomer
            // 
            this.colCustomer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colCustomer.HeaderText = "客户";
            this.colCustomer.MinimumWidth = 100;
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
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
            // Frm内部转账记录报表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 566);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "Frm内部转账记录报表";
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
        private GeneralLibrary.WinformControl.DBCTextBox txt转入账号;
        private System.Windows.Forms.LinkLabel lnk转入账号;
        private GeneralLibrary.WinformControl.DBCTextBox txt转出账号;
        private System.Windows.Forms.LinkLabel lnk转出账号;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSheetDate;
        private System.Windows.Forms.DataGridViewLinkColumn colSheetID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn col到款日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col作废原因;
    }
}