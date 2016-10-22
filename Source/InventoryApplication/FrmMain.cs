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
        private DateTime _dtHostDogTime = new DateTime(2016, 1, 31);
        private int _RetryTime =0;
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
                FrmContactUs frm = new FrmContactUs();
                frm.txtMessage.Text = "没有找到加密狗";
                frm.ShowDialog();
                System.Environment.Exit(0);
            }
            else if ((_SoftDog.SoftwareList & SoftwareType.TYPE_Inventory) == 0)  //没有开放进销存软件权限
            {
                FrmContactUs frm = new FrmContactUs();
                frm.txtMessage.Text = "加密狗权限不足";
                frm.ShowDialog();
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
                 FrmContactUs frm = new FrmContactUs();
                frm.txtMessage.Text = "软件已经过期";
                frm.ShowDialog();
                System.Environment.Exit(0);
            }
            else if (!string.IsNullOrEmpty(_SoftDog.MAC))
            {
                string[] auMac = _SoftDog.MAC.Split(',', '，');
                string local = LJH.GeneralLibrary.Net.NetTool.GetLocalMAC();
                if (string.IsNullOrEmpty(local))
                {
                    MessageBox.Show("软件不允许在此电脑上使用!", "注意");
                    System.Environment.Exit(0);
                }
                var locMac = local.Split(',', '，');
                if (locMac.Any(it => !string.IsNullOrEmpty(it) && auMac.Any(f => !string.IsNullOrEmpty(f) && it.Replace("-", string.Empty).ToUpper() == f.Replace("-", string.Empty).ToUpper())))
                {
                }
                else
                {
                    MessageBox.Show("软件不允许在此电脑上使用!", "注意");
                    System.Environment.Exit(0);
                }
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
                    _RetryTime++;
                    if (_RetryTime >= 6) //由于有时会获取失败，所以可以重试几次，
                    {
                        FrmContactUs frm = new FrmContactUs();
                        frm.txtMessage.Text = "没有检测到主机加密狗";
                        frm.ShowDialog();
                        Environment.Exit(0);
                    }
                }
                else
                {
                    _RetryTime = 0;
                    DateTime hostLastDate = DateTime.MinValue;
                    string memo = new DTEncrypt().DSEncrypt(p.Memo);
                    if (DateTime.TryParse(p.Value, out hostLastDate) && !string.IsNullOrEmpty(memo))
                    {
                        string[] temp = memo.Split(';');
                        if (temp[0] != _SoftDog.ProjectNo.ToString())
                        {
                            FrmContactUs frm = new FrmContactUs();
                            frm.txtMessage.Text = "错误的项目编号";
                            frm.ShowDialog();
                            Environment.Exit(0);
                        }
                        DateTime dt2 = DateTime.MinValue;
                        if (!DateTime.TryParse(temp[1], out dt2) || dt2 != hostLastDate)
                        {
                            FrmContactUs frm = new FrmContactUs();
                            frm.txtMessage.Text = "没有检测到主机加密狗";
                            frm.ShowDialog();
                            Environment.Exit(0);
                        }
                        DateTime now = DateTime.Now;
                        if (hostLastDate.AddDays(10) < now)//超过7天就退出软件
                        {
                            FrmContactUs frm = new FrmContactUs();
                            frm.txtMessage.Text = "没有检测到主机加密狗";
                            frm.ShowDialog();
                            Environment.Exit(0);
                        }
                        else if (hostLastDate.AddDays(3) < now) //主机狗超过3天没有登录
                        {
                            tmrSoftDogChecker.Enabled = false;
                            MessageBox.Show("主机加密狗处于长时间离线状态，为了避免软件被锁定，请及时让主机加密狗处于在线状态", "软件过期", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tmrSoftDogChecker.Enabled = true;
                        }
                    }
                    else
                    {
                        FrmContactUs frm = new FrmContactUs();
                        frm.txtMessage.Text = "没有检测到主机加密狗";
                        frm.ShowDialog();
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
            this.mnu_Operator.Enabled = cur.Permit(Permission.Operator, PermissionActions.Read) || cur.Permit(Permission.Operator, PermissionActions.Edit);
            this.mnu_Role.Enabled = cur.Permit(Permission.Role, PermissionActions.Read) || cur.Permit(Permission.Role, PermissionActions.Edit);
            this.mnu_Options.Enabled = cur.Permit(Permission.SystemOptions, PermissionActions.Read) || cur.Permit(Permission.SystemOptions, PermissionActions.Edit);
            //仓库
            this.mnu_SteelRoll.Enabled = cur.Permit(Permission.SteelRoll, PermissionActions.Read) || cur.Permit(Permission.SteelRoll, PermissionActions.Edit);
            this.mnu_SteelRollSlice.Enabled = cur.Permit(Permission.SteelRollSlice, PermissionActions.Read) || cur.Permit(Permission.SteelRollSlice, PermissionActions.Edit);
            this.mnu_DeliverySheet.Enabled = cur.Permit(Permission.DeliverySheet, PermissionActions.Read) || cur.Permit(Permission.DeliverySheet, PermissionActions.Edit);
            this.mnu_Customer.Enabled = cur.Permit(Permission.Customer, PermissionActions.Read) || cur.Permit(Permission.Customer, PermissionActions.Edit);
            this.mnu_Supplier.Enabled = cur.Permit(Permission.Supplier, PermissionActions.Read) || cur.Permit(Permission.Supplier, PermissionActions.Edit);
            this.mnu_WareHouse.Enabled = cur.Permit(Permission.WareHouse, PermissionActions.Read) || cur.Permit(Permission.WareHouse, PermissionActions.Edit);
            //财务
            this.mnu_CustomerState.Enabled = cur.Permit(Permission.CustomerState, PermissionActions.Read);
            this.mnu_Expanditure.Enabled = cur.Permit(Permission.ExpenditureRecord, PermissionActions.Read) || cur.Permit(Permission.ExpenditureRecord, PermissionActions.Edit);
            this.mnu_SupplierState.Enabled = cur.Permit(Permission.SupplierState, PermissionActions.Read);
            //报表
            this.mnu_DeliveryRecordReport.Enabled = cur.Permit(Permission.DeliveryRecordReport, PermissionActions.Read);
            this.mnu_DeliveryStatistic.Enabled = cur.Permit(Permission.DeliveryRecordReport, PermissionActions.Read);
            this.mnu_InventoryRecord.Enabled = cur.Permit(Permission.InventoryRecordReport, PermissionActions.Read);
            this.mnu_SliceRecordReport.Enabled = cur.Permit(Permission.SliceRecordReport, PermissionActions.Read);
            this.mnu_PaymentReport.Enabled = cur.Permit(Permission.PaymentReport, PermissionActions.Read);
            this.mnu_TaxBillReport.Enabled = cur.Permit(Permission.TaxBillReport, PermissionActions.Read);
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
            ShowSingleForm<FrmProductMaster>(null);
        }

        private void mnu_DeliverySheet_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmStackOutSheetMaster>(sender);
        }

        private void mnu_ProductCategory_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmProductCategoryMaster>(null);
        }

        private void mnu_Customer_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmCustomerMaster>(null);
        }

        private void mnu_WareHouse_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmWareHouseMaster>(null);
        }

        private void mnu_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnu_Operator_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmOperatorMaster>(null);
        }

        private void mnu_Role_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmRoleMaster>(null);
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
            ShowSingleForm<FrmDeliveryRecordReport>(null);
        }

        private void mnu_DeliveryStatistic_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmDeliveryStatistics>(null);
        }

        private void mnu_Supplier_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmSupplierMaster>(null);
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
            ShowSingleForm<FrmWareHouseMaster>(null);
        }

        private void mnu_CustomerReceivable_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmCustomerFinancialStateMaster>(sender);
        }

        private void mnu_CustomerPaymentReport_Click(object sender, EventArgs e)
        {
            ShowSingleForm<LJH.Inventory.UI.Forms.Financial.Report.FrmCustomerPaymentReport>(null);
        }

        private void mnu_Staff_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmStaffMaster>(null);
        }

        private void mnu_SupplierState_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmSupplierFinancialStateMaster>(sender);
        }

        private void mnu_InventoryRecord_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmInventoryRecordReport>(null);
        }

        private void mnu_Material_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmSteelRollMaster>(sender);
        }

        private void mnu_SliceRecordReport_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmSliceRecordReport>(null);
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
            //CheckHostDog();
            UserSettings.Current = SysParaSettingsBll.GetOrCreateSetting<UserSettings>(AppSettings.Current.ConnStr);
            //this.tmrSoftDogChecker.Enabled = _EnableSoftDog;

            OpenLastForms();

            this.ucFormViewMain.FormActivated += new EventHandler(ucFormViewMain_FormActivated);
            this.ucFormViewSecondary.FormActivated += new EventHandler(ucFormViewMain_FormActivated);
        }

        private void ucFormViewMain_FormActivated(object sender, EventArgs e)
        {
            if (sender is LJH.GeneralLibrary.Core.UI.FrmMasterBase)
            {
                (sender as LJH.GeneralLibrary.Core.UI.FrmMasterBase).ReFreshData();
            }
        }

        private void tmrSoftDogChecker_Tick(object sender, EventArgs e)
        {
            CheckDog();
            if (_SoftDog != null)
            {
                if (_SoftDog.IsHost)
                {
                    if (_dtHostDogTime.Date != DateTime.Today)  //一天只写一次主机狗
                    {
                        var p = new SysparameterInfo()
                        {
                            ID = "__dog",
                            Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            Memo = new DTEncrypt().Encrypt(string.Format("{0};{1}", _SoftDog.ProjectNo, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))),
                        };
                        new SysparameterInfoBLL(AppSettings.Current.ConnStr).Save(p);
                        _dtHostDogTime = DateTime.Today;
                    }
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
            ShowSingleForm<LJH.Inventory.UI.Forms.Financial.Report.FrmCustomerTaxBillReport>(null);
        }

        private void 小件盘点报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSingleForm<LJH.Inventory.UI.Forms.Inventory.Report.Frm小件盘点记录报表>(null);
        }

        private void 原材料盘点报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSingleForm<LJH.Inventory.UI.Forms.Inventory.Report.Frm原材料盘点记录报表>(null);
        }
    }
}