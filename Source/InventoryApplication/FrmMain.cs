using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
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

namespace InventoryApplication
{
    public partial class FrmMain : Form, LJH.GeneralLibrary.Core.UI.IOperatorRender
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region 私有变量
        private Dictionary<Form, string> _openedForms = new Dictionary<Form, string>();
        private SoftDogInfo _SoftDog;
        private bool _EnableSoftDog = true; //启用加密狗
        private DateTime _ExpireDate = new DateTime(2016, 1, 31);
        #endregion

        #region 私有方法
        private void ReadDog()
        {
            string lic = Path.Combine(Application.StartupPath, "ljh.lic");
            string skey = AppSettings.Current.GetConfigContent("SKey");
            if (string.IsNullOrEmpty(skey))
            {
                skey = @"#i~xnUc4RH1G@\)$&7z6qv9xy@~<mTR5nUR?OU}jh`4r<qN>:*xZwz~E$0";
                AppSettings.Current.SaveConfig("SKey", skey);
            }
            try
            {
                SoftDogReader reader = new SoftDogReader(skey);
                _SoftDog = reader.ReadDog();
            }
            catch
            {
            }
            try
            {
                if (_SoftDog == null && File.Exists(lic))
                {
                    _SoftDog = LICReader.ReadDog(lic);
                }
            }
            catch
            {

            }
        }

