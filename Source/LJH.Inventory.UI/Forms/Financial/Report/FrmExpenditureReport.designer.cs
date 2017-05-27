namespace LJH.Inventory.UI.Forms.Financial.Report
{
    partial class FrmExpenditureReport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucDateTimeInterval1 = new LJH.GeneralLibrary.WinformControl.UCDateTimeInterval();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtRequest = new System.Windows.Forms.TextBox();
            this.lnkRequest = new System.Windows.Forms.LinkLabel();
            this.txtCategory = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkCategory = new System.Windows.Forms.LinkLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSheetDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(621, 12);
            this.btnSearch.Size = new System.Drawing.Size(142, 23);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(621, 41);
            this.btnSaveAs.Size = new System.Drawing.Size(142, 23);
            // 
            // btnColumn
            // 
            this.btnColumn.Location = new System.Drawing.Point(621, 70);
            this.btnColumn.Size = new System.Drawing.Size(142, 23);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucDateTimeInterval1);
            this.groupBox1.Location = new System.Drawing.Point(5, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 90);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "创建日期";
            // 
            // ucDateTimeInterval1
            // 
            this.ucDateTimeInterval1.EndDateTime = new System.DateTime(2012, 6, 2, 10, 42, 8, 482);
            this.ucDateTimeInterval1.Location = new System.Drawing.Point(4, 14);
            this.ucDateTimeInterval1.Name = "ucDateTimeInterval1";
            this.ucDateTimeInterval1.ShowTime = false;
            this.ucDateTimeInterval1.Size = new System.Drawing.Size(221, 74);
            this.ucDateTimeInterval1.StartDateTime = new System.DateTime(2012, 6, 2, 10, 42, 8, 482);
            this.ucDateTimeInterval1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtRequest);
            this.groupBox3.Controls.Add(this.lnkRequest);
            this.groupBox3.Controls.Add(this.txtCategory);
            this.groupBox3.Controls.Add(this.lnkCategory);
            this.groupBox3.Location = new System.Drawing.Point(242, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(363, 90);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其它";
            // 
            // txtRequest
            // 
            this.txtRequest.Location = new System.Drawing.Point(75, 48);
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.ReadOnly = true;
            this.txtRequest.Size = new System.Drawing.Size(153, 21);
            this.txtRequest.TabIndex = 40;
            this.txtRequest.DoubleClick += new System.EventHandler(this.txtRequest_DoubleClick);
            // 
            // lnkRequest
            // 
            this.lnkRequest.AutoSize = true;
            this.lnkRequest.Location = new System.Drawing.Point(28, 51);
            this.lnkRequest.Name = "lnkRequest";
            this.lnkRequest.Size = new System.Drawing.Size(41, 12);
            this.lnkRequest.TabIndex = 39;
            this.lnkRequest.TabStop = true;
            this.lnkRequest.Text = "申请人";
            this.lnkRequest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRequest_LinkClicked);
            // 
            // txtCategory
            // 
            this.txtCategory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCategory.Location = new System.Drawing.Point(75, 18);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(153, 21);
            this.txtCategory.TabIndex = 38;
            this.txtCategory.DoubleClick += new System.EventHandler(this.txtCategory_DoubleClick);
            // 
            // lnkCategory
            // 
            this.lnkCategory.AutoSize = true;
            this.lnkCategory.Location = new System.Drawing.Point(16, 21);
            this.lnkCategory.Name = "lnkCategory";
            this.lnkCategory.Size = new System.Drawing.Size(53, 12);
            this.lnkCategory.TabIndex = 0;
            this.lnkCategory.TabStop = true;
            this.lnkCategory.Text = "费用类别";
            this.lnkCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCategory_LinkClicked);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colSheetDate,
            this.colCategory,
            this.colAmount,
            this.colAccount,
            this.colState,
            this.colRequest,
            this.colPayee,
            this.colMemo});
            this.dataGridView1.Location = new System.Drawing.Point(5, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1146, 437);
            this.dataGridView1.TabIndex = 117;
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colID.HeaderText = "支出单号";
            this.colID.MinimumWidth = 100;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colSheetDate
            // 
            this.colSheetDate.HeaderText = "日期";
            this.colSheetDate.Name = "colSheetDate";
            this.colSheetDate.ReadOnly = true;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "费用类别";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            // 
            // colAmount
            // 
            dataGridViewCellStyle1.NullValue = "C2";
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.colAmount.HeaderText = "金额";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 120;
            // 
            // colAccount
            // 
            this.colAccount.HeaderText = "付款账号";
            this.colAccount.Name = "colAccount";
            this.colAccount.ReadOnly = true;
            this.colAccount.Width = 120;
            // 
            // colState
            // 
            this.colState.HeaderText = "状态";
            this.colState.Name = "colState";
            this.colState.ReadOnly = true;
            // 
            // colRequest
            // 
            this.colRequest.HeaderText = "申请人";
            this.colRequest.Name = "colRequest";
            this.colRequest.ReadOnly = true;
            // 
            // colPayee
            // 
            this.colPayee.HeaderText = "对方账号";
            this.colPayee.Name = "colPayee";
            this.colPayee.ReadOnly = true;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            // 
            // FrmExpenditureReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 566);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "FrmExpenditureReport";
            this.Text = "公司管理费用报表";
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnSaveAs, 0);
            this.Controls.SetChildIndex(this.btnColumn, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private GeneralLibrary.WinformControl.UCDateTimeInterval ucDateTimeInterval1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.LinkLabel lnkCategory;
        private GeneralLibrary.WinformControl.DBCTextBox txtCategory;
        private System.Windows.Forms.TextBox txtRequest;
        private System.Windows.Forms.LinkLabel lnkRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSheetDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
    }
}