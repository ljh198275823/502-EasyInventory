namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class FrmSteelRollSliceDepart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSteelRollSliceDepart));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtDepart = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkCustomer = new System.Windows.Forms.LinkLabel();
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtWareHouse = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkWarehouse = new System.Windows.Forms.LinkLabel();
            this.txtOriginal = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ucSpecification1 = new LJH.Inventory.UI.Controls.UCSpecification();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLength = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(264, 261);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOk.Location = new System.Drawing.Point(177, 261);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtDepart
            // 
            this.txtDepart.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDepart.Location = new System.Drawing.Point(74, 109);
            this.txtDepart.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtDepart.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDepart.Name = "txtDepart";
            this.txtDepart.PointCount = 0;
            this.txtDepart.Size = new System.Drawing.Size(265, 21);
            this.txtDepart.TabIndex = 7;
            this.txtDepart.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "拆出数量";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomer.Enabled = false;
            this.txtCustomer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCustomer.Location = new System.Drawing.Point(74, 177);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(265, 21);
            this.txtCustomer.TabIndex = 92;
            // 
            // lnkCustomer
            // 
            this.lnkCustomer.AutoSize = true;
            this.lnkCustomer.Location = new System.Drawing.Point(41, 181);
            this.lnkCustomer.Name = "lnkCustomer";
            this.lnkCustomer.Size = new System.Drawing.Size(29, 12);
            this.lnkCustomer.TabIndex = 91;
            this.lnkCustomer.TabStop = true;
            this.lnkCustomer.Text = "客户";
            this.lnkCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomer_LinkClicked);
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(74, 208);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(265, 21);
            this.txtMemo.TabIndex = 89;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 90;
            this.label3.Text = "备注";
            // 
            // txtWareHouse
            // 
            this.txtWareHouse.BackColor = System.Drawing.SystemColors.Control;
            this.txtWareHouse.Enabled = false;
            this.txtWareHouse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWareHouse.Location = new System.Drawing.Point(74, 145);
            this.txtWareHouse.Name = "txtWareHouse";
            this.txtWareHouse.ReadOnly = true;
            this.txtWareHouse.Size = new System.Drawing.Size(265, 21);
            this.txtWareHouse.TabIndex = 87;
            // 
            // lnkWarehouse
            // 
            this.lnkWarehouse.AutoSize = true;
            this.lnkWarehouse.Location = new System.Drawing.Point(41, 148);
            this.lnkWarehouse.Name = "lnkWarehouse";
            this.lnkWarehouse.Size = new System.Drawing.Size(29, 12);
            this.lnkWarehouse.TabIndex = 88;
            this.lnkWarehouse.TabStop = true;
            this.lnkWarehouse.Text = "仓库";
            this.lnkWarehouse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWarehouse_LinkClicked);
            // 
            // txtOriginal
            // 
            this.txtOriginal.Enabled = false;
            this.txtOriginal.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtOriginal.Location = new System.Drawing.Point(74, 16);
            this.txtOriginal.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtOriginal.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOriginal.Name = "txtOriginal";
            this.txtOriginal.PointCount = 0;
            this.txtOriginal.Size = new System.Drawing.Size(265, 21);
            this.txtOriginal.TabIndex = 93;
            this.txtOriginal.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 94;
            this.label1.Text = "原包数量";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 95;
            this.label4.Text = "规格";
            // 
            // ucSpecification1
            // 
            this.ucSpecification1.Location = new System.Drawing.Point(74, 45);
            this.ucSpecification1.Name = "ucSpecification1";
            this.ucSpecification1.Size = new System.Drawing.Size(200, 27);
            this.ucSpecification1.Specification = "*";
            this.ucSpecification1.TabIndex = 96;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 97;
            this.label5.Text = "长度(米)";
            // 
            // txtLength
            // 
            this.txtLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLength.Location = new System.Drawing.Point(76, 79);
            this.txtLength.MaxValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txtLength.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLength.Name = "txtLength";
            this.txtLength.PointCount = 3;
            this.txtLength.Size = new System.Drawing.Size(62, 21);
            this.txtLength.TabIndex = 98;
            this.txtLength.Text = "0.00";
            // 
            // FrmSteelRollSliceDepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 303);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ucSpecification1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOriginal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lnkCustomer);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWareHouse);
            this.Controls.Add(this.lnkWarehouse);
            this.Controls.Add(this.txtDepart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSteelRollSliceDepart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "拆包";
            this.Load += new System.EventHandler(this.FrmSteelRollSliceDepart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnOk;
        private GeneralLibrary.WinformControl.DecimalTextBox txtDepart;
        private System.Windows.Forms.Label label2;
        private GeneralLibrary.WinformControl.DBCTextBox txtCustomer;
        private System.Windows.Forms.LinkLabel lnkCustomer;
        private GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private System.Windows.Forms.Label label3;
        private GeneralLibrary.WinformControl.DBCTextBox txtWareHouse;
        private System.Windows.Forms.LinkLabel lnkWarehouse;
        private GeneralLibrary.WinformControl.DecimalTextBox txtOriginal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Controls.UCSpecification ucSpecification1;
        private System.Windows.Forms.Label label5;
        private GeneralLibrary.WinformControl.DecimalTextBox txtLength;
    }
}