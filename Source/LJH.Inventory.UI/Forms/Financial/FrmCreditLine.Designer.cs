namespace LJH.Inventory.UI.Forms.Financial
{
    partial class FrmCreditLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCreditLine));
            this.txtNewCreditLine = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtOldCreditLine = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNewCreditLine
            // 
            this.txtNewCreditLine.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtNewCreditLine.Location = new System.Drawing.Point(94, 59);
            this.txtNewCreditLine.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtNewCreditLine.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNewCreditLine.Name = "txtNewCreditLine";
            this.txtNewCreditLine.PointCount = 0;
            this.txtNewCreditLine.Size = new System.Drawing.Size(195, 21);
            this.txtNewCreditLine.TabIndex = 10;
            this.txtNewCreditLine.Text = "0";
            // 
            // txtOldCreditLine
            // 
            this.txtOldCreditLine.Enabled = false;
            this.txtOldCreditLine.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtOldCreditLine.Location = new System.Drawing.Point(94, 28);
            this.txtOldCreditLine.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtOldCreditLine.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOldCreditLine.Name = "txtOldCreditLine";
            this.txtOldCreditLine.PointCount = 0;
            this.txtOldCreditLine.Size = new System.Drawing.Size(195, 21);
            this.txtOldCreditLine.TabIndex = 12;
            this.txtOldCreditLine.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "新信用额度";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "旧信用额度";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(196, 108);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOk.Location = new System.Drawing.Point(109, 108);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmCreditLine
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(322, 143);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtNewCreditLine);
            this.Controls.Add(this.txtOldCreditLine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCreditLine";
            this.Text = "信用额度";
            this.Load += new System.EventHandler(this.FrmCreditLine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GeneralLibrary.WinformControl.DecimalTextBox txtNewCreditLine;
        private GeneralLibrary.WinformControl.DecimalTextBox txtOldCreditLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnOk;
    }
}