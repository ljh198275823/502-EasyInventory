namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class Frm其它产品选择
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSteelRollSliceSelection));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucFormViewMain = new LJH.GeneralLibrary.WinformControl.UCFormView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colWareHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriginalThick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealThick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceRoll = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colSourceRollWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(1186, 631);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 41);
            this.btnClose.TabIndex = 91;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(1024, 631);
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
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ucFormViewMain);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1305, 599);
            this.panel1.TabIndex = 119;
            // 
            // ucFormViewMain
            // 
            this.ucFormViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFormViewMain.FormHeaderLength = 135;
            this.ucFormViewMain.HideHeader = true;
            this.ucFormViewMain.Location = new System.Drawing.Point(0, 0);
            this.ucFormViewMain.Name = "ucFormViewMain";
            this.ucFormViewMain.Size = new System.Drawing.Size(1303, 393);
            this.ucFormViewMain.TabIndex = 13;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 393);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1303, 6);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 399);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1303, 198);
            this.panel2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colWareHouse,
            this.colCategory,
            this.colSpecification,
            this.colLength,
            this.colModel,
            this.colWeight,
            this.colOriginalThick,
            this.colRealThick,
            this.colSourceRoll,
            this.colSourceRollWeight,
            this.colCustomer,
            this.colDeliveryCount,
            this.colAction});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1303, 198);
            this.dataGridView1.TabIndex = 119;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridview1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridview1_CellEndEdit);
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
            this.colCategory.Width = 80;
            // 
            // colSpecification
            // 
            this.colSpecification.HeaderText = "规格";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            // 
            // colLength
            // 
            dataGridViewCellStyle1.Format = "N3";
            this.colLength.DefaultCellStyle = dataGridViewCellStyle1;
            this.colLength.HeaderText = "长度(米)";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.Width = 80;
            // 
            // colModel
            // 
            this.colModel.HeaderText = "加工类型";
            this.colModel.Name = "colModel";
            this.colModel.ReadOnly = true;
            this.colModel.Width = 80;
            // 
            // colWeight
            // 
            dataGridViewCellStyle2.Format = "N4";
            this.colWeight.DefaultCellStyle = dataGridViewCellStyle2;
            this.colWeight.HeaderText = "重量(吨)";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            this.colWeight.Width = 80;
            // 
            // colOriginalThick
            // 
            dataGridViewCellStyle3.Format = "N3";
            this.colOriginalThick.DefaultCellStyle = dataGridViewCellStyle3;
            this.colOriginalThick.HeaderText = "入库厚度";
            this.colOriginalThick.Name = "colOriginalThick";
            this.colOriginalThick.ReadOnly = true;
            this.colOriginalThick.Width = 80;
            // 
            // colRealThick
            // 
            dataGridViewCellStyle4.Format = "N3";
            this.colRealThick.DefaultCellStyle = dataGridViewCellStyle4;
            this.colRealThick.HeaderText = "开平厚度";
            this.colRealThick.Name = "colRealThick";
            this.colRealThick.ReadOnly = true;
            this.colRealThick.Width = 80;
            // 
            // colSourceRoll
            // 
            this.colSourceRoll.HeaderText = "来源卷";
            this.colSourceRoll.Name = "colSourceRoll";
            this.colSourceRoll.ReadOnly = true;
            // 
            // colSourceRollWeight
            // 
            dataGridViewCellStyle5.Format = "N4";
            this.colSourceRollWeight.DefaultCellStyle = dataGridViewCellStyle5;
            this.colSourceRollWeight.HeaderText = "来源卷重";
            this.colSourceRollWeight.Name = "colSourceRollWeight";
            this.colSourceRollWeight.ReadOnly = true;
            this.colSourceRollWeight.Visible = false;
            this.colSourceRollWeight.Width = 80;
            // 
            // colCustomer
            // 
            this.colCustomer.HeaderText = "客户";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            // 
            // colDeliveryCount
            // 
            this.colDeliveryCount.HeaderText = "出货数量";
            this.colDeliveryCount.Name = "colDeliveryCount";
            this.colDeliveryCount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDeliveryCount.Width = 80;
            // 
            // colAction
            // 
            this.colAction.HeaderText = "";
            this.colAction.Name = "colAction";
            this.colAction.ReadOnly = true;
            // 
            // FrmSteelRollSliceSelection
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1310, 695);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSteelRollSliceSelection";
            this.Text = "小件出库选择";
            this.Load += new System.EventHandler(this.FrmSteelRollSliceSelection_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel1;
        private GeneralLibrary.WinformControl.UCFormView ucFormViewMain;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWareHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriginalThick;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealThick;
        private System.Windows.Forms.DataGridViewLinkColumn colSourceRoll;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceRollWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryCount;
        private System.Windows.Forms.DataGridViewButtonColumn colAction;
    }
}