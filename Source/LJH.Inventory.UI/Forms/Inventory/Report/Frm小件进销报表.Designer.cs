namespace LJH.Inventory.UI.Forms.Inventory.Report
{
    partial class Frm小件进销报表
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucDateTimeInterval1 = new LJH.GeneralLibrary.WinformControl.UCDateTimeInterval();
            this.lblTotalIn = new System.Windows.Forms.Label();
            this.lblTotalOut = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLength = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtCategory = new LJH.Inventory.UI.Controls.CategoryComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSpecification = new LJH.Inventory.UI.Controls.SpecificationComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.colSheetDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSheetID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col客户 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col进货 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col出货 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col余数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col来源卷 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col操作员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(479, 13);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(479, 42);
            // 
            // btnColumn
            // 
            this.btnColumn.Location = new System.Drawing.Point(479, 71);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSheetDate,
            this.colSheetID,
            this.col客户,
            this.col进货,
            this.col出货,
            this.col余数,
            this.col来源卷,
            this.colMemo,
            this.col操作员});
            this.dataGridView1.Location = new System.Drawing.Point(7, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(999, 328);
            this.dataGridView1.TabIndex = 42;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucDateTimeInterval1);
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 90);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日期";
            // 
            // ucDateTimeInterval1
            // 
            this.ucDateTimeInterval1.EndDateTime = new System.DateTime(2012, 6, 2, 10, 42, 8, 482);
            this.ucDateTimeInterval1.Location = new System.Drawing.Point(4, 14);
            this.ucDateTimeInterval1.Name = "ucDateTimeInterval1";
            this.ucDateTimeInterval1.ShowTime = false;
            this.ucDateTimeInterval1.Size = new System.Drawing.Size(221, 74);
            this.ucDateTimeInterval1.StartDateTime = new System.DateTime(2012, 6, 2, 10, 42, 8, 482);
            this.ucDateTimeInterval1.TabIndex = 1;
            // 
            // lblTotalIn
            // 
            this.lblTotalIn.AutoSize = true;
            this.lblTotalIn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalIn.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalIn.Location = new System.Drawing.Point(637, 28);
            this.lblTotalIn.Name = "lblTotalIn";
            this.lblTotalIn.Size = new System.Drawing.Size(20, 20);
            this.lblTotalIn.TabIndex = 98;
            this.lblTotalIn.Text = "0";
            this.lblTotalIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalOut
            // 
            this.lblTotalOut.AutoSize = true;
            this.lblTotalOut.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalOut.ForeColor = System.Drawing.Color.Red;
            this.lblTotalOut.Location = new System.Drawing.Point(637, 64);
            this.lblTotalOut.Name = "lblTotalOut";
            this.lblTotalOut.Size = new System.Drawing.Size(20, 20);
            this.lblTotalOut.TabIndex = 97;
            this.lblTotalOut.Text = "0";
            this.lblTotalOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 106;
            this.label2.Text = "长度";
            // 
            // txtLength
            // 
            this.txtLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLength.Location = new System.Drawing.Point(292, 74);
            this.txtLength.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtLength.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLength.Name = "txtLength";
            this.txtLength.PointCount = 3;
            this.txtLength.Size = new System.Drawing.Size(165, 21);
            this.txtLength.TabIndex = 105;
            this.txtLength.Text = "0";
            // 
            // txtCategory
            // 
            this.txtCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCategory.FormattingEnabled = true;
            this.txtCategory.Location = new System.Drawing.Point(292, 16);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(165, 20);
            this.txtCategory.TabIndex = 104;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 103;
            this.label1.Text = "类别";
            // 
            // cmbSpecification
            // 
            this.cmbSpecification.FormattingEnabled = true;
            this.cmbSpecification.Location = new System.Drawing.Point(292, 45);
            this.cmbSpecification.Name = "cmbSpecification";
            this.cmbSpecification.Size = new System.Drawing.Size(165, 20);
            this.cmbSpecification.TabIndex = 102;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 101;
            this.label5.Text = "规格";
            // 
            // colSheetDate
            // 
            dataGridViewCellStyle1.Format = "D";
            dataGridViewCellStyle1.NullValue = null;
            this.colSheetDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colSheetDate.HeaderText = "日期";
            this.colSheetDate.Name = "colSheetDate";
            this.colSheetDate.ReadOnly = true;
            this.colSheetDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colSheetID
            // 
            this.colSheetID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSheetID.HeaderText = "单据编号";
            this.colSheetID.MinimumWidth = 120;
            this.colSheetID.Name = "colSheetID";
            this.colSheetID.ReadOnly = true;
            this.colSheetID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSheetID.Width = 120;
            // 
            // col客户
            // 
            this.col客户.HeaderText = "客户";
            this.col客户.Name = "col客户";
            this.col客户.ReadOnly = true;
            this.col客户.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col客户.Width = 250;
            // 
            // col进货
            // 
            this.col进货.HeaderText = "进货";
            this.col进货.Name = "col进货";
            this.col进货.ReadOnly = true;
            this.col进货.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col出货
            // 
            this.col出货.HeaderText = "出货";
            this.col出货.Name = "col出货";
            this.col出货.ReadOnly = true;
            this.col出货.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col出货.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col出货.Width = 120;
            // 
            // col余数
            // 
            this.col余数.HeaderText = "余数";
            this.col余数.Name = "col余数";
            this.col余数.ReadOnly = true;
            this.col余数.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col余数.Visible = false;
            this.col余数.Width = 120;
            // 
            // col来源卷
            // 
            this.col来源卷.HeaderText = "来源卷";
            this.col来源卷.Name = "col来源卷";
            this.col来源卷.ReadOnly = true;
            this.col来源卷.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col来源卷.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMemo
            // 
            this.colMemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMemo.HeaderText = "备注";
            this.colMemo.MinimumWidth = 100;
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            this.colMemo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col操作员
            // 
            this.col操作员.HeaderText = "操作员";
            this.col操作员.Name = "col操作员";
            this.col操作员.ReadOnly = true;
            this.col操作员.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Frm小件进销报表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 456);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSpecification);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTotalIn);
            this.Controls.Add(this.lblTotalOut);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Frm小件进销报表";
            this.Text = "小件进销报表";
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnSaveAs, 0);
            this.Controls.SetChildIndex(this.btnColumn, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblTotalOut, 0);
            this.Controls.SetChildIndex(this.lblTotalIn, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cmbSpecification, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtCategory, 0);
            this.Controls.SetChildIndex(this.txtLength, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private GeneralLibrary.WinformControl.UCDateTimeInterval ucDateTimeInterval1;
        private System.Windows.Forms.Label lblTotalIn;
        private System.Windows.Forms.Label lblTotalOut;
        private System.Windows.Forms.Label label2;
        private GeneralLibrary.WinformControl.DecimalTextBox txtLength;
        private Controls.CategoryComboBox txtCategory;
        private System.Windows.Forms.Label label1;
        private Controls.SpecificationComboBox cmbSpecification;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSheetDate;
        private System.Windows.Forms.DataGridViewLinkColumn colSheetID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col客户;
        private System.Windows.Forms.DataGridViewTextBoxColumn col进货;
        private System.Windows.Forms.DataGridViewTextBoxColumn col出货;
        private System.Windows.Forms.DataGridViewTextBoxColumn col余数;
        private System.Windows.Forms.DataGridViewTextBoxColumn col来源卷;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col操作员;
    }
}