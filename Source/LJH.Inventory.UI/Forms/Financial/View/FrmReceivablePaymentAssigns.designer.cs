namespace LJH.Inventory.UI.Forms.Financial.View
{
    partial class FrmReceivablePaymentAssigns
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReceivablePaymentAssigns));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ItemsGrid = new System.Windows.Forms.DataGridView();
            this.colSheetID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colAssign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnu_AssignGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_UndoAssign = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsGrid)).BeginInit();
            this.mnu_AssignGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 250);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(555, 22);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(540, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "总共 0 项";
            // 
            // ItemsGrid
            // 
            this.ItemsGrid.AllowUserToAddRows = false;
            this.ItemsGrid.AllowUserToDeleteRows = false;
            this.ItemsGrid.AllowUserToResizeRows = false;
            this.ItemsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsGrid.BackgroundColor = System.Drawing.Color.White;
            this.ItemsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSheetID,
            this.colAssign,
            this.colFill});
            this.ItemsGrid.ContextMenuStrip = this.mnu_AssignGrid;
            this.ItemsGrid.Location = new System.Drawing.Point(0, 1);
            this.ItemsGrid.Name = "ItemsGrid";
            this.ItemsGrid.RowHeadersVisible = false;
            this.ItemsGrid.RowTemplate.Height = 23;
            this.ItemsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ItemsGrid.Size = new System.Drawing.Size(555, 246);
            this.ItemsGrid.TabIndex = 21;
            // 
            // colSheetID
            // 
            this.colSheetID.HeaderText = "单据编号";
            this.colSheetID.Name = "colSheetID";
            this.colSheetID.ReadOnly = true;
            this.colSheetID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSheetID.Width = 150;
            // 
            // colAssign
            // 
            dataGridViewCellStyle1.Format = "C2";
            this.colAssign.DefaultCellStyle = dataGridViewCellStyle1;
            this.colAssign.HeaderText = "分配金额";
            this.colAssign.Name = "colAssign";
            this.colAssign.ReadOnly = true;
            this.colAssign.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colFill
            // 
            this.colFill.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFill.HeaderText = "";
            this.colFill.Name = "colFill";
            this.colFill.ReadOnly = true;
            this.colFill.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // mnu_AssignGrid
            // 
            this.mnu_AssignGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_UndoAssign});
            this.mnu_AssignGrid.Name = "contextMenuStrip1";
            this.mnu_AssignGrid.Size = new System.Drawing.Size(137, 26);
            // 
            // mnu_UndoAssign
            // 
            this.mnu_UndoAssign.Name = "mnu_UndoAssign";
            this.mnu_UndoAssign.Size = new System.Drawing.Size(136, 22);
            this.mnu_UndoAssign.Text = "取消核销项";
            this.mnu_UndoAssign.Click += new System.EventHandler(this.mnu_UndoAssign_Click);
            // 
            // FrmReceivablePaymentAssigns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 272);
            this.Controls.Add(this.ItemsGrid);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReceivablePaymentAssigns";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "核销明细";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsGrid)).EndInit();
            this.mnu_AssignGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridView ItemsGrid;
        private System.Windows.Forms.DataGridViewLinkColumn colSheetID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssign;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFill;
        private System.Windows.Forms.ContextMenuStrip mnu_AssignGrid;
        private System.Windows.Forms.ToolStripMenuItem mnu_UndoAssign;
    }
}