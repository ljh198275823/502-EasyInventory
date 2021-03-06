﻿namespace LJH.Inventory.UI.Forms.Purchase
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
            this.chkShowState = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdWithoutTax = new System.Windows.Forms.RadioButton();
            this.rdWithTax = new System.Windows.Forms.RadioButton();
            this.lnkBuyer = new System.Windows.Forms.LinkLabel();
            this.txtSupplier = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.dtSheetDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkSupplier = new System.Windows.Forms.LinkLabel();
            this.txtBuyer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.ItemsGrid = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_AddOrderRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_AddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_RemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSheetNo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.dtDemandDate = new LJH.Inventory.UI.Controls.NullableDateTimePicker(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.gridAttachment = new System.Windows.Forms.DataGridView();
            this.colUploadDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnUndoApprove = new System.Windows.Forms.ToolStripButton();
            this.btnNullify = new System.Windows.Forms.ToolStripButton();
            this.colHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.btnClose.Location = new System.Drawing.Point(970, 366);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(861, 366);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-4, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1061, 401);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkShowState);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.lnkBuyer);
            this.tabPage1.Controls.Add(this.txtSupplier);
            this.tabPage1.Controls.Add(this.dtSheetDate);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lnkSupplier);
            this.tabPage1.Controls.Add(this.txtBuyer);
            this.tabPage1.Controls.Add(this.ItemsGrid);
            this.tabPage1.Controls.Add(this.txtSheetNo);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.dtDemandDate);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1053, 375);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本资料";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkShowState
            // 
            this.chkShowState.AutoSize = true;
            this.chkShowState.Location = new System.Drawing.Point(630, 49);
            this.chkShowState.Name = "chkShowState";
            this.chkShowState.Size = new System.Drawing.Size(120, 16);
            this.chkShowState.TabIndex = 8;
            this.chkShowState.Text = "显示订单收货情况";
            this.chkShowState.UseVisualStyleBackColor = true;
            this.chkShowState.CheckedChanged += new System.EventHandler(this.chkShowState_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdWithoutTax);
            this.panel1.Controls.Add(this.rdWithTax);
            this.panel1.Location = new System.Drawing.Point(411, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(136, 21);
            this.panel1.TabIndex = 123;
            // 
            // rdWithoutTax
            // 
            this.rdWithoutTax.AutoSize = true;
            this.rdWithoutTax.Location = new System.Drawing.Point(68, 2);
            this.rdWithoutTax.Name = "rdWithoutTax";
            this.rdWithoutTax.Size = new System.Drawing.Size(59, 16);
            this.rdWithoutTax.TabIndex = 7;
            this.rdWithoutTax.TabStop = true;
            this.rdWithoutTax.Text = "不含税";
            this.rdWithoutTax.UseVisualStyleBackColor = true;
            // 
            // rdWithTax
            // 
            this.rdWithTax.AutoSize = true;
            this.rdWithTax.Location = new System.Drawing.Point(4, 3);
            this.rdWithTax.Name = "rdWithTax";
            this.rdWithTax.Size = new System.Drawing.Size(47, 16);
            this.rdWithTax.TabIndex = 6;
            this.rdWithTax.TabStop = true;
            this.rdWithTax.Text = "含税";
            this.rdWithTax.UseVisualStyleBackColor = true;
            // 
            // lnkBuyer
            // 
            this.lnkBuyer.AutoSize = true;
            this.lnkBuyer.Location = new System.Drawing.Point(217, 48);
            this.lnkBuyer.Name = "lnkBuyer";
            this.lnkBuyer.Size = new System.Drawing.Size(47, 12);
            this.lnkBuyer.TabIndex = 4;
            this.lnkBuyer.TabStop = true;
            this.lnkBuyer.Text = "采购员:";
            this.lnkBuyer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBuyer_LinkClicked);
            // 
            // txtSupplier
            // 
            this.txtSupplier.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSupplier.Location = new System.Drawing.Point(265, 14);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(282, 21);
            this.txtSupplier.TabIndex = 1;
            this.txtSupplier.DoubleClick += new System.EventHandler(this.txtSupplier_DoubleClick);
            // 
            // dtSheetDate
            // 
            this.dtSheetDate.Location = new System.Drawing.Point(630, 14);
            this.dtSheetDate.Name = "dtSheetDate";
            this.dtSheetDate.Size = new System.Drawing.Size(109, 21);
            this.dtSheetDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(592, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 106;
            this.label1.Text = "日期:";
            // 
            // lnkSupplier
            // 
            this.lnkSupplier.AutoSize = true;
            this.lnkSupplier.Location = new System.Drawing.Point(217, 18);
            this.lnkSupplier.Name = "lnkSupplier";
            this.lnkSupplier.Size = new System.Drawing.Size(47, 12);
            this.lnkSupplier.TabIndex = 0;
            this.lnkSupplier.TabStop = true;
            this.lnkSupplier.Text = "供应商:";
            this.lnkSupplier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSupplier_LinkClicked);
            // 
            // txtBuyer
            // 
            this.txtBuyer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtBuyer.Location = new System.Drawing.Point(265, 44);
            this.txtBuyer.Name = "txtBuyer";
            this.txtBuyer.ReadOnly = true;
            this.txtBuyer.Size = new System.Drawing.Size(131, 21);
            this.txtBuyer.TabIndex = 5;
            this.txtBuyer.DoubleClick += new System.EventHandler(this.txtBuyer_DoubleClick);
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
            this.colCategory,
            this.colSpecification,
            this.colUnit,
            this.colPrice,
            this.colCount,
            this.colTotal,
            this.colReceived,
            this.colOrderID,
            this.colMemo});
            this.ItemsGrid.ContextMenuStrip = this.contextMenuStrip1;
            this.ItemsGrid.Location = new System.Drawing.Point(13, 77);
            this.ItemsGrid.Name = "ItemsGrid";
            this.ItemsGrid.RowHeadersVisible = false;
            this.ItemsGrid.RowHeadersWidth = 30;
            this.ItemsGrid.RowTemplate.Height = 23;
            this.ItemsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ItemsGrid.Size = new System.Drawing.Size(1032, 236);
            this.ItemsGrid.TabIndex = 9;
            this.ItemsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemsGrid_CellContentClick);
            this.ItemsGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemsGrid_CellEndEdit);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMnu_AddOrderRecord,
            this.cMnu_AddItem,
            this.cMnu_RemoveItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 70);
            // 
            // cMnu_AddOrderRecord
            // 
            this.cMnu_AddOrderRecord.Name = "cMnu_AddOrderRecord";
            this.cMnu_AddOrderRecord.Size = new System.Drawing.Size(160, 22);
            this.cMnu_AddOrderRecord.Text = "选择销售订单项";
            this.cMnu_AddOrderRecord.Click += new System.EventHandler(this.cMnu_AddOrderRecord_Click);
            // 
            // cMnu_AddItem
            // 
            this.cMnu_AddItem.Name = "cMnu_AddItem";
            this.cMnu_AddItem.Size = new System.Drawing.Size(160, 22);
            this.cMnu_AddItem.Text = "选择产品";
            this.cMnu_AddItem.Click += new System.EventHandler(this.cMnu_Add_Click);
            // 
            // cMnu_RemoveItem
            // 
            this.cMnu_RemoveItem.Name = "cMnu_RemoveItem";
            this.cMnu_RemoveItem.Size = new System.Drawing.Size(160, 22);
            this.cMnu_RemoveItem.Text = "删除";
            this.cMnu_RemoveItem.Click += new System.EventHandler(this.cMnu_Remove_Click);
            // 
            // txtSheetNo
            // 
            this.txtSheetNo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSheetNo.Location = new System.Drawing.Point(88, 14);
            this.txtSheetNo.Name = "txtSheetNo";
            this.txtSheetNo.Size = new System.Drawing.Size(112, 21);
            this.txtSheetNo.TabIndex = 10;
            this.txtSheetNo.Text = "自动创建";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 88;
            this.label11.Text = "订单号:";
            // 
            // dtDemandDate
            // 
            this.dtDemandDate.CustomFormat = "yyyy-MM-dd";
            this.dtDemandDate.Location = new System.Drawing.Point(88, 44);
            this.dtDemandDate.Name = "dtDemandDate";
            this.dtDemandDate.Size = new System.Drawing.Size(112, 21);
            this.dtDemandDate.TabIndex = 3;
            this.dtDemandDate.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 87;
            this.label4.Text = "交货日期:";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.gridAttachment);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1053, 375);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "附件";
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
            this.colSize,
            this.colFileName});
            this.gridAttachment.ContextMenuStrip = this.mnu_Attachment;
            this.gridAttachment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAttachment.Location = new System.Drawing.Point(0, 0);
            this.gridAttachment.Name = "gridAttachment";
            this.gridAttachment.RowHeadersVisible = false;
            this.gridAttachment.RowTemplate.Height = 23;
            this.gridAttachment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAttachment.Size = new System.Drawing.Size(1053, 375);
            this.gridAttachment.TabIndex = 103;
            this.gridAttachment.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAttachment_CellDoubleClick);
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
            // 
            // colSize
            // 
            this.colSize.HeaderText = "文件大小";
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
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
            this.tabPage2.Size = new System.Drawing.Size(1053, 375);
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
            this.dataGridView1.Size = new System.Drawing.Size(1053, 375);
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
            this.btnPrint,
            this.btnUndoApprove,
            this.btnNullify});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1057, 56);
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
            this.btnPrint.Visible = false;
            // 
            // btnUndoApprove
            // 
            this.btnUndoApprove.Image = global::LJH.Inventory.UI.Properties.Resources.canceled;
            this.btnUndoApprove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndoApprove.Name = "btnUndoApprove";
            this.btnUndoApprove.Size = new System.Drawing.Size(60, 53);
            this.btnUndoApprove.Text = "取消审核";
            this.btnUndoApprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUndoApprove.Click += new System.EventHandler(this.btnUndoApprove_Click);
            // 
            // btnNullify
            // 
            this.btnNullify.Image = global::LJH.Inventory.UI.Properties.Resources.delete;
            this.btnNullify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNullify.Name = "btnNullify";
            this.btnNullify.Size = new System.Drawing.Size(54, 53);
            this.btnNullify.Text = "作废(&N)";
            this.btnNullify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNullify.Click += new System.EventHandler(this.btnNullify_Click);
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
            this.colProductID.HeaderText = "产品编号";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colProductName
            // 
            this.colProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colProductName.HeaderText = "名称";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colProductName.Width = 35;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "类别";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colSpecification
            // 
            this.colSpecification.HeaderText = "规格";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            this.colSpecification.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.colPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPrice.HeaderText = "单价";
            this.colPrice.Name = "colPrice";
            this.colPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCount
            // 
            dataGridViewCellStyle2.NullValue = "0";
            this.colCount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCount.HeaderText = "数量";
            this.colCount.Name = "colCount";
            this.colCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTotal
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTotal.HeaderText = "金额";
            this.colTotal.Name = "colTotal";
            this.colTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colReceived
            // 
            this.colReceived.HeaderText = "已收货";
            this.colReceived.Name = "colReceived";
            this.colReceived.ReadOnly = true;
            this.colReceived.Visible = false;
            // 
            // colOrderID
            // 
            this.colOrderID.HeaderText = "销售订单";
            this.colOrderID.Name = "colOrderID";
            this.colOrderID.ReadOnly = true;
            this.colOrderID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOrderID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "备注";
            this.colMemo.MinimumWidth = 150;
            this.colMemo.Name = "colMemo";
            this.colMemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMemo.Width = 161;
            // 
            // FrmPurchaseOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 401);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.LinkLabel lnkBuyer;
        private GeneralLibrary.WinformControl.DBCTextBox txtSupplier;
        private System.Windows.Forms.DateTimePicker dtSheetDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkSupplier;
        private GeneralLibrary.WinformControl.DBCTextBox txtBuyer;
        private System.Windows.Forms.DataGridView ItemsGrid;
        private GeneralLibrary.WinformControl.DBCTextBox txtSheetNo;
        private System.Windows.Forms.Label label11;
        private Controls.NullableDateTimePicker dtDemandDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnApprove;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cMnu_AddItem;
        private System.Windows.Forms.ToolStripMenuItem cMnu_RemoveItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFill;
        private System.Windows.Forms.ToolStripMenuItem cMnu_AddOrderRecord;
        private System.Windows.Forms.ContextMenuStrip mnu_Attachment;
        private System.Windows.Forms.ToolStripMenuItem mnu_AttachmentAdd;
        private System.Windows.Forms.ToolStripMenuItem mnu_AttachmentOpen;
        private System.Windows.Forms.ToolStripMenuItem mnu_AttachmentSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnu_AttachmentDelete;
        private System.Windows.Forms.DataGridView gridAttachment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdWithoutTax;
        private System.Windows.Forms.RadioButton rdWithTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUploadDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.ToolStripButton btnUndoApprove;
        private System.Windows.Forms.ToolStripButton btnNullify;
        private System.Windows.Forms.CheckBox chkShowState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
    }
}