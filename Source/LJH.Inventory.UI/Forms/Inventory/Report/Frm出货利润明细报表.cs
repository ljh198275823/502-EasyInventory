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

        private decimal _销售金额 = 0;
        private decimal _国税计提 = 0;
        private decimal _成本合计 = 0;

        #region 重写基类方法
        protected override void ShowItemsOnGrid(List<object> items)
        {
            _成本合计 = 0;
            _国税计提 = 0;
            _销售金额 = 0;
            base.ShowItemsOnGrid(items);
            lbl销售金额.Text = string.Format("销售金额：{0:C2}", _销售金额);
            lbl产品成本.Text = string.Format("产品成本：{0:C2}", _成本合计);
            lbl国税计提.Text = string.Format("国税计提：{0:C2}", _国税计提);
            lbl毛利.Text = string.Format("毛    利：{0:C2}", _销售金额 - _国税计提 - _成本合计);
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            StackOutRecord sor = item as StackOutRecord;
            if (sor.Price == 0) //这里是用于解决之前送货单的一个BUG，就是出货的时候同一种产品，后面加的可能单价是0
            {
                var p = _AllSS[sor.SheetNo].FirstOrDefault(it => it.ProductID == sor.ProductID && it.Price > 0);
                if (p != null)
                {
                    sor.Price = p.Price;
                }
            }
            row.Tag = sor;
            row.Cells["colDeliveryDate"].Value = sor.SheetDate.ToString("yyyy-MM-dd");
            row.Cells["colSheetNo"].Value = sor.SheetNo;
            row.Cells["colCustomerName"].Value = sor.Customer.Name;
            row.Cells["colSpecification"].Value = sor.Specification;
            row.Cells["colModel"].Value = sor.Product.Model;
            row.Cells["colCategoryID"].Value = sor.Product.Category.Name;
            row.Cells["colLength"].Value = sor.Length;
            if (sor.SourceRollWeight.HasValue) row.Cells["colSourceRollWeight"].Value = sor.SourceRollWeight;
            else row.Cells["colSourceRollWeight"].Value = "查看";
            row.Cells["colPrice"].Value = sor.Price;
            row.Cells["colWithTax"].Value = sor.WithTax;
            row.Cells["colCount"].Value = sor.Count;
            var totalCout = _AllSS[sor.SheetNo].Where(it => it.ProductID == sor.ProductID).Sum(it => it.Count);
            var amount = sor.Weight.HasValue ? sor.Amount * sor.Count / totalCout : sor.Amount;
            _销售金额 += amount;
            if (totalCout == sor.Count)
            {
                row.Cells["colWeight"].Value = sor.Weight;
                row.Cells["colAmount"].Value = amount;
            }
            else
            {
                if (sor.Weight.HasValue) row.Cells["colWeight"].Value = sor.Weight.Value * sor.Count / totalCout;
                row.Cells["colAmount"].Value = amount;
            }
            decimal unitCost = 0;
            if (_Piis.ContainsKey(sor.ID))
            {
                var sr = _Piis[sor.ID];
                row.Cells["col厂家"].Value = sr.Manufacture;
                row.Cells["col合同号"].Value = sr.PurchaseID;
                if (Operator.Current.Permit(Permission.结算单价, PermissionActions.Read))
                {
                    CostItem ci = sr.GetCost(CostItem.结算单价);
                    if (ci != null) row.Cells["col结算单价"].Value = ci.Price;
                }
                if (Operator.Current.Permit(Permission.其它成本, PermissionActions.Read))
                {
                    CostItem ci = sr.GetCost(CostItem.运费);
                    if (ci != null && ci.Price > 0) row.Cells["col运费"].Value = ci.Price;
                    ci = sr.GetCost(CostItem.短途运费1);
                    if (ci != null && ci.Price > 0) row.Cells["col短途运费"].Value = ci.Price;
                    ci = sr.GetCost(CostItem.短途运费2);
                    if (ci != null && ci.Price > 0) row.Cells["col短途运费2"].Value = ci.Price;
                    ci = sr.GetCost(CostItem.加工费);
                    if (ci != null && ci.Price > 0) row.Cells["col加工费"].Value = ci.Price;
                    ci = sr.GetCost(CostItem.开平费);
                    if (ci != null && ci.Price > 0) row.Cells["col开平费"].Value = ci.Price;
                    ci = sr.GetCost(CostItem.分条费);
                    if (ci != null && ci.Price > 0) row.Cells["col分条费"].Value = ci.Price;
                    ci = sr.GetCost(CostItem.吊装费);
                    if (ci != null && ci.Price > 0) row.Cells["col吊装费"].Value = ci.Price;
                    ci = sr.GetCost(CostItem.其它费用);
                    if (ci != null && ci.Price > 0) row.Cells["col其它费用"].Value = ci.Price;
                    ci = sr.GetCost(CostItem.入库单价);
                    if (ci != null && ci.Price > 0) row.Cells["col入库单价"].Value = ci.Price;
                }
                unitCost = sr.CalUnitCost(sor.WithTax, UserSettings.Current.税点系数);
                if (sr.Model != ProductModel.原材料) row.Cells["col单件成本"].Value = unitCost;
                else if (sor.Weight > 0) row.Cells["col单件成本"].Value = unitCost / sor.Weight.Value; //卷材显示吨价
                row.Cells["col成本合计"].Value = unitCost * sor.Count;
            }
            _成本合计 += unitCost * sor.Count;
            var 国税计提 = sor.WithTax ? amount * UserSettings.Current.国税系数 : 0;
            _国税计提 += 国税计提;
            row.Cells["col国税计提"].Value = 国税计提;
            row.Cells["col利润合计"].Value = amount - unitCost * sor.Count - 国税计提;
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
                if (!string.IsNullOrEmpty(txtSheetNo.Text)) items = items.Where(it => it.SheetNo.Contains(txtSheetNo.Text)).ToList();
                if (txtProductCategory.Tag != null) items = items.Where(it => it.Product.CategoryID == (txtProductCategory.Tag as ProductCategory).ID).ToList();
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

        private void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                var sor = gridView.Rows[e.RowIndex].Tag as StackOutRecord;
                if (gridView.Columns[e.ColumnIndex].Name == "col单件成本")
                {
                    if (_Piis.ContainsKey(sor.ID))
                    {
                        var frm = new Frm成本明细();
                        frm.ProductInventoryItem = _Piis[sor.ID];
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                        btnSearch.PerformClick();
                    }
                }
                else if (gridView.Columns[e.ColumnIndex].Name == "colSheetNo")
                {
                    var sheet = new StackOutSheetBLL(AppSettings.Current.ConnStr).GetByID(sor.SheetNo).QueryObject;
                    if (sheet != null)
                    {
                        Inventory.FrmStackOutSheetDetail frm = new Inventory.FrmStackOutSheetDetail();
                        frm.IsAdding = false;
                        frm.IsForView = true;
                        frm.UpdatingItem = sheet;
                        frm.ShowDialog();
                    }
                }
                else if (gridView.Columns[e.ColumnIndex].Name == "colSourceRollWeight")
                {
                    if (_Piis.ContainsKey(sor.ID))
                    {
                        var sr = _Piis[sor.ID];
                        if (sr.SourceRoll != null)
                        {
                            var pi = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).GetByID(sr.SourceRoll.Value).QueryObject;
                            if (pi != null)
                            {
                                FrmSteelRollDetail frm = new FrmSteelRollDetail();
                                frm.UpdatingItem = pi;
                                frm.IsForView = true;
                                frm.ShowDialog();
                            }
                        }
                        else if (sr.Model == ProductModel.原材料)
                        {
                            FrmSteelRollDetail frm = new FrmSteelRollDetail();
                            frm.UpdatingItem = sr;
                            frm.IsForView = true;
                            frm.ShowDialog();
                        }
                        else
                        {
                            ProductInventoryItem pi = null;
                            if (sr.SourceID == null) pi = sr;
                            else pi = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).GetByID(sr.SourceID.Value).QueryObject;
                            while (pi != null && pi.SourceID != null) //直到取到最后的入库项
                            {
                                pi = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).GetByID(pi.SourceID.Value).QueryObject;
                            }
                            if (pi != null && pi.Model != ProductModel.其它产品)
                            {
                                FrmSteelRollSliceStackIn frm = new FrmSteelRollSliceStackIn();
                                frm.SteelRollSlice = pi;
                                frm.IsForView = true;
                                frm.ShowDialog();
                            }
                            else
                            {
                                Frm其它产品入库 frm = new Frm其它产品入库();
                                frm.SteelRollSlice = pi;
                                frm.IsForView = true;
                                frm.ShowDialog();
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
