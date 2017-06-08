namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class FrmStackOutSheetMaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cMnu_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalWeight = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLast3Month = new System.Windows.Forms.Button();
            this.ucDateTimeInterval1 = new LJH.Inventory.UI.Controls.UCDateTimeInterval();
            this.chkSheetDate = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkWithoutTax = new System.Windows.Forms.CheckBox();
            this.chkWithTax = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkNullify = new System.Windows.Forms.CheckBox();
            this.chkShipped = new System.Windows.Forms.CheckBox();
            this.chkAdded = new System.Windows.Forms.CheckBox();
            this.chkApproved = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.CategoryMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_AddSheet = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSheetDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSheetNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWithTax = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTotalWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCosts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col国税计提 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col毛利 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShipDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLinker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDriver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDriverCall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCarPlate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.CategoryMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMnu_Fresh,
            this.cMnu_Add,
            this.toolStripSeparator3,
            this.cMnu_SelectColumns,
            this.cMnu_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(122, 98);
            // 
            // cMnu_Fresh
            // 
            this.cMnu_Fresh.Name = "cMnu_Fresh";
            this.cMnu_Fresh.Size = new System.Drawing.Size(121, 22);
            this.cMnu_Fresh.Text = "刷新";
            // 
            // cMnu_Add
            // 
            this.cMnu_Add.Name = "cMnu_Add";
            this.cMnu_Add.Size = new System.Drawing.Size(121, 22);
            this.cMnu_Add.Text = "新建";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(118, 6);
            // 
            // cMnu_SelectColumns
            // 
            this.cMnu_SelectColumns.Name = "cMnu_SelectColumns";
            this.cMnu_SelectColumns.Size = new System.Drawing.Size(121, 22);
            this.cMnu_SelectColumns.Text = "选择列...";
            // 
            // cMnu_Export
            // 
            this.cMnu_Export.Name = "cMnu_Export";
            this.cMnu_Export.Size = new System.Drawing.Size(121, 22);
            this.cMnu_Export.Text = "导出...";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.panel5);
            this.pnlFilter.Controls.Add(this.panel4);
            this.pnlFilter.Controls.Add(this.panel3);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1244, 87);
            this.pnlFilter.TabIndex = 113;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblTotalAmount);
            this.panel5.Controls.Add(this.lblTotalWeight);
            this.panel5.Controls.Add(this.txtCustomer);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.btnLast3Month);
            this.panel5.Controls.Add(this.ucDateTimeInterval1);
            this.panel5.Controls.Add(this.chkSheetDate);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(2, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1242, 87);
            this.panel5.TabIndex = 6;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalAmount.Location = new System.Drawing.Point(934, 23);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(17, 16);
            this.lblTotalAmount.TabIndex = 139;
            this.lblTotalAmount.Text = "0";
            // 
            // lblTotalWeight
            // 
            this.lblTotalWeight.AutoSize = true;
            this.lblTotalWeight.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalWeight.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalWeight.Location = new System.Drawing.Point(934, 54);
            this.lblTotalWeight.Name = "lblTotalWeight";
            this.lblTotalWeight.Size = new System.Drawing.Size(17, 16);
            this.lblTotalWeight.TabIndex = 138;
            this.lblTotalWeight.Text = "0";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCustomer.Location = new System.Drawing.Point(680, 33);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(238, 30);
            this.txtCustomer.TabIndex = 137;
            this.txtCustomer.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(645, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 136;
            this.label2.Text = "客户";
            // 
            // btnLast3Month
            // 
            this.btnLast3Month.Location = new System.Drawing.Point(329, 36);
            this.btnLast3Month.Name = "btnLast3Month";
            this.btnLast3Month.Size = new System.Drawing.Size(75, 39);
            this.btnLast3Month.TabIndex = 135;
            this.btnLast3Month.Text = "最近三个月";
            this.btnLast3Month.UseVisualStyleBackColor = true;
            this.btnLast3Month.Click += new System.EventHandler(this.btnLast3Month_Click);
            // 
            // ucDateTimeInterval1
            // 
            this.ucDateTimeInterval1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDateTimeInterval1.EndDateTime = new System.DateTime(2015, 11, 19, 10, 3, 12, 722);
            this.ucDateTimeInterval1.Location = new System.Drawing.Point(405, 7);
            this.ucDateTimeInterval1.Name = "ucDateTimeInterval1";
            this.ucDateTimeInterval1.ShowTime = true;
            this.ucDateTimeInterval1.Size = new System.Drawing.Size(223, 74);
            this.ucDateTimeInterval1.StartDateTime = new System.DateTime(2015, 11, 19, 10, 3, 12, 722);
            this.ucDateTimeInterval1.TabIndex = 134;
            this.ucDateTimeInterval1.ValueChanged += new System.EventHandler(this.ucDateTimeInterval1_ValueChanged);
            // 
            // chkSheetDate
            // 
            this.chkSheetDate.AutoSize = true;
            this.chkSheetDate.Location = new System.Drawing.Point(332, 14);
            this.chkSheetDate.Name = "chkSheetDate";
            this.chkSheetDate.Size = new System.Drawing.Size(72, 16);
            this.chkSheetDate.TabIndex = 133;
            this.chkSheetDate.Text = "开单日期";
            this.chkSheetDate.UseVisualStyleBackColor = true;
            this.chkSheetDate.CheckedChanged += new System.EventHandler(this.chkSheetDate_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "含税";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkWithoutTax);
            this.panel2.Controls.Add(this.chkWithTax);
            this.panel2.Location = new System.Drawing.Point(50, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 22);
            this.panel2.TabIndex = 32;
            // 
            // chkWithoutTax
            // 
            this.chkWithoutTax.AutoSize = true;
            this.chkWithoutTax.Checked = true;
            this.chkWithoutTax.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWithoutTax.Location = new System.Drawing.Point(62, 3);
            this.chkWithoutTax.Name = "chkWithoutTax";
            this.chkWithoutTax.Size = new System.Drawing.Size(60, 16);
            this.chkWithoutTax.TabIndex = 1;
            this.chkWithoutTax.Text = "不含税";
            this.chkWithoutTax.UseVisualStyleBackColor = true;
            this.chkWithoutTax.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chkWithTax
            // 
            this.chkWithTax.AutoSize = true;
            this.chkWithTax.Checked = true;
            this.chkWithTax.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWithTax.Location = new System.Drawing.Point(4, 3);
            this.chkWithTax.Name = "chkWithTax";
            this.chkWithTax.Size = new System.Drawing.Size(48, 16);
            this.chkWithTax.TabIndex = 0;
            this.chkWithTax.Text = "含税";
            this.chkWithTax.UseVisualStyleBackColor = true;
            this.chkWithTax.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkNullify);
            this.panel1.Controls.Add(this.chkShipped);
            this.panel1.Controls.Add(this.chkAdded);
            this.panel1.Controls.Add(this.chkApproved);
            this.panel1.Location = new System.Drawing.Point(50, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 22);
            this.panel1.TabIndex = 5;
            // 
            // chkNullify
            // 
            this.chkNullify.AutoSize = true;
            this.chkNullify.Location = new System.Drawing.Point(177, 3);
            this.chkNullify.Name = "chkNullify";
            this.chkNullify.Size = new System.Drawing.Size(48, 16);
            this.chkNullify.TabIndex = 3;
            this.chkNullify.Text = "作废";
            this.chkNullify.UseVisualStyleBackColor = true;
            this.chkNullify.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chkShipped
            // 
            this.chkShipped.AutoSize = true;
            this.chkShipped.Checked = true;
            this.chkShipped.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShipped.Location = new System.Drawing.Point(116, 3);
            this.chkShipped.Name = "chkShipped";
            this.chkShipped.Size = new System.Drawing.Size(60, 16);
            this.chkShipped.TabIndex = 4;
            this.chkShipped.Text = "已发货";
            this.chkShipped.UseVisualStyleBackColor = true;
            this.chkShipped.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chkAdded
            // 
            this.chkAdded.AutoSize = true;
            this.chkAdded.Checked = true;
            this.chkAdded.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAdded.Location = new System.Drawing.Point(4, 3);
            this.chkAdded.Name = "chkAdded";
            this.chkAdded.Size = new System.Drawing.Size(48, 16);
            this.chkAdded.TabIndex = 1;
            this.chkAdded.Text = "新建";
            this.chkAdded.UseVisualStyleBackColor = true;
            this.chkAdded.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chkApproved
            // 
            this.chkApproved.AutoSize = true;
            this.chkApproved.Checked = true;
            this.chkApproved.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkApproved.Location = new System.Drawing.Point(62, 3);
            this.chkApproved.Name = "chkApproved";
            this.chkApproved.Size = new System.Drawing.Size(48, 16);
            this.chkApproved.TabIndex = 2;
            this.chkApproved.Text = "审核";
            this.chkApproved.UseVisualStyleBackColor = true;
            this.chkApproved.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "状态";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(1, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 87);
            this.panel4.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 87);
            this.panel3.TabIndex = 3;
            // 
            // CategoryMenu
            // 
            this.CategoryMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_AddSheet});
            this.CategoryMenu.Name = "contextMenuStrip1";
            this.CategoryMenu.Size = new System.Drawing.Size(137, 26);
            // 
            // mnu_AddSheet
            // 
            this.mnu_AddSheet.Name = "mnu_AddSheet";
            this.mnu_AddSheet.Size = new System.Drawing.Size(136, 22);
            this.mnu_AddSheet.Text = "新建送货单";
            this.mnu_AddSheet.Click += new System.EventHandler(this.mnu_AddSheet_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSheetDate,
            this.colSheetNo,
            this.colCustomer,
            this.colFileID,
            this.colWithTax,
            this.colTotalWeight,
            this.colAmount,
            this.colPaid,
            this.colNotPaid,
            this.colCosts,
            this.col国税计提,
            this.col毛利,
            this.colState,
            this.colShipDate,
            this.colLinker,
            this.colTelphone,
            this.colAddress,
            this.colDriver,
            this.colDriverCall,
            this.colCarPlate,
            this.colMemo});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1244, 396);
            this.dataGridView1.TabIndex = 116;
            // 
            // colSheetDate
            // 
            this.colSheetDate.HeaderText = "录单日期";
            this.colSheetDate.Name = "colSheetDate";
            this.colSheetDate.ReadOnly = true;
            this.colSheetDate.Width = 130;
            // 
            // colSheetNo
            // 
            this.colSheetNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSheetNo.HeaderText = "出库单号";
            this.colSheetNo.Name = "colSheetNo";
            this.colSheetNo.ReadOnly = true;
            this.colSheetNo.Width = 78;
            // 
            // colCustomer
            // 
            this.colCustomer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colCustomer.HeaderText = "客户";
            this.colCustomer.MinimumWidth = 100;
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colFileID
            // 
            this.colFileID.HeaderText = "归档码";
            this.colFileID.Name = "colFileID";
            this.colFileID.ReadOnly = true;
            this.colFileID.Width = 80;
            // 
            // colWithTax
            // 
            this.colWithTax.HeaderText = "含税";
            this.colWithTax.Name = "colWithTax";
            this.colWithTax.ReadOnly = true;
            this.colWithTax.Width = 40;
            // 
            // colTotalWeight
            // 
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            this.colTotalWeight.DefaultCellStyle = dataGridViewCellStyle1;
            this.colTotalWeight.HeaderText = "总重量";
            this.colTotalWeight.Name = "colTotalWeight";
            this.colTotalWeight.ReadOnly = true;
            // 
            // colAmount
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAmount.HeaderText = "金额";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colPaid
            // 
            dataGridViewCellStyle3.Format = "C2";
            this.colPaid.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPaid.HeaderText = "已付金额";
            this.colPaid.Name = "colPaid";
            this.colPaid.ReadOnly = true;
            // 
            // colNotPaid
            // 
            dataGridViewCellStyle4.Format = "C2";
            this.colNotPaid.DefaultCellStyle = dataGridViewCellStyle4;
            this.colNotPaid.HeaderText = "未付金额";
            this.colNotPaid.Name = "colNotPaid";
            this.colNotPaid.ReadOnly = true;
            // 
            // colCosts
            // 
            dataGridViewCellStyle5.Format = "C2";
            this.colCosts.DefaultCellStyle = dataGridViewCellStyle5;
            this.colCosts.HeaderText = "成本";
            this.colCosts.Name = "colCosts";
            this.colCosts.ReadOnly = true;
            // 
            // col国税计提
            // 
            dataGridViewCellStyle6.Format = "C2";
            this.col国税计提.DefaultCellStyle = dataGridViewCellStyle6;
            this.col国税计提.HeaderText = "国税计提";
            this.col国税计提.Name = "col国税计提";
            this.col国税计提.ReadOnly = true;
            // 
            // col毛利
            // 
            dataGridViewCellStyle7.Format = "C2";
            this.col毛利.DefaultCellStyle = dataGridViewCellStyle7;
            this.col毛利.HeaderText = "毛利";
            this.col毛利.Name = "col毛利";
            this.col毛利.ReadOnly = true;
            // 
            // colState
            // 
            this.colState.HeaderText = "状态";
            this.colState.Name = "colState";
            this.colState.ReadOnly = true;
            this.colState.Width = 60;
            // 
            // colShipDate
            // 
            dataGridViewCellStyle8.Format = "g";
            dataGridViewCellStyle8.NullValue = null;
            this.colShipDate.DefaultCellStyle = dataGridViewCellStyle8;
            this.colShipDate.HeaderText = "发货日期";
            this.colShipDate.Name = "colShipDate";
            this.colShipDate.ReadOnly = true;
            this.colShipDate.Width = 150;
            // 
            // colLinker
            // 
            this.colLinker.HeaderText = "联系人";
            this.colLinker.Name = "colLinker";
            this.colLinker.ReadOnly = true;
            // 
            // colTelphone
            // 
            this.colTelphone.HeaderText = "联系电话";
            this.colTelphone.Name = "colTelphone";
            this.colTelphone.ReadOnly = true;
            // 
            // colAddress
            // 
            this.colAddress.HeaderText = "送货地址";
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            this.colAddress.Width = 150;
            // 
            // colDriver
            // 
            this.colDriver.HeaderText = "送货司机";
            this.colDriver.Name = "colDriver";
            this.colDriver.ReadOnly = true;
            // 
            // colDriverCall
            // 
            this.colDriverCall.HeaderText = "司机电话";
            this.colDriverCall.Name = "colDriverCall";
            this.colDriverCall.ReadOnly = true;
            // 
            // colCarPlate
            // 
            this.colCarPlate.HeaderText = "车牌号";
            this.colCarPlate.Name = "colCarPlate";
            this.colCarPlate.ReadOnly = true;
            // 
            // colMemo
            // 
            this.colMemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMemo.HeaderText = "备注";
            this.colMemo.MinimumWidth = 100;
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            // 
            // FrmStackOutSheetMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1244, 505);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnlFilter);
            this.Name = "FrmStackOutSheetMaster";
            this.Text = "送货单管理";
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.CategoryMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Fresh;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Add;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cMnu_SelectColumns;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkNullify;
        private System.Windows.Forms.CheckBox chkApproved;
        private System.Windows.Forms.CheckBox chkAdded;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox chkShipped;
        private System.Windows.Forms.ContextMenuStrip CategoryMenu;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddSheet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkWithoutTax;
        private System.Windows.Forms.CheckBox chkWithTax;
        private System.Windows.Forms.CheckBox chkSheetDate;
        private Controls.UCDateTimeInterval ucDateTimeInterval1;
        private System.Windows.Forms.Button btnLast3Month;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSheetDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSheetNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colWithTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCosts;
        private System.Windows.Forms.DataGridViewTextBoxColumn col国税计提;
        private System.Windows.Forms.DataGridViewTextBoxColumn col毛利;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShipDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLinker;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDriver;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDriverCall;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCarPlate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
    }
}