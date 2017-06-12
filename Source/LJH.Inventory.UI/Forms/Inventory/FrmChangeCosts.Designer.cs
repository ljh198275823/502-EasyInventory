namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class FrmChangeCosts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChangeCosts));
            this.pnlCost = new System.Windows.Forms.GroupBox();
            this.chk其它费用 = new System.Windows.Forms.CheckBox();
            this.chk运费 = new System.Windows.Forms.CheckBox();
            this.chk入库单价 = new System.Windows.Forms.CheckBox();
            this.pnlTrans = new System.Windows.Forms.Panel();
            this.rdWithTax_运费 = new System.Windows.Forms.RadioButton();
            this.rdWithoutTax__运费 = new System.Windows.Forms.RadioButton();
            this.pnlOther = new System.Windows.Forms.Panel();
            this.rdWithTax_其它费用 = new System.Windows.Forms.RadioButton();
            this.rdWithoutTax__其它费用 = new System.Windows.Forms.RadioButton();
            this.pnlTax = new System.Windows.Forms.Panel();
            this.rdWithTax_入库单价 = new System.Windows.Forms.RadioButton();
            this.rdWithoutTax__入库单价 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPurchasePrice = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTransCost = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtOtherCost = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.chkOtherCostPrepay = new System.Windows.Forms.CheckBox();
            this.chkTransCostPrepay = new System.Windows.Forms.CheckBox();
            this.btnOk1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlCost.SuspendLayout();
            this.pnlTrans.SuspendLayout();
            this.pnlOther.SuspendLayout();
            this.pnlTax.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCost
            // 
            this.pnlCost.Controls.Add(this.chk其它费用);
            this.pnlCost.Controls.Add(this.chk运费);
            this.pnlCost.Controls.Add(this.chk入库单价);
            this.pnlCost.Controls.Add(this.pnlTrans);
            this.pnlCost.Controls.Add(this.pnlOther);
            this.pnlCost.Controls.Add(this.pnlTax);
            this.pnlCost.Controls.Add(this.label9);
            this.pnlCost.Controls.Add(this.txtPurchasePrice);
            this.pnlCost.Controls.Add(this.label11);
            this.pnlCost.Controls.Add(this.label10);
            this.pnlCost.Controls.Add(this.txtTransCost);
            this.pnlCost.Controls.Add(this.txtOtherCost);
            this.pnlCost.Controls.Add(this.chkOtherCostPrepay);
            this.pnlCost.Controls.Add(this.chkTransCostPrepay);
            this.pnlCost.Location = new System.Drawing.Point(12, 12);
            this.pnlCost.Name = "pnlCost";
            this.pnlCost.Size = new System.Drawing.Size(515, 118);
            this.pnlCost.TabIndex = 148;
            this.pnlCost.TabStop = false;
            // 
            // chk其它费用
            // 
            this.chk其它费用.AutoSize = true;
            this.chk其它费用.Location = new System.Drawing.Point(18, 93);
            this.chk其它费用.Name = "chk其它费用";
            this.chk其它费用.Size = new System.Drawing.Size(15, 14);
            this.chk其它费用.TabIndex = 151;
            this.chk其它费用.UseVisualStyleBackColor = true;
            this.chk其它费用.CheckedChanged += new System.EventHandler(this.chk其它费用_CheckedChanged);
            // 
            // chk运费
            // 
            this.chk运费.AutoSize = true;
            this.chk运费.Location = new System.Drawing.Point(18, 57);
            this.chk运费.Name = "chk运费";
            this.chk运费.Size = new System.Drawing.Size(15, 14);
            this.chk运费.TabIndex = 150;
            this.chk运费.UseVisualStyleBackColor = true;
            this.chk运费.CheckedChanged += new System.EventHandler(this.chk运费_CheckedChanged);
            // 
            // chk入库单价
            // 
            this.chk入库单价.AutoSize = true;
            this.chk入库单价.Location = new System.Drawing.Point(18, 22);
            this.chk入库单价.Name = "chk入库单价";
            this.chk入库单价.Size = new System.Drawing.Size(15, 14);
            this.chk入库单价.TabIndex = 149;
            this.chk入库单价.UseVisualStyleBackColor = true;
            this.chk入库单价.CheckedChanged += new System.EventHandler(this.chk入库单价_CheckedChanged);
            // 
            // pnlTrans
            // 
            this.pnlTrans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTrans.Controls.Add(this.rdWithTax_运费);
            this.pnlTrans.Controls.Add(this.rdWithoutTax__运费);
            this.pnlTrans.Enabled = false;
            this.pnlTrans.Location = new System.Drawing.Point(261, 52);
            this.pnlTrans.Name = "pnlTrans";
            this.pnlTrans.Size = new System.Drawing.Size(145, 25);
            this.pnlTrans.TabIndex = 138;
            // 
            // rdWithTax_运费
            // 
            this.rdWithTax_运费.AutoSize = true;
            this.rdWithTax_运费.Location = new System.Drawing.Point(4, 3);
            this.rdWithTax_运费.Name = "rdWithTax_运费";
            this.rdWithTax_运费.Size = new System.Drawing.Size(47, 16);
            this.rdWithTax_运费.TabIndex = 129;
            this.rdWithTax_运费.TabStop = true;
            this.rdWithTax_运费.Text = "含税";
            this.rdWithTax_运费.UseVisualStyleBackColor = true;
            // 
            // rdWithoutTax__运费
            // 
            this.rdWithoutTax__运费.AutoSize = true;
            this.rdWithoutTax__运费.Location = new System.Drawing.Point(57, 3);
            this.rdWithoutTax__运费.Name = "rdWithoutTax__运费";
            this.rdWithoutTax__运费.Size = new System.Drawing.Size(59, 16);
            this.rdWithoutTax__运费.TabIndex = 130;
            this.rdWithoutTax__运费.TabStop = true;
            this.rdWithoutTax__运费.Text = "不含税";
            this.rdWithoutTax__运费.UseVisualStyleBackColor = true;
            // 
            // pnlOther
            // 
            this.pnlOther.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOther.Controls.Add(this.rdWithTax_其它费用);
            this.pnlOther.Controls.Add(this.rdWithoutTax__其它费用);
            this.pnlOther.Enabled = false;
            this.pnlOther.Location = new System.Drawing.Point(261, 87);
            this.pnlOther.Name = "pnlOther";
            this.pnlOther.Size = new System.Drawing.Size(145, 25);
            this.pnlOther.TabIndex = 137;
            // 
            // rdWithTax_其它费用
            // 
            this.rdWithTax_其它费用.AutoSize = true;
            this.rdWithTax_其它费用.Location = new System.Drawing.Point(4, 3);
            this.rdWithTax_其它费用.Name = "rdWithTax_其它费用";
            this.rdWithTax_其它费用.Size = new System.Drawing.Size(47, 16);
            this.rdWithTax_其它费用.TabIndex = 129;
            this.rdWithTax_其它费用.TabStop = true;
            this.rdWithTax_其它费用.Text = "含税";
            this.rdWithTax_其它费用.UseVisualStyleBackColor = true;
            // 
            // rdWithoutTax__其它费用
            // 
            this.rdWithoutTax__其它费用.AutoSize = true;
            this.rdWithoutTax__其它费用.Location = new System.Drawing.Point(57, 5);
            this.rdWithoutTax__其它费用.Name = "rdWithoutTax__其它费用";
            this.rdWithoutTax__其它费用.Size = new System.Drawing.Size(59, 16);
            this.rdWithoutTax__其它费用.TabIndex = 130;
            this.rdWithoutTax__其它费用.TabStop = true;
            this.rdWithoutTax__其它费用.Text = "不含税";
            this.rdWithoutTax__其它费用.UseVisualStyleBackColor = true;
            // 
            // pnlTax
            // 
            this.pnlTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTax.Controls.Add(this.rdWithTax_入库单价);
            this.pnlTax.Controls.Add(this.rdWithoutTax__入库单价);
            this.pnlTax.Enabled = false;
            this.pnlTax.Location = new System.Drawing.Point(261, 17);
            this.pnlTax.Name = "pnlTax";
            this.pnlTax.Size = new System.Drawing.Size(145, 25);
            this.pnlTax.TabIndex = 134;
            // 
            // rdWithTax_入库单价
            // 
            this.rdWithTax_入库单价.AutoSize = true;
            this.rdWithTax_入库单价.Location = new System.Drawing.Point(4, 3);
            this.rdWithTax_入库单价.Name = "rdWithTax_入库单价";
            this.rdWithTax_入库单价.Size = new System.Drawing.Size(47, 16);
            this.rdWithTax_入库单价.TabIndex = 129;
            this.rdWithTax_入库单价.TabStop = true;
            this.rdWithTax_入库单价.Text = "含税";
            this.rdWithTax_入库单价.UseVisualStyleBackColor = true;
            // 
            // rdWithoutTax__入库单价
            // 
            this.rdWithoutTax__入库单价.AutoSize = true;
            this.rdWithoutTax__入库单价.Location = new System.Drawing.Point(57, 3);
            this.rdWithoutTax__入库单价.Name = "rdWithoutTax__入库单价";
            this.rdWithoutTax__入库单价.Size = new System.Drawing.Size(59, 16);
            this.rdWithoutTax__入库单价.TabIndex = 130;
            this.rdWithoutTax__入库单价.TabStop = true;
            this.rdWithoutTax__入库单价.Text = "不含税";
            this.rdWithoutTax__入库单价.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 94;
            this.label9.Text = "入库单价";
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.Enabled = false;
            this.txtPurchasePrice.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPurchasePrice.Location = new System.Drawing.Point(97, 19);
            this.txtPurchasePrice.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtPurchasePrice.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.PointCount = 2;
            this.txtPurchasePrice.Size = new System.Drawing.Size(150, 21);
            this.txtPurchasePrice.TabIndex = 98;
            this.txtPurchasePrice.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 96;
            this.label11.Text = "其它费用";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(62, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 95;
            this.label10.Text = "运费";
            // 
            // txtTransCost
            // 
            this.txtTransCost.Enabled = false;
            this.txtTransCost.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtTransCost.Location = new System.Drawing.Point(97, 54);
            this.txtTransCost.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtTransCost.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTransCost.Name = "txtTransCost";
            this.txtTransCost.PointCount = 2;
            this.txtTransCost.Size = new System.Drawing.Size(150, 21);
            this.txtTransCost.TabIndex = 97;
            this.txtTransCost.Text = "0";
            // 
            // txtOtherCost
            // 
            this.txtOtherCost.Enabled = false;
            this.txtOtherCost.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtOtherCost.Location = new System.Drawing.Point(97, 89);
            this.txtOtherCost.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtOtherCost.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOtherCost.Name = "txtOtherCost";
            this.txtOtherCost.PointCount = 2;
            this.txtOtherCost.Size = new System.Drawing.Size(150, 21);
            this.txtOtherCost.TabIndex = 99;
            this.txtOtherCost.Text = "0";
            // 
            // chkOtherCostPrepay
            // 
            this.chkOtherCostPrepay.AutoSize = true;
            this.chkOtherCostPrepay.Enabled = false;
            this.chkOtherCostPrepay.Location = new System.Drawing.Point(415, 91);
            this.chkOtherCostPrepay.Name = "chkOtherCostPrepay";
            this.chkOtherCostPrepay.Size = new System.Drawing.Size(84, 16);
            this.chkOtherCostPrepay.TabIndex = 135;
            this.chkOtherCostPrepay.Text = "供应商代垫";
            this.chkOtherCostPrepay.UseVisualStyleBackColor = true;
            // 
            // chkTransCostPrepay
            // 
            this.chkTransCostPrepay.AutoSize = true;
            this.chkTransCostPrepay.Enabled = false;
            this.chkTransCostPrepay.Location = new System.Drawing.Point(415, 56);
            this.chkTransCostPrepay.Name = "chkTransCostPrepay";
            this.chkTransCostPrepay.Size = new System.Drawing.Size(84, 16);
            this.chkTransCostPrepay.TabIndex = 136;
            this.chkTransCostPrepay.Text = "供应商代垫";
            this.chkTransCostPrepay.UseVisualStyleBackColor = true;
            // 
            // btnOk1
            // 
            this.btnOk1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk1.Location = new System.Drawing.Point(239, 148);
            this.btnOk1.Name = "btnOk1";
            this.btnOk1.Size = new System.Drawing.Size(126, 35);
            this.btnOk1.TabIndex = 147;
            this.btnOk1.Text = "确定(&O)";
            this.btnOk1.UseVisualStyleBackColor = true;
            this.btnOk1.Click += new System.EventHandler(this.btnOk1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(401, 148);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 35);
            this.btnClose.TabIndex = 149;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmChangeCosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 206);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlCost);
            this.Controls.Add(this.btnOk1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmChangeCosts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改单价";
            this.Load += new System.EventHandler(this.FrmChangeCosts_Load);
            this.pnlCost.ResumeLayout(false);
            this.pnlCost.PerformLayout();
            this.pnlTrans.ResumeLayout(false);
            this.pnlTrans.PerformLayout();
            this.pnlOther.ResumeLayout(false);
            this.pnlOther.PerformLayout();
            this.pnlTax.ResumeLayout(false);
            this.pnlTax.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox pnlCost;
        private System.Windows.Forms.Panel pnlTrans;
        private System.Windows.Forms.RadioButton rdWithTax_运费;
        private System.Windows.Forms.RadioButton rdWithoutTax__运费;
        private System.Windows.Forms.Panel pnlOther;
        private System.Windows.Forms.RadioButton rdWithTax_其它费用;
        private System.Windows.Forms.RadioButton rdWithoutTax__其它费用;
        private System.Windows.Forms.Panel pnlTax;
        private System.Windows.Forms.RadioButton rdWithTax_入库单价;
        private System.Windows.Forms.RadioButton rdWithoutTax__入库单价;
        private System.Windows.Forms.Label label9;
        private GeneralLibrary.WinformControl.DecimalTextBox txtPurchasePrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private GeneralLibrary.WinformControl.DecimalTextBox txtTransCost;
        private GeneralLibrary.WinformControl.DecimalTextBox txtOtherCost;
        private System.Windows.Forms.CheckBox chkOtherCostPrepay;
        private System.Windows.Forms.CheckBox chkTransCostPrepay;
        private System.Windows.Forms.Button btnOk1;
        private System.Windows.Forms.CheckBox chk其它费用;
        private System.Windows.Forms.CheckBox chk运费;
        private System.Windows.Forms.CheckBox chk入库单价;
        protected System.Windows.Forms.Button btnClose;
    }
}