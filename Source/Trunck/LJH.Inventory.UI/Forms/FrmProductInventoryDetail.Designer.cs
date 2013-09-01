namespace LJH.Inventory.UI.Forms
{
    partial class FrmProductInventoryDetail
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
            this.txtProductID = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtCost = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtCount = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtAmount = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.lnkProduct = new System.Windows.Forms.LinkLabel();
            this.lnkWarehouse = new System.Windows.Forms.LinkLabel();
            this.txtWareHouseID = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(186, 160);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(99, 160);
            // 
            // txtProductID
            // 
            this.txtProductID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtProductID.Location = new System.Drawing.Point(79, 38);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(184, 21);
            this.txtProductID.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "进货价：";
            // 
            // txtCost
            // 
            this.txtCost.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCost.Location = new System.Drawing.Point(79, 66);
            this.txtCost.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtCost.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCost.Name = "txtCost";
            this.txtCost.PointCount = 2;
            this.txtCost.Size = new System.Drawing.Size(184, 21);
            this.txtCost.TabIndex = 3;
            this.txtCost.Text = "0.00";
            this.txtCost.TextChanged += new System.EventHandler(this.txtCount_TextChanged);
            // 
            // txtCount
            // 
            this.txtCount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCount.Location = new System.Drawing.Point(79, 95);
            this.txtCount.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtCount.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCount.Name = "txtCount";
            this.txtCount.PointCount = 2;
            this.txtCount.Size = new System.Drawing.Size(184, 21);
            this.txtCount.TabIndex = 4;
            this.txtCount.Text = "0.00";
            this.txtCount.TextChanged += new System.EventHandler(this.txtCount_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "数量：";
            // 
            // txtAmount
            // 
            this.txtAmount.Enabled = false;
            this.txtAmount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAmount.Location = new System.Drawing.Point(79, 125);
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
            this.txtAmount.Size = new System.Drawing.Size(184, 21);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.Text = "0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "库存总额：";
            // 
            // lnkProduct
            // 
            this.lnkProduct.AutoSize = true;
            this.lnkProduct.Location = new System.Drawing.Point(35, 42);
            this.lnkProduct.Name = "lnkProduct";
            this.lnkProduct.Size = new System.Drawing.Size(41, 12);
            this.lnkProduct.TabIndex = 13;
            this.lnkProduct.TabStop = true;
            this.lnkProduct.Text = "商品：";
            this.lnkProduct.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProduct_LinkClicked);
            // 
            // lnkWarehouse
            // 
            this.lnkWarehouse.AutoSize = true;
            this.lnkWarehouse.Location = new System.Drawing.Point(35, 14);
            this.lnkWarehouse.Name = "lnkWarehouse";
            this.lnkWarehouse.Size = new System.Drawing.Size(41, 12);
            this.lnkWarehouse.TabIndex = 14;
            this.lnkWarehouse.TabStop = true;
            this.lnkWarehouse.Text = "仓库：";
            this.lnkWarehouse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWarehouse_LinkClicked);
            // 
            // txtWareHouseID
            // 
            this.txtWareHouseID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWareHouseID.Location = new System.Drawing.Point(79, 11);
            this.txtWareHouseID.Name = "txtWareHouseID";
            this.txtWareHouseID.Size = new System.Drawing.Size(184, 21);
            this.txtWareHouseID.TabIndex = 15;
            // 
            // FrmProductInventoryDetail
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(273, 195);
            this.Controls.Add(this.txtWareHouseID);
            this.Controls.Add(this.lnkWarehouse);
            this.Controls.Add(this.lnkProduct);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProductID);
            this.Name = "FrmProductInventoryDetail";
            this.Text = "库存信息";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.txtProductID, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtCost, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtCount, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtAmount, 0);
            this.Controls.SetChildIndex(this.lnkProduct, 0);
            this.Controls.SetChildIndex(this.lnkWarehouse, 0);
            this.Controls.SetChildIndex(this.txtWareHouseID, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtProductID;
        private System.Windows.Forms.Label label4;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtCost;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtCount;
        private System.Windows.Forms.Label label5;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel lnkProduct;
        private System.Windows.Forms.LinkLabel lnkWarehouse;
        private GeneralLibrary.WinformControl.DBCTextBox txtWareHouseID;

    }
}