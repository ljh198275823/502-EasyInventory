using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.GeneralLibrary;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.Inventory.UI.Forms;
using LJH.Inventory.UI.Forms.General;
using LJH.Inventory.UI.Forms.Sale;

namespace LJH.Inventory.UI.Forms.Inventory.Report
{
    public partial class Frm出货利润明细报表 : FrmReportBase
    {
        public Frm出货利润明细报表()
        {
            InitializeComponent();
        }

        private Dictionary<Guid, ProductInventoryItem> _Piis = new Dictionary<Guid, ProductInventoryItem>();
        private Dictionary<string, List<StackOutRecord>> _AllSS = new Dictionary<string, List<StackOutRecord>>();

        #region 重写基类方法
        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            StackOutRecord sor = item as StackOutRecord;
            row.Cells["colDeliveryDate"].Value = sor.SheetDate.ToString("yyyy-MM-dd");
            row.Cells["colSheetNo"].Value = sor.SheetNo;
            row.Cells["colCustomerName"].Value = sor.Customer.Name;
            row.Cells["colSpecification"].Value = sor.Specification;
            row.Cells["colModel"].Value = sor.Product.Model;
            row.Cells["colCategoryID"].Value = sor.Product.Category.Name;
            row.Cells["colLength"].Value = sor.Length;
            row.Cells["colSourceRollWeight"].Value = sor.SourceRollWeight;
            row.Cells["colPrice"].Value = sor.Price;
            row.Cells["colWithTax"].Value = sor.WithTax;
            row.Cells["colCount"].Value = sor.Count;
            var totalCout = _AllSS[sor.SheetNo].Where(it => it.ProductID == sor.ProductID).Sum(it => it.Count);
            if (totalCout == sor.Count)
            {
                row.Cells["colWeight"].Value = sor.Weight;
                row.Cells["colAmount"].Value = sor.Amount;
            }
            else
            {
                if (sor.Weight.HasValue) row.Cells["colWeight"].Value = sor.Weight.Value * sor.Count / totalCout;
                row.Cells["colAmount"].Value = sor.Amount * sor.Count / totalCout;
            }
            if (_Piis.ContainsKey(sor.ID))
            {
                var sr = _Piis[sor.ID];
                row.Cells["col厂家"].Value = sr.Manufacture;
                row.Cells["col合同号"].Value = sr.PurchaseID;
                CostItem ci = sr.GetCost(CostItem.入库单价);
                if (ci != null) row.Cells["col入库吨价"].Value = ci.Price;
                ci = sr.GetCost(CostItem.运费);
                if (ci != null && ci.Price > 0) row.Cells["col运费"].Value = ci.Price;
                ci = sr.GetCost(CostItem.加工费);
                if (ci != null && ci.Price > 0)
                {
                    row.Cells["col开平费"].Value = ci.Price;
                }
                else
                {
                    ci = sr.GetCost("开平费");
                    if (ci != null && ci.Price > 0) row.Cells["col开平费"].Value = ci.Price;
                }
                ci = sr.GetCost(CostItem.吊装费);
                if (ci != null && ci.Price > 0) row.Cells["col吊装费"].Value = ci.Price;
                ci = sr.GetCost(CostItem.其它费用);
                if (ci != null && ci.Price > 0) row.Cells["col其它费用"].Value = ci.Price;
            }
        }

        protected override List<object> GetDataSource()
        {
            var con = new StackOutSheetSearchCondition();
            con.SheetDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            con.States = new List<SheetState>();
            con.States.Add(SheetState.已发货);
            con.SheetTypes = new List<StackOutSheetType>();
            con.SheetTypes.Add(StackOutSheetType.DeliverySheet);
            if (txtCustomer.Tag != null) con.CustomerID = (txtCustomer.Tag as CompanyInfo).ID;

            _Piis.Clear();
            var pis = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).GetItems(con).QueryObjects;
            foreach (var pi in pis)
            {
                _Piis.Add(pi.DeliveryItem.Value, pi);
            }

            _AllSS.Clear();
            List<StackOutRecord> items = (new StackOutSheetBLL(AppSettings.Current.ConnStr)).GetDeliveryRecords(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                decimal length = txtLength.DecimalValue;
                if (length != 0) items = items.Where(it => it.Length.HasValue && it.Length == length).ToList();
                decimal weight = txtWeight.DecimalValue;
                if (weight != 0) items = items.Where(it => it.Weight.HasValue && it.Weight == weight).ToList();
                decimal sourceRollWeight = txtSourceRollWeight.DecimalValue;
                if (sourceRollWeight != 0) items = items.Where(it => it.SourceRollWeight.HasValue && it.SourceRollWeight == sourceRollWeight).ToList();
                decimal? width = SpecificationHelper.GetWrittenWidth(cmbSpecification.Specification);
                decimal? thick = SpecificationHelper.GetWrittenThick(cmbSpecification.Specification);
                items = (from item in items
                         orderby item.SheetNo ascending, item.AddDate ascending
                         where (!width.HasValue || SpecificationHelper.GetWrittenWidth(item.Specification) == width) &&
                               (!thick.HasValue || SpecificationHelper.GetWrittenThick(item.Specification) == thick)
                         select item).ToList();
                if (items != null && items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        if (!_AllSS.ContainsKey(item.SheetNo)) _AllSS.Add(item.SheetNo, new List<StackOutRecord>());
                        _AllSS[item.SheetNo].Add(item);
                    }
                    return items.Select(it => (object)it).ToList();
                }
            }
            return null;
        }

        protected override void Init()
        {
            ucDateTimeInterval1.ShowTime = false;
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            cmbSpecification.Init();
            btnSaveAs.Enabled = Operator.Current.Permit(Permission.DeliveryRecordReport, PermissionActions.导出);
            base.Init();
        }
        #endregion

        #region 事件处理程序
        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerMaster frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CompanyInfo customer = frm.SelectedItem as CompanyInfo;
                txtCustomer.Text = customer != null ? customer.Name : string.Empty;
                txtCustomer.Tag = customer;
            }
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            txtCustomer.Text = string.Empty;
            txtCustomer.Tag = null;
        }

        private void lnkProductCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmProductCategoryMaster frm = new FrmProductCategoryMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ProductCategory pc = frm.SelectedItem as ProductCategory;
                txtProductCategory.Text = pc != null ? pc.Name : string.Empty;
                txtProductCategory.Tag = pc;
            }
        }

        private void txtProductCategory_DoubleClick(object sender, EventArgs e)
        {
            txtProductCategory.Text = string.Empty;
            txtProductCategory.Tag = null;
        }
        #endregion
    }
}
