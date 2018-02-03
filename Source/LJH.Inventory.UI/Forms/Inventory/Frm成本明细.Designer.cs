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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GridView = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWithTax = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn设置其它成本 = new System.Windows.Forms.Button();
            this.btn设置入库单价 = new System.Windows.Forms.Button();
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
            this.Column1});
            this.GridView.Location = new System.Drawing.Point(0, 66);
            this.GridView.Name = "GridView";
            this.GridView.ReadOnly = true;
            this.GridView.RowHeadersVisible = false;
            this.GridView.RowTemplate.Height = 23;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView.Size = new System.Drawing.Size(422, 239);
            this.GridView.TabIndex = 23;
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
            dataGridViewCellStyle3.Format = "C2";
            this.colPrice.DefaultCellStyle = dataGridViewCellStyle3;
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
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btn设置其它成本
            // 
            this.btn设置其它成本.Location = new System.Drawing.Point(307, 14);
            this.btn设置其它成本.Name = "btn设置其它成本";
            this.btn设置其它成本.Size = new System.Drawing.Size(92, 37);
            this.btn设置其它成本.TabIndex = 159;
            this.btn设置其它成本.Text = "设置其它成本";
            this.btn设置其它成本.UseVisualStyleBackColor = true;
            this.btn设置其它成本.Click += new System.EventHandler(this.btn设置其它成本_Click);
            // 
            // btn设置入库单价
            // 
            this.btn设置入库单价.Location = new System.Drawing.Point(191, 14);
            this.btn设置入库单价.Name = "btn设置入库单价";
            this.btn设置入库单价.Size = new System.Drawing.Size(92, 37);
            this.btn设置入库单价.TabIndex = 158;
            this.btn设置入库单价.Text = "设置入库单价";
            this.btn设置入库单价.UseVisualStyleBackColor = true;
            this.btn设置入库单价.Click += new System.EventHandler(this.btn设置入库单价_Click);
            // 
            // Frm成本明细
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 327);
            this.Controls.Add(this.btn设置其它成本);
            this.Controls.Add(this.btn设置入库单价);
            this.Controls.Add(this.GridView);
            this.Name = "Frm成本明细";
            this.Text = "成本明细";
            this.Controls.SetChildIndex(this.GridView, 0);
            this.Controls.SetChildIndex(this.btn设置入库单价, 0);
            this.Controls.SetChildIndex(this.btn设置其它成本, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colWithTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button btn设置其它成本;
        private System.Windows.Forms.Button btn设置入库单价;
    }
}