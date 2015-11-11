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
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWeight = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.chkShipped = new System.Windows.Forms.CheckBox();
            this.chkWaitShip = new System.Windows.Forms.CheckBox();
            this.chkRemainless = new System.Windows.Forms.CheckBox();
            this.chkOnlyTail = new System.Windows.Forms.CheckBox();
            this.chkPartial = new System.Windows.Forms.CheckBox();
            this.chkIntact = new System.Windows.Forms.CheckBox();
            this.dtStorage = new System.Windows.Forms.DateTimePicker();
            this.chkStorageDT = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Slice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_SliceView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_Check = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Nullify = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cMnu_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_CheckView = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryComboBox1 = new LJH.Inventory.UI.Controls.CategoryComboBox(this.components);
            this.wareHouseComboBox1 = new LJH.Inventory.UI.Controls.WareHouseComboBox(this.components);
            this.cmbSpecification = new LJH.Inventory.UI.Controls.SpecificationComboBox(this.components);
            this.colAddDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWareHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriginalWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriginalLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliverySheet = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilter.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.pnlFilter.Size = new System.Drawing.Size(1511, 49);
            this.pnlFilter.TabIndex = 112;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.categoryComboBox1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.wareHouseComboBox1);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.cmbSupplier);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.cmbBrand);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.cmbSpecification);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.txtWeight);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.chkShipped);
            this.panel5.Controls.Add(this.chkWaitShip);
            this.panel5.Controls.Add(this.chkRemainless);
            this.panel5.Controls.Add(this.chkOnlyTail);
            this.panel5.Controls.Add(this.chkPartial);
            this.panel5.Controls.Add(this.chkIntact);
            this.panel5.Controls.Add(this.dtStorage);
            this.panel5.Controls.Add(this.chkStorageDT);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(1, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1510, 49);
            this.panel5.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 84;
            this.label1.Text = "类别";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 81;
            this.label4.Text = "仓库";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(546, 14);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(112, 20);
            this.cmbSupplier.TabIndex = 80;
            this.cmbSupplier.SelectedIndexChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(504, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 79;
            this.label3.Text = "供应商";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(709, 14);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(121, 20);
            this.cmbBrand.TabIndex = 78;
            this.cmbBrand.SelectedIndexChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(675, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 77;
            this.label9.Text = "厂家";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(338, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 75;
            this.label5.Text = "规格";
            // 
            // txtWeight
            // 
            this.txtWeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWeight.Location = new System.Drawing.Point(1419, 14);
            this.txtWeight.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtWeight.MinValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.PointCount = -1;
            this.txtWeight.Size = new System.Drawing.Size(70, 21);
            this.txtWeight.TabIndex = 53;
            this.txtWeight.Text = "0";
            this.txtWeight.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1363, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 52;
            this.label2.Text = "剩余重量";
            // 
            // chkShipped
            // 
            this.chkShipped.AutoSize = true;
            this.chkShipped.Location = new System.Drawing.Point(1247, 16);
            this.chkShipped.Name = "chkShipped";
            this.chkShipped.Size = new System.Drawing.Size(60, 16);
            this.chkShipped.TabIndex = 51;
            this.chkShipped.Text = "已发货";
            this.chkShipped.UseVisualStyleBackColor = true;
            this.chkShipped.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chkWaitShip
            // 
            this.chkWaitShip.AutoSize = true;
            this.chkWaitShip.Checked = true;
            this.chkWaitShip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWaitShip.Location = new System.Drawing.Point(1138, 16);
            this.chkWaitShip.Name = "chkWaitShip";
            this.chkWaitShip.Size = new System.Drawing.Size(60, 16);
            this.chkWaitShip.TabIndex = 50;
            this.chkWaitShip.Text = "待发货";
            this.chkWaitShip.UseVisualStyleBackColor = true;
            this.chkWaitShip.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chkRemainless
            // 
            this.chkRemainless.AutoSize = true;
            this.chkRemainless.Location = new System.Drawing.Point(1309, 16);
            this.chkRemainless.Name = "chkRemainless";
            this.chkRemainless.Size = new System.Drawing.Size(48, 16);
            this.chkRemainless.TabIndex = 49;
            this.chkRemainless.Text = "余料";
            this.chkRemainless.UseVisualStyleBackColor = true;
            this.chkRemainless.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chkOnlyTail
            // 
            this.chkOnlyTail.AutoSize = true;
            this.chkOnlyTail.Checked = true;
            this.chkOnlyTail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyTail.Location = new System.Drawing.Point(1199, 16);
            this.chkOnlyTail.Name = "chkOnlyTail";
            this.chkOnlyTail.Size = new System.Drawing.Size(48, 16);
            this.chkOnlyTail.TabIndex = 48;
            this.chkOnlyTail.Text = "尾卷";
            this.chkOnlyTail.UseVisualStyleBackColor = true;
            this.chkOnlyTail.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chkPartial
            // 
            this.chkPartial.AutoSize = true;
            this.chkPartial.Checked = true;
            this.chkPartial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPartial.Location = new System.Drawing.Point(1090, 16);
            this.chkPartial.Name = "chkPartial";
            this.chkPartial.Size = new System.Drawing.Size(48, 16);
            this.chkPartial.TabIndex = 47;
            this.chkPartial.Text = "余卷";
            this.chkPartial.UseVisualStyleBackColor = true;
            this.chkPartial.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chkIntact
            // 
            this.chkIntact.AutoSize = true;
            this.chkIntact.Checked = true;
            this.chkIntact.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIntact.Location = new System.Drawing.Point(1041, 16);
            this.chkIntact.Name = "chkIntact";
            this.chkIntact.Size = new System.Drawing.Size(48, 16);
            this.chkIntact.TabIndex = 46;
            this.chkIntact.Text = "整卷";
            this.chkIntact.UseVisualStyleBackColor = true;
            this.chkIntact.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // dtStorage
            // 
            this.dtStorage.CustomFormat = "yyyy-MM-dd";
            this.dtStorage.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStorage.Location = new System.Drawing.Point(915, 14);
            this.dtStorage.Name = "dtStorage";
            this.dtStorage.Size = new System.Drawing.Size(106, 21);
            this.dtStorage.TabIndex = 45;
            this.dtStorage.ValueChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chkStorageDT
            // 
            this.chkStorageDT.AutoSize = true;
            this.chkStorageDT.Location = new System.Drawing.Point(843, 16);
            this.chkStorageDT.Name = "chkStorageDT";
            this.chkStorageDT.Size = new System.Drawing.Size(72, 16);
            this.chkStorageDT.TabIndex = 44;
            this.chkStorageDT.Text = "进货日期";
            this.chkStorageDT.UseVisualStyleBackColor = true;
            this.chkStorageDT.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 49);
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
            this.colSupplier,
            this.colManufacture,
            this.colSerialNumber,
            this.colStatus,
            this.colState,
            this.colDeliverySheet,
            this.colMemo});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1511, 483);
            this.dataGridView1.TabIndex = 115;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMnu_Fresh,
            this.cMnu_Add,
            this.mnu_Slice,
            this.mnu_SliceView,
            this.toolStripSeparator1,
            this.mnu_Check,
            this.mnu_CheckView,
            this.mnu_Nullify,
            this.toolStripSeparator3,
            this.cMnu_SelectColumns,
            this.cMnu_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 214);
            // 
            // cMnu_Fresh
            // 
            this.cMnu_Fresh.Name = "cMnu_Fresh";
            this.cMnu_Fresh.Size = new System.Drawing.Size(148, 22);
            this.cMnu_Fresh.Text = "刷新";
            // 
            // cMnu_Add
            // 
            this.cMnu_Add.Name = "cMnu_Add";
            this.cMnu_Add.Size = new System.Drawing.Size(148, 22);
            this.cMnu_Add.Text = "新建";
            // 
            // mnu_Slice
            // 
            this.mnu_Slice.Name = "mnu_Slice";
            this.mnu_Slice.Size = new System.Drawing.Size(148, 22);
            this.mnu_Slice.Text = "加工";
            this.mnu_Slice.Click += new System.EventHandler(this.mnu_Slice_Click);
            // 
            // mnu_SliceView
            // 
            this.mnu_SliceView.Name = "mnu_SliceView";
            this.mnu_SliceView.Size = new System.Drawing.Size(148, 22);
            this.mnu_SliceView.Text = "查看加工记录";
            this.mnu_SliceView.Click += new System.EventHandler(this.mnu_SliceView_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // mnu_Check
            // 
            this.mnu_Check.Name = "mnu_Check";
            this.mnu_Check.Size = new System.Drawing.Size(148, 22);
            this.mnu_Check.Text = "盘点";
            this.mnu_Check.Click += new System.EventHandler(this.mnu_Check_Click);
            // 
            // mnu_Nullify
            // 
            this.mnu_Nullify.Name = "mnu_Nullify";
            this.mnu_Nullify.Size = new System.Drawing.Size(148, 22);
            this.mnu_Nullify.Text = "作废";
            this.mnu_Nullify.Click += new System.EventHandler(this.mnu_Nullify_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
            // 
            // cMnu_SelectColumns
            // 
            this.cMnu_SelectColumns.Name = "cMnu_SelectColumns";
            this.cMnu_SelectColumns.Size = new System.Drawing.Size(148, 22);
            this.cMnu_SelectColumns.Text = "选择列...";
            // 
            // cMnu_Export
            // 
            this.cMnu_Export.Name = "cMnu_Export";
            this.cMnu_Export.Size = new System.Drawing.Size(148, 22);
            this.cMnu_Export.Text = "导出...";
            // 
            // mnu_CheckView
            // 
            this.mnu_CheckView.Name = "mnu_CheckView";
            this.mnu_CheckView.Size = new System.Drawing.Size(148, 22);
            this.mnu_CheckView.Text = "查看盘点记录";
            this.mnu_CheckView.Click += new System.EventHandler(this.mnu_CheckView_Click);
            // 
            // categoryComboBox1
            // 
            this.categoryComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox1.FormattingEnabled = true;
            this.categoryComboBox1.Location = new System.Drawing.Point(207, 14);
            this.categoryComboBox1.Name = "categoryComboBox1";
            this.categoryComboBox1.Size = new System.Drawing.Size(121, 20);
            this.categoryComboBox1.TabIndex = 85;
            this.categoryComboBox1.SelectedIndexChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // wareHouseComboBox1
            // 
            this.wareHouseComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wareHouseComboBox1.FormattingEnabled = true;
            this.wareHouseComboBox1.Location = new System.Drawing.Point(46, 14);
            this.wareHouseComboBox1.Name = "wareHouseComboBox1";
            this.wareHouseComboBox1.Size = new System.Drawing.Size(112, 20);
            this.wareHouseComboBox1.TabIndex = 83;
            this.wareHouseComboBox1.SelectedIndexChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // cmbSpecification
            // 
            this.cmbSpecification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecification.FormattingEnabled = true;
            this.cmbSpecification.Location = new System.Drawing.Point(370, 14);
            this.cmbSpecification.Name = "cmbSpecification";
            this.cmbSpecification.Size = new System.Drawing.Size(121, 20);
            this.cmbSpecification.TabIndex = 76;
            this.cmbSpecification.SelectedIndexChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // colAddDate
            // 
            this.colAddDate.HeaderText = "入库日期";
            this.colAddDate.Name = "colAddDate";
            this.colAddDate.ReadOnly = true;
            // 
            // colWareHouse
            // 
            this.colWareHouse.HeaderText = "仓库";
            this.colWareHouse.Name = "colWareHouse";
            this.colWareHouse.ReadOnly = true;
            this.colWareHouse.Width = 120;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "类别";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            // 
            // colSpecification
            // 
            this.colSpecification.HeaderText = "规格";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            // 
            // colOriginalWeight
            // 
            this.colOriginalWeight.HeaderText = "入库重量";
            this.colOriginalWeight.Name = "colOriginalWeight";
            this.colOriginalWeight.ReadOnly = true;
            // 
            // colOriginalLength
            // 
            this.colOriginalLength.HeaderText = "入库长度";
            this.colOriginalLength.Name = "colOriginalLength";
            this.colOriginalLength.ReadOnly = true;
            // 
            // colWeight
            // 
            this.colWeight.HeaderText = "剩余重量";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            // 
            // colLength
            // 
            this.colLength.HeaderText = "剩余长度";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            // 
            // colSupplier
            // 
            this.colSupplier.HeaderText = "供应商";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.ReadOnly = true;
            // 
            // colManufacture
            // 
            this.colManufacture.HeaderText = "厂家";
            this.colManufacture.Name = "colManufacture";
            this.colManufacture.ReadOnly = true;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.HeaderText = "卷号";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "物料状态";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colState
            // 
            this.colState.HeaderText = "库存状态";
            this.colState.Name = "colState";
            this.colState.ReadOnly = true;
            // 
            // colDeliverySheet
            // 
            this.colDeliverySheet.HeaderText = "送货单";
            this.colDeliverySheet.Name = "colDeliverySheet";
            this.colDeliverySheet.ReadOnly = true;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            // 
            // FrmSteelRollMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1511, 554);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnlFilter);
            this.Name = "FrmSteelRollMaster";
            this.Text = "原材料管理";
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.pnlFilter.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cMnu_SelectColumns;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStripMenuItem mnu_Check;
        private System.Windows.Forms.ToolStripMenuItem mnu_Nullify;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkShipped;
        private System.Windows.Forms.CheckBox chkWaitShip;
        private System.Windows.Forms.CheckBox chkRemainless;
        private System.Windows.Forms.CheckBox chkOnlyTail;
        private System.Windows.Forms.CheckBox chkPartial;
        private System.Windows.Forms.CheckBox chkIntact;
        private System.Windows.Forms.DateTimePicker dtStorage;
        private System.Windows.Forms.CheckBox chkStorageDT;
        private GeneralLibrary.WinformControl.DecimalTextBox txtWeight;
        private Controls.SpecificationComboBox cmbSpecification;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private Controls.WareHouseComboBox wareHouseComboBox1;
        private System.Windows.Forms.ToolStripMenuItem mnu_Slice;
        private System.Windows.Forms.ToolStripMenuItem mnu_SliceView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controls.CategoryComboBox categoryComboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem mnu_CheckView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWareHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriginalWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriginalLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacture;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.DataGridViewLinkColumn colDeliverySheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
    }
}