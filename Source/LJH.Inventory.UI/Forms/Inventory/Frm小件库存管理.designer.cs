namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class Frm小件库存管理
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_CreateInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_修改入库单价 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_设置结算单价 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_查看价格改动记录 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_Check = new System.Windows.Forms.ToolStripMenuItem();
            this.折包ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_更换仓库 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Nullify = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cMnu_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Import = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLength = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtWeight = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.lblOriginalTotal = new System.Windows.Forms.Label();
            this.lblTotalWeight = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlStates = new System.Windows.Forms.Panel();
            this.chk待发货 = new System.Windows.Forms.CheckBox();
            this.chk预订 = new System.Windows.Forms.CheckBox();
            this.chk在库 = new System.Windows.Forms.CheckBox();
            this.chk发货 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk开卷 = new System.Windows.Forms.CheckBox();
            this.chk开条 = new System.Windows.Forms.CheckBox();
            this.chk开吨 = new System.Windows.Forms.CheckBox();
            this.chk开平 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkStackIn = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colInventoryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWareHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriginalThick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealThick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceRoll = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col含税出单位成本 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col不含税出单位成本 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col结算单价 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchaseTax = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTransCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOtherCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchaseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCarplate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliverySheet = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbBrand = new LJH.Inventory.UI.Controls.CustomerCombobox(this.components);
            this.cmbSupplier = new LJH.Inventory.UI.Controls.CustomerCombobox(this.components);
            this.ucDateTimeInterval1 = new LJH.Inventory.UI.Controls.UCDateTimeInterval();
            this.customerCombobox1 = new LJH.Inventory.UI.Controls.CustomerCombobox(this.components);
            this.categoryComboBox1 = new LJH.Inventory.UI.Controls.CategoryComboBox(this.components);
            this.wareHouseComboBox1 = new LJH.Inventory.UI.Controls.WareHouseComboBox(this.components);
            this.cmbSpecification = new LJH.Inventory.UI.Controls.SpecificationComboBox(this.components);
            this.chk作废 = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlStates.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMnu_Fresh,
            this.mnu_CreateInventory,
            this.toolStripSeparator2,
            this.mnu_修改入库单价,
            this.mnu_设置结算单价,
            this.mnu_查看价格改动记录,
            this.toolStripSeparator1,
            this.mnu_Check,
            this.折包ToolStripMenuItem,
            this.mnu_更换仓库,
            this.mnu_Nullify,
            this.toolStripSeparator3,
            this.cMnu_SelectColumns,
            this.cMnu_Export,
            this.mnu_Import});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 286);
            // 
            // cMnu_Fresh
            // 
            this.cMnu_Fresh.Name = "cMnu_Fresh";
            this.cMnu_Fresh.Size = new System.Drawing.Size(172, 22);
            this.cMnu_Fresh.Text = "刷新";
            // 
            // mnu_CreateInventory
            // 
            this.mnu_CreateInventory.Name = "mnu_CreateInventory";
            this.mnu_CreateInventory.Size = new System.Drawing.Size(172, 22);
            this.mnu_CreateInventory.Text = "新建库存";
            this.mnu_CreateInventory.Click += new System.EventHandler(this.mnu_CreateInventory_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // mnu_修改入库单价
            // 
            this.mnu_修改入库单价.Name = "mnu_修改入库单价";
            this.mnu_修改入库单价.Size = new System.Drawing.Size(172, 22);
            this.mnu_修改入库单价.Text = "修改入库价格";
            this.mnu_修改入库单价.Click += new System.EventHandler(this.mnu_修改入库单价_Click);
            // 
            // mnu_设置结算单价
            // 
            this.mnu_设置结算单价.Name = "mnu_设置结算单价";
            this.mnu_设置结算单价.Size = new System.Drawing.Size(172, 22);
            this.mnu_设置结算单价.Text = "设置结算价格";
            this.mnu_设置结算单价.Click += new System.EventHandler(this.mnu_设置结算单价_Click);
            // 
            // mnu_查看价格改动记录
            // 
            this.mnu_查看价格改动记录.Name = "mnu_查看价格改动记录";
            this.mnu_查看价格改动记录.Size = new System.Drawing.Size(172, 22);
            this.mnu_查看价格改动记录.Text = "查看价格改动记录";
            this.mnu_查看价格改动记录.Click += new System.EventHandler(this.查看价格改动记录ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // mnu_Check
            // 
            this.mnu_Check.Name = "mnu_Check";
            this.mnu_Check.Size = new System.Drawing.Size(172, 22);
            this.mnu_Check.Text = "盘点";
            this.mnu_Check.Click += new System.EventHandler(this.mnu_Check_Click);
            // 
            // 折包ToolStripMenuItem
            // 
            this.折包ToolStripMenuItem.Name = "折包ToolStripMenuItem";
            this.折包ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.折包ToolStripMenuItem.Text = "拆包";
            this.折包ToolStripMenuItem.Click += new System.EventHandler(this.折包ToolStripMenuItem_Click);
            // 
            // mnu_更换仓库
            // 
            this.mnu_更换仓库.Name = "mnu_更换仓库";
            this.mnu_更换仓库.Size = new System.Drawing.Size(172, 22);
            this.mnu_更换仓库.Text = "更换仓库";
            this.mnu_更换仓库.Click += new System.EventHandler(this.更换仓库ToolStripMenuItem_Click);
            // 
            // mnu_Nullify
            // 
            this.mnu_Nullify.Name = "mnu_Nullify";
            this.mnu_Nullify.Size = new System.Drawing.Size(172, 22);
            this.mnu_Nullify.Text = "作废";
            this.mnu_Nullify.Click += new System.EventHandler(this.mnu_Nullify_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // cMnu_SelectColumns
            // 
            this.cMnu_SelectColumns.Name = "cMnu_SelectColumns";
            this.cMnu_SelectColumns.Size = new System.Drawing.Size(172, 22);
            this.cMnu_SelectColumns.Text = "选择列...";
            // 
            // cMnu_Export
            // 
            this.cMnu_Export.Name = "cMnu_Export";
            this.cMnu_Export.Size = new System.Drawing.Size(172, 22);
            this.cMnu_Export.Text = "导出...";
            // 
            // mnu_Import
            // 
            this.mnu_Import.Name = "mnu_Import";
            this.mnu_Import.Size = new System.Drawing.Size(172, 22);
            this.mnu_Import.Text = "导入...";
            this.mnu_Import.Click += new System.EventHandler(this.mnu_Import_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cmbBrand);
            this.panel5.Controls.Add(this.cmbSupplier);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.txtLength);
            this.panel5.Controls.Add(this.txtWeight);
            this.panel5.Controls.Add(this.lblOriginalTotal);
            this.panel5.Controls.Add(this.lblTotalWeight);
            this.panel5.Controls.Add(this.ucDateTimeInterval1);
            this.panel5.Controls.Add(this.customerCombobox1);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.pnlStates);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.categoryComboBox1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.wareHouseComboBox1);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.cmbSpecification);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.chkStackIn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1341, 93);
            this.panel5.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(466, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 98;
            this.label2.Text = "长度";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(466, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 97;
            this.label10.Text = "重量";
            // 
            // txtLength
            // 
            this.txtLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLength.Location = new System.Drawing.Point(501, 50);
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
            this.txtLength.PointCount = 3;
            this.txtLength.Size = new System.Drawing.Size(81, 21);
            this.txtLength.TabIndex = 96;
            this.txtLength.Text = "0";
            this.txtLength.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // txtWeight
            // 
            this.txtWeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWeight.Location = new System.Drawing.Point(501, 15);
            this.txtWeight.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtWeight.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.PointCount = 3;
            this.txtWeight.Size = new System.Drawing.Size(81, 21);
            this.txtWeight.TabIndex = 95;
            this.txtWeight.Text = "0";
            this.txtWeight.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // lblOriginalTotal
            // 
            this.lblOriginalTotal.AutoSize = true;
            this.lblOriginalTotal.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOriginalTotal.ForeColor = System.Drawing.Color.Blue;
            this.lblOriginalTotal.Location = new System.Drawing.Point(1198, 52);
            this.lblOriginalTotal.Name = "lblOriginalTotal";
            this.lblOriginalTotal.Size = new System.Drawing.Size(22, 21);
            this.lblOriginalTotal.TabIndex = 94;
            this.lblOriginalTotal.Text = "0";
            // 
            // lblTotalWeight
            // 
            this.lblTotalWeight.AutoSize = true;
            this.lblTotalWeight.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalWeight.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalWeight.Location = new System.Drawing.Point(1198, 17);
            this.lblTotalWeight.Name = "lblTotalWeight";
            this.lblTotalWeight.Size = new System.Drawing.Size(22, 21);
            this.lblTotalWeight.TabIndex = 93;
            this.lblTotalWeight.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(322, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 90;
            this.label8.Text = "客户";
            // 
            // pnlStates
            // 
            this.pnlStates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStates.Controls.Add(this.chk作废);
            this.pnlStates.Controls.Add(this.chk待发货);
            this.pnlStates.Controls.Add(this.chk预订);
            this.pnlStates.Controls.Add(this.chk在库);
            this.pnlStates.Controls.Add(this.chk发货);
            this.pnlStates.Location = new System.Drawing.Point(965, 35);
            this.pnlStates.Name = "pnlStates";
            this.pnlStates.Size = new System.Drawing.Size(218, 47);
            this.pnlStates.TabIndex = 89;
            // 
            // chk待发货
            // 
            this.chk待发货.AutoSize = true;
            this.chk待发货.Checked = true;
            this.chk待发货.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk待发货.Location = new System.Drawing.Point(102, 3);
            this.chk待发货.Name = "chk待发货";
            this.chk待发货.Size = new System.Drawing.Size(60, 16);
            this.chk待发货.TabIndex = 54;
            this.chk待发货.Text = "待发货";
            this.chk待发货.UseVisualStyleBackColor = true;
            this.chk待发货.CheckStateChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chk预订
            // 
            this.chk预订.AutoSize = true;
            this.chk预订.Checked = true;
            this.chk预订.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk预订.Location = new System.Drawing.Point(54, 3);
            this.chk预订.Name = "chk预订";
            this.chk预订.Size = new System.Drawing.Size(48, 16);
            this.chk预订.TabIndex = 53;
            this.chk预订.Text = "预订";
            this.chk预订.UseVisualStyleBackColor = true;
            this.chk预订.CheckStateChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chk在库
            // 
            this.chk在库.AutoSize = true;
            this.chk在库.Checked = true;
            this.chk在库.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk在库.Location = new System.Drawing.Point(5, 3);
            this.chk在库.Name = "chk在库";
            this.chk在库.Size = new System.Drawing.Size(48, 16);
            this.chk在库.TabIndex = 52;
            this.chk在库.Text = "在库";
            this.chk在库.UseVisualStyleBackColor = true;
            this.chk在库.CheckStateChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chk发货
            // 
            this.chk发货.AutoSize = true;
            this.chk发货.Location = new System.Drawing.Point(5, 25);
            this.chk发货.Name = "chk发货";
            this.chk发货.Size = new System.Drawing.Size(48, 16);
            this.chk发货.TabIndex = 51;
            this.chk发货.Text = "发货";
            this.chk发货.UseVisualStyleBackColor = true;
            this.chk发货.CheckedChanged += new System.EventHandler(this.chk发货_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(906, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 88;
            this.label7.Text = "库存状态";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chk开卷);
            this.panel1.Controls.Add(this.chk开条);
            this.panel1.Controls.Add(this.chk开吨);
            this.panel1.Controls.Add(this.chk开平);
            this.panel1.Location = new System.Drawing.Point(965, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 24);
            this.panel1.TabIndex = 87;
            // 
            // chk开卷
            // 
            this.chk开卷.AutoSize = true;
            this.chk开卷.Checked = true;
            this.chk开卷.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk开卷.Location = new System.Drawing.Point(56, 3);
            this.chk开卷.Name = "chk开卷";
            this.chk开卷.Size = new System.Drawing.Size(48, 16);
            this.chk开卷.TabIndex = 95;
            this.chk开卷.Text = "开卷";
            this.chk开卷.UseVisualStyleBackColor = true;
            this.chk开卷.CheckStateChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chk开条
            // 
            this.chk开条.AutoSize = true;
            this.chk开条.Checked = true;
            this.chk开条.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk开条.Location = new System.Drawing.Point(114, 3);
            this.chk开条.Name = "chk开条";
            this.chk开条.Size = new System.Drawing.Size(48, 16);
            this.chk开条.TabIndex = 94;
            this.chk开条.Text = "开条";
            this.chk开条.UseVisualStyleBackColor = true;
            this.chk开条.CheckStateChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chk开吨
            // 
            this.chk开吨.AutoSize = true;
            this.chk开吨.Checked = true;
            this.chk开吨.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk开吨.Location = new System.Drawing.Point(169, 3);
            this.chk开吨.Name = "chk开吨";
            this.chk开吨.Size = new System.Drawing.Size(48, 16);
            this.chk开吨.TabIndex = 93;
            this.chk开吨.Text = "开吨";
            this.chk开吨.UseVisualStyleBackColor = true;
            this.chk开吨.CheckStateChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chk开平
            // 
            this.chk开平.AutoSize = true;
            this.chk开平.Checked = true;
            this.chk开平.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk开平.Location = new System.Drawing.Point(2, 3);
            this.chk开平.Name = "chk开平";
            this.chk开平.Size = new System.Drawing.Size(48, 16);
            this.chk开平.TabIndex = 92;
            this.chk开平.Text = "开平";
            this.chk开平.UseVisualStyleBackColor = true;
            this.chk开平.CheckStateChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(906, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 86;
            this.label6.Text = "物料状态";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 84;
            this.label1.Text = "类别";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 81;
            this.label4.Text = "仓库";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 79;
            this.label3.Text = "供应商";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(168, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 77;
            this.label9.Text = "厂家";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(322, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 75;
            this.label5.Text = "规格";
            // 
            // chkStackIn
            // 
            this.chkStackIn.AutoSize = true;
            this.chkStackIn.Location = new System.Drawing.Point(595, 15);
            this.chkStackIn.Name = "chkStackIn";
            this.chkStackIn.Size = new System.Drawing.Size(72, 16);
            this.chkStackIn.TabIndex = 44;
            this.chkStackIn.Text = "入库日期";
            this.chkStackIn.UseVisualStyleBackColor = true;
            this.chkStackIn.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInventoryDate,
            this.colWareHouse,
            this.colCategory,
            this.colModel,
            this.colSpecification,
            this.colWeight,
            this.colLength,
            this.colOriginalThick,
            this.colRealThick,
            this.colCount,
            this.colCustomer,
            this.colManufacture,
            this.colSupplier,
            this.colSourceRoll,
            this.col含税出单位成本,
            this.col不含税出单位成本,
            this.colPurchasePrice,
            this.col结算单价,
            this.colPurchaseTax,
            this.colTransCost,
            this.colOtherCost,
            this.colMaterial,
            this.colPurchaseID,
            this.colCarplate,
            this.colDeliverySheet,
            this.colMemo});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1341, 483);
            this.dataGridView1.TabIndex = 116;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // colInventoryDate
            // 
            this.colInventoryDate.HeaderText = "日期";
            this.colInventoryDate.Name = "colInventoryDate";
            this.colInventoryDate.ReadOnly = true;
            // 
            // colWareHouse
            // 
            this.colWareHouse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colWareHouse.HeaderText = "仓库";
            this.colWareHouse.Name = "colWareHouse";
            this.colWareHouse.ReadOnly = true;
            this.colWareHouse.Width = 54;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "类别";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 60;
            // 
            // colModel
            // 
            this.colModel.HeaderText = "加工";
            this.colModel.Name = "colModel";
            this.colModel.ReadOnly = true;
            this.colModel.Width = 60;
            // 
            // colSpecification
            // 
            this.colSpecification.HeaderText = "规格";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            this.colSpecification.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSpecification.Width = 80;
            // 
            // colWeight
            // 
            dataGridViewCellStyle12.Format = "N3";
            dataGridViewCellStyle12.NullValue = null;
            this.colWeight.DefaultCellStyle = dataGridViewCellStyle12;
            this.colWeight.HeaderText = "重量(吨)";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            this.colWeight.Width = 80;
            // 
            // colLength
            // 
            dataGridViewCellStyle13.Format = "N3";
            dataGridViewCellStyle13.NullValue = null;
            this.colLength.DefaultCellStyle = dataGridViewCellStyle13;
            this.colLength.HeaderText = "长度(米)";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.Width = 80;
            // 
            // colOriginalThick
            // 
            dataGridViewCellStyle14.Format = "N3";
            this.colOriginalThick.DefaultCellStyle = dataGridViewCellStyle14;
            this.colOriginalThick.HeaderText = "入库厚度";
            this.colOriginalThick.Name = "colOriginalThick";
            this.colOriginalThick.ReadOnly = true;
            this.colOriginalThick.Width = 80;
            // 
            // colRealThick
            // 
            dataGridViewCellStyle15.Format = "N3";
            dataGridViewCellStyle15.NullValue = null;
            this.colRealThick.DefaultCellStyle = dataGridViewCellStyle15;
            this.colRealThick.HeaderText = "开平厚度";
            this.colRealThick.Name = "colRealThick";
            this.colRealThick.ReadOnly = true;
            this.colRealThick.Width = 80;
            // 
            // colCount
            // 
            dataGridViewCellStyle16.Format = "N0";
            dataGridViewCellStyle16.NullValue = "?";
            this.colCount.DefaultCellStyle = dataGridViewCellStyle16;
            this.colCount.HeaderText = "数量";
            this.colCount.Name = "colCount";
            this.colCount.ReadOnly = true;
            this.colCount.Width = 80;
            // 
            // colCustomer
            // 
            this.colCustomer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colCustomer.HeaderText = "客户";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.Width = 54;
            // 
            // colManufacture
            // 
            this.colManufacture.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colManufacture.HeaderText = "厂家";
            this.colManufacture.Name = "colManufacture";
            this.colManufacture.ReadOnly = true;
            this.colManufacture.Width = 54;
            // 
            // colSupplier
            // 
            this.colSupplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSupplier.HeaderText = "供应商";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.ReadOnly = true;
            this.colSupplier.Width = 66;
            // 
            // colSourceRoll
            // 
            this.colSourceRoll.HeaderText = "来源卷";
            this.colSourceRoll.Name = "colSourceRoll";
            this.colSourceRoll.ReadOnly = true;
            this.colSourceRoll.Width = 60;
            // 
            // col含税出单位成本
            // 
            dataGridViewCellStyle17.Format = "C2";
            this.col含税出单位成本.DefaultCellStyle = dataGridViewCellStyle17;
            this.col含税出单位成本.HeaderText = "含税出单位成本";
            this.col含税出单位成本.Name = "col含税出单位成本";
            this.col含税出单位成本.ReadOnly = true;
            this.col含税出单位成本.Width = 80;
            // 
            // col不含税出单位成本
            // 
            dataGridViewCellStyle18.Format = "C2";
            this.col不含税出单位成本.DefaultCellStyle = dataGridViewCellStyle18;
            this.col不含税出单位成本.HeaderText = "不含税出单位成本";
            this.col不含税出单位成本.Name = "col不含税出单位成本";
            this.col不含税出单位成本.ReadOnly = true;
            this.col不含税出单位成本.Width = 80;
            // 
            // colPurchasePrice
            // 
            dataGridViewCellStyle19.Format = "C2";
            this.colPurchasePrice.DefaultCellStyle = dataGridViewCellStyle19;
            this.colPurchasePrice.HeaderText = "入库吨价";
            this.colPurchasePrice.Name = "colPurchasePrice";
            this.colPurchasePrice.ReadOnly = true;
            this.colPurchasePrice.Width = 80;
            // 
            // col结算单价
            // 
            dataGridViewCellStyle20.Format = "C2";
            this.col结算单价.DefaultCellStyle = dataGridViewCellStyle20;
            this.col结算单价.HeaderText = "结算吨价";
            this.col结算单价.Name = "col结算单价";
            this.col结算单价.ReadOnly = true;
            this.col结算单价.Width = 80;
            // 
            // colPurchaseTax
            // 
            this.colPurchaseTax.HeaderText = "含税";
            this.colPurchaseTax.Name = "colPurchaseTax";
            this.colPurchaseTax.ReadOnly = true;
            this.colPurchaseTax.Width = 40;
            // 
            // colTransCost
            // 
            dataGridViewCellStyle21.Format = "C2";
            this.colTransCost.DefaultCellStyle = dataGridViewCellStyle21;
            this.colTransCost.HeaderText = "运费";
            this.colTransCost.Name = "colTransCost";
            this.colTransCost.ReadOnly = true;
            this.colTransCost.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTransCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTransCost.Width = 80;
            // 
            // colOtherCost
            // 
            dataGridViewCellStyle22.Format = "C2";
            this.colOtherCost.DefaultCellStyle = dataGridViewCellStyle22;
            this.colOtherCost.HeaderText = "其它费用";
            this.colOtherCost.Name = "colOtherCost";
            this.colOtherCost.ReadOnly = true;
            this.colOtherCost.Width = 80;
            // 
            // colMaterial
            // 
            this.colMaterial.HeaderText = "材质";
            this.colMaterial.Name = "colMaterial";
            this.colMaterial.ReadOnly = true;
            // 
            // colPurchaseID
            // 
            this.colPurchaseID.HeaderText = "合同号";
            this.colPurchaseID.Name = "colPurchaseID";
            this.colPurchaseID.ReadOnly = true;
            // 
            // colCarplate
            // 
            this.colCarplate.HeaderText = "车皮号";
            this.colCarplate.Name = "colCarplate";
            this.colCarplate.ReadOnly = true;
            // 
            // colDeliverySheet
            // 
            this.colDeliverySheet.HeaderText = "送货单";
            this.colDeliverySheet.Name = "colDeliverySheet";
            this.colDeliverySheet.ReadOnly = true;
            this.colDeliverySheet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDeliverySheet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colMemo
            // 
            this.colMemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            this.colMemo.Width = 51;
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(202, 50);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(108, 20);
            this.cmbBrand.TabIndex = 100;
            this.cmbBrand.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(54, 50);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(106, 20);
            this.cmbSupplier.TabIndex = 99;
            this.cmbSupplier.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // ucDateTimeInterval1
            // 
            this.ucDateTimeInterval1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDateTimeInterval1.EndDateTime = new System.DateTime(2015, 11, 19, 10, 3, 12, 722);
            this.ucDateTimeInterval1.Location = new System.Drawing.Point(670, 7);
            this.ucDateTimeInterval1.Name = "ucDateTimeInterval1";
            this.ucDateTimeInterval1.ShowTime = true;
            this.ucDateTimeInterval1.Size = new System.Drawing.Size(221, 74);
            this.ucDateTimeInterval1.StartDateTime = new System.DateTime(2015, 11, 19, 10, 3, 12, 722);
            this.ucDateTimeInterval1.TabIndex = 92;
            this.ucDateTimeInterval1.ValueChanged += new System.EventHandler(this.ucDateTimeInterval1_ValueChanged);
            // 
            // customerCombobox1
            // 
            this.customerCombobox1.FormattingEnabled = true;
            this.customerCombobox1.Location = new System.Drawing.Point(354, 50);
            this.customerCombobox1.Name = "customerCombobox1";
            this.customerCombobox1.Size = new System.Drawing.Size(99, 20);
            this.customerCombobox1.TabIndex = 91;
            this.customerCombobox1.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // categoryComboBox1
            // 
            this.categoryComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox1.FormattingEnabled = true;
            this.categoryComboBox1.Location = new System.Drawing.Point(202, 14);
            this.categoryComboBox1.Name = "categoryComboBox1";
            this.categoryComboBox1.Size = new System.Drawing.Size(108, 20);
            this.categoryComboBox1.TabIndex = 85;
            this.categoryComboBox1.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // wareHouseComboBox1
            // 
            this.wareHouseComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wareHouseComboBox1.FormattingEnabled = true;
            this.wareHouseComboBox1.Location = new System.Drawing.Point(54, 14);
            this.wareHouseComboBox1.Name = "wareHouseComboBox1";
            this.wareHouseComboBox1.Size = new System.Drawing.Size(106, 20);
            this.wareHouseComboBox1.TabIndex = 83;
            this.wareHouseComboBox1.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // cmbSpecification
            // 
            this.cmbSpecification.FormattingEnabled = true;
            this.cmbSpecification.Location = new System.Drawing.Point(354, 14);
            this.cmbSpecification.Name = "cmbSpecification";
            this.cmbSpecification.Size = new System.Drawing.Size(99, 20);
            this.cmbSpecification.TabIndex = 76;
            this.cmbSpecification.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chk作废
            // 
            this.chk作废.AutoSize = true;
            this.chk作废.Location = new System.Drawing.Point(54, 25);
            this.chk作废.Name = "chk作废";
            this.chk作废.Size = new System.Drawing.Size(48, 16);
            this.chk作废.TabIndex = 55;
            this.chk作废.Text = "作废";
            this.chk作废.UseVisualStyleBackColor = true;
            this.chk作废.CheckedChanged += new System.EventHandler(this.chk发货_CheckedChanged);
            // 
            // Frm小件库存管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 598);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel5);
            this.Name = "Frm小件库存管理";
            this.Text = "小件库存明细";
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlStates.ResumeLayout(false);
            this.pnlStates.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cMnu_SelectColumns;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
        private System.Windows.Forms.ToolStripMenuItem mnu_Check;
        private System.Windows.Forms.ToolStripMenuItem mnu_CreateInventory;
        private System.Windows.Forms.ToolStripMenuItem 折包ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_更换仓库;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnu_修改入库单价;
        private System.Windows.Forms.ToolStripMenuItem mnu_设置结算单价;
        private System.Windows.Forms.ToolStripMenuItem mnu_查看价格改动记录;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblOriginalTotal;
        private System.Windows.Forms.Label lblTotalWeight;
        private Controls.UCDateTimeInterval ucDateTimeInterval1;
        private Controls.CustomerCombobox customerCombobox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlStates;
        internal System.Windows.Forms.CheckBox chk待发货;
        internal System.Windows.Forms.CheckBox chk预订;
        internal System.Windows.Forms.CheckBox chk在库;
        internal System.Windows.Forms.CheckBox chk发货;
        private System.Windows.Forms.Label label7;
        private Controls.CategoryComboBox categoryComboBox1;
        private System.Windows.Forms.Label label1;
        private Controls.WareHouseComboBox wareHouseComboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private Controls.SpecificationComboBox cmbSpecification;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkStackIn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chk开卷;
        private System.Windows.Forms.CheckBox chk开条;
        private System.Windows.Forms.CheckBox chk开吨;
        private System.Windows.Forms.CheckBox chk开平;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private GeneralLibrary.WinformControl.DecimalTextBox txtLength;
        private GeneralLibrary.WinformControl.DecimalTextBox txtWeight;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Controls.CustomerCombobox cmbBrand;
        private Controls.CustomerCombobox cmbSupplier;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Fresh;
        private System.Windows.Forms.ToolStripMenuItem mnu_Import;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnu_Nullify;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInventoryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWareHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriginalThick;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealThick;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacture;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;
        private System.Windows.Forms.DataGridViewLinkColumn colSourceRoll;
        private System.Windows.Forms.DataGridViewTextBoxColumn col含税出单位成本;
        private System.Windows.Forms.DataGridViewTextBoxColumn col不含税出单位成本;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn col结算单价;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPurchaseTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOtherCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchaseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCarplate;
        private System.Windows.Forms.DataGridViewLinkColumn colDeliverySheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        internal System.Windows.Forms.CheckBox chk作废;

    }
}