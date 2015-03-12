namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class FrmInvnetoryCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInvnetoryCheck));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkChecker = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProduct = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtWarehouse = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtChecker = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtInventory = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtCheckCount = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "盘点时库存";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "盘点数量";
            // 
            // lnkChecker
            // 
            this.lnkChecker.AutoSize = true;
            this.lnkChecker.Location = new System.Drawing.Point(29, 132);
            this.lnkChecker.Name = "lnkChecker";
            this.lnkChecker.Size = new System.Drawing.Size(53, 12);
            this.lnkChecker.TabIndex = 2;
            this.lnkChecker.TabStop = true;
            this.lnkChecker.Text = "盘点人员";
            this.lnkChecker.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkChecker_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "产品";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "仓库";
            // 
            // txtProduct
            // 
            this.txtProduct.Enabled = false;
            this.txtProduct.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtProduct.Location = new System.Drawing.Point(91, 14);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(239, 21);
            this.txtProduct.TabIndex = 5;
            // 
            // txtWarehouse
            // 
            this.txtWarehouse.Enabled = false;
            this.txtWarehouse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWarehouse.Location = new System.Drawing.Point(91, 41);
            this.txtWarehouse.Name = "txtWarehouse";
            this.txtWarehouse.Size = new System.Drawing.Size(239, 21);
            this.txtWarehouse.TabIndex = 6;
            // 
            // txtChecker
            // 
            this.txtChecker.BackColor = System.Drawing.Color.White;
            this.txtChecker.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtChecker.Location = new System.Drawing.Point(91, 128);
            this.txtChecker.Name = "txtChecker";
            this.txtChecker.ReadOnly = true;
            this.txtChecker.Size = new System.Drawing.Size(239, 21);
            this.txtChecker.TabIndex = 1;
            this.txtChecker.DoubleClick += new System.EventHandler(this.txtChecker_DoubleClick);
            // 
            // txtInventory
            // 
            this.txtInventory.Enabled = false;
            this.txtInventory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtInventory.Location = new System.Drawing.Point(91, 71);
            this.txtInventory.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtInventory.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtInventory.Name = "txtInventory";
            this.txtInventory.PointCount = 2;
            this.txtInventory.Size = new System.Drawing.Size(239, 21);
            this.txtInventory.TabIndex = 8;
            this.txtInventory.Text = "0.00";
            // 
            // txtCheckCount
            // 
            this.txtCheckCount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCheckCount.Location = new System.Drawing.Point(91, 100);
            this.txtCheckCount.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtCheckCount.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCheckCount.Name = "txtCheckCount";
            this.txtCheckCount.PointCount = 2;
            this.txtCheckCount.Size = new System.Drawing.Size(239, 21);
            this.txtCheckCount.TabIndex = 0;
            this.txtCheckCount.Text = "0.00";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(257, 188);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOk.Location = new System.Drawing.Point(170, 188);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "备注";
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(91, 157);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(239, 21);
            this.txtMemo.TabIndex = 2;
            // 
            // FrmInvnetoryCheck
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(348, 221);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtCheckCount);
            this.Controls.Add(this.txtInventory);
            this.Controls.Add(this.txtChecker);
            this.Controls.Add(this.txtWarehouse);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lnkChecker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmInvnetoryCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "产品盘点";
            this.Load += new System.EventHandler(this.FrmInvnetoryCheck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkChecker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private GeneralLibrary.WinformControl.DBCTextBox txtProduct;
        private GeneralLibrary.WinformControl.DBCTextBox txtWarehouse;
        private GeneralLibrary.WinformControl.DBCTextBox txtChecker;
        private GeneralLibrary.WinformControl.DecimalTextBox txtInventory;
        private GeneralLibrary.WinformControl.DecimalTextBox txtCheckCount;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label5;
        private GeneralLibrary.WinformControl.DBCTextBox txtMemo;
    }
}