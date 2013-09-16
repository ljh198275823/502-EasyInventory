﻿namespace LJH.Inventory.UI.Forms
{
    partial class FrmCustomerOtherReceivableDetail
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
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtAmount = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtCurrencyType = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkCurrencyType = new System.Windows.Forms.LinkLabel();
            this.txtCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkCustomer = new System.Windows.Forms.LinkLabel();
            this.txtID = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtCreateDate = new System.Windows.Forms.DateTimePicker();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colOperateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(428, 195);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(317, 195);
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(72, 108);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(371, 21);
            this.txtMemo.TabIndex = 44;
            // 
            // txtAmount
            // 
            this.txtAmount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAmount.Location = new System.Drawing.Point(320, 77);
            this.txtAmount.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtAmount.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PointCount = 2;
            this.txtAmount.Size = new System.Drawing.Size(164, 21);
            this.txtAmount.TabIndex = 41;
            this.txtAmount.Text = "0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 50;
            this.label5.Text = "备注";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(506, 168);
            this.tabControl1.TabIndex = 91;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtCurrencyType);
            this.tabPage1.Controls.Add(this.txtAmount);
            this.tabPage1.Controls.Add(this.txtMemo);
            this.tabPage1.Controls.Add(this.lnkCurrencyType);
            this.tabPage1.Controls.Add(this.txtCustomer);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lnkCustomer);
            this.tabPage1.Controls.Add(this.txtID);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dtCreateDate);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(498, 142);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本资料";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtCurrencyType
            // 
            this.txtCurrencyType.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCurrencyType.Location = new System.Drawing.Point(72, 77);
            this.txtCurrencyType.Name = "txtCurrencyType";
            this.txtCurrencyType.Size = new System.Drawing.Size(165, 21);
            this.txtCurrencyType.TabIndex = 120;
            // 
            // lnkCurrencyType
            // 
            this.lnkCurrencyType.AutoSize = true;
            this.lnkCurrencyType.Location = new System.Drawing.Point(37, 81);
            this.lnkCurrencyType.Name = "lnkCurrencyType";
            this.lnkCurrencyType.Size = new System.Drawing.Size(29, 12);
            this.lnkCurrencyType.TabIndex = 119;
            this.lnkCurrencyType.TabStop = true;
            this.lnkCurrencyType.Text = "币别";
            this.lnkCurrencyType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCurrencyType_LinkClicked);
            // 
            // txtCustomer
            // 
            this.txtCustomer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCustomer.Location = new System.Drawing.Point(72, 43);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(413, 21);
            this.txtCustomer.TabIndex = 6;
            // 
            // lnkCustomer
            // 
            this.lnkCustomer.AutoSize = true;
            this.lnkCustomer.Location = new System.Drawing.Point(37, 47);
            this.lnkCustomer.Name = "lnkCustomer";
            this.lnkCustomer.Size = new System.Drawing.Size(29, 12);
            this.lnkCustomer.TabIndex = 108;
            this.lnkCustomer.TabStop = true;
            this.lnkCustomer.Text = "客户";
            this.lnkCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomer_LinkClicked);
            // 
            // txtID
            // 
            this.txtID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtID.Location = new System.Drawing.Point(71, 13);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(164, 21);
            this.txtID.TabIndex = 91;
            this.txtID.Text = "自动创建";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 92;
            this.label11.Text = "支出单号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(285, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "金额";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "创建日期";
            // 
            // dtCreateDate
            // 
            this.dtCreateDate.Location = new System.Drawing.Point(320, 13);
            this.dtCreateDate.Name = "dtCreateDate";
            this.dtCreateDate.Size = new System.Drawing.Size(164, 21);
            this.dtCreateDate.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(498, 142);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "相关文档";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(498, 142);
            this.tabPage2.TabIndex = 6;
            this.tabPage2.Text = "操作记录";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOperateDate,
            this.colOperation,
            this.colOperator,
            this.colFill});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(498, 142);
            this.dataGridView1.TabIndex = 98;
            // 
            // colOperateDate
            // 
            this.colOperateDate.HeaderText = "操作时间";
            this.colOperateDate.Name = "colOperateDate";
            this.colOperateDate.ReadOnly = true;
            this.colOperateDate.Width = 130;
            // 
            // colOperation
            // 
            this.colOperation.HeaderText = "操作";
            this.colOperation.Name = "colOperation";
            this.colOperation.ReadOnly = true;
            this.colOperation.Width = 200;
            // 
            // colOperator
            // 
            this.colOperator.HeaderText = "操作员";
            this.colOperator.Name = "colOperator";
            this.colOperator.ReadOnly = true;
            this.colOperator.Width = 150;
            // 
            // colFill
            // 
            this.colFill.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFill.HeaderText = "";
            this.colFill.Name = "colFill";
            this.colFill.ReadOnly = true;
            // 
            // FrmCustomerOtherReceivableDetail
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(514, 230);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmCustomerOtherReceivableDetail";
            this.Text = "其它应收款明细";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private GeneralLibrary.WinformControl.DBCTextBox txtCurrencyType;
        private System.Windows.Forms.LinkLabel lnkCurrencyType;
        private GeneralLibrary.WinformControl.DBCTextBox txtCustomer;
        private System.Windows.Forms.LinkLabel lnkCustomer;
        private GeneralLibrary.WinformControl.DBCTextBox txtID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtCreateDate;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFill;
    }
}