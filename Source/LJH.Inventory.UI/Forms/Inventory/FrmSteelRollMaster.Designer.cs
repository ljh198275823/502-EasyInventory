namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class FrmSteelRollMaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWeight = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.cmbBrand = new LJH.Inventory.UI.Controls.CustomerCombobox(this.components);
            this.cmbSupplier = new LJH.Inventory.UI.Controls.CustomerCombobox(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.txtPurchaseID = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lblOriginalTotal = new System.Windows.Forms.Label();
            this.lblTotalWeight = new System.Windows.Forms.Label();
            this.ucDateTimeInterval1 = new LJH.Inventory.UI.Controls.UCDateTimeInterval();
            this.customerCombobox1 = new LJH.Inventory.UI.Controls.CustomerCombobox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.pnlStates = new System.Windows.Forms.Panel();
            this.chk待发货 = new System.Windows.Forms.CheckBox();
            this.chk预订 = new System.Windows.Forms.CheckBox();
            this.chk在库 = new System.Windows.Forms.CheckBox();
            this.chk作废 = new System.Windows.Forms.CheckBox();
            this.chk发货 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkIntact = new System.Windows.Forms.CheckBox();
            this.chkPartial = new System.Windows.Forms.CheckBox();
            this.chkOnlyTail = new System.Windows.Forms.CheckBox();
            this.chkRemainless = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.categoryComboBox1 = new LJH.Inventory.UI.Controls.CategoryComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.wareHouseComboBox1 = new LJH.Inventory.UI.Controls.WareHouseComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSpecification = new LJH.Inventory.UI.Controls.SpecificationComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.chkStackIn = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_设置入库单价 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_设置其它成本 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_查看成本明细 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_查看价格改动记录 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.加工ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_开平 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_开卷 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_开条 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_开吨 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_SliceView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.更换仓库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Check = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_CheckView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cMnu_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Import = new System.Windows.Forms.ToolStripMenuItem();
            this.更多操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.预订ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消预订ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_拆卷 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_原材料拆条 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Nullify = new System.Windows.Forms.ToolStripMenuItem();
            this.colAddDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWareHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriginalWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriginalLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriginalThick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealThick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliverySheet = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colPurchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchaseTax = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col运费 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col开平费 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col吊装费 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col其它费用 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCarplate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchaseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceRoll = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colOperator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilter.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlStates.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.panel5);
            this.pnlFilter.Controls.Add(this.panel4);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1362, 86);
            this.pnlFilter.TabIndex = 112;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.txtWeight);
            this.panel5.Controls.Add(this.cmbBrand);
            this.panel5.Controls.Add(this.cmbSupplier);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.txtPurchaseID);
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
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(1, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1361, 86);
            this.panel5.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 150;
            this.label2.Text = "重量";
            // 
            // txtWeight
            // 
            this.txtWeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWeight.Location = new System.Drawing.Point(501, 13);
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
            this.txtWeight.Size = new System.Drawing.Size(63, 21);
            this.txtWeight.TabIndex = 149;
            this.txtWeight.Text = "0";
            this.txtWeight.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(202, 49);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(108, 20);
            this.cmbBrand.TabIndex = 148;
            this.cmbBrand.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(54, 49);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(106, 20);
            this.cmbSupplier.TabIndex = 147;
            this.cmbSupplier.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(458, 53);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 146;
            this.label15.Text = "合同号";
            // 
            // txtPurchaseID
            // 
            this.txtPurchaseID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPurchaseID.Location = new System.Drawing.Point(501, 49);
            this.txtPurchaseID.Name = "txtPurchaseID";
            this.txtPurchaseID.Size = new System.Drawing.Size(114, 21);
            this.txtPurchaseID.TabIndex = 145;
            this.txtPurchaseID.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // lblOriginalTotal
            // 
            this.lblOriginalTotal.AutoSize = true;
            this.lblOriginalTotal.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOriginalTotal.ForeColor = System.Drawing.Color.Blue;
            this.lblOriginalTotal.Location = new System.Drawing.Point(1155, 17);
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
            this.lblTotalWeight.Location = new System.Drawing.Point(1155, 47);
            this.lblTotalWeight.Name = "lblTotalWeight";
            this.lblTotalWeight.Size = new System.Drawing.Size(22, 21);
            this.lblTotalWeight.TabIndex = 93;
            this.lblTotalWeight.Text = "0";
            // 
            // ucDateTimeInterval1
            // 
            this.ucDateTimeInterval1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDateTimeInterval1.EndDateTime = new System.DateTime(2015, 11, 19, 10, 3, 12, 722);
            this.ucDateTimeInterval1.Location = new System.Drawing.Point(645, 7);
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
            this.customerCombobox1.Location = new System.Drawing.Point(349, 49);
            this.customerCombobox1.Name = "customerCombobox1";
            this.customerCombobox1.Size = new System.Drawing.Size(99, 20);
            this.customerCombobox1.TabIndex = 91;
            this.customerCombobox1.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(317, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 90;
            this.label8.Text = "客户";
            // 
            // pnlStates
            // 
            this.pnlStates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStates.Controls.Add(this.chk待发货);
            this.pnlStates.Controls.Add(this.chk预订);
            this.pnlStates.Controls.Add(this.chk在库);
            this.pnlStates.Controls.Add(this.chk作废);
            this.pnlStates.Controls.Add(this.chk发货);
            this.pnlStates.Location = new System.Drawing.Point(940, 35);
            this.pnlStates.Name = "pnlStates";
            this.pnlStates.Size = new System.Drawing.Size(205, 47);
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
            this.chk待发货.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
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
            this.chk预订.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
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
            this.chk在库.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chk作废
            // 
            this.chk作废.AutoSize = true;
            this.chk作废.Location = new System.Drawing.Point(54, 26);
            this.chk作废.Name = "chk作废";
            this.chk作废.Size = new System.Drawing.Size(48, 16);
            this.chk作废.TabIndex = 50;
            this.chk作废.Text = "作废";
            this.chk作废.UseVisualStyleBackColor = true;
            this.chk作废.CheckedChanged += new System.EventHandler(this.chk发货_CheckedChanged);
            // 
            // chk发货
            // 
            this.chk发货.AutoSize = true;
            this.chk发货.Location = new System.Drawing.Point(5, 26);
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
            this.label7.Location = new System.Drawing.Point(881, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 88;
            this.label7.Text = "库存状态";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkIntact);
            this.panel1.Controls.Add(this.chkPartial);
            this.panel1.Controls.Add(this.chkOnlyTail);
            this.panel1.Controls.Add(this.chkRemainless);
            this.panel1.Location = new System.Drawing.Point(940, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 24);
            this.panel1.TabIndex = 87;
            // 
            // chkIntact
            // 
            this.chkIntact.AutoSize = true;
            this.chkIntact.Checked = true;
            this.chkIntact.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIntact.Location = new System.Drawing.Point(3, 3);
            this.chkIntact.Name = "chkIntact";
            this.chkIntact.Size = new System.Drawing.Size(48, 16);
            this.chkIntact.TabIndex = 46;
            this.chkIntact.Text = "整卷";
            this.chkIntact.UseVisualStyleBackColor = true;
            this.chkIntact.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chkPartial
            // 
            this.chkPartial.AutoSize = true;
            this.chkPartial.Checked = true;
            this.chkPartial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPartial.Location = new System.Drawing.Point(52, 3);
            this.chkPartial.Name = "chkPartial";
            this.chkPartial.Size = new System.Drawing.Size(48, 16);
            this.chkPartial.TabIndex = 47;
            this.chkPartial.Text = "余卷";
            this.chkPartial.UseVisualStyleBackColor = true;
            this.chkPartial.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chkOnlyTail
            // 
            this.chkOnlyTail.AutoSize = true;
            this.chkOnlyTail.Checked = true;
            this.chkOnlyTail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyTail.Location = new System.Drawing.Point(101, 3);
            this.chkOnlyTail.Name = "chkOnlyTail";
            this.chkOnlyTail.Size = new System.Drawing.Size(48, 16);
            this.chkOnlyTail.TabIndex = 48;
            this.chkOnlyTail.Text = "尾卷";
            this.chkOnlyTail.UseVisualStyleBackColor = true;
            this.chkOnlyTail.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chkRemainless
            // 
            this.chkRemainless.AutoSize = true;
            this.chkRemainless.Location = new System.Drawing.Point(150, 3);
            this.chkRemainless.Name = "chkRemainless";
            this.chkRemainless.Size = new System.Drawing.Size(48, 16);
            this.chkRemainless.TabIndex = 49;
            this.chkRemainless.Text = "余料";
            this.chkRemainless.UseVisualStyleBackColor = true;
            this.chkRemainless.CheckedChanged += new System.EventHandler(this.chk发货_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(881, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 86;
            this.label6.Text = "物料状态";
            // 
            // categoryComboBox1
            // 
            this.categoryComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox1.FormattingEnabled = true;
            this.categoryComboBox1.Location = new System.Drawing.Point(202, 14);
            this.categoryComboBox1.Name = "categoryComboBox1";
            this.categoryComboBox1.Size = new System.Drawing.Size(108, 20);
            this.categoryComboBox1.TabIndex = 85;
            this.categoryComboBox1.SelectedIndexChanged += new System.EventHandler(this.FreshData_Clicked);
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
            // wareHouseComboBox1
            // 
            this.wareHouseComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wareHouseComboBox1.FormattingEnabled = true;
            this.wareHouseComboBox1.Location = new System.Drawing.Point(54, 14);
            this.wareHouseComboBox1.Name = "wareHouseComboBox1";
            this.wareHouseComboBox1.Size = new System.Drawing.Size(106, 20);
            this.wareHouseComboBox1.TabIndex = 83;
            this.wareHouseComboBox1.SelectedIndexChanged += new System.EventHandler(this.FreshData_Clicked);
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
            this.label3.Location = new System.Drawing.Point(10, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 79;
            this.label3.Text = "供应商";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(168, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 77;
            this.label9.Text = "厂家";
            // 
            // cmbSpecification
            // 
            this.cmbSpecification.FormattingEnabled = true;
            this.cmbSpecification.Location = new System.Drawing.Point(349, 14);
            this.cmbSpecification.Name = "cmbSpecification";
            this.cmbSpecification.Size = new System.Drawing.Size(99, 20);
            this.cmbSpecification.TabIndex = 76;
            this.cmbSpecification.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(317, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 75;
            this.label5.Text = "规格";
            // 
            // chkStackIn
            // 
            this.chkStackIn.AutoSize = true;
            this.chkStackIn.Location = new System.Drawing.Point(570, 15);
            this.chkStackIn.Name = "chkStackIn";
            this.chkStackIn.Size = new System.Drawing.Size(72, 16);
            this.chkStackIn.TabIndex = 44;
            this.chkStackIn.Text = "入库日期";
            this.chkStackIn.UseVisualStyleBackColor = true;
            this.chkStackIn.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 86);
            this.panel4.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAddDate,
            this.colWareHouse,
            this.colCategory,
            this.colSpecification,
            this.colOriginalWeight,
            this.colOriginalLength,
            this.colWeight,
            this.colLength,
            this.colOriginalThick,
            this.colRealThick,
            this.colCustomer,
            this.colSupplier,
            this.colManufacture,
            this.colSerialNumber,
            this.colStatus,
            this.colState,
            this.colDeliverySheet,
            this.colPurchasePrice,
            this.colPurchaseTax,
            this.col运费,
            this.col开平费,
            this.col吊装费,
            this.col其它费用,
            this.colPosition,
            this.colMaterial,
            this.colCarplate,
            this.colPurchaseID,
            this.colSourceRoll,
            this.colOperator,
            this.colMemo});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1362, 446);
            this.dataGridView1.TabIndex = 115;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMnu_Fresh,
            this.cMnu_Add,
            this.toolStripSeparator3,
            this.mnu_设置入库单价,
            this.mnu_设置其它成本,
            this.mnu_查看成本明细,
            this.mnu_查看价格改动记录,
            this.toolStripSeparator2,
            this.加工ToolStripMenuItem,
            this.mnu_SliceView,
            this.toolStripSeparator1,
            this.更换仓库ToolStripMenuItem,
            this.mnu_Check,
            this.mnu_CheckView,
            this.toolStripSeparator4,
            this.cMnu_SelectColumns,
            this.cMnu_Export,
            this.mnu_Import,
            this.更多操作ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 358);
            // 
            // cMnu_Fresh
            // 
            this.cMnu_Fresh.Name = "cMnu_Fresh";
            this.cMnu_Fresh.Size = new System.Drawing.Size(172, 22);
            this.cMnu_Fresh.Text = "刷新";
            // 
            // cMnu_Add
            // 
            this.cMnu_Add.Name = "cMnu_Add";
            this.cMnu_Add.Size = new System.Drawing.Size(172, 22);
            this.cMnu_Add.Text = "原材料入库";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // mnu_设置入库单价
            // 
            this.mnu_设置入库单价.Name = "mnu_设置入库单价";
            this.mnu_设置入库单价.Size = new System.Drawing.Size(172, 22);
            this.mnu_设置入库单价.Text = "设置入库价格";
            this.mnu_设置入库单价.Click += new System.EventHandler(this.mnu_设置入库单价_Click);
            // 
            // mnu_设置其它成本
            // 
            this.mnu_设置其它成本.Name = "mnu_设置其它成本";
            this.mnu_设置其它成本.Size = new System.Drawing.Size(172, 22);
            this.mnu_设置其它成本.Text = "设置其它成本";
            this.mnu_设置其它成本.Click += new System.EventHandler(this.mnu_设置其它成本_Click);
            // 
            // mnu_查看成本明细
            // 
            this.mnu_查看成本明细.Name = "mnu_查看成本明细";
            this.mnu_查看成本明细.Size = new System.Drawing.Size(172, 22);
            this.mnu_查看成本明细.Text = "查看成本明细";
            this.mnu_查看成本明细.Click += new System.EventHandler(this.mnu_查看成本明细_Click);
            // 
            // mnu_查看价格改动记录
            // 
            this.mnu_查看价格改动记录.Name = "mnu_查看价格改动记录";
            this.mnu_查看价格改动记录.Size = new System.Drawing.Size(172, 22);
            this.mnu_查看价格改动记录.Text = "查看价格改动记录";
            this.mnu_查看价格改动记录.Click += new System.EventHandler(this.查看价格改动记录ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // 加工ToolStripMenuItem
            // 
            this.加工ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_开平,
            this.mnu_开卷,
            this.mnu_开条,
            this.mnu_开吨});
            this.加工ToolStripMenuItem.Name = "加工ToolStripMenuItem";
            this.加工ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.加工ToolStripMenuItem.Text = "加工...";
            // 
            // mnu_开平
            // 
            this.mnu_开平.Name = "mnu_开平";
            this.mnu_开平.Size = new System.Drawing.Size(100, 22);
            this.mnu_开平.Text = "开平";
            this.mnu_开平.Click += new System.EventHandler(this.mnu_Slice_Click);
            // 
            // mnu_开卷
            // 
            this.mnu_开卷.Name = "mnu_开卷";
            this.mnu_开卷.Size = new System.Drawing.Size(100, 22);
            this.mnu_开卷.Text = "开卷";
            this.mnu_开卷.Click += new System.EventHandler(this.mnu_Slice_Click);
            // 
            // mnu_开条
            // 
            this.mnu_开条.Name = "mnu_开条";
            this.mnu_开条.Size = new System.Drawing.Size(100, 22);
            this.mnu_开条.Text = "开条";
            this.mnu_开条.Click += new System.EventHandler(this.mnu_Slice_Click);
            // 
            // mnu_开吨
            // 
            this.mnu_开吨.Name = "mnu_开吨";
            this.mnu_开吨.Size = new System.Drawing.Size(100, 22);
            this.mnu_开吨.Text = "开吨";
            this.mnu_开吨.Click += new System.EventHandler(this.mnu_Slice_Click);
            // 
            // mnu_SliceView
            // 
            this.mnu_SliceView.Name = "mnu_SliceView";
            this.mnu_SliceView.Size = new System.Drawing.Size(172, 22);
            this.mnu_SliceView.Text = "查看加工记录";
            this.mnu_SliceView.Click += new System.EventHandler(this.mnu_SliceView_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // 更换仓库ToolStripMenuItem
            // 
            this.更换仓库ToolStripMenuItem.Name = "更换仓库ToolStripMenuItem";
            this.更换仓库ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.更换仓库ToolStripMenuItem.Text = "更换仓库";
            this.更换仓库ToolStripMenuItem.Click += new System.EventHandler(this.更换仓库ToolStripMenuItem_Click);
            // 
            // mnu_Check
            // 
            this.mnu_Check.Name = "mnu_Check";
            this.mnu_Check.Size = new System.Drawing.Size(172, 22);
            this.mnu_Check.Text = "盘点";
            this.mnu_Check.Click += new System.EventHandler(this.mnu_Check_Click);
            // 
            // mnu_CheckView
            // 
            this.mnu_CheckView.Name = "mnu_CheckView";
            this.mnu_CheckView.Size = new System.Drawing.Size(172, 22);
            this.mnu_CheckView.Text = "查看盘点记录";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(169, 6);
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
            // 更多操作ToolStripMenuItem
            // 
            this.更多操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.预订ToolStripMenuItem,
            this.取消预订ToolStripMenuItem,
            this.mnu_拆卷,
            this.mnu_原材料拆条,
            this.mnu_Nullify});
            this.更多操作ToolStripMenuItem.Name = "更多操作ToolStripMenuItem";
            this.更多操作ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.更多操作ToolStripMenuItem.Text = "更多操作...";
            // 
            // 预订ToolStripMenuItem
            // 
            this.预订ToolStripMenuItem.Name = "预订ToolStripMenuItem";
            this.预订ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.预订ToolStripMenuItem.Text = "预订";
            this.预订ToolStripMenuItem.Click += new System.EventHandler(this.预订ToolStripMenuItem_Click);
            // 
            // 取消预订ToolStripMenuItem
            // 
            this.取消预订ToolStripMenuItem.Name = "取消预订ToolStripMenuItem";
            this.取消预订ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.取消预订ToolStripMenuItem.Text = "取消预订";
            this.取消预订ToolStripMenuItem.Click += new System.EventHandler(this.取消预订ToolStripMenuItem_Click);
            // 
            // mnu_拆卷
            // 
            this.mnu_拆卷.Name = "mnu_拆卷";
            this.mnu_拆卷.Size = new System.Drawing.Size(136, 22);
            this.mnu_拆卷.Text = "拆卷";
            this.mnu_拆卷.Click += new System.EventHandler(this.mnu_拆卷_Click);
            // 
            // mnu_原材料拆条
            // 
            this.mnu_原材料拆条.Name = "mnu_原材料拆条";
            this.mnu_原材料拆条.Size = new System.Drawing.Size(136, 22);
            this.mnu_原材料拆条.Text = "原材料分条";
            this.mnu_原材料拆条.Click += new System.EventHandler(this.mnu_原材料拆条_Click);
            // 
            // mnu_Nullify
            // 
            this.mnu_Nullify.Name = "mnu_Nullify";
            this.mnu_Nullify.Size = new System.Drawing.Size(136, 22);
            this.mnu_Nullify.Text = "作废";
            this.mnu_Nullify.Click += new System.EventHandler(this.mnu_Nullify_Click);
            // 
            // colAddDate
            // 
            this.colAddDate.HeaderText = "入库日期";
            this.colAddDate.Name = "colAddDate";
            this.colAddDate.ReadOnly = true;
            this.colAddDate.Width = 120;
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
            this.colCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colCategory.HeaderText = "类别";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 54;
            // 
            // colSpecification
            // 
            this.colSpecification.HeaderText = "规格";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            // 
            // colOriginalWeight
            // 
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            this.colOriginalWeight.DefaultCellStyle = dataGridViewCellStyle1;
            this.colOriginalWeight.HeaderText = "入库重量";
            this.colOriginalWeight.Name = "colOriginalWeight";
            this.colOriginalWeight.ReadOnly = true;
            // 
            // colOriginalLength
            // 
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.colOriginalLength.DefaultCellStyle = dataGridViewCellStyle2;
            this.colOriginalLength.HeaderText = "入库长度";
            this.colOriginalLength.Name = "colOriginalLength";
            this.colOriginalLength.ReadOnly = true;
            this.colOriginalLength.Visible = false;
            // 
            // colWeight
            // 
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.colWeight.DefaultCellStyle = dataGridViewCellStyle3;
            this.colWeight.HeaderText = "剩余重量";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            // 
            // colLength
            // 
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = null;
            this.colLength.DefaultCellStyle = dataGridViewCellStyle4;
            this.colLength.HeaderText = "剩余长度";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.Visible = false;
            // 
            // colOriginalThick
            // 
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = null;
            this.colOriginalThick.DefaultCellStyle = dataGridViewCellStyle5;
            this.colOriginalThick.HeaderText = "入库厚度";
            this.colOriginalThick.Name = "colOriginalThick";
            this.colOriginalThick.ReadOnly = true;
            this.colOriginalThick.Visible = false;
            // 
            // colRealThick
            // 
            dataGridViewCellStyle6.Format = "N3";
            dataGridViewCellStyle6.NullValue = null;
            this.colRealThick.DefaultCellStyle = dataGridViewCellStyle6;
            this.colRealThick.HeaderText = "开平厚度";
            this.colRealThick.Name = "colRealThick";
            this.colRealThick.ReadOnly = true;
            // 
            // colCustomer
            // 
            this.colCustomer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colCustomer.HeaderText = "客户";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.Width = 54;
            // 
            // colSupplier
            // 
            this.colSupplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSupplier.HeaderText = "供应商";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.ReadOnly = true;
            this.colSupplier.Width = 66;
            // 
            // colManufacture
            // 
            this.colManufacture.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colManufacture.HeaderText = "厂家";
            this.colManufacture.Name = "colManufacture";
            this.colManufacture.ReadOnly = true;
            this.colManufacture.Width = 54;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSerialNumber.HeaderText = "卷号";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.ReadOnly = true;
            this.colSerialNumber.Width = 54;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colStatus.HeaderText = "物料状态";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 78;
            // 
            // colState
            // 
            this.colState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colState.HeaderText = "库存状态";
            this.colState.Name = "colState";
            this.colState.ReadOnly = true;
            this.colState.Width = 78;
            // 
            // colDeliverySheet
            // 
            this.colDeliverySheet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDeliverySheet.HeaderText = "送货单";
            this.colDeliverySheet.Name = "colDeliverySheet";
            this.colDeliverySheet.ReadOnly = true;
            this.colDeliverySheet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDeliverySheet.Width = 66;
            // 
            // colPurchasePrice
            // 
            dataGridViewCellStyle7.Format = "C2";
            this.colPurchasePrice.DefaultCellStyle = dataGridViewCellStyle7;
            this.colPurchasePrice.HeaderText = "入库吨价";
            this.colPurchasePrice.Name = "colPurchasePrice";
            this.colPurchasePrice.ReadOnly = true;
            // 
            // colPurchaseTax
            // 
            this.colPurchaseTax.HeaderText = "含税";
            this.colPurchaseTax.Name = "colPurchaseTax";
            this.colPurchaseTax.ReadOnly = true;
            this.colPurchaseTax.Width = 40;
            // 
            // col运费
            // 
            dataGridViewCellStyle8.Format = "C2";
            this.col运费.DefaultCellStyle = dataGridViewCellStyle8;
            this.col运费.HeaderText = "运费";
            this.col运费.Name = "col运费";
            this.col运费.ReadOnly = true;
            this.col运费.Width = 80;
            // 
            // col开平费
            // 
            dataGridViewCellStyle9.Format = "C2";
            this.col开平费.DefaultCellStyle = dataGridViewCellStyle9;
            this.col开平费.HeaderText = "开平费";
            this.col开平费.Name = "col开平费";
            this.col开平费.ReadOnly = true;
            this.col开平费.Width = 80;
            // 
            // col吊装费
            // 
            dataGridViewCellStyle10.Format = "C2";
            this.col吊装费.DefaultCellStyle = dataGridViewCellStyle10;
            this.col吊装费.HeaderText = "吊装费";
            this.col吊装费.Name = "col吊装费";
            this.col吊装费.ReadOnly = true;
            this.col吊装费.Width = 80;
            // 
            // col其它费用
            // 
            dataGridViewCellStyle11.Format = "C2";
            this.col其它费用.DefaultCellStyle = dataGridViewCellStyle11;
            this.col其它费用.HeaderText = "其它费用";
            this.col其它费用.Name = "col其它费用";
            this.col其它费用.ReadOnly = true;
            this.col其它费用.Width = 80;
            // 
            // colPosition
            // 
            this.colPosition.HeaderText = "摆放位置";
            this.colPosition.Name = "colPosition";
            // 
            // colMaterial
            // 
            this.colMaterial.HeaderText = "材质";
            this.colMaterial.Name = "colMaterial";
            this.colMaterial.ReadOnly = true;
            // 
            // colCarplate
            // 
            this.colCarplate.HeaderText = "车皮号";
            this.colCarplate.Name = "colCarplate";
            this.colCarplate.ReadOnly = true;
            // 
            // colPurchaseID
            // 
            this.colPurchaseID.HeaderText = "合同号";
            this.colPurchaseID.Name = "colPurchaseID";
            // 
            // colSourceRoll
            // 
            this.colSourceRoll.HeaderText = "来源卷";
            this.colSourceRoll.Name = "colSourceRoll";
            this.colSourceRoll.ReadOnly = true;
            this.colSourceRoll.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSourceRoll.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSourceRoll.Width = 80;
            // 
            // colOperator
            // 
            this.colOperator.HeaderText = "操作员";
            this.colOperator.Name = "colOperator";
            this.colOperator.ReadOnly = true;
            this.colOperator.Width = 80;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            // 
            // FrmSteelRollMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1362, 554);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnlFilter);
            this.Name = "FrmSteelRollMaster";
            this.Text = "原材料管理";
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.pnlFilter.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlStates.ResumeLayout(false);
            this.pnlStates.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Fresh;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Add;
        private System.Windows.Forms.ToolStripMenuItem cMnu_SelectColumns;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStripMenuItem mnu_Check;
        private System.Windows.Forms.CheckBox chkStackIn;
        private Controls.SpecificationComboBox cmbSpecification;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private Controls.WareHouseComboBox wareHouseComboBox1;
        private System.Windows.Forms.ToolStripMenuItem mnu_SliceView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controls.CategoryComboBox categoryComboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlStates;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Controls.CustomerCombobox customerCombobox1;
        private Controls.UCDateTimeInterval ucDateTimeInterval1;
        private System.Windows.Forms.ToolStripMenuItem mnu_Import;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 更换仓库ToolStripMenuItem;
        private System.Windows.Forms.Label lblTotalWeight;
        private System.Windows.Forms.Label lblOriginalTotal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        internal System.Windows.Forms.CheckBox chkRemainless;
        internal System.Windows.Forms.CheckBox chkOnlyTail;
        internal System.Windows.Forms.CheckBox chkPartial;
        internal System.Windows.Forms.CheckBox chkIntact;
        internal System.Windows.Forms.CheckBox chk作废;
        internal System.Windows.Forms.CheckBox chk发货;
        internal System.Windows.Forms.CheckBox chk待发货;
        internal System.Windows.Forms.CheckBox chk预订;
        internal System.Windows.Forms.CheckBox chk在库;
        private System.Windows.Forms.Label label15;
        private GeneralLibrary.WinformControl.DBCTextBox txtPurchaseID;
        private System.Windows.Forms.ToolStripMenuItem mnu_设置入库单价;
        private System.Windows.Forms.ToolStripMenuItem mnu_设置其它成本;
        private System.Windows.Forms.ToolStripMenuItem 更多操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 预订ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消预订ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_拆卷;
        private System.Windows.Forms.ToolStripMenuItem 加工ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_开平;
        private System.Windows.Forms.ToolStripMenuItem mnu_开卷;
        private System.Windows.Forms.ToolStripMenuItem mnu_开条;
        private System.Windows.Forms.ToolStripMenuItem mnu_开吨;
        private System.Windows.Forms.ToolStripMenuItem mnu_CheckView;
        private System.Windows.Forms.ToolStripMenuItem mnu_Nullify;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnu_查看价格改动记录;
        private System.Windows.Forms.ToolStripMenuItem mnu_原材料拆条;
        private Controls.CustomerCombobox cmbBrand;
        private Controls.CustomerCombobox cmbSupplier;
        private System.Windows.Forms.Label label2;
        private GeneralLibrary.WinformControl.DecimalTextBox txtWeight;
        private System.Windows.Forms.ToolStripMenuItem mnu_查看成本明细;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWareHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriginalWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriginalLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriginalThick;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealThick;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacture;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.DataGridViewLinkColumn colDeliverySheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchasePrice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPurchaseTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn col运费;
        private System.Windows.Forms.DataGridViewTextBoxColumn col开平费;
        private System.Windows.Forms.DataGridViewTextBoxColumn col吊装费;
        private System.Windows.Forms.DataGridViewTextBoxColumn col其它费用;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCarplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchaseID;
        private System.Windows.Forms.DataGridViewLinkColumn colSourceRoll;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
    }
}