namespace LJH.Inventory.UI.Forms.General
{
    partial class FrmProductCategoryDetail
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrefix = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkParentCategory = new System.Windows.Forms.LinkLabel();
            this.txtParentCategory = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(178, 266);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(69, 266);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "编号";
            // 
            // txtID
            // 
            this.txtID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtID.Location = new System.Drawing.Point(9, 31);
            this.txtID.MaxLength = 100;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(248, 21);
            this.txtID.TabIndex = 3;
            this.txtID.Text = "自动创建";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "名称";
            // 
            // txtName
            // 
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtName.Location = new System.Drawing.Point(9, 73);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(248, 21);
            this.txtName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "备注";
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(9, 204);
            this.txtMemo.MaxLength = 200;
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(248, 43);
            this.txtMemo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "商品编号前缀(用于自动生成商品编号）";
            // 
            // txtPrefix
            // 
            this.txtPrefix.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPrefix.Location = new System.Drawing.Point(9, 118);
            this.txtPrefix.MaxLength = 100;
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(248, 21);
            this.txtPrefix.TabIndex = 9;
            // 
            // lnkParentCategory
            // 
            this.lnkParentCategory.AutoSize = true;
            this.lnkParentCategory.Location = new System.Drawing.Point(9, 146);
            this.lnkParentCategory.Name = "lnkParentCategory";
            this.lnkParentCategory.Size = new System.Drawing.Size(41, 12);
            this.lnkParentCategory.TabIndex = 10;
            this.lnkParentCategory.TabStop = true;
            this.lnkParentCategory.Text = "父类别";
            this.lnkParentCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkParentCategory_LinkClicked);
            // 
            // txtParentCategory
            // 
            this.txtParentCategory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtParentCategory.Location = new System.Drawing.Point(9, 161);
            this.txtParentCategory.MaxLength = 100;
            this.txtParentCategory.Name = "txtParentCategory";
            this.txtParentCategory.ReadOnly = true;
            this.txtParentCategory.Size = new System.Drawing.Size(248, 21);
            this.txtParentCategory.TabIndex = 11;
            this.txtParentCategory.DoubleClick += new System.EventHandler(this.txtParentCategory_DoubleClick);
            // 
            // FrmProductCategoryDetail
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(265, 301);
            this.Controls.Add(this.txtParentCategory);
            this.Controls.Add(this.lnkParentCategory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtID);
            this.Name = "FrmProductCategoryDetail";
            this.Text = "商品类别";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.txtID, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtMemo, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtPrefix, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lnkParentCategory, 0);
            this.Controls.SetChildIndex(this.txtParentCategory, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtID;
        private System.Windows.Forms.Label label2;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtName;
        private System.Windows.Forms.Label label3;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private System.Windows.Forms.Label label4;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtPrefix;
        private System.Windows.Forms.LinkLabel lnkParentCategory;
        private GeneralLibrary.WinformControl.DBCTextBox txtParentCategory;
    }
}