namespace LJH.Inventory.UI.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductInventoryMaster));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.btn_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtKeyword = new LJH.Inventory.UI.Controls.TooStripDBCTextBox(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.categoryTree = new System.Windows.Forms.TreeView();
            this.CategoryMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_FreshTree = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_AddCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_DeleteCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_CategoryProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colWareHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReserved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSum = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colEmpty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.CategoryMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.menu.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Add,
            this.btn_Export,
            this.btn_Fresh,
            this.btn_SelectColumns,
            this.toolStripSeparator1,
            this.txtKeyword,
            this.toolStripSeparator2});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1198, 50);
            this.menu.TabIndex = 48;
            // 
            // btn_Add
            // 
            this.btn_Add.Image = global::LJH.Inventory.UI.Properties.Resources.add;
            this.btn_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(62, 46);
            this.btn_Add.Text = "新建(&N)";
            this.btn_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btn_Export
            // 
            this.btn_Export.Image = global::LJH.Inventory.UI.Properties.Resources.export;
            this.btn_Export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(59, 46);
            this.btn_Export.Text = "导出(&E)";
            this.btn_Export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btn_Fresh
            // 
            this.btn_Fresh.Image = global::LJH.Inventory.UI.Properties.Resources.refresh;
            this.btn_Fresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Fresh.Name = "btn_Fresh";
            this.btn_Fresh.Size = new System.Drawing.Size(58, 46);
            this.btn_Fresh.Text = "刷新(&F)";
            this.btn_Fresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btn_SelectColumns
            // 
            this.btn_SelectColumns.Image = global::LJH.Inventory.UI.Properties.Resources.columns;
            this.btn_SelectColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_SelectColumns.Name = "btn_SelectColumns";
            this.btn_SelectColumns.Size = new System.Drawing.Size(70, 46);
            this.btn_SelectColumns.Text = "选择列(&L)";
            this.btn_SelectColumns.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // txtKeyword
            // 
            this.txtKeyword.AutoSize = false;
            this.txtKeyword.Margin = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(200, 30);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 46);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitter1.Location = new System.Drawing.Point(194, 50);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 309);
            this.splitter1.TabIndex = 110;
            this.splitter1.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.categoryTree);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 50);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(194, 309);
            this.pnlLeft.TabIndex = 109;
            // 
            // categoryTree
            // 
            this.categoryTree.ContextMenuStrip = this.CategoryMenu;
            this.categoryTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryTree.ImageIndex = 0;
            this.categoryTree.ImageList = this.imageList1;
            this.categoryTree.ItemHeight = 20;
            this.categoryTree.Location = new System.Drawing.Point(0, 0);
            this.categoryTree.Name = "categoryTree";
            this.categoryTree.SelectedImageIndex = 0;
            this.categoryTree.Size = new System.Drawing.Size(194, 309);
            this.categoryTree.TabIndex = 3;
            this.categoryTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.categoryTree_NodeMouseClick);
            // 
            // CategoryMenu
            // 
            this.CategoryMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_FreshTree,
            this.mnu_AddCategory,
            this.mnu_DeleteCategory,
            this.mnu_CategoryProperty});
            this.CategoryMenu.Name = "contextMenuStrip1";
            this.CategoryMenu.Size = new System.Drawing.Size(125, 92);
            // 
            // mnu_FreshTree
            // 
            this.mnu_FreshTree.Name = "mnu_FreshTree";
            this.mnu_FreshTree.Size = new System.Drawing.Size(124, 22);
            this.mnu_FreshTree.Text = "刷新";
            this.mnu_FreshTree.Click += new System.EventHandler(this.mnu_FreshTree_Click);
            // 
            // mnu_AddCategory
            // 
            this.mnu_AddCategory.Name = "mnu_AddCategory";
            this.mnu_AddCategory.Size = new System.Drawing.Size(124, 22);
            this.mnu_AddCategory.Text = "增加类别";
            this.mnu_AddCategory.Click += new System.EventHandler(this.mnu_AddCategory_Click);
            // 
            // mnu_DeleteCategory
            // 
            this.mnu_DeleteCategory.Name = "mnu_DeleteCategory";
            this.mnu_DeleteCategory.Size = new System.Drawing.Size(124, 22);
            this.mnu_DeleteCategory.Text = "删除";
            this.mnu_DeleteCategory.Click += new System.EventHandler(this.mnu_DeleteCategory_Click);
            // 
            // mnu_CategoryProperty
            // 
            this.mnu_CategoryProperty.Name = "mnu_CategoryProperty";
            this.mnu_CategoryProperty.Size = new System.Drawing.Size(124, 22);
            this.mnu_CategoryProperty.Text = "属性";
            this.mnu_CategoryProperty.Click += new System.EventHandler(this.mnu_CategoryProperty_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "inventory1.png");
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
            this.colSum,
            this.colEmpty});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(202, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(996, 309);
            this.dataGridView1.TabIndex = 111;
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
            this.colProductID.HeaderText = "商品编号";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colProductID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colProductID.Width = 120;
            // 
            // colProduct
            // 
            this.colProduct.HeaderText = "商品名称";
            this.colProduct.Name = "colProduct";
            this.colProduct.ReadOnly = true;
            this.colProduct.Width = 150;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "商品类别";
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
            this.colUnit.HeaderText = "";
            this.colUnit.Name = "colUnit";
            this.colUnit.ReadOnly = true;
            this.colUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colUnit.Width = 40;
            // 
            // colReserved
            // 
            this.colReserved.HeaderText = "已下单库存";
            this.colReserved.Name = "colReserved";
            this.colReserved.ReadOnly = true;
            this.colReserved.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colValid
            // 
            this.colValid.HeaderText = "未下单库存";
            this.colValid.Name = "colValid";
            this.colValid.ReadOnly = true;
            // 
            // colSum
            // 
            this.colSum.HeaderText = "库存合计";
            this.colSum.Name = "colSum";
            this.colSum.ReadOnly = true;
            // 
            // colEmpty
            // 
            this.colEmpty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEmpty.HeaderText = "";
            this.colEmpty.Name = "colEmpty";
            this.colEmpty.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMnu_Fresh,
            this.cMnu_Add,
            this.cMnu_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(110, 70);
            // 
            // cMnu_Fresh
            // 
            this.cMnu_Fresh.Name = "cMnu_Fresh";
            this.cMnu_Fresh.Size = new System.Drawing.Size(109, 22);
            this.cMnu_Fresh.Text = "刷新";
            // 
            // cMnu_Add
            // 
            this.cMnu_Add.Name = "cMnu_Add";
            this.cMnu_Add.Size = new System.Drawing.Size(109, 22);
            this.cMnu_Add.Text = "新建";
            // 
            // cMnu_Export
            // 
            this.cMnu_Export.Name = "cMnu_Export";
            this.cMnu_Export.Size = new System.Drawing.Size(109, 22);
            this.cMnu_Export.Text = "导出...";
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
            this.Controls.Add(this.menu);
            this.Name = "FrmProductInventoryMaster";
            this.Text = "商品库存资料";
            this.Controls.SetChildIndex(this.menu, 0);
            this.Controls.SetChildIndex(this.pnlLeft, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.CategoryMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem btn_Add;
        private System.Windows.Forms.ToolStripMenuItem btn_Export;
        private System.Windows.Forms.ToolStripMenuItem btn_Fresh;
        private System.Windows.Forms.ToolStripMenuItem btn_SelectColumns;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private LJH.Inventory.UI.Controls.TooStripDBCTextBox txtKeyword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWareHouse;
        private System.Windows.Forms.DataGridViewLinkColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReserved;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValid;
        private System.Windows.Forms.DataGridViewLinkColumn colSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpty;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Fresh;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Add;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
        private System.Windows.Forms.ContextMenuStrip CategoryMenu;
        private System.Windows.Forms.ToolStripMenuItem mnu_FreshTree;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddCategory;
        private System.Windows.Forms.ToolStripMenuItem mnu_CategoryProperty;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView categoryTree;
        private System.Windows.Forms.ToolStripMenuItem mnu_DeleteCategory;
    }
}