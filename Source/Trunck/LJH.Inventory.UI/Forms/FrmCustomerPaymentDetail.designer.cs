namespace LJH.Inventory.UI.Forms
{
    partial class FrmCustomerPaymentDetail
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
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomer = new LJH.Inventory.UI.Controls.CustomerCombobox(this.components);
            this.txtCheckNum = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkPayReceivables = new System.Windows.Forms.CheckBox();
            this.dtPaidDate = new System.Windows.Forms.DateTimePicker();
            this.rdTransfer = new System.Windows.Forms.RadioButton();
            this.rdCash = new System.Windows.Forms.RadioButton();
            this.rdCheck = new System.Windows.Forms.RadioButton();
            this.txtAmount = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtSheetNo = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.btnClose.Location = new System.Drawing.Point(530, 258);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(425, 258);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(256, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 32;
            this.label7.Text = "付款日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "付款金额";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "付款方式";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "客户";
            // 
            // txtCustomer
            // 
            this.txtCustomer.FormattingEnabled = true;
            this.txtCustomer.Location = new System.Drawing.Point(69, 12);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(164, 20);
            this.txtCustomer.TabIndex = 0;
            this.txtCustomer.TextChanged += new System.EventHandler(this.txtCustomer_TextChanged);
            // 
            // txtCheckNum
            // 
            this.txtCheckNum.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCheckNum.Location = new System.Drawing.Point(69, 78);
            this.txtCheckNum.Name = "txtCheckNum";
            this.txtCheckNum.Size = new System.Drawing.Size(164, 21);
            this.txtCheckNum.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 36;
            this.label5.Text = "备注";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 35;
            this.label6.Text = "支票号";
            // 
            // chkPayReceivables
            // 
            this.chkPayReceivables.AutoSize = true;
            this.chkPayReceivables.Location = new System.Drawing.Point(69, 116);
            this.chkPayReceivables.Name = "chkPayReceivables";
            this.chkPayReceivables.Size = new System.Drawing.Size(156, 16);
            this.chkPayReceivables.TabIndex = 9;
            this.chkPayReceivables.Text = "用于抵销客户的应收账款";
            this.chkPayReceivables.UseVisualStyleBackColor = true;
            this.chkPayReceivables.CheckedChanged += new System.EventHandler(this.chkPayReceivables_CheckedChanged);
            // 
            // dtPaidDate
            // 
            this.dtPaidDate.Location = new System.Drawing.Point(312, 78);
            this.dtPaidDate.Name = "dtPaidDate";
            this.dtPaidDate.Size = new System.Drawing.Size(128, 21);
            this.dtPaidDate.TabIndex = 7;
            // 
            // rdTransfer
            // 
            this.rdTransfer.AutoSize = true;
            this.rdTransfer.Checked = true;
            this.rdTransfer.Location = new System.Drawing.Point(69, 45);
            this.rdTransfer.Name = "rdTransfer";
            this.rdTransfer.Size = new System.Drawing.Size(47, 16);
            this.rdTransfer.TabIndex = 2;
            this.rdTransfer.TabStop = true;
            this.rdTransfer.Text = "转账";
            this.rdTransfer.UseVisualStyleBackColor = true;
            // 
            // rdCash
            // 
            this.rdCash.AutoSize = true;
            this.rdCash.Location = new System.Drawing.Point(126, 45);
            this.rdCash.Name = "rdCash";
            this.rdCash.Size = new System.Drawing.Size(47, 16);
            this.rdCash.TabIndex = 3;
            this.rdCash.Text = "现金";
            this.rdCash.UseVisualStyleBackColor = true;
            // 
            // rdCheck
            // 
            this.rdCheck.AutoSize = true;
            this.rdCheck.Location = new System.Drawing.Point(179, 45);
            this.rdCheck.Name = "rdCheck";
            this.rdCheck.Size = new System.Drawing.Size(47, 16);
            this.rdCheck.TabIndex = 4;
            this.rdCheck.Text = "支票";
            this.rdCheck.UseVisualStyleBackColor = true;
            // 
            // txtAmount
            // 
            this.txtAmount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAmount.Location = new System.Drawing.Point(312, 44);
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
            this.txtAmount.Size = new System.Drawing.Size(128, 21);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.Text = "0.00";
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(69, 144);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(371, 21);
            this.txtMemo.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 44;
            this.label4.Text = "抵销应收项";
            // 
            // txtSheetNo
            // 
            this.txtSheetNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSheetNo.FormattingEnabled = true;
            this.txtSheetNo.Location = new System.Drawing.Point(312, 113);
            this.txtSheetNo.Name = "txtSheetNo";
            this.txtSheetNo.Size = new System.Drawing.Size(128, 20);
            this.txtSheetNo.TabIndex = 1;
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
            this.tabControl1.Size = new System.Drawing.Size(610, 236);
            this.tabControl1.TabIndex = 90;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtSheetNo);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtMemo);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtAmount);
            this.tabPage1.Controls.Add(this.txtCustomer);
            this.tabPage1.Controls.Add(this.rdCheck);
            this.tabPage1.Controls.Add(this.txtCheckNum);
            this.tabPage1.Controls.Add(this.rdCash);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.rdTransfer);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.dtPaidDate);
            this.tabPage1.Controls.Add(this.chkPayReceivables);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(602, 210);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本资料";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(602, 347);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "相关文档";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(602, 347);
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
            this.dataGridView1.Size = new System.Drawing.Size(602, 347);
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
            // FrmCustomerPaymentDetail
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(617, 293);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmCustomerPaymentDetail";
            this.Text = "客户还款单";
            this.Load += new System.EventHandler(this.FrmCustomerPaymentDetail_Load);
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

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Controls.CustomerCombobox txtCustomer;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtCheckNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkPayReceivables;
        private System.Windows.Forms.DateTimePicker dtPaidDate;
        private System.Windows.Forms.RadioButton rdTransfer;
        private System.Windows.Forms.RadioButton rdCash;
        private System.Windows.Forms.RadioButton rdCheck;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtAmount;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtSheetNo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFill;
    }
}