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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGeneral = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSale = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPurchase = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabSale = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnOrderMonitor = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.tabPurchase = new System.Windows.Forms.TabPage();
            this.btnPurchaseMonitor = new System.Windows.Forms.Button();
            this.btnPurchaseOrder = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.pnlLeft.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabSale.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPurchase.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.toolStrip1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(190, 441);
            this.pnlLeft.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGeneral,
            this.toolStripSeparator1,
            this.btnSale,
            this.toolStripSeparator2,
            this.btnPurchase});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(190, 152);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnGeneral
            // 
            this.btnGeneral.Image = global::LJH.Inventory.UI.Properties.Resources.information;
            this.btnGeneral.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(188, 40);
            this.btnGeneral.Tag = "tabGeneral";
            this.btnGeneral.Text = "基本资料";
            this.btnGeneral.Click += new System.EventHandler(this.btn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // btnSale
            // 
            this.btnSale.Image = global::LJH.Inventory.UI.Properties.Resources.sale;
            this.btnSale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(188, 40);
            this.btnSale.Tag = "tabSale";
            this.btnSale.Text = "销售管理";
            this.btnSale.Click += new System.EventHandler(this.btn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
            // 
            // btnPurchase
            // 
            this.btnPurchase.Image = global::LJH.Inventory.UI.Properties.Resources.buy;
            this.btnPurchase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(188, 40);
            this.btnPurchase.Tag = "tabPurchase";
            this.btnPurchase.Text = "采购管理";
            this.btnPurchase.Click += new System.EventHandler(this.btn_Click);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitter1.Location = new System.Drawing.Point(190, 0);
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
            this.panel2.Location = new System.Drawing.Point(198, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(765, 441);
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
            this.tabControl1.Size = new System.Drawing.Size(765, 441);
            this.tabControl1.TabIndex = 116;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.tableLayoutPanel1);
            this.tabGeneral.Location = new System.Drawing.Point(22, 4);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(739, 433);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "基本资料";
            this.tabGeneral.UseVisualStyleBackColor = true;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 85);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 85);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
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
            // tabSale
            // 
            this.tabSale.Controls.Add(this.tableLayoutPanel2);
            this.tabSale.Location = new System.Drawing.Point(22, 4);
            this.tabSale.Name = "tabSale";
            this.tabSale.Padding = new System.Windows.Forms.Padding(3);
            this.tabSale.Size = new System.Drawing.Size(739, 433);
            this.tabSale.TabIndex = 1;
            this.tabSale.Text = "销售管理";
            this.tabSale.UseVisualStyleBackColor = true;
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
            // tabPurchase
            // 
            this.tabPurchase.Controls.Add(this.btnPurchaseMonitor);
            this.tabPurchase.Controls.Add(this.btnPurchaseOrder);
            this.tabPurchase.Controls.Add(this.btnSupplier);
            this.tabPurchase.Location = new System.Drawing.Point(22, 4);
            this.tabPurchase.Name = "tabPurchase";
            this.tabPurchase.Size = new System.Drawing.Size(739, 433);
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
            this.pnlLeft.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabSale.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabPurchase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabSale;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPurchase;
        private System.Windows.Forms.Button btnOrderMonitor;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnPurchaseMonitor;
        private System.Windows.Forms.Button btnPurchaseOrder;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnGeneral;
        private System.Windows.Forms.ToolStripButton btnSale;
        private System.Windows.Forms.ToolStripButton btnPurchase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}