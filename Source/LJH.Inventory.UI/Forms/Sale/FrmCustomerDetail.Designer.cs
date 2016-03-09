namespace LJH.Inventory.UI.Forms.Sale
{
    partial class FrmCustomerDetail
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_AddContact = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_DeleteContact = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.txtCity = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.txtAddress = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtWeb = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtPost = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtFax = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtTelphone = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lblCategory = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNation = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtCategory = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtName = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.GridView = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDefault = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colHowold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHobby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttachment)).BeginInit();
            this.mnu_Attachment.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(639, 283);
            this.btnClose.TabIndex = 10;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(530, 283);
            this.btnOk.TabIndex = 9;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_AddContact,
            this.mnu_DeleteContact});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 48);
            // 
            // mnu_AddContact
            // 
            this.mnu_AddContact.Name = "mnu_AddContact";
            this.mnu_AddContact.Size = new System.Drawing.Size(136, 22);
            this.mnu_AddContact.Text = "增加联系人";
            this.mnu_AddContact.Click += new System.EventHandler(this.mnu_AddContact_Click);
            // 
            // mnu_DeleteContact
            // 
            this.mnu_DeleteContact.Name = "mnu_DeleteContact";
            this.mnu_DeleteContact.Size = new System.Drawing.Size(136, 22);
            this.mnu_DeleteContact.Text = "删除联系人";
            this.mnu_DeleteContact.Click += new System.EventHandler(this.mnu_DeleteContact_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(717, 262);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label5);
            this.tabPage6.Controls.Add(this.txtMemo);
            this.tabPage6.Controls.Add(this.label10);
            this.tabPage6.Controls.Add(this.txtCity);
            this.tabPage6.Controls.Add(this.label9);
            this.tabPage6.Controls.Add(this.txtAddress);
            this.tabPage6.Controls.Add(this.label8);
            this.tabPage6.Controls.Add(this.txtWeb);
            this.tabPage6.Controls.Add(this.label7);
            this.tabPage6.Controls.Add(this.txtPost);
            this.tabPage6.Controls.Add(this.label6);
            this.tabPage6.Controls.Add(this.txtFax);
            this.tabPage6.Controls.Add(this.label2);
            this.tabPage6.Controls.Add(this.txtTelphone);
            this.tabPage6.Controls.Add(this.lblCategory);
            this.tabPage6.Controls.Add(this.label4);
            this.tabPage6.Controls.Add(this.txtNation);
            this.tabPage6.Controls.Add(this.txtCategory);
            this.tabPage6.Controls.Add(this.txtName);
            this.tabPage6.Controls.Add(this.label3);
            this.tabPage6.Controls.Add(this.txtID);
            this.tabPage6.Controls.Add(this.label1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(709, 236);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "基本资料";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 80;
            this.label5.Text = "备注";
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(77, 201);
            this.txtMemo.MaxLength = 100;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(377, 21);
            this.txtMemo.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(276, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 78;
            this.label10.Text = "地区";
            // 
            // txtCity
            // 
            this.txtCity.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCity.Location = new System.Drawing.Point(311, 76);
            this.txtCity.MaxLength = 100;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(143, 21);
            this.txtCity.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 76;
            this.label9.Text = "地址";
            // 
            // txtAddress
            // 
            this.txtAddress.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAddress.Location = new System.Drawing.Point(77, 170);
            this.txtAddress.MaxLength = 100;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(377, 21);
            this.txtAddress.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(276, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 74;
            this.label8.Text = "网址";
            // 
            // txtWeb
            // 
            this.txtWeb.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWeb.Location = new System.Drawing.Point(311, 139);
            this.txtWeb.MaxLength = 100;
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(143, 21);
            this.txtWeb.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 72;
            this.label7.Text = "邮政";
            // 
            // txtPost
            // 
            this.txtPost.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPost.Location = new System.Drawing.Point(77, 139);
            this.txtPost.MaxLength = 100;
            this.txtPost.Name = "txtPost";
            this.txtPost.Size = new System.Drawing.Size(143, 21);
            this.txtPost.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 70;
            this.label6.Text = "传真";
            // 
            // txtFax
            // 
            this.txtFax.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtFax.Location = new System.Drawing.Point(311, 108);
            this.txtFax.MaxLength = 100;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(143, 21);
            this.txtFax.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 68;
            this.label2.Text = "电话";
            // 
            // txtTelphone
            // 
            this.txtTelphone.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtTelphone.Location = new System.Drawing.Point(77, 108);
            this.txtTelphone.MaxLength = 100;
            this.txtTelphone.Name = "txtTelphone";
            this.txtTelphone.Size = new System.Drawing.Size(143, 21);
            this.txtTelphone.TabIndex = 5;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(252, 19);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(53, 12);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.TabStop = true;
            this.lblCategory.Text = "客户类别";
            this.lblCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCategory_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 61;
            this.label4.Text = "国家";
            // 
            // txtNation
            // 
            this.txtNation.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtNation.Location = new System.Drawing.Point(77, 76);
            this.txtNation.MaxLength = 100;
            this.txtNation.Name = "txtNation";
            this.txtNation.Size = new System.Drawing.Size(143, 21);
            this.txtNation.TabIndex = 3;
            // 
            // txtCategory
            // 
            this.txtCategory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCategory.Location = new System.Drawing.Point(311, 15);
            this.txtCategory.MaxLength = 100;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(143, 21);
            this.txtCategory.TabIndex = 1;
            this.txtCategory.DoubleClick += new System.EventHandler(this.txtCategory_DoubleClick);
            // 
            // txtName
            // 
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtName.Location = new System.Drawing.Point(77, 47);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(377, 21);
            this.txtName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 58;
            this.label3.Text = "公司名称";
            // 
            // txtID
            // 
            this.txtID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtID.Location = new System.Drawing.Point(77, 15);
            this.txtID.MaxLength = 100;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(143, 21);
            this.txtID.TabIndex = 11;
            this.txtID.Text = "自动创建";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 57;
            this.label1.Text = "客户编号";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(709, 236);
            this.tabPage1.TabIndex = 6;
            this.tabPage1.Text = "联系人";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // GridView
            // 
            this.GridView.AllowUserToAddRows = false;
            this.GridView.AllowUserToDeleteRows = false;
            this.GridView.AllowUserToResizeRows = false;
            this.GridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridView.BackgroundColor = System.Drawing.Color.White;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colPosition,
            this.colMobile,
            this.colTelphone,
            this.colQQ,
            this.colEmail,
            this.colDefault,
            this.colHowold,
            this.colBirthday,
            this.colHobby,
            this.colMemo});
            this.GridView.ContextMenuStrip = this.contextMenuStrip1;
            this.GridView.Location = new System.Drawing.Point(3, 3);
            this.GridView.Name = "GridView";
            this.GridView.RowHeadersVisible = false;
            this.GridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GridView.RowTemplate.Height = 23;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView.Size = new System.Drawing.Size(703, 230);
            this.GridView.TabIndex = 65;
            this.GridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellDoubleClick);
            this.GridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellEndEdit);
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colName.HeaderText = "姓名";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 54;
            // 
            // colPosition
            // 
            this.colPosition.HeaderText = "职位";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            // 
            // colMobile
            // 
            this.colMobile.HeaderText = "移动电话";
            this.colMobile.Name = "colMobile";
            this.colMobile.ReadOnly = true;
            // 
            // colTelphone
            // 
            this.colTelphone.HeaderText = "电话";
            this.colTelphone.Name = "colTelphone";
            this.colTelphone.ReadOnly = true;
            // 
            // colQQ
            // 
            this.colQQ.HeaderText = "QQ";
            this.colQQ.Name = "colQQ";
            this.colQQ.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Width = 60;
            // 
            // colDefault
            // 
            this.colDefault.HeaderText = "默认";
            this.colDefault.Name = "colDefault";
            this.colDefault.Width = 60;
            // 
            // colHowold
            // 
            this.colHowold.HeaderText = "年龄";
            this.colHowold.Name = "colHowold";
            this.colHowold.ReadOnly = true;
            this.colHowold.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHowold.Visible = false;
            this.colHowold.Width = 40;
            // 
            // colBirthday
            // 
            this.colBirthday.HeaderText = "生日";
            this.colBirthday.Name = "colBirthday";
            this.colBirthday.ReadOnly = true;
            this.colBirthday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBirthday.Visible = false;
            this.colBirthday.Width = 80;
            // 
            // colHobby
            // 
            this.colHobby.HeaderText = "爱好";
            this.colHobby.Name = "colHobby";
            this.colHobby.ReadOnly = true;
            this.colHobby.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHobby.Visible = false;
            // 
            // colMemo
            // 
            this.colMemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMemo.HeaderText = "备注";
            this.colMemo.MinimumWidth = 100;
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridAttachment);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(709, 236);
            this.tabPage2.TabIndex = 7;
            this.tabPage2.Text = "附件";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.gridAttachment.Size = new System.Drawing.Size(709, 236);
            this.gridAttachment.TabIndex = 100;
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
            this.colFileName.MinimumWidth = 250;
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
            // FrmCustomerDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 316);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmCustomerDetail";
            this.Text = "客户资料";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAttachment)).EndInit();
            this.mnu_Attachment.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddContact;
        private System.Windows.Forms.ToolStripMenuItem mnu_DeleteContact;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.LinkLabel lblCategory;
        private System.Windows.Forms.Label label4;
        private GeneralLibrary.WinformControl.DBCTextBox txtNation;
        private GeneralLibrary.WinformControl.DBCTextBox txtCategory;
        private GeneralLibrary.WinformControl.DBCTextBox txtName;
        private System.Windows.Forms.Label label3;
        private GeneralLibrary.WinformControl.DBCTextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.Label label6;
        private GeneralLibrary.WinformControl.DBCTextBox txtFax;
        private System.Windows.Forms.Label label2;
        private GeneralLibrary.WinformControl.DBCTextBox txtTelphone;
        private System.Windows.Forms.Label label9;
        private GeneralLibrary.WinformControl.DBCTextBox txtAddress;
        private System.Windows.Forms.Label label8;
        private GeneralLibrary.WinformControl.DBCTextBox txtWeb;
        private System.Windows.Forms.Label label7;
        private GeneralLibrary.WinformControl.DBCTextBox txtPost;
        private System.Windows.Forms.Label label10;
        private GeneralLibrary.WinformControl.DBCTextBox txtCity;
        private System.Windows.Forms.Label label5;
        private GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ContextMenuStrip mnu_Attachment;
        private System.Windows.Forms.ToolStripMenuItem mnu_AttachmentAdd;
        private System.Windows.Forms.ToolStripMenuItem mnu_AttachmentOpen;
        private System.Windows.Forms.ToolStripMenuItem mnu_AttachmentSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnu_AttachmentDelete;
        private System.Windows.Forms.DataGridView gridAttachment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUploadDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDefault;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHowold;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBirthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHobby;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
    }
}