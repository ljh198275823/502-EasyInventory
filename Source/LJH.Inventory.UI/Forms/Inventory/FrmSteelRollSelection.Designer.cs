namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class FrmSteelRollSelection
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
            this.ucFormViewMain = new LJH.GeneralLibrary.WinformControl.UCFormView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ucFormViewMain
            // 
            this.ucFormViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucFormViewMain.FormHeaderLength = 135;
            this.ucFormViewMain.HideHeader = true;
            this.ucFormViewMain.Location = new System.Drawing.Point(-1, 2);
            this.ucFormViewMain.Name = "ucFormViewMain";
            this.ucFormViewMain.Size = new System.Drawing.Size(1468, 457);
            this.ucFormViewMain.TabIndex = 12;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(1304, 479);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(141, 41);
            this.btnClose.TabIndex = 93;
            this.btnClose.Text = "取消(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(1142, 479);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(141, 41);
            this.btnOk.TabIndex = 92;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmSteelRollSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 531);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.ucFormViewMain);
            this.Name = "FrmSteelRollSelection";
            this.Text = "原材料选择";
            this.Load += new System.EventHandler(this.FrmSteelRollSelection_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GeneralLibrary.WinformControl.UCFormView ucFormViewMain;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnOk;
    }
}