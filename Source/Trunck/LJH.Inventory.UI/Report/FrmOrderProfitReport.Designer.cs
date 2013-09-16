namespace LJH.Inventory.UI.Report
{
    partial class FrmOrderProfitReport
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
            this.gridView = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lnkSalesPerson = new System.Windows.Forms.LinkLabel();
            this.txtSalesPerson = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtFinalCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkFinalCustomer = new System.Windows.Forms.LinkLabel();
            this.txtCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkCustomer = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucDateTimeInterval1 = new LJH.GeneralLibrary.WinformControl.UCDateTimeInterval();
            this.colOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFinalCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrencyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExchangeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocalMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpanditure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalesPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(574, 12);
            // 
            // btnOkAs
            // 
            this.btnOkAs.Location = new System.Drawing.Point(574, 41);
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
            this.colOrderDate,
            this.colOrderID,
            this.colCustomer,
            this.colFinalCustomer,
            this.colCurrencyType,
            this.colAmount,
            this.colExchangeRate,
            this.colLocalMoney,
            this.colPurchase,
            this.colExpanditure,
            this.colProfit,
            this.colSalesPerson});
            this.gridView.Location = new System.Drawing.Point(1, 109);
            this.gridView.Name = "gridView";
            this.gridView.RowHeadersVisible = false;
            this.gridView.RowTemplate.Height = 23;
            this.gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridView.Size = new System.Drawing.Size(1179, 220);
            this.gridView.TabIndex = 42;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lnkSalesPerson);
            this.groupBox3.Controls.Add(this.txtSalesPerson);
            this.groupBox3.Controls.Add(this.txtFinalCustomer);
            this.groupBox3.Controls.Add(this.lnkFinalCustomer);
            this.groupBox3.Controls.Add(this.txtCustomer);
            this.groupBox3.Controls.Add(this.lnkCustomer);
            this.groupBox3.Location = new System.Drawing.Point(241, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(323, 98);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其它";
            // 
            // lnkSalesPerson
            // 
            this.lnkSalesPerson.AutoSize = true;
            this.lnkSalesPerson.Location = new System.Drawing.Point(21, 69);
            this.lnkSalesPerson.Name = "lnkSalesPerson";
            this.lnkSalesPerson.Size = new System.Drawing.Size(47, 12);
            this.lnkSalesPerson.TabIndex = 128;
            this.lnkSalesPerson.TabStop = true;
            this.lnkSalesPerson.Text = "业务员:";
            // 
            // txtSalesPerson
            // 
            this.txtSalesPerson.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSalesPerson.Location = new System.Drawing.Point(69, 65);
            this.txtSalesPerson.Name = "txtSalesPerson";
            this.txtSalesPerson.Size = new System.Drawing.Size(100, 21);
            this.txtSalesPerson.TabIndex = 127;
            // 
            // txtFinalCustomer
            // 
            this.txtFinalCustomer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtFinalCustomer.Location = new System.Drawing.Point(70, 40);
            this.txtFinalCustomer.Name = "txtFinalCustomer";
            this.txtFinalCustomer.Size = new System.Drawing.Size(241, 21);
            this.txtFinalCustomer.TabIndex = 126;
            // 
            // lnkFinalCustomer
            // 
            this.lnkFinalCustomer.AutoSize = true;
            this.lnkFinalCustomer.Location = new System.Drawing.Point(9, 44);
            this.lnkFinalCustomer.Name = "lnkFinalCustomer";
            this.lnkFinalCustomer.Size = new System.Drawing.Size(59, 12);
            this.lnkFinalCustomer.TabIndex = 125;
            this.lnkFinalCustomer.TabStop = true;
            this.lnkFinalCustomer.Text = "最终客户:";
            // 
            // txtCustomer
            // 
            this.txtCustomer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCustomer.Location = new System.Drawing.Point(70, 15);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(241, 21);
            this.txtCustomer.TabIndex = 109;
            // 
            // lnkCustomer
            // 
            this.lnkCustomer.AutoSize = true;
            this.lnkCustomer.Location = new System.Drawing.Point(33, 18);
            this.lnkCustomer.Name = "lnkCustomer";
            this.lnkCustomer.Size = new System.Drawing.Size(35, 12);
            this.lnkCustomer.TabIndex = 108;
            this.lnkCustomer.TabStop = true;
            this.lnkCustomer.Text = "客户:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucDateTimeInterval1);
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 98);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "合同日期";
            // 
            // ucDateTimeInterval1
            // 
            this.ucDateTimeInterval1.EndDateTime = new System.DateTime(2012, 6, 2, 10, 42, 8, 482);
            this.ucDateTimeInterval1.Location = new System.Drawing.Point(4, 14);
            this.ucDateTimeInterval1.Name = "ucDateTimeInterval1";
            this.ucDateTimeInterval1.ShowTime = false;
            this.ucDateTimeInterval1.Size = new System.Drawing.Size(221, 78);
            this.ucDateTimeInterval1.StartDateTime = new System.DateTime(2012, 6, 2, 10, 42, 8, 482);
            this.ucDateTimeInterval1.TabIndex = 1;
            // 
            // colOrderDate
            // 
            this.colOrderDate.HeaderText = "合同日期";
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.ReadOnly = true;
            this.colOrderDate.Width = 130;
            // 
            // colOrderID
            // 
            this.colOrderID.HeaderText = "销售订单";
            this.colOrderID.Name = "colOrderID";
            this.colOrderID.ReadOnly = true;
            // 
            // colCustomer
            // 
            this.colCustomer.HeaderText = "客户";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.Width = 140;
            // 
            // colFinalCustomer
            // 
            this.colFinalCustomer.HeaderText = "最终客户";
            this.colFinalCustomer.Name = "colFinalCustomer";
            this.colFinalCustomer.ReadOnly = true;
            // 
            // colCurrencyType
            // 
            this.colCurrencyType.HeaderText = "币别";
            this.colCurrencyType.Name = "colCurrencyType";
            this.colCurrencyType.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "合同金额";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colExchangeRate
            // 
            this.colExchangeRate.HeaderText = "汇率";
            this.colExchangeRate.Name = "colExchangeRate";
            this.colExchangeRate.ReadOnly = true;
            // 
            // colLocalMoney
            // 
            this.colLocalMoney.HeaderText = "合同金额";
            this.colLocalMoney.Name = "colLocalMoney";
            this.colLocalMoney.ReadOnly = true;
            // 
            // colPurchase
            // 
            this.colPurchase.HeaderText = "采购金额";
            this.colPurchase.Name = "colPurchase";
            this.colPurchase.ReadOnly = true;
            // 
            // colExpanditure
            // 
            this.colExpanditure.HeaderText = "其它费用";
            this.colExpanditure.Name = "colExpanditure";
            this.colExpanditure.ReadOnly = true;
            // 
            // colProfit
            // 
            this.colProfit.HeaderText = "毛利";
            this.colProfit.Name = "colProfit";
            this.colProfit.ReadOnly = true;
            // 
            // colSalesPerson
            // 
            this.colSalesPerson.HeaderText = "业务";
            this.colSalesPerson.Name = "colSalesPerson";
            this.colSalesPerson.ReadOnly = true;
            // 
            // FrmOrderProfitReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 354);
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmOrderProfitReport";
            this.Text = "销售订单毛利统计";
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnOkAs, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.gridView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel lnkSalesPerson;
        private GeneralLibrary.WinformControl.DBCTextBox txtSalesPerson;
        private GeneralLibrary.WinformControl.DBCTextBox txtFinalCustomer;
        private System.Windows.Forms.LinkLabel lnkFinalCustomer;
        private GeneralLibrary.WinformControl.DBCTextBox txtCustomer;
        private System.Windows.Forms.LinkLabel lnkCustomer;
        private System.Windows.Forms.GroupBox groupBox1;
        private GeneralLibrary.WinformControl.UCDateTimeInterval ucDateTimeInterval1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderDate;
        private System.Windows.Forms.DataGridViewLinkColumn colOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinalCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrencyType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExchangeRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocalMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchase;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpanditure;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalesPerson;
    }
}