        private void CheckDog()
        {
            ReadDog();
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

        private void CheckHostDog()
        {
            if (_SoftDog == null) return;
            if (_SoftDog.IsHost) return;
            try
            {
                var p = new SysparameterInfoBLL(AppSettings.Current.ConnStr).GetByID("__dog").QueryObject; ;
                if (p == null)
                {
                    MessageBox.Show("没有检测到主机加密狗，软件即将退出");
                    Environment.Exit(0);
                }
                else
                {
                    DateTime hostLastDate = DateTime.MinValue;
                    string memo = new DTEncrypt().DSEncrypt(p.Memo);
                    if (DateTime.TryParse(p.Value, out hostLastDate) && !string.IsNullOrEmpty(memo))
                    {
                        string[] temp = memo.Split(';');
                        if (temp[0] != _SoftDog.ProjectNo.ToString())
                        {
                            MessageBox.Show("加密狗不是本客户的加密狗，软件即将退出");
                            Environment.Exit(0);
                        }
                        DateTime dt2 = DateTime.MinValue;
                        if (!DateTime.TryParse(temp[1], out dt2) || dt2 != hostLastDate)
                        {
                            MessageBox.Show("没有检测到主机加密狗，软件即将退出");
                            Environment.Exit(0);
                        }
                        DateTime now = DateTime.Now;
                        if (hostLastDate.AddDays(10) < now)//超过7天就退出软件
                        {
                            MessageBox.Show("主机加密狗处于长时间离线状态，系统即将退出，你可以用主机加密狗登录或者联系供应商");
                            Environment.Exit(0);
                        }
                        else if (hostLastDate.AddDays(1) < now) //主机狗超过3天没有登录
                        {
                            tmrSoftDogChecker.Enabled = false;
                            MessageBox.Show("主机加密狗处于长时间离线状态，为了避免软件被锁定，请及时让主机加密狗处于在线状态", "软件过期", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tmrSoftDogChecker.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("没有检测到主机加密狗，软件即将退出");
                        Environment.Exit(0);
                    }
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

            DialogResult ret = DialogResult.Cancel;
            if (!_EnableSoftDog)
            {
                ret = (new FrmLogin()).ShowDialog();
            }
            else
            {
                FrmLoginDog frm = new FrmLoginDog();
                frm.SoftDog = _SoftDog;
                frm.StartPosition = FormStartPosition.CenterParent;
                ret = frm.ShowDialog();
            }
            if (ret == DialogResult.OK)
            {
                ShowOperatorRights();
                if (_openedForms != null && _openedForms.Count > 0)
                {
                    foreach (Form frm in _openedForms.Keys)
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
            this.mnu_SteelRollSlice.Enabled = cur.Permit(Permission.SteelRollSlice, PermissionActions.Read) || cur.Permit(Permission.SteelRollSlice, PermissionActions.Edit);
            this.mnu_InventorySheet.Enabled = cur.Permit(Permission.InventorySheet, PermissionActions.Read) || cur.Permit(Permission.InventorySheet, PermissionActions.Edit);
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
            this.mnu_DeliveryStatistic.Enabled = cur.Permit(Permission.DeliveryRecordReport, PermissionActions.Read);
            this.mnu_CustomerPaymentReport.Enabled = cur.Permit(Permission.CustomerPayment, PermissionActions.Read) || cur.Permit(Permission.CustomerPayment, PermissionActions.Edit);
            this.mnu_InventoryRecord.Enabled = true;
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
        public T ShowSingleForm<T>(object menu, bool mainPanel = true) where T : Form
        {
            string cmd = null;
            if (menu is ToolStripMenuItem) cmd = (menu as ToolStripMenuItem).Name;

            T instance = null;
            foreach (Form frm in _openedForms.Keys)
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
                _openedForms.Add(instance, cmd);
                AddForm(instance, mainPanel, true);
                instance.FormClosed += delegate(object sender, FormClosedEventArgs e)
                {
                    _openedForms.Remove(instance);
                };
            }
            return instance;
        }

        private void SaveOpenedForms()
        {
            string temp = string.Empty;
            foreach (var pair in _openedForms)
            {
                if (!string.IsNullOrEmpty(pair.Value))
                {
                    temp += pair.Value + ";";
                }
            }
            if (!string.IsNullOrEmpty(temp)) AppSettings.Current.SaveConfig("OpenedForms", temp);
        }

        private void OpenLastForms()
        {
            string temp = AppSettings.Current.GetConfigContent("OpenedForms");
            if (!string.IsNullOrEmpty(temp))
            {
                string[] ms = temp.Split(';');
                foreach (var str in ms)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        var c = this.menuStrip1.Items.Find(str, true);
                        if (c != null && c.Length == 1 && c[0].Enabled) c[0].PerformClick();
                    }
                }
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
            ShowSingleForm<FrmProductMaster>(sender);
        }

        private void mnu_DeliverySheet_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmStackOutSheetMaster>(sender);
        }

        private void mnu_ProductCategory_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmProductCategoryMaster>(sender);
        }

        private void mnu_Customer_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmCustomerMaster>(sender);
        }

        private void mnu_WareHouse_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmWareHouseMaster>(sender);
        }

        private void mnu_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnu_Operator_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmOperatorMaster>(sender);
        }

        private void mnu_Role_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmRoleMaster>(sender);
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
            ShowSingleForm<FrmSteelRollSliceMaster>(sender);
        }

