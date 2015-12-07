namespace LJH.Inventory.UI.Forms.Inventory.Report
{
    partial class FrmSliceRecordReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucDateTimeInterval1 = new LJH.GeneralLibrary.WinformControl.UCDateTimeInterval();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chk开吨 = new System.Windows.Forms.CheckBox();
            this.chk开条 = new System.Windows.Forms.CheckBox();
            this.chk开平 = new System.Windows.Forms.CheckBox();
            this.categoryComboBox1 = new LJH.Inventory.UI.Controls.CategoryComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.comSpecification1 = new LJH.Inventory.UI.Controls.SpecificationComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSlicedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSlicedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBeforeWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBeforeLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAfterWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAfterLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSlicer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceRoll = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(498, 18);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(498, 47);
            // 
            // btnColumn
            // 
            this.btnColumn.Location = new System.Drawing.Point(498, 78);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucDateTimeInterval1);
            this.groupBox1.Location = new System.Drawing.Point(8, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 99);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "加工日期";
            // 
            // ucDateTimeInterval1
            // 
            this.ucDateTimeInterval1.EndDateTime = new System.DateTime(2012, 6, 2, 10, 42, 8, 482);
            this.ucDateTimeInterval1.Location = new System.Drawing.Point(8, 16);
            this.ucDateTimeInterval1.Name = "ucDateTimeInterval1";
            this.ucDateTimeInterval1.ShowTime = false;
            this.ucDateTimeInterval1.Size = new System.Drawing.Size(221, 74);
            this.ucDateTimeInterval1.StartDateTime = new System.DateTime(2012, 6, 2, 10, 42, 8, 482);
            this.ucDateTimeInterval1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chk开吨);
            this.groupBox3.Controls.Add(this.chk开条);
            this.groupBox3.Controls.Add(this.chk开平);
            this.groupBox3.Controls.Add(this.categoryComboBox1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.comSpecification1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(247, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(199, 90);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其它";
            // 
            // chk开吨
            // 
            this.chk开吨.AutoSize = true;
            this.chk开吨.Checked = true;
            this.chk开吨.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk开吨.Location = new System.Drawing.Point(149, 68);
            this.chk开吨.Name = "chk开吨";
            this.chk开吨.Size = new System.Drawing.Size(48, 16);
            this.chk开吨.TabIndex = 32;
            this.chk开吨.Text = "开吨";
            this.chk开吨.UseVisualStyleBackColor = true;
            // 
            // chk开条
            // 
            this.chk开条.AutoSize = true;
            this.chk开条.Checked = true;
            this.chk开条.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk开条.Location = new System.Drawing.Point(99, 68);
            this.chk开条.Name = "chk开条";
            this.chk开条.Size = new System.Drawing.Size(48, 16);
            this.chk开条.TabIndex = 31;
            this.chk开条.Text = "开条";
            this.chk开条.UseVisualStyleBackColor = true;
            // 
            // chk开平
            // 
            this.chk开平.AutoSize = true;
            this.chk开平.Checked = true;
            this.chk开平.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk开平.Location = new System.Drawing.Point(46, 68);
            this.chk开平.Name = "chk开平";
            this.chk开平.Size = new System.Drawing.Size(48, 16);
            this.chk开平.TabIndex = 30;
            this.chk开平.Text = "平板";
            this.chk开平.UseVisualStyleBackColor = true;
            // 
            // categoryComboBox1
            // 
            this.categoryComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox1.FormattingEnabled = true;
            this.categoryComboBox1.Location = new System.Drawing.Point(46, 17);
            this.categoryComboBox1.Name = "categoryComboBox1";
            this.categoryComboBox1.Size = new System.Drawing.Size(145, 20);
            this.categoryComboBox1.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "类别";
            // 
            // comSpecification1
            // 
            this.comSpecification1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comSpecification1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSpecification1.FormattingEnabled = true;
            this.comSpecification1.Location = new System.Drawing.Point(46, 44);
            this.comSpecification1.Name = "comSpecification1";
            this.comSpecification1.Size = new System.Drawing.Size(145, 20);
            this.comSpecification1.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "规格";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSlicedDateTime,
            this.colCategoryID,
            this.colSpecification,
            this.colSlicedTo,
            this.colBeforeWeight,
            this.colBeforeLength,
            this.colLength,
            this.colWeight,
            this.colAmount,
            this.colTotalWeight,
            this.colTotalLength,
            this.colAfterWeight,
            this.colAfterLength,
            this.colCustomer,
            this.colSlicer,
            this.colSourceRoll,
            this.colMemo});
            this.dataGridView1.Location = new System.Drawing.Point(5, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1243, 350);
            this.dataGridView1.TabIndex = 38;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
            // 
            // colSlicedDateTime
            // 
            this.colSlicedDateTime.HeaderText = "加工日期";
            this.colSlicedDateTime.Name = "colSlicedDateTime";
            this.colSlicedDateTime.ReadOnly = true;
            // 
            // colCategoryID
            // 
            this.colCategoryID.HeaderText = "类别";
            this.colCategoryID.Name = "colCategoryID";
            this.colCategoryID.ReadOnly = true;
            // 
            // colSpecification
            // 
            this.colSpecification.HeaderText = "规格";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            this.colSpecification.Width = 80;
            // 
            // colSlicedTo
            // 
            this.colSlicedTo.HeaderText = "小件类型";
            this.colSlicedTo.Name = "colSlicedTo";
            this.colSlicedTo.ReadOnly = true;
            this.colSlicedTo.Width = 80;
            // 
            // colBeforeWeight
            // 
            dataGridViewCellStyle1.Format = "N3";
            this.colBeforeWeight.DefaultCellStyle = dataGridViewCellStyle1;
            this.colBeforeWeight.HeaderText = "加工前重量";
            this.colBeforeWeight.Name = "colBeforeWeight";
            this.colBeforeWeight.ReadOnly = true;
            // 
            // colBeforeLength
            // 
            dataGridViewCellStyle2.Format = "N3";
            this.colBeforeLength.DefaultCellStyle = dataGridViewCellStyle2;
            this.colBeforeLength.HeaderText = "加工前长度";
            this.colBeforeLength.Name = "colBeforeLength";
            this.colBeforeLength.ReadOnly = true;
            // 
            // colLength
            // 
            dataGridViewCellStyle3.Format = "N3";
            this.colLength.DefaultCellStyle = dataGridViewCellStyle3;
            this.colLength.HeaderText = "小件长度";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.Width = 80;
            // 
            // colWeight
            // 
            dataGridViewCellStyle4.Format = "N3";
            this.colWeight.DefaultCellStyle = dataGridViewCellStyle4;
            this.colWeight.HeaderText = "小件重量";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            this.colWeight.Width = 80;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "加工数量";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 80;
            // 
            // colTotalWeight
            // 
            dataGridViewCellStyle5.Format = "N3";
            this.colTotalWeight.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTotalWeight.HeaderText = "加工重量";
            this.colTotalWeight.Name = "colTotalWeight";
            this.colTotalWeight.ReadOnly = true;
            this.colTotalWeight.Width = 80;
            // 
            // colTotalLength
            // 
            dataGridViewCellStyle6.Format = "N3";
            this.colTotalLength.DefaultCellStyle = dataGridViewCellStyle6;
            this.colTotalLength.HeaderText = "加工长度";
            this.colTotalLength.Name = "colTotalLength";
            this.colTotalLength.ReadOnly = true;
            this.colTotalLength.Width = 80;
            // 
            // colAfterWeight
            // 
            dataGridViewCellStyle7.Format = "N3";
            this.colAfterWeight.DefaultCellStyle = dataGridViewCellStyle7;
            this.colAfterWeight.HeaderText = "加工后重量";
            this.colAfterWeight.Name = "colAfterWeight";
            this.colAfterWeight.ReadOnly = true;
            // 
            // colAfterLength
            // 
            dataGridViewCellStyle8.Format = "N3";
            this.colAfterLength.DefaultCellStyle = dataGridViewCellStyle8;
            this.colAfterLength.HeaderText = "加工后长度";
            this.colAfterLength.Name = "colAfterLength";
            this.colAfterLength.ReadOnly = true;
            // 
            // colCustomer
            // 
            this.colCustomer.HeaderText = "客户";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            // 
            // colSlicer
            // 
            this.colSlicer.HeaderText = "加工人员";
            this.colSlicer.Name = "colSlicer";
            this.colSlicer.ReadOnly = true;
            // 
            // colSourceRoll
            // 
            this.colSourceRoll.HeaderText = "原材料卷";
            this.colSourceRoll.Name = "colSourceRoll";
            this.colSourceRoll.ReadOnly = true;
            this.colSourceRoll.Width = 80;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            // 
            // FrmSliceRecordReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 482);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSliceRecordReport";
            this.Text = "加工记录查询";
            this.Controls.SetChildIndex(this.btnColumn, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnSaveAs, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
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
        private LJH.GeneralLibrary.WinformControl.UCDateTimeInterval ucDateTimeInterval1;
        private System.Windows.Forms.GroupBox groupBox3;
        private Controls.CategoryComboBox categoryComboBox1;
        private System.Windows.Forms.Label label2;
        private Controls.SpecificationComboBox comSpecification1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk开吨;
        private System.Windows.Forms.CheckBox chk开条;
        private System.Windows.Forms.CheckBox chk开平;
        protected System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSlicedDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSlicedTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBeforeWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBeforeLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAfterWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAfterLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSlicer;
        private System.Windows.Forms.DataGridViewLinkColumn colSourceRoll;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
    }
}