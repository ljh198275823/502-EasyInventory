namespace LJH.Inventory.UI.Forms.Financial
{
    partial class FrmReceivablesPaid
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtAmount = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.rdCheck = new System.Windows.Forms.RadioButton();
            this.rdCash = new System.Windows.Forms.RadioButton();
            this.rdTransfer = new System.Windows.Forms.RadioButton();
            this.dtPaidDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCheckNum = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReceivable = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 59;
            this.label4.Text = "应收项";
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(63, 109);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(371, 21);
            this.txtMemo.TabIndex = 53;
            // 
            // txtAmount
            // 
            this.txtAmount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAmount.Location = new System.Drawing.Point(306, 44);
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
            this.txtAmount.TabIndex = 50;
            this.txtAmount.Text = "0.00";
            // 
            // rdCheck
            // 
            this.rdCheck.AutoSize = true;
            this.rdCheck.Location = new System.Drawing.Point(173, 45);
            this.rdCheck.Name = "rdCheck";
            this.rdCheck.Size = new System.Drawing.Size(47, 16);
            this.rdCheck.TabIndex = 49;
            this.rdCheck.Text = "支票";
            this.rdCheck.UseVisualStyleBackColor = true;
            // 
            // rdCash
            // 
            this.rdCash.AutoSize = true;
            this.rdCash.Location = new System.Drawing.Point(120, 45);
            this.rdCash.Name = "rdCash";
            this.rdCash.Size = new System.Drawing.Size(47, 16);
            this.rdCash.TabIndex = 48;
            this.rdCash.Text = "现金";
            this.rdCash.UseVisualStyleBackColor = true;
            // 
            // rdTransfer
            // 
            this.rdTransfer.AutoSize = true;
            this.rdTransfer.Checked = true;
            this.rdTransfer.Location = new System.Drawing.Point(63, 45);
            this.rdTransfer.Name = "rdTransfer";
            this.rdTransfer.Size = new System.Drawing.Size(47, 16);
            this.rdTransfer.TabIndex = 47;
            this.rdTransfer.TabStop = true;
            this.rdTransfer.Text = "转账";
            this.rdTransfer.UseVisualStyleBackColor = true;
            // 
            // dtPaidDate
            // 
            this.dtPaidDate.Location = new System.Drawing.Point(306, 78);
            this.dtPaidDate.Name = "dtPaidDate";
            this.dtPaidDate.Size = new System.Drawing.Size(128, 21);
            this.dtPaidDate.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 58;
            this.label5.Text = "备注";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 57;
            this.label6.Text = "支票号";
            // 
            // txtCheckNum
            // 
            this.txtCheckNum.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCheckNum.Location = new System.Drawing.Point(63, 78);
            this.txtCheckNum.Name = "txtCheckNum";
            this.txtCheckNum.Size = new System.Drawing.Size(157, 21);
            this.txtCheckNum.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 56;
            this.label7.Text = "付款日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 55;
            this.label2.Text = "付款金额";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 54;
            this.label3.Text = "付款方式";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 60;
            this.label1.Text = "客户";
            // 
            // txtReceivable
            // 
            this.txtReceivable.Enabled = false;
            this.txtReceivable.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtReceivable.Location = new System.Drawing.Point(306, 13);
            this.txtReceivable.Name = "txtReceivable";
            this.txtReceivable.Size = new System.Drawing.Size(128, 21);
            this.txtReceivable.TabIndex = 61;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Enabled = false;
            this.txtCustomer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCustomer.Location = new System.Drawing.Point(63, 12);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(157, 21);
            this.txtCustomer.TabIndex = 62;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(359, 146);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 64;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOk.Location = new System.Drawing.Point(250, 146);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 63;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmReceivablesPaid
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(443, 181);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.txtReceivable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.rdCheck);
            this.Controls.Add(this.rdCash);
            this.Controls.Add(this.rdTransfer);
            this.Controls.Add(this.dtPaidDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCheckNum);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "FrmReceivablesPaid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "应收项付款";
            this.Load += new System.EventHandler(this.FrmReceivablesPaid_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtAmount;
        private System.Windows.Forms.RadioButton rdCheck;
        private System.Windows.Forms.RadioButton rdCash;
        private System.Windows.Forms.RadioButton rdTransfer;
        private System.Windows.Forms.DateTimePicker dtPaidDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtCheckNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtReceivable;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtCustomer;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnOk;
    }
}