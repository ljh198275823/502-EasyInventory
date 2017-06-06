﻿namespace LJH.Inventory.UI.Forms.Inventory
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
            this.txtWeight = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtLength = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtCategory = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkCategory = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rd开吨 = new System.Windows.Forms.RadioButton();
            this.rd开卷 = new System.Windows.Forms.RadioButton();
            this.rd开平 = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.rd单件重 = new System.Windows.Forms.RadioButton();
            this.rd总重 = new System.Windows.Forms.RadioButton();
            this.txtCarPlate = new LJH.Inventory.UI.Controls.CarplateComboBox(this.components);
            this.txtMaterial = new LJH.Inventory.UI.Controls.MaterialComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPurchaseID = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.pnlCost = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdWithTax_运费 = new System.Windows.Forms.RadioButton();
            this.rdWithoutTax__运费 = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdWithTax_其它费用 = new System.Windows.Forms.RadioButton();
            this.rdWithoutTax__其它费用 = new System.Windows.Forms.RadioButton();
            this.pnlTax = new System.Windows.Forms.Panel();
            this.rdWithTax_入库单价 = new System.Windows.Forms.RadioButton();
            this.rdWithoutTax__入库单价 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPurchasePrice = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTransCost = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtOtherCost = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.chkOtherCostPrepay = new System.Windows.Forms.CheckBox();
            this.chkTransCostPrepay = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlCost.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlTax.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCount
            // 
            this.txtCount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCount.Location = new System.Drawing.Point(340, 147);
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
            this.txtCount.Size = new System.Drawing.Size(145, 21);
            this.txtCount.TabIndex = 5;
            this.txtCount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(307, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "数量";
            // 
            // lnkWarehouse
            // 
            this.lnkWarehouse.AutoSize = true;
            this.lnkWarehouse.Location = new System.Drawing.Point(308, 21);
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
            this.txtWareHouse.Location = new System.Drawing.Point(340, 17);
            this.txtWareHouse.Name = "txtWareHouse";
            this.txtWareHouse.ReadOnly = true;
            this.txtWareHouse.Size = new System.Drawing.Size(145, 21);
            this.txtWareHouse.TabIndex = 1;
            // 
            // txtWeight
            // 
            this.txtWeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWeight.Location = new System.Drawing.Point(99, 114);
            this.txtWeight.MaxValue = new decimal(new int[] {
            20,
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
            this.txtWeight.TabIndex = 4;
            this.txtWeight.Text = "0.000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 61;
            this.label2.Text = "重量";
            // 
            // txtLength
            // 
            this.txtLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLength.Location = new System.Drawing.Point(99, 147);
            this.txtLength.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtLength.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLength.Name = "txtLength";
            this.txtLength.PointCount = 3;
            this.txtLength.Size = new System.Drawing.Size(145, 21);
            this.txtLength.TabIndex = 3;
            this.txtLength.Text = "0.000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 151);
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
            this.txtCategory.Location = new System.Drawing.Point(340, 50);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(145, 21);
            this.txtCategory.TabIndex = 1;
            // 
            // lnkCategory
            // 
            this.lnkCategory.AutoSize = true;
            this.lnkCategory.Location = new System.Drawing.Point(308, 54);
            this.lnkCategory.Name = "lnkCategory";
            this.lnkCategory.Size = new System.Drawing.Size(29, 12);
            this.lnkCategory.TabIndex = 76;
            this.lnkCategory.TabStop = true;
            this.lnkCategory.Text = "类别";
            this.lnkCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCategory_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 75;
            this.label1.Text = "规格";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rd开吨);
            this.panel1.Controls.Add(this.rd开卷);
            this.panel1.Controls.Add(this.rd开平);
            this.panel1.Location = new System.Drawing.Point(99, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 21);
            this.panel1.TabIndex = 2;
            // 
            // rd开吨
            // 
            this.rd开吨.AutoSize = true;
            this.rd开吨.Location = new System.Drawing.Point(128, 2);
            this.rd开吨.Name = "rd开吨";
            this.rd开吨.Size = new System.Drawing.Size(47, 16);
            this.rd开吨.TabIndex = 2;
            this.rd开吨.Tag = "开吨";
            this.rd开吨.Text = "开吨";
            this.rd开吨.UseVisualStyleBackColor = true;
            this.rd开吨.CheckedChanged += new System.EventHandler(this.rdSliceType_CheckedChanged);
            // 
            // rd开卷
            // 
            this.rd开卷.AutoSize = true;
            this.rd开卷.Location = new System.Drawing.Point(65, 3);
            this.rd开卷.Name = "rd开卷";
            this.rd开卷.Size = new System.Drawing.Size(47, 16);
            this.rd开卷.TabIndex = 1;
            this.rd开卷.Tag = "";
            this.rd开卷.Text = "开卷";
            this.rd开卷.UseVisualStyleBackColor = true;
            this.rd开卷.CheckedChanged += new System.EventHandler(this.rdSliceType_CheckedChanged);
            // 
            // rd开平
            // 
            this.rd开平.AutoSize = true;
            this.rd开平.Location = new System.Drawing.Point(4, 3);
            this.rd开平.Name = "rd开平";
            this.rd开平.Size = new System.Drawing.Size(47, 16);
            this.rd开平.TabIndex = 0;
            this.rd开平.Tag = "板材";
            this.rd开平.Text = "开平";
            this.rd开平.UseVisualStyleBackColor = true;
            this.rd开平.CheckedChanged += new System.EventHandler(this.rdSliceType_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(42, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 79;
            this.label10.Text = "加工类别";
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(99, 303);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(386, 21);
            this.txtMemo.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 306);
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
            this.txtCustomer.Location = new System.Drawing.Point(99, 210);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(145, 21);
            this.txtCustomer.TabIndex = 86;
            // 
            // lnkCustomer
            // 
            this.lnkCustomer.AutoSize = true;
            this.lnkCustomer.Location = new System.Drawing.Point(66, 214);
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
            this.btnClose.Location = new System.Drawing.Point(371, 467);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 32);
            this.btnClose.TabIndex = 88;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOk.Location = new System.Drawing.Point(249, 467);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 32);
            this.btnOk.TabIndex = 87;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cmbSpecification
            // 
            this.cmbSpecification.Location = new System.Drawing.Point(99, 47);
            this.cmbSpecification.Name = "cmbSpecification";
            this.cmbSpecification.Size = new System.Drawing.Size(158, 26);
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
            this.cmbBrand.Location = new System.Drawing.Point(340, 178);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.ReadOnly = true;
            this.cmbBrand.Size = new System.Drawing.Size(145, 21);
            this.cmbBrand.TabIndex = 97;
            // 
            // lnkBrand
            // 
            this.lnkBrand.AutoSize = true;
            this.lnkBrand.Location = new System.Drawing.Point(308, 182);
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
            this.txtSupplier.Location = new System.Drawing.Point(99, 178);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(145, 21);
            this.txtSupplier.TabIndex = 96;
            this.txtSupplier.DoubleClick += new System.EventHandler(this.txtSupplier_DoubleClick);
            // 
            // lnkSupplier
            // 
            this.lnkSupplier.AutoSize = true;
            this.lnkSupplier.Location = new System.Drawing.Point(54, 182);
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
            this.label8.Location = new System.Drawing.Point(42, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 149;
            this.label8.Text = "存放位置";
            // 
            // txtPosition
            // 
            this.txtPosition.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPosition.Location = new System.Drawing.Point(99, 271);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(145, 21);
            this.txtPosition.TabIndex = 148;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.rd单件重);
            this.panel3.Controls.Add(this.rd总重);
            this.panel3.Location = new System.Drawing.Point(250, 112);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(118, 25);
            this.panel3.TabIndex = 150;
            // 
            // rd单件重
            // 
            this.rd单件重.AutoSize = true;
            this.rd单件重.Location = new System.Drawing.Point(54, 3);
            this.rd单件重.Name = "rd单件重";
            this.rd单件重.Size = new System.Drawing.Size(59, 16);
            this.rd单件重.TabIndex = 129;
            this.rd单件重.Text = "单件重";
            this.rd单件重.UseVisualStyleBackColor = true;
            // 
            // rd总重
            // 
            this.rd总重.AutoSize = true;
            this.rd总重.Location = new System.Drawing.Point(4, 3);
            this.rd总重.Name = "rd总重";
            this.rd总重.Size = new System.Drawing.Size(47, 16);
            this.rd总重.TabIndex = 130;
            this.rd总重.Text = "总重";
            this.rd总重.UseVisualStyleBackColor = true;
            // 
            // txtCarPlate
            // 
            this.txtCarPlate.FormattingEnabled = true;
            this.txtCarPlate.Location = new System.Drawing.Point(99, 241);
            this.txtCarPlate.Name = "txtCarPlate";
            this.txtCarPlate.Size = new System.Drawing.Size(145, 20);
            this.txtCarPlate.TabIndex = 154;
            // 
            // txtMaterial
            // 
            this.txtMaterial.FormattingEnabled = true;
            this.txtMaterial.Location = new System.Drawing.Point(340, 241);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(145, 20);
            this.txtMaterial.TabIndex = 153;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 152;
            this.label4.Text = "材质";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(54, 245);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 151;
            this.label13.Text = "车皮号";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(293, 275);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 156;
            this.label15.Text = "合同号";
            // 
            // txtPurchaseID
            // 
            this.txtPurchaseID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPurchaseID.Location = new System.Drawing.Point(340, 271);
            this.txtPurchaseID.Name = "txtPurchaseID";
            this.txtPurchaseID.Size = new System.Drawing.Size(145, 21);
            this.txtPurchaseID.TabIndex = 155;
            // 
            // pnlCost
            // 
            this.pnlCost.Controls.Add(this.panel2);
            this.pnlCost.Controls.Add(this.panel4);
            this.pnlCost.Controls.Add(this.pnlTax);
            this.pnlCost.Controls.Add(this.label9);
            this.pnlCost.Controls.Add(this.txtPurchasePrice);
            this.pnlCost.Controls.Add(this.label11);
            this.pnlCost.Controls.Add(this.label12);
            this.pnlCost.Controls.Add(this.txtTransCost);
            this.pnlCost.Controls.Add(this.txtOtherCost);
            this.pnlCost.Controls.Add(this.chkOtherCostPrepay);
            this.pnlCost.Controls.Add(this.chkTransCostPrepay);
            this.pnlCost.Location = new System.Drawing.Point(7, 330);
            this.pnlCost.Name = "pnlCost";
            this.pnlCost.Size = new System.Drawing.Size(488, 118);
            this.pnlCost.TabIndex = 157;
            this.pnlCost.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rdWithTax_运费);
            this.panel2.Controls.Add(this.rdWithoutTax__运费);
            this.panel2.Location = new System.Drawing.Point(238, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(145, 25);
            this.panel2.TabIndex = 138;
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
            // rdWithoutTax__运费
            // 
            this.rdWithoutTax__运费.AutoSize = true;
            this.rdWithoutTax__运费.Location = new System.Drawing.Point(57, 3);
            this.rdWithoutTax__运费.Name = "rdWithoutTax__运费";
            this.rdWithoutTax__运费.Size = new System.Drawing.Size(59, 16);
            this.rdWithoutTax__运费.TabIndex = 130;
            this.rdWithoutTax__运费.TabStop = true;
            this.rdWithoutTax__运费.Text = "不含税";
            this.rdWithoutTax__运费.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.rdWithTax_其它费用);
            this.panel4.Controls.Add(this.rdWithoutTax__其它费用);
            this.panel4.Location = new System.Drawing.Point(238, 87);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(145, 25);
            this.panel4.TabIndex = 137;
            // 
            // rdWithTax_其它费用
            // 
            this.rdWithTax_其它费用.AutoSize = true;
            this.rdWithTax_其它费用.Location = new System.Drawing.Point(4, 3);
            this.rdWithTax_其它费用.Name = "rdWithTax_其它费用";
            this.rdWithTax_其它费用.Size = new System.Drawing.Size(47, 16);
            this.rdWithTax_其它费用.TabIndex = 129;
            this.rdWithTax_其它费用.TabStop = true;
            this.rdWithTax_其它费用.Text = "含税";
            this.rdWithTax_其它费用.UseVisualStyleBackColor = true;
            // 
            // rdWithoutTax__其它费用
            // 
            this.rdWithoutTax__其它费用.AutoSize = true;
            this.rdWithoutTax__其它费用.Location = new System.Drawing.Point(57, 5);
            this.rdWithoutTax__其它费用.Name = "rdWithoutTax__其它费用";
            this.rdWithoutTax__其它费用.Size = new System.Drawing.Size(59, 16);
            this.rdWithoutTax__其它费用.TabIndex = 130;
            this.rdWithoutTax__其它费用.TabStop = true;
            this.rdWithoutTax__其它费用.Text = "不含税";
            this.rdWithoutTax__其它费用.UseVisualStyleBackColor = true;
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 94;
            this.label9.Text = "入库单价(/吨)";
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPurchasePrice.Location = new System.Drawing.Point(99, 19);
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 12);
            this.label11.TabIndex = 96;
            this.label11.Text = "其它费用(/吨)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 95;
            this.label12.Text = "运费(/吨)";
            // 
            // txtTransCost
            // 
            this.txtTransCost.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtTransCost.Location = new System.Drawing.Point(99, 54);
            this.txtTransCost.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtTransCost.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTransCost.Name = "txtTransCost";
            this.txtTransCost.PointCount = 2;
            this.txtTransCost.Size = new System.Drawing.Size(122, 21);
            this.txtTransCost.TabIndex = 97;
            this.txtTransCost.Text = "0";
            // 
            // txtOtherCost
            // 
            this.txtOtherCost.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtOtherCost.Location = new System.Drawing.Point(99, 89);
            this.txtOtherCost.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtOtherCost.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOtherCost.Name = "txtOtherCost";
            this.txtOtherCost.PointCount = 2;
            this.txtOtherCost.Size = new System.Drawing.Size(122, 21);
            this.txtOtherCost.TabIndex = 99;
            this.txtOtherCost.Text = "0";
            // 
            // chkOtherCostPrepay
            // 
            this.chkOtherCostPrepay.AutoSize = true;
            this.chkOtherCostPrepay.Location = new System.Drawing.Point(392, 91);
            this.chkOtherCostPrepay.Name = "chkOtherCostPrepay";
            this.chkOtherCostPrepay.Size = new System.Drawing.Size(84, 16);
            this.chkOtherCostPrepay.TabIndex = 135;
            this.chkOtherCostPrepay.Text = "供应商代垫";
            this.chkOtherCostPrepay.UseVisualStyleBackColor = true;
            // 
            // chkTransCostPrepay
            // 
            this.chkTransCostPrepay.AutoSize = true;
            this.chkTransCostPrepay.Location = new System.Drawing.Point(392, 56);
            this.chkTransCostPrepay.Name = "chkTransCostPrepay";
            this.chkTransCostPrepay.Size = new System.Drawing.Size(84, 16);
            this.chkTransCostPrepay.TabIndex = 136;
            this.chkTransCostPrepay.Text = "供应商代垫";
            this.chkTransCostPrepay.UseVisualStyleBackColor = true;
            // 
            // FrmSteelRollSliceStackIn
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(503, 523);
            this.Controls.Add(this.pnlCost);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtPurchaseID);
            this.Controls.Add(this.txtCarPlate);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel3);
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
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.lnkCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLength);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlCost.ResumeLayout(false);
            this.pnlCost.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
        private GeneralLibrary.WinformControl.DecimalTextBox txtWeight;
        private System.Windows.Forms.Label label2;
        private GeneralLibrary.WinformControl.DecimalTextBox txtLength;
        private System.Windows.Forms.Label label7;
        private GeneralLibrary.WinformControl.DBCTextBox txtCategory;
        private System.Windows.Forms.LinkLabel lnkCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rd开吨;
        private System.Windows.Forms.RadioButton rd开卷;
        private System.Windows.Forms.RadioButton rd开平;
        private System.Windows.Forms.Label label10;
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rd单件重;
        private System.Windows.Forms.RadioButton rd总重;
        private Controls.CarplateComboBox txtCarPlate;
        private Controls.MaterialComboBox txtMaterial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private GeneralLibrary.WinformControl.DBCTextBox txtPurchaseID;
        private System.Windows.Forms.GroupBox pnlCost;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdWithTax_运费;
        private System.Windows.Forms.RadioButton rdWithoutTax__运费;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdWithTax_其它费用;
        private System.Windows.Forms.RadioButton rdWithoutTax__其它费用;
        private System.Windows.Forms.Panel pnlTax;
        private System.Windows.Forms.RadioButton rdWithTax_入库单价;
        private System.Windows.Forms.RadioButton rdWithoutTax__入库单价;
        private System.Windows.Forms.Label label9;
        private GeneralLibrary.WinformControl.DecimalTextBox txtPurchasePrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private GeneralLibrary.WinformControl.DecimalTextBox txtTransCost;
        private GeneralLibrary.WinformControl.DecimalTextBox txtOtherCost;
        private System.Windows.Forms.CheckBox chkOtherCostPrepay;
        private System.Windows.Forms.CheckBox chkTransCostPrepay;

    }
}