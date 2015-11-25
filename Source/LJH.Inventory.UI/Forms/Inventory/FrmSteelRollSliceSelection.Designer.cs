namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class FrmSteelRollSliceSelection
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.customerCombobox1 = new LJH.Inventory.UI.Controls.CustomerCombobox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLength = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtWeight = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.chk开条 = new System.Windows.Forms.CheckBox();
            this.chk开吨 = new System.Windows.Forms.CheckBox();
            this.chk开平 = new System.Windows.Forms.CheckBox();
            this.categoryComboBox1 = new LJH.Inventory.UI.Controls.CategoryComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSpecification = new LJH.Inventory.UI.Controls.SpecificationComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridview1 = new System.Windows.Forms.DataGridView();
            this.colWareHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealThick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wareHouseComboBox1 = new LJH.Inventory.UI.Controls.WareHouseComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridview1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.wareHouseComboBox1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.customerCombobox1);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.txtLength);
            this.panel5.Controls.Add(this.txtWeight);
            this.panel5.Controls.Add(this.chk开条);
            this.panel5.Controls.Add(this.chk开吨);
            this.panel5.Controls.Add(this.chk开平);
            this.panel5.Controls.Add(this.categoryComboBox1);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.cmbSpecification);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1185, 48);
            this.panel5.TabIndex = 7;
            // 
            // customerCombobox1
            // 
            this.customerCombobox1.FormattingEnabled = true;
            this.customerCombobox1.Location = new System.Drawing.Point(544, 15);
            this.customerCombobox1.Name = "customerCombobox1";
            this.customerCombobox1.Size = new System.Drawing.Size(121, 20);
            this.customerCombobox1.TabIndex = 93;
            this.customerCombobox1.TextChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(512, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 92;
            this.label8.Text = "客户";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(818, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 89;
            this.label4.Text = "长度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(692, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 88;
            this.label3.Text = "重量";
            // 
            // txtLength
            // 
            this.txtLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLength.Location = new System.Drawing.Point(853, 15);
            this.txtLength.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtLength.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLength.Name = "txtLength";
            this.txtLength.PointCount = 2;
            this.txtLength.Size = new System.Drawing.Size(72, 21);
            this.txtLength.TabIndex = 87;
            this.txtLength.Text = "0";
            this.txtLength.TextChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // txtWeight
            // 
            this.txtWeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWeight.Location = new System.Drawing.Point(727, 15);
            this.txtWeight.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtWeight.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.PointCount = 3;
            this.txtWeight.Size = new System.Drawing.Size(81, 21);
            this.txtWeight.TabIndex = 86;
            this.txtWeight.Text = "0";
            this.txtWeight.TextChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // chk开条
            // 
            this.chk开条.AutoSize = true;
            this.chk开条.Checked = true;
            this.chk开条.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk开条.Location = new System.Drawing.Point(1008, 17);
            this.chk开条.Name = "chk开条";
            this.chk开条.Size = new System.Drawing.Size(48, 16);
            this.chk开条.TabIndex = 85;
            this.chk开条.Text = "开条";
            this.chk开条.UseVisualStyleBackColor = true;
            this.chk开条.CheckedChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // chk开吨
            // 
            this.chk开吨.AutoSize = true;
            this.chk开吨.Checked = true;
            this.chk开吨.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk开吨.Location = new System.Drawing.Point(1063, 17);
            this.chk开吨.Name = "chk开吨";
            this.chk开吨.Size = new System.Drawing.Size(48, 16);
            this.chk开吨.TabIndex = 84;
            this.chk开吨.Text = "开吨";
            this.chk开吨.UseVisualStyleBackColor = true;
            this.chk开吨.CheckedChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // chk开平
            // 
            this.chk开平.AutoSize = true;
            this.chk开平.Checked = true;
            this.chk开平.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk开平.Location = new System.Drawing.Point(954, 17);
            this.chk开平.Name = "chk开平";
            this.chk开平.Size = new System.Drawing.Size(48, 16);
            this.chk开平.TabIndex = 83;
            this.chk开平.Text = "开平";
            this.chk开平.UseVisualStyleBackColor = true;
            this.chk开平.CheckedChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // categoryComboBox1
            // 
            this.categoryComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox1.FormattingEnabled = true;
            this.categoryComboBox1.Location = new System.Drawing.Point(213, 15);
            this.categoryComboBox1.Name = "categoryComboBox1";
            this.categoryComboBox1.Size = new System.Drawing.Size(121, 20);
            this.categoryComboBox1.TabIndex = 82;
            this.categoryComboBox1.SelectedIndexChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 81;
            this.label2.Text = "类别";
            // 
            // cmbSpecification
            // 
            this.cmbSpecification.FormattingEnabled = true;
            this.cmbSpecification.Location = new System.Drawing.Point(374, 15);
            this.cmbSpecification.Name = "cmbSpecification";
            this.cmbSpecification.Size = new System.Drawing.Size(121, 20);
            this.cmbSpecification.TabIndex = 80;
            this.cmbSpecification.TextChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(342, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 79;
            this.label5.Text = "规格";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(996, 471);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 41);
            this.btnClose.TabIndex = 91;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOk.Location = new System.Drawing.Point(874, 471);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 41);
            this.btnOk.TabIndex = 90;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1185, 50);
            this.panel1.TabIndex = 117;
            // 
            // dataGridview1
            // 
            this.dataGridview1.AllowUserToAddRows = false;
            this.dataGridview1.AllowUserToDeleteRows = false;
            this.dataGridview1.AllowUserToResizeRows = false;
            this.dataGridview1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridview1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridview1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colWareHouse,
            this.colCategory,
            this.colSpecification,
            this.colModel,
            this.colWeight,
            this.colLength,
            this.colRealThick,
            this.colCustomer,
            this.colCount,
            this.colDeliveryCount,
            this.colMemo});
            this.dataGridview1.Location = new System.Drawing.Point(2, 50);
            this.dataGridview1.Name = "dataGridview1";
            this.dataGridview1.RowHeadersVisible = false;
            this.dataGridview1.RowTemplate.Height = 23;
            this.dataGridview1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridview1.Size = new System.Drawing.Size(1180, 402);
            this.dataGridview1.TabIndex = 118;
            this.dataGridview1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridview1_CellContentClick);
            this.dataGridview1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridview1_CellEndEdit);
            // 
            // colWareHouse
            // 
            this.colWareHouse.HeaderText = "仓库";
            this.colWareHouse.Name = "colWareHouse";
            this.colWareHouse.ReadOnly = true;
            this.colWareHouse.Width = 120;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "产品类别";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            // 
            // colSpecification
            // 
            this.colSpecification.HeaderText = "规格";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            // 
            // colModel
            // 
            this.colModel.HeaderText = "加工类型";
            this.colModel.Name = "colModel";
            this.colModel.ReadOnly = true;
            // 
            // colWeight
            // 
            dataGridViewCellStyle5.Format = "N3";
            this.colWeight.DefaultCellStyle = dataGridViewCellStyle5;
            this.colWeight.HeaderText = "重量(吨)";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            // 
            // colLength
            // 
            dataGridViewCellStyle6.Format = "N2";
            this.colLength.DefaultCellStyle = dataGridViewCellStyle6;
            this.colLength.HeaderText = "长度(米)";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            // 
            // colRealThick
            // 
            dataGridViewCellStyle7.Format = "N3";
            this.colRealThick.DefaultCellStyle = dataGridViewCellStyle7;
            this.colRealThick.HeaderText = "厚度";
            this.colRealThick.Name = "colRealThick";
            this.colRealThick.ReadOnly = true;
            // 
            // colCustomer
            // 
            this.colCustomer.HeaderText = "客户";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            // 
            // colCount
            // 
            dataGridViewCellStyle8.Format = "N0";
            this.colCount.DefaultCellStyle = dataGridViewCellStyle8;
            this.colCount.HeaderText = "数量";
            this.colCount.Name = "colCount";
            this.colCount.ReadOnly = true;
            this.colCount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colDeliveryCount
            // 
            this.colDeliveryCount.HeaderText = "出货数量";
            this.colDeliveryCount.Name = "colDeliveryCount";
            this.colDeliveryCount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            this.colMemo.Width = 150;
            // 
            // wareHouseComboBox1
            // 
            this.wareHouseComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wareHouseComboBox1.FormattingEnabled = true;
            this.wareHouseComboBox1.Location = new System.Drawing.Point(54, 15);
            this.wareHouseComboBox1.Name = "wareHouseComboBox1";
            this.wareHouseComboBox1.Size = new System.Drawing.Size(112, 20);
            this.wareHouseComboBox1.TabIndex = 95;
            this.wareHouseComboBox1.TextChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 94;
            this.label1.Text = "仓库";
            // 
            // FrmSteelRollSliceSelection
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1185, 554);
            this.Controls.Add(this.dataGridview1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOk);
            this.Name = "FrmSteelRollSliceSelection";
            this.Text = "小件出库选择";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.dataGridview1, 0);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridview1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private GeneralLibrary.WinformControl.DecimalTextBox txtLength;
        private GeneralLibrary.WinformControl.DecimalTextBox txtWeight;
        private System.Windows.Forms.CheckBox chk开条;
        private System.Windows.Forms.CheckBox chk开吨;
        private System.Windows.Forms.CheckBox chk开平;
        private Controls.CategoryComboBox categoryComboBox1;
        private System.Windows.Forms.Label label2;
        private Controls.SpecificationComboBox cmbSpecification;
        private System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridview1;
        private Controls.CustomerCombobox customerCombobox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWareHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealThick;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        private Controls.WareHouseComboBox wareHouseComboBox1;
        private System.Windows.Forms.Label label1;
    }
}