namespace LJH.Inventory.UI.Forms.General
{
    partial class FrmStaffMaster
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.btn_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtKeyword = new LJH.Inventory.UI.Controls.TooStripDBCTextBox(this.components);
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.departmentTree1 = new LJH.Inventory.UI.Controls.DepartmentTree(this.components);
            this.CategoryMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_FreshTree = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_AddStaff = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_AddDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_DeleteDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_DepartmentProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCertificate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResigned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResignDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btn_Delete,
            this.btn_Export,
            this.btn_Fresh,
            this.btn_SelectColumns,
            this.toolStripSeparator1,
            this.txtKeyword});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1253, 50);
            this.menu.TabIndex = 32;
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
            // btn_Delete
            // 
            this.btn_Delete.Image = global::LJH.Inventory.UI.Properties.Resources.delete;
            this.btn_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(61, 46);
            this.btn_Delete.Text = "删除(&D)";
            this.btn_Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            this.txtKeyword.Size = new System.Drawing.Size(300, 30);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.departmentTree1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 50);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(194, 291);
            this.pnlLeft.TabIndex = 110;
            // 
            // departmentTree1
            // 
            this.departmentTree1.ContextMenuStrip = this.CategoryMenu;
            this.departmentTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.departmentTree1.ItemHeight = 20;
            this.departmentTree1.LoadStaff = false;
            this.departmentTree1.Location = new System.Drawing.Point(0, 0);
            this.departmentTree1.Name = "departmentTree1";
            this.departmentTree1.Size = new System.Drawing.Size(194, 291);
            this.departmentTree1.TabIndex = 0;
            this.departmentTree1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.departmentTree1_NodeMouseClick);
            // 
            // CategoryMenu
            // 
            this.CategoryMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_FreshTree,
            this.mnu_AddStaff,
            this.mnu_AddDepartment,
            this.mnu_DeleteDepartment,
            this.mnu_DepartmentProperty});
            this.CategoryMenu.Name = "contextMenuStrip1";
            this.CategoryMenu.Size = new System.Drawing.Size(125, 114);
            // 
            // mnu_FreshTree
            // 
            this.mnu_FreshTree.Name = "mnu_FreshTree";
            this.mnu_FreshTree.Size = new System.Drawing.Size(124, 22);
            this.mnu_FreshTree.Text = "刷新";
            this.mnu_FreshTree.Click += new System.EventHandler(this.mnu_FreshTree_Click);
            // 
            // mnu_AddStaff
            // 
            this.mnu_AddStaff.Name = "mnu_AddStaff";
            this.mnu_AddStaff.Size = new System.Drawing.Size(124, 22);
            this.mnu_AddStaff.Text = "新建员工";
            this.mnu_AddStaff.Click += new System.EventHandler(this.mnu_AddStaff_Click);
            // 
            // mnu_AddDepartment
            // 
            this.mnu_AddDepartment.Name = "mnu_AddDepartment";
            this.mnu_AddDepartment.Size = new System.Drawing.Size(124, 22);
            this.mnu_AddDepartment.Text = "增加部门";
            this.mnu_AddDepartment.Click += new System.EventHandler(this.mnu_AddDepartment_Click);
            // 
            // mnu_DeleteDepartment
            // 
            this.mnu_DeleteDepartment.Name = "mnu_DeleteDepartment";
            this.mnu_DeleteDepartment.Size = new System.Drawing.Size(124, 22);
            this.mnu_DeleteDepartment.Text = "删除部门";
            this.mnu_DeleteDepartment.Click += new System.EventHandler(this.mnu_DeleteDepartment_Click);
            // 
            // mnu_DepartmentProperty
            // 
            this.mnu_DepartmentProperty.Name = "mnu_DepartmentProperty";
            this.mnu_DepartmentProperty.Size = new System.Drawing.Size(124, 22);
            this.mnu_DepartmentProperty.Text = "属性";
            this.mnu_DepartmentProperty.Click += new System.EventHandler(this.mnu_DepartmentProperty_Click);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitter1.Location = new System.Drawing.Point(194, 50);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 291);
            this.splitter1.TabIndex = 111;
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
            this.colName,
            this.colCertificate,
            this.colDepartment,
            this.colSex,
            this.colPosition,
            this.colHireDate,
            this.colLogID,
            this.colRole,
            this.colResigned,
            this.colResignDate,
            this.colMemo});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(202, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1051, 291);
            this.dataGridView1.TabIndex = 112;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMnu_Fresh,
            this.cMnu_Add,
            this.cMnu_Delete,
            this.cMnu_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(110, 92);
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
            // cMnu_Delete
            // 
            this.cMnu_Delete.Name = "cMnu_Delete";
            this.cMnu_Delete.Size = new System.Drawing.Size(109, 22);
            this.cMnu_Delete.Text = "删除";
            // 
            // cMnu_Export
            // 
            this.cMnu_Export.Name = "cMnu_Export";
            this.cMnu_Export.Size = new System.Drawing.Size(109, 22);
            this.cMnu_Export.Text = "导出...";
            // 
            // colImage
            // 
            this.colImage.HeaderText = "";
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            this.colImage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colImage.Width = 30;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colName.HeaderText = "名称";
            this.colName.MinimumWidth = 120;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 120;
            // 
            // colCertificate
            // 
            this.colCertificate.HeaderText = "员工编号";
            this.colCertificate.Name = "colCertificate";
            this.colCertificate.ReadOnly = true;
            // 
            // colDepartment
            // 
            this.colDepartment.HeaderText = "部门";
            this.colDepartment.MinimumWidth = 120;
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.ReadOnly = true;
            this.colDepartment.Width = 120;
            // 
            // colSex
            // 
            this.colSex.HeaderText = "性别";
            this.colSex.Name = "colSex";
            this.colSex.ReadOnly = true;
            this.colSex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSex.Width = 40;
            // 
            // colPosition
            // 
            this.colPosition.HeaderText = "职位";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            this.colPosition.Width = 120;
            // 
            // colHireDate
            // 
            this.colHireDate.HeaderText = "入职日期";
            this.colHireDate.Name = "colHireDate";
            this.colHireDate.ReadOnly = true;
            // 
            // colLogID
            // 
            this.colLogID.HeaderText = "登录ID";
            this.colLogID.Name = "colLogID";
            this.colLogID.ReadOnly = true;
            // 
            // colRole
            // 
            this.colRole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colRole.HeaderText = "角色";
            this.colRole.MinimumWidth = 100;
            this.colRole.Name = "colRole";
            this.colRole.ReadOnly = true;
            this.colRole.Width = 120;
            // 
            // colResigned
            // 
            this.colResigned.HeaderText = "离职";
            this.colResigned.Name = "colResigned";
            this.colResigned.ReadOnly = true;
            this.colResigned.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colResigned.Visible = false;
            this.colResigned.Width = 40;
            // 
            // colResignDate
            // 
            this.colResignDate.HeaderText = "离职日期";
            this.colResignDate.Name = "colResignDate";
            this.colResignDate.ReadOnly = true;
            this.colResignDate.Visible = false;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "备注";
            this.colMemo.MinimumWidth = 150;
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            this.colMemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMemo.Width = 150;
            // 
            // FrmStaffMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 363);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.menu);
            this.Name = "FrmStaffMaster";
            this.Text = "员工管理";
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
        private System.Windows.Forms.ToolStripMenuItem btn_Delete;
        private System.Windows.Forms.ToolStripMenuItem btn_Export;
        private System.Windows.Forms.ToolStripMenuItem btn_Fresh;
        private System.Windows.Forms.ToolStripMenuItem btn_SelectColumns;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controls.TooStripDBCTextBox txtKeyword;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Controls.DepartmentTree departmentTree1;
        private System.Windows.Forms.ContextMenuStrip CategoryMenu;
        private System.Windows.Forms.ToolStripMenuItem mnu_FreshTree;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddStaff;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddDepartment;
        private System.Windows.Forms.ToolStripMenuItem mnu_DeleteDepartment;
        private System.Windows.Forms.ToolStripMenuItem mnu_DepartmentProperty;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Fresh;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Add;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Delete;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCertificate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHireDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResigned;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResignDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
    }
}