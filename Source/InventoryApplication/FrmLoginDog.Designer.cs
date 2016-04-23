namespace InventoryApplication
{
    partial class FrmLoginDog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoginDog));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.gpDB = new System.Windows.Forms.GroupBox();
            this.txtServer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLogName = new System.Windows.Forms.ComboBox();
            this.chkRememberLogid = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDBName = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.gpDB.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(317, 41);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "退出软件(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(317, 12);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(131, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "登录(&L)";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPassword.Location = new System.Drawing.Point(69, 50);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(209, 21);
            this.txtPassword.TabIndex = 1;
            // 
            // gpDB
            // 
            this.gpDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gpDB.Controls.Add(this.txtDBName);
            this.gpDB.Controls.Add(this.label4);
            this.gpDB.Controls.Add(this.txtServer);
            this.gpDB.Controls.Add(this.label3);
            this.gpDB.Location = new System.Drawing.Point(12, 117);
            this.gpDB.Name = "gpDB";
            this.gpDB.Size = new System.Drawing.Size(436, 94);
            this.gpDB.TabIndex = 5;
            this.gpDB.TabStop = false;
            this.gpDB.Text = "数据库设置";
            // 
            // txtServer
            // 
            this.txtServer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtServer.Location = new System.Drawing.Point(99, 27);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(331, 21);
            this.txtServer.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "数据库服务器：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtLogName);
            this.groupBox3.Controls.Add(this.chkRememberLogid);
            this.groupBox3.Controls.Add(this.txtPassword);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(16, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(295, 105);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // txtLogName
            // 
            this.txtLogName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtLogName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLogName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLogName.Location = new System.Drawing.Point(69, 20);
            this.txtLogName.MaxLength = 20;
            this.txtLogName.Name = "txtLogName";
            this.txtLogName.Size = new System.Drawing.Size(209, 20);
            this.txtLogName.TabIndex = 0;
            // 
            // chkRememberLogid
            // 
            this.chkRememberLogid.AutoSize = true;
            this.chkRememberLogid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkRememberLogid.Location = new System.Drawing.Point(194, 80);
            this.chkRememberLogid.Name = "chkRememberLogid";
            this.chkRememberLogid.Size = new System.Drawing.Size(84, 16);
            this.chkRememberLogid.TabIndex = 4;
            this.chkRememberLogid.Text = "记住登录名";
            this.chkRememberLogid.UseVisualStyleBackColor = true;
            this.chkRememberLogid.CheckedChanged += new System.EventHandler(this.chkRememberLogid_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "数据库名称：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDBName
            // 
            this.txtDBName.Enabled = false;
            this.txtDBName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDBName.Location = new System.Drawing.Point(99, 60);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(331, 21);
            this.txtDBName.TabIndex = 4;
            // 
            // FrmLoginDog
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(463, 216);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gpDB);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLoginDog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "易存企业管理系统 登录";
            this.Load += new System.EventHandler(this.Login_Load);
            this.gpDB.ResumeLayout(false);
            this.gpDB.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnLogin;
        public LJH.GeneralLibrary.WinformControl.DBCTextBox  txtPassword;
        private System.Windows.Forms.GroupBox gpDB;
        private System.Windows.Forms.Label label3;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox  txtServer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkRememberLogid;
        public System.Windows.Forms.ComboBox txtLogName;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtDBName;
        private System.Windows.Forms.Label label4;
    }
}