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
using LJH.Inventory.UI.Report;
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
        private List<CompanyInfo> _AllCustomers = null;
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
                if (UserSettings.Current.LoadSheetsBefore == 0) return new DateTimeRange(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), DateTime.Now);
                return new DateTimeRange(DateTime.Today.AddMonths(-UserSettings.Current.LoadSheetsBefore), DateTime.Now);
            }
            return new DateTimeRange(DateTime.Today.AddYears(-1), DateTime.Now); //最近一年的送货单
        }

        private List<object> FilterData()
        {
            List<StackOutSheet> items = _Sheets;
            if (items != null && items.Count > 0)
            {
                if (chkSheetDate.Checked) items = items.Where(it => it.SheetDate >= ucDateTimeInterval1.StartDateTime && it.SheetDate <= ucDateTimeInterval1.EndDateTime).ToList();
                if (this.customerTree1.SelectedNode != null)
                {
                    List<CompanyInfo> pcs = null;
                    pcs = this.customerTree1.GetCompanyofNode(this.customerTree1.SelectedNode);
                    if (pcs != null && pcs.Count > 0)
                    {
                        items = items.Where(it => pcs.Exists(c => c.ID == it.CustomerID)).ToList();
                    }
                    else
                    {
                        items = null;
                    }
                }
                if (!string.IsNullOrEmpty(txtCustomer.Text))
                {
                    if (_AllCustomers == null) _AllCustomers = new CompanyBLL(AppSettings.Current.ConnStr).GetAllCustomers().QueryObjects;
                    if (_AllCustomers != null)
                    {
                        List<CompanyInfo> pcs = _AllCustomers.Where(it => it.Name.Contains(txtCustomer.Text)).ToList();
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
                items = items.Where(item => ((item.State == SheetState.Add && chkAdded.Checked) ||
                                        (item.State == SheetState.Approved && chkApproved.Checked) ||
                                        (item.State == SheetState.Shipped && chkShipped.Checked) ||
                                        (item.State == SheetState.Canceled && chkNullify.Checked))).ToList();
                items = items.Where(item => (chkWithTax.Checked && item.WithTax) ||
                                            (chkWithoutTax.Checked && !item.WithTax)).ToList();
            }
            List<object> objs = null;
            if (items != null && items.Count > 0) objs = (from item in items orderby item.ID descending select (object)item).ToList();
            return objs;
        }
        #endregion

        #region 重写基类方法和处理事件
        public override void ReFreshData()
        {
            customerTree1.Init();
            base.ReFreshData();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Edit);
            mnu_AddSheet.Enabled = Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Edit);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmStackOutSheetDetail frm = new FrmStackOutSheetDetail();
            var customer = (customerTree1.SelectedNode != null) ? customerTree1.SelectedNode.Tag as CompanyInfo : null;
            frm.IsAdding = true;
            frm.UpdatingItem = StackOutSheet.Create(customer, null);
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            if (SearchCondition == null)
            {
                StackOutSheetSearchCondition con = new StackOutSheetSearchCondition();
                con.LastActiveDate = GetDateTimeRange();
                _Sheets = (new StackOutSheetBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            }
            else
            {
                _Sheets = (new StackOutSheetBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            _Warehouses = (new WareHouseBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            return FilterData();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            StackOutSheet sheet = item as StackOutSheet;
            row.Tag = sheet;
            row.Cells["colSheetDate"].Value = sheet.SheetDate.ToString("yyyy年MM月dd日");
            row.Cells["colSheetNo"].Value = sheet.ID;
            CompanyInfo customer = customerTree1.GetCustomer(sheet.CustomerID);
            row.Cells["colCustomer"].Value = customer != null ? customer.Name : string.Empty;
            row.Cells["colWithTax"].Value = sheet.WithTax;
            row.Cells["colAmount"].Value = sheet.Amount;
            row.Cells["colState"].Value = SheetStateDescription.GetDescription(sheet.State);
            row.Cells["colShipDate"].Value = sheet.State == SheetState.Shipped ? (DateTime?)sheet.LastActiveDate: null;
            row.Cells["colLinker"].Value = sheet.Linker;
            row.Cells["colTelphone"].Value = sheet.LinkerCall;
            row.Cells["colAddress"].Value = sheet.Address;
            row.Cells["colDriver"].Value = sheet.Driver;
            row.Cells["colDriverCall"].Value = sheet.DriverCall;
            row.Cells["colCarPlate"].Value = sheet.CarPlate;
            row.Cells["colMemo"].Value = sheet.Memo;
            if (sheet.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
            if (!_Sheets.Exists(it => it.ID == sheet.ID)) _Sheets.Add(sheet);
        }

        protected override bool DeletingItem(object item)
        {
            MessageBox.Show("不能删除送货单,可以将送货单作废", "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        #endregion

        #region 事件处理程序
        private void ucDateTimeInterval1_ValueChanged(object sender, EventArgs e)
        {
            if (chkSheetDate.Checked) cMnu_Fresh.PerformClick();
        }

        private void FreshData_Clicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            FreshData();
        }

        private void FreshData_Clicked(object sender, EventArgs e)
        {
            FreshData();
        }

        private void chkSheetDate_CheckedChanged(object sender, EventArgs e)
        {
            cMnu_Fresh.PerformClick();
        }

        private void mnu_AddSheet_Click(object sender, EventArgs e)
        {
            PerformAddData();
        }
        #endregion

        private void btnLast3Month_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            ucDateTimeInterval1.StartDateTime = today.AddMonths(-3);
            ucDateTimeInterval1.EndDateTime = today.AddDays(1).AddSeconds(-1);
        }

       
    }
}
