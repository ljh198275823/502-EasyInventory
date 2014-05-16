namespace LJH.Inventory.UI.Forms.Sale.View
{
    partial class FrmOrderView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_Pay = new System.Windows.Forms.ToolStripMenuItem();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.txtKeyword = new LJH.Inventory.UI.Controls.TooStripDBCTextBox(this.components);
            this.GridView = new System.Windows.Forms.DataGridView();
            this.colOrderID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceivable = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colHasPaid = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colNotPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_Pay});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // mnu_Pay
            // 
            this.mnu_Pay.Name = "mnu_Pay";
            this.mnu_Pay.Size = new System.Drawing.Size(100, 22);
            this.mnu_Pay.Text = "支付";
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.menu.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtKeyword});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(637, 34);
            this.menu.TabIndex = 33;
            // 
            // txtKeyword
            // 
            this.txtKeyword.AutoSize = false;
            this.txtKeyword.Margin = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(200, 30);
            // 
            // GridView
            // 
            this.GridView.AllowUserToAddRows = false;
            this.GridView.AllowUserToDeleteRows = false;
            this.GridView.AllowUserToResizeRows = false;
            this.GridView.BackgroundColor = System.Drawing.Color.White;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderID,
            this.colAmount,
            this.colReceivable,
            this.colHasPaid,
            this.colNotPaid,
            this.colFill});
            this.GridView.ContextMenuStrip = this.contextMenuStrip1;
            this.GridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridView.Location = new System.Drawing.Point(0, 34);
            this.GridView.Name = "GridView";
            this.GridView.RowHeadersVisible = false;
            this.GridView.RowTemplate.Height = 23;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView.Size = new System.Drawing.Size(637, 260);
            this.GridView.TabIndex = 34;
            // 
            // colOrderID
            // 
            this.colOrderID.HeaderText = "销售订单";
            this.colOrderID.Name = "colOrderID";
            this.colOrderID.ReadOnly = true;
            this.colOrderID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colAmount
            // 
            dataGridViewCellStyle4.Format = "C2";
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAmount.HeaderText = "总金额";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colReceivable
            // 
            this.colReceivable.HeaderText = "已发货金额";
            this.colReceivable.Name = "colReceivable";
            this.colReceivable.ReadOnly = true;
            this.colReceivable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colReceivable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colHasPaid
            // 
            dataGridViewCellStyle5.Format = "C2";
            this.colHasPaid.DefaultCellStyle = dataGridViewCellStyle5;
            this.colHasPaid.HeaderText = "已收款";
            this.colHasPaid.Name = "colHasPaid";
            this.colHasPaid.ReadOnly = true;
            this.colHasPaid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colHasPaid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colNotPaid
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.colNotPaid.DefaultCellStyle = dataGridViewCellStyle6;
            this.colNotPaid.HeaderText = "未收款";
            this.colNotPaid.Name = "colNotPaid";
            this.colNotPaid.ReadOnly = true;
            this.colNotPaid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colFill
            // 
            this.colFill.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFill.HeaderText = "";
            this.colFill.Name = "colFill";
            this.colFill.ReadOnly = true;
            // 
            // FrmOrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 316);
            this.Controls.Add(this.GridView);
            this.Controls.Add(this.menu);
            this.Name = "FrmOrderView";
            this.Text = "销售订单选择";
            this.Controls.SetChildIndex(this.menu, 0);
            this.Controls.SetChildIndex(this.GridView, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnu_Pay;
        private System.Windows.Forms.MenuStrip menu;
        private Controls.TooStripDBCTextBox txtKeyword;
        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.DataGridViewLinkColumn colOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewLinkColumn colReceivable;
        private System.Windows.Forms.DataGridViewLinkColumn colHasPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFill;
    }
}