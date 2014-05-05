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

namespace InventoryDemo
{
    public partial class FrmMain : Form, LJH.GeneralLibrary .Core.UI .IOperatorRender
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<Form> _openedForms = new List<Form>();
        private SoftDogInfo _SoftDog;
        #endregion

        #region 私有方法
        private void ReadSoftDog()
        {
            SoftDogReader reader = new SoftDogReader();
            try
            {
                _SoftDog = reader.ReadDog();
                if (_SoftDog == null)
                {
                    MessageBox.Show("加密狗访问错误：没有找到加密狗。如果加密狗已经插上，则可能是加密狗还没有加密，请先联系厂家进行加密!", "注意");
                    System.Environment.Exit(0);
                }
                else if ((_SoftDog.SoftwareList & SoftwareType.TYPE_Inventory) == 0)  //没有写停车场权限
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
                this.Close();
            }
        }

        public void ShowOperatorRights()
        {
            Operator cur = Operator.Current;
            //基本资料
            this.mnu_Product.Enabled = cur.Permit(Permission.Product, PermissionActions.Read) || cur.Permit(Permission.Product, PermissionActions.Edit);
            this.mnu_WareHouse.Enabled = cur.Permit(Permission.WareHouse, PermissionActions.Read) || cur.Permit(Permission.WareHouse, PermissionActions.Edit);
            this.mnu_Unit.Enabled = cur.Permit(Permission.Unit, PermissionActions.Read) || cur.Permit(Permission.Unit, PermissionActions.Edit);
            this.mnu_CurrencyType.Enabled = cur.Permit(Permission.CurrencyType, PermissionActions.Read) || cur.Permit(Permission.CurrencyType, PermissionActions.Edit);
            this.mnu_Transport.Enabled = cur.Permit(Permission.Transport, PermissionActions.Read) || cur.Permit(Permission.Transport, PermissionActions.Edit);
            this.mnu_Staff.Enabled = cur.Permit(Permission.Staff, PermissionActions.Read) || cur.Permit(Permission.Staff, PermissionActions.Edit);
            this.mnu_Role.Enabled = cur.Permit(Permission.Role, PermissionActions.Read) || cur.Permit(Permission.Role, PermissionActions.Edit);
            this.mnu_Options.Enabled = cur.Permit(Permission.SystemOptions, PermissionActions.Read) || cur.Permit(Permission.SystemOptions, PermissionActions.Edit);
            //销售
            this.mnu_Customer.Enabled = cur.Permit(Permission.Customer, PermissionActions.Read) || cur.Permit(Permission.Customer, PermissionActions.Edit);
            this.mnu_Order.Enabled = cur.Permit(Permission.Order, PermissionActions.Read) || cur.Permit(Permission.Order, PermissionActions.Edit);
            this.mnu_OrderMonitor.Enabled = cur.Permit(Permission.Order, PermissionActions.Read) || cur.Permit(Permission.Order, PermissionActions.Edit);
            //采购
            this.mnu_Supplier.Enabled = cur.Permit(Permission.Supplier, PermissionActions.Read) || cur.Permit(Permission.Supplier, PermissionActions.Edit);
            this.mnu_PurchaseOrder.Enabled = cur.Permit(Permission.PurchaseOrder, PermissionActions.Read) || cur.Permit(Permission.PurchaseOrder, PermissionActions.Edit);
            this.mnu_PurchaseMonitor.Enabled = cur.Permit(Permission.PurchaseOrder, PermissionActions.Read) || cur.Permit(Permission.PurchaseOrder, PermissionActions.Edit);
            //仓库
            this.mnu_Inventory.Enabled = cur.Permit(Permission.ProductInventory, PermissionActions.Read) || cur.Permit(Permission.ProductInventory, PermissionActions.Edit);
            this.mnu_InventorySheet.Enabled = cur.Permit(Permission.InventorySheet, PermissionActions.Read) || cur.Permit(Permission.InventorySheet, PermissionActions.Edit);
            this.mnu_DeliverySheet.Enabled = cur.Permit(Permission.DeliverySheet, PermissionActions.Read) || cur.Permit(Permission.DeliverySheet, PermissionActions.Edit);
            //财务
            this.mnu_CustomerState .Enabled =cur.Permit (Permission.CustomerState ,PermissionActions.Read )|| cur.Permit (Permission.CustomerState ,PermissionActions.Edit );
            this.mnu_CustomerOtherReceivable.Enabled = cur.Permit(Permission.CustomerOtherReceivable, PermissionActions.Read) || cur.Permit(Permission.CustomerOtherReceivable, PermissionActions.Edit);
            this.mnu_CustomerPayment.Enabled = cur.Permit(Permission.CustomerPayment, PermissionActions.Read) || cur.Permit(Permission.CustomerPayment, PermissionActions.Edit);
            this.mnu_Expanditure.Enabled = cur.Permit(Permission.ExpenditureRecord, PermissionActions.Read) || cur.Permit(Permission.ExpenditureRecord, PermissionActions.Edit);
            
            //报表
            this.mnu_DeliveryRecordReport.Enabled = cur.Permit(Permission.DeliveryRecordReport, PermissionActions.Read);
        }
        #endregion

        #region 公共方法
        private void AddForm(Form frm, bool mainPanel)
        {
            if (!mainPanel && this.ucFormViewSecondary.Visible)
            {
                this.ucFormViewSecondary.AddAForm(frm);
            }
            else
            {
                this.ucFormViewMain.AddAForm(frm);
            }
        }
        /// <summary>
        /// 显示窗口的单个实例，如果之前已经打开过，则只是激活打开过的窗体
        /// </summary>
        /// <param name="formType">要打开的窗体类型</param>
        /// <param name="mainPanel">是否在主面板中打开,否则在从面板中打开</param>
        public T ShowSingleForm<T>(bool mainPanel = true) where T : Form
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
                AddForm(instance, mainPanel);
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
            ShowSingleForm<FrmDeliverySheetMaster>();
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
            ShowSingleForm<FrmProductInventoryMaster>();
        }

        private void mnu_InventorySheet_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmInventorySheetMaster>();
        }

        private void mnu_CustomerPayment_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmCustomerPaymentMaster>();
        }

        private void mnu_Expanditure_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmExpenditureRecordMaster>();
        }

        private void mnu_DaiFu_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmCustomerOtherReceivableMaster>();
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

        private void mnu_PriceTerm_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmPriceTermMaster>();
        }

        private void mnu_Unit_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmUnitMaster>();
        }

        private void mnu_NativePort_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmNativePortMaster>();
        }

        private void mnu_ForeignPort_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmForeignPortMaster>();
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

        private void mnu_CustomerOtherReceivable_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmCustomerOtherReceivableMaster>();
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
        #endregion

        #region 事件处理程序
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //ReadSoftDog();
            DoLogIn();
            UserSettings.Current = SysParaSettingsBll.GetOrCreateSetting<UserSettings>(AppSettings.Current.ConnStr);
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        #endregion

    }
}