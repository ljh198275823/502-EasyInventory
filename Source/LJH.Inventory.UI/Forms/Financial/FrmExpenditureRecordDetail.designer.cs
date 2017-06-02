namespace LJH.Inventory.UI.Forms.Financial
{
    partial class FrmExpenditureRecordDetail
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtPayee = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtAccount = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkAccout = new System.Windows.Forms.LinkLabel();
            this.txtRequest = new System.Windows.Forms.TextBox();
            this.lnkRequest = new System.Windows.Forms.LinkLabel();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.lnkCategory = new System.Windows.Forms.LinkLabel();
            this.txtSheetNo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtAmount = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.dtSheetDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.btnUndoApprove = new System.Windows.Forms.ToolStripButton();
            this.btnNullify = new System.Windows.Forms.ToolStripButton();
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
            this.btnClose.Location = new System.Drawing.Point(406, 273);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(295, 273);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-1, 59);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(496, 192);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtPayee);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtAccount);
            this.tabPage1.Controls.Add(this.lnkAccout);
            this.tabPage1.Controls.Add(this.txtRequest);
            this.tabPage1.Controls.Add(this.lnkRequest);
            this.tabPage1.Controls.Add(this.txtCategory);
            this.tabPage1.Controls.Add(this.lnkCategory);
            this.tabPage1.Controls.Add(this.txtSheetNo);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.txtMemo);
            this.tabPage1.Controls.Add(this.txtAmount);
            this.tabPage1.Controls.Add(this.dtSheetDate);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(488, 166);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本资料";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtPayee
            // 
            this.txtPayee.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPayee.Location = new System.Drawing.Point(313, 74);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.Size = new System.Drawing.Size(158, 21);
            this.txtPayee.TabIndex = 104;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 105;
            this.label4.Text = "对方账号";
            // 
            // txtAccount
            // 
            this.txtAccount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAccount.Location = new System.Drawing.Point(72, 74);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.ReadOnly = true;
            this.txtAccount.Size = new System.Drawing.Size(160, 21);
            this.txtAccount.TabIndex = 103;
            // 
            // lnkAccout
            // 
            this.lnkAccout.Location = new System.Drawing.Point(7, 76);
            this.lnkAccout.Name = "lnkAccout";
            this.lnkAccout.Size = new System.Drawing.Size(60, 17);
            this.lnkAccout.TabIndex = 102;
            this.lnkAccout.TabStop = true;
            this.lnkAccout.Text = "付款账号";
            this.lnkAccout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkAccout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAccout_LinkClicked);
            // 
            // txtRequest
            // 
            this.txtRequest.Location = new System.Drawing.Point(72, 105);
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.ReadOnly = true;
            this.txtRequest.Size = new System.Drawing.Size(159, 21);
            this.txtRequest.TabIndex = 9;
            this.txtRequest.DoubleClick += new System.EventHandler(this.txtRequest_DoubleClick);
            // 
            // lnkRequest
            // 
            this.lnkRequest.AutoSize = true;
            this.lnkRequest.Location = new System.Drawing.Point(25, 109);
            this.lnkRequest.Name = "lnkRequest";
            this.lnkRequest.Size = new System.Drawing.Size(41, 12);
            this.lnkRequest.TabIndex = 8;
            this.lnkRequest.TabStop = true;
            this.lnkRequest.Text = "申请人";
            this.lnkRequest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRequest_LinkClicked);
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(73, 42);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(159, 21);
            this.txtCategory.TabIndex = 2;
            this.txtCategory.DoubleClick += new System.EventHandler(this.txtCategory_DoubleClick);
            // 
            // lnkCategory
            // 
            this.lnkCategory.AutoSize = true;
            this.lnkCategory.Location = new System.Drawing.Point(14, 46);
            this.lnkCategory.Name = "lnkCategory";
            this.lnkCategory.Size = new System.Drawing.Size(53, 12);
            this.lnkCategory.TabIndex = 1;
            this.lnkCategory.TabStop = true;
            this.lnkCategory.Text = "费用类别";
            this.lnkCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCategory_LinkClicked);
            // 
            // txtSheetNo
            // 
            this.txtSheetNo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSheetNo.Location = new System.Drawing.Point(73, 12);
            this.txtSheetNo.Name = "txtSheetNo";
            this.txtSheetNo.Size = new System.Drawing.Size(159, 21);
            this.txtSheetNo.TabIndex = 89;
            this.txtSheetNo.Text = "自动创建";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 90;
            this.label11.Text = "支出单号";
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(72, 134);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(399, 21);
            this.txtMemo.TabIndex = 10;
            // 
            // txtAmount
            // 
            this.txtAmount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAmount.Location = new System.Drawing.Point(313, 42);
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
            this.txtAmount.Size = new System.Drawing.Size(159, 21);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.Text = "0.00";
            // 
            // dtSheetDate
            // 
            this.dtSheetDate.Location = new System.Drawing.Point(313, 12);
            this.dtSheetDate.Name = "dtSheetDate";
            this.dtSheetDate.Size = new System.Drawing.Size(159, 21);
            this.dtSheetDate.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 58;
            this.label5.Text = "备注";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(277, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 57;
            this.label7.Text = "日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 56;
            this.label2.Text = "支出金额";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.gridAttachment);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(488, 166);
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
            this.gridAttachment.Size = new System.Drawing.Size(488, 166);
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
            this.tabPage2.Size = new System.Drawing.Size(488, 166);
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
            this.dataGridView1.Size = new System.Drawing.Size(488, 166);
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
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnApprove,
            this.btnUndoApprove,
            this.btnNullify});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(501, 56);
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
            // FrmExpenditureRecordDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 251);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmExpenditureRecordDetail";
            this.Text = "公司管理费用明细";
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

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private GeneralLibrary.WinformControl.DecimalTextBox txtAmount;
        private System.Windows.Forms.DateTimePicker dtSheetDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFill;
        private GeneralLibrary.WinformControl.DBCTextBox txtSheetNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRequest;
        private System.Windows.Forms.LinkLabel lnkRequest;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.LinkLabel lnkCategory;
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnApprove;
        private System.Windows.Forms.ToolStripButton btnUndoApprove;
        private System.Windows.Forms.ToolStripButton btnNullify;
        private GeneralLibrary.WinformControl.DBCTextBox txtAccount;
        private System.Windows.Forms.LinkLabel lnkAccout;
        private GeneralLibrary.WinformControl.DBCTextBox txtPayee;
        private System.Windows.Forms.Label label4;

    }
}