namespace InventoryDemo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.商务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_SteelRoll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_InventorySheet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_SteelRollSlice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_DeliverySheet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_Customer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Supplier = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_WareHouse = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.财务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_CustomerState = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_SupplierState = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_Expanditure = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_Reports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_DeliveryRecordReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_SliceRecordReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_DeliveryStatistic = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_InventoryRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_PaymentReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_TaxBillReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_System = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Staff = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Role = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_ChangePwd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_LogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Manual = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_DogInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Aboat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new LJH.GeneralLibrary.WinformControl.MyToolStrip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblOperator = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDBPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.pSecondary = new System.Windows.Forms.Panel();
            this.ucFormViewSecondary = new LJH.GeneralLibrary.WinformControl.UCFormView();
            this.pMain = new System.Windows.Forms.Panel();
            this.ucFormViewMain = new LJH.GeneralLibrary.WinformControl.UCFormView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.mnu_Operator = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pSecondary.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.商务ToolStripMenuItem,
            this.toolStripSeparator9,
            this.财务ToolStripMenuItem,
            this.toolStripSeparator12,
            this.mnu_Reports,
            this.toolStripSeparator14,
            this.mnu_System,
            this.toolStripSeparator15,
            this.mnu_Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(899, 38);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 商务ToolStripMenuItem
            // 
            this.商务ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_SteelRoll,
            this.mnu_InventorySheet,
            this.mnu_SteelRollSlice,
            this.mnu_DeliverySheet,
            this.toolStripSeparator16,
            this.mnu_Customer,
            this.mnu_Supplier,
            this.mnu_WareHouse,
            this.toolStripSeparator17});
            this.商务ToolStripMenuItem.Image = global::InventoryDemo.Properties.Resources.inventory1;
            this.商务ToolStripMenuItem.Name = "商务ToolStripMenuItem";
            this.商务ToolStripMenuItem.Size = new System.Drawing.Size(74, 34);
            this.商务ToolStripMenuItem.Text = "仓库";
            // 
            // mnu_SteelRoll
            // 
            this.mnu_SteelRoll.Enabled = false;
            this.mnu_SteelRoll.Name = "mnu_SteelRoll";
            this.mnu_SteelRoll.Size = new System.Drawing.Size(148, 22);
            this.mnu_SteelRoll.Text = "原材料管理";
            this.mnu_SteelRoll.Click += new System.EventHandler(this.mnu_Material_Click);
            // 
            // mnu_InventorySheet
            // 
            this.mnu_InventorySheet.Enabled = false;
            this.mnu_InventorySheet.Name = "mnu_InventorySheet";
            this.mnu_InventorySheet.Size = new System.Drawing.Size(148, 22);
            this.mnu_InventorySheet.Text = "原材料入库单";
            this.mnu_InventorySheet.Visible = false;
            this.mnu_InventorySheet.Click += new System.EventHandler(this.mnu_InventorySheet_Click);
            // 
            // mnu_SteelRollSlice
            // 
            this.mnu_SteelRollSlice.Enabled = false;
            this.mnu_SteelRollSlice.Name = "mnu_SteelRollSlice";
            this.mnu_SteelRollSlice.Size = new System.Drawing.Size(148, 22);
            this.mnu_SteelRollSlice.Text = "小件管理";
            this.mnu_SteelRollSlice.Click += new System.EventHandler(this.mnu_Inventory_Click);
            // 
            // mnu_DeliverySheet
            // 
            this.mnu_DeliverySheet.Enabled = false;
            this.mnu_DeliverySheet.Name = "mnu_DeliverySheet";
            this.mnu_DeliverySheet.Size = new System.Drawing.Size(148, 22);
            this.mnu_DeliverySheet.Text = "送货单管理";
            this.mnu_DeliverySheet.Click += new System.EventHandler(this.mnu_DeliverySheet_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(145, 6);
            // 
            // mnu_Customer
            // 
            this.mnu_Customer.Enabled = false;
            this.mnu_Customer.Name = "mnu_Customer";
            this.mnu_Customer.Size = new System.Drawing.Size(148, 22);
            this.mnu_Customer.Text = "客户资料";
            this.mnu_Customer.Click += new System.EventHandler(this.mnu_Customer_Click);
            // 
            // mnu_Supplier
            // 
            this.mnu_Supplier.Enabled = false;
            this.mnu_Supplier.Name = "mnu_Supplier";
            this.mnu_Supplier.Size = new System.Drawing.Size(148, 22);
            this.mnu_Supplier.Text = "供应商资料";
            this.mnu_Supplier.Click += new System.EventHandler(this.mnu_Supplier_Click);
            // 
            // mnu_WareHouse
            // 
            this.mnu_WareHouse.Enabled = false;
            this.mnu_WareHouse.Name = "mnu_WareHouse";
            this.mnu_WareHouse.Size = new System.Drawing.Size(148, 22);
            this.mnu_WareHouse.Text = "仓库资料";
            this.mnu_WareHouse.Click += new System.EventHandler(this.mnu_WareHouse_Click_1);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 34);
            // 
            // 财务ToolStripMenuItem
            // 
            this.财务ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_CustomerState,
            this.toolStripSeparator6,
            this.mnu_SupplierState,
            this.toolStripSeparator1,
            this.mnu_Expanditure});
            this.财务ToolStripMenuItem.Image = global::InventoryDemo.Properties.Resources.finance;
            this.财务ToolStripMenuItem.Name = "财务ToolStripMenuItem";
            this.财务ToolStripMenuItem.Size = new System.Drawing.Size(74, 34);
            this.财务ToolStripMenuItem.Text = "财务";
            // 
            // mnu_CustomerState
            // 
            this.mnu_CustomerState.Enabled = false;
            this.mnu_CustomerState.Name = "mnu_CustomerState";
            this.mnu_CustomerState.Size = new System.Drawing.Size(160, 22);
            this.mnu_CustomerState.Text = "客户应收管理";
            this.mnu_CustomerState.Click += new System.EventHandler(this.mnu_CustomerReceivable_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(157, 6);
            // 
            // mnu_SupplierState
            // 
            this.mnu_SupplierState.Enabled = false;
            this.mnu_SupplierState.Name = "mnu_SupplierState";
            this.mnu_SupplierState.Size = new System.Drawing.Size(160, 22);
            this.mnu_SupplierState.Text = "供应商应付账款";
            this.mnu_SupplierState.Click += new System.EventHandler(this.mnu_SupplierState_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // mnu_Expanditure
            // 
            this.mnu_Expanditure.Enabled = false;
            this.mnu_Expanditure.Name = "mnu_Expanditure";
            this.mnu_Expanditure.Size = new System.Drawing.Size(160, 22);
            this.mnu_Expanditure.Text = "公司管理费用";
            this.mnu_Expanditure.Click += new System.EventHandler(this.mnu_Expanditure_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 34);
            this.toolStripSeparator12.Visible = false;
            // 
            // mnu_Reports
            // 
            this.mnu_Reports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_DeliveryRecordReport,
            this.mnu_SliceRecordReport,
            this.mnu_DeliveryStatistic,
            this.mnu_InventoryRecord,
            this.toolStripSeparator4,
            this.mnu_PaymentReport,
            this.mnu_TaxBillReport});
            this.mnu_Reports.Image = global::InventoryDemo.Properties.Resources.report;
            this.mnu_Reports.Name = "mnu_Reports";
            this.mnu_Reports.Size = new System.Drawing.Size(74, 34);
            this.mnu_Reports.Text = "报表";
            // 
            // mnu_DeliveryRecordReport
            // 
            this.mnu_DeliveryRecordReport.Enabled = false;
            this.mnu_DeliveryRecordReport.Name = "mnu_DeliveryRecordReport";
            this.mnu_DeliveryRecordReport.Size = new System.Drawing.Size(160, 22);
            this.mnu_DeliveryRecordReport.Text = "出货记录查询";
            this.mnu_DeliveryRecordReport.Click += new System.EventHandler(this.mnu_DeliveryRecordReport_Click);
            // 
            // mnu_SliceRecordReport
            // 
            this.mnu_SliceRecordReport.Name = "mnu_SliceRecordReport";
            this.mnu_SliceRecordReport.Size = new System.Drawing.Size(160, 22);
            this.mnu_SliceRecordReport.Text = "原料卷加工记录";
            this.mnu_SliceRecordReport.Click += new System.EventHandler(this.mnu_SliceRecordReport_Click);
            // 
            // mnu_DeliveryStatistic
            // 
            this.mnu_DeliveryStatistic.Name = "mnu_DeliveryStatistic";
            this.mnu_DeliveryStatistic.Size = new System.Drawing.Size(160, 22);
            this.mnu_DeliveryStatistic.Text = "出货统计";
            this.mnu_DeliveryStatistic.Click += new System.EventHandler(this.mnu_DeliveryStatistic_Click);
            // 
            // mnu_InventoryRecord
            // 
            this.mnu_InventoryRecord.Name = "mnu_InventoryRecord";
            this.mnu_InventoryRecord.Size = new System.Drawing.Size(160, 22);
            this.mnu_InventoryRecord.Text = "入库记录查询";
            this.mnu_InventoryRecord.Click += new System.EventHandler(this.mnu_InventoryRecord_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(157, 6);
            // 
            // mnu_PaymentReport
            // 
            this.mnu_PaymentReport.Name = "mnu_PaymentReport";
            this.mnu_PaymentReport.Size = new System.Drawing.Size(160, 22);
            this.mnu_PaymentReport.Text = "收付款流水报表";
            this.mnu_PaymentReport.Click += new System.EventHandler(this.客户付款流水报表ToolStripMenuItem_Click);
            // 
            // mnu_TaxBillReport
            // 
            this.mnu_TaxBillReport.Name = "mnu_TaxBillReport";
            this.mnu_TaxBillReport.Size = new System.Drawing.Size(160, 22);
            this.mnu_TaxBillReport.Text = "增值税发票报表";
            this.mnu_TaxBillReport.Click += new System.EventHandler(this.客户增值税发票报表ToolStripMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 34);
            // 
            // mnu_System
            // 
            this.mnu_System.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_Options,
            this.mnu_Staff,
            this.mnu_Operator,
            this.mnu_Role,
            this.toolStripSeparator7,
            this.mnu_ChangePwd,
            this.mnu_LogOut,
            this.mnu_Exit});
            this.mnu_System.Image = global::InventoryDemo.Properties.Resources.system;
            this.mnu_System.Name = "mnu_System";
            this.mnu_System.Size = new System.Drawing.Size(74, 34);
            this.mnu_System.Text = "系统";
            // 
            // mnu_Options
            // 
            this.mnu_Options.Enabled = false;
            this.mnu_Options.Name = "mnu_Options";
            this.mnu_Options.Size = new System.Drawing.Size(152, 22);
            this.mnu_Options.Text = "系统参数";
            this.mnu_Options.Click += new System.EventHandler(this.mnu_Options_Click);
            // 
            // mnu_Staff
            // 
            this.mnu_Staff.Enabled = false;
            this.mnu_Staff.Name = "mnu_Staff";
            this.mnu_Staff.Size = new System.Drawing.Size(152, 22);
            this.mnu_Staff.Text = "人员部门";
            this.mnu_Staff.Click += new System.EventHandler(this.mnu_Staff_Click);
            // 
            // mnu_Role
            // 
            this.mnu_Role.Enabled = false;
            this.mnu_Role.Name = "mnu_Role";
            this.mnu_Role.Size = new System.Drawing.Size(152, 22);
            this.mnu_Role.Text = "角色";
            this.mnu_Role.Click += new System.EventHandler(this.mnu_Role_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(149, 6);
            // 
            // mnu_ChangePwd
            // 
            this.mnu_ChangePwd.Name = "mnu_ChangePwd";
            this.mnu_ChangePwd.Size = new System.Drawing.Size(152, 22);
            this.mnu_ChangePwd.Text = "更改密码";
            this.mnu_ChangePwd.Click += new System.EventHandler(this.mnu_ChangePwd_Click);
            // 
            // mnu_LogOut
            // 
            this.mnu_LogOut.Name = "mnu_LogOut";
            this.mnu_LogOut.Size = new System.Drawing.Size(152, 22);
            this.mnu_LogOut.Text = "更改用户";
            this.mnu_LogOut.Click += new System.EventHandler(this.mnu_LogOut_Click);
            // 
            // mnu_Exit
            // 
            this.mnu_Exit.Name = "mnu_Exit";
            this.mnu_Exit.Size = new System.Drawing.Size(152, 22);
            this.mnu_Exit.Text = "退出";
            this.mnu_Exit.Click += new System.EventHandler(this.mnu_Exit_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 34);
            // 
            // mnu_Help
            // 
            this.mnu_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_Manual,
            this.mnu_DogInfo,
            this.mnu_Aboat});
            this.mnu_Help.Image = global::InventoryDemo.Properties.Resources.help;
            this.mnu_Help.Name = "mnu_Help";
            this.mnu_Help.Size = new System.Drawing.Size(74, 34);
            this.mnu_Help.Text = "帮助";
            // 
            // mnu_Manual
            // 
            this.mnu_Manual.Name = "mnu_Manual";
            this.mnu_Manual.Size = new System.Drawing.Size(148, 22);
            this.mnu_Manual.Text = "用户手册";
            this.mnu_Manual.Click += new System.EventHandler(this.mnu_Manual_Click);
            // 
            // mnu_DogInfo
            // 
            this.mnu_DogInfo.Name = "mnu_DogInfo";
            this.mnu_DogInfo.Size = new System.Drawing.Size(148, 22);
            this.mnu_DogInfo.Text = "软件授权信息";
            this.mnu_DogInfo.Click += new System.EventHandler(this.mnu_DogInfo_Click);
            // 
            // mnu_Aboat
            // 
            this.mnu_Aboat.Name = "mnu_Aboat";
            this.mnu_Aboat.Size = new System.Drawing.Size(148, 22);
            this.mnu_Aboat.Text = "关于";
            this.mnu_Aboat.Click += new System.EventHandler(this.mnu_Aboat_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ClickThrough = true;
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(899, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblOperator,
            this.toolStripStatusLabel2,
            this.lblDBPath});
            this.statusStrip1.Location = new System.Drawing.Point(0, 308);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(899, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabel1.Text = "操作员:";
            // 
            // lblOperator
            // 
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel2.Text = "数据文件";
            // 
            // lblDBPath
            // 
            this.lblDBPath.ForeColor = System.Drawing.Color.Blue;
            this.lblDBPath.Name = "lblDBPath";
            this.lblDBPath.Size = new System.Drawing.Size(0, 17);
            // 
            // pSecondary
            // 
            this.pSecondary.AutoScroll = true;
            this.pSecondary.BackColor = System.Drawing.SystemColors.Control;
            this.pSecondary.Controls.Add(this.ucFormViewSecondary);
            this.pSecondary.Dock = System.Windows.Forms.DockStyle.Right;
            this.pSecondary.Location = new System.Drawing.Point(780, 0);
            this.pSecondary.Name = "pSecondary";
            this.pSecondary.Size = new System.Drawing.Size(119, 270);
            this.pSecondary.TabIndex = 11;
            this.pSecondary.Visible = false;
            // 
            // ucFormViewSecondary
            // 
            this.ucFormViewSecondary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFormViewSecondary.FormHeaderLength = 135;
            this.ucFormViewSecondary.HideHeader = false;
            this.ucFormViewSecondary.Location = new System.Drawing.Point(0, 0);
            this.ucFormViewSecondary.Name = "ucFormViewSecondary";
            this.ucFormViewSecondary.Size = new System.Drawing.Size(119, 270);
            this.ucFormViewSecondary.TabIndex = 7;
            // 
            // pMain
            // 
            this.pMain.AutoScroll = true;
            this.pMain.BackColor = System.Drawing.SystemColors.Control;
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 0);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(780, 270);
            this.pMain.TabIndex = 13;
            // 
            // ucFormViewMain
            // 
            this.ucFormViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFormViewMain.FormHeaderLength = 135;
            this.ucFormViewMain.HideHeader = false;
            this.ucFormViewMain.Location = new System.Drawing.Point(0, 0);
            this.ucFormViewMain.Name = "ucFormViewMain";
            this.ucFormViewMain.Size = new System.Drawing.Size(772, 270);
            this.ucFormViewMain.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucFormViewMain);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.pMain);
            this.panel1.Controls.Add(this.pSecondary);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(899, 270);
            this.panel1.TabIndex = 15;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(772, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 270);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            this.splitter1.Visible = false;
            // 
            // mnu_Operator
            // 
            this.mnu_Operator.Enabled = false;
            this.mnu_Operator.Name = "mnu_Operator";
            this.mnu_Operator.Size = new System.Drawing.Size(152, 22);
            this.mnu_Operator.Text = "操作员管理";
            this.mnu_Operator.Click += new System.EventHandler(this.mnu_Operator_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 330);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "易存企业管理系统(演示版)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pSecondary.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnu_System;
        private System.Windows.Forms.ToolStripMenuItem mnu_Exit;
        private LJH.GeneralLibrary.WinformControl.MyToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnu_Help;
        private System.Windows.Forms.ToolStripMenuItem mnu_Manual;
        private System.Windows.Forms.ToolStripMenuItem mnu_Aboat;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnu_Reports;
        private System.Windows.Forms.ToolStripMenuItem mnu_DeliveryRecordReport;
        private System.Windows.Forms.ToolStripMenuItem mnu_LogOut;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblOperator;
        private System.Windows.Forms.ToolStripMenuItem mnu_InventoryRecord;
        private System.Windows.Forms.ToolStripMenuItem mnu_DeliveryStatistic;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnu_DogInfo;
        private System.Windows.Forms.Panel pSecondary;
        private System.Windows.Forms.Panel pMain;
        private LJH.GeneralLibrary.WinformControl.UCFormView ucFormViewMain;
        private System.Windows.Forms.ToolStripMenuItem 商务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_DeliverySheet;
        private System.Windows.Forms.ToolStripMenuItem 财务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_Expanditure;
        private System.Windows.Forms.ToolStripMenuItem mnu_SteelRollSlice;
        private System.Windows.Forms.ToolStripMenuItem mnu_InventorySheet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private LJH.GeneralLibrary.WinformControl.UCFormView ucFormViewSecondary;
        private System.Windows.Forms.ToolStripMenuItem mnu_CustomerState;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripMenuItem mnu_ChangePwd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnu_SupplierState;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblDBPath;
        private System.Windows.Forms.ToolStripMenuItem mnu_SteelRoll;
        private System.Windows.Forms.ToolStripMenuItem mnu_WareHouse;
        private System.Windows.Forms.ToolStripMenuItem mnu_Options;
        private System.Windows.Forms.ToolStripMenuItem mnu_Staff;
        private System.Windows.Forms.ToolStripMenuItem mnu_Role;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem mnu_Customer;
        private System.Windows.Forms.ToolStripMenuItem mnu_SliceRecordReport;
        private System.Windows.Forms.ToolStripMenuItem mnu_PaymentReport;
        private System.Windows.Forms.ToolStripMenuItem mnu_TaxBillReport;
        private System.Windows.Forms.ToolStripMenuItem mnu_Supplier;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripMenuItem mnu_Operator;
    }
}