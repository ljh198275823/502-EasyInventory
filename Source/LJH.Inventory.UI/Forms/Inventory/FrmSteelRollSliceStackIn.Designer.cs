namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class FrmSteelRollSliceStackIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSteelRollSliceStackIn));
            this.txtCount = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.lnkWarehouse = new System.Windows.Forms.LinkLabel();
            this.txtWareHouse = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtCategory = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkCategory = new System.Windows.Forms.LinkLabel();
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkCustomer = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cmbSpecification = new LJH.Inventory.UI.Controls.UCSpecification();
            this.dtStorageDateTime = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbBrand = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkBrand = new System.Windows.Forms.LinkLabel();
            this.txtSupplier = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkSupplier = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPosition = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtCarPlate = new LJH.Inventory.UI.Controls.CarplateComboBox(this.components);
            this.txtMaterial = new LJH.Inventory.UI.Controls.MaterialComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPurchaseID = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.pnlCost = new System.Windows.Forms.GroupBox();
            this.txtSupplier运费 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkSupplier_运费 = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdWithTax_运费 = new System.Windows.Forms.RadioButton();
            this.rdWithoutTax_运费 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txt运费 = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.pnlTax = new System.Windows.Forms.Panel();
            this.rdWithTax_入库单价 = new System.Windows.Forms.RadioButton();
            this.rdWithoutTax__入库单价 = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPurchasePrice = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.txtProductName = new LJH.Inventory.UI.Controls.ProductNameComboBox(this.components);
            this.txtLength = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.pnlCost.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlTax.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCount
            // 
            this.txtCount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCount.Location = new System.Drawing.Point(320, 119);
            this.txtCount.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtCount.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCount.Name = "txtCount";
            this.txtCount.PointCount = 0;
            this.txtCount.Size = new System.Drawing.Size(158, 21);
            this.txtCount.TabIndex = 5;
            this.txtCount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "入库数量";
            // 
            // lnkWarehouse
            // 
            this.lnkWarehouse.AutoSize = true;
            this.lnkWarehouse.Location = new System.Drawing.Point(288, 85);
            this.lnkWarehouse.Name = "lnkWarehouse";
            this.lnkWarehouse.Size = new System.Drawing.Size(29, 12);
            this.lnkWarehouse.TabIndex = 7;
            this.lnkWarehouse.TabStop = true;
            this.lnkWarehouse.Text = "仓库";
            this.lnkWarehouse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWarehouse_LinkClicked);
            // 
            // txtWareHouse
            // 
            this.txtWareHouse.BackColor = System.Drawing.SystemColors.Control;
            this.txtWareHouse.Enabled = false;
            this.txtWareHouse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWareHouse.Location = new System.Drawing.Point(320, 81);
            this.txtWareHouse.Name = "txtWareHouse";
            this.txtWareHouse.ReadOnly = true;
            this.txtWareHouse.Size = new System.Drawing.Size(158, 21);
            this.txtWareHouse.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 56;
            this.label7.Text = "单件长度";
            // 
            // txtCategory
            // 
            this.txtCategory.BackColor = System.Drawing.SystemColors.Control;
            this.txtCategory.Enabled = false;
            this.txtCategory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCategory.Location = new System.Drawing.Point(99, 81);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(145, 21);
            this.txtCategory.TabIndex = 1;
            // 
            // lnkCategory
            // 
            this.lnkCategory.AutoSize = true;
            this.lnkCategory.Location = new System.Drawing.Point(66, 85);
            this.lnkCategory.Name = "lnkCategory";
            this.lnkCategory.Size = new System.Drawing.Size(29, 12);
            this.lnkCategory.TabIndex = 76;
            this.lnkCategory.TabStop = true;
            this.lnkCategory.Text = "类别";
            this.lnkCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCategory_LinkClicked);
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(99, 274);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(386, 21);
            this.txtMemo.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 84;
            this.label3.Text = "备注";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomer.Enabled = false;
            this.txtCustomer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCustomer.Location = new System.Drawing.Point(99, 181);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(145, 21);
            this.txtCustomer.TabIndex = 86;
            // 
            // lnkCustomer
            // 
            this.lnkCustomer.AutoSize = true;
            this.lnkCustomer.Location = new System.Drawing.Point(66, 185);
            this.lnkCustomer.Name = "lnkCustomer";
            this.lnkCustomer.Size = new System.Drawing.Size(29, 12);
            this.lnkCustomer.TabIndex = 85;
            this.lnkCustomer.TabStop = true;
            this.lnkCustomer.Text = "客户";
            this.lnkCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomer_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(371, 456);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 32);
            this.btnClose.TabIndex = 88;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOk.Location = new System.Drawing.Point(249, 456);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 32);
            this.btnOk.TabIndex = 87;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cmbSpecification
            // 
            this.cmbSpecification.Location = new System.Drawing.Point(270, 45);
            this.cmbSpecification.Name = "cmbSpecification";
            this.cmbSpecification.SelectedWidth = null;
            this.cmbSpecification.Selected克重 = null;
            this.cmbSpecification.Size = new System.Drawing.Size(208, 26);
            this.cmbSpecification.Specification = "*";
            this.cmbSpecification.TabIndex = 91;
            // 
            // dtStorageDateTime
            // 
            this.dtStorageDateTime.Location = new System.Drawing.Point(99, 17);
            this.dtStorageDateTime.Name = "dtStorageDateTime";
            this.dtStorageDateTime.Size = new System.Drawing.Size(145, 21);
            this.dtStorageDateTime.TabIndex = 92;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 93;
            this.label6.Text = "入库日期";
            // 
            // cmbBrand
            // 
            this.cmbBrand.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbBrand.Location = new System.Drawing.Point(320, 149);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.ReadOnly = true;
            this.cmbBrand.Size = new System.Drawing.Size(158, 21);
            this.cmbBrand.TabIndex = 97;
            // 
            // lnkBrand
            // 
            this.lnkBrand.AutoSize = true;
            this.lnkBrand.Location = new System.Drawing.Point(288, 153);
            this.lnkBrand.Name = "lnkBrand";
            this.lnkBrand.Size = new System.Drawing.Size(29, 12);
            this.lnkBrand.TabIndex = 95;
            this.lnkBrand.TabStop = true;
            this.lnkBrand.Text = "厂家";
            this.lnkBrand.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBrand_LinkClicked);
            // 
            // txtSupplier
            // 
            this.txtSupplier.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSupplier.Location = new System.Drawing.Point(99, 149);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(145, 21);
            this.txtSupplier.TabIndex = 96;
            this.txtSupplier.DoubleClick += new System.EventHandler(this.txtSupplier_DoubleClick);
            // 
            // lnkSupplier
            // 
            this.lnkSupplier.AutoSize = true;
            this.lnkSupplier.Location = new System.Drawing.Point(54, 153);
            this.lnkSupplier.Name = "lnkSupplier";
            this.lnkSupplier.Size = new System.Drawing.Size(41, 12);
            this.lnkSupplier.TabIndex = 94;
            this.lnkSupplier.TabStop = true;
            this.lnkSupplier.Text = "供应商";
            this.lnkSupplier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSupplier_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 246);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 149;
            this.label8.Text = "存放位置";
            // 
            // txtPosition
            // 
            this.txtPosition.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPosition.Location = new System.Drawing.Point(99, 242);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(145, 21);
            this.txtPosition.TabIndex = 148;
            // 
            // txtCarPlate
            // 
            this.txtCarPlate.FormattingEnabled = true;
            this.txtCarPlate.Location = new System.Drawing.Point(99, 212);
            this.txtCarPlate.Name = "txtCarPlate";
            this.txtCarPlate.Size = new System.Drawing.Size(145, 20);
            this.txtCarPlate.TabIndex = 154;
            // 
            // txtMaterial
            // 
            this.txtMaterial.FormattingEnabled = true;
            this.txtMaterial.Location = new System.Drawing.Point(320, 212);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(158, 20);
            this.txtMaterial.TabIndex = 153;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 152;
            this.label4.Text = "材质";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(54, 216);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 151;
            this.label13.Text = "车皮号";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(273, 246);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 156;
            this.label15.Text = "合同号";
            // 
            // txtPurchaseID
            // 
            this.txtPurchaseID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPurchaseID.Location = new System.Drawing.Point(320, 242);
            this.txtPurchaseID.Name = "txtPurchaseID";
            this.txtPurchaseID.Size = new System.Drawing.Size(158, 21);
            this.txtPurchaseID.TabIndex = 155;
            // 
            // pnlCost
            // 
            this.pnlCost.Controls.Add(this.txtSupplier运费);
            this.pnlCost.Controls.Add(this.lnkSupplier_运费);
            this.pnlCost.Controls.Add(this.panel2);
            this.pnlCost.Controls.Add(this.label9);
            this.pnlCost.Controls.Add(this.txt运费);
            this.pnlCost.Controls.Add(this.pnlTax);
            this.pnlCost.Controls.Add(this.label11);
            this.pnlCost.Controls.Add(this.txtPurchasePrice);
            this.pnlCost.Location = new System.Drawing.Point(12, 307);
            this.pnlCost.Name = "pnlCost";
            this.pnlCost.Size = new System.Drawing.Size(488, 127);
            this.pnlCost.TabIndex = 157;
            this.pnlCost.TabStop = false;
            // 
            // txtSupplier运费
            // 
            this.txtSupplier运费.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSupplier运费.Location = new System.Drawing.Point(102, 90);
            this.txtSupplier运费.Name = "txtSupplier运费";
            this.txtSupplier运费.ReadOnly = true;
            this.txtSupplier运费.Size = new System.Drawing.Size(281, 21);
            this.txtSupplier运费.TabIndex = 155;
            // 
            // lnkSupplier_运费
            // 
            this.lnkSupplier_运费.AutoSize = true;
            this.lnkSupplier_运费.Location = new System.Drawing.Point(26, 93);
            this.lnkSupplier_运费.Name = "lnkSupplier_运费";
            this.lnkSupplier_运费.Size = new System.Drawing.Size(65, 12);
            this.lnkSupplier_运费.TabIndex = 154;
            this.lnkSupplier_运费.TabStop = true;
            this.lnkSupplier_运费.Text = "运费供应商";
            this.lnkSupplier_运费.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSupplier_运费_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rdWithTax_运费);
            this.panel2.Controls.Add(this.rdWithoutTax_运费);
            this.panel2.Location = new System.Drawing.Point(238, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(145, 25);
            this.panel2.TabIndex = 137;
            // 
            // rdWithTax_运费
            // 
            this.rdWithTax_运费.AutoSize = true;
            this.rdWithTax_运费.Location = new System.Drawing.Point(4, 3);
            this.rdWithTax_运费.Name = "rdWithTax_运费";
            this.rdWithTax_运费.Size = new System.Drawing.Size(47, 16);
            this.rdWithTax_运费.TabIndex = 129;
            this.rdWithTax_运费.TabStop = true;
            this.rdWithTax_运费.Text = "含税";
            this.rdWithTax_运费.UseVisualStyleBackColor = true;
            // 
            // rdWithoutTax_运费
            // 
            this.rdWithoutTax_运费.AutoSize = true;
            this.rdWithoutTax_运费.Location = new System.Drawing.Point(57, 3);
            this.rdWithoutTax_运费.Name = "rdWithoutTax_运费";
            this.rdWithoutTax_运费.Size = new System.Drawing.Size(59, 16);
            this.rdWithoutTax_运费.TabIndex = 130;
            this.rdWithoutTax_运费.TabStop = true;
            this.rdWithoutTax_运费.Text = "不含税";
            this.rdWithoutTax_运费.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 135;
            this.label9.Text = "运费(/吨)";
            // 
            // txt运费
            // 
            this.txt运费.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txt运费.Location = new System.Drawing.Point(102, 58);
            this.txt运费.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txt运费.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt运费.Name = "txt运费";
            this.txt运费.PointCount = 2;
            this.txt运费.Size = new System.Drawing.Size(122, 21);
            this.txt运费.TabIndex = 136;
            this.txt运费.Text = "0";
            // 
            // pnlTax
            // 
            this.pnlTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTax.Controls.Add(this.rdWithTax_入库单价);
            this.pnlTax.Controls.Add(this.rdWithoutTax__入库单价);
            this.pnlTax.Location = new System.Drawing.Point(238, 17);
            this.pnlTax.Name = "pnlTax";
            this.pnlTax.Size = new System.Drawing.Size(145, 25);
            this.pnlTax.TabIndex = 134;
            // 
            // rdWithTax_入库单价
            // 
            this.rdWithTax_入库单价.AutoSize = true;
            this.rdWithTax_入库单价.Location = new System.Drawing.Point(4, 3);
            this.rdWithTax_入库单价.Name = "rdWithTax_入库单价";
            this.rdWithTax_入库单价.Size = new System.Drawing.Size(47, 16);
            this.rdWithTax_入库单价.TabIndex = 129;
            this.rdWithTax_入库单价.TabStop = true;
            this.rdWithTax_入库单价.Text = "含税";
            this.rdWithTax_入库单价.UseVisualStyleBackColor = true;
            // 
            // rdWithoutTax__入库单价
            // 
            this.rdWithoutTax__入库单价.AutoSize = true;
            this.rdWithoutTax__入库单价.Location = new System.Drawing.Point(57, 3);
            this.rdWithoutTax__入库单价.Name = "rdWithoutTax__入库单价";
            this.rdWithoutTax__入库单价.Size = new System.Drawing.Size(59, 16);
            this.rdWithoutTax__入库单价.TabIndex = 130;
            this.rdWithoutTax__入库单价.TabStop = true;
            this.rdWithoutTax__入库单价.Text = "不含税";
            this.rdWithoutTax__入库单价.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 12);
            this.label11.TabIndex = 94;
            this.label11.Text = "入库单价(/吨)";
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPurchasePrice.Location = new System.Drawing.Point(102, 19);
            this.txtPurchasePrice.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtPurchasePrice.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.PointCount = 2;
            this.txtPurchasePrice.Size = new System.Drawing.Size(122, 21);
            this.txtPurchasePrice.TabIndex = 98;
            this.txtPurchasePrice.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(38, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 158;
            this.label12.Text = "产品名称";
            // 
            // txtProductName
            // 
            this.txtProductName.FormattingEnabled = true;
            this.txtProductName.Location = new System.Drawing.Point(99, 48);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(146, 20);
            this.txtProductName.TabIndex = 159;
            // 
            // txtLength
            // 
            this.txtLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLength.Location = new System.Drawing.Point(99, 119);
            this.txtLength.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtLength.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLength.Name = "txtLength";
            this.txtLength.PointCount = 0;
            this.txtLength.Size = new System.Drawing.Size(145, 21);
            this.txtLength.TabIndex = 160;
            this.txtLength.Text = "0";
            // 
            // FrmSteelRollSliceStackIn
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(503, 512);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pnlCost);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtPurchaseID);
            this.Controls.Add(this.txtCarPlate);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.lnkBrand);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.lnkSupplier);
            this.Controls.Add(this.dtStorageDateTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbSpecification);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lnkCustomer);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.lnkCategory);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtWareHouse);
            this.Controls.Add(this.lnkWarehouse);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.label5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSteelRollSliceStackIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "小件入库";
            this.Load += new System.EventHandler(this.FrmSteelRollSliceDetail_Load);
            this.pnlCost.ResumeLayout(false);
            this.pnlCost.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlTax.ResumeLayout(false);
            this.pnlTax.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lnkWarehouse;
        private GeneralLibrary.WinformControl.DBCTextBox txtWareHouse;
        private System.Windows.Forms.Label label7;
        private GeneralLibrary.WinformControl.DBCTextBox txtCategory;
        private System.Windows.Forms.LinkLabel lnkCategory;
        private GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private System.Windows.Forms.Label label3;
        private GeneralLibrary.WinformControl.DBCTextBox txtCustomer;
        private System.Windows.Forms.LinkLabel lnkCustomer;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnOk;
        private Controls.UCSpecification cmbSpecification;
        private System.Windows.Forms.DateTimePicker dtStorageDateTime;
        private System.Windows.Forms.Label label6;
        private GeneralLibrary.WinformControl.DBCTextBox cmbBrand;
        private System.Windows.Forms.LinkLabel lnkBrand;
        private GeneralLibrary.WinformControl.DBCTextBox txtSupplier;
        private System.Windows.Forms.LinkLabel lnkSupplier;
        private System.Windows.Forms.Label label8;
        private GeneralLibrary.WinformControl.DBCTextBox txtPosition;
        private Controls.CarplateComboBox txtCarPlate;
        private Controls.MaterialComboBox txtMaterial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private GeneralLibrary.WinformControl.DBCTextBox txtPurchaseID;
        private System.Windows.Forms.GroupBox pnlCost;
        private GeneralLibrary.WinformControl.DBCTextBox txtSupplier运费;
        private System.Windows.Forms.LinkLabel lnkSupplier_运费;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdWithTax_运费;
        private System.Windows.Forms.RadioButton rdWithoutTax_运费;
        private System.Windows.Forms.Label label9;
        private GeneralLibrary.WinformControl.DecimalTextBox txt运费;
        private System.Windows.Forms.Panel pnlTax;
        private System.Windows.Forms.RadioButton rdWithTax_入库单价;
        private System.Windows.Forms.RadioButton rdWithoutTax__入库单价;
        private System.Windows.Forms.Label label11;
        private GeneralLibrary.WinformControl.DecimalTextBox txtPurchasePrice;
        private System.Windows.Forms.Label label12;
        private Controls.ProductNameComboBox txtProductName;
        private GeneralLibrary.WinformControl.DecimalTextBox txtLength;

    }
}