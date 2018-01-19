namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class FrmSlice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSlice));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtCount = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtSliceDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCurrentWeigth = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemainWeight = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSlicers = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtWareHouse = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkWareHouse = new System.Windows.Forms.LinkLabel();
            this.txtCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkCustomer = new System.Windows.Forms.LinkLabel();
            this.chkOver = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.ComboBox();
            this.txtBeforeLength = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtAfterLength = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.txtLength = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.ucSpecification1 = new LJH.Inventory.UI.Controls.UCSpecification();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(313, 320);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 41);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOk.Location = new System.Drawing.Point(191, 320);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 41);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtCount
            // 
            this.txtCount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCount.Location = new System.Drawing.Point(250, 112);
            this.txtCount.MaxValue = 999999999;
            this.txtCount.MinValue = 0;
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(70, 21);
            this.txtCount.TabIndex = 13;
            this.txtCount.Text = "0";
            this.txtCount.TextChanged += new System.EventHandler(this.txtLength_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "小件数量";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "小件长度(mm)";
            // 
            // dtSliceDate
            // 
            this.dtSliceDate.Location = new System.Drawing.Point(96, 17);
            this.dtSliceDate.Name = "dtSliceDate";
            this.dtSliceDate.Size = new System.Drawing.Size(114, 21);
            this.dtSliceDate.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 41;
            this.label6.Text = "加工日期";
            // 
            // txtCurrentWeigth
            // 
            this.txtCurrentWeigth.Enabled = false;
            this.txtCurrentWeigth.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCurrentWeigth.Location = new System.Drawing.Point(96, 78);
            this.txtCurrentWeigth.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtCurrentWeigth.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCurrentWeigth.Name = "txtCurrentWeigth";
            this.txtCurrentWeigth.PointCount = 4;
            this.txtCurrentWeigth.Size = new System.Drawing.Size(114, 21);
            this.txtCurrentWeigth.TabIndex = 36;
            this.txtCurrentWeigth.Text = "0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 35;
            this.label9.Text = "当前重量(吨)";
            // 
            // txtRemainWeight
            // 
            this.txtRemainWeight.Enabled = false;
            this.txtRemainWeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtRemainWeight.Location = new System.Drawing.Point(96, 145);
            this.txtRemainWeight.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtRemainWeight.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRemainWeight.Name = "txtRemainWeight";
            this.txtRemainWeight.PointCount = 4;
            this.txtRemainWeight.Size = new System.Drawing.Size(114, 21);
            this.txtRemainWeight.TabIndex = 46;
            this.txtRemainWeight.Text = "0.00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 45;
            this.label12.Text = "剩余重量(吨)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 49;
            this.label1.Text = "加工人员";
            // 
            // txtSlicers
            // 
            this.txtSlicers.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSlicers.Location = new System.Drawing.Point(96, 239);
            this.txtSlicers.Name = "txtSlicers";
            this.txtSlicers.Size = new System.Drawing.Size(328, 21);
            this.txtSlicers.TabIndex = 50;
            // 
            // txtWareHouse
            // 
            this.txtWareHouse.Enabled = false;
            this.txtWareHouse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWareHouse.Location = new System.Drawing.Point(96, 179);
            this.txtWareHouse.Name = "txtWareHouse";
            this.txtWareHouse.Size = new System.Drawing.Size(328, 21);
            this.txtWareHouse.TabIndex = 78;
            // 
            // lnkWareHouse
            // 
            this.lnkWareHouse.AutoSize = true;
            this.lnkWareHouse.Location = new System.Drawing.Point(38, 183);
            this.lnkWareHouse.Name = "lnkWareHouse";
            this.lnkWareHouse.Size = new System.Drawing.Size(53, 12);
            this.lnkWareHouse.TabIndex = 77;
            this.lnkWareHouse.TabStop = true;
            this.lnkWareHouse.Text = "存放仓库";
            this.lnkWareHouse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWareHouse_LinkClicked);
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.White;
            this.txtCustomer.Enabled = false;
            this.txtCustomer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCustomer.Location = new System.Drawing.Point(96, 209);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(328, 21);
            this.txtCustomer.TabIndex = 80;
            // 
            // lnkCustomer
            // 
            this.lnkCustomer.AutoSize = true;
            this.lnkCustomer.Location = new System.Drawing.Point(56, 213);
            this.lnkCustomer.Name = "lnkCustomer";
            this.lnkCustomer.Size = new System.Drawing.Size(35, 12);
            this.lnkCustomer.TabIndex = 79;
            this.lnkCustomer.TabStop = true;
            this.lnkCustomer.Text = "客户:";
            this.lnkCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomer_LinkClicked);
            // 
            // chkOver
            // 
            this.chkOver.AutoSize = true;
            this.chkOver.ForeColor = System.Drawing.Color.Red;
            this.chkOver.Location = new System.Drawing.Point(336, 114);
            this.chkOver.Name = "chkOver";
            this.chkOver.Size = new System.Drawing.Size(84, 16);
            this.chkOver.TabIndex = 85;
            this.chkOver.Text = "卷子已开完";
            this.chkOver.UseVisualStyleBackColor = true;
            this.chkOver.CheckedChanged += new System.EventHandler(this.chkOver_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(62, 278);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 86;
            this.label14.Text = "备注";
            // 
            // txtMemo
            // 
            this.txtMemo.FormattingEnabled = true;
            this.txtMemo.Items.AddRange(new object[] {
            "库存数量以实际开平数量为准"});
            this.txtMemo.Location = new System.Drawing.Point(96, 274);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(328, 20);
            this.txtMemo.TabIndex = 87;
            // 
            // txtBeforeLength
            // 
            this.txtBeforeLength.Enabled = false;
            this.txtBeforeLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtBeforeLength.Location = new System.Drawing.Point(300, 78);
            this.txtBeforeLength.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.txtBeforeLength.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtBeforeLength.Name = "txtBeforeLength";
            this.txtBeforeLength.PointCount = 3;
            this.txtBeforeLength.Size = new System.Drawing.Size(124, 21);
            this.txtBeforeLength.TabIndex = 89;
            this.txtBeforeLength.Text = "0.00";
            this.txtBeforeLength.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(241, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 88;
            this.label8.Text = "当前长度";
            this.label8.Visible = false;
            // 
            // txtAfterLength
            // 
            this.txtAfterLength.Enabled = false;
            this.txtAfterLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAfterLength.Location = new System.Drawing.Point(300, 145);
            this.txtAfterLength.MaxValue = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.txtAfterLength.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAfterLength.Name = "txtAfterLength";
            this.txtAfterLength.PointCount = 3;
            this.txtAfterLength.Size = new System.Drawing.Size(124, 21);
            this.txtAfterLength.TabIndex = 91;
            this.txtAfterLength.Text = "0.00";
            this.txtAfterLength.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(241, 149);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 90;
            this.label11.Text = "剩余长度";
            this.label11.Visible = false;
            // 
            // txtLength
            // 
            this.txtLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLength.Location = new System.Drawing.Point(96, 112);
            this.txtLength.MaxValue = 999999;
            this.txtLength.MinValue = 0;
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(76, 21);
            this.txtLength.TabIndex = 92;
            this.txtLength.Text = "0";
            // 
            // ucSpecification1
            // 
            this.ucSpecification1.Enabled = false;
            this.ucSpecification1.Location = new System.Drawing.Point(63, 44);
            this.ucSpecification1.Name = "ucSpecification1";
            this.ucSpecification1.SelectedWidth = null;
            this.ucSpecification1.Selected克重 = null;
            this.ucSpecification1.Size = new System.Drawing.Size(226, 27);
            this.ucSpecification1.Specification = "*";
            this.ucSpecification1.TabIndex = 93;
            // 
            // FrmSlice
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(436, 385);
            this.Controls.Add(this.ucSpecification1);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.txtAfterLength);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBeforeLength);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.chkOver);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lnkCustomer);
            this.Controls.Add(this.txtWareHouse);
            this.Controls.Add(this.lnkWareHouse);
            this.Controls.Add(this.txtSlicers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemainWeight);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dtSliceDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCurrentWeigth);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSlice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "开平";
            this.Load += new System.EventHandler(this.FrmSlice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnOk;
        private LJH.GeneralLibrary.WinformControl.IntergerTextBox txtCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtSliceDate;
        private System.Windows.Forms.Label label6;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtCurrentWeigth;
        private System.Windows.Forms.Label label9;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtRemainWeight;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtSlicers;
        private GeneralLibrary.WinformControl.DBCTextBox txtWareHouse;
        private System.Windows.Forms.LinkLabel lnkWareHouse;
        private GeneralLibrary.WinformControl.DBCTextBox txtCustomer;
        private System.Windows.Forms.LinkLabel lnkCustomer;
        private System.Windows.Forms.CheckBox chkOver;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox txtMemo;
        private GeneralLibrary.WinformControl.DecimalTextBox txtBeforeLength;
        private System.Windows.Forms.Label label8;
        private GeneralLibrary.WinformControl.DecimalTextBox txtAfterLength;
        private System.Windows.Forms.Label label11;
        private GeneralLibrary.WinformControl.IntergerTextBox txtLength;
        private Controls.UCSpecification ucSpecification1;

    }
}