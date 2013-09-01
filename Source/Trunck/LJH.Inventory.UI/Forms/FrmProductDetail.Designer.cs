namespace LJH.Inventory.UI.Forms
{
    partial class FrmProductDetail
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtID = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtName = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtBarCode = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrice = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtCost = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtUnit = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtSpecification = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.txtShortName = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtWarehouse = new LJH.Inventory.UI.Controls.WareHouseComboBox(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.txtCount = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtModel = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.txtForeignName = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.txtCategory = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkCategory = new System.Windows.Forms.LinkLabel();
            this.lnkUnit = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(290, 259);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(181, 259);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "编号:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "名称:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "条码:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "备注:";
            // 
            // txtID
            // 
            this.txtID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtID.Location = new System.Drawing.Point(44, 9);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(138, 21);
            this.txtID.TabIndex = 0;
            this.txtID.Text = "自动创建";
            // 
            // txtName
            // 
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtName.Location = new System.Drawing.Point(44, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(325, 21);
            this.txtName.TabIndex = 1;
            // 
            // txtBarCode
            // 
            this.txtBarCode.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtBarCode.Location = new System.Drawing.Point(231, 133);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(138, 21);
            this.txtBarCode.TabIndex = 4;
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(44, 223);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(326, 21);
            this.txtMemo.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "售价:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(195, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "成本:";
            // 
            // txtPrice
            // 
            this.txtPrice.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPrice.Location = new System.Drawing.Point(44, 193);
            this.txtPrice.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtPrice.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PointCount = 2;
            this.txtPrice.Size = new System.Drawing.Size(138, 21);
            this.txtPrice.TabIndex = 7;
            this.txtPrice.Text = "0.00";
            // 
            // txtCost
            // 
            this.txtCost.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCost.Location = new System.Drawing.Point(231, 193);
            this.txtCost.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtCost.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCost.Name = "txtCost";
            this.txtCost.PointCount = 2;
            this.txtCost.Size = new System.Drawing.Size(138, 21);
            this.txtCost.TabIndex = 8;
            this.txtCost.Text = "0.00";
            // 
            // txtUnit
            // 
            this.txtUnit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtUnit.Location = new System.Drawing.Point(44, 133);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(138, 21);
            this.txtUnit.TabIndex = 5;
            this.txtUnit.Text = "个";
            // 
            // txtSpecification
            // 
            this.txtSpecification.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSpecification.Location = new System.Drawing.Point(44, 163);
            this.txtSpecification.Name = "txtSpecification";
            this.txtSpecification.Size = new System.Drawing.Size(138, 21);
            this.txtSpecification.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 15;
            this.label10.Text = "规格:";
            // 
            // txtShortName
            // 
            this.txtShortName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtShortName.Location = new System.Drawing.Point(44, 102);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(138, 21);
            this.txtShortName.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "简写:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(195, 357);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "数量:";
            this.label12.Visible = false;
            // 
            // txtWarehouse
            // 
            this.txtWarehouse.FormattingEnabled = true;
            this.txtWarehouse.Location = new System.Drawing.Point(44, 353);
            this.txtWarehouse.Name = "txtWarehouse";
            this.txtWarehouse.Size = new System.Drawing.Size(138, 20);
            this.txtWarehouse.TabIndex = 19;
            this.txtWarehouse.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 357);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 20;
            this.label13.Text = "库存:";
            this.label13.Visible = false;
            // 
            // txtCount
            // 
            this.txtCount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCount.Location = new System.Drawing.Point(231, 353);
            this.txtCount.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtCount.MinValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.txtCount.Name = "txtCount";
            this.txtCount.PointCount = 2;
            this.txtCount.Size = new System.Drawing.Size(138, 21);
            this.txtCount.TabIndex = 21;
            this.txtCount.Text = "0.00";
            this.txtCount.Visible = false;
            // 
            // txtModel
            // 
            this.txtModel.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtModel.Location = new System.Drawing.Point(231, 163);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(138, 21);
            this.txtModel.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(195, 167);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 12);
            this.label14.TabIndex = 24;
            this.label14.Text = "型号:";
            // 
            // txtForeignName
            // 
            this.txtForeignName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtForeignName.Location = new System.Drawing.Point(64, 70);
            this.txtForeignName.Name = "txtForeignName";
            this.txtForeignName.Size = new System.Drawing.Size(306, 21);
            this.txtForeignName.TabIndex = 25;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 26;
            this.label15.Text = "外贸名称:";
            // 
            // txtCategory
            // 
            this.txtCategory.Enabled = false;
            this.txtCategory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCategory.Location = new System.Drawing.Point(231, 9);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(138, 21);
            this.txtCategory.TabIndex = 27;
            // 
            // lnkCategory
            // 
            this.lnkCategory.AutoSize = true;
            this.lnkCategory.Location = new System.Drawing.Point(197, 13);
            this.lnkCategory.Name = "lnkCategory";
            this.lnkCategory.Size = new System.Drawing.Size(35, 12);
            this.lnkCategory.TabIndex = 28;
            this.lnkCategory.TabStop = true;
            this.lnkCategory.Text = "类别:";
            this.lnkCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCategory_LinkClicked);
            // 
            // lnkUnit
            // 
            this.lnkUnit.AutoSize = true;
            this.lnkUnit.Location = new System.Drawing.Point(8, 137);
            this.lnkUnit.Name = "lnkUnit";
            this.lnkUnit.Size = new System.Drawing.Size(35, 12);
            this.lnkUnit.TabIndex = 29;
            this.lnkUnit.TabStop = true;
            this.lnkUnit.Text = "单位:";
            this.lnkUnit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUnit_LinkClicked);
            // 
            // FrmProductDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 297);
            this.Controls.Add(this.lnkUnit);
            this.Controls.Add(this.lnkCategory);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtForeignName);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtWarehouse);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtSpecification);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FrmProductDetail";
            this.Text = "商品明细";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtID, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.txtBarCode, 0);
            this.Controls.SetChildIndex(this.txtMemo, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtPrice, 0);
            this.Controls.SetChildIndex(this.txtCost, 0);
            this.Controls.SetChildIndex(this.txtUnit, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtSpecification, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtShortName, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtWarehouse, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtCount, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtModel, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.txtForeignName, 0);
            this.Controls.SetChildIndex(this.txtCategory, 0);
            this.Controls.SetChildIndex(this.lnkCategory, 0);
            this.Controls.SetChildIndex(this.lnkUnit, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtID;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtName;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtBarCode;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtPrice;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtCost;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtUnit;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtSpecification;
        private System.Windows.Forms.Label label10;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtShortName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private Controls.WareHouseComboBox txtWarehouse;
        private System.Windows.Forms.Label label13;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtCount;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtModel;
        private System.Windows.Forms.Label label14;
        private GeneralLibrary.WinformControl.DBCTextBox txtForeignName;
        private System.Windows.Forms.Label label15;
        private GeneralLibrary.WinformControl.DBCTextBox txtCategory;
        private System.Windows.Forms.LinkLabel lnkCategory;
        private System.Windows.Forms.LinkLabel lnkUnit;
    }
}