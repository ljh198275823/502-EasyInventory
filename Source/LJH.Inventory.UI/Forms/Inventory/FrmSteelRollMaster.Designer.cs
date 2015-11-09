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
            this.wareHouseComboBox1 = new LJH.Inventory.UI.Controls.WareHouseComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSpecification = new LJH.Inventory.UI.Controls.SpecificationComboBox(this.components);
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.categoryTree = new LJH.Inventory.UI.Controls.ProductTree(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Check = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Nullify = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cMnu_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFilter.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlLeft.SuspendLayout();
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
            this.pnlFilter.Size = new System.Drawing.Size(1481, 75);
            this.pnlFilter.TabIndex = 112;
            // 
            // panel5
            // 
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
            this.panel5.Size = new System.Drawing.Size(1480, 75);
            this.panel5.TabIndex = 7;
            // 
            // wareHouseComboBox1
            // 
            this.wareHouseComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wareHouseComboBox1.FormattingEnabled = true;
            this.wareHouseComboBox1.Location = new System.Drawing.Point(292, 14);
            this.wareHouseComboBox1.Name = "wareHouseComboBox1";
            this.wareHouseComboBox1.Size = new System.Drawing.Size(112, 20);
            this.wareHouseComboBox1.TabIndex = 83;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 81;
            this.label4.Text = "仓库";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(292, 45);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(112, 20);
            this.cmbSupplier.TabIndex = 80;
            this.cmbSupplier.SelectedIndexChanged += new System.EventHandler(this.cmbSupplier_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 79;
            this.label3.Text = "供应商";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(455, 45);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(121, 20);
            this.cmbBrand.TabIndex = 78;
            this.cmbBrand.SelectedIndexChanged += new System.EventHandler(this.cmbBrand_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(421, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 77;
            this.label9.Text = "厂家";
            // 
            // cmbSpecification
            // 
            this.cmbSpecification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecification.FormattingEnabled = true;
            this.cmbSpecification.Location = new System.Drawing.Point(455, 14);
            this.cmbSpecification.Name = "cmbSpecification";
            this.cmbSpecification.Size = new System.Drawing.Size(121, 20);
            this.cmbSpecification.TabIndex = 76;
            this.cmbSpecification.SelectedIndexChanged += new System.EventHandler(this.cmbSpecification_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(423, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 75;
            this.label5.Text = "规格";
            // 
            // txtWeight
            // 
            this.txtWeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWeight.Location = new System.Drawing.Point(662, 14);
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
            this.txtWeight.TextChanged += new System.EventHandler(this.txtWeight_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(606, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 52;
            this.label2.Text = "剩余重量";
            // 
            // chkShipped
            // 
            this.chkShipped.AutoSize = true;
            this.chkShipped.Location = new System.Drawing.Point(814, 47);
            this.chkShipped.Name = "chkShipped";
            this.chkShipped.Size = new System.Drawing.Size(60, 16);
            this.chkShipped.TabIndex = 51;
            this.chkShipped.Text = "已发货";
            this.chkShipped.UseVisualStyleBackColor = true;
            this.chkShipped.CheckedChanged += new System.EventHandler(this.chkState_CheckedChanged);
            // 
            // chkWaitShip
            // 
            this.chkWaitShip.AutoSize = true;
            this.chkWaitShip.Checked = true;
            this.chkWaitShip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWaitShip.Location = new System.Drawing.Point(705, 47);
            this.chkWaitShip.Name = "chkWaitShip";
            this.chkWaitShip.Size = new System.Drawing.Size(60, 16);
            this.chkWaitShip.TabIndex = 50;
            this.chkWaitShip.Text = "待发货";
            this.chkWaitShip.UseVisualStyleBackColor = true;
            this.chkWaitShip.CheckedChanged += new System.EventHandler(this.chkState_CheckedChanged);
            // 
            // chkRemainless
            // 
            this.chkRemainless.AutoSize = true;
            this.chkRemainless.Location = new System.Drawing.Point(876, 47);
            this.chkRemainless.Name = "chkRemainless";
            this.chkRemainless.Size = new System.Drawing.Size(60, 16);
            this.chkRemainless.TabIndex = 49;
            this.chkRemainless.Text = "无余料";
            this.chkRemainless.UseVisualStyleBackColor = true;
            this.chkRemainless.CheckedChanged += new System.EventHandler(this.chkState_CheckedChanged);
            // 
            // chkOnlyTail
            // 
            this.chkOnlyTail.AutoSize = true;
            this.chkOnlyTail.Checked = true;
            this.chkOnlyTail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyTail.Location = new System.Drawing.Point(766, 47);
            this.chkOnlyTail.Name = "chkOnlyTail";
            this.chkOnlyTail.Size = new System.Drawing.Size(48, 16);
            this.chkOnlyTail.TabIndex = 48;
            this.chkOnlyTail.Text = "尾卷";
            this.chkOnlyTail.UseVisualStyleBackColor = true;
            this.chkOnlyTail.CheckedChanged += new System.EventHandler(this.chkState_CheckedChanged);
            // 
            // chkPartial
            // 
            this.chkPartial.AutoSize = true;
            this.chkPartial.Checked = true;
            this.chkPartial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPartial.Location = new System.Drawing.Point(657, 47);
            this.chkPartial.Name = "chkPartial";
            this.chkPartial.Size = new System.Drawing.Size(48, 16);
            this.chkPartial.TabIndex = 47;
            this.chkPartial.Text = "余卷";
            this.chkPartial.UseVisualStyleBackColor = true;
            this.chkPartial.CheckedChanged += new System.EventHandler(this.chkState_CheckedChanged);
            // 
            // chkIntact
            // 
            this.chkIntact.AutoSize = true;
            this.chkIntact.Checked = true;
            this.chkIntact.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIntact.Location = new System.Drawing.Point(608, 47);
            this.chkIntact.Name = "chkIntact";
            this.chkIntact.Size = new System.Drawing.Size(48, 16);
            this.chkIntact.TabIndex = 46;
            this.chkIntact.Text = "整卷";
            this.chkIntact.UseVisualStyleBackColor = true;
            this.chkIntact.CheckedChanged += new System.EventHandler(this.chkState_CheckedChanged);
            // 
            // dtStorage
            // 
            this.dtStorage.CustomFormat = "yyyy-MM-dd";
            this.dtStorage.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStorage.Location = new System.Drawing.Point(821, 14);
            this.dtStorage.Name = "dtStorage";
            this.dtStorage.Size = new System.Drawing.Size(106, 21);
            this.dtStorage.TabIndex = 45;
            this.dtStorage.ValueChanged += new System.EventHandler(this.dtStorage_ValueChanged);
            // 
            // chkStorageDT
            // 
            this.chkStorageDT.AutoSize = true;
            this.chkStorageDT.Location = new System.Drawing.Point(749, 16);
            this.chkStorageDT.Name = "chkStorageDT";
            this.chkStorageDT.Size = new System.Drawing.Size(72, 16);
            this.chkStorageDT.TabIndex = 44;
            this.chkStorageDT.Text = "进货日期";
            this.chkStorageDT.UseVisualStyleBackColor = true;
            this.chkStorageDT.CheckedChanged += new System.EventHandler(this.chkState_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 75);
            this.panel4.TabIndex = 6;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.categoryTree);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 75);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(242, 457);
            this.pnlLeft.TabIndex = 113;
            // 
            // categoryTree
            // 
            this.categoryTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryTree.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.categoryTree.HideSelection = false;
            this.categoryTree.ImageIndex = 0;
            this.categoryTree.ItemHeight = 20;
            this.categoryTree.LoadProduct = false;
            this.categoryTree.Location = new System.Drawing.Point(0, 0);
            this.categoryTree.Name = "categoryTree";
            this.categoryTree.SelectedImageIndex = 0;
            this.categoryTree.Size = new System.Drawing.Size(242, 457);
            this.categoryTree.TabIndex = 3;
            this.categoryTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.categoryTree_NodeMouseClick);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitter1.Location = new System.Drawing.Point(242, 75);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 457);
            this.splitter1.TabIndex = 114;
            this.splitter1.TabStop = false;
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
            this.colState,
            this.colMemo});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(250, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1231, 457);
            this.dataGridView1.TabIndex = 115;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            // colState
            // 
            this.colState.HeaderText = "状态";
            this.colState.Name = "colState";
            this.colState.ReadOnly = true;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMnu_Fresh,
            this.cMnu_Add,
            this.mnu_Check,
            this.mnu_Nullify,
            this.toolStripSeparator3,
            this.cMnu_SelectColumns,
            this.cMnu_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(122, 142);
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
            // mnu_Check
            // 
            this.mnu_Check.Name = "mnu_Check";
            this.mnu_Check.Size = new System.Drawing.Size(121, 22);
            this.mnu_Check.Text = "盘点";
            this.mnu_Check.Click += new System.EventHandler(this.mnu_Check_Click);
            // 
            // mnu_Nullify
            // 
            this.mnu_Nullify.Name = "mnu_Nullify";
            this.mnu_Nullify.Size = new System.Drawing.Size(121, 22);
            this.mnu_Nullify.Text = "作废";
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
            // FrmSteelRollMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1481, 554);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlFilter);
            this.Name = "FrmSteelRollMaster";
            this.Text = "原材料管理";
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            this.Controls.SetChildIndex(this.pnlLeft, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.pnlFilter.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlLeft;
        private Controls.ProductTree categoryTree;
        private System.Windows.Forms.Splitter splitter1;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        private Controls.SpecificationComboBox cmbSpecification;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private Controls.WareHouseComboBox wareHouseComboBox1;
    }
}