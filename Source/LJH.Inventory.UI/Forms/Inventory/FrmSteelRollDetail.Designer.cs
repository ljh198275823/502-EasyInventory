namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class FrmSteelRollDetail
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
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtStorageDateTime = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWeight = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtLength = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtSerialNumber = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkSupplier = new System.Windows.Forms.LinkLabel();
            this.lnkCategory = new System.Windows.Forms.LinkLabel();
            this.txtCategory = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtSupplier = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtWareHouse = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkWareHouse = new System.Windows.Forms.LinkLabel();
            this.cmbBrand = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkBrand = new System.Windows.Forms.LinkLabel();
            this.txtCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkCustomer = new System.Windows.Forms.LinkLabel();
            this.txtOriginalLength = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtOriginalWeight = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPurchasePrice = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.pnlTax = new System.Windows.Forms.Panel();
            this.rdWithTax_入库单价 = new System.Windows.Forms.RadioButton();
            this.rdWithoutTax__入库单价 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPosition = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMaterial = new LJH.Inventory.UI.Controls.MaterialComboBox(this.components);
            this.cmbSpecification = new LJH.Inventory.UI.Controls.UCSpecification();
            this.txtCarPlate = new LJH.Inventory.UI.Controls.CarplateComboBox(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.txtPurchaseID = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.btnOk1 = new System.Windows.Forms.Button();
            this.pnlCost = new System.Windows.Forms.GroupBox();
            this.btn查看来源卷 = new System.Windows.Forms.Button();
            this.pnlTax.SuspendLayout();
            this.pnlCost.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(387, 379);
            this.btnClose.Size = new System.Drawing.Size(107, 35);
            this.btnClose.TabIndex = 21;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(26, 416);
            this.btnOk.Size = new System.Drawing.Size(107, 35);
            this.btnOk.TabIndex = 20;
            this.btnOk.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(301, 188);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 57;
            this.label14.Text = "钢卷号";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(69, 285);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 55;
            this.label12.Text = "描述";
            // 
            // dtStorageDateTime
            // 
            this.dtStorageDateTime.Location = new System.Drawing.Point(100, 25);
            this.dtStorageDateTime.Name = "dtStorageDateTime";
            this.dtStorageDateTime.Size = new System.Drawing.Size(145, 21);
            this.dtStorageDateTime.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 51;
            this.label6.Text = "入库日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 50;
            this.label3.Text = "剩余重量(吨)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 48;
            this.label5.Text = "规格";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "剩余长度(米)";
            // 
            // txtWeight
            // 
            this.txtWeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWeight.Location = new System.Drawing.Point(100, 119);
            this.txtWeight.MaxValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.txtWeight.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.PointCount = 3;
            this.txtWeight.Size = new System.Drawing.Size(145, 21);
            this.txtWeight.TabIndex = 6;
            this.txtWeight.Text = "0";
            // 
            // txtLength
            // 
            this.txtLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLength.Location = new System.Drawing.Point(346, 119);
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
            this.txtLength.PointCount = 2;
            this.txtLength.Size = new System.Drawing.Size(145, 21);
            this.txtLength.TabIndex = 7;
            this.txtLength.Text = "0";
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(102, 281);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(391, 21);
            this.txtMemo.TabIndex = 12;
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSerialNumber.Location = new System.Drawing.Point(346, 185);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(145, 21);
            this.txtSerialNumber.TabIndex = 11;
            // 
            // lnkSupplier
            // 
            this.lnkSupplier.AutoSize = true;
            this.lnkSupplier.Location = new System.Drawing.Point(55, 158);
            this.lnkSupplier.Name = "lnkSupplier";
            this.lnkSupplier.Size = new System.Drawing.Size(41, 12);
            this.lnkSupplier.TabIndex = 8;
            this.lnkSupplier.TabStop = true;
            this.lnkSupplier.Text = "供应商";
            this.lnkSupplier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSupplier_LinkClicked);
            // 
            // lnkCategory
            // 
            this.lnkCategory.AutoSize = true;
            this.lnkCategory.Location = new System.Drawing.Point(313, 59);
            this.lnkCategory.Name = "lnkCategory";
            this.lnkCategory.Size = new System.Drawing.Size(29, 12);
            this.lnkCategory.TabIndex = 3;
            this.lnkCategory.TabStop = true;
            this.lnkCategory.Text = "类别";
            this.lnkCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCategory_LinkClicked);
            // 
            // txtCategory
            // 
            this.txtCategory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCategory.Location = new System.Drawing.Point(346, 55);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(145, 21);
            this.txtCategory.TabIndex = 71;
            // 
            // txtSupplier
            // 
            this.txtSupplier.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSupplier.Location = new System.Drawing.Point(100, 154);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(145, 21);
            this.txtSupplier.TabIndex = 72;
            this.txtSupplier.DoubleClick += new System.EventHandler(this.txtSupplier_DoubleClick);
            // 
            // txtWareHouse
            // 
            this.txtWareHouse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWareHouse.Location = new System.Drawing.Point(346, 25);
            this.txtWareHouse.Name = "txtWareHouse";
            this.txtWareHouse.ReadOnly = true;
            this.txtWareHouse.Size = new System.Drawing.Size(145, 21);
            this.txtWareHouse.TabIndex = 76;
            // 
            // lnkWareHouse
            // 
            this.lnkWareHouse.AutoSize = true;
            this.lnkWareHouse.Location = new System.Drawing.Point(313, 29);
            this.lnkWareHouse.Name = "lnkWareHouse";
            this.lnkWareHouse.Size = new System.Drawing.Size(29, 12);
            this.lnkWareHouse.TabIndex = 1;
            this.lnkWareHouse.TabStop = true;
            this.lnkWareHouse.Text = "仓库";
            this.lnkWareHouse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWareHouse_LinkClicked);
            // 
            // cmbBrand
            // 
            this.cmbBrand.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbBrand.Location = new System.Drawing.Point(346, 154);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.ReadOnly = true;
            this.cmbBrand.Size = new System.Drawing.Size(145, 21);
            this.cmbBrand.TabIndex = 78;
            // 
            // lnkBrand
            // 
            this.lnkBrand.AutoSize = true;
            this.lnkBrand.Location = new System.Drawing.Point(313, 158);
            this.lnkBrand.Name = "lnkBrand";
            this.lnkBrand.Size = new System.Drawing.Size(29, 12);
            this.lnkBrand.TabIndex = 9;
            this.lnkBrand.TabStop = true;
            this.lnkBrand.Text = "厂家";
            this.lnkBrand.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBrand_LinkClicked);
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCustomer.Location = new System.Drawing.Point(100, 185);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(145, 21);
            this.txtCustomer.TabIndex = 82;
            // 
            // lnkCustomer
            // 
            this.lnkCustomer.AutoSize = true;
            this.lnkCustomer.Location = new System.Drawing.Point(67, 189);
            this.lnkCustomer.Name = "lnkCustomer";
            this.lnkCustomer.Size = new System.Drawing.Size(29, 12);
            this.lnkCustomer.TabIndex = 10;
            this.lnkCustomer.TabStop = true;
            this.lnkCustomer.Text = "客户";
            this.lnkCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomer_LinkClicked);
            // 
            // txtOriginalLength
            // 
            this.txtOriginalLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtOriginalLength.Location = new System.Drawing.Point(346, 86);
            this.txtOriginalLength.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtOriginalLength.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOriginalLength.Name = "txtOriginalLength";
            this.txtOriginalLength.PointCount = 2;
            this.txtOriginalLength.Size = new System.Drawing.Size(145, 21);
            this.txtOriginalLength.TabIndex = 5;
            this.txtOriginalLength.Text = "0";
            this.txtOriginalLength.TextChanged += new System.EventHandler(this.txtOriginalLength_TextChanged);
            // 
            // txtOriginalWeight
            // 
            this.txtOriginalWeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtOriginalWeight.Location = new System.Drawing.Point(100, 86);
            this.txtOriginalWeight.MaxValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.txtOriginalWeight.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOriginalWeight.Name = "txtOriginalWeight";
            this.txtOriginalWeight.PointCount = 3;
            this.txtOriginalWeight.Size = new System.Drawing.Size(145, 21);
            this.txtOriginalWeight.TabIndex = 4;
            this.txtOriginalWeight.Text = "0";
            this.txtOriginalWeight.TextChanged += new System.EventHandler(this.txtOriginalWeight_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 84;
            this.label2.Text = "入库重量(吨)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 83;
            this.label4.Text = "入库长度(米)";
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 94;
            this.label9.Text = "入库单价(/吨)";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 138;
            this.label7.Text = "存放位置";
            // 
            // txtPosition
            // 
            this.txtPosition.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPosition.Location = new System.Drawing.Point(102, 249);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(145, 21);
            this.txtPosition.TabIndex = 137;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(311, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 140;
            this.label8.Text = "材质";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(55, 221);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 139;
            this.label13.Text = "车皮号";
            // 
            // txtMaterial
            // 
            this.txtMaterial.FormattingEnabled = true;
            this.txtMaterial.Location = new System.Drawing.Point(344, 217);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(145, 20);
            this.txtMaterial.TabIndex = 141;
            // 
            // cmbSpecification
            // 
            this.cmbSpecification.Location = new System.Drawing.Point(100, 52);
            this.cmbSpecification.Name = "cmbSpecification";
            this.cmbSpecification.Size = new System.Drawing.Size(164, 26);
            this.cmbSpecification.Specification = "*";
            this.cmbSpecification.TabIndex = 85;
            // 
            // txtCarPlate
            // 
            this.txtCarPlate.FormattingEnabled = true;
            this.txtCarPlate.Location = new System.Drawing.Point(100, 217);
            this.txtCarPlate.Name = "txtCarPlate";
            this.txtCarPlate.Size = new System.Drawing.Size(145, 20);
            this.txtCarPlate.TabIndex = 142;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(299, 253);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 144;
            this.label15.Text = "合同号";
            // 
            // txtPurchaseID
            // 
            this.txtPurchaseID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPurchaseID.Location = new System.Drawing.Point(346, 249);
            this.txtPurchaseID.Name = "txtPurchaseID";
            this.txtPurchaseID.Size = new System.Drawing.Size(145, 21);
            this.txtPurchaseID.TabIndex = 143;
            // 
            // btnOk1
            // 
            this.btnOk1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk1.Location = new System.Drawing.Point(235, 379);
            this.btnOk1.Name = "btnOk1";
            this.btnOk1.Size = new System.Drawing.Size(126, 35);
            this.btnOk1.TabIndex = 145;
            this.btnOk1.Text = "确定(&O)";
            this.btnOk1.UseVisualStyleBackColor = true;
            this.btnOk1.Click += new System.EventHandler(this.btnOk1_Click);
            // 
            // pnlCost
            // 
            this.pnlCost.Controls.Add(this.pnlTax);
            this.pnlCost.Controls.Add(this.label9);
            this.pnlCost.Controls.Add(this.txtPurchasePrice);
            this.pnlCost.Location = new System.Drawing.Point(5, 307);
            this.pnlCost.Name = "pnlCost";
            this.pnlCost.Size = new System.Drawing.Size(488, 56);
            this.pnlCost.TabIndex = 146;
            this.pnlCost.TabStop = false;
            // 
            // btn查看来源卷
            // 
            this.btn查看来源卷.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn查看来源卷.Location = new System.Drawing.Point(74, 379);
            this.btn查看来源卷.Name = "btn查看来源卷";
            this.btn查看来源卷.Size = new System.Drawing.Size(126, 35);
            this.btn查看来源卷.TabIndex = 147;
            this.btn查看来源卷.Text = "查看来源卷";
            this.btn查看来源卷.UseVisualStyleBackColor = true;
            this.btn查看来源卷.Visible = false;
            this.btn查看来源卷.Click += new System.EventHandler(this.btn查看来源卷_Click);
            // 
            // FrmSteelRollDetail
            // 
            this.AcceptButton = this.btnOk1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 435);
            this.Controls.Add(this.btn查看来源卷);
            this.Controls.Add(this.pnlCost);
            this.Controls.Add(this.btnOk1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtPurchaseID);
            this.Controls.Add(this.txtCarPlate);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.cmbSpecification);
            this.Controls.Add(this.txtOriginalLength);
            this.Controls.Add(this.txtOriginalWeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lnkCustomer);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.lnkBrand);
            this.Controls.Add(this.txtWareHouse);
            this.Controls.Add(this.lnkWareHouse);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.lnkCategory);
            this.Controls.Add(this.lnkSupplier);
            this.Controls.Add(this.txtSerialNumber);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dtStorageDateTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "FrmSteelRollDetail";
            this.Text = "原材料入库";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.dtStorageDateTime, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtWeight, 0);
            this.Controls.SetChildIndex(this.txtLength, 0);
            this.Controls.SetChildIndex(this.txtMemo, 0);
            this.Controls.SetChildIndex(this.txtSerialNumber, 0);
            this.Controls.SetChildIndex(this.lnkSupplier, 0);
            this.Controls.SetChildIndex(this.lnkCategory, 0);
            this.Controls.SetChildIndex(this.txtCategory, 0);
            this.Controls.SetChildIndex(this.txtSupplier, 0);
            this.Controls.SetChildIndex(this.lnkWareHouse, 0);
            this.Controls.SetChildIndex(this.txtWareHouse, 0);
            this.Controls.SetChildIndex(this.lnkBrand, 0);
            this.Controls.SetChildIndex(this.cmbBrand, 0);
            this.Controls.SetChildIndex(this.lnkCustomer, 0);
            this.Controls.SetChildIndex(this.txtCustomer, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtOriginalWeight, 0);
            this.Controls.SetChildIndex(this.txtOriginalLength, 0);
            this.Controls.SetChildIndex(this.cmbSpecification, 0);
            this.Controls.SetChildIndex(this.txtPosition, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtMaterial, 0);
            this.Controls.SetChildIndex(this.txtCarPlate, 0);
            this.Controls.SetChildIndex(this.txtPurchaseID, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.btnOk1, 0);
            this.Controls.SetChildIndex(this.pnlCost, 0);
            this.Controls.SetChildIndex(this.btn查看来源卷, 0);
            this.pnlTax.ResumeLayout(false);
            this.pnlTax.PerformLayout();
            this.pnlCost.ResumeLayout(false);
            this.pnlCost.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtStorageDateTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private GeneralLibrary.WinformControl.DecimalTextBox txtWeight;
        private GeneralLibrary.WinformControl.DecimalTextBox txtLength;
        private GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private GeneralLibrary.WinformControl.DBCTextBox txtSerialNumber;
        private System.Windows.Forms.LinkLabel lnkSupplier;
        private System.Windows.Forms.LinkLabel lnkCategory;
        private GeneralLibrary.WinformControl.DBCTextBox txtCategory;
        private GeneralLibrary.WinformControl.DBCTextBox txtSupplier;
        private GeneralLibrary.WinformControl.DBCTextBox txtWareHouse;
        private System.Windows.Forms.LinkLabel lnkWareHouse;
        private GeneralLibrary.WinformControl.DBCTextBox cmbBrand;
        private System.Windows.Forms.LinkLabel lnkBrand;
        private GeneralLibrary.WinformControl.DBCTextBox txtCustomer;
        private System.Windows.Forms.LinkLabel lnkCustomer;
        private GeneralLibrary.WinformControl.DecimalTextBox txtOriginalLength;
        private GeneralLibrary.WinformControl.DecimalTextBox txtOriginalWeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Controls.UCSpecification cmbSpecification;
        private GeneralLibrary.WinformControl.DecimalTextBox txtPurchasePrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlTax;
        private System.Windows.Forms.RadioButton rdWithTax_入库单价;
        private System.Windows.Forms.RadioButton rdWithoutTax__入库单价;
        private System.Windows.Forms.Label label7;
        private GeneralLibrary.WinformControl.DBCTextBox txtPosition;
        private Controls.MaterialComboBox txtMaterial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private Controls.CarplateComboBox txtCarPlate;
        private System.Windows.Forms.Label label15;
        private GeneralLibrary.WinformControl.DBCTextBox txtPurchaseID;
        private System.Windows.Forms.Button btnOk1;
        private System.Windows.Forms.GroupBox pnlCost;
        private System.Windows.Forms.Button btn查看来源卷;
    }
}