        private void mnu_InventorySheet_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmStackInSheetMaster>(sender);
        }

        private void mnu_CustomerPayment_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmCustomerPaymentMaster>(sender);
        }

        private void mnu_Expanditure_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmExpenditureRecordMaster>(sender);
        }

        private void mnu_DogInfo_Click(object sender, EventArgs e)
        {
            FrmSoftDogInfo frm = new FrmSoftDogInfo();
            frm.SoftDog = _SoftDog;
            frm.ShowDialog();
        }

        private void mnu_DeliveryRecordReport_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmDeliveryRecordReport>(sender);
        }

        private void mnu_DeliveryStatistic_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmDeliveryStatistics>(sender);
        }

        private void mnu_Performance_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmSalesPersonPerformanceReport>(sender);
        }

        private void mnu_CollectionType_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmCollectionTypeMaster>(sender);
        }

        private void mnu_CurrencyType_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmCurrencyTypeMaster>(sender);
        }

        private void mnu_Unit_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmUnitMaster>(sender);
        }

        private void mnu_Transport_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmTransportMaster>(sender);
        }

        private void mnu_Supplier_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmSupplierMaster>(sender);
        }

        private void mnu_BackupData_Click(object sender, EventArgs e)
        {
            FrmBackUp frm = new FrmBackUp();
            frm.ShowDialog();
        }

        private void mnu_ExpanditureType_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmExpenditureTypeMaster>(sender);
        }

        private void mnu_OrderPaymentReport_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmOrderPaymentReport>(sender);
        }

        private void mnu_RelatedCompanyType_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmRelatedCompanyTypeMaster>(sender);
        }

        private void mnu_RelatedCompany_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmRelatedCompanyMaster>(sender);
        }

        private void mnu_WareHouse_Click_1(object sender, EventArgs e)
        {
            ShowSingleForm<FrmWareHouseMaster>(sender);
        }

        private void mnu_CustomerReceivable_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmCustomerFinancialStateMaster>(sender);
        }

        private void mnu_OrderMonitor_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmOrderItemRecordMaster>(sender);
        }

        private void mnu_PurchaseMonitor_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmPurchaseItemRecordMaster>(sender);
        }

        private void mnu_CustomerPaymentReport_Click(object sender, EventArgs e)
        {
            ShowSingleForm<LJH.Inventory.UI.Forms.Financial.Report.FrmCustomerPaymentReport>(sender);
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
            ShowSingleForm<FrmStaffMaster>(sender);
        }

        private void mnu_SupplierState_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmSupplierFinancialStateMaster>(sender);
        }

        private void mnu_SupplierPayment_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmSupplierPaymentMaster>(sender);
        }

        private void mnu_InventoryRecord_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmInventoryRecordReport>(sender);
        }

        private void mnu_Proxy_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmProxyMaster>(sender);
        }

        private void mnu_Material_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmSteelRollMaster>(sender);
        }

        private void mnu_SliceRecordReport_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmSliceRecordReport>(sender);
        }
        #endregion

        #region 事件处理程序
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text += string.Format(" [{0}]", Application.ProductVersion);
            if (!_EnableSoftDog)
            {
                if (DateTime.Today > _ExpireDate)
                {
                    MessageBox.Show("软件已经过期,请联系供应商");
                    Environment.Exit(0);
                }
            }
            else
            {
                CheckDog();
            }

            DoLogIn();
            CheckHostDog();
            UserSettings.Current = SysParaSettingsBll.GetOrCreateSetting<UserSettings>(AppSettings.Current.ConnStr);
            this.tmrSoftDogChecker.Enabled = _EnableSoftDog;

            OpenLastForms();
        }

        private void tmrSoftDogChecker_Tick(object sender, EventArgs e)
        {
            CheckDog();
            if (_SoftDog != null)
            {
                if (_SoftDog.IsHost)
                {
                    var p = new SysparameterInfo()
                    {
                        ID = "__dog",
                        Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Memo = new DTEncrypt().Encrypt(string.Format("{0};{1}", _SoftDog.ProjectNo, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))),
                    };
                    new SysparameterInfoBLL(AppSettings.Current.ConnStr).Save(p);
                    tmrSoftDogChecker.Interval = 60000;
                }
                else
                {
                    CheckHostDog();
                }
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveOpenedForms();
            Environment.Exit(0);
        }
        #endregion

        private void 其它费用管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductMaster frm = new FrmProductMaster();
            LJH.Inventory.BusinessModel.SearchCondition.ProductSearchCondition con = new LJH.Inventory.BusinessModel.SearchCondition.ProductSearchCondition();
            con.IsService = true;
            frm.SearchCondition = con;
            frm.ShowDialog();
        }

        private void 客户增值税发票报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSingleForm<LJH.Inventory.UI.Forms.Financial.Report.FrmCustomerTaxBillReport>(sender);
        }
    }
}