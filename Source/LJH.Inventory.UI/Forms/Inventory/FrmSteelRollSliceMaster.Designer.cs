namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class FrmSteelRollSliceMaster
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
            this.chk开卷 = new System.Windows.Forms.CheckBox();
            this.chk开吨 = new System.Windows.Forms.CheckBox();
            this.chk开平 = new System.Windows.Forms.CheckBox();
            this.categoryComboBox1 = new LJH.Inventory.UI.Controls.CategoryComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSpecification = new LJH.Inventory.UI.Controls.SpecificationComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.wareHouseComboBox1 = new LJH.Inventory.UI.Controls.WareHouseComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Check = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_StackRecords = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cMnu_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colWareHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValid = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colReserved = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewLinkColumn();
            this.pnlFilter.SuspendLayout();
            this.panel5.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.panel5);
            this.pnlFilter.Controls.Add(this.panel4);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1219, 38);
            this.pnlFilter.TabIndex = 112;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chk开卷);
            this.panel5.Controls.Add(this.chk开吨);
            this.panel5.Controls.Add(this.chk开平);
            this.panel5.Controls.Add(this.categoryComboBox1);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.cmbSpecification);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.wareHouseComboBox1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(1, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1218, 38);
            this.panel5.TabIndex = 7;
            // 
            // chk开卷
            // 
            this.chk开卷.AutoSize = true;
            this.chk开卷.Checked = true;
            this.chk开卷.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk开卷.Location = new System.Drawing.Point(574, 12);
            this.chk开卷.Name = "chk开卷";
            this.chk开卷.Size = new System.Drawing.Size(48, 16);
            this.chk开卷.TabIndex = 85;
            this.chk开卷.Text = "开卷";
            this.chk开卷.UseVisualStyleBackColor = true;
            this.chk开卷.CheckedChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // chk开吨
            // 
            this.chk开吨.AutoSize = true;
            this.chk开吨.Checked = true;
            this.chk开吨.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk开吨.Location = new System.Drawing.Point(683, 12);
            this.chk开吨.Name = "chk开吨";
            this.chk开吨.Size = new System.Drawing.Size(48, 16);
            this.chk开吨.TabIndex = 84;
            this.chk开吨.Text = "开吨";
            this.chk开吨.UseVisualStyleBackColor = true;
            this.chk开吨.CheckedChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // chk开平
            // 
            this.chk开平.AutoSize = true;
            this.chk开平.Checked = true;
            this.chk开平.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk开平.Location = new System.Drawing.Point(629, 12);
            this.chk开平.Name = "chk开平";
            this.chk开平.Size = new System.Drawing.Size(48, 16);
            this.chk开平.TabIndex = 83;
            this.chk开平.Text = "开平";
            this.chk开平.UseVisualStyleBackColor = true;
            this.chk开平.CheckedChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // categoryComboBox1
            // 
            this.categoryComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox1.FormattingEnabled = true;
            this.categoryComboBox1.Location = new System.Drawing.Point(262, 10);
            this.categoryComboBox1.Name = "categoryComboBox1";
            this.categoryComboBox1.Size = new System.Drawing.Size(121, 20);
            this.categoryComboBox1.TabIndex = 82;
            this.categoryComboBox1.SelectedIndexChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 81;
            this.label2.Text = "类别";
            // 
            // cmbSpecification
            // 
            this.cmbSpecification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecification.FormattingEnabled = true;
            this.cmbSpecification.Location = new System.Drawing.Point(423, 10);
            this.cmbSpecification.Name = "cmbSpecification";
            this.cmbSpecification.Size = new System.Drawing.Size(121, 20);
            this.cmbSpecification.TabIndex = 80;
            this.cmbSpecification.SelectedIndexChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 79;
            this.label5.Text = "规格";
            // 
            // wareHouseComboBox1
            // 
            this.wareHouseComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wareHouseComboBox1.FormattingEnabled = true;
            this.wareHouseComboBox1.Location = new System.Drawing.Point(59, 10);
            this.wareHouseComboBox1.Name = "wareHouseComboBox1";
            this.wareHouseComboBox1.Size = new System.Drawing.Size(151, 20);
            this.wareHouseComboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "仓库";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 38);
            this.panel4.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMnu_Fresh,
            this.cMnu_Add,
            this.mnu_Check,
            this.mnu_StackRecords,
            this.toolStripSeparator3,
            this.cMnu_SelectColumns,
            this.cMnu_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 142);
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
            this.cMnu_Add.Text = "新建库存";
            // 
            // mnu_Check
            // 
            this.mnu_Check.Name = "mnu_Check";
            this.mnu_Check.Size = new System.Drawing.Size(148, 22);
            this.mnu_Check.Text = "盘点";
            this.mnu_Check.Click += new System.EventHandler(this.mnu_Check_Click);
            // 
            // mnu_StackRecords
            // 
            this.mnu_StackRecords.Name = "mnu_StackRecords";
            this.mnu_StackRecords.Size = new System.Drawing.Size(148, 22);
            this.mnu_StackRecords.Text = "产品进出明细";
            this.mnu_StackRecords.Click += new System.EventHandler(this.mnu_StackRecords_Click);
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImage,
            this.colWareHouse,
            this.colCategory,
            this.colSpecification,
            this.colModel,
            this.colWeight,
            this.colLength,
            this.colValid,
            this.colReserved,
            this.colTotal});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1219, 334);
            this.dataGridView1.TabIndex = 115;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colImage
            // 
            this.colImage.HeaderText = "";
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            this.colImage.Width = 30;
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
            this.colCategory.HeaderText = "产品类别";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            // 
            // colSpecification
            // 
            this.colSpecification.HeaderText = "规格";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            // 
            // colModel
            // 
            this.colModel.HeaderText = "加工类型";
            this.colModel.Name = "colModel";
            this.colModel.ReadOnly = true;
            // 
            // colWeight
            // 
            this.colWeight.HeaderText = "重量(吨)";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            // 
            // colLength
            // 
            this.colLength.HeaderText = "长度(米)";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            // 
            // colValid
            // 
            this.colValid.HeaderText = "可用库存";
            this.colValid.Name = "colValid";
            this.colValid.ReadOnly = true;
            this.colValid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colValid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colReserved
            // 
            this.colReserved.HeaderText = "订单备货";
            this.colReserved.Name = "colReserved";
            this.colReserved.ReadOnly = true;
            this.colReserved.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colReserved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "库存合计";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FrmSteelRollSliceMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1219, 394);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnlFilter);
            this.Name = "FrmSteelRollSliceMaster";
            this.Text = "小件管理";
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.pnlFilter.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Fresh;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Add;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cMnu_SelectColumns;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private Controls.WareHouseComboBox wareHouseComboBox1;
        private System.Windows.Forms.ToolStripMenuItem mnu_StackRecords;
        private System.Windows.Forms.ToolStripMenuItem mnu_Check;
        private Controls.SpecificationComboBox cmbSpecification;
        private System.Windows.Forms.Label label5;
        private Controls.CategoryComboBox categoryComboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox chk开卷;
        private System.Windows.Forms.CheckBox chk开吨;
        private System.Windows.Forms.CheckBox chk开平;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWareHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewLinkColumn colValid;
        private System.Windows.Forms.DataGridViewLinkColumn colReserved;
        private System.Windows.Forms.DataGridViewLinkColumn colTotal;
    }
}