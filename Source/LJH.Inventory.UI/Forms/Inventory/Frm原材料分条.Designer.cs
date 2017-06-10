namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class Frm原材料分条
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm原材料分条));
            this.label1 = new System.Windows.Forms.Label();
            this.txtWidth1 = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtCount1 = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtCount2 = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtWidth2 = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtCount3 = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtWidth3 = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtCount4 = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtWidth4 = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.txtCount5 = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.txtWidth5 = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtRemain = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.txtSpecification = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "分条规格";
            // 
            // txtWidth1
            // 
            this.txtWidth1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWidth1.Location = new System.Drawing.Point(68, 47);
            this.txtWidth1.MaxValue = 10000;
            this.txtWidth1.MinValue = 0;
            this.txtWidth1.Name = "txtWidth1";
            this.txtWidth1.Size = new System.Drawing.Size(70, 21);
            this.txtWidth1.TabIndex = 15;
            this.txtWidth1.Text = "0";
            this.txtWidth1.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "宽度";
            // 
            // txtCount1
            // 
            this.txtCount1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCount1.Location = new System.Drawing.Point(191, 47);
            this.txtCount1.MaxValue = 10000;
            this.txtCount1.MinValue = 0;
            this.txtCount1.Name = "txtCount1";
            this.txtCount1.Size = new System.Drawing.Size(70, 21);
            this.txtCount1.TabIndex = 17;
            this.txtCount1.Text = "0";
            this.txtCount1.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "数量";
            // 
            // txtCount2
            // 
            this.txtCount2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCount2.Location = new System.Drawing.Point(191, 84);
            this.txtCount2.MaxValue = 10000;
            this.txtCount2.MinValue = 0;
            this.txtCount2.Name = "txtCount2";
            this.txtCount2.Size = new System.Drawing.Size(70, 21);
            this.txtCount2.TabIndex = 21;
            this.txtCount2.Text = "0";
            this.txtCount2.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "数量";
            // 
            // txtWidth2
            // 
            this.txtWidth2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWidth2.Location = new System.Drawing.Point(68, 84);
            this.txtWidth2.MaxValue = 10000;
            this.txtWidth2.MinValue = 0;
            this.txtWidth2.Name = "txtWidth2";
            this.txtWidth2.Size = new System.Drawing.Size(70, 21);
            this.txtWidth2.TabIndex = 19;
            this.txtWidth2.Text = "0";
            this.txtWidth2.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "宽度";
            // 
            // txtCount3
            // 
            this.txtCount3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCount3.Location = new System.Drawing.Point(191, 122);
            this.txtCount3.MaxValue = 10000;
            this.txtCount3.MinValue = 0;
            this.txtCount3.Name = "txtCount3";
            this.txtCount3.Size = new System.Drawing.Size(70, 21);
            this.txtCount3.TabIndex = 25;
            this.txtCount3.Text = "0";
            this.txtCount3.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "数量";
            // 
            // txtWidth3
            // 
            this.txtWidth3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWidth3.Location = new System.Drawing.Point(68, 122);
            this.txtWidth3.MaxValue = 10000;
            this.txtWidth3.MinValue = 0;
            this.txtWidth3.Name = "txtWidth3";
            this.txtWidth3.Size = new System.Drawing.Size(70, 21);
            this.txtWidth3.TabIndex = 23;
            this.txtWidth3.Text = "0";
            this.txtWidth3.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "宽度";
            // 
            // txtCount4
            // 
            this.txtCount4.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCount4.Location = new System.Drawing.Point(191, 160);
            this.txtCount4.MaxValue = 10000;
            this.txtCount4.MinValue = 0;
            this.txtCount4.Name = "txtCount4";
            this.txtCount4.Size = new System.Drawing.Size(70, 21);
            this.txtCount4.TabIndex = 29;
            this.txtCount4.Text = "0";
            this.txtCount4.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(156, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "数量";
            // 
            // txtWidth4
            // 
            this.txtWidth4.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWidth4.Location = new System.Drawing.Point(68, 160);
            this.txtWidth4.MaxValue = 10000;
            this.txtWidth4.MinValue = 0;
            this.txtWidth4.Name = "txtWidth4";
            this.txtWidth4.Size = new System.Drawing.Size(70, 21);
            this.txtWidth4.TabIndex = 27;
            this.txtWidth4.Text = "0";
            this.txtWidth4.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 26;
            this.label9.Text = "宽度";
            // 
            // txtCount5
            // 
            this.txtCount5.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCount5.Location = new System.Drawing.Point(191, 200);
            this.txtCount5.MaxValue = 10000;
            this.txtCount5.MinValue = 0;
            this.txtCount5.Name = "txtCount5";
            this.txtCount5.Size = new System.Drawing.Size(70, 21);
            this.txtCount5.TabIndex = 33;
            this.txtCount5.Text = "0";
            this.txtCount5.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(156, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 32;
            this.label10.Text = "数量";
            // 
            // txtWidth5
            // 
            this.txtWidth5.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWidth5.Location = new System.Drawing.Point(68, 200);
            this.txtWidth5.MaxValue = 10000;
            this.txtWidth5.MinValue = 0;
            this.txtWidth5.Name = "txtWidth5";
            this.txtWidth5.Size = new System.Drawing.Size(70, 21);
            this.txtWidth5.TabIndex = 31;
            this.txtWidth5.Text = "0";
            this.txtWidth5.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(33, 204);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "宽度";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(152, 281);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 41);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOk.Location = new System.Drawing.Point(30, 281);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 41);
            this.btnOk.TabIndex = 34;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtRemain
            // 
            this.txtRemain.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtRemain.Location = new System.Drawing.Point(68, 240);
            this.txtRemain.MaxValue = 10000;
            this.txtRemain.MinValue = 0;
            this.txtRemain.Name = "txtRemain";
            this.txtRemain.Size = new System.Drawing.Size(70, 21);
            this.txtRemain.TabIndex = 37;
            this.txtRemain.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(33, 244);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 36;
            this.label12.Text = "剩余";
            // 
            // txtSpecification
            // 
            this.txtSpecification.Enabled = false;
            this.txtSpecification.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSpecification.Location = new System.Drawing.Point(68, 14);
            this.txtSpecification.Name = "txtSpecification";
            this.txtSpecification.Size = new System.Drawing.Size(193, 21);
            this.txtSpecification.TabIndex = 56;
            // 
            // Frm原材料分条
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 344);
            this.Controls.Add(this.txtSpecification);
            this.Controls.Add(this.txtRemain);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtCount5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtWidth5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCount4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtWidth4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCount3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtWidth3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCount2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtWidth2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCount1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWidth1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm原材料分条";
            this.Text = "原材料分条";
            this.Load += new System.EventHandler(this.Frm原材料分条_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private GeneralLibrary.WinformControl.IntergerTextBox txtWidth1;
        private System.Windows.Forms.Label label3;
        private GeneralLibrary.WinformControl.IntergerTextBox txtCount1;
        private System.Windows.Forms.Label label2;
        private GeneralLibrary.WinformControl.IntergerTextBox txtCount2;
        private System.Windows.Forms.Label label4;
        private GeneralLibrary.WinformControl.IntergerTextBox txtWidth2;
        private System.Windows.Forms.Label label5;
        private GeneralLibrary.WinformControl.IntergerTextBox txtCount3;
        private System.Windows.Forms.Label label6;
        private GeneralLibrary.WinformControl.IntergerTextBox txtWidth3;
        private System.Windows.Forms.Label label7;
        private GeneralLibrary.WinformControl.IntergerTextBox txtCount4;
        private System.Windows.Forms.Label label8;
        private GeneralLibrary.WinformControl.IntergerTextBox txtWidth4;
        private System.Windows.Forms.Label label9;
        private GeneralLibrary.WinformControl.IntergerTextBox txtCount5;
        private System.Windows.Forms.Label label10;
        private GeneralLibrary.WinformControl.IntergerTextBox txtWidth5;
        private System.Windows.Forms.Label label11;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnOk;
        private GeneralLibrary.WinformControl.IntergerTextBox txtRemain;
        private System.Windows.Forms.Label label12;
        private GeneralLibrary.WinformControl.DBCTextBox txtSpecification;
    }
}