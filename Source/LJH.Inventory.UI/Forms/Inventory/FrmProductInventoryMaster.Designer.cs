﻿namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class FrmProductInventoryMaster
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
            this.chkOnlyHasInventory = new System.Windows.Forms.CheckBox();
            this.txtKeyword = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.wareHouseComboBox1 = new LJH.Inventory.UI.Controls.WareHouseComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.categoryTree = new LJH.Inventory.UI.Controls.ProductTree(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colWareHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReserved = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colValid = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewLinkColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_StackRecords = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cMnu_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Check = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFilter.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.panel5);
            this.pnlFilter.Controls.Add(this.panel4);
            this.pnlFilter.Controls.Add(this.panel2);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1198, 38);
            this.pnlFilter.TabIndex = 112;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chkOnlyHasInventory);
            this.panel5.Controls.Add(this.txtKeyword);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(242, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(956, 38);
            this.panel5.TabIndex = 7;
            // 
            // chkOnlyHasInventory
            // 
            this.chkOnlyHasInventory.AutoSize = true;
            this.chkOnlyHasInventory.Checked = true;
            this.chkOnlyHasInventory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyHasInventory.Location = new System.Drawing.Point(8, 10);
            this.chkOnlyHasInventory.Name = "chkOnlyHasInventory";
            this.chkOnlyHasInventory.Size = new System.Drawing.Size(120, 16);
            this.chkOnlyHasInventory.TabIndex = 2;
            this.chkOnlyHasInventory.Text = "只显示有库存的项";
            this.chkOnlyHasInventory.UseVisualStyleBackColor = true;
            this.chkOnlyHasInventory.CheckedChanged += new System.EventHandler(this.chkOnlyHasInventory_CheckedChanged);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyword.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtKeyword.Location = new System.Drawing.Point(203, 7);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(741, 21);
            this.txtKeyword.TabIndex = 1;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "模糊匹配";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(241, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 38);
            this.panel4.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.wareHouseComboBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 38);
            this.panel2.TabIndex = 2;
            // 
            // wareHouseComboBox1
            // 
            this.wareHouseComboBox1.FormattingEnabled = true;
            this.wareHouseComboBox1.Location = new System.Drawing.Point(44, 7);
            this.wareHouseComboBox1.Name = "wareHouseComboBox1";
            this.wareHouseComboBox1.Size = new System.Drawing.Size(192, 20);
            this.wareHouseComboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "仓库";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.categoryTree);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 38);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(242, 321);
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
            this.categoryTree.Size = new System.Drawing.Size(242, 321);
            this.categoryTree.TabIndex = 3;
            this.categoryTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.categoryTree_NodeMouseClick);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitter1.Location = new System.Drawing.Point(242, 38);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 321);
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
            this.colImage,
            this.colWareHouse,
            this.colProductID,
            this.colProduct,
            this.colCategory,
            this.colSpecification,
            this.colModel,
            this.colUnit,
            this.colReserved,
            this.colValid,
            this.colAmount});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(250, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(948, 321);
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
            // colProductID
            // 
            this.colProductID.HeaderText = "产品编号";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colProductID.Width = 120;
            // 
            // colProduct
            // 
            this.colProduct.HeaderText = "产品名称";
            this.colProduct.Name = "colProduct";
            this.colProduct.ReadOnly = true;
            this.colProduct.Width = 150;
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
            this.colModel.HeaderText = "型号";
            this.colModel.Name = "colModel";
            this.colModel.ReadOnly = true;
            // 
            // colUnit
            // 
            this.colUnit.HeaderText = "单位";
            this.colUnit.Name = "colUnit";
            this.colUnit.ReadOnly = true;
            this.colUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colUnit.Width = 40;
            // 
            // colReserved
            // 
            this.colReserved.HeaderText = "订单备货";
            this.colReserved.Name = "colReserved";
            this.colReserved.ReadOnly = true;
            this.colReserved.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colReserved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colValid
            // 
            this.colValid.HeaderText = "可用库存";
            this.colValid.Name = "colValid";
            this.colValid.ReadOnly = true;
            this.colValid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colValid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "库存合计";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 164);
            // 
            // cMnu_Fresh
            // 
            this.cMnu_Fresh.Name = "cMnu_Fresh";
            this.cMnu_Fresh.Size = new System.Drawing.Size(152, 22);
            this.cMnu_Fresh.Text = "刷新";
            // 
            // cMnu_Add
            // 
            this.cMnu_Add.Name = "cMnu_Add";
            this.cMnu_Add.Size = new System.Drawing.Size(152, 22);
            this.cMnu_Add.Text = "新建";
            // 
            // mnu_StackRecords
            // 
            this.mnu_StackRecords.Name = "mnu_StackRecords";
            this.mnu_StackRecords.Size = new System.Drawing.Size(152, 22);
            this.mnu_StackRecords.Text = "产品进出明细";
            this.mnu_StackRecords.Click += new System.EventHandler(this.mnu_StackRecords_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // cMnu_SelectColumns
            // 
            this.cMnu_SelectColumns.Name = "cMnu_SelectColumns";
            this.cMnu_SelectColumns.Size = new System.Drawing.Size(152, 22);
            this.cMnu_SelectColumns.Text = "选择列...";
            // 
            // cMnu_Export
            // 
            this.cMnu_Export.Name = "cMnu_Export";
            this.cMnu_Export.Size = new System.Drawing.Size(152, 22);
            this.cMnu_Export.Text = "导出...";
            // 
            // mnu_Check
            // 
            this.mnu_Check.Name = "mnu_Check";
            this.mnu_Check.Size = new System.Drawing.Size(152, 22);
            this.mnu_Check.Text = "盘点";
            this.mnu_Check.Click += new System.EventHandler(this.mnu_Check_Click);
            // 
            // FrmProductInventoryMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1198, 381);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlFilter);
            this.Name = "FrmProductInventoryMaster";
            this.Text = "产品库存资料";
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            this.Controls.SetChildIndex(this.pnlLeft, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.pnlFilter.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private GeneralLibrary.WinformControl.DBCTextBox txtKeyword;
        private System.Windows.Forms.Label label2;
        private Controls.WareHouseComboBox wareHouseComboBox1;
        private System.Windows.Forms.CheckBox chkOnlyHasInventory;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWareHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewLinkColumn colReserved;
        private System.Windows.Forms.DataGridViewLinkColumn colValid;
        private System.Windows.Forms.DataGridViewLinkColumn colAmount;
        private System.Windows.Forms.ToolStripMenuItem mnu_StackRecords;
        private System.Windows.Forms.ToolStripMenuItem mnu_Check;
    }
}