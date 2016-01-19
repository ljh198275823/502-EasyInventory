using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.UI.Report;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary.Core.UI;
using LJH.GeneralLibrary.SoftDog;
using LJH.Inventory.UI.Forms;
using LJH.GeneralLibrary.SQLHelper;
using LJH.Inventory.UI.Forms.Financial;
using LJH.Inventory.UI.Forms.Sale;
using LJH.Inventory.UI.Forms.General;
using LJH.Inventory.UI.Forms.Purchase;
using LJH.Inventory.UI.Forms.Inventory;
using LJH.Inventory.UI.Forms.Inventory.Report;

namespace InventoryDemo
{
    public partial class FrmMain : Form,IMyMDIForm, LJH.GeneralLibrary.Core.UI.IOperatorRender
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<Form> _openedForms = new List<Form>();
        private SoftDogInfo _SoftDog;
        private DateTime _ExpireDate = new DateTime(2016, 1, 31);
        #endregion

        #region 私有方法
        private void ReadSoftDog()
        {
            string skey = AppSettings.Current.GetConfigContent("SKey");
            if (string.IsNullOrEmpty(skey))
            {
                skey = @"#i~xnUc4RH1G@\)$&7z6qv9xy@~<mTR5nUR?OU}jh`4r<qN>:*xZwz~E$0";
                AppSettings.Current.SaveConfig("SKey", skey);
            }
            SoftDogReader reader = new SoftDogReader(skey);
            try
            {
                _SoftDog = reader.ReadDog();
                if (_SoftDog == null)
                {
                    MessageBox.Show("加密狗访问错误：没有找到加密狗。如果加密狗已经插上，则可能是加密狗还没有加密，请先联系厂家进行加密!", "注意");
                    System.Environment.Exit(0);
                }
                else if ((_SoftDog.SoftwareList & SoftwareType.TYPE_Inventory) == 0)  //没有开放进销存软件权限
                {
                    MessageBox.Show("加密狗权限不足：原因可能是加密狗中没有开放进销存软件权限,请联系厂家开放相应的权限!", "注意");
                    System.Environment.Exit(0);
                }
                else if (_SoftDog.ExpiredDate < DateTime.Today && _SoftDog.ExpiredDate.AddDays(15) >= DateTime.Today) //已经过期
                {
                    DateTime expire = _SoftDog.ExpiredDate.AddDays(15);
                    TimeSpan ts = new TimeSpan(expire.Ticks - DateTime.Today.Ticks);
                    MessageBox.Show(string.Format("软件已经过期，还可以再试用 {0} 天，请尽快与供应商联系延长您的软件使用期!", (int)(ts.TotalDays + 1)), "注意");
                }
                else if (_SoftDog.ExpiredDate.AddDays(15) < DateTime.Today)
                {
                    MessageBox.Show("软件已经过期，请联系厂家延长期限!", "注意");
                    System.Environment.Exit(0);
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                System.Environment.Exit(0);
            }
        }

        private void DoLogIn()
        {
            DialogResult ret = (new FrmLogin()).ShowDialog();
            if (ret == DialogResult.OK)
            {
                ShowOperatorRights();
                if (_openedForms != null && _openedForms.Count > 0)
                {
                    foreach (Form frm in _openedForms)
                    {
                        if (frm is IOperatorRender)
                        {
                            (frm as IOperatorRender).ShowOperatorRights();
                        }
                    }
                }
                this.lblOperator.Text = Operator.Current.Name;
            }
            else
            {
                Environment.Exit(0);
            }
        }

        public void ShowOperatorRights()
        {
            Operator cur = Operator.Current;
            //基本资料
            this.mnu_Product.Enabled = cur.Permit(Permission.Product, PermissionActions.Read) || cur.Permit(Permission.Product, PermissionActions.Edit);
            this.mnu_Unit.Enabled = cur.Permit(Permission.Unit, PermissionActions.Read) || cur.Permit(Permission.Unit, PermissionActions.Edit);
            this.mnu_CurrencyType.Enabled = cur.Permit(Permission.CurrencyType, PermissionActions.Read) || cur.Permit(Permission.CurrencyType, PermissionActions.Edit);
            this.mnu_Staff.Enabled = cur.Permit(Permission.Staff, PermissionActions.Read) || cur.Permit(Permission.Staff, PermissionActions.Edit);
            this.mnu_Role.Enabled = cur.Permit(Permission.Role, PermissionActions.Read) || cur.Permit(Permission.Role, PermissionActions.Edit);
            this.mnu_Options.Enabled = cur.Permit(Permission.SystemOptions, PermissionActions.Read) || cur.Permit(Permission.SystemOptions, PermissionActions.Edit);
            //销售
            this.mnu_Order.Enabled = cur.Permit(Permission.Order, PermissionActions.Read) || cur.Permit(Permission.Order, PermissionActions.Edit);
            this.mnu_OrderMonitor.Enabled = cur.Permit(Permission.Order, PermissionActions.Read) || cur.Permit(Permission.Order, PermissionActions.Edit);
            //采购
            this.mnu_Supplier.Enabled = cur.Permit(Permission.Supplier, PermissionActions.Read) || cur.Permit(Permission.Supplier, PermissionActions.Edit);
            this.mnu_PurchaseOrder.Enabled = cur.Permit(Permission.PurchaseOrder, PermissionActions.Read) || cur.Permit(Permission.PurchaseOrder, PermissionActions.Edit);
            this.mnu_PurchaseMonitor.Enabled = cur.Permit(Permission.PurchaseOrder, PermissionActions.Read) || cur.Permit(Permission.PurchaseOrder, PermissionActions.Edit);
            //仓库
            this.mnu_SteelRoll.Enabled = cur.Permit(Permission.SteelRoll, PermissionActions.Read) || cur.Permit(Permission.SteelRoll, PermissionActions.Edit);
            this.mnu_DeliverySheet.Enabled = cur.Permit(Permission.DeliverySheet, PermissionActions.Read) || cur.Permit(Permission.DeliverySheet, PermissionActions.Edit);
            this.mnu_Customer.Enabled = cur.Permit(Permission.Customer, PermissionActions.Read) || cur.Permit(Permission.Customer, PermissionActions.Edit);
            this.mnu_WareHouse.Enabled = cur.Permit(Permission.WareHouse, PermissionActions.Read) || cur.Permit(Permission.WareHouse, PermissionActions.Edit);
            //财务
            this.mnu_CustomerState.Enabled = cur.Permit(Permission.CustomerState, PermissionActions.Read);
            this.mnu_CustomerPayment.Enabled = cur.Permit(Permission.CustomerPayment, PermissionActions.Read) || cur.Permit(Permission.CustomerPayment, PermissionActions.Edit);
            this.mnu_Expanditure.Enabled = cur.Permit(Permission.ExpenditureRecord, PermissionActions.Read) || cur.Permit(Permission.ExpenditureRecord, PermissionActions.Edit);
            this.mnu_SupplierState.Enabled = cur.Permit(Permission.SupplierState, PermissionActions.Read);
            this.mnu_SupplierPayment.Enabled = cur.Permit(Permission.SupplierPayment, PermissionActions.Read) || cur.Permit(Permission.SupplierPayment, PermissionActions.Edit);
            //报表
            this.mnu_DeliveryRecordReport.Enabled = cur.Permit(Permission.DeliveryRecordReport, PermissionActions.Read);
            this.mnu_DeliveryStatistic.Enabled = cur.Permit(Permission.DeliveryStatistics, PermissionActions.Read);
        }
        #endregion

        #region 公共方法
        private void AddForm(Form frm, bool mainPanel, bool showHeader = true)
        {
            if (!mainPanel && this.ucFormViewSecondary.Visible)
            {
                this.ucFormViewSecondary.AddAForm(frm, showHeader);
            }
            else
            {
                this.ucFormViewMain.AddAForm(frm, showHeader);
            }
        }
        /// <summary>
        /// 显示窗口的单个实例，如果之前已经打开过，则只是激活打开过的窗体
        /// </summary>
        /// <param name="formType">要打开的窗体类型</param>
        /// <param name="mainPanel">是否在主面板中打开,否则在从面板中打开</param>
        public T ShowSingleForm<T>(bool mainPanel = true, bool showHeader = true) where T : Form
        {
            T instance = null;
            foreach (Form frm in _openedForms)
            {
                if (frm.GetType() == typeof(T))
                {
                    ucFormViewMain.ActiveForm(frm);
                    instance = frm as T;
                    break;
                }
            }
            if (instance == null)
            {
                instance = Activator.CreateInstance(typeof(T)) as T;
                instance.Tag = this;
                instance.TopLevel = false;
                _openedForms.Add(instance);
                AddForm(instance, mainPanel, showHeader);
                instance.FormClosed += delegate(object sender, FormClosedEventArgs e)
                {
                    _openedForms.Remove(instance);
                };
            }
            return instance;
        }
        #endregion

        #region 菜单事件程序
        private void mnu_LogOut_Click(object sender, EventArgs e)
        {
            DoLogIn();
        }

        private void mnu_Product_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmProductMaster>();
        }

