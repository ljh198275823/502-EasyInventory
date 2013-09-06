namespace LJH.Inventory.UI.Forms
{
    partial class FrmOrderSelection
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_Pay = new System.Windows.Forms.ToolStripMenuItem();
            this.GridView = new System.Windows.Forms.DataGridView();
            this.colSheetNo = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceivable = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colPaid = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colNotPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
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
            this.mnu_Pay.Click += new System.EventHandler(this.mnu_Pay_Click);
            // 
            // GridView
            // 
            this.GridView.AllowUserToAddRows = false;
            this.GridView.AllowUserToDeleteRows = false;
            this.GridView.AllowUserToResizeRows = false;
            this.GridView.BackgroundColor = System.Drawing.Color.White;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSheetNo,
            this.colAmount,
            this.colReceivable,
            this.colPaid,
            this.colNotPaid,
            this.colFill});
            this.GridView.ContextMenuStrip = this.contextMenuStrip1;
            this.GridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridView.Location = new System.Drawing.Point(0, 0);
            this.GridView.Name = "GridView";
            this.GridView.RowHeadersVisible = false;
            this.GridView.RowTemplate.Height = 23;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView.Size = new System.Drawing.Size(553, 294);
            this.GridView.TabIndex = 19;
            // 
            // colSheetNo
            // 
            this.colSheetNo.HeaderText = "销售订单";
            this.colSheetNo.Name = "colSheetNo";
            this.colSheetNo.ReadOnly = true;
            this.colSheetNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colAmount
            // 
            dataGridViewCellStyle1.Format = "C2";
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle1;
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
            // colPaid
            // 
            dataGridViewCellStyle2.Format = "C2";
            this.colPaid.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPaid.HeaderText = "已收款";
            this.colPaid.Name = "colPaid";
            this.colPaid.ReadOnly = true;
            this.colPaid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPaid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colNotPaid
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.colNotPaid.DefaultCellStyle = dataGridViewCellStyle3;
            this.colNotPaid.HeaderText = "应收账款";
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
            // FrmOrderSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 316);
            this.Controls.Add(this.GridView);
            this.Name = "FrmOrderSelection";
            this.Text = "应收货款明细";
            this.Load += new System.EventHandler(this.FrmCustomerReceivables_Load);
            this.Controls.SetChildIndex(this.GridView, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnu_Pay;
        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.DataGridViewLinkColumn colSheetNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewLinkColumn colReceivable;
        private System.Windows.Forms.DataGridViewLinkColumn colPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFill;
    }
}