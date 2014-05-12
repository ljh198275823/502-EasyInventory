namespace LJH.Inventory.UI.Forms.General
{
    partial class FrmRelatedCompanyTypeDetail
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtParentCategory = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkParentCategory = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(297, 137);
            this.btnClose.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(186, 137);
            this.btnOk.TabIndex = 4;
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(52, 77);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(319, 43);
            this.txtMemo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 40;
            this.label2.Text = "备注";
            // 
            // txtName
            // 
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtName.Location = new System.Drawing.Point(52, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(319, 21);
            this.txtName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 39;
            this.label3.Text = "名称";
            // 
            // txtParentCategory
            // 
            this.txtParentCategory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtParentCategory.Location = new System.Drawing.Point(52, 45);
            this.txtParentCategory.MaxLength = 100;
            this.txtParentCategory.Name = "txtParentCategory";
            this.txtParentCategory.ReadOnly = true;
            this.txtParentCategory.Size = new System.Drawing.Size(319, 21);
            this.txtParentCategory.TabIndex = 2;
            this.txtParentCategory.DoubleClick += new System.EventHandler(this.txtParentCategory_DoubleClick);
            // 
            // lnkParentCategory
            // 
            this.lnkParentCategory.AutoSize = true;
            this.lnkParentCategory.Location = new System.Drawing.Point(3, 48);
            this.lnkParentCategory.Name = "lnkParentCategory";
            this.lnkParentCategory.Size = new System.Drawing.Size(41, 12);
            this.lnkParentCategory.TabIndex = 1;
            this.lnkParentCategory.TabStop = true;
            this.lnkParentCategory.Text = "父类别";
            this.lnkParentCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkParentCategory_LinkClicked);
            // 
            // FrmRelatedCompanyTypeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 172);
            this.Controls.Add(this.txtParentCategory);
            this.Controls.Add(this.lnkParentCategory);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label2);
            this.Name = "FrmRelatedCompanyTypeDetail";
            this.Text = "相关公司类别";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtMemo, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.lnkParentCategory, 0);
            this.Controls.SetChildIndex(this.txtParentCategory, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private System.Windows.Forms.Label label2;
        private GeneralLibrary.WinformControl.DBCTextBox txtName;
        private System.Windows.Forms.Label label3;
        private GeneralLibrary.WinformControl.DBCTextBox txtParentCategory;
        private System.Windows.Forms.LinkLabel lnkParentCategory;
    }
}