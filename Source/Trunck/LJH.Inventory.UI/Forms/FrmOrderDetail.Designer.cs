namespace LJH.Inventory.UI.Forms
{
    partial class FrmOrderDetail
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_AddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_RemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnApprove = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnShip = new System.Windows.Forms.ToolStripButton();
            this.btnPaid = new System.Windows.Forms.ToolStripButton();
            this.btnPaymentAssign = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtFinalCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkFinalCustomer = new System.Windows.Forms.LinkLabel();
            this.txtDestinationPort = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtLoadPort = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtTransport = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtCollectionType = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtCurrencyType = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtPriceTerm = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkSalesPerson = new System.Windows.Forms.LinkLabel();
            this.lnkDestinationPort = new System.Windows.Forms.LinkLabel();
            this.lnkLoadPort = new System.Windows.Forms.LinkLabel();
            this.lnkTransport = new System.Windows.Forms.LinkLabel();
            this.lnkCollectionType = new System.Windows.Forms.LinkLabel();
            this.lnkPriceTerm = new System.Windows.Forms.LinkLabel();
            this.lnkCurrencyType = new System.Windows.Forms.LinkLabel();
            this.txtCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.dtOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkCustomer = new System.Windows.Forms.LinkLabel();
            this.txtSalesPerson = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.ItemsGrid = new System.Windows.Forms.DataGridView();
            this.txtSheetNo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.dtDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colOperateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colForeignName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOnPurchase = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colInventory = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colPrepared = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShipped = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colNotShipped = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsGrid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(582, 488);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(473, 488);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_AddItem,
            this.mnu_RemoveItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 48);
            // 
            // btn_AddItem
            // 
            this.btn_AddItem.Name = "btn_AddItem";
            this.btn_AddItem.Size = new System.Drawing.Size(112, 22);
            this.btn_AddItem.Text = "新增项";
            this.btn_AddItem.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // mnu_RemoveItem
            // 
            this.mnu_RemoveItem.Name = "mnu_RemoveItem";
            this.mnu_RemoveItem.Size = new System.Drawing.Size(112, 22);
            this.mnu_RemoveItem.Text = "删除项";
            this.mnu_RemoveItem.Click += new System.EventHandler(this.mnu_Remove_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnApprove,
            this.btnPrint,
            this.btnShip,
            this.btnPaid,
            this.btnPaymentAssign});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1135, 56);
            this.toolStrip1.TabIndex = 86;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::LJH.Inventory.UI.Properties.Resources.save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 53);
            this.btnSave.Text = "保存(&S)";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.ToolTipText = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Image = global::LJH.Inventory.UI.Properties.Resources.approve;
            this.btnApprove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(52, 53);
            this.btnApprove.Text = "审核(&A)";
            this.btnApprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::LJH.Inventory.UI.Properties.Resources.Print_;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(51, 53);
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnShip
            // 
            this.btnShip.Image = global::LJH.Inventory.UI.Properties.Resources.shipped;
            this.btnShip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShip.Name = "btnShip";
            this.btnShip.Size = new System.Drawing.Size(53, 53);
            this.btnShip.Text = "出货(&D)";
            this.btnShip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnShip.Click += new System.EventHandler(this.btnShip_Click);
            // 
            // btnPaid
            // 
            this.btnPaid.Image = global::LJH.Inventory.UI.Properties.Resources.payment;
            this.btnPaid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(51, 53);
            this.btnPaid.Text = "收款(&P)";
            this.btnPaid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnPaymentAssign
            // 
            this.btnPaymentAssign.Image = global::LJH.Inventory.UI.Properties.Resources.assign;
            this.btnPaymentAssign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaymentAssign.Name = "btnPaymentAssign";
            this.btnPaymentAssign.Size = new System.Drawing.Size(53, 53);
            this.btnPaymentAssign.Text = "核销(&G)";
            this.btnPaymentAssign.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 59);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1134, 401);
            this.tabControl1.TabIndex = 87;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtFinalCustomer);
            this.tabPage1.Controls.Add(this.lnkFinalCustomer);
            this.tabPage1.Controls.Add(this.txtDestinationPort);
            this.tabPage1.Controls.Add(this.txtLoadPort);
            this.tabPage1.Controls.Add(this.txtTransport);
            this.tabPage1.Controls.Add(this.txtCollectionType);
            this.tabPage1.Controls.Add(this.txtCurrencyType);
            this.tabPage1.Controls.Add(this.txtPriceTerm);
            this.tabPage1.Controls.Add(this.lnkSalesPerson);
            this.tabPage1.Controls.Add(this.lnkDestinationPort);
            this.tabPage1.Controls.Add(this.lnkLoadPort);
            this.tabPage1.Controls.Add(this.lnkTransport);
            this.tabPage1.Controls.Add(this.lnkCollectionType);
            this.tabPage1.Controls.Add(this.lnkPriceTerm);
            this.tabPage1.Controls.Add(this.lnkCurrencyType);
            this.tabPage1.Controls.Add(this.txtCustomer);
            this.tabPage1.Controls.Add(this.dtOrderDate);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lnkCustomer);
            this.tabPage1.Controls.Add(this.txtSalesPerson);
            this.tabPage1.Controls.Add(this.ItemsGrid);
            this.tabPage1.Controls.Add(this.txtSheetNo);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.dtDeliveryDate);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1126, 375);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本资料";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtFinalCustomer
            // 
            this.txtFinalCustomer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtFinalCustomer.Location = new System.Drawing.Point(855, 15);
            this.txtFinalCustomer.Name = "txtFinalCustomer";
            this.txtFinalCustomer.Size = new System.Drawing.Size(241, 21);
            this.txtFinalCustomer.TabIndex = 124;
            // 
            // lnkFinalCustomer
            // 
            this.lnkFinalCustomer.AutoSize = true;
            this.lnkFinalCustomer.Location = new System.Drawing.Point(791, 19);
            this.lnkFinalCustomer.Name = "lnkFinalCustomer";
            this.lnkFinalCustomer.Size = new System.Drawing.Size(59, 12);
            this.lnkFinalCustomer.TabIndex = 123;
            this.lnkFinalCustomer.TabStop = true;
            this.lnkFinalCustomer.Text = "最终客户:";
            this.lnkFinalCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEndCustomer_LinkClicked);
            // 
            // txtDestinationPort
            // 
            this.txtDestinationPort.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDestinationPort.Location = new System.Drawing.Point(507, 87);
            this.txtDestinationPort.Name = "txtDestinationPort";
            this.txtDestinationPort.Size = new System.Drawing.Size(131, 21);
            this.txtDestinationPort.TabIndex = 122;
            // 
            // txtLoadPort
            // 
            this.txtLoadPort.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLoadPort.Location = new System.Drawing.Point(292, 83);
            this.txtLoadPort.Name = "txtLoadPort";
            this.txtLoadPort.Size = new System.Drawing.Size(109, 21);
            this.txtLoadPort.TabIndex = 121;
            // 
            // txtTransport
            // 
            this.txtTransport.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtTransport.Location = new System.Drawing.Point(88, 83);
            this.txtTransport.Name = "txtTransport";
            this.txtTransport.Size = new System.Drawing.Size(106, 21);
            this.txtTransport.TabIndex = 120;
            // 
            // txtCollectionType
            // 
            this.txtCollectionType.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCollectionType.Location = new System.Drawing.Point(507, 51);
            this.txtCollectionType.Name = "txtCollectionType";
            this.txtCollectionType.Size = new System.Drawing.Size(241, 21);
            this.txtCollectionType.TabIndex = 119;
            // 
            // txtCurrencyType
            // 
            this.txtCurrencyType.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCurrencyType.Location = new System.Drawing.Point(292, 51);
            this.txtCurrencyType.Name = "txtCurrencyType";
            this.txtCurrencyType.Size = new System.Drawing.Size(109, 21);
            this.txtCurrencyType.TabIndex = 118;
            // 
            // txtPriceTerm
            // 
            this.txtPriceTerm.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPriceTerm.Location = new System.Drawing.Point(88, 51);
            this.txtPriceTerm.Name = "txtPriceTerm";
            this.txtPriceTerm.Size = new System.Drawing.Size(106, 21);
            this.txtPriceTerm.TabIndex = 117;
            // 
            // lnkSalesPerson
            // 
            this.lnkSalesPerson.AutoSize = true;
            this.lnkSalesPerson.Location = new System.Drawing.Point(804, 55);
            this.lnkSalesPerson.Name = "lnkSalesPerson";
            this.lnkSalesPerson.Size = new System.Drawing.Size(47, 12);
            this.lnkSalesPerson.TabIndex = 114;
            this.lnkSalesPerson.TabStop = true;
            this.lnkSalesPerson.Text = "业务员:";
            this.lnkSalesPerson.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSalesPerson_LinkClicked);
            // 
            // lnkDestinationPort
            // 
            this.lnkDestinationPort.AutoSize = true;
            this.lnkDestinationPort.Location = new System.Drawing.Point(453, 89);
            this.lnkDestinationPort.Name = "lnkDestinationPort";
            this.lnkDestinationPort.Size = new System.Drawing.Size(47, 12);
            this.lnkDestinationPort.TabIndex = 113;
            this.lnkDestinationPort.TabStop = true;
            this.lnkDestinationPort.Text = "目的港:";
            this.lnkDestinationPort.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDestinationPort_LinkClicked);
            // 
            // lnkLoadPort
            // 
            this.lnkLoadPort.AutoSize = true;
            this.lnkLoadPort.Location = new System.Drawing.Point(238, 87);
            this.lnkLoadPort.Name = "lnkLoadPort";
            this.lnkLoadPort.Size = new System.Drawing.Size(47, 12);
            this.lnkLoadPort.TabIndex = 112;
            this.lnkLoadPort.TabStop = true;
            this.lnkLoadPort.Text = "起运港:";
            this.lnkLoadPort.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLoadPort_LinkClicked);
            // 
            // lnkTransport
            // 
            this.lnkTransport.AutoSize = true;
            this.lnkTransport.Location = new System.Drawing.Point(23, 87);
            this.lnkTransport.Name = "lnkTransport";
            this.lnkTransport.Size = new System.Drawing.Size(59, 12);
            this.lnkTransport.TabIndex = 111;
            this.lnkTransport.TabStop = true;
            this.lnkTransport.Text = "运输方式:";
            this.lnkTransport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTransport_LinkClicked);
            // 
            // lnkCollectionType
            // 
            this.lnkCollectionType.AutoSize = true;
            this.lnkCollectionType.Location = new System.Drawing.Point(441, 55);
            this.lnkCollectionType.Name = "lnkCollectionType";
            this.lnkCollectionType.Size = new System.Drawing.Size(59, 12);
            this.lnkCollectionType.TabIndex = 110;
            this.lnkCollectionType.TabStop = true;
            this.lnkCollectionType.Text = "收汇方式:";
            this.lnkCollectionType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCollectionType_LinkClicked);
            // 
            // lnkPriceTerm
            // 
            this.lnkPriceTerm.AutoSize = true;
            this.lnkPriceTerm.Location = new System.Drawing.Point(23, 55);
            this.lnkPriceTerm.Name = "lnkPriceTerm";
            this.lnkPriceTerm.Size = new System.Drawing.Size(59, 12);
            this.lnkPriceTerm.TabIndex = 109;
            this.lnkPriceTerm.TabStop = true;
            this.lnkPriceTerm.Text = "价格条款:";
            this.lnkPriceTerm.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPriceTerm_LinkClicked);
            // 
            // lnkCurrencyType
            // 
            this.lnkCurrencyType.AutoSize = true;
            this.lnkCurrencyType.Location = new System.Drawing.Point(250, 55);
            this.lnkCurrencyType.Name = "lnkCurrencyType";
            this.lnkCurrencyType.Size = new System.Drawing.Size(35, 12);
            this.lnkCurrencyType.TabIndex = 108;
            this.lnkCurrencyType.TabStop = true;
            this.lnkCurrencyType.Text = "币别:";
            this.lnkCurrencyType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCurrencyType_LinkClicked);
            // 
            // txtCustomer
            // 
            this.txtCustomer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCustomer.Location = new System.Drawing.Point(507, 15);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(241, 21);
            this.txtCustomer.TabIndex = 107;
            // 
            // dtOrderDate
            // 
            this.dtOrderDate.Location = new System.Drawing.Point(292, 15);
            this.dtOrderDate.Name = "dtOrderDate";
            this.dtOrderDate.Size = new System.Drawing.Size(109, 21);
            this.dtOrderDate.TabIndex = 105;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 106;
            this.label1.Text = "合同日期:";
            // 
            // lnkCustomer
            // 
            this.lnkCustomer.AutoSize = true;
            this.lnkCustomer.Location = new System.Drawing.Point(465, 19);
            this.lnkCustomer.Name = "lnkCustomer";
            this.lnkCustomer.Size = new System.Drawing.Size(35, 12);
            this.lnkCustomer.TabIndex = 104;
            this.lnkCustomer.TabStop = true;
            this.lnkCustomer.Text = "客户:";
            this.lnkCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomer_LinkClicked);
            // 
            // txtSalesPerson
            // 
            this.txtSalesPerson.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSalesPerson.Location = new System.Drawing.Point(855, 51);
            this.txtSalesPerson.Name = "txtSalesPerson";
            this.txtSalesPerson.Size = new System.Drawing.Size(131, 21);
            this.txtSalesPerson.TabIndex = 101;
            // 
            // ItemsGrid
            // 
            this.ItemsGrid.AllowDrop = true;
            this.ItemsGrid.AllowUserToAddRows = false;
            this.ItemsGrid.AllowUserToDeleteRows = false;
            this.ItemsGrid.AllowUserToResizeRows = false;
            this.ItemsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductID,
            this.colProductName,
            this.colForeignName,
            this.colProductCode,
            this.colSpecification,
            this.colUnit,
            this.colPrice,
            this.colCount,
            this.colTotal,
            this.colOnPurchase,
            this.colInventory,
            this.colPrepared,
            this.colShipped,
            this.colNotShipped,
            this.colMemo});
            this.ItemsGrid.ContextMenuStrip = this.contextMenuStrip1;
            this.ItemsGrid.Location = new System.Drawing.Point(13, 114);
            this.ItemsGrid.Name = "ItemsGrid";
            this.ItemsGrid.RowHeadersVisible = false;
            this.ItemsGrid.RowTemplate.Height = 23;
            this.ItemsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ItemsGrid.Size = new System.Drawing.Size(1107, 253);
            this.ItemsGrid.TabIndex = 97;
            this.ItemsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemsGrid_CellContentClick);
            this.ItemsGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemsGrid_CellEndEdit);
            // 
            // txtSheetNo
            // 
            this.txtSheetNo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSheetNo.Location = new System.Drawing.Point(88, 15);
            this.txtSheetNo.Name = "txtSheetNo";
            this.txtSheetNo.Size = new System.Drawing.Size(106, 21);
            this.txtSheetNo.TabIndex = 83;
            this.txtSheetNo.Text = "自动创建";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 88;
            this.label11.Text = "订单号:";
            // 
            // dtDeliveryDate
            // 
            this.dtDeliveryDate.Location = new System.Drawing.Point(729, 83);
            this.dtDeliveryDate.Name = "dtDeliveryDate";
            this.dtDeliveryDate.Size = new System.Drawing.Size(131, 21);
            this.dtDeliveryDate.TabIndex = 85;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(666, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 87;
            this.label4.Text = "出货日期:";
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1126, 375);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "合同条款";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1126, 375);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "相关文档";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1126, 375);
            this.tabPage2.TabIndex = 6;
            this.tabPage2.Text = "操作记录";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOperateDate,
            this.colOperation,
            this.colOperator,
            this.colFill});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1126, 375);
            this.dataGridView1.TabIndex = 98;
            // 
            // colOperateDate
            // 
            this.colOperateDate.HeaderText = "操作时间";
            this.colOperateDate.Name = "colOperateDate";
            this.colOperateDate.ReadOnly = true;
            this.colOperateDate.Width = 130;
            // 
            // colOperation
            // 
            this.colOperation.HeaderText = "操作";
            this.colOperation.Name = "colOperation";
            this.colOperation.ReadOnly = true;
            this.colOperation.Width = 200;
            // 
            // colOperator
            // 
            this.colOperator.HeaderText = "操作员";
            this.colOperator.Name = "colOperator";
            this.colOperator.ReadOnly = true;
            this.colOperator.Width = 150;
            // 
            // colFill
            // 
            this.colFill.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFill.HeaderText = "";
            this.colFill.Name = "colFill";
            this.colFill.ReadOnly = true;
            // 
            // colProductID
            // 
            this.colProductID.HeaderText = "商品编号";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "商品名称";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colProductName.Width = 120;
            // 
            // colForeignName
            // 
            this.colForeignName.HeaderText = "英文名称";
            this.colForeignName.Name = "colForeignName";
            this.colForeignName.ReadOnly = true;
            this.colForeignName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colProductCode
            // 
            this.colProductCode.HeaderText = "商品代码";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colSpecification
            // 
            this.colSpecification.HeaderText = "规格";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            this.colSpecification.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSpecification.Width = 80;
            // 
            // colUnit
            // 
            this.colUnit.HeaderText = "单位";
            this.colUnit.Name = "colUnit";
            this.colUnit.ReadOnly = true;
            this.colUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colUnit.Width = 60;
            // 
            // colPrice
            // 
            dataGridViewCellStyle1.NullValue = null;
            this.colPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPrice.HeaderText = "单价";
            this.colPrice.Name = "colPrice";
            this.colPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPrice.Width = 60;
            // 
            // colCount
            // 
            dataGridViewCellStyle2.NullValue = "0";
            this.colCount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCount.HeaderText = "数量";
            this.colCount.Name = "colCount";
            this.colCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCount.Width = 60;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "金额";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTotal.Width = 60;
            // 
            // colOnPurchase
            // 
            this.colOnPurchase.HeaderText = "采购在途";
            this.colOnPurchase.Name = "colOnPurchase";
            this.colOnPurchase.ReadOnly = true;
            this.colOnPurchase.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOnPurchase.Width = 60;
            // 
            // colInventory
            // 
            this.colInventory.HeaderText = "库存";
            this.colInventory.Name = "colInventory";
            this.colInventory.ReadOnly = true;
            this.colInventory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInventory.Width = 60;
            // 
            // colPrepared
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            this.colPrepared.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPrepared.HeaderText = "已备货";
            this.colPrepared.Name = "colPrepared";
            this.colPrepared.ReadOnly = true;
            this.colPrepared.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPrepared.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPrepared.Width = 60;
            // 
            // colShipped
            // 
            this.colShipped.HeaderText = "已出货";
            this.colShipped.Name = "colShipped";
            this.colShipped.ReadOnly = true;
            this.colShipped.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colShipped.Width = 60;
            // 
            // colNotShipped
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red;
            this.colNotShipped.DefaultCellStyle = dataGridViewCellStyle4;
            this.colNotShipped.HeaderText = "未出货";
            this.colNotShipped.Name = "colNotShipped";
            this.colNotShipped.ReadOnly = true;
            this.colNotShipped.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colNotShipped.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colNotShipped.Width = 60;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            this.colMemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMemo.Width = 200;
            // 
            // FrmOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 460);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmOrderDetail";
            this.Text = "销售订单";
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsGrid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btn_AddItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_RemoveItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnApprove;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnShip;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnPaid;
        private System.Windows.Forms.ToolStripButton btnPaymentAssign;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private GeneralLibrary.WinformControl.DBCTextBox txtSalesPerson;
        private System.Windows.Forms.DataGridView ItemsGrid;
        private GeneralLibrary.WinformControl.DBCTextBox txtSheetNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtDeliveryDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.LinkLabel lnkCustomer;
        private System.Windows.Forms.DateTimePicker dtOrderDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkSalesPerson;
        private System.Windows.Forms.LinkLabel lnkDestinationPort;
        private System.Windows.Forms.LinkLabel lnkLoadPort;
        private System.Windows.Forms.LinkLabel lnkTransport;
        private System.Windows.Forms.LinkLabel lnkCollectionType;
        private System.Windows.Forms.LinkLabel lnkPriceTerm;
        private System.Windows.Forms.LinkLabel lnkCurrencyType;
        private GeneralLibrary.WinformControl.DBCTextBox txtCustomer;
        private System.Windows.Forms.TabPage tabPage6;
        private GeneralLibrary.WinformControl.DBCTextBox txtDestinationPort;
        private GeneralLibrary.WinformControl.DBCTextBox txtLoadPort;
        private GeneralLibrary.WinformControl.DBCTextBox txtTransport;
        private GeneralLibrary.WinformControl.DBCTextBox txtCollectionType;
        private GeneralLibrary.WinformControl.DBCTextBox txtCurrencyType;
        private GeneralLibrary.WinformControl.DBCTextBox txtPriceTerm;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFill;
        private GeneralLibrary.WinformControl.DBCTextBox txtFinalCustomer;
        private System.Windows.Forms.LinkLabel lnkFinalCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colForeignName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewLinkColumn colOnPurchase;
        private System.Windows.Forms.DataGridViewLinkColumn colInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrepared;
        private System.Windows.Forms.DataGridViewLinkColumn colShipped;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotShipped;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
    }
}