namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class Frm设置其它成本
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm设置其它成本));
            this.rdWithTax = new System.Windows.Forms.RadioButton();
            this.rdWithoutTax = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrice = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.btnOk1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txt成本类别 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSupplier = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkSupplier = new System.Windows.Forms.LinkLabel();
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.chk总金额 = new System.Windows.Forms.CheckBox();
            this.txtCarPlate = new LJH.Inventory.UI.Controls.CarplateComboBox(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rdWithTax
            // 
            this.rdWithTax.AutoSize = true;
            this.rdWithTax.Location = new System.Drawing.Point(212, 62);
            this.rdWithTax.Name = "rdWithTax";
            this.rdWithTax.Size = new System.Drawing.Size(47, 16);
            this.rdWithTax.TabIndex = 2;
            this.rdWithTax.TabStop = true;
            this.rdWithTax.Text = "含税";
            this.rdWithTax.UseVisualStyleBackColor = true;
            // 
            // rdWithoutTax
            // 
            this.rdWithoutTax.AutoSize = true;
            this.rdWithoutTax.Location = new System.Drawing.Point(265, 62);
            this.rdWithoutTax.Name = "rdWithoutTax";
            this.rdWithoutTax.Size = new System.Drawing.Size(59, 16);
            this.rdWithoutTax.TabIndex = 3;
            this.rdWithoutTax.TabStop = true;
            this.rdWithoutTax.Text = "不含税";
            this.rdWithoutTax.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 94;
            this.label9.Text = "成本";
            // 
            // txtPrice
            // 
            this.txtPrice.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPrice.Location = new System.Drawing.Point(83, 60);
            this.txtPrice.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtPrice.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PointCount = 2;
            this.txtPrice.Size = new System.Drawing.Size(121, 21);
            this.txtPrice.TabIndex = 1;
            this.txtPrice.Text = "0";
            // 
            // btnOk1
            // 
            this.btnOk1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk1.Location = new System.Drawing.Point(116, 181);
            this.btnOk1.Name = "btnOk1";
            this.btnOk1.Size = new System.Drawing.Size(126, 35);
            this.btnOk1.TabIndex = 147;
            this.btnOk1.Text = "确定(&O)";
            this.btnOk1.UseVisualStyleBackColor = true;
            this.btnOk1.Click += new System.EventHandler(this.btnOk1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(265, 181);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 35);
            this.btnClose.TabIndex = 149;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txt成本类别
            // 
            this.txt成本类别.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt成本类别.FormattingEnabled = true;
            this.txt成本类别.Location = new System.Drawing.Point(83, 22);
            this.txt成本类别.Name = "txt成本类别";
            this.txt成本类别.Size = new System.Drawing.Size(121, 20);
            this.txt成本类别.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 151;
            this.label1.Text = "成本类别";
            // 
            // txtSupplier
            // 
            this.txtSupplier.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSupplier.Location = new System.Drawing.Point(83, 100);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(295, 21);
            this.txtSupplier.TabIndex = 153;
            this.txtSupplier.DoubleClick += new System.EventHandler(this.txtSupplier_DoubleClick);
            // 
            // lnkSupplier
            // 
            this.lnkSupplier.AutoSize = true;
            this.lnkSupplier.Location = new System.Drawing.Point(38, 104);
            this.lnkSupplier.Name = "lnkSupplier";
            this.lnkSupplier.Size = new System.Drawing.Size(41, 12);
            this.lnkSupplier.TabIndex = 4;
            this.lnkSupplier.TabStop = true;
            this.lnkSupplier.Text = "供应商";
            this.lnkSupplier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSupplier_LinkClicked);
            // 
            // txtMemo
            // 
            this.txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(83, 137);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(295, 21);
            this.txtMemo.TabIndex = 169;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(46, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 170;
            this.label12.Text = "备注";
            // 
            // chk总金额
            // 
            this.chk总金额.AutoSize = true;
            this.chk总金额.ForeColor = System.Drawing.Color.Red;
            this.chk总金额.Location = new System.Drawing.Point(333, 62);
            this.chk总金额.Name = "chk总金额";
            this.chk总金额.Size = new System.Drawing.Size(60, 16);
            this.chk总金额.TabIndex = 171;
            this.chk总金额.Text = "总金额";
            this.chk总金额.UseVisualStyleBackColor = true;
            // 
            // txtCarPlate
            // 
            this.txtCarPlate.FormattingEnabled = true;
            this.txtCarPlate.Location = new System.Drawing.Point(265, 22);
            this.txtCarPlate.Name = "txtCarPlate";
            this.txtCarPlate.Size = new System.Drawing.Size(126, 20);
            this.txtCarPlate.TabIndex = 173;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(220, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 172;
            this.label13.Text = "车皮号";
            // 
            // FrmChangeCosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 239);
            this.Controls.Add(this.txtCarPlate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.chk总金额);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.rdWithTax);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.rdWithoutTax);
            this.Controls.Add(this.lnkSupplier);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt成本类别);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk1);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmChangeCosts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置其它成本";
            this.Load += new System.EventHandler(this.FrmChangeCosts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdWithTax;
        private System.Windows.Forms.RadioButton rdWithoutTax;
        private System.Windows.Forms.Label label9;
        private GeneralLibrary.WinformControl.DecimalTextBox txtPrice;
        private System.Windows.Forms.Button btnOk1;
        protected System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox txt成本类别;
        private System.Windows.Forms.Label label1;
        private GeneralLibrary.WinformControl.DBCTextBox txtSupplier;
        private System.Windows.Forms.LinkLabel lnkSupplier;
        private GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.CheckBox chk总金额;
        private Controls.CarplateComboBox txtCarPlate;
        private System.Windows.Forms.Label label13;
    }
}