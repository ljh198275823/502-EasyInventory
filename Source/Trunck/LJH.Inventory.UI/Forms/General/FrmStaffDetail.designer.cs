namespace LJH.Inventory.UI.Forms.General
{
    partial class FrmStaffDetail
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
            this.dtHireDate = new LJH.Inventory.UI.Controls.NullableDateTimePicker(this.components);
            this.btnChangePwd = new System.Windows.Forms.Button();
            this.comRoleList = new LJH.Inventory.UI.Controls.RoleComboBox(this.components);
            this.txtPassword = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtOperatorID = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.lnkDepartment = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdFemale = new System.Windows.Forms.RadioButton();
            this.rdMale = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdResign = new System.Windows.Forms.RadioButton();
            this.rdUnResign = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDelPhoto = new System.Windows.Forms.Button();
            this.btnBrowserPhoto = new System.Windows.Forms.Button();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserPosition = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtCertificate = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(466, 277);
            this.btnClose.TabIndex = 17;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(357, 277);
            this.btnOk.TabIndex = 16;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(9, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(535, 259);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtHireDate);
            this.tabPage1.Controls.Add(this.btnChangePwd);
            this.tabPage1.Controls.Add(this.comRoleList);
            this.tabPage1.Controls.Add(this.txtPassword);
            this.tabPage1.Controls.Add(this.txtOperatorID);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtDepartment);
            this.tabPage1.Controls.Add(this.lnkDepartment);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.btnDelPhoto);
            this.tabPage1.Controls.Add(this.btnBrowserPhoto);
            this.tabPage1.Controls.Add(this.picPhoto);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtUserPosition);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtCertificate);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(527, 233);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本资料";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtHireDate
            // 
            this.dtHireDate.CustomFormat = "yyyy-MM-dd";
            this.dtHireDate.Location = new System.Drawing.Point(59, 107);
            this.dtHireDate.Name = "dtHireDate";
            this.dtHireDate.Size = new System.Drawing.Size(121, 21);
            this.dtHireDate.TabIndex = 78;
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Location = new System.Drawing.Point(326, 139);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(28, 23);
            this.btnChangePwd.TabIndex = 12;
            this.btnChangePwd.Text = "改";
            this.btnChangePwd.UseVisualStyleBackColor = true;
            // 
            // comRoleList
            // 
            this.comRoleList.FormattingEnabled = true;
            this.comRoleList.Location = new System.Drawing.Point(59, 169);
            this.comRoleList.Name = "comRoleList";
            this.comRoleList.Size = new System.Drawing.Size(121, 20);
            this.comRoleList.TabIndex = 13;
            // 
            // txtPassword
            // 
            this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPassword.Location = new System.Drawing.Point(227, 139);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(96, 21);
            this.txtPassword.TabIndex = 11;
            // 
            // txtOperatorID
            // 
            this.txtOperatorID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtOperatorID.Location = new System.Drawing.Point(59, 139);
            this.txtOperatorID.Name = "txtOperatorID";
            this.txtOperatorID.Size = new System.Drawing.Size(121, 21);
            this.txtOperatorID.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 77;
            this.label2.Text = "角色";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 75;
            this.label5.Text = "密码";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 74;
            this.label9.Text = "登录ID";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(59, 41);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(121, 21);
            this.txtDepartment.TabIndex = 3;
            this.txtDepartment.DoubleClick += new System.EventHandler(this.txtDepartment_DoubleClick);
            // 
            // lnkDepartment
            // 
            this.lnkDepartment.AutoSize = true;
            this.lnkDepartment.Location = new System.Drawing.Point(24, 46);
            this.lnkDepartment.Name = "lnkDepartment";
            this.lnkDepartment.Size = new System.Drawing.Size(29, 12);
            this.lnkDepartment.TabIndex = 2;
            this.lnkDepartment.TabStop = true;
            this.lnkDepartment.Text = "部门";
            this.lnkDepartment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDepartment_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdFemale);
            this.panel2.Controls.Add(this.rdMale);
            this.panel2.Location = new System.Drawing.Point(59, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(121, 24);
            this.panel2.TabIndex = 54;
            // 
            // rdFemale
            // 
            this.rdFemale.AutoSize = true;
            this.rdFemale.Location = new System.Drawing.Point(55, 4);
            this.rdFemale.Name = "rdFemale";
            this.rdFemale.Size = new System.Drawing.Size(35, 16);
            this.rdFemale.TabIndex = 6;
            this.rdFemale.Text = "女";
            this.rdFemale.UseVisualStyleBackColor = true;
            // 
            // rdMale
            // 
            this.rdMale.AutoSize = true;
            this.rdMale.Checked = true;
            this.rdMale.Location = new System.Drawing.Point(2, 4);
            this.rdMale.Name = "rdMale";
            this.rdMale.Size = new System.Drawing.Size(35, 16);
            this.rdMale.TabIndex = 5;
            this.rdMale.TabStop = true;
            this.rdMale.Text = "男";
            this.rdMale.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdResign);
            this.panel1.Controls.Add(this.rdUnResign);
            this.panel1.Location = new System.Drawing.Point(227, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(121, 24);
            this.panel1.TabIndex = 53;
            // 
            // rdResign
            // 
            this.rdResign.AutoSize = true;
            this.rdResign.Location = new System.Drawing.Point(59, 4);
            this.rdResign.Name = "rdResign";
            this.rdResign.Size = new System.Drawing.Size(47, 16);
            this.rdResign.TabIndex = 9;
            this.rdResign.Text = "离职";
            this.rdResign.UseVisualStyleBackColor = true;
            // 
            // rdUnResign
            // 
            this.rdUnResign.AutoSize = true;
            this.rdUnResign.Checked = true;
            this.rdUnResign.Location = new System.Drawing.Point(4, 4);
            this.rdUnResign.Name = "rdUnResign";
            this.rdUnResign.Size = new System.Drawing.Size(47, 16);
            this.rdUnResign.TabIndex = 8;
            this.rdUnResign.TabStop = true;
            this.rdUnResign.Text = "在职";
            this.rdUnResign.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(24, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 52;
            this.label8.Text = "性别";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(24, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 48;
            this.label7.Text = "入职";
            // 
            // btnDelPhoto
            // 
            this.btnDelPhoto.Location = new System.Drawing.Point(363, 187);
            this.btnDelPhoto.Name = "btnDelPhoto";
            this.btnDelPhoto.Size = new System.Drawing.Size(75, 23);
            this.btnDelPhoto.TabIndex = 14;
            this.btnDelPhoto.Text = "删除相片";
            this.btnDelPhoto.UseVisualStyleBackColor = true;
            this.btnDelPhoto.Click += new System.EventHandler(this.btnDelPhoto_Click);
            // 
            // btnBrowserPhoto
            // 
            this.btnBrowserPhoto.Location = new System.Drawing.Point(444, 188);
            this.btnBrowserPhoto.Name = "btnBrowserPhoto";
            this.btnBrowserPhoto.Size = new System.Drawing.Size(75, 23);
            this.btnBrowserPhoto.TabIndex = 15;
            this.btnBrowserPhoto.Text = "查找相片";
            this.btnBrowserPhoto.UseVisualStyleBackColor = true;
            this.btnBrowserPhoto.Click += new System.EventHandler(this.btnBrowserPhoto_Click);
            // 
            // picPhoto
            // 
            this.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPhoto.Location = new System.Drawing.Point(363, 12);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(150, 166);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPhoto.TabIndex = 45;
            this.picPhoto.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(194, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 40;
            this.label6.Text = "状态";
            // 
            // txtUserPosition
            // 
            this.txtUserPosition.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtUserPosition.Location = new System.Drawing.Point(227, 43);
            this.txtUserPosition.MaxLength = 20;
            this.txtUserPosition.Name = "txtUserPosition";
            this.txtUserPosition.Size = new System.Drawing.Size(121, 21);
            this.txtUserPosition.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(194, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 37;
            this.label4.Text = "职位";
            // 
            // txtCertificate
            // 
            this.txtCertificate.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCertificate.Location = new System.Drawing.Point(227, 11);
            this.txtCertificate.MaxLength = 20;
            this.txtCertificate.Name = "txtCertificate";
            this.txtCertificate.Size = new System.Drawing.Size(121, 21);
            this.txtCertificate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(194, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "编号";
            // 
            // txtName
            // 
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtName.Location = new System.Drawing.Point(59, 11);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(121, 21);
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "姓名";
            // 
            // FrmStaffDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 312);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmStaffDetail";
            this.Text = "员工信息";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnDelPhoto;
        private System.Windows.Forms.Button btnBrowserPhoto;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.RadioButton rdResign;
        private System.Windows.Forms.RadioButton rdUnResign;
        private System.Windows.Forms.Label label6;
        private GeneralLibrary.WinformControl.DBCTextBox txtUserPosition;
        private System.Windows.Forms.Label label4;
        private GeneralLibrary.WinformControl.DBCTextBox txtCertificate;
        private System.Windows.Forms.Label label3;
        private GeneralLibrary.WinformControl.DBCTextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdFemale;
        private System.Windows.Forms.RadioButton rdMale;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lnkDepartment;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Button btnChangePwd;
        private Controls.RoleComboBox comRoleList;
        private GeneralLibrary.WinformControl.DBCTextBox txtPassword;
        private GeneralLibrary.WinformControl.DBCTextBox txtOperatorID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private Controls.NullableDateTimePicker dtHireDate;
    }
}