        private void mnu_DeliverySheet_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmStackOutSheetMaster>();
        }

        private void mnu_ProductCategory_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmProductCategoryMaster>();
        }

        private void mnu_Customer_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmCustomerMaster>();
        }

        private void mnu_WareHouse_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmWareHouseMaster>();
        }

        private void mnu_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnu_Operator_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmOperatorMaster>();
        }

        private void mnu_Role_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmRoleMaster>();
        }

        private void mnu_ChangePwd_Click(object sender, EventArgs e)
        {
            FrmChangePwd frm = new FrmChangePwd();
            frm.Operator = LJH.Inventory.BusinessModel.Operator.Current;
            frm.ShowDialog();
        }

        private void mnu_Aboat_Click(object sender, EventArgs e)
        {
            Form frm = new FrmAboat();
            frm.ShowDialog();
        }

        private void mnu_Options_Click(object sender, EventArgs e)
        {
            FrmSystemOptions frm = new FrmSystemOptions();
            frm.ShowDialog();
        }

        private void mnu_Inventory_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmSteelRollSliceMaster>();
        }

        private void mnu_InventorySheet_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmStackInSheetMaster>();
        }

        private void mnu_CustomerPayment_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmCustomerPaymentMaster>();
        }

        private void mnu_Expanditure_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmExpenditureRecordMaster>();
        }

        private void mnu_DogInfo_Click(object sender, EventArgs e)
        {
            FrmSoftDogInfo frm = new FrmSoftDogInfo();
            frm.SoftDog = _SoftDog;
            frm.ShowDialog();
        }

        private void mnu_DeliveryRecordReport_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmDeliveryRecordReport>();
        }

        private void mnu_DeliveryStatistic_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmDeliveryStatistics>();
        }

        private void mnu_Performance_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmSalesPersonPerformanceReport>();
        }

        private void mnu_CollectionType_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmCollectionTypeMaster>();
        }

        private void mnu_CurrencyType_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmCurrencyTypeMaster>();
        }

        private void mnu_Unit_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmUnitMaster>();
        }

        private void mnu_Transport_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmTransportMaster>();
        }

        private void mnu_Supplier_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmSupplierMaster>();
        }

        private void mnu_BackupData_Click(object sender, EventArgs e)
        {
            FrmBackUp frm = new FrmBackUp();
            frm.ShowDialog();
        }

        private void mnu_PurchaseOrder_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmPurchaseOrderMaster>();
        }

        private void mnu_CustomerType_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmCustomerTypeMaster>();
        }

        private void mnu_SupplierType_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmSupplierTypeMaster>();
        }

        private void mnu_Order_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmOrderMaster>();
        }

        private void mnu_ExpanditureType_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmExpenditureTypeMaster>();
        }

        private void mnu_OrderPaymentReport_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmOrderPaymentReport>();
        }

        private void mnu_Manual_Click(object sender, EventArgs e)
        {

        }

        private void mnu_RelatedCompanyType_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmRelatedCompanyTypeMaster>();
        }

        private void mnu_RelatedCompany_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmRelatedCompanyMaster>();
        }

        private void mnu_WareHouse_Click_1(object sender, EventArgs e)
        {
            ShowSingleForm<FrmWareHouseMaster>();
        }

        private void mnu_CustomerReceivable_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmCustomerFinancialStateMaster>();
        }

        private void mnu_OrderMonitor_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmOrderItemRecordMaster>();
        }

        private void mnu_PurchaseMonitor_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmPurchaseItemRecordMaster>();
        }

        private void mnu_HorizontalSplit_Click(object sender, EventArgs e)
        {
            this.pSecondary.Visible = !this.pSecondary.Visible;
            this.splitter1.Visible = !this.splitter1.Visible;
            mnu_HorizontalSplit.Text = this.pSecondary.Visible ? "取消水平拆分" : "水平拆分";
            this.mnu_VerticalSplit.Enabled = !this.pSecondary.Visible;
            if (this.pSecondary.Visible)
            {
                this.pSecondary.Width = this.panel1.Width / 2;
                this.pSecondary.Dock = DockStyle.Right;
                this.splitter1.Dock = DockStyle.Right;
            }
            else
            {

            }
        }

        private void mnu_VerticalSplit_Click(object sender, EventArgs e)
        {
            this.pSecondary.Visible = !this.pSecondary.Visible;
            this.splitter1.Visible = !this.splitter1.Visible;
            this.mnu_VerticalSplit.Text = this.pSecondary.Visible ? "取消垂直拆分" : "垂直拆分";
            this.mnu_HorizontalSplit.Enabled = !this.pSecondary.Visible;
            if (this.pSecondary.Visible)
            {
                this.pSecondary.Dock = DockStyle.Bottom;
                this.splitter1.Dock = DockStyle.Bottom;
                this.pSecondary.Height = this.panel1.Height / 2;
            }
            else
            {

            }
        }

        private void mnu_Staff_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmStaffMaster>();
        }

        private void mnu_SupplierState_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmSupplierFinancialStateMaster>();
        }

        private void mnu_SupplierPayment_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmSupplierPaymentMaster>();
        }

        private void mnu_InventoryRecord_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmInventoryRecordReport>();
        }
        #endregion

        #region 事件处理程序
        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (DateTime.Today > _ExpireDate)
            {
                MessageBox.Show("软件已经过期,请联系供应商");
                Environment.Exit(0);
            }
            this.Text += string.Format(" [{0}]", Application.ProductVersion);
            DoLogIn();
            UserSettings.Current = SysParaSettingsBll.GetOrCreateSetting<UserSettings>(AppSettings.Current.ConnStr);
            lblDBPath.Text = AppSettings.Current.GetConfigContent("DBPath");
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion

        private void mnu_Proxy_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmProxyMaster>();
        }

        private void mnu_Material_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmSteelRollMaster>();
        }

        private void mnu_SliceRecordReport_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmSliceRecordReport>();
        }

        private void 客户付款流水报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSingleForm<LJH.Inventory.UI.Forms.Financial.Report.FrmCustomerPaymentReport>();
        }
    }
}