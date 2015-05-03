namespace LJH.Inventory.UI.Forms
{
    partial class FrmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHome));
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.btnSale = new System.Windows.Forms.Button();
            this.btn_General = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabSale = new System.Windows.Forms.TabPage();
            this.btnOrderMonitor = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.tabPurchase = new System.Windows.Forms.TabPage();
            this.btnPurchaseMonitor = new System.Windows.Forms.Button();
            this.btnPurchaseOrder = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeft.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabSale.SuspendLayout();
            this.tabPurchase.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.button6);
            this.pnlLeft.Controls.Add(this.btnSale);
            this.pnlLeft.Controls.Add(this.btn_General);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(200, 441);
            this.pnlLeft.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(0, 86);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(200, 43);
            this.button6.TabIndex = 3;
            this.button6.Tag = "tabPurchase";
            this.button6.Text = "采购管理";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnSale
            // 
            this.btnSale.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSale.Location = new System.Drawing.Point(0, 43);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(200, 43);
            this.btnSale.TabIndex = 2;
            this.btnSale.Tag = "tabSale";
            this.btnSale.Text = "销售管理";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_General
            // 
            this.btn_General.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_General.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_General.Location = new System.Drawing.Point(0, 0);
            this.btn_General.Name = "btn_General";
            this.btn_General.Size = new System.Drawing.Size(200, 43);
            this.btn_General.TabIndex = 1;
            this.btn_General.Tag = "tabGeneral";
            this.btn_General.Text = "基本资料";
            this.btn_General.UseVisualStyleBackColor = true;
            this.btn_General.Click += new System.EventHandler(this.btn_Click);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitter1.Location = new System.Drawing.Point(200, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 441);
            this.splitter1.TabIndex = 114;
            this.splitter1.TabStop = false;
            this.splitter1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(208, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(755, 441);
            this.panel2.TabIndex = 116;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabSale);
            this.tabControl1.Controls.Add(this.tabPurchase);
            this.tabControl1.ItemSize = new System.Drawing.Size(18, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(755, 441);
            this.tabControl1.TabIndex = 116;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.tableLayoutPanel1);
            this.tabGeneral.Location = new System.Drawing.Point(22, 4);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(729, 433);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "基本资料";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(364, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(173, 85);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(4, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(173, 85);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 85);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 85);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabSale
            // 
            this.tabSale.Controls.Add(this.tableLayoutPanel2);
            this.tabSale.Location = new System.Drawing.Point(22, 4);
            this.tabSale.Name = "tabSale";
            this.tabSale.Padding = new System.Windows.Forms.Padding(3);
            this.tabSale.Size = new System.Drawing.Size(729, 433);
            this.tabSale.TabIndex = 1;
            this.tabSale.Text = "销售管理";
            this.tabSale.UseVisualStyleBackColor = true;
            // 
            // btnOrderMonitor
            // 
            this.btnOrderMonitor.Location = new System.Drawing.Point(4, 100);
            this.btnOrderMonitor.Name = "btnOrderMonitor";
            this.btnOrderMonitor.Size = new System.Drawing.Size(173, 68);
            this.btnOrderMonitor.TabIndex = 2;
            this.btnOrderMonitor.Text = "订单跟踪";
            this.btnOrderMonitor.UseVisualStyleBackColor = true;
            this.btnOrderMonitor.Click += new System.EventHandler(this.btnOrderMonitor_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(184, 4);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(173, 68);
            this.btnOrder.TabIndex = 1;
            this.btnOrder.Text = "销售订单";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Location = new System.Drawing.Point(4, 4);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(173, 68);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "客户资料";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // tabPurchase
            // 
            this.tabPurchase.Controls.Add(this.btnPurchaseMonitor);
            this.tabPurchase.Controls.Add(this.btnPurchaseOrder);
            this.tabPurchase.Controls.Add(this.btnSupplier);
            this.tabPurchase.Location = new System.Drawing.Point(22, 4);
            this.tabPurchase.Name = "tabPurchase";
            this.tabPurchase.Size = new System.Drawing.Size(729, 433);
            this.tabPurchase.TabIndex = 2;
            this.tabPurchase.Text = "采购管理";
            this.tabPurchase.UseVisualStyleBackColor = true;
            // 
            // btnPurchaseMonitor
            // 
            this.btnPurchaseMonitor.Location = new System.Drawing.Point(47, 129);
            this.btnPurchaseMonitor.Name = "btnPurchaseMonitor";
            this.btnPurchaseMonitor.Size = new System.Drawing.Size(177, 68);
            this.btnPurchaseMonitor.TabIndex = 5;
            this.btnPurchaseMonitor.Text = "采购单跟踪";
            this.btnPurchaseMonitor.UseVisualStyleBackColor = true;
            // 
            // btnPurchaseOrder
            // 
            this.btnPurchaseOrder.Location = new System.Drawing.Point(260, 23);
            this.btnPurchaseOrder.Name = "btnPurchaseOrder";
            this.btnPurchaseOrder.Size = new System.Drawing.Size(174, 68);
            this.btnPurchaseOrder.TabIndex = 4;
            this.btnPurchaseOrder.Text = "采购订单";
            this.btnPurchaseOrder.UseVisualStyleBackColor = true;
            // 
            // btnSupplier
            // 
            this.btnSupplier.Location = new System.Drawing.Point(47, 23);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(177, 68);
            this.btnSupplier.TabIndex = 3;
            this.btnSupplier.Text = "供应商资料";
            this.btnSupplier.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button3, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(724, 387);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.btnCustomer, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnOrderMonitor, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnOrder, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(724, 387);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 441);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmHome";
            this.ShowInTaskbar = false;
            this.Text = "首页";
            this.Load += new System.EventHandler(this.FrmHome_Load);
            this.pnlLeft.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabSale.ResumeLayout(false);
            this.tabPurchase.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabSale;
        private System.Windows.Forms.Button btn_General;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.TabPage tabPurchase;
        private System.Windows.Forms.Button btnOrderMonitor;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnPurchaseMonitor;
        private System.Windows.Forms.Button btnPurchaseOrder;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}