namespace LJH.Inventory.UI.Forms.Inventory.Report
{
    partial class FrmInventoryRecordReport
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLength = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtWeight = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.cmbSpecification = new LJH.Inventory.UI.Controls.UCSpecification();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProductCategory = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkProductCategory = new System.Windows.Forms.LinkLabel();
            this.lnkCustomer = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucDateTimeInterval1 = new LJH.GeneralLibrary.WinformControl.UCDateTimeInterval();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.colAddDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriginalWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchaseTax = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTransCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOtherCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(839, 12);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(839, 41);
            // 
            // btnColumn
            // 
            this.btnColumn.Location = new System.Drawing.Point(839, 70);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtLength);
            this.groupBox3.Controls.Add(this.txtWeight);
            this.groupBox3.Controls.Add(this.cmbSpecification);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtProductCategory);
            this.groupBox3.Controls.Add(this.txtCustomer);
            this.groupBox3.Controls.Add(this.lnkProductCategory);
            this.groupBox3.Controls.Add(this.lnkCustomer);
            this.groupBox3.Location = new System.Drawing.Point(244, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(574, 90);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其它";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 97;
            this.label4.Text = "小件长度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 96;
            this.label3.Text = "重量";
            // 
            // txtLength
            // 
            this.txtLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLength.Location = new System.Drawing.Point(457, 49);
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
            this.txtLength.Size = new System.Drawing.Size(100, 21);
            this.txtLength.TabIndex = 95;
            this.txtLength.Text = "0";
            // 
            // txtWeight
            // 
            this.txtWeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWeight.Location = new System.Drawing.Point(457, 18);
            this.txtWeight.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtWeight.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.PointCount = 3;
            this.txtWeight.Size = new System.Drawing.Size(100, 21);
            this.txtWeight.TabIndex = 94;
            this.txtWeight.Text = "0";
            // 
            // cmbSpecification
            // 
            this.cmbSpecification.Location = new System.Drawing.Point(246, 15);
            this.cmbSpecification.Name = "cmbSpecification";
            this.cmbSpecification.Size = new System.Drawing.Size(158, 26);
            this.cmbSpecification.Specification = "*";
            this.cmbSpecification.TabIndex = 89;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 88;
            this.label5.Text = "规格";
            // 
            // txtProductCategory
            // 
            this.txtProductCategory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtProductCategory.Location = new System.Drawing.Point(53, 49);
            this.txtProductCategory.Name = "txtProductCategory";
            this.txtProductCategory.ReadOnly = true;
            this.txtProductCategory.Size = new System.Drawing.Size(153, 21);
            this.txtProductCategory.TabIndex = 39;
            this.txtProductCategory.DoubleClick += new System.EventHandler(this.txtProductCategory_DoubleClick);
            // 
            // txtCustomer
            // 
            this.txtCustomer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCustomer.Location = new System.Drawing.Point(53, 18);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(153, 21);
            this.txtCustomer.TabIndex = 37;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            // 
            // lnkProductCategory
            // 
            this.lnkProductCategory.AutoSize = true;
            this.lnkProductCategory.Location = new System.Drawing.Point(17, 53);
            this.lnkProductCategory.Name = "lnkProductCategory";
            this.lnkProductCategory.Size = new System.Drawing.Size(29, 12);
            this.lnkProductCategory.TabIndex = 36;
            this.lnkProductCategory.TabStop = true;
            this.lnkProductCategory.Text = "类别";
            this.lnkProductCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProductCategory_LinkClicked);
            // 
            // lnkCustomer
            // 
            this.lnkCustomer.AutoSize = true;
            this.lnkCustomer.Location = new System.Drawing.Point(7, 22);
            this.lnkCustomer.Name = "lnkCustomer";
            this.lnkCustomer.Size = new System.Drawing.Size(41, 12);
            this.lnkCustomer.TabIndex = 33;
            this.lnkCustomer.TabStop = true;
            this.lnkCustomer.Text = "供应商";
            this.lnkCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomer_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucDateTimeInterval1);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 90);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "入库日期";
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
            this.colAddDate,
            this.colCategoryID,
            this.colModel,
            this.colThick,
            this.colWidth,
            this.colOriginalWeight,
            this.colLength,
            this.colCount,
            this.colPurchasePrice,
            this.colPurchaseTax,
            this.colTransCost,
            this.colOtherCost,
            this.colSupplier,
            this.colCustomer,
            this.colManufacturer});
            this.gridView.Location = new System.Drawing.Point(4, 100);
            this.gridView.Name = "gridView";
            this.gridView.RowHeadersVisible = false;
            this.gridView.RowTemplate.Height = 23;
            this.gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridView.Size = new System.Drawing.Size(1296, 348);
            this.gridView.TabIndex = 39;
            // 
            // colAddDate
            // 
            this.colAddDate.HeaderText = "入库日期";
            this.colAddDate.Name = "colAddDate";
            this.colAddDate.ReadOnly = true;
            this.colAddDate.Width = 130;
            // 
            // colCategoryID
            // 
            this.colCategoryID.HeaderText = "类别";
            this.colCategoryID.Name = "colCategoryID";
            this.colCategoryID.ReadOnly = true;
            this.colCategoryID.Width = 80;
            // 
            // colModel
            // 
            this.colModel.HeaderText = "型号";
            this.colModel.Name = "colModel";
            this.colModel.ReadOnly = true;
            this.colModel.Width = 80;
            // 
            // colThick
            // 
            this.colThick.HeaderText = "规格厚度";
            this.colThick.Name = "colThick";
            this.colThick.ReadOnly = true;
            // 
            // colWidth
            // 
            this.colWidth.HeaderText = "规格宽度";
            this.colWidth.Name = "colWidth";
            this.colWidth.ReadOnly = true;
            // 
            // colOriginalWeight
            // 
            dataGridViewCellStyle1.Format = "N3";
            this.colOriginalWeight.DefaultCellStyle = dataGridViewCellStyle1;
            this.colOriginalWeight.HeaderText = "重量";
            this.colOriginalWeight.Name = "colOriginalWeight";
            this.colOriginalWeight.ReadOnly = true;
            this.colOriginalWeight.Width = 80;
            // 
            // colLength
            // 
            dataGridViewCellStyle2.Format = "N3";
            this.colLength.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLength.HeaderText = "长度";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.Width = 80;
            // 
            // colCount
            // 
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.colCount.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCount.HeaderText = "数量";
            this.colCount.Name = "colCount";
            this.colCount.ReadOnly = true;
            this.colCount.Width = 80;
            // 
            // colPurchasePrice
            // 
            dataGridViewCellStyle4.Format = "C2";
            this.colPurchasePrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.colPurchasePrice.HeaderText = "吨价";
            this.colPurchasePrice.Name = "colPurchasePrice";
            this.colPurchasePrice.ReadOnly = true;
            this.colPurchasePrice.Width = 80;
            // 
            // colPurchaseTax
            // 
            this.colPurchaseTax.HeaderText = "含税";
            this.colPurchaseTax.Name = "colPurchaseTax";
            this.colPurchaseTax.ReadOnly = true;
            this.colPurchaseTax.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPurchaseTax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colPurchaseTax.Width = 60;
            // 
            // colTransCost
            // 
            dataGridViewCellStyle5.Format = "C2";
            this.colTransCost.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTransCost.HeaderText = "运费(/t)";
            this.colTransCost.Name = "colTransCost";
            this.colTransCost.ReadOnly = true;
            this.colTransCost.Width = 80;
            // 
            // colOtherCost
            // 
            dataGridViewCellStyle6.Format = "C2";
            this.colOtherCost.DefaultCellStyle = dataGridViewCellStyle6;
            this.colOtherCost.HeaderText = "其它(/t)";
            this.colOtherCost.Name = "colOtherCost";
            this.colOtherCost.ReadOnly = true;
            this.colOtherCost.Width = 80;
            // 
            // colSupplier
            // 
            this.colSupplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSupplier.HeaderText = "供应商";
            this.colSupplier.MinimumWidth = 150;
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.ReadOnly = true;
            this.colSupplier.Width = 150;
            // 
            // colCustomer
            // 
            this.colCustomer.HeaderText = "客户";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            // 
            // colManufacturer
            // 
            this.colManufacturer.HeaderText = "厂家";
            this.colManufacturer.Name = "colManufacturer";
            this.colManufacturer.ReadOnly = true;
            // 
            // FrmInventoryRecordReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 473);
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmInventoryRecordReport";
            this.Text = "入库记录报表";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.gridView, 0);
            this.Controls.SetChildIndex(this.btnColumn, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnSaveAs, 0);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private GeneralLibrary.WinformControl.DBCTextBox txtProductCategory;
        private GeneralLibrary.WinformControl.DBCTextBox txtCustomer;
        private System.Windows.Forms.LinkLabel lnkProductCategory;
        private System.Windows.Forms.LinkLabel lnkCustomer;
        private System.Windows.Forms.GroupBox groupBox1;
        private GeneralLibrary.WinformControl.UCDateTimeInterval ucDateTimeInterval1;
        private System.Windows.Forms.DataGridView gridView;
        private Controls.UCSpecification cmbSpecification;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private GeneralLibrary.WinformControl.DecimalTextBox txtLength;
        private GeneralLibrary.WinformControl.DecimalTextBox txtWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThick;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriginalWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchasePrice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPurchaseTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOtherCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacturer;
    }
}