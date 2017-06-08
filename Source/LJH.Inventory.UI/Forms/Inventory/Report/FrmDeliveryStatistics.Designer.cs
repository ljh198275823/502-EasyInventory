namespace LJH.Inventory.UI.Forms.Inventory.Report
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdByNone = new System.Windows.Forms.RadioButton();
            this.rdBySheet = new System.Windows.Forms.RadioButton();
            this.rdByCustomer = new System.Windows.Forms.RadioButton();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col国税计提 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProfitRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkCustomer = new System.Windows.Forms.LinkLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ucDateTimeInterval1 = new LJH.GeneralLibrary.WinformControl.UCDateTimeInterval();
            this.lbl毛利 = new System.Windows.Forms.Label();
            this.lbl国税计提 = new System.Windows.Forms.Label();
            this.lbl产品成本 = new System.Windows.Forms.Label();
            this.lbl销售金额 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(542, 17);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(542, 46);
            // 
            // btnColumn
            // 
            this.btnColumn.Location = new System.Drawing.Point(542, 75);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdByNone);
            this.groupBox2.Controls.Add(this.rdBySheet);
            this.groupBox2.Controls.Add(this.rdByCustomer);
            this.groupBox2.Location = new System.Drawing.Point(267, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 43);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计方式";
            // 
            // rdByNone
            // 
            this.rdByNone.AutoSize = true;
            this.rdByNone.Location = new System.Drawing.Point(158, 21);
            this.rdByNone.Name = "rdByNone";
            this.rdByNone.Size = new System.Drawing.Size(47, 16);
            this.rdByNone.TabIndex = 5;
            this.rdByNone.Text = "合计";
            this.rdByNone.UseVisualStyleBackColor = true;
            // 
            // rdBySheet
            // 
            this.rdBySheet.AutoSize = true;
            this.rdBySheet.Checked = true;
            this.rdBySheet.Location = new System.Drawing.Point(13, 21);
            this.rdBySheet.Name = "rdBySheet";
            this.rdBySheet.Size = new System.Drawing.Size(71, 16);
            this.rdBySheet.TabIndex = 4;
            this.rdBySheet.TabStop = true;
            this.rdBySheet.Text = "按送货单";
            this.rdBySheet.UseVisualStyleBackColor = true;
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
            this.colName,
            this.colWeight,
            this.colAmount,
            this.colCost,
            this.col国税计提,
            this.colProfit,
            this.colProfitRate,
            this.colFill});
            this.gridView.Location = new System.Drawing.Point(4, 108);
            this.gridView.Name = "gridView";
            this.gridView.RowHeadersVisible = false;
            this.gridView.RowTemplate.Height = 23;
            this.gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridView.Size = new System.Drawing.Size(898, 392);
            this.gridView.TabIndex = 27;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colName.HeaderText = "名称";
            this.colName.MinimumWidth = 100;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colWeight
            // 
            dataGridViewCellStyle1.Format = "N3";
            this.colWeight.DefaultCellStyle = dataGridViewCellStyle1;
            this.colWeight.HeaderText = "重量";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAmount.HeaderText = "销售收入";
            this.colAmount.MinimumWidth = 120;
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 120;
            // 
            // colCost
            // 
            this.colCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.colCost.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCost.HeaderText = "销售成本";
            this.colCost.MinimumWidth = 120;
            this.colCost.Name = "colCost";
            this.colCost.ReadOnly = true;
            this.colCost.Width = 120;
            // 
            // col国税计提
            // 
            this.col国税计提.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle4.Format = "C2";
            this.col国税计提.DefaultCellStyle = dataGridViewCellStyle4;
            this.col国税计提.HeaderText = "国税计提";
            this.col国税计提.MinimumWidth = 120;
            this.col国税计提.Name = "col国税计提";
            this.col国税计提.ReadOnly = true;
            this.col国税计提.Width = 120;
            // 
            // colProfit
            // 
            this.colProfit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.colProfit.DefaultCellStyle = dataGridViewCellStyle5;
            this.colProfit.HeaderText = "毛利";
            this.colProfit.MinimumWidth = 120;
            this.colProfit.Name = "colProfit";
            this.colProfit.ReadOnly = true;
            this.colProfit.Width = 120;
            // 
            // colProfitRate
            // 
            this.colProfitRate.HeaderText = "毛利率";
            this.colProfitRate.MinimumWidth = 120;
            this.colProfitRate.Name = "colProfitRate";
            this.colProfitRate.ReadOnly = true;
            this.colProfitRate.Width = 120;
            // 
            // colFill
            // 
            this.colFill.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFill.HeaderText = "";
            this.colFill.Name = "colFill";
            this.colFill.ReadOnly = true;
            this.colFill.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtCustomer
            // 
            this.txtCustomer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCustomer.Location = new System.Drawing.Point(301, 17);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(198, 21);
            this.txtCustomer.TabIndex = 37;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            // 
            // lnkCustomer
            // 
            this.lnkCustomer.AutoSize = true;
            this.lnkCustomer.Location = new System.Drawing.Point(265, 21);
            this.lnkCustomer.Name = "lnkCustomer";
            this.lnkCustomer.Size = new System.Drawing.Size(29, 12);
            this.lnkCustomer.TabIndex = 33;
            this.lnkCustomer.TabStop = true;
            this.lnkCustomer.Text = "客户";
            this.lnkCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomer_LinkClicked);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ucDateTimeInterval1);
            this.groupBox4.Location = new System.Drawing.Point(7, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(231, 90);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "开单日期";
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
            // lbl毛利
            // 
            this.lbl毛利.AutoSize = true;
            this.lbl毛利.ForeColor = System.Drawing.Color.Blue;
            this.lbl毛利.Location = new System.Drawing.Point(682, 85);
            this.lbl毛利.Name = "lbl毛利";
            this.lbl毛利.Size = new System.Drawing.Size(11, 12);
            this.lbl毛利.TabIndex = 41;
            this.lbl毛利.Text = "0";
            // 
            // lbl国税计提
            // 
            this.lbl国税计提.AutoSize = true;
            this.lbl国税计提.ForeColor = System.Drawing.Color.Blue;
            this.lbl国税计提.Location = new System.Drawing.Point(682, 62);
            this.lbl国税计提.Name = "lbl国税计提";
            this.lbl国税计提.Size = new System.Drawing.Size(11, 12);
            this.lbl国税计提.TabIndex = 40;
            this.lbl国税计提.Text = "0";
            // 
            // lbl产品成本
            // 
            this.lbl产品成本.AutoSize = true;
            this.lbl产品成本.ForeColor = System.Drawing.Color.Blue;
            this.lbl产品成本.Location = new System.Drawing.Point(682, 39);
            this.lbl产品成本.Name = "lbl产品成本";
            this.lbl产品成本.Size = new System.Drawing.Size(11, 12);
            this.lbl产品成本.TabIndex = 39;
            this.lbl产品成本.Text = "0";
            // 
            // lbl销售金额
            // 
            this.lbl销售金额.AutoSize = true;
            this.lbl销售金额.ForeColor = System.Drawing.Color.Blue;
            this.lbl销售金额.Location = new System.Drawing.Point(682, 16);
            this.lbl销售金额.Name = "lbl销售金额";
            this.lbl销售金额.Size = new System.Drawing.Size(11, 12);
            this.lbl销售金额.TabIndex = 38;
            this.lbl销售金额.Text = "0";
            // 
            // FrmDeliveryStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 524);
            this.Controls.Add(this.lbl毛利);
            this.Controls.Add(this.lbl国税计提);
            this.Controls.Add(this.lbl产品成本);
            this.Controls.Add(this.lbl销售金额);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lnkCustomer);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmDeliveryStatistics";
            this.Text = "出货利润统计报表";
            this.Controls.SetChildIndex(this.btnColumn, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnSaveAs, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.gridView, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.lnkCustomer, 0);
            this.Controls.SetChildIndex(this.txtCustomer, 0);
            this.Controls.SetChildIndex(this.lbl销售金额, 0);
            this.Controls.SetChildIndex(this.lbl产品成本, 0);
            this.Controls.SetChildIndex(this.lbl国税计提, 0);
            this.Controls.SetChildIndex(this.lbl毛利, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdByCustomer;
        private System.Windows.Forms.DataGridView gridView;
        private GeneralLibrary.WinformControl.DBCTextBox txtCustomer;
        private System.Windows.Forms.LinkLabel lnkCustomer;
        private System.Windows.Forms.GroupBox groupBox4;
        private GeneralLibrary.WinformControl.UCDateTimeInterval ucDateTimeInterval1;
        private System.Windows.Forms.RadioButton rdByNone;
        private System.Windows.Forms.RadioButton rdBySheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn col国税计提;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProfitRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFill;
        private System.Windows.Forms.Label lbl毛利;
        private System.Windows.Forms.Label lbl国税计提;
        private System.Windows.Forms.Label lbl产品成本;
        private System.Windows.Forms.Label lbl销售金额;
    }
}