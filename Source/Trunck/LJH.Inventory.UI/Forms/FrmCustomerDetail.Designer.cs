namespace LJH.Inventory.UI.Forms
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
            this.GridView = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSkype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHowold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHobby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lnkBusinessMan = new System.Windows.Forms.LinkLabel();
            this.lblCategory = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNation = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtCategory = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtBusinessMan = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtMedia = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCreater = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(685, 290);
            this.btnClose.TabIndex = 10;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(576, 290);
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
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(765, 255);
            this.tabControl1.TabIndex = 51;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label5);
            this.tabPage6.Controls.Add(this.txtCreater);
            this.tabPage6.Controls.Add(this.GridView);
            this.tabPage6.Controls.Add(this.lnkBusinessMan);
            this.tabPage6.Controls.Add(this.lblCategory);
            this.tabPage6.Controls.Add(this.label4);
            this.tabPage6.Controls.Add(this.txtNation);
            this.tabPage6.Controls.Add(this.txtCategory);
            this.tabPage6.Controls.Add(this.txtBusinessMan);
            this.tabPage6.Controls.Add(this.txtMedia);
            this.tabPage6.Controls.Add(this.label2);
            this.tabPage6.Controls.Add(this.txtName);
            this.tabPage6.Controls.Add(this.label3);
            this.tabPage6.Controls.Add(this.txtID);
            this.tabPage6.Controls.Add(this.label1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(757, 229);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "基本资料";
            this.tabPage6.UseVisualStyleBackColor = true;
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
            this.colSkype,
            this.colHowold,
            this.colBirthday,
            this.colHobby,
            this.colMemo});
            this.GridView.ContextMenuStrip = this.contextMenuStrip1;
            this.GridView.Location = new System.Drawing.Point(6, 99);
            this.GridView.Name = "GridView";
            this.GridView.RowHeadersVisible = false;
            this.GridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GridView.RowTemplate.Height = 23;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView.Size = new System.Drawing.Size(745, 121);
            this.GridView.TabIndex = 64;
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
            // colSkype
            // 
            this.colSkype.HeaderText = "Skype";
            this.colSkype.Name = "colSkype";
            this.colSkype.ReadOnly = true;
            // 
            // colHowold
            // 
            this.colHowold.HeaderText = "年龄";
            this.colHowold.Name = "colHowold";
            this.colHowold.ReadOnly = true;
            this.colHowold.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHowold.Width = 40;
            // 
            // colBirthday
            // 
            this.colBirthday.HeaderText = "生日";
            this.colBirthday.Name = "colBirthday";
            this.colBirthday.ReadOnly = true;
            this.colBirthday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBirthday.Width = 80;
            // 
            // colHobby
            // 
            this.colHobby.HeaderText = "爱好";
            this.colHobby.Name = "colHobby";
            this.colHobby.ReadOnly = true;
            this.colHobby.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            // 
            // lnkBusinessMan
            // 
            this.lnkBusinessMan.AutoSize = true;
            this.lnkBusinessMan.Location = new System.Drawing.Point(248, 76);
            this.lnkBusinessMan.Name = "lnkBusinessMan";
            this.lnkBusinessMan.Size = new System.Drawing.Size(65, 12);
            this.lnkBusinessMan.TabIndex = 63;
            this.lnkBusinessMan.TabStop = true;
            this.lnkBusinessMan.Text = "客户负责人";
            this.lnkBusinessMan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBusinessMan_LinkClicked);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(13, 47);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(53, 12);
            this.lblCategory.TabIndex = 62;
            this.lblCategory.TabStop = true;
            this.lblCategory.Text = "客户类别";
            this.lblCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCategory_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 61;
            this.label4.Text = "国别";
            // 
            // txtNation
            // 
            this.txtNation.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtNation.Location = new System.Drawing.Point(319, 42);
            this.txtNation.MaxLength = 100;
            this.txtNation.Name = "txtNation";
            this.txtNation.Size = new System.Drawing.Size(143, 21);
            this.txtNation.TabIndex = 54;
            // 
            // txtCategory
            // 
            this.txtCategory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCategory.Location = new System.Drawing.Point(71, 43);
            this.txtCategory.MaxLength = 100;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(143, 21);
            this.txtCategory.TabIndex = 53;
            // 
            // txtBusinessMan
            // 
            this.txtBusinessMan.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtBusinessMan.Location = new System.Drawing.Point(319, 72);
            this.txtBusinessMan.MaxLength = 100;
            this.txtBusinessMan.Name = "txtBusinessMan";
            this.txtBusinessMan.Size = new System.Drawing.Size(143, 21);
            this.txtBusinessMan.TabIndex = 56;
            // 
            // txtMedia
            // 
            this.txtMedia.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMedia.Location = new System.Drawing.Point(71, 72);
            this.txtMedia.MaxLength = 100;
            this.txtMedia.Name = "txtMedia";
            this.txtMedia.Size = new System.Drawing.Size(143, 21);
            this.txtMedia.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 59;
            this.label2.Text = "信息来源";
            // 
            // txtName
            // 
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtName.Location = new System.Drawing.Point(319, 15);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(425, 21);
            this.txtName.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 58;
            this.label3.Text = "公司名称";
            // 
            // txtID
            // 
            this.txtID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtID.Location = new System.Drawing.Point(71, 13);
            this.txtID.MaxLength = 100;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(143, 21);
            this.txtID.TabIndex = 51;
            this.txtID.Text = "自动创建";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 57;
            this.label1.Text = "客户编号";
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(757, 229);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "联系人";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(757, 229);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "订单";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(757, 229);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "收款记录";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(757, 229);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "报价";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(757, 229);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "往来沟通";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(502, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 66;
            this.label5.Text = "创建";
            // 
            // txtCreater
            // 
            this.txtCreater.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCreater.Location = new System.Drawing.Point(538, 72);
            this.txtCreater.MaxLength = 100;
            this.txtCreater.Name = "txtCreater";
            this.txtCreater.Size = new System.Drawing.Size(143, 21);
            this.txtCreater.TabIndex = 65;
            // 
            // FrmCustomerDetail
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(781, 326);
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
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddContact;
        private System.Windows.Forms.ToolStripMenuItem mnu_DeleteContact;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.LinkLabel lblCategory;
        private System.Windows.Forms.Label label4;
        private GeneralLibrary.WinformControl.DBCTextBox txtNation;
        private GeneralLibrary.WinformControl.DBCTextBox txtCategory;
        private GeneralLibrary.WinformControl.DBCTextBox txtBusinessMan;
        private GeneralLibrary.WinformControl.DBCTextBox txtMedia;
        private System.Windows.Forms.Label label2;
        private GeneralLibrary.WinformControl.DBCTextBox txtName;
        private System.Windows.Forms.Label label3;
        private GeneralLibrary.WinformControl.DBCTextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkBusinessMan;
        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSkype;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHowold;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBirthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHobby;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        private System.Windows.Forms.Label label5;
        private GeneralLibrary.WinformControl.DBCTextBox txtCreater;
    }
}