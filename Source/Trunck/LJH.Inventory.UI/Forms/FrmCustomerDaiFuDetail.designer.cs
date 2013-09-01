namespace LJH.Inventory.UI.Forms
{
    partial class FrmCustomerDaiFuDetail
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
            this.rdCheck = new System.Windows.Forms.RadioButton();
            this.rdCash = new System.Windows.Forms.RadioButton();
            this.rdTransfer = new System.Windows.Forms.RadioButton();
            this.dtPaidDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCheckNum = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtCustomer = new LJH.Inventory.UI.Controls.CustomerCombobox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(355, 158);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(244, 158);
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(64, 111);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(371, 21);
            this.txtMemo.TabIndex = 44;
            // 
            // txtAmount
            // 
            this.txtAmount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAmount.Location = new System.Drawing.Point(307, 43);
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
            this.txtAmount.TabIndex = 41;
            this.txtAmount.Text = "0.00";
            // 
            // rdCheck
            // 
            this.rdCheck.AutoSize = true;
            this.rdCheck.Location = new System.Drawing.Point(174, 44);
            this.rdCheck.Name = "rdCheck";
            this.rdCheck.Size = new System.Drawing.Size(47, 16);
            this.rdCheck.TabIndex = 40;
            this.rdCheck.Text = "支票";
            this.rdCheck.UseVisualStyleBackColor = true;
            // 
            // rdCash
            // 
            this.rdCash.AutoSize = true;
            this.rdCash.Location = new System.Drawing.Point(121, 44);
            this.rdCash.Name = "rdCash";
            this.rdCash.Size = new System.Drawing.Size(47, 16);
            this.rdCash.TabIndex = 39;
            this.rdCash.Text = "现金";
            this.rdCash.UseVisualStyleBackColor = true;
            // 
            // rdTransfer
            // 
            this.rdTransfer.AutoSize = true;
            this.rdTransfer.Checked = true;
            this.rdTransfer.Location = new System.Drawing.Point(64, 44);
            this.rdTransfer.Name = "rdTransfer";
            this.rdTransfer.Size = new System.Drawing.Size(47, 16);
            this.rdTransfer.TabIndex = 38;
            this.rdTransfer.TabStop = true;
            this.rdTransfer.Text = "转账";
            this.rdTransfer.UseVisualStyleBackColor = true;
            // 
            // dtPaidDate
            // 
            this.dtPaidDate.Location = new System.Drawing.Point(307, 77);
            this.dtPaidDate.Name = "dtPaidDate";
            this.dtPaidDate.Size = new System.Drawing.Size(128, 21);
            this.dtPaidDate.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 50;
            this.label5.Text = "备注";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 49;
            this.label6.Text = "支票号";
            // 
            // txtCheckNum
            // 
            this.txtCheckNum.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCheckNum.Location = new System.Drawing.Point(64, 77);
            this.txtCheckNum.Name = "txtCheckNum";
            this.txtCheckNum.Size = new System.Drawing.Size(164, 21);
            this.txtCheckNum.TabIndex = 42;
            // 
            // txtCustomer
            // 
            this.txtCustomer.FormattingEnabled = true;
            this.txtCustomer.Location = new System.Drawing.Point(64, 11);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(164, 20);
            this.txtCustomer.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(251, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 48;
            this.label7.Text = "代付日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 47;
            this.label2.Text = "代付金额";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 46;
            this.label3.Text = "代付方式";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "客户";
            // 
            // FrmCustomerDaiFuDetail
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(441, 193);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.rdCheck);
            this.Controls.Add(this.rdCash);
            this.Controls.Add(this.rdTransfer);
            this.Controls.Add(this.dtPaidDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCheckNum);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FrmCustomerDaiFuDetail";
            this.Text = "代付款";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtCustomer, 0);
            this.Controls.SetChildIndex(this.txtCheckNum, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.dtPaidDate, 0);
            this.Controls.SetChildIndex(this.rdTransfer, 0);
            this.Controls.SetChildIndex(this.rdCash, 0);
            this.Controls.SetChildIndex(this.rdCheck, 0);
            this.Controls.SetChildIndex(this.txtAmount, 0);
            this.Controls.SetChildIndex(this.txtMemo, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtAmount;
        private System.Windows.Forms.RadioButton rdCheck;
        private System.Windows.Forms.RadioButton rdCash;
        private System.Windows.Forms.RadioButton rdTransfer;
        private System.Windows.Forms.DateTimePicker dtPaidDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtCheckNum;
        private Controls.CustomerCombobox txtCustomer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}