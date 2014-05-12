namespace LJH.Inventory.UI.Forms.General
{
    partial class FrmRelatedCompanyDetail
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
            this.txtName = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtTelephone = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtFax = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.传真 = new System.Windows.Forms.Label();
            this.txtPostalCode = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNation = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtCategory = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.GridView = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_AddContact = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_DeleteContact = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCategory = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(576, 334);
            this.btnClose.TabIndex = 12;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(467, 334);
            this.btnOk.TabIndex = 11;
            // 
            // txtName
            // 
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtName.Location = new System.Drawing.Point(298, 12);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(367, 21);
            this.txtName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "公司名称";
            // 
            // txtID
            // 
            this.txtID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtID.Location = new System.Drawing.Point(70, 10);
            this.txtID.MaxLength = 100;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(143, 21);
            this.txtID.TabIndex = 13;
            this.txtID.Text = "自动创建";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "客户编号";
            // 
            // txtTelephone
            // 
            this.txtTelephone.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtTelephone.Location = new System.Drawing.Point(70, 69);
            this.txtTelephone.MaxLength = 100;
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(143, 21);
            this.txtTelephone.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "联系电话";
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(70, 129);
            this.txtMemo.MaxLength = 200;
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(596, 47);
            this.txtMemo.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "备注";
            // 
            // txtAddress
            // 
            this.txtAddress.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAddress.Location = new System.Drawing.Point(70, 101);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(595, 21);
            this.txtAddress.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "地址";
            // 
            // txtFax
            // 
            this.txtFax.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtFax.Location = new System.Drawing.Point(298, 70);
            this.txtFax.MaxLength = 100;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(143, 21);
            this.txtFax.TabIndex = 5;
            // 
            // 传真
            // 
            this.传真.AutoSize = true;
            this.传真.Location = new System.Drawing.Point(263, 73);
            this.传真.Name = "传真";
            this.传真.Size = new System.Drawing.Size(29, 12);
            this.传真.TabIndex = 29;
            this.传真.Text = "传真";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPostalCode.Location = new System.Drawing.Point(522, 69);
            this.txtPostalCode.MaxLength = 100;
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(143, 21);
            this.txtPostalCode.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(464, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 38;
            this.label12.Text = "邮政编码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 49;
            this.label4.Text = "国别";
            // 
            // txtNation
            // 
            this.txtNation.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtNation.Location = new System.Drawing.Point(298, 40);
            this.txtNation.MaxLength = 100;
            this.txtNation.Name = "txtNation";
            this.txtNation.Size = new System.Drawing.Size(143, 21);
            this.txtNation.TabIndex = 3;
            // 
            // txtCategory
            // 
            this.txtCategory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCategory.Location = new System.Drawing.Point(70, 40);
            this.txtCategory.MaxLength = 100;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(143, 21);
            this.txtCategory.TabIndex = 2;
            this.txtCategory.DoubleClick += new System.EventHandler(this.txtCategory_DoubleClick);
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
            this.colEmail,
            this.colQQ,
            this.colMemo});
            this.GridView.ContextMenuStrip = this.contextMenuStrip1;
            this.GridView.Location = new System.Drawing.Point(14, 182);
            this.GridView.Name = "GridView";
            this.GridView.RowHeadersVisible = false;
            this.GridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GridView.RowTemplate.Height = 23;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView.Size = new System.Drawing.Size(651, 140);
            this.GridView.TabIndex = 9;
            this.GridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellDoubleClick);
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
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
            // colEmail
            // 
            this.colEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Width = 60;
            // 
            // colQQ
            // 
            this.colQQ.HeaderText = "QQ";
            this.colQQ.Name = "colQQ";
            this.colQQ.ReadOnly = true;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
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
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(12, 44);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(53, 12);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.TabStop = true;
            this.lblCategory.Text = "客户类别";
            this.lblCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCategory_LinkClicked);
            // 
            // FrmRelatedCompanyDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 370);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.GridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNation);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtPostalCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.传真);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Name = "FrmRelatedCompanyDetail";
            this.Text = "客户资料";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtID, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtTelephone, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtAddress, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtMemo, 0);
            this.Controls.SetChildIndex(this.传真, 0);
            this.Controls.SetChildIndex(this.txtFax, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtPostalCode, 0);
            this.Controls.SetChildIndex(this.txtCategory, 0);
            this.Controls.SetChildIndex(this.txtNation, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.GridView, 0);
            this.Controls.SetChildIndex(this.lblCategory, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LJH.GeneralLibrary.WinformControl.DBCTextBox  txtName;
        private System.Windows.Forms.Label label3;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox  txtID;
        private System.Windows.Forms.Label label1;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox  txtTelephone;
        private System.Windows.Forms.Label label2;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox  txtMemo;
        private System.Windows.Forms.Label label5;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox  txtAddress;
        private System.Windows.Forms.Label label6;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtFax;
        private System.Windows.Forms.Label 传真;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtPostalCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private GeneralLibrary.WinformControl.DBCTextBox txtNation;
        private GeneralLibrary.WinformControl.DBCTextBox txtCategory;
        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddContact;
        private System.Windows.Forms.ToolStripMenuItem mnu_DeleteContact;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        private System.Windows.Forms.LinkLabel lblCategory;
    }
}