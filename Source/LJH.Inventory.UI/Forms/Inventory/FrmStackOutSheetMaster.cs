using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmStackOutSheetMaster : FrmMasterBase
    {
        public FrmStackOutSheetMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<StackOutSheet> _Sheets = null;
        private List<WareHouse> _Warehouses = null;
        private Dictionary<string, CompanyInfo> _AllCustomers = new Dictionary<string, CompanyInfo>();

        private List<AccountRecord> _AllPayments = null;
        private Dictionary<string, List<CustomerReceivable>> _Receivables = new Dictionary<string, List<CustomerReceivable>>();
        private bool _Fresh = false;
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> objs = FilterData();
            ShowItemsOnGrid(objs);
        }

        private DateTimeRange GetDateTimeRange()
        {
            if (chkSheetDate.Checked)
            {
                return new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            }
            if (UserSettings.Current != null)
            {
                if (UserSettings.Current.LoadSheetsBefore == 0) return new DateTimeRange(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), DateTime.MaxValue);
                return new DateTimeRange(DateTime.Today.AddMonths(-UserSettings.Current.LoadSheetsBefore), DateTime.MaxValue);
            }
            return new DateTimeRange(DateTime.Today.AddYears(-1), DateTime.MaxValue); //最近一年的送货单
        }

        private List<object> FilterData()
        {
            List<StackOutSheet> items = _Sheets;
            if (items != null && items.Count > 0)
            {
                if (!string.IsNullOrEmpty(txtCustomer.Text))
                {
                    if (_AllCustomers != null)
                    {
                        List<CompanyInfo> pcs = _AllCustomers.Where(it => it.Value.Name.Contains(txtCustomer.Text)).Select(it => it.Value).ToList();
                        if (pcs != null && pcs.Count > 0)
                        {
                            items = items.Where(it => pcs.Exists(c => c.ID == it.CustomerID)).ToList();
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                if (items != null)
                {
                    items = items.Where(item => ((item.State == SheetState.Add && chkAdded.Checked) ||
                                            (item.State == SheetState.Approved && chkApproved.Checked) ||
                                            (item.State == SheetState.Shipped && chkShipped.Checked) ||
                                            (item.State == SheetState.Canceled && chkNullify.Checked))).ToList();
                }
                if (items != null) items = items.Where(item => (chkWithTax.Checked && item.WithTax) ||
                                              (chkWithoutTax.Checked && !item.WithTax)).ToList();
            }
            List<object> objs = null;
            if (items != null && items.Count > 0) objs = (from item in items orderby item.ID descending select (object)item).ToList();
            return objs;
        }

        private void 显示总重量和总金额()
        {
            decimal totalAmount = 0;
            decimal totalWeight = 0;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Visible == false) continue;
                var s = r.Tag as StackOutSheet;
                totalAmount += s.Amount;
                totalWeight += s.TotalWeight;
            }
            lblTotalWeight.Text = string.Format("总重量 {0:F3}吨", totalWeight);
            lblTotalAmount.Text = string.Format("总金额 {0:F2}元", totalAmount);
        }
        #endregion

        #region 重写基类方法和处理事件
        protected override void Init()
        {
            base.Init();
            this.ucDateTimeInterval1.Init();
            this.ucDateTimeInterval1.SelectThisMonth();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Edit);
            mnu_AddSheet.Enabled = Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Edit);
            cMnu_Export.Enabled = Operator.Current.Permit(Permission.DeliverySheet , PermissionActions.导出);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmStackOutSheetDetail frm = new FrmStackOutSheetDetail();
            frm.IsAdding = true;
            frm.UpdatingItem = StackOutSheet.Create(null, null);
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            _AllCustomers.Clear();
            var cs = new CompanyBLL(AppSettings.Current.ConnStr).GetAllCustomers().QueryObjects;
            if (cs != null && cs.Count > 0)
            {
                foreach (var c in cs) _AllCustomers.Add(c.ID, c);
            }

            if (SearchCondition == null)
            {
                StackOutSheetSearchCondition con = new StackOutSheetSearchCondition();
                con.SheetDate = GetDateTimeRange();
                _Sheets = (new StackOutSheetBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            }
            else
            {
                _Sheets = (new StackOutSheetBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            var ret = FilterData();
            return ret;
        }

        protected override void ShowItemsOnGrid(List<object> items)
        {
            _Warehouses = (new WareHouseBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            CustomerReceivableSearchCondition crsc = new CustomerReceivableSearchCondition();
            crsc.CreateDate = GetDateTimeRange();
            crsc.ReceivableTypes = new List<CustomerReceivableType>() { CustomerReceivableType.CustomerReceivable };
            var crs = new CustomerReceivableBLL(AppSettings.Current.ConnStr).GetItems(crsc).QueryObjects;
            _Receivables.Clear();
            if (crs != null && crs.Count > 0)
            {
                foreach (var cr in crs)
                {
                    if (!_Receivables.ContainsKey(cr.SheetID)) _Receivables.Add(cr.SheetID, new List<CustomerReceivable>());
                    _Receivables[cr.SheetID].Add(cr);
                }
            }

            AccountRecordSearchCondition cpsc = new AccountRecordSearchCondition();
            cpsc.PaymentTypes = new List<CustomerPaymentType>() { CustomerPaymentType.客户收款 };
            cpsc.HasRemain = true;
            _AllPayments = new AccountRecordBLL(AppSettings.Current.ConnStr).GetItems(cpsc).QueryObjects;

            _Fresh = true;
            base.ShowItemsOnGrid(items);
            显示总重量和总金额();
            _Fresh = false;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            StackOutSheet sheet = item as StackOutSheet;
            row.Tag = sheet;
            row.Cells["colSheetDate"].Value = sheet.SheetDate.ToString("yyyy年MM月dd日");
            row.Cells["colSheetNo"].Value = sheet.ID;
            CompanyInfo customer = _AllCustomers.ContainsKey(sheet.CustomerID) ? _AllCustomers[sheet.CustomerID] : null;
            row.Cells["colCustomer"].Value = customer != null ? customer.Name : string.Empty;
            row.Cells["colFileID"].Value = customer != null ? customer.FileID : null;
            row.Cells["colWithTax"].Value = sheet.WithTax;
            row.Cells["colTotalWeight"].Value = sheet.TotalWeight;
            row.Cells["colAmount"].Value = sheet.Amount;
            row.Cells["colState"].Value = SheetStateDescription.GetDescription(sheet.State);
            row.Cells["colShipDate"].Value = sheet.State == SheetState.Shipped ? (DateTime?)sheet.LastActiveDate : null;
            row.Cells["colLinker"].Value = sheet.Linker;
            row.Cells["colTelphone"].Value = sheet.LinkerCall;
            row.Cells["colAddress"].Value = sheet.Address;
            row.Cells["colDriver"].Value = sheet.Driver;
            row.Cells["colDriverCall"].Value = sheet.DriverCall;
            row.Cells["colCarPlate"].Value = sheet.CarPlate;
            row.Cells["colMemo"].Value = sheet.Memo;
            if (_Fresh) //全部刷新
            {
                if (sheet.State == SheetState.Shipped)
                {
                    var cr = _Receivables.ContainsKey(sheet.ID) ? _Receivables[sheet.ID] : null;
                    row.Cells["colPaid"].Value = cr != null ? cr.Sum(it => it.Haspaid) : 0; ;
                    row.Cells["colNotPaid"].Value = cr != null ? cr.Sum(it => it.Remain) : 0;
                }
                else if (sheet.State == SheetState.Add || sheet.State == SheetState.Approved)
                {
                    if (_AllPayments != null)
                    {
                        var cr = _AllPayments.Where(it => it.StackSheetID == sheet.ID && it.ClassID == CustomerPaymentType.客户收款);
                        row.Cells["colPaid"].Value = cr.Sum(it => it.Remain);
                        row.Cells["colNotPaid"].Value = sheet.Amount - cr.Sum(it => it.Remain);
                    }
                }
            }
            else //单独一条记录刷新
            {
                var sheetState = new StackOutSheetBLL(AppSettings.Current.ConnStr).GetFinancialStateOf(sheet.ID).QueryObject;
                if (sheetState != null)
                {
                    row.Cells["colPaid"].Value = sheetState.Paid;
                    row.Cells["colNotPaid"].Value = sheetState.NotPaid;
                }
                显示总重量和总金额();
                new StackOutSheetBLL(AppSettings.Current.ConnStr).GetCosts(sheet); //重新获取成本
            }
            if (Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.显示成本))
            {
                if (sheet.Costs.HasValue) row.Cells["colCosts"].Value = sheet.Costs.Value;
                if (sheet.WithTax) row.Cells["col国税计提"].Value = sheet.Amount * UserSettings.Current.国税系数;
                row.Cells["col毛利"].Value = sheet.Profit;
            }
            if (!_Sheets.Exists(it => it.ID == sheet.ID)) _Sheets.Add(sheet);
            ShowRowColor(row);
        }

        private void ShowRowColor(DataGridViewRow row)
        {
            StackOutSheet sheet = row.Tag as StackOutSheet;
            if (sheet.State == SheetState.Add)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
            }
            else if (sheet.State == SheetState.Shipped)
            {
                row.DefaultCellStyle.ForeColor = Color.Blue;
            }
            else if (sheet.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
        }

        protected override bool DeletingItem(object item)
        {
            MessageBox.Show("不能删除送货单,可以将送货单作废", "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        #endregion

        #region 事件处理程序
        private void FreshData_Clicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            FreshData();
        }

        private void FreshData_Clicked(object sender, EventArgs e)
        {
            FreshData();
        }

        private void mnu_AddSheet_Click(object sender, EventArgs e)
        {
            PerformAddData();
        }

        private void chkSheetDate_CheckedChanged(object sender, EventArgs e)
        {
            cMnu_Fresh.PerformClick();
        }

        private void btnLast3Month_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            ucDateTimeInterval1.StartDateTime = today.AddMonths(-3);
            ucDateTimeInterval1.EndDateTime = today.AddDays(1).AddSeconds(-1);
        }

        private void ucDateTimeInterval1_ValueChanged(object sender, EventArgs e)
        {
            if (chkSheetDate.Checked) cMnu_Fresh.PerformClick();
        }
        #endregion
    }
}
