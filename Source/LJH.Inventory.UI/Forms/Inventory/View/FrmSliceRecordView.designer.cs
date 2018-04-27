namespace LJH.Inventory.UI.Forms.Inventory.View
{
    partial class FrmSliceRecordView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSliceRecordView));
            this.GridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.colSlicedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSlicedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBeforeWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBeforeLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAfterWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAfterLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSlicer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col操作员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridView
            // 
            this.GridView.AllowUserToAddRows = false;
            this.GridView.AllowUserToDeleteRows = false;
            this.GridView.AllowUserToResizeRows = false;
            this.GridView.BackgroundColor = System.Drawing.Color.White;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSlicedDateTime,
            this.colCategoryID,
            this.colSpecification,
            this.colSlicedTo,
            this.colBeforeWeight,
            this.colBeforeLength,
            this.colLength,
            this.colWeight,
            this.colAmount,
            this.colTotalWeight,
            this.colTotalLength,
            this.colAfterWeight,
            this.colAfterLength,
            this.colCustomer,
            this.colSlicer,
            this.col操作员});
            this.GridView.ContextMenuStrip = this.contextMenuStrip1;
            this.GridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridView.Location = new System.Drawing.Point(0, 0);
            this.GridView.Name = "GridView";
            this.GridView.ReadOnly = true;
            this.GridView.RowHeadersVisible = false;
            this.GridView.RowTemplate.Height = 23;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView.Size = new System.Drawing.Size(1106, 383);
            this.GridView.TabIndex = 22;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_Undo,
            this.cMnu_SelectColumns,
            this.cMnu_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // mnu_Undo
            // 
            this.mnu_Undo.Name = "mnu_Undo";
            this.mnu_Undo.Size = new System.Drawing.Size(124, 22);
            this.mnu_Undo.Text = "撤销加工";
            this.mnu_Undo.Click += new System.EventHandler(this.撤回加工ToolStripMenuItem_Click);
            // 
            // cMnu_SelectColumns
            // 
            this.cMnu_SelectColumns.Name = "cMnu_SelectColumns";
            this.cMnu_SelectColumns.Size = new System.Drawing.Size(124, 22);
            this.cMnu_SelectColumns.Text = "选择列...";
            // 
            // cMnu_Export
            // 
            this.cMnu_Export.Name = "cMnu_Export";
            this.cMnu_Export.Size = new System.Drawing.Size(124, 22);
            this.cMnu_Export.Text = "导出...";
            // 
            // colSlicedDateTime
            // 
            this.colSlicedDateTime.HeaderText = "加工日期";
            this.colSlicedDateTime.Name = "colSlicedDateTime";
            this.colSlicedDateTime.ReadOnly = true;
            this.colSlicedDateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCategoryID
            // 
            this.colCategoryID.HeaderText = "类别";
            this.colCategoryID.Name = "colCategoryID";
            this.colCategoryID.ReadOnly = true;
            this.colCategoryID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCategoryID.Width = 60;
            // 
            // colSpecification
            // 
            this.colSpecification.HeaderText = "规格";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            this.colSpecification.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSpecification.Width = 80;
            // 
            // colSlicedTo
            // 
            this.colSlicedTo.HeaderText = "小件类型";
            this.colSlicedTo.Name = "colSlicedTo";
            this.colSlicedTo.ReadOnly = true;
            this.colSlicedTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSlicedTo.Width = 80;
            // 
            // colBeforeWeight
            // 
            dataGridViewCellStyle1.Format = "N3";
            this.colBeforeWeight.DefaultCellStyle = dataGridViewCellStyle1;
            this.colBeforeWeight.HeaderText = "加工前重量";
            this.colBeforeWeight.Name = "colBeforeWeight";
            this.colBeforeWeight.ReadOnly = true;
            this.colBeforeWeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBeforeWeight.Width = 80;
            // 
            // colBeforeLength
            // 
            dataGridViewCellStyle2.Format = "N2";
            this.colBeforeLength.DefaultCellStyle = dataGridViewCellStyle2;
            this.colBeforeLength.HeaderText = "加工前长度";
            this.colBeforeLength.Name = "colBeforeLength";
            this.colBeforeLength.ReadOnly = true;
            this.colBeforeLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBeforeLength.Visible = false;
            this.colBeforeLength.Width = 80;
            // 
            // colLength
            // 
            dataGridViewCellStyle3.Format = "N3";
            this.colLength.DefaultCellStyle = dataGridViewCellStyle3;
            this.colLength.HeaderText = "小件长度";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colLength.Width = 80;
            // 
            // colWeight
            // 
            dataGridViewCellStyle4.Format = "N3";
            this.colWeight.DefaultCellStyle = dataGridViewCellStyle4;
            this.colWeight.HeaderText = "小件重量";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            this.colWeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colWeight.Width = 80;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "加工数量";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAmount.Width = 80;
            // 
            // colTotalWeight
            // 
            dataGridViewCellStyle5.Format = "N3";
            this.colTotalWeight.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTotalWeight.HeaderText = "加工重量";
            this.colTotalWeight.Name = "colTotalWeight";
            this.colTotalWeight.ReadOnly = true;
            this.colTotalWeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTotalWeight.Visible = false;
            this.colTotalWeight.Width = 80;
            // 
            // colTotalLength
            // 
            dataGridViewCellStyle6.Format = "N2";
            this.colTotalLength.DefaultCellStyle = dataGridViewCellStyle6;
            this.colTotalLength.HeaderText = "加工长度";
            this.colTotalLength.Name = "colTotalLength";
            this.colTotalLength.ReadOnly = true;
            this.colTotalLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTotalLength.Visible = false;
            this.colTotalLength.Width = 80;
            // 
            // colAfterWeight
            // 
            dataGridViewCellStyle7.Format = "N3";
            this.colAfterWeight.DefaultCellStyle = dataGridViewCellStyle7;
            this.colAfterWeight.HeaderText = "加工后重量";
            this.colAfterWeight.Name = "colAfterWeight";
            this.colAfterWeight.ReadOnly = true;
            this.colAfterWeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAfterWeight.Width = 80;
            // 
            // colAfterLength
            // 
            dataGridViewCellStyle8.Format = "N2";
            this.colAfterLength.DefaultCellStyle = dataGridViewCellStyle8;
            this.colAfterLength.HeaderText = "加工后长度";
            this.colAfterLength.Name = "colAfterLength";
            this.colAfterLength.ReadOnly = true;
            this.colAfterLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAfterLength.Visible = false;
            this.colAfterLength.Width = 80;
            // 
            // colCustomer
            // 
            this.colCustomer.HeaderText = "客户";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colSlicer
            // 
            this.colSlicer.HeaderText = "加工人员";
            this.colSlicer.Name = "colSlicer";
            this.colSlicer.ReadOnly = true;
            this.colSlicer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSlicer.Width = 80;
            // 
            // col操作员
            // 
            this.col操作员.HeaderText = "操作员";
            this.col操作员.Name = "col操作员";
            this.col操作员.ReadOnly = true;
            this.col操作员.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col操作员.Width = 80;
            // 
            // FrmSliceRecordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 405);
            this.Controls.Add(this.GridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSliceRecordView";
            this.Text = "铁皮卷加工记录";
            this.Controls.SetChildIndex(this.GridView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cMnu_SelectColumns;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
        private System.Windows.Forms.ToolStripMenuItem mnu_Undo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSlicedDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSlicedTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBeforeWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBeforeLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAfterWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAfterLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSlicer;
        private System.Windows.Forms.DataGridViewTextBoxColumn col操作员;
    }
}