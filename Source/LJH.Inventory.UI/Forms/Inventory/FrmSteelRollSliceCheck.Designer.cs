namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class FrmSteelRollSliceCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSteelRollSliceCheck));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkChecker = new System.Windows.Forms.LinkLabel();
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
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "盘点时库存";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "盘点数量";
            // 
            // lnkChecker
            // 
            this.lnkChecker.AutoSize = true;
            this.lnkChecker.Location = new System.Drawing.Point(41, 87);
            this.lnkChecker.Name = "lnkChecker";
            this.lnkChecker.Size = new System.Drawing.Size(41, 12);
            this.lnkChecker.TabIndex = 2;
            this.lnkChecker.TabStop = true;
            this.lnkChecker.Text = "盘点人";
            this.lnkChecker.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkChecker_LinkClicked);
            // 
            // txtChecker
            // 
            this.txtChecker.BackColor = System.Drawing.Color.White;
            this.txtChecker.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtChecker.Location = new System.Drawing.Point(91, 83);
            this.txtChecker.Name = "txtChecker";
            this.txtChecker.ReadOnly = false;
            this.txtChecker.Size = new System.Drawing.Size(239, 21);
            this.txtChecker.TabIndex = 1;
            // 
            // txtInventory
            // 
            this.txtInventory.Enabled = false;
            this.txtInventory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtInventory.Location = new System.Drawing.Point(91, 22);
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
            this.txtInventory.PointCount = 0;
            this.txtInventory.Size = new System.Drawing.Size(239, 21);
            this.txtInventory.TabIndex = 8;
            this.txtInventory.Text = "0";
            // 
            // txtCheckCount
            // 
            this.txtCheckCount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCheckCount.Location = new System.Drawing.Point(91, 53);
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
            this.txtCheckCount.PointCount = 0;
            this.txtCheckCount.Size = new System.Drawing.Size(239, 21);
            this.txtCheckCount.TabIndex = 0;
            this.txtCheckCount.Text = "0";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(262, 161);
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
            this.btnOk.Location = new System.Drawing.Point(175, 161);
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
            this.label5.Location = new System.Drawing.Point(53, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "备注";
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(91, 114);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(239, 21);
            this.txtMemo.TabIndex = 2;
            // 
            // FrmSteelRollSliceCheck
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(353, 194);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtCheckCount);
            this.Controls.Add(this.txtInventory);
            this.Controls.Add(this.txtChecker);
            this.Controls.Add(this.lnkChecker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSteelRollSliceCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "小件盘点";
            this.Load += new System.EventHandler(this.FrmInvnetoryCheck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkChecker;
        private GeneralLibrary.WinformControl.DBCTextBox txtChecker;
        private GeneralLibrary.WinformControl.DecimalTextBox txtInventory;
        private GeneralLibrary.WinformControl.DecimalTextBox txtCheckCount;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label5;
        private GeneralLibrary.WinformControl.DBCTextBox txtMemo;
    }
}