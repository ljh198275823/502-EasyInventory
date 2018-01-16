namespace LJH.Inventory.UI.Forms.Inventory.View
{
    partial class FrmSteelRollCheckRecordView
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
            this.GridView = new System.Windows.Forms.DataGridView();
            this.colCheckDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBeforeWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBeforeLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChecker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
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
            this.colCheckDate,
            this.colBeforeWeight,
            this.colBeforeLength,
            this.colWeight,
            this.colLength,
            this.colChecker,
            this.colMemo});
            this.GridView.ContextMenuStrip = this.contextMenuStrip1;
            this.GridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridView.Location = new System.Drawing.Point(0, 0);
            this.GridView.Name = "GridView";
            this.GridView.ReadOnly = true;
            this.GridView.RowHeadersVisible = false;
            this.GridView.RowTemplate.Height = 23;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GridView.Size = new System.Drawing.Size(708, 309);
            this.GridView.TabIndex = 23;
            // 
            // colCheckDate
            // 
            this.colCheckDate.HeaderText = "盘点日期";
            this.colCheckDate.Name = "colCheckDate";
            this.colCheckDate.ReadOnly = true;
            // 
            // colBeforeWeight
            // 
            dataGridViewCellStyle1.Format = "N4";
            this.colBeforeWeight.DefaultCellStyle = dataGridViewCellStyle1;
            this.colBeforeWeight.HeaderText = "盘点前重量";
            this.colBeforeWeight.Name = "colBeforeWeight";
            this.colBeforeWeight.ReadOnly = true;
            // 
            // colBeforeLength
            // 
            dataGridViewCellStyle2.Format = "N2";
            this.colBeforeLength.DefaultCellStyle = dataGridViewCellStyle2;
            this.colBeforeLength.HeaderText = "盘点前长度";
            this.colBeforeLength.Name = "colBeforeLength";
            this.colBeforeLength.ReadOnly = true;
            // 
            // colWeight
            // 
            dataGridViewCellStyle3.Format = "N4";
            this.colWeight.DefaultCellStyle = dataGridViewCellStyle3;
            this.colWeight.HeaderText = "盘点后重量";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            // 
            // colLength
            // 
            dataGridViewCellStyle4.Format = "N2";
            this.colLength.DefaultCellStyle = dataGridViewCellStyle4;
            this.colLength.HeaderText = "盘点后长度";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            // 
            // colChecker
            // 
            this.colChecker.HeaderText = "盘点人员";
            this.colChecker.Name = "colChecker";
            this.colChecker.ReadOnly = true;
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
            this.cMnu_SelectColumns,
            this.cMnu_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(122, 48);
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
            // FrmSteelRollCheckRecordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 331);
            this.Controls.Add(this.GridView);
            this.Name = "FrmSteelRollCheckRecordView";
            this.Text = "原材料盘点记录";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBeforeWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBeforeLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChecker;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
    }
}