﻿namespace LJH.Inventory.UI.Forms.Inventory
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
            this.rd开条 = new System.Windows.Forms.RadioButton();
            this.rd开平 = new System.Windows.Forms.RadioButton();
            this.txtCount = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.txtLength = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtSliceDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCurrentWeigth = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtCurrentLength = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rd开吨 = new System.Windows.Forms.RadioButton();
            this.txtRemainWeight = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtRemainLength = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSlicers = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtCategory = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtSpecification = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtWareHouse = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkWareHouse = new System.Windows.Forms.LinkLabel();
            this.txtCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkCustomer = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFormula = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtResult = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.chkOver = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(313, 333);
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
            this.btnOk.Location = new System.Drawing.Point(191, 333);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 41);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // rd开条
            // 
            this.rd开条.AutoSize = true;
            this.rd开条.Location = new System.Drawing.Point(65, 3);
            this.rd开条.Name = "rd开条";
            this.rd开条.Size = new System.Drawing.Size(47, 16);
            this.rd开条.TabIndex = 1;
            this.rd开条.Tag = "卷材";
            this.rd开条.Text = "开条";
            this.rd开条.UseVisualStyleBackColor = true;
            this.rd开条.CheckedChanged += new System.EventHandler(this.rd开条_CheckedChanged);
            // 
            // rd开平
            // 
            this.rd开平.AutoSize = true;
            this.rd开平.Location = new System.Drawing.Point(4, 3);
            this.rd开平.Name = "rd开平";
            this.rd开平.Size = new System.Drawing.Size(47, 16);
            this.rd开平.TabIndex = 0;
            this.rd开平.Tag = "板材";
            this.rd开平.Text = "开平";
            this.rd开平.UseVisualStyleBackColor = true;
            this.rd开平.CheckedChanged += new System.EventHandler(this.rd开平_CheckedChanged);
            // 
            // txtCount
            // 
            this.txtCount.Enabled = false;
            this.txtCount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCount.Location = new System.Drawing.Point(250, 140);
            this.txtCount.MaxValue = 10000;
            this.txtCount.MinValue = 0;
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(70, 21);
            this.txtCount.TabIndex = 13;
            this.txtCount.Text = "0";
            this.txtCount.TextChanged += new System.EventHandler(this.txtLength_TextChanged);
            // 
            // txtLength
            // 
            this.txtLength.Enabled = false;
            this.txtLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLength.Location = new System.Drawing.Point(96, 140);
            this.txtLength.MaxValue = new decimal(new int[] {
            1000,
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
            this.txtLength.Size = new System.Drawing.Size(82, 21);
            this.txtLength.TabIndex = 12;
            this.txtLength.Text = "0.00";
            this.txtLength.TextChanged += new System.EventHandler(this.txtLength_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "开平数量";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "开平长度(米)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(50, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 42;
            this.label13.Text = "类  别";
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
            this.txtCurrentWeigth.PointCount = 3;
            this.txtCurrentWeigth.Size = new System.Drawing.Size(114, 21);
            this.txtCurrentWeigth.TabIndex = 36;
            this.txtCurrentWeigth.Text = "0.00";
            // 
            // txtCurrentLength
            // 
            this.txtCurrentLength.Enabled = false;
            this.txtCurrentLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCurrentLength.Location = new System.Drawing.Point(300, 78);
            this.txtCurrentLength.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtCurrentLength.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCurrentLength.Name = "txtCurrentLength";
            this.txtCurrentLength.PointCount = 2;
            this.txtCurrentLength.Size = new System.Drawing.Size(126, 21);
            this.txtCurrentLength.TabIndex = 37;
            this.txtCurrentLength.Text = "0.00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(219, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 38;
            this.label8.Text = "当前长度(米)";
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 43;
            this.label10.Text = "加工方式";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rd开吨);
            this.panel1.Controls.Add(this.rd开条);
            this.panel1.Controls.Add(this.rd开平);
            this.panel1.Location = new System.Drawing.Point(96, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 21);
            this.panel1.TabIndex = 44;
            // 
            // rd开吨
            // 
            this.rd开吨.AutoSize = true;
            this.rd开吨.Location = new System.Drawing.Point(128, 2);
            this.rd开吨.Name = "rd开吨";
            this.rd开吨.Size = new System.Drawing.Size(47, 16);
            this.rd开吨.TabIndex = 2;
            this.rd开吨.Tag = "开吨";
            this.rd开吨.Text = "开吨";
            this.rd开吨.UseVisualStyleBackColor = true;
            this.rd开吨.CheckedChanged += new System.EventHandler(this.rd开吨_CheckedChanged);
            // 
            // txtRemainWeight
            // 
            this.txtRemainWeight.Enabled = false;
            this.txtRemainWeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtRemainWeight.Location = new System.Drawing.Point(96, 202);
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
            this.txtRemainWeight.PointCount = 3;
            this.txtRemainWeight.Size = new System.Drawing.Size(114, 21);
            this.txtRemainWeight.TabIndex = 46;
            this.txtRemainWeight.Text = "0.00";
            // 
            // txtRemainLength
            // 
            this.txtRemainLength.Enabled = false;
            this.txtRemainLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtRemainLength.Location = new System.Drawing.Point(300, 202);
            this.txtRemainLength.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtRemainLength.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRemainLength.Name = "txtRemainLength";
            this.txtRemainLength.PointCount = 2;
            this.txtRemainLength.Size = new System.Drawing.Size(126, 21);
            this.txtRemainLength.TabIndex = 47;
            this.txtRemainLength.Text = "0.00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(219, 206);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 48;
            this.label11.Text = "剩余长度(米)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 206);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 45;
            this.label12.Text = "剩余重量(吨)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 49;
            this.label1.Text = "加工人员";
            // 
            // txtSlicers
            // 
            this.txtSlicers.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSlicers.Location = new System.Drawing.Point(96, 296);
            this.txtSlicers.Name = "txtSlicers";
            this.txtSlicers.Size = new System.Drawing.Size(328, 21);
            this.txtSlicers.TabIndex = 50;
            // 
            // txtCategory
            // 
            this.txtCategory.Enabled = false;
            this.txtCategory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCategory.Location = new System.Drawing.Point(96, 47);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(115, 21);
            this.txtCategory.TabIndex = 53;
            // 
            // txtSpecification
            // 
            this.txtSpecification.Enabled = false;
            this.txtSpecification.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSpecification.Location = new System.Drawing.Point(300, 47);
            this.txtSpecification.Name = "txtSpecification";
            this.txtSpecification.Size = new System.Drawing.Size(124, 21);
            this.txtSpecification.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 54;
            this.label5.Text = "规  格";
            // 
            // txtWareHouse
            // 
            this.txtWareHouse.Enabled = false;
            this.txtWareHouse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWareHouse.Location = new System.Drawing.Point(96, 236);
            this.txtWareHouse.Name = "txtWareHouse";
            this.txtWareHouse.Size = new System.Drawing.Size(328, 21);
            this.txtWareHouse.TabIndex = 78;
            // 
            // lnkWareHouse
            // 
            this.lnkWareHouse.AutoSize = true;
            this.lnkWareHouse.Location = new System.Drawing.Point(38, 240);
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
            this.txtCustomer.Location = new System.Drawing.Point(96, 266);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(328, 21);
            this.txtCustomer.TabIndex = 80;
            // 
            // lnkCustomer
            // 
            this.lnkCustomer.AutoSize = true;
            this.lnkCustomer.Location = new System.Drawing.Point(56, 270);
            this.lnkCustomer.Name = "lnkCustomer";
            this.lnkCustomer.Size = new System.Drawing.Size(35, 12);
            this.lnkCustomer.TabIndex = 79;
            this.lnkCustomer.TabStop = true;
            this.lnkCustomer.Text = "客户:";
            this.lnkCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomer_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 81;
            this.label2.Text = "开条说明";
            // 
            // txtFormula
            // 
            this.txtFormula.Enabled = false;
            this.txtFormula.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtFormula.Location = new System.Drawing.Point(96, 171);
            this.txtFormula.Name = "txtFormula";
            this.txtFormula.Size = new System.Drawing.Size(217, 21);
            this.txtFormula.TabIndex = 82;
            this.txtFormula.TextChanged += new System.EventHandler(this.txtFormula_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(319, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 83;
            this.label7.Text = "=";
            // 
            // txtResult
            // 
            this.txtResult.Enabled = false;
            this.txtResult.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtResult.Location = new System.Drawing.Point(336, 171);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(88, 21);
            this.txtResult.TabIndex = 84;
            // 
            // chkOver
            // 
            this.chkOver.AutoSize = true;
            this.chkOver.ForeColor = System.Drawing.Color.Red;
            this.chkOver.Location = new System.Drawing.Point(336, 142);
            this.chkOver.Name = "chkOver";
            this.chkOver.Size = new System.Drawing.Size(84, 16);
            this.chkOver.TabIndex = 85;
            this.chkOver.Text = "卷子已开完";
            this.chkOver.UseVisualStyleBackColor = true;
            this.chkOver.CheckedChanged += new System.EventHandler(this.chkOver_CheckedChanged);
            // 
            // FrmSlice
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(436, 386);
            this.Controls.Add(this.chkOver);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFormula);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lnkCustomer);
            this.Controls.Add(this.txtWareHouse);
            this.Controls.Add(this.lnkWareHouse);
            this.Controls.Add(this.txtSpecification);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtSlicers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemainWeight);
            this.Controls.Add(this.txtRemainLength);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtSliceDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCurrentWeigth);
            this.Controls.Add(this.txtCurrentLength);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSlice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "卷材加工";
            this.Load += new System.EventHandler(this.FrmSlice_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.RadioButton rd开条;
        private System.Windows.Forms.RadioButton rd开平;
        private LJH.GeneralLibrary.WinformControl.IntergerTextBox txtCount;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtSliceDate;
        private System.Windows.Forms.Label label6;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtCurrentWeigth;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtCurrentLength;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtRemainWeight;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtRemainLength;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtSlicers;
        private System.Windows.Forms.RadioButton rd开吨;
        private GeneralLibrary.WinformControl.DBCTextBox txtCategory;
        private GeneralLibrary.WinformControl.DBCTextBox txtSpecification;
        private System.Windows.Forms.Label label5;
        private GeneralLibrary.WinformControl.DBCTextBox txtWareHouse;
        private System.Windows.Forms.LinkLabel lnkWareHouse;
        private GeneralLibrary.WinformControl.DBCTextBox txtCustomer;
        private System.Windows.Forms.LinkLabel lnkCustomer;
        private System.Windows.Forms.Label label2;
        private GeneralLibrary.WinformControl.DBCTextBox txtFormula;
        private System.Windows.Forms.Label label7;
        private GeneralLibrary.WinformControl.DBCTextBox txtResult;
        private System.Windows.Forms.CheckBox chkOver;

    }
}