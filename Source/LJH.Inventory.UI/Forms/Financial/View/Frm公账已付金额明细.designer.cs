namespace LJH.Inventory.UI.Forms.Financial.View
{
    partial class Frm公账已付金额明细
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm公账已付金额明细));
            this.GridView = new System.Windows.Forms.DataGridView();
            this.colSheetID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colSheetDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssigned = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colRemain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStackSheetID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colPayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Assign = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMSG = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnLast3Month = new System.Windows.Forms.Button();
            this.ucDateTimeInterval1 = new LJH.Inventory.UI.Controls.UCDateTimeInterval();
            this.chkSheetDate = new System.Windows.Forms.CheckBox();
            this.txtKeyword = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridView
            // 
            this.GridView.AllowUserToAddRows = false;
            this.GridView.AllowUserToDeleteRows = false;
            this.GridView.AllowUserToResizeRows = false;
            this.GridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridView.BackgroundColor = System.Drawing.Color.White;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSheetID,
            this.colSheetDate,
            this.colAccount,
            this.colAmount,
            this.colAssigned,
            this.colRemain,
            this.colStackSheetID,
            this.colPayer,
            this.colMemo});
            this.GridView.ContextMenuStrip = this.contextMenuStrip1;
            this.GridView.Location = new System.Drawing.Point(0, 90);
            this.GridView.Name = "GridView";
            this.GridView.RowHeadersVisible = false;
            this.GridView.RowTemplate.Height = 23;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView.Size = new System.Drawing.Size(994, 297);
            this.GridView.TabIndex = 21;
            this.GridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellClick);
            // 
            // colSheetID
            // 
            this.colSheetID.HeaderText = "单据编号";
            this.colSheetID.MinimumWidth = 150;
            this.colSheetID.Name = "colSheetID";
            this.colSheetID.ReadOnly = true;
            this.colSheetID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSheetID.Width = 150;
            // 
            // colSheetDate
            // 
            dataGridViewCellStyle1.Format = "D";
            dataGridViewCellStyle1.NullValue = null;
            this.colSheetDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colSheetDate.HeaderText = "日期";
            this.colSheetDate.Name = "colSheetDate";
            this.colSheetDate.ReadOnly = true;
            this.colSheetDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAccount
            // 
            this.colAccount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAccount.HeaderText = "公司账号";
            this.colAccount.Name = "colAccount";
            this.colAccount.ReadOnly = true;
            this.colAccount.Width = 78;
            // 
            // colAmount
            // 
            dataGridViewCellStyle2.Format = "C2";
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAmount.HeaderText = "金额";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAssigned
            // 
            dataGridViewCellStyle3.Format = "C2";
            this.colAssigned.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAssigned.HeaderText = "已核销";
            this.colAssigned.Name = "colAssigned";
            this.colAssigned.ReadOnly = true;
            this.colAssigned.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colRemain
            // 
            dataGridViewCellStyle4.Format = "C2";
            this.colRemain.DefaultCellStyle = dataGridViewCellStyle4;
            this.colRemain.HeaderText = "未核销";
            this.colRemain.Name = "colRemain";
            this.colRemain.ReadOnly = true;
            this.colRemain.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colStackSheetID
            // 
            this.colStackSheetID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colStackSheetID.HeaderText = "送货单";
            this.colStackSheetID.Name = "colStackSheetID";
            this.colStackSheetID.ReadOnly = true;
            this.colStackSheetID.Width = 47;
            // 
            // colPayer
            // 
            this.colPayer.HeaderText = "对方账号";
            this.colPayer.Name = "colPayer";
            this.colPayer.ReadOnly = true;
            // 
            // colMemo
            // 
            this.colMemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            this.colMemo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_Add,
            this.mnu_Assign,
            this.cMnu_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 70);
            // 
            // mnu_Add
            // 
            this.mnu_Add.Name = "mnu_Add";
            this.mnu_Add.Size = new System.Drawing.Size(136, 22);
            this.mnu_Add.Text = "新建转公账";
            this.mnu_Add.Click += new System.EventHandler(this.mnu_Add_Click);
            // 
            // mnu_Assign
            // 
            this.mnu_Assign.Name = "mnu_Assign";
            this.mnu_Assign.Size = new System.Drawing.Size(136, 22);
            this.mnu_Assign.Text = "核销...";
            this.mnu_Assign.Click += new System.EventHandler(this.mnu_Assign_Click);
            // 
            // cMnu_Export
            // 
            this.cMnu_Export.Name = "cMnu_Export";
            this.cMnu_Export.Size = new System.Drawing.Size(136, 22);
            this.cMnu_Export.Text = "导出...";
            this.cMnu_Export.Click += new System.EventHandler(this.cMnu_Export_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMSG});
            this.statusStrip1.Location = new System.Drawing.Point(0, 390);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(994, 22);
            this.statusStrip1.TabIndex = 26;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMSG
            // 
            this.lblMSG.Name = "lblMSG";
            this.lblMSG.Size = new System.Drawing.Size(979, 17);
            this.lblMSG.Spring = true;
            this.lblMSG.Text = "共 0 项";
            // 
            // btnLast3Month
            // 
            this.btnLast3Month.Location = new System.Drawing.Point(9, 34);
            this.btnLast3Month.Name = "btnLast3Month";
            this.btnLast3Month.Size = new System.Drawing.Size(75, 39);
            this.btnLast3Month.TabIndex = 141;
            this.btnLast3Month.Text = "最近三个月";
            this.btnLast3Month.UseVisualStyleBackColor = true;
            this.btnLast3Month.Click += new System.EventHandler(this.btnLast3Month_Click);
            // 
            // ucDateTimeInterval1
            // 
            this.ucDateTimeInterval1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDateTimeInterval1.EndDateTime = new System.DateTime(2015, 11, 19, 10, 3, 12, 722);
            this.ucDateTimeInterval1.Location = new System.Drawing.Point(85, 5);
            this.ucDateTimeInterval1.Name = "ucDateTimeInterval1";
            this.ucDateTimeInterval1.ShowTime = true;
            this.ucDateTimeInterval1.Size = new System.Drawing.Size(223, 74);
            this.ucDateTimeInterval1.StartDateTime = new System.DateTime(2015, 11, 19, 10, 3, 12, 722);
            this.ucDateTimeInterval1.TabIndex = 140;
            this.ucDateTimeInterval1.ValueChanged += new System.EventHandler(this.ucDateTimeInterval1_ValueChanged);
            // 
            // chkSheetDate
            // 
            this.chkSheetDate.AutoSize = true;
            this.chkSheetDate.Location = new System.Drawing.Point(12, 12);
            this.chkSheetDate.Name = "chkSheetDate";
            this.chkSheetDate.Size = new System.Drawing.Size(72, 16);
            this.chkSheetDate.TabIndex = 139;
            this.chkSheetDate.Text = "开单日期";
            this.chkSheetDate.UseVisualStyleBackColor = true;
            this.chkSheetDate.Click += new System.EventHandler(this.chkSheetDate_CheckedChanged);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtKeyword.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKeyword.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtKeyword.Location = new System.Drawing.Point(381, 24);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(252, 30);
            this.txtKeyword.TabIndex = 157;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 156;
            this.label2.Text = "模糊匹配";
            // 
            // Frm公账已付金额明细
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 412);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLast3Month);
            this.Controls.Add(this.ucDateTimeInterval1);
            this.Controls.Add(this.chkSheetDate);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.GridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm公账已付金额明细";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "对公已付金额明细";
            this.Load += new System.EventHandler(this.FrmCustomerPaymentView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnu_Assign;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMSG;
        private System.Windows.Forms.ToolStripMenuItem mnu_Add;
        private System.Windows.Forms.DataGridViewLinkColumn colSheetID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSheetDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewLinkColumn colAssigned;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemain;
        private System.Windows.Forms.DataGridViewLinkColumn colStackSheetID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        private System.Windows.Forms.Button btnLast3Month;
        private Controls.UCDateTimeInterval ucDateTimeInterval1;
        private System.Windows.Forms.CheckBox chkSheetDate;
        private GeneralLibrary.WinformControl.DBCTextBox txtKeyword;
        private System.Windows.Forms.Label label2;
    }
}