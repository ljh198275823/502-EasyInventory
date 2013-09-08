namespace LJH.Inventory.UI.Forms.Report
{
    partial class FrmDeliveryRecordReport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSalesPerson = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.productComboBox1 = new LJH.Inventory.UI.Controls.ProductComboBox(this.components);
            this.categoryComboBox1 = new LJH.Inventory.UI.Controls.CategoryComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.customerCombobox1 = new LJH.Inventory.UI.Controls.CustomerCombobox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucDateTimeInterval1 = new LJH.GeneralLibrary.WinformControl.UCDateTimeInterval();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.colDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSheetNo = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProfitRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalesPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(649, 14);
            // 
            // btnOkAs
            // 
            this.btnOkAs.Location = new System.Drawing.Point(649, 43);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 96);
            this.panel1.TabIndex = 25;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSalesPerson);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.productComboBox1);
            this.groupBox3.Controls.Add(this.categoryComboBox1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.customerCombobox1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(240, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(403, 90);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其它";
            // 
            // txtSalesPerson
            // 
            this.txtSalesPerson.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSalesPerson.Location = new System.Drawing.Point(243, 17);
            this.txtSalesPerson.Name = "txtSalesPerson";
            this.txtSalesPerson.Size = new System.Drawing.Size(145, 21);
            this.txtSalesPerson.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "业务";
            // 
            // productComboBox1
            // 
            this.productComboBox1.FormattingEnabled = true;
            this.productComboBox1.Location = new System.Drawing.Point(243, 43);
            this.productComboBox1.Name = "productComboBox1";
            this.productComboBox1.Size = new System.Drawing.Size(145, 20);
            this.productComboBox1.TabIndex = 30;
            // 
            // categoryComboBox1
            // 
            this.categoryComboBox1.FormattingEnabled = true;
            this.categoryComboBox1.Location = new System.Drawing.Point(48, 42);
            this.categoryComboBox1.Name = "categoryComboBox1";
            this.categoryComboBox1.Size = new System.Drawing.Size(145, 20);
            this.categoryComboBox1.TabIndex = 29;
            this.categoryComboBox1.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "类别";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "商品";
            // 
            // customerCombobox1
            // 
            this.customerCombobox1.FormattingEnabled = true;
            this.customerCombobox1.Location = new System.Drawing.Point(48, 16);
            this.customerCombobox1.Name = "customerCombobox1";
            this.customerCombobox1.Size = new System.Drawing.Size(145, 20);
            this.customerCombobox1.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "客户";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucDateTimeInterval1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 90);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "出货日期";
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
            // gridView
            // 
            this.gridView.AllowUserToAddRows = false;
            this.gridView.AllowUserToDeleteRows = false;
            this.gridView.AllowUserToResizeColumns = false;
            this.gridView.AllowUserToResizeRows = false;
            this.gridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridView.BackgroundColor = System.Drawing.Color.White;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeliveryDate,
            this.colSheetNo,
            this.colCustomerName,
            this.colProductID,
            this.colProductName,
            this.colCategoryID,
            this.colPrice,
            this.colCount,
            this.colAmount,
            this.colCost,
            this.colProfitRate,
            this.colSalesPerson});
            this.gridView.Location = new System.Drawing.Point(0, 102);
            this.gridView.Name = "gridView";
            this.gridView.RowHeadersVisible = false;
            this.gridView.RowTemplate.Height = 23;
            this.gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridView.Size = new System.Drawing.Size(980, 292);
            this.gridView.TabIndex = 26;
            this.gridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_CellContentClick);
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.HeaderText = "出货日期";
            this.colDeliveryDate.Name = "colDeliveryDate";
            this.colDeliveryDate.ReadOnly = true;
            this.colDeliveryDate.Width = 130;
            // 
            // colSheetNo
            // 
            this.colSheetNo.HeaderText = "送货单";
            this.colSheetNo.Name = "colSheetNo";
            this.colSheetNo.ReadOnly = true;
            this.colSheetNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSheetNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colCustomerName
            // 
            this.colCustomerName.HeaderText = "客户";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            this.colCustomerName.Width = 140;
            // 
            // colProductID
            // 
            this.colProductID.HeaderText = "商品编号";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            // 
            // colProductName
            // 
            this.colProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colProductName.HeaderText = "商品名称";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 78;
            // 
            // colCategoryID
            // 
            this.colCategoryID.HeaderText = "商品类别";
            this.colCategoryID.Name = "colCategoryID";
            this.colCategoryID.ReadOnly = true;
            // 
            // colPrice
            // 
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.colPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPrice.HeaderText = "单价";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colCount
            // 
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.colCount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCount.HeaderText = "数量";
            this.colCount.Name = "colCount";
            this.colCount.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "出货金额";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colCost
            // 
            this.colCost.HeaderText = "出货成本";
            this.colCost.Name = "colCost";
            this.colCost.ReadOnly = true;
            // 
            // colProfitRate
            // 
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.colProfitRate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colProfitRate.HeaderText = "毛利率";
            this.colProfitRate.Name = "colProfitRate";
            this.colProfitRate.ReadOnly = true;
            // 
            // colSalesPerson
            // 
            this.colSalesPerson.HeaderText = "业务";
            this.colSalesPerson.Name = "colSalesPerson";
            this.colSalesPerson.ReadOnly = true;
            // 
            // FrmDeliveryRecordReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 416);
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDeliveryRecordReport";
            this.Text = "出货记录报表";
            this.Load += new System.EventHandler(this.FrmDeliveryRecordReport_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gridView, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnOkAs, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private LJH.GeneralLibrary.WinformControl.UCDateTimeInterval ucDateTimeInterval1;
        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.GroupBox groupBox3;
        private Controls.CustomerCombobox customerCombobox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private Controls.CategoryComboBox categoryComboBox1;
        private System.Windows.Forms.Label label2;
        private Controls.ProductComboBox productComboBox1;
        private GeneralLibrary.WinformControl.DBCTextBox txtSalesPerson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryDate;
        private System.Windows.Forms.DataGridViewLinkColumn colSheetNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProfitRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalesPerson;
    }
}