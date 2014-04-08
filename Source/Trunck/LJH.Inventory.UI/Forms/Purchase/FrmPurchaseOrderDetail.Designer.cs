namespace LJH.Inventory.UI.Forms
{
    partial class FrmPurchaseOrderDetail
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtCurrencyType = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkBuyer = new System.Windows.Forms.LinkLabel();
            this.lnkCurrencyType = new System.Windows.Forms.LinkLabel();
            this.txtSupplier = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.dtOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkSupplier = new System.Windows.Forms.LinkLabel();
            this.txtBuyer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.ItemsGrid = new System.Windows.Forms.DataGridView();
            this.colHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colReceived = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colOnWay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_AddOrderRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_AddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_RemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSheetNo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.dtDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.gridAttachment = new System.Windows.Forms.DataGridView();
            this.colUploadDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnu_Attachment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_AttachmentAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_AttachmentOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_AttachmentSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_AttachmentDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colOperateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnApprove = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsGrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttachment)).BeginInit();
            this.mnu_Attachment.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(917, 366);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(808, 366);
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
            this.tabControl1.Location = new System.Drawing.Point(-4, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 401);
            this.tabControl1.TabIndex = 89;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtCurrencyType);
            this.tabPage1.Controls.Add(this.lnkBuyer);
            this.tabPage1.Controls.Add(this.lnkCurrencyType);
            this.tabPage1.Controls.Add(this.txtSupplier);
            this.tabPage1.Controls.Add(this.dtOrderDate);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lnkSupplier);
            this.tabPage1.Controls.Add(this.txtBuyer);
            this.tabPage1.Controls.Add(this.ItemsGrid);
            this.tabPage1.Controls.Add(this.txtSheetNo);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.dtDeliveryDate);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1000, 375);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本资料";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtCurrencyType
            // 
            this.txtCurrencyType.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCurrencyType.Location = new System.Drawing.Point(89, 50);
            this.txtCurrencyType.Name = "txtCurrencyType";
            this.txtCurrencyType.Size = new System.Drawing.Size(109, 21);
            this.txtCurrencyType.TabIndex = 118;
            // 
            // lnkBuyer
            // 
            this.lnkBuyer.AutoSize = true;
            this.lnkBuyer.Location = new System.Drawing.Point(465, 50);
            this.lnkBuyer.Name = "lnkBuyer";
            this.lnkBuyer.Size = new System.Drawing.Size(47, 12);
            this.lnkBuyer.TabIndex = 114;
            this.lnkBuyer.TabStop = true;
            this.lnkBuyer.Text = "采购员:";
            this.lnkBuyer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBuyer_LinkClicked);
            // 
            // lnkCurrencyType
            // 
            this.lnkCurrencyType.AutoSize = true;
            this.lnkCurrencyType.Location = new System.Drawing.Point(47, 54);
            this.lnkCurrencyType.Name = "lnkCurrencyType";
            this.lnkCurrencyType.Size = new System.Drawing.Size(35, 12);
            this.lnkCurrencyType.TabIndex = 108;
            this.lnkCurrencyType.TabStop = true;
            this.lnkCurrencyType.Text = "币别:";
            this.lnkCurrencyType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCurrencyType_LinkClicked);
            // 
            // txtSupplier
            // 
            this.txtSupplier.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSupplier.Location = new System.Drawing.Point(513, 15);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(353, 21);
            this.txtSupplier.TabIndex = 107;
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
            // lnkSupplier
            // 
            this.lnkSupplier.AutoSize = true;
            this.lnkSupplier.Location = new System.Drawing.Point(465, 19);
            this.lnkSupplier.Name = "lnkSupplier";
            this.lnkSupplier.Size = new System.Drawing.Size(47, 12);
            this.lnkSupplier.TabIndex = 104;
            this.lnkSupplier.TabStop = true;
            this.lnkSupplier.Text = "供应商:";
            this.lnkSupplier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSupplier_LinkClicked);
            // 
            // txtBuyer
            // 
            this.txtBuyer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtBuyer.Location = new System.Drawing.Point(513, 46);
            this.txtBuyer.Name = "txtBuyer";
            this.txtBuyer.Size = new System.Drawing.Size(131, 21);
            this.txtBuyer.TabIndex = 101;
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
            this.colHeader,
            this.colProductID,
            this.colProductName,
            this.colSpecification,
            this.colPrice,
            this.colCount,
            this.colTotal,
            this.colOrderID,
            this.colReceived,
            this.colOnWay,
            this.colMemo});
            this.ItemsGrid.ContextMenuStrip = this.contextMenuStrip1;
            this.ItemsGrid.Location = new System.Drawing.Point(13, 77);
            this.ItemsGrid.Name = "ItemsGrid";
            this.ItemsGrid.RowHeadersVisible = false;
            this.ItemsGrid.RowHeadersWidth = 30;
            this.ItemsGrid.RowTemplate.Height = 23;
            this.ItemsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ItemsGrid.Size = new System.Drawing.Size(979, 236);
            this.ItemsGrid.TabIndex = 97;
            this.ItemsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemsGrid_CellContentClick);
            this.ItemsGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemsGrid_CellEndEdit);
            // 
            // colHeader
            // 
            this.colHeader.HeaderText = "";
            this.colHeader.MinimumWidth = 20;
            this.colHeader.Name = "colHeader";
            this.colHeader.ReadOnly = true;
            this.colHeader.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHeader.Width = 20;
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
            this.colProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colProductName.HeaderText = "商品名称";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colProductName.Width = 59;
            // 
            // colSpecification
            // 
            this.colSpecification.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSpecification.HeaderText = "规格";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            this.colSpecification.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSpecification.Width = 35;
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
            dataGridViewCellStyle3.NullValue = null;
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTotal.HeaderText = "金额";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTotal.Width = 60;
            // 
            // colOrderID
            // 
            this.colOrderID.HeaderText = "销售订单";
            this.colOrderID.Name = "colOrderID";
            this.colOrderID.ReadOnly = true;
            this.colOrderID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colReceived
            // 
            this.colReceived.HeaderText = "到货数";
            this.colReceived.Name = "colReceived";
            this.colReceived.ReadOnly = true;
            this.colReceived.Width = 60;
            // 
            // colOnWay
            // 
            this.colOnWay.HeaderText = "在途数";
            this.colOnWay.Name = "colOnWay";
            this.colOnWay.ReadOnly = true;
            this.colOnWay.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOnWay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colOnWay.Width = 60;
            // 
            // colMemo
            // 
            this.colMemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            this.colMemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_AddOrderRecord,
            this.btn_AddItem,
            this.mnu_RemoveItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 70);
            // 
            // btn_AddOrderRecord
            // 
            this.btn_AddOrderRecord.Name = "btn_AddOrderRecord";
            this.btn_AddOrderRecord.Size = new System.Drawing.Size(160, 22);
            this.btn_AddOrderRecord.Text = "选择销售订单项";
            this.btn_AddOrderRecord.Click += new System.EventHandler(this.btn_AddOrderRecord_Click);
            // 
            // btn_AddItem
            // 
            this.btn_AddItem.Name = "btn_AddItem";
            this.btn_AddItem.Size = new System.Drawing.Size(160, 22);
            this.btn_AddItem.Text = "选择商品";
            this.btn_AddItem.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // mnu_RemoveItem
            // 
            this.mnu_RemoveItem.Name = "mnu_RemoveItem";
            this.mnu_RemoveItem.Size = new System.Drawing.Size(160, 22);
            this.mnu_RemoveItem.Text = "删除";
            this.mnu_RemoveItem.Click += new System.EventHandler(this.mnu_Remove_Click);
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
            this.dtDeliveryDate.Location = new System.Drawing.Point(289, 49);
            this.dtDeliveryDate.Name = "dtDeliveryDate";
            this.dtDeliveryDate.Size = new System.Drawing.Size(112, 21);
            this.dtDeliveryDate.TabIndex = 85;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 87;
            this.label4.Text = "发货日期:";
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1000, 375);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "合同条款";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.gridAttachment);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1000, 375);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "相关文档";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // gridAttachment
            // 
            this.gridAttachment.AllowDrop = true;
            this.gridAttachment.AllowUserToAddRows = false;
            this.gridAttachment.AllowUserToDeleteRows = false;
            this.gridAttachment.AllowUserToResizeRows = false;
            this.gridAttachment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAttachment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUploadDateTime,
            this.colOwner,
            this.colFileName});
            this.gridAttachment.ContextMenuStrip = this.mnu_Attachment;
            this.gridAttachment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAttachment.Location = new System.Drawing.Point(0, 0);
            this.gridAttachment.Name = "gridAttachment";
            this.gridAttachment.RowHeadersVisible = false;
            this.gridAttachment.RowTemplate.Height = 23;
            this.gridAttachment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAttachment.Size = new System.Drawing.Size(1000, 375);
            this.gridAttachment.TabIndex = 103;
            // 
            // colUploadDateTime
            // 
            this.colUploadDateTime.HeaderText = "上传时间";
            this.colUploadDateTime.Name = "colUploadDateTime";
            this.colUploadDateTime.ReadOnly = true;
            this.colUploadDateTime.Width = 130;
            // 
            // colOwner
            // 
            this.colOwner.HeaderText = "操作员";
            this.colOwner.Name = "colOwner";
            this.colOwner.ReadOnly = true;
            this.colOwner.Width = 150;
            // 
            // colFileName
            // 
            this.colFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFileName.HeaderText = "附件";
            this.colFileName.MinimumWidth = 100;
            this.colFileName.Name = "colFileName";
            this.colFileName.ReadOnly = true;
            // 
            // mnu_Attachment
            // 
            this.mnu_Attachment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_AttachmentAdd,
            this.mnu_AttachmentOpen,
            this.mnu_AttachmentSaveAs,
            this.mnu_AttachmentDelete});
            this.mnu_Attachment.Name = "contextMenuStrip1";
            this.mnu_Attachment.Size = new System.Drawing.Size(122, 92);
            // 
            // mnu_AttachmentAdd
            // 
            this.mnu_AttachmentAdd.Name = "mnu_AttachmentAdd";
            this.mnu_AttachmentAdd.Size = new System.Drawing.Size(121, 22);
            this.mnu_AttachmentAdd.Text = "新增";
            this.mnu_AttachmentAdd.Click += new System.EventHandler(this.mnu_AttachmentAdd_Click);
            // 
            // mnu_AttachmentOpen
            // 
            this.mnu_AttachmentOpen.Name = "mnu_AttachmentOpen";
            this.mnu_AttachmentOpen.Size = new System.Drawing.Size(121, 22);
            this.mnu_AttachmentOpen.Text = "打开";
            this.mnu_AttachmentOpen.Click += new System.EventHandler(this.mnu_AttachmentOpen_Click);
            // 
            // mnu_AttachmentSaveAs
            // 
            this.mnu_AttachmentSaveAs.Name = "mnu_AttachmentSaveAs";
            this.mnu_AttachmentSaveAs.Size = new System.Drawing.Size(121, 22);
            this.mnu_AttachmentSaveAs.Text = "另存为...";
            this.mnu_AttachmentSaveAs.Click += new System.EventHandler(this.mnu_AttachmentSaveAs_Click);
            // 
            // mnu_AttachmentDelete
            // 
            this.mnu_AttachmentDelete.Name = "mnu_AttachmentDelete";
            this.mnu_AttachmentDelete.Size = new System.Drawing.Size(121, 22);
            this.mnu_AttachmentDelete.Text = "删除";
            this.mnu_AttachmentDelete.Click += new System.EventHandler(this.mnu_AttachmentDelete_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1000, 375);
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
            this.dataGridView1.Size = new System.Drawing.Size(1000, 375);
            this.dataGridView1.TabIndex = 99;
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
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnApprove,
            this.btnPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1004, 56);
            this.toolStrip1.TabIndex = 88;
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
            // FrmPurchaseOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 401);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmPurchaseOrderDetail";
            this.Text = "采购合同明细";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsGrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAttachment)).EndInit();
            this.mnu_Attachment.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private GeneralLibrary.WinformControl.DBCTextBox txtCurrencyType;
        private System.Windows.Forms.LinkLabel lnkBuyer;
        private System.Windows.Forms.LinkLabel lnkCurrencyType;
        private GeneralLibrary.WinformControl.DBCTextBox txtSupplier;
        private System.Windows.Forms.DateTimePicker dtOrderDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkSupplier;
        private GeneralLibrary.WinformControl.DBCTextBox txtBuyer;
        private System.Windows.Forms.DataGridView ItemsGrid;
        private GeneralLibrary.WinformControl.DBCTextBox txtSheetNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtDeliveryDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnApprove;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btn_AddItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_RemoveItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFill;
        private System.Windows.Forms.ToolStripMenuItem btn_AddOrderRecord;
        private System.Windows.Forms.ContextMenuStrip mnu_Attachment;
        private System.Windows.Forms.ToolStripMenuItem mnu_AttachmentAdd;
        private System.Windows.Forms.ToolStripMenuItem mnu_AttachmentOpen;
        private System.Windows.Forms.ToolStripMenuItem mnu_AttachmentSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnu_AttachmentDelete;
        private System.Windows.Forms.DataGridView gridAttachment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUploadDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewLinkColumn colOrderID;
        private System.Windows.Forms.DataGridViewLinkColumn colReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOnWay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
    }
}