﻿namespace LJH.Inventory.UI.Forms.Financial
{
    partial class Frm退款
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
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtSheetDate = new System.Windows.Forms.DateTimePicker();
            this.txtAmount = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txt手续费 = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txt手续费类别 = new System.Windows.Forms.TextBox();
            this.lnk手续费类别 = new System.Windows.Forms.LinkLabel();
            this.txt管理费用类别 = new System.Windows.Forms.TextBox();
            this.lnk管理费用类别 = new System.Windows.Forms.LinkLabel();
            this.rd计为管理费用 = new System.Windows.Forms.RadioButton();
            this.rd增加客户应收 = new System.Windows.Forms.RadioButton();
            this.chk公账 = new System.Windows.Forms.CheckBox();
            this.lbl大写 = new System.Windows.Forms.Label();
            this.dtPaidDate = new LJH.Inventory.UI.Controls.NullableDateTimePicker(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkCustomer = new System.Windows.Forms.LinkLabel();
            this.txtPayer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtAccount = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkAccout = new System.Windows.Forms.LinkLabel();
            this.txtID = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
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
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnApprove = new System.Windows.Forms.ToolStripButton();
            this.btnUndoApprove = new System.Windows.Forms.ToolStripButton();
            this.btnNullify = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblSheetState = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.btnClose.Location = new System.Drawing.Point(506, 408);
            this.btnClose.TabIndex = 10;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(401, 408);
            this.btnOk.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(312, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 32;
            this.label7.Text = "日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "金额";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 36;
            this.label5.Text = "备注";
            // 
            // dtSheetDate
            // 
            this.dtSheetDate.Location = new System.Drawing.Point(346, 13);
            this.dtSheetDate.Name = "dtSheetDate";
            this.dtSheetDate.Size = new System.Drawing.Size(164, 21);
            this.dtSheetDate.TabIndex = 0;
            // 
            // txtAmount
            // 
            this.txtAmount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAmount.Location = new System.Drawing.Point(97, 111);
            this.txtAmount.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtAmount.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PointCount = 2;
            this.txtAmount.Size = new System.Drawing.Size(163, 21);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(97, 232);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(414, 21);
            this.txtMemo.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(586, 324);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txt手续费);
            this.tabPage1.Controls.Add(this.txt手续费类别);
            this.tabPage1.Controls.Add(this.lnk手续费类别);
            this.tabPage1.Controls.Add(this.txt管理费用类别);
            this.tabPage1.Controls.Add(this.lnk管理费用类别);
            this.tabPage1.Controls.Add(this.rd计为管理费用);
            this.tabPage1.Controls.Add(this.rd增加客户应收);
            this.tabPage1.Controls.Add(this.chk公账);
            this.tabPage1.Controls.Add(this.lbl大写);
            this.tabPage1.Controls.Add(this.dtPaidDate);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtCustomer);
            this.tabPage1.Controls.Add(this.lnkCustomer);
            this.tabPage1.Controls.Add(this.txtPayer);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtAccount);
            this.tabPage1.Controls.Add(this.lnkAccout);
            this.tabPage1.Controls.Add(this.txtID);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtMemo);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtAmount);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.dtSheetDate);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(578, 298);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本资料";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 139;
            this.label3.Text = "手续费金额";
            // 
            // txt手续费
            // 
            this.txt手续费.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txt手续费.Location = new System.Drawing.Point(381, 265);
            this.txt手续费.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txt手续费.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt手续费.Name = "txt手续费";
            this.txt手续费.PointCount = 2;
            this.txt手续费.Size = new System.Drawing.Size(130, 21);
            this.txt手续费.TabIndex = 138;
            this.txt手续费.Text = "0.00";
            // 
            // txt手续费类别
            // 
            this.txt手续费类别.Location = new System.Drawing.Point(97, 265);
            this.txt手续费类别.Name = "txt手续费类别";
            this.txt手续费类别.ReadOnly = true;
            this.txt手续费类别.Size = new System.Drawing.Size(164, 21);
            this.txt手续费类别.TabIndex = 137;
            this.txt手续费类别.DoubleClick += new System.EventHandler(this.txt手续费类别_DoubleClick);
            // 
            // lnk手续费类别
            // 
            this.lnk手续费类别.AutoSize = true;
            this.lnk手续费类别.Location = new System.Drawing.Point(25, 269);
            this.lnk手续费类别.Name = "lnk手续费类别";
            this.lnk手续费类别.Size = new System.Drawing.Size(65, 12);
            this.lnk手续费类别.TabIndex = 136;
            this.lnk手续费类别.TabStop = true;
            this.lnk手续费类别.Text = "手续费类别";
            this.lnk手续费类别.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk手续费类别_LinkClicked);
            // 
            // txt管理费用类别
            // 
            this.txt管理费用类别.Enabled = false;
            this.txt管理费用类别.Location = new System.Drawing.Point(276, 201);
            this.txt管理费用类别.Name = "txt管理费用类别";
            this.txt管理费用类别.ReadOnly = true;
            this.txt管理费用类别.Size = new System.Drawing.Size(159, 21);
            this.txt管理费用类别.TabIndex = 135;
            this.txt管理费用类别.DoubleClick += new System.EventHandler(this.txt管理费用类别_DoubleClick);
            // 
            // lnk管理费用类别
            // 
            this.lnk管理费用类别.AutoSize = true;
            this.lnk管理费用类别.Enabled = false;
            this.lnk管理费用类别.Location = new System.Drawing.Point(217, 205);
            this.lnk管理费用类别.Name = "lnk管理费用类别";
            this.lnk管理费用类别.Size = new System.Drawing.Size(53, 12);
            this.lnk管理费用类别.TabIndex = 134;
            this.lnk管理费用类别.TabStop = true;
            this.lnk管理费用类别.Text = "费用类别";
            this.lnk管理费用类别.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk管理费用类别_LinkClicked);
            // 
            // rd计为管理费用
            // 
            this.rd计为管理费用.AutoSize = true;
            this.rd计为管理费用.Location = new System.Drawing.Point(102, 203);
            this.rd计为管理费用.Name = "rd计为管理费用";
            this.rd计为管理费用.Size = new System.Drawing.Size(95, 16);
            this.rd计为管理费用.TabIndex = 133;
            this.rd计为管理费用.TabStop = true;
            this.rd计为管理费用.Text = "计为管理费用";
            this.rd计为管理费用.UseVisualStyleBackColor = true;
            // 
            // rd增加客户应收
            // 
            this.rd增加客户应收.AutoSize = true;
            this.rd增加客户应收.Location = new System.Drawing.Point(102, 172);
            this.rd增加客户应收.Name = "rd增加客户应收";
            this.rd增加客户应收.Size = new System.Drawing.Size(107, 16);
            this.rd增加客户应收.TabIndex = 132;
            this.rd增加客户应收.TabStop = true;
            this.rd增加客户应收.Text = "退回到应收账款";
            this.rd增加客户应收.UseVisualStyleBackColor = true;
            // 
            // chk公账
            // 
            this.chk公账.AutoSize = true;
            this.chk公账.ForeColor = System.Drawing.Color.Red;
            this.chk公账.Location = new System.Drawing.Point(218, 172);
            this.chk公账.Name = "chk公账";
            this.chk公账.Size = new System.Drawing.Size(48, 16);
            this.chk公账.TabIndex = 131;
            this.chk公账.Text = "公账";
            this.chk公账.UseVisualStyleBackColor = true;
            // 
            // lbl大写
            // 
            this.lbl大写.AutoSize = true;
            this.lbl大写.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl大写.ForeColor = System.Drawing.Color.Blue;
            this.lbl大写.Location = new System.Drawing.Point(288, 115);
            this.lbl大写.Name = "lbl大写";
            this.lbl大写.Size = new System.Drawing.Size(18, 12);
            this.lbl大写.TabIndex = 115;
            this.lbl大写.Text = "整";
            // 
            // dtPaidDate
            // 
            this.dtPaidDate.Location = new System.Drawing.Point(97, 142);
            this.dtPaidDate.Name = "dtPaidDate";
            this.dtPaidDate.Size = new System.Drawing.Size(163, 21);
            this.dtPaidDate.TabIndex = 111;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 110;
            this.label1.Text = "退款日期";
            // 
            // txtCustomer
            // 
            this.txtCustomer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCustomer.Location = new System.Drawing.Point(97, 46);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(413, 21);
            this.txtCustomer.TabIndex = 104;
            // 
            // lnkCustomer
            // 
            this.lnkCustomer.Location = new System.Drawing.Point(29, 50);
            this.lnkCustomer.Name = "lnkCustomer";
            this.lnkCustomer.Size = new System.Drawing.Size(60, 17);
            this.lnkCustomer.TabIndex = 103;
            this.lnkCustomer.TabStop = true;
            this.lnkCustomer.Text = "客户";
            this.lnkCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomer_LinkClicked);
            // 
            // txtPayer
            // 
            this.txtPayer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPayer.Location = new System.Drawing.Point(346, 80);
            this.txtPayer.Name = "txtPayer";
            this.txtPayer.Size = new System.Drawing.Size(161, 21);
            this.txtPayer.TabIndex = 101;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 102;
            this.label4.Text = "对方账号";
            // 
            // txtAccount
            // 
            this.txtAccount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAccount.Location = new System.Drawing.Point(97, 80);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.ReadOnly = true;
            this.txtAccount.Size = new System.Drawing.Size(163, 21);
            this.txtAccount.TabIndex = 100;
            // 
            // lnkAccout
            // 
            this.lnkAccout.Location = new System.Drawing.Point(29, 82);
            this.lnkAccout.Name = "lnkAccout";
            this.lnkAccout.Size = new System.Drawing.Size(60, 17);
            this.lnkAccout.TabIndex = 99;
            this.lnkAccout.TabStop = true;
            this.lnkAccout.Text = "退款账号";
            this.lnkAccout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkAccout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAccout_LinkClicked);
            // 
            // txtID
            // 
            this.txtID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtID.Location = new System.Drawing.Point(97, 13);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(164, 21);
            this.txtID.TabIndex = 91;
            this.txtID.Text = "自动创建";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 92;
            this.label11.Text = "付款单号";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.gridAttachment);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(578, 298);
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
            this.colSize,
            this.colFileName});
            this.gridAttachment.ContextMenuStrip = this.mnu_Attachment;
            this.gridAttachment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAttachment.Location = new System.Drawing.Point(0, 0);
            this.gridAttachment.Name = "gridAttachment";
            this.gridAttachment.RowHeadersVisible = false;
            this.gridAttachment.RowTemplate.Height = 23;
            this.gridAttachment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAttachment.Size = new System.Drawing.Size(578, 298);
            this.gridAttachment.TabIndex = 102;
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
            this.tabPage2.Size = new System.Drawing.Size(578, 298);
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
            this.colMemo});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(578, 298);
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
            // 
            // colOperator
            // 
            this.colOperator.HeaderText = "操作员";
            this.colOperator.Name = "colOperator";
            this.colOperator.ReadOnly = true;
            // 
            // colMemo
            // 
            this.colMemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMemo.HeaderText = "";
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnApprove,
            this.btnUndoApprove,
            this.btnNullify,
            this.toolStripSeparator1,
            this.lblSheetState,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(593, 56);
            this.toolStrip1.TabIndex = 93;
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
            this.btnApprove.Visible = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnUndoApprove
            // 
            this.btnUndoApprove.Image = global::LJH.Inventory.UI.Properties.Resources.canceled;
            this.btnUndoApprove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndoApprove.Name = "btnUndoApprove";
            this.btnUndoApprove.Size = new System.Drawing.Size(60, 53);
            this.btnUndoApprove.Text = "取消审核";
            this.btnUndoApprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUndoApprove.Visible = false;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 56);
            // 
            // lblSheetState
            // 
            this.lblSheetState.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblSheetState.Name = "lblSheetState";
            this.lblSheetState.Size = new System.Drawing.Size(112, 53);
            this.lblSheetState.Text = "状态：新增";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 56);
            // 
            // Frm退款
            // 
            this.AcceptButton = null;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 389);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm退款";
            this.Text = "退款";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtSheetDate;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtAmount;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private GeneralLibrary.WinformControl.DBCTextBox txtID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView gridAttachment;
        private System.Windows.Forms.ContextMenuStrip mnu_Attachment;
        private System.Windows.Forms.ToolStripMenuItem mnu_AttachmentAdd;
        private System.Windows.Forms.ToolStripMenuItem mnu_AttachmentOpen;
        private System.Windows.Forms.ToolStripMenuItem mnu_AttachmentSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnu_AttachmentDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUploadDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnApprove;
        private System.Windows.Forms.ToolStripButton btnUndoApprove;
        private System.Windows.Forms.ToolStripButton btnNullify;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        private GeneralLibrary.WinformControl.DBCTextBox txtAccount;
        private System.Windows.Forms.LinkLabel lnkAccout;
        private GeneralLibrary.WinformControl.DBCTextBox txtPayer;
        private System.Windows.Forms.Label label4;
        private GeneralLibrary.WinformControl.DBCTextBox txtCustomer;
        private System.Windows.Forms.LinkLabel lnkCustomer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblSheetState;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private Controls.NullableDateTimePicker dtPaidDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl大写;
        private System.Windows.Forms.Label label3;
        private GeneralLibrary.WinformControl.DecimalTextBox txt手续费;
        private System.Windows.Forms.TextBox txt手续费类别;
        private System.Windows.Forms.LinkLabel lnk手续费类别;
        private System.Windows.Forms.TextBox txt管理费用类别;
        private System.Windows.Forms.LinkLabel lnk管理费用类别;
        private System.Windows.Forms.RadioButton rd计为管理费用;
        private System.Windows.Forms.RadioButton rd增加客户应收;
        private System.Windows.Forms.CheckBox chk公账;
    }
}