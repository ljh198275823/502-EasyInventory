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
using LJH.GeneralLibrary.SoftDog;
using LJH.Inventory.UI.Forms;
using LJH.GeneralLibrary.SQLHelper;

namespace InventoryApplication
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<Form> _openedForms = new List<Form>();
        private DatetimeSyncService _DatetimeSyncService;
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
                this.lblOperator.Text = OperatorInfo.CurrentOperator.OperatorName;
            }
            else
            {
                this.Close();
            }
        }

        private void ShowOperatorRights()
        {
            OperatorInfo cur = OperatorInfo.CurrentOperator;
            this.mnu_Product.Enabled = cur.Permit(Permission.ReadProduct) || cur.Permit(Permission.EditProduct);
            this.mnu_WareHouse.Enabled = cur.Permit(Permission.EditWareHouse) || cur.Permit(Permission.ReadWareHouse);
            this.mnu_Customer.Enabled = cur.Permit(Permission.ReadCustomer) || cur.Permit(Permission.EditCustomer);
            this.mnu_DeliverySheet.Enabled = cur.Permit(Permission.ReadDeliverySheet) || cur.Permit(Permission.EditDeliverySheet);
            this.mnu_Options.Enabled = cur.Permit(Permission.ReadSystemOptions) || cur.Permit(Permission.EditSystemOptions);
            this.mnu_CustomerPayment.Enabled = cur.Permit(Permission.ReadCustomerPayment) || cur.Permit(Permission.EditCustomerPayment);
            // this.mnu_DaiFu.Enabled = cur.Permit(Permission.ReadDaiFuRecord) || cur.Permit(Permission.EditCustomerDaiFu);
            this.mnu_Expanditure.Enabled = cur.Permit(Permission.ReadExpenditureRecord) || cur.Permit(Permission.EditExpenditureRecord);

            this.mnu_Operator.Enabled = cur.Permit(Permission.ReadOperaotor) || cur.Permit(Permission.EditOperator);
            this.mnu_Role.Enabled = cur.Permit(Permission.ReadRole) || cur.Permit(Permission.EditRole);

            this.mnu_DeliveryRecordReport.Enabled = cur.Permit(Permission.DeliveryRecordReport);
            this.mnu_InventoryRecord.Enabled = cur.Permit(Permission._InventoryRecordReport);
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 显示窗口的单个实例，如果之前已经打开过，则只是激活打开过的窗体
        /// </summary>
        /// <param name="formType">要打开的窗体类型</param>
        /// <param name="mainPanel">是否在主面板中打开,否则在从面板中打开</param>
        public void ShowSingleForm(Type formType, bool mainPanel)
        {
            Form instance = null;
            foreach (Form frm in _openedForms)
            {
                if (frm.GetType() == formType)
                {
                    instance = frm;
                    ucFormViewMain.ActiveForm(frm);
                    ucFormViewSecondary.ActiveForm(frm);
                    break;
                }
            }
            if (instance == null)
            {
                instance = (Form)Activator.CreateInstance(formType);
                instance.Tag = this;
                instance.TopLevel = false;
                _openedForms.Add(instance);
                AddForm(instance, mainPanel);
                instance.FormClosed += delegate(object sender, FormClosedEventArgs e)
                {
                    _openedForms.Remove(instance);
                };
            }
        }

        /// <summary>
        /// 显示窗口的单个实例，如果之前已经打开过，则只是激活打开过的窗体
        /// </summary>
        /// <param name="formType"></param>
        /// <param name="mainPanel"></param>
        public void ShowSingleForm(Type formType)
        {
            ShowSingleForm(formType, true);
        }

        public void AddForm(Form frm, bool mainPanel)
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

        #endregion

        #region 菜单事件程序
        private void mnu_LogOut_Click(object sender, EventArgs e)
        {
            DoLogIn();
        }

        private void mnu_Product_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmProductMaster));
        }

        private void mnu_DeliverySheet_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmDeliverySheetMaster));
        }

        private void mnu_ProductCategory_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmProductCategoryMaster));
        }

        private void mnu_Customer_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmCustomerMaster));
        }

        private void mnu_WareHouse_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmWareHouseMaster));
        }

        private void mnu_Supplier_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmSupplierMaster));
        }

        private void mnu_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnu_Operator_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmOperatorMaster));
        }

        private void mnu_Role_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmRoles));
        }

        private void mnu_ChangePwd_Click(object sender, EventArgs e)
        {
            FrmChangePwd frm = new FrmChangePwd();
            frm.Operator = LJH.Inventory.BusinessModel.OperatorInfo.CurrentOperator;
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
            ShowSingleForm(typeof(FrmProductInventoryMaster));
        }

        private void mnu_InventorySheet_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmInventorySheetMaster));
        }

        private void mnu_CustomerPayment_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmCustomerPaymentMaster));
        }

        private void mnu_Expanditure_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmExpenditureRecordMaster));
        }

        private void mnu_DaiFu_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmCustomerOtherReceivableMaster));
        }

        private void mnu_DogInfo_Click(object sender, EventArgs e)
        {
            FrmSoftDogInfo frm = new FrmSoftDogInfo();
            frm.SoftDog = _SoftDog;
            frm.ShowDialog();
        }

        private void mnu_DeliveryRecordReport_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmDeliveryRecordReport));
        }
        #endregion

        #region 事件处理程序
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //ReadSoftDog();
            DoLogIn();
            UserSettings.Current = SysParaSettingsBll.GetOrCreateSetting<UserSettings>(AppSettings.CurrentSetting.ConnectString);
            //启动同步时间服务
            _DatetimeSyncService = new DatetimeSyncService(AppSettings.CurrentSetting.ConnectString);
            _DatetimeSyncService.Start();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_DatetimeSyncService != null) _DatetimeSyncService.Stop();
        }
        #endregion

        private void mnu_DeliveryStatistic_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmDeliveryStatistics));
        }

        private void mnu_Performance_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmSalesPersonPerformanceReport));
        }

        private void mnu_CollectionType_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmCollectionTypeMaster));
        }

        private void mnu_CurrencyType_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmCurrencyTypeMaster));
        }

        private void mnu_PriceTerm_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmPriceTermMaster));
        }

        private void mnu_Unit_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmUnitMaster));
        }

        private void mnu_NativePort_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmNativePortMaster));
        }

        private void mnu_ForeignPort_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmForeignPortMaster));
        }

        private void mnu_Transport_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmTransportMaster));
        }

        private void mnu_Supplier_Click_1(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmSupplierMaster));
        }

        private void mnu_BackupData_Click(object sender, EventArgs e)
        {
            FrmBackUp frm = new FrmBackUp();
            frm.ShowDialog();
        }

        private void mnu_PurchaseOrder_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmPurchaseOrderMaster));
        }

        private void mnu_CustomerType_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmCustomerTypeMaster));
        }

        private void mnu_SupplierType_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmSupplierTypeMaster));
        }

        private void mnu_UpdateDB_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要升级数据库?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string path = System.IO.Path.Combine(Application.StartupPath, "DbUpdate.sql");
                if (System.IO.File.Exists(path))
                {
                    try
                    {
                        SqlClient client = new SqlClient(AppSettings.CurrentSetting.ConnectString);
                        client.Connect();
                        client.ExecuteSQLFile(path);
                        MessageBox.Show("数据库升级成功!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                    }
                }
            }
        }

        private void mnu_Order_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmOrderMaster));
        }

        private void mnu_ExpanditureType_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmExpenditureTypeMaster));
        }

        private void mnu_CustomerOtherReceivable_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmCustomerOtherReceivableMaster));
        }

        private void mnu_OrderPaymentReport_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmOrderPaymentReport));
        }

        private void mnu_Manual_Click(object sender, EventArgs e)
        {

        }

        private void mnu_RelatedCompanyType_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmRelatedCompanyTypeMaster));
        }

        private void mnu_RelatedCompany_Click(object sender, EventArgs e)
        {
            ShowSingleForm(typeof(FrmRelatedCompanyMaster));
        }
    }
}