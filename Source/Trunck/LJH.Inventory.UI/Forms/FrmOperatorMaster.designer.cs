namespace LJH.Inventory.UI.Forms
{
    partial class FrmOperatorMaster
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
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.OperatorView = new System.Windows.Forms.DataGridView();
            this.colOperatorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperatorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OperatorView)).BeginInit();
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
            this.txtKeyword,
            this.toolStripSeparator2});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(713, 50);
            this.menu.TabIndex = 22;
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
            this.txtKeyword.Size = new System.Drawing.Size(200, 30);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 46);
            // 
            // OperatorView
            // 
            this.OperatorView.AllowUserToAddRows = false;
            this.OperatorView.AllowUserToOrderColumns = true;
            this.OperatorView.AllowUserToResizeRows = false;
            this.OperatorView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OperatorView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOperatorID,
            this.colOperatorName,
            this.colRoleID,
            this.colDepartment,
            this.colPost,
            this.Column1});
            this.OperatorView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OperatorView.Location = new System.Drawing.Point(0, 50);
            this.OperatorView.Name = "OperatorView";
            this.OperatorView.RowHeadersVisible = false;
            this.OperatorView.RowHeadersWidth = 20;
            this.OperatorView.RowTemplate.Height = 23;
            this.OperatorView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OperatorView.Size = new System.Drawing.Size(713, 221);
            this.OperatorView.TabIndex = 58;
            // 
            // colOperatorID
            // 
            this.colOperatorID.DataPropertyName = "OperatorID";
            this.colOperatorID.HeaderText = "登录ID";
            this.colOperatorID.Name = "colOperatorID";
            this.colOperatorID.ReadOnly = true;
            // 
            // colOperatorName
            // 
            this.colOperatorName.DataPropertyName = "OperatorName";
            this.colOperatorName.HeaderText = "操作员名";
            this.colOperatorName.Name = "colOperatorName";
            this.colOperatorName.ReadOnly = true;
            // 
            // colRoleID
            // 
            this.colRoleID.DataPropertyName = "RoleID";
            this.colRoleID.HeaderText = "角色";
            this.colRoleID.Name = "colRoleID";
            this.colRoleID.ReadOnly = true;
            // 
            // colDepartment
            // 
            this.colDepartment.HeaderText = "部门";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.ReadOnly = true;
            this.colDepartment.Width = 150;
            // 
            // colPost
            // 
            this.colPost.HeaderText = "职位";
            this.colPost.Name = "colPost";
            this.colPost.ReadOnly = true;
            this.colPost.Width = 150;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmOperatorMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 293);
            this.Controls.Add(this.OperatorView);
            this.Controls.Add(this.menu);
            this.Name = "FrmOperatorMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "操作员管理";
            this.Controls.SetChildIndex(this.menu, 0);
            this.Controls.SetChildIndex(this.OperatorView, 0);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OperatorView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem btn_Add;
        private System.Windows.Forms.ToolStripMenuItem btn_Delete;
        private System.Windows.Forms.ToolStripMenuItem btn_Export;
        private System.Windows.Forms.ToolStripMenuItem btn_Fresh;
        private System.Windows.Forms.DataGridView OperatorView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperatorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperatorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.ToolStripMenuItem btn_SelectColumns;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private LJH.Inventory.UI.Controls.TooStripDBCTextBox txtKeyword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;


    }
}