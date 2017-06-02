namespace LJH.Inventory.UI.Forms.Financial
{
    partial class FrmAccountDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccountDetail));
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.chk对公账号 = new System.Windows.Forms.CheckBox();
            this.rd银行账号 = new System.Windows.Forms.RadioButton();
            this.rd现金账号 = new System.Windows.Forms.RadioButton();
            this.rd财务核算 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(302, 150);
            this.btnClose.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(193, 150);
            this.btnOk.TabIndex = 4;
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(58, 87);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(319, 43);
            this.txtMemo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 40;
            this.label2.Text = "备注：";
            // 
            // txtName
            // 
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtName.Location = new System.Drawing.Point(60, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(237, 21);
            this.txtName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 39;
            this.label3.Text = "名称：";
            // 
            // chk对公账号
            // 
            this.chk对公账号.AutoSize = true;
            this.chk对公账号.ForeColor = System.Drawing.Color.Red;
            this.chk对公账号.Location = new System.Drawing.Point(302, 24);
            this.chk对公账号.Name = "chk对公账号";
            this.chk对公账号.Size = new System.Drawing.Size(72, 16);
            this.chk对公账号.TabIndex = 41;
            this.chk对公账号.Text = "对公账号";
            this.chk对公账号.UseVisualStyleBackColor = true;
            // 
            // rd银行账号
            // 
            this.rd银行账号.AutoSize = true;
            this.rd银行账号.Location = new System.Drawing.Point(60, 56);
            this.rd银行账号.Name = "rd银行账号";
            this.rd银行账号.Size = new System.Drawing.Size(71, 16);
            this.rd银行账号.TabIndex = 42;
            this.rd银行账号.TabStop = true;
            this.rd银行账号.Text = "银行账号";
            this.rd银行账号.UseVisualStyleBackColor = true;
            // 
            // rd现金账号
            // 
            this.rd现金账号.AutoSize = true;
            this.rd现金账号.Location = new System.Drawing.Point(143, 56);
            this.rd现金账号.Name = "rd现金账号";
            this.rd现金账号.Size = new System.Drawing.Size(71, 16);
            this.rd现金账号.TabIndex = 43;
            this.rd现金账号.TabStop = true;
            this.rd现金账号.Text = "现金账号";
            this.rd现金账号.UseVisualStyleBackColor = true;
            // 
            // rd财务核算
            // 
            this.rd财务核算.AutoSize = true;
            this.rd财务核算.Location = new System.Drawing.Point(224, 56);
            this.rd财务核算.Name = "rd财务核算";
            this.rd财务核算.Size = new System.Drawing.Size(71, 16);
            this.rd财务核算.TabIndex = 44;
            this.rd财务核算.TabStop = true;
            this.rd财务核算.Text = "财务核算";
            this.rd财务核算.UseVisualStyleBackColor = true;
            // 
            // FrmAccountDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 185);
            this.Controls.Add(this.rd财务核算);
            this.Controls.Add(this.rd现金账号);
            this.Controls.Add(this.rd银行账号);
            this.Controls.Add(this.chk对公账号);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAccountDetail";
            this.Text = "公司管理费用类别 明细";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtMemo, 0);
            this.Controls.SetChildIndex(this.chk对公账号, 0);
            this.Controls.SetChildIndex(this.rd银行账号, 0);
            this.Controls.SetChildIndex(this.rd现金账号, 0);
            this.Controls.SetChildIndex(this.rd财务核算, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private System.Windows.Forms.Label label2;
        private GeneralLibrary.WinformControl.DBCTextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chk对公账号;
        private System.Windows.Forms.RadioButton rd银行账号;
        private System.Windows.Forms.RadioButton rd现金账号;
        private System.Windows.Forms.RadioButton rd财务核算;
    }
}