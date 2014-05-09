namespace LJH.Inventory.UI.Report
{
    partial class FrmDeliveryStatistics
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucDateTimeInterval1 = new LJH.GeneralLibrary.WinformControl.UCDateTimeInterval();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdByCategory = new System.Windows.Forms.RadioButton();
            this.rdBySalesPerson = new System.Windows.Forms.RadioButton();
            this.rdByCustomer = new System.Windows.Forms.RadioButton();
            this.rdByProdcut = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdByYear = new System.Windows.Forms.RadioButton();
            this.rdByMonth = new System.Windows.Forms.RadioButton();
            this.rdByDay = new System.Windows.Forms.RadioButton();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtProductCategory = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtProduct = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkProductCategory = new System.Windows.Forms.LinkLabel();
            this.lnkProduct = new System.Windows.Forms.LinkLabel();
            this.lnkCustomer = new System.Windows.Forms.LinkLabel();
            this.colDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProfitRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(991, 17);
            // 
            // btnOkAs
            // 
            this.btnOkAs.Location = new System.Drawing.Point(991, 46);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucDateTimeInterval1);
            this.groupBox1.Location = new System.Drawing.Point(6, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 96);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计日期";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdByCategory);
            this.groupBox2.Controls.Add(this.rdBySalesPerson);
            this.groupBox2.Controls.Add(this.rdByCustomer);
            this.groupBox2.Controls.Add(this.rdByProdcut);
            this.groupBox2.Location = new System.Drawing.Point(652, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 45);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计方式";
            // 
            // rdByCategory
            // 
            this.rdByCategory.AutoSize = true;
            this.rdByCategory.Location = new System.Drawing.Point(245, 21);
            this.rdByCategory.Name = "rdByCategory";
            this.rdByCategory.Size = new System.Drawing.Size(83, 16);
            this.rdByCategory.TabIndex = 3;
            this.rdByCategory.Text = "按商品类别";
            this.rdByCategory.UseVisualStyleBackColor = true;
            // 
            // rdBySalesPerson
            // 
            this.rdBySalesPerson.AutoSize = true;
            this.rdBySalesPerson.Location = new System.Drawing.Point(163, 21);
            this.rdBySalesPerson.Name = "rdBySalesPerson";
            this.rdBySalesPerson.Size = new System.Drawing.Size(71, 16);
            this.rdBySalesPerson.TabIndex = 2;
            this.rdBySalesPerson.Text = "按业务员";
            this.rdBySalesPerson.UseVisualStyleBackColor = true;
            // 
            // rdByCustomer
            // 
            this.rdByCustomer.AutoSize = true;
            this.rdByCustomer.Location = new System.Drawing.Point(90, 21);
            this.rdByCustomer.Name = "rdByCustomer";
            this.rdByCustomer.Size = new System.Drawing.Size(59, 16);
            this.rdByCustomer.TabIndex = 1;
            this.rdByCustomer.Text = "按客户";
            this.rdByCustomer.UseVisualStyleBackColor = true;
            // 
            // rdByProdcut
            // 
            this.rdByProdcut.AutoSize = true;
            this.rdByProdcut.Checked = true;
            this.rdByProdcut.Location = new System.Drawing.Point(18, 21);
            this.rdByProdcut.Name = "rdByProdcut";
            this.rdByProdcut.Size = new System.Drawing.Size(59, 16);
            this.rdByProdcut.TabIndex = 0;
            this.rdByProdcut.TabStop = true;
            this.rdByProdcut.Text = "按商品";
            this.rdByProdcut.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdByYear);
            this.groupBox3.Controls.Add(this.rdByMonth);
            this.groupBox3.Controls.Add(this.rdByDay);
            this.groupBox3.Location = new System.Drawing.Point(652, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(221, 45);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "统计间隔";
            // 
            // rdByYear
            // 
            this.rdByYear.AutoSize = true;
            this.rdByYear.Location = new System.Drawing.Point(163, 21);
            this.rdByYear.Name = "rdByYear";
            this.rdByYear.Size = new System.Drawing.Size(47, 16);
            this.rdByYear.TabIndex = 4;
            this.rdByYear.Text = "按年";
            this.rdByYear.UseVisualStyleBackColor = true;
            // 
            // rdByMonth
            // 
            this.rdByMonth.AutoSize = true;
            this.rdByMonth.Location = new System.Drawing.Point(90, 21);
            this.rdByMonth.Name = "rdByMonth";
            this.rdByMonth.Size = new System.Drawing.Size(47, 16);
            this.rdByMonth.TabIndex = 3;
            this.rdByMonth.Text = "按月";
            this.rdByMonth.UseVisualStyleBackColor = true;
            // 
            // rdByDay
            // 
            this.rdByDay.AutoSize = true;
            this.rdByDay.Checked = true;
            this.rdByDay.Location = new System.Drawing.Point(18, 21);
            this.rdByDay.Name = "rdByDay";
            this.rdByDay.Size = new System.Drawing.Size(47, 16);
            this.rdByDay.TabIndex = 0;
            this.rdByDay.TabStop = true;
            this.rdByDay.Text = "按天";
            this.rdByDay.UseVisualStyleBackColor = true;
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
            this.colName,
            this.colCount,
            this.colAmount,
            this.colCost,
            this.colProfit,
            this.colProfitRate,
            this.colFill});
            this.gridView.Location = new System.Drawing.Point(4, 108);
            this.gridView.Name = "gridView";
            this.gridView.RowHeadersVisible = false;
            this.gridView.RowTemplate.Height = 23;
            this.gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridView.Size = new System.Drawing.Size(1122, 236);
            this.gridView.TabIndex = 27;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtProductCategory);
            this.groupBox4.Controls.Add(this.txtProduct);
            this.groupBox4.Controls.Add(this.txtCustomer);
            this.groupBox4.Controls.Add(this.lnkProductCategory);
            this.groupBox4.Controls.Add(this.lnkProduct);
            this.groupBox4.Controls.Add(this.lnkCustomer);
            this.groupBox4.Location = new System.Drawing.Point(245, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(401, 96);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "其它";
            // 
            // txtProductCategory
            // 
            this.txtProductCategory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtProductCategory.Location = new System.Drawing.Point(42, 48);
            this.txtProductCategory.Name = "txtProductCategory";
            this.txtProductCategory.ReadOnly = true;
            this.txtProductCategory.Size = new System.Drawing.Size(153, 21);
            this.txtProductCategory.TabIndex = 45;
            this.txtProductCategory.DoubleClick += new System.EventHandler(this.txtProductCategory_DoubleClick);
            // 
            // txtProduct
            // 
            this.txtProduct.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtProduct.Location = new System.Drawing.Point(236, 19);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.ReadOnly = true;
            this.txtProduct.Size = new System.Drawing.Size(153, 21);
            this.txtProduct.TabIndex = 44;
            this.txtProduct.DoubleClick += new System.EventHandler(this.txtProduct_DoubleClick);
            // 
            // txtCustomer
            // 
            this.txtCustomer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCustomer.Location = new System.Drawing.Point(42, 19);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(153, 21);
            this.txtCustomer.TabIndex = 43;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            // 
            // lnkProductCategory
            // 
            this.lnkProductCategory.AutoSize = true;
            this.lnkProductCategory.Location = new System.Drawing.Point(6, 52);
            this.lnkProductCategory.Name = "lnkProductCategory";
            this.lnkProductCategory.Size = new System.Drawing.Size(29, 12);
            this.lnkProductCategory.TabIndex = 42;
            this.lnkProductCategory.TabStop = true;
            this.lnkProductCategory.Text = "类别";
            this.lnkProductCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProductCategory_LinkClicked);
            // 
            // lnkProduct
            // 
            this.lnkProduct.AutoSize = true;
            this.lnkProduct.Location = new System.Drawing.Point(201, 23);
            this.lnkProduct.Name = "lnkProduct";
            this.lnkProduct.Size = new System.Drawing.Size(29, 12);
            this.lnkProduct.TabIndex = 41;
            this.lnkProduct.TabStop = true;
            this.lnkProduct.Text = "产品";
            this.lnkProduct.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProduct_LinkClicked);
            // 
            // lnkCustomer
            // 
            this.lnkCustomer.AutoSize = true;
            this.lnkCustomer.Location = new System.Drawing.Point(6, 23);
            this.lnkCustomer.Name = "lnkCustomer";
            this.lnkCustomer.Size = new System.Drawing.Size(29, 12);
            this.lnkCustomer.TabIndex = 40;
            this.lnkCustomer.TabStop = true;
            this.lnkCustomer.Text = "客户";
            this.lnkCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomer_LinkClicked);
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.HeaderText = "统计日期";
            this.colDeliveryDate.Name = "colDeliveryDate";
            this.colDeliveryDate.ReadOnly = true;
            this.colDeliveryDate.Width = 130;
            // 
            // colName
            // 
            this.colName.HeaderText = "名称";
            this.colName.MinimumWidth = 150;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 150;
            // 
            // colCount
            // 
            this.colCount.HeaderText = "数量";
            this.colCount.Name = "colCount";
            this.colCount.ReadOnly = true;
            // 
            // colAmount
            // 
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.colAmount.HeaderText = "销售收入";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colCost
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.colCost.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCost.HeaderText = "销售成本";
            this.colCost.Name = "colCost";
            this.colCost.ReadOnly = true;
            // 
            // colProfit
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.colProfit.DefaultCellStyle = dataGridViewCellStyle3;
            this.colProfit.HeaderText = "利润";
            this.colProfit.Name = "colProfit";
            this.colProfit.ReadOnly = true;
            // 
            // colProfitRate
            // 
            this.colProfitRate.HeaderText = "利润率";
            this.colProfitRate.Name = "colProfitRate";
            this.colProfitRate.ReadOnly = true;
            // 
            // colFill
            // 
            this.colFill.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFill.HeaderText = "";
            this.colFill.Name = "colFill";
            this.colFill.ReadOnly = true;
            this.colFill.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmDeliveryStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 368);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmDeliveryStatistics";
            this.Text = "出货统计";
            this.Load += new System.EventHandler(this.FrmDeliveryStatistics_Load);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnOkAs, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.gridView, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private GeneralLibrary.WinformControl.UCDateTimeInterval ucDateTimeInterval1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdByCategory;
        private System.Windows.Forms.RadioButton rdBySalesPerson;
        private System.Windows.Forms.RadioButton rdByCustomer;
        private System.Windows.Forms.RadioButton rdByProdcut;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdByDay;
        private System.Windows.Forms.RadioButton rdByYear;
        private System.Windows.Forms.RadioButton rdByMonth;
        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.GroupBox groupBox4;
        private GeneralLibrary.WinformControl.DBCTextBox txtProductCategory;
        private GeneralLibrary.WinformControl.DBCTextBox txtProduct;
        private GeneralLibrary.WinformControl.DBCTextBox txtCustomer;
        private System.Windows.Forms.LinkLabel lnkProductCategory;
        private System.Windows.Forms.LinkLabel lnkProduct;
        private System.Windows.Forms.LinkLabel lnkCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProfitRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFill;
    }
}