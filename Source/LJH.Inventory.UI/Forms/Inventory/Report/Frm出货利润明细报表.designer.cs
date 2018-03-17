namespace LJH.Inventory.UI.Forms.Inventory.Report
{
    partial class Frm出货利润明细报表
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSheetNo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtSourceRollWeight = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLength = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtWeight = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.cmbSpecification = new LJH.Inventory.UI.Controls.UCSpecification();
            this.txtProductCategory = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkProductCategory = new System.Windows.Forms.LinkLabel();
            this.lnkCustomer = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucDateTimeInterval1 = new LJH.GeneralLibrary.WinformControl.UCDateTimeInterval();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.lbl毛利 = new System.Windows.Forms.Label();
            this.lbl国税计提 = new System.Windows.Forms.Label();
            this.lbl产品成本 = new System.Windows.Forms.Label();
            this.lbl销售金额 = new System.Windows.Forms.Label();
            this.colDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSheetNo = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col克重 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col合同号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col厂家 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceRollWeight = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colWithTax = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col入库单价 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col结算单价 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col运费 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col短途运费 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col短途运费2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col分条费 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col开平费 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col加工费 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col吊装费 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col其它费用 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col单件成本 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col成本合计 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col国税计提 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col利润合计 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(865, 12);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(865, 40);
            // 
            // btnColumn
            // 
            this.btnColumn.Location = new System.Drawing.Point(865, 70);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(0, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 102);
            this.panel1.TabIndex = 25;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtSheetNo);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtSourceRollWeight);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtLength);
            this.groupBox3.Controls.Add(this.txtWeight);
            this.groupBox3.Controls.Add(this.cmbSpecification);
            this.groupBox3.Controls.Add(this.txtProductCategory);
            this.groupBox3.Controls.Add(this.txtCustomer);
            this.groupBox3.Controls.Add(this.lnkProductCategory);
            this.groupBox3.Controls.Add(this.lnkCustomer);
            this.groupBox3.Location = new System.Drawing.Point(240, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(616, 90);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其它";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 150;
            this.label2.Text = "送货单";
            // 
            // txtSheetNo
            // 
            this.txtSheetNo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSheetNo.Location = new System.Drawing.Point(254, 51);
            this.txtSheetNo.Name = "txtSheetNo";
            this.txtSheetNo.Size = new System.Drawing.Size(180, 21);
            this.txtSheetNo.TabIndex = 149;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(430, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 95;
            this.label1.Text = "来源卷重";
            // 
            // txtSourceRollWeight
            // 
            this.txtSourceRollWeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSourceRollWeight.Location = new System.Drawing.Point(487, 68);
            this.txtSourceRollWeight.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtSourceRollWeight.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSourceRollWeight.Name = "txtSourceRollWeight";
            this.txtSourceRollWeight.PointCount = 3;
            this.txtSourceRollWeight.Size = new System.Drawing.Size(100, 21);
            this.txtSourceRollWeight.TabIndex = 94;
            this.txtSourceRollWeight.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(452, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 93;
            this.label4.Text = "长度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(452, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 92;
            this.label3.Text = "重量";
            // 
            // txtLength
            // 
            this.txtLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLength.Location = new System.Drawing.Point(487, 41);
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
            this.txtLength.Size = new System.Drawing.Size(100, 21);
            this.txtLength.TabIndex = 91;
            this.txtLength.Text = "0";
            // 
            // txtWeight
            // 
            this.txtWeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWeight.Location = new System.Drawing.Point(487, 12);
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
            this.txtWeight.Size = new System.Drawing.Size(100, 21);
            this.txtWeight.TabIndex = 90;
            this.txtWeight.Text = "0";
            // 
            // cmbSpecification
            // 
            this.cmbSpecification.Location = new System.Drawing.Point(218, 15);
            this.cmbSpecification.Name = "cmbSpecification";
            this.cmbSpecification.SelectedWidth = null;
            this.cmbSpecification.Selected克重 = null;
            this.cmbSpecification.Size = new System.Drawing.Size(221, 26);
            this.cmbSpecification.Specification = "*";
            this.cmbSpecification.TabIndex = 87;
            // 
            // txtProductCategory
            // 
            this.txtProductCategory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtProductCategory.Location = new System.Drawing.Point(48, 47);
            this.txtProductCategory.Name = "txtProductCategory";
            this.txtProductCategory.ReadOnly = true;
            this.txtProductCategory.Size = new System.Drawing.Size(153, 21);
            this.txtProductCategory.TabIndex = 39;
            this.txtProductCategory.DoubleClick += new System.EventHandler(this.txtProductCategory_DoubleClick);
            // 
            // txtCustomer
            // 
            this.txtCustomer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCustomer.Location = new System.Drawing.Point(48, 18);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(153, 21);
            this.txtCustomer.TabIndex = 37;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            // 
            // lnkProductCategory
            // 
            this.lnkProductCategory.AutoSize = true;
            this.lnkProductCategory.Location = new System.Drawing.Point(12, 51);
            this.lnkProductCategory.Name = "lnkProductCategory";
            this.lnkProductCategory.Size = new System.Drawing.Size(29, 12);
            this.lnkProductCategory.TabIndex = 36;
            this.lnkProductCategory.TabStop = true;
            this.lnkProductCategory.Text = "类别";
            this.lnkProductCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProductCategory_LinkClicked);
            // 
            // lnkCustomer
            // 
            this.lnkCustomer.AutoSize = true;
            this.lnkCustomer.Location = new System.Drawing.Point(12, 22);
            this.lnkCustomer.Name = "lnkCustomer";
            this.lnkCustomer.Size = new System.Drawing.Size(29, 12);
            this.lnkCustomer.TabIndex = 33;
            this.lnkCustomer.TabStop = true;
            this.lnkCustomer.Text = "客户";
            this.lnkCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomer_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucDateTimeInterval1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 90);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "出货日期";
            // 
            // ucDateTimeInterval1
            // 
            this.ucDateTimeInterval1.EndDateTime = new System.DateTime(2012, 6, 2, 10, 42, 8, 482);
            this.ucDateTimeInterval1.Location = new System.Drawing.Point(4, 14);
            this.ucDateTimeInterval1.Name = "ucDateTimeInterval1";
            this.ucDateTimeInterval1.ShowTime = false;
            this.ucDateTimeInterval1.Size = new System.Drawing.Size(221, 74);
            this.ucDateTimeInterval1.StartDateTime = new System.DateTime(2012, 6, 2, 10, 42, 8, 482);
            this.ucDateTimeInterval1.TabIndex = 1;
            // 
            // gridView
            // 
            this.gridView.AllowUserToAddRows = false;
            this.gridView.AllowUserToDeleteRows = false;
            this.gridView.AllowUserToResizeColumns = false;
            this.gridView.AllowUserToResizeRows = false;
            this.gridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridView.BackgroundColor = System.Drawing.Color.White;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeliveryDate,
            this.colCustomerName,
            this.colSheetNo,
            this.colCategoryID,
            this.colName,
            this.col克重,
            this.colWidth,
            this.colLength,
            this.col合同号,
            this.col厂家,
            this.colWeight,
            this.colSourceRollWeight,
            this.colWithTax,
            this.colPrice,
            this.colCount,
            this.colAmount,
            this.col入库单价,
            this.col结算单价,
            this.col运费,
            this.col短途运费,
            this.col短途运费2,
            this.col分条费,
            this.col开平费,
            this.col加工费,
            this.col吊装费,
            this.col其它费用,
            this.col单件成本,
            this.col成本合计,
            this.col国税计提,
            this.col利润合计});
            this.gridView.Location = new System.Drawing.Point(0, 112);
            this.gridView.Name = "gridView";
            this.gridView.RowHeadersVisible = false;
            this.gridView.RowTemplate.Height = 23;
            this.gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridView.Size = new System.Drawing.Size(1370, 395);
            this.gridView.TabIndex = 26;
            this.gridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_CellContentClick);
            // 
            // lbl毛利
            // 
            this.lbl毛利.AutoSize = true;
            this.lbl毛利.ForeColor = System.Drawing.Color.Blue;
            this.lbl毛利.Location = new System.Drawing.Point(1008, 84);
            this.lbl毛利.Name = "lbl毛利";
            this.lbl毛利.Size = new System.Drawing.Size(11, 12);
            this.lbl毛利.TabIndex = 3;
            this.lbl毛利.Text = "0";
            // 
            // lbl国税计提
            // 
            this.lbl国税计提.AutoSize = true;
            this.lbl国税计提.ForeColor = System.Drawing.Color.Blue;
            this.lbl国税计提.Location = new System.Drawing.Point(1008, 61);
            this.lbl国税计提.Name = "lbl国税计提";
            this.lbl国税计提.Size = new System.Drawing.Size(11, 12);
            this.lbl国税计提.TabIndex = 2;
            this.lbl国税计提.Text = "0";
            // 
            // lbl产品成本
            // 
            this.lbl产品成本.AutoSize = true;
            this.lbl产品成本.ForeColor = System.Drawing.Color.Blue;
            this.lbl产品成本.Location = new System.Drawing.Point(1008, 38);
            this.lbl产品成本.Name = "lbl产品成本";
            this.lbl产品成本.Size = new System.Drawing.Size(11, 12);
            this.lbl产品成本.TabIndex = 1;
            this.lbl产品成本.Text = "0";
            // 
            // lbl销售金额
            // 
            this.lbl销售金额.AutoSize = true;
            this.lbl销售金额.ForeColor = System.Drawing.Color.Blue;
            this.lbl销售金额.Location = new System.Drawing.Point(1008, 15);
            this.lbl销售金额.Name = "lbl销售金额";
            this.lbl销售金额.Size = new System.Drawing.Size(11, 12);
            this.lbl销售金额.TabIndex = 0;
            this.lbl销售金额.Text = "0";
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDeliveryDate.HeaderText = "出货日期";
            this.colDeliveryDate.Name = "colDeliveryDate";
            this.colDeliveryDate.ReadOnly = true;
            this.colDeliveryDate.Width = 78;
            // 
            // colCustomerName
            // 
            this.colCustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colCustomerName.HeaderText = "客户";
            this.colCustomerName.MinimumWidth = 120;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            this.colCustomerName.Width = 120;
            // 
            // colSheetNo
            // 
            this.colSheetNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSheetNo.HeaderText = "送货单";
            this.colSheetNo.Name = "colSheetNo";
            this.colSheetNo.ReadOnly = true;
            this.colSheetNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSheetNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSheetNo.Width = 66;
            // 
            // colCategoryID
            // 
            this.colCategoryID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colCategoryID.HeaderText = "类别";
            this.colCategoryID.Name = "colCategoryID";
            this.colCategoryID.ReadOnly = true;
            this.colCategoryID.Width = 54;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colName.HeaderText = "名称";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 54;
            // 
            // col克重
            // 
            this.col克重.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col克重.HeaderText = "克重";
            this.col克重.Name = "col克重";
            this.col克重.ReadOnly = true;
            this.col克重.Width = 54;
            // 
            // colWidth
            // 
            this.colWidth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colWidth.HeaderText = "宽度";
            this.colWidth.Name = "colWidth";
            this.colWidth.ReadOnly = true;
            this.colWidth.Width = 54;
            // 
            // colLength
            // 
            this.colLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colLength.HeaderText = "长度";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.Width = 54;
            // 
            // col合同号
            // 
            this.col合同号.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col合同号.HeaderText = "合同号";
            this.col合同号.Name = "col合同号";
            this.col合同号.ReadOnly = true;
            this.col合同号.Width = 66;
            // 
            // col厂家
            // 
            this.col厂家.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col厂家.HeaderText = "厂家";
            this.col厂家.Name = "col厂家";
            this.col厂家.ReadOnly = true;
            this.col厂家.Width = 54;
            // 
            // colWeight
            // 
            this.colWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle1.Format = "N3";
            this.colWeight.DefaultCellStyle = dataGridViewCellStyle1;
            this.colWeight.HeaderText = "重量";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            this.colWeight.Width = 54;
            // 
            // colSourceRollWeight
            // 
            this.colSourceRollWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Format = "N3";
            this.colSourceRollWeight.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSourceRollWeight.HeaderText = "来源卷重";
            this.colSourceRollWeight.Name = "colSourceRollWeight";
            this.colSourceRollWeight.ReadOnly = true;
            this.colSourceRollWeight.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSourceRollWeight.Width = 59;
            // 
            // colWithTax
            // 
            this.colWithTax.HeaderText = "含税";
            this.colWithTax.Name = "colWithTax";
            this.colWithTax.ReadOnly = true;
            this.colWithTax.Width = 40;
            // 
            // colPrice
            // 
            this.colPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.colPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPrice.HeaderText = "销售单价";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 78;
            // 
            // colCount
            // 
            this.colCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.colCount.DefaultCellStyle = dataGridViewCellStyle4;
            this.colCount.HeaderText = "数量";
            this.colCount.Name = "colCount";
            this.colCount.ReadOnly = true;
            this.colCount.Width = 54;
            // 
            // colAmount
            // 
            this.colAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle5;
            this.colAmount.HeaderText = "金额";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 54;
            // 
            // col入库单价
            // 
            this.col入库单价.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle6.Format = "C2";
            this.col入库单价.DefaultCellStyle = dataGridViewCellStyle6;
            this.col入库单价.HeaderText = "入库单价";
            this.col入库单价.Name = "col入库单价";
            this.col入库单价.ReadOnly = true;
            this.col入库单价.Width = 78;
            // 
            // col结算单价
            // 
            this.col结算单价.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col结算单价.HeaderText = "结算单价";
            this.col结算单价.Name = "col结算单价";
            this.col结算单价.ReadOnly = true;
            this.col结算单价.Width = 78;
            // 
            // col运费
            // 
            this.col运费.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle7.Format = "C2";
            this.col运费.DefaultCellStyle = dataGridViewCellStyle7;
            this.col运费.HeaderText = "运费";
            this.col运费.Name = "col运费";
            this.col运费.ReadOnly = true;
            this.col运费.Width = 54;
            // 
            // col短途运费
            // 
            this.col短途运费.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle8.Format = "C2";
            this.col短途运费.DefaultCellStyle = dataGridViewCellStyle8;
            this.col短途运费.HeaderText = "短途运费1";
            this.col短途运费.Name = "col短途运费";
            this.col短途运费.ReadOnly = true;
            this.col短途运费.Width = 84;
            // 
            // col短途运费2
            // 
            this.col短途运费2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle9.Format = "C2";
            this.col短途运费2.DefaultCellStyle = dataGridViewCellStyle9;
            this.col短途运费2.HeaderText = "短途运费2";
            this.col短途运费2.Name = "col短途运费2";
            this.col短途运费2.ReadOnly = true;
            this.col短途运费2.Width = 84;
            // 
            // col分条费
            // 
            this.col分条费.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle10.Format = "C2";
            this.col分条费.DefaultCellStyle = dataGridViewCellStyle10;
            this.col分条费.HeaderText = "分条费";
            this.col分条费.Name = "col分条费";
            this.col分条费.ReadOnly = true;
            this.col分条费.Width = 66;
            // 
            // col开平费
            // 
            this.col开平费.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle11.Format = "C2";
            this.col开平费.DefaultCellStyle = dataGridViewCellStyle11;
            this.col开平费.HeaderText = "开平费";
            this.col开平费.Name = "col开平费";
            this.col开平费.ReadOnly = true;
            this.col开平费.Width = 66;
            // 
            // col加工费
            // 
            this.col加工费.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle12.Format = "C2";
            this.col加工费.DefaultCellStyle = dataGridViewCellStyle12;
            this.col加工费.HeaderText = "加工费";
            this.col加工费.Name = "col加工费";
            this.col加工费.ReadOnly = true;
            this.col加工费.Width = 66;
            // 
            // col吊装费
            // 
            this.col吊装费.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle13.Format = "C2";
            this.col吊装费.DefaultCellStyle = dataGridViewCellStyle13;
            this.col吊装费.HeaderText = "吊装费";
            this.col吊装费.Name = "col吊装费";
            this.col吊装费.ReadOnly = true;
            this.col吊装费.Width = 66;
            // 
            // col其它费用
            // 
            this.col其它费用.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle14.Format = "C2";
            this.col其它费用.DefaultCellStyle = dataGridViewCellStyle14;
            this.col其它费用.HeaderText = "其它费用";
            this.col其它费用.Name = "col其它费用";
            this.col其它费用.ReadOnly = true;
            this.col其它费用.Width = 78;
            // 
            // col单件成本
            // 
            this.col单件成本.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle15.Format = "C2";
            this.col单件成本.DefaultCellStyle = dataGridViewCellStyle15;
            this.col单件成本.HeaderText = "单位成本";
            this.col单件成本.Name = "col单件成本";
            this.col单件成本.ReadOnly = true;
            this.col单件成本.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col单件成本.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col单件成本.Width = 78;
            // 
            // col成本合计
            // 
            this.col成本合计.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle16.Format = "C2";
            this.col成本合计.DefaultCellStyle = dataGridViewCellStyle16;
            this.col成本合计.HeaderText = "成本合计";
            this.col成本合计.Name = "col成本合计";
            this.col成本合计.ReadOnly = true;
            this.col成本合计.Width = 78;
            // 
            // col国税计提
            // 
            this.col国税计提.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle17.Format = "C2";
            this.col国税计提.DefaultCellStyle = dataGridViewCellStyle17;
            this.col国税计提.HeaderText = "国税计提";
            this.col国税计提.Name = "col国税计提";
            this.col国税计提.ReadOnly = true;
            this.col国税计提.Width = 78;
            // 
            // col利润合计
            // 
            this.col利润合计.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle18.Format = "C2";
            this.col利润合计.DefaultCellStyle = dataGridViewCellStyle18;
            this.col利润合计.HeaderText = "利润合计";
            this.col利润合计.Name = "col利润合计";
            this.col利润合计.ReadOnly = true;
            this.col利润合计.Width = 78;
            // 
            // Frm出货利润明细报表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 529);
            this.Controls.Add(this.lbl毛利);
            this.Controls.Add(this.lbl国税计提);
            this.Controls.Add(this.lbl产品成本);
            this.Controls.Add(this.lbl销售金额);
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.panel1);
            this.Name = "Frm出货利润明细报表";
            this.Text = "出货利润明细报表";
            this.Controls.SetChildIndex(this.btnColumn, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnSaveAs, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gridView, 0);
            this.Controls.SetChildIndex(this.lbl销售金额, 0);
            this.Controls.SetChildIndex(this.lbl产品成本, 0);
            this.Controls.SetChildIndex(this.lbl国税计提, 0);
            this.Controls.SetChildIndex(this.lbl毛利, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private LJH.GeneralLibrary.WinformControl.UCDateTimeInterval ucDateTimeInterval1;
        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel lnkProductCategory;
        private System.Windows.Forms.LinkLabel lnkCustomer;
        private GeneralLibrary.WinformControl.DBCTextBox txtProductCategory;
        private GeneralLibrary.WinformControl.DBCTextBox txtCustomer;
        private Controls.UCSpecification cmbSpecification;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private GeneralLibrary.WinformControl.DecimalTextBox txtLength;
        private GeneralLibrary.WinformControl.DecimalTextBox txtWeight;
        private System.Windows.Forms.Label label1;
        private GeneralLibrary.WinformControl.DecimalTextBox txtSourceRollWeight;
        private System.Windows.Forms.Label label2;
        private GeneralLibrary.WinformControl.DBCTextBox txtSheetNo;
        private System.Windows.Forms.Label lbl毛利;
        private System.Windows.Forms.Label lbl国税计提;
        private System.Windows.Forms.Label lbl产品成本;
        private System.Windows.Forms.Label lbl销售金额;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewLinkColumn colSheetNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col克重;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn col合同号;
        private System.Windows.Forms.DataGridViewTextBoxColumn col厂家;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewLinkColumn colSourceRollWeight;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colWithTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col入库单价;
        private System.Windows.Forms.DataGridViewTextBoxColumn col结算单价;
        private System.Windows.Forms.DataGridViewTextBoxColumn col运费;
        private System.Windows.Forms.DataGridViewTextBoxColumn col短途运费;
        private System.Windows.Forms.DataGridViewTextBoxColumn col短途运费2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col分条费;
        private System.Windows.Forms.DataGridViewTextBoxColumn col开平费;
        private System.Windows.Forms.DataGridViewTextBoxColumn col加工费;
        private System.Windows.Forms.DataGridViewTextBoxColumn col吊装费;
        private System.Windows.Forms.DataGridViewTextBoxColumn col其它费用;
        private System.Windows.Forms.DataGridViewLinkColumn col单件成本;
        private System.Windows.Forms.DataGridViewTextBoxColumn col成本合计;
        private System.Windows.Forms.DataGridViewTextBoxColumn col国税计提;
        private System.Windows.Forms.DataGridViewTextBoxColumn col利润合计;
    }
}