namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class Frm成本明细
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GridView = new System.Windows.Forms.DataGridView();
            this.btn设置其它成本 = new System.Windows.Forms.Button();
            this.btn设置结算单价 = new System.Windows.Forms.Button();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWithTax = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col供应商 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col操作员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // GridView
            // 
            this.GridView.AllowUserToAddRows = false;
            this.GridView.AllowUserToDeleteRows = false;
            this.GridView.AllowUserToResizeRows = false;
            this.GridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridView.BackgroundColor = System.Drawing.Color.White;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colPrice,
            this.colWithTax,
            this.col供应商,
            this.col操作员,
            this.colMemo});
            this.GridView.Location = new System.Drawing.Point(0, 66);
            this.GridView.Name = "GridView";
            this.GridView.ReadOnly = true;
            this.GridView.RowHeadersVisible = false;
            this.GridView.RowTemplate.Height = 23;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView.Size = new System.Drawing.Size(696, 239);
            this.GridView.TabIndex = 23;
            // 
            // btn设置其它成本
            // 
            this.btn设置其它成本.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn设置其它成本.Location = new System.Drawing.Point(592, 14);
            this.btn设置其它成本.Name = "btn设置其它成本";
            this.btn设置其它成本.Size = new System.Drawing.Size(92, 37);
            this.btn设置其它成本.TabIndex = 159;
            this.btn设置其它成本.Text = "设置其它成本";
            this.btn设置其它成本.UseVisualStyleBackColor = true;
            this.btn设置其它成本.Click += new System.EventHandler(this.btn设置其它成本_Click);
            // 
            // btn设置结算单价
            // 
            this.btn设置结算单价.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn设置结算单价.Location = new System.Drawing.Point(476, 14);
            this.btn设置结算单价.Name = "btn设置结算单价";
            this.btn设置结算单价.Size = new System.Drawing.Size(92, 37);
            this.btn设置结算单价.TabIndex = 158;
            this.btn设置结算单价.Text = "设置结算单价";
            this.btn设置结算单价.UseVisualStyleBackColor = true;
            this.btn设置结算单价.Click += new System.EventHandler(this.btn设置入库单价_Click);
            // 
            // colName
            // 
            this.colName.HeaderText = "名称";
            this.colName.MinimumWidth = 150;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 150;
            // 
            // colPrice
            // 
            dataGridViewCellStyle1.Format = "C2";
            this.colPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPrice.HeaderText = "单价";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colWithTax
            // 
            this.colWithTax.HeaderText = "含税";
            this.colWithTax.Name = "colWithTax";
            this.colWithTax.ReadOnly = true;
            this.colWithTax.Width = 60;
            // 
            // col供应商
            // 
            this.col供应商.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col供应商.HeaderText = "供应商";
            this.col供应商.Name = "col供应商";
            this.col供应商.ReadOnly = true;
            this.col供应商.Width = 66;
            // 
            // col操作员
            // 
            this.col操作员.HeaderText = "操作员";
            this.col操作员.Name = "col操作员";
            this.col操作员.ReadOnly = true;
            this.col操作员.Width = 80;
            // 
            // colMemo
            // 
            this.colMemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            this.colMemo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Frm成本明细
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 327);
            this.Controls.Add(this.btn设置其它成本);
            this.Controls.Add(this.btn设置结算单价);
            this.Controls.Add(this.GridView);
            this.Name = "Frm成本明细";
            this.Text = "成本明细";
            this.Controls.SetChildIndex(this.GridView, 0);
            this.Controls.SetChildIndex(this.btn设置结算单价, 0);
            this.Controls.SetChildIndex(this.btn设置其它成本, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.Button btn设置其它成本;
        private System.Windows.Forms.Button btn设置结算单价;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colWithTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn col供应商;
        private System.Windows.Forms.DataGridViewTextBoxColumn col操作员;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
    }
}