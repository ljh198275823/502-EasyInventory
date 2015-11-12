namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class FrmSteelRollCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSteelRollCheck));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewWeigth = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtNewLength = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtChecker = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkChecker = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(208, 142);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOk.Location = new System.Drawing.Point(116, 142);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "重量(吨)";
            // 
            // txtNewWeigth
            // 
            this.txtNewWeigth.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtNewWeigth.Location = new System.Drawing.Point(80, 18);
            this.txtNewWeigth.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtNewWeigth.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNewWeigth.Name = "txtNewWeigth";
            this.txtNewWeigth.PointCount = 3;
            this.txtNewWeigth.Size = new System.Drawing.Size(93, 21);
            this.txtNewWeigth.TabIndex = 0;
            this.txtNewWeigth.Text = "0.00";
            // 
            // txtNewLength
            // 
            this.txtNewLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtNewLength.Location = new System.Drawing.Point(289, 18);
            this.txtNewLength.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtNewLength.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNewLength.Name = "txtNewLength";
            this.txtNewLength.PointCount = 2;
            this.txtNewLength.Size = new System.Drawing.Size(93, 21);
            this.txtNewLength.TabIndex = 1;
            this.txtNewLength.Text = "0.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "长度(米)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "备注";
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(80, 92);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(302, 21);
            this.txtMemo.TabIndex = 3;
            // 
            // txtChecker
            // 
            this.txtChecker.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtChecker.Location = new System.Drawing.Point(80, 57);
            this.txtChecker.Name = "txtChecker";
            this.txtChecker.Size = new System.Drawing.Size(302, 21);
            this.txtChecker.TabIndex = 2;
            // 
            // lnkChecker
            // 
            this.lnkChecker.AutoSize = true;
            this.lnkChecker.Location = new System.Drawing.Point(34, 60);
            this.lnkChecker.Name = "lnkChecker";
            this.lnkChecker.Size = new System.Drawing.Size(41, 12);
            this.lnkChecker.TabIndex = 24;
            this.lnkChecker.TabStop = true;
            this.lnkChecker.Text = "盘点人";
            this.lnkChecker.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkChecker_LinkClicked);
            // 
            // FrmSteelRollCheck
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(404, 177);
            this.Controls.Add(this.lnkChecker);
            this.Controls.Add(this.txtChecker);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNewLength);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNewWeigth);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSteelRollCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "原材料盘点";
            this.Load += new System.EventHandler(this.FrmSteelRollCheck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label2;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtNewWeigth;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtNewLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private GeneralLibrary.WinformControl.DBCTextBox txtChecker;
        private System.Windows.Forms.LinkLabel lnkChecker;
    }
}