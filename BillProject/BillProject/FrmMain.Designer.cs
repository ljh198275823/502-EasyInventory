namespace LJH.BillProject.BillProject
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblAmount = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnAddLog = new System.Windows.Forms.ToolStripButton();
            this.btnThisMonth = new System.Windows.Forms.ToolStripButton();
            this.btnShowThisYear = new System.Windows.Forms.ToolStripButton();
            this.btnShowLastYear = new System.Windows.Forms.ToolStripButton();
            this.btn_Report = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblAmount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 320);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1106, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddLog,
            this.toolStripSeparator1,
            this.btnThisMonth,
            this.btnShowThisYear,
            this.btnShowLastYear,
            this.btn_Report,
            this.toolStripSeparator2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1106, 54);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 54);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1106, 266);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // lblAmount
            // 
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(1091, 17);
            this.lblAmount.Spring = true;
            // 
            // btnAddLog
            // 
            this.btnAddLog.Image = global::LJH.BillProject.Properties.Resources.Write;
            this.btnAddLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddLog.Name = "btnAddLog";
            this.btnAddLog.Size = new System.Drawing.Size(48, 51);
            this.btnAddLog.Text = "记   账";
            this.btnAddLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddLog.Click += new System.EventHandler(this.btnAddLog_Click);
            // 
            // btnThisMonth
            // 
            this.btnThisMonth.Image = global::LJH.BillProject.Properties.Resources.month;
            this.btnThisMonth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThisMonth.Name = "btnThisMonth";
            this.btnThisMonth.Size = new System.Drawing.Size(60, 51);
            this.btnThisMonth.Text = "显示本月";
            this.btnThisMonth.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThisMonth.Click += new System.EventHandler(this.btnThisMonth_Click);
            // 
            // btnShowThisYear
            // 
            this.btnShowThisYear.Image = global::LJH.BillProject.Properties.Resources.month;
            this.btnShowThisYear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowThisYear.Name = "btnShowThisYear";
            this.btnShowThisYear.Size = new System.Drawing.Size(60, 51);
            this.btnShowThisYear.Text = "显示本年";
            this.btnShowThisYear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnShowThisYear.Click += new System.EventHandler(this.btnShowThisYear_Click);
            // 
            // btnShowLastYear
            // 
            this.btnShowLastYear.Image = global::LJH.BillProject.Properties.Resources.month;
            this.btnShowLastYear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowLastYear.Name = "btnShowLastYear";
            this.btnShowLastYear.Size = new System.Drawing.Size(60, 51);
            this.btnShowLastYear.Text = "最近一年";
            this.btnShowLastYear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnShowLastYear.Click += new System.EventHandler(this.btnShowLastYear_Click);
            // 
            // btn_Report
            // 
            this.btn_Report.Image = global::LJH.BillProject.Properties.Resources.columns;
            this.btn_Report.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Report.Name = "btn_Report";
            this.btn_Report.Size = new System.Drawing.Size(60, 51);
            this.btn_Report.Text = "消费报表";
            this.btn_Report.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Report.Click += new System.EventHandler(this.btn_Report_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::LJH.BillProject.Properties.Resources.delete;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(48, 51);
            this.toolStripButton1.Text = "退   出";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 342);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "我的记账小秘";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripButton btnAddLog;
        private System.Windows.Forms.ToolStripButton btnThisMonth;
        private System.Windows.Forms.ToolStripButton btnShowLastYear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btn_Report;
        private System.Windows.Forms.ToolStripStatusLabel lblAmount;
        private System.Windows.Forms.ToolStripButton btnShowThisYear;
    }
}