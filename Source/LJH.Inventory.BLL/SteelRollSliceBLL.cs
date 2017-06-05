using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class SteelRollSliceBLL
    {
        #region 构造函数
        public SteelRollSliceBLL(string repoUri)
        {
            RepoUri = repoUri;
        }
        #endregion

        private string RepoUri = null;
        private const string MODEL = "原材料";

        #region 私有方法
        private void AddReceivables(ProductInventoryItem sheet, DateTime dt, IUnitWork unitWork)
        {
            CustomerReceivable cr = null;
            CustomerReceivable original = null;
            CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
            con.SheetID = sheet.ID.ToString();
            con.ReceivableTypes = new List<CustomerReceivableType>();
            con.ReceivableTypes.Add(CustomerReceivableType.SupplierReceivable);
            var items = ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (items != null && items.Count >= 1) original = items[0];

            if (original == null)
            {
                cr = new CustomerReceivable();
                cr.ID = Guid.NewGuid();
                cr.CreateDate = dt;
                cr.ClassID = CustomerReceivableType.SupplierReceivable;
                cr.SheetID = sheet.ID.ToString();
            }
            else
            {
                cr = original.Clone();
            }
            cr.CustomerID = sheet.Supplier;
            cr.OrderID = sheet.PurchaseID;
            cr.SetProperty("规格", sheet.Product.Specification);
            decimal amount = sheet.CalReceivable();
            if (original != null && original.Haspaid > amount) throw new Exception("原材料应收已核销的金额超过当前总价，请先取消部分核销金额再保存");
            cr.Amount = amount;
            if (original == null)
            {
                if (cr.Amount > 0) ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Insert(cr, unitWork);
            }
            else
            {
                ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Update(cr, original, unitWork);
            }
        }

        private void AddTax(ProductInventoryItem sheet, DateTime dt, IUnitWork unitWork)
        {
            CustomerReceivable tax = null;
            CustomerReceivable original = null;
            CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
            con.SheetID = sheet.ID.ToString();
            con.ReceivableTypes = new List<CustomerReceivableType>();
            con.ReceivableTypes.Add(CustomerReceivableType.SupplierTax);
            var items = ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (items != null && items.Count >= 1) original = items[0];

            if (original == null)
            {
                tax = new CustomerReceivable()
                {
                    ID = Guid.NewGuid(),
                    CreateDate = dt,
                    ClassID = CustomerReceivableType.SupplierTax,
                    SheetID = sheet.ID.ToString(),
                };
            }
            else
            {
                tax = original.Clone();
            }
            tax.CustomerID = sheet.Supplier;
            tax.OrderID = sheet.PurchaseID;
            tax.SetProperty("规格", sheet.Product.Specification);
            decimal amount = sheet.CalTax();
            if (original != null && original.Haspaid > amount) throw new Exception("原材料应开发票已核销的金额超过当前总价，请先取消部分核销发票再保存");
            tax.Amount = amount;
            if (original == null)
            {
                if (amount > 0) ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Insert(tax, unitWork);
            }
            else
            {
                ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Update(tax, original, unitWork);
            }
        }
        #endregion

        #region 公共方法
        public QueryResultList<SteelRollSlice> GetSteelRollSlices(SearchCondition con)
        {
            List<SteelRollSlice> items = null;
            QueryResultList<ProductInventoryItem> ret = GetItems(con);
            if (ret.QueryObjects != null && ret.QueryObjects.Count > 0)
            {
                var gs = from it in ret.QueryObjects
                         group it by new { it.ProductID };
                foreach (var g in gs)
                {
                    if (items == null) items = new List<SteelRollSlice>();
                    SteelRollSlice srs = new SteelRollSlice();
                    srs.ID = Guid.Empty;
                    srs.Product = g.First().Product;
                    srs.Unit = g.First().Unit;
                    srs.WaitShipping = g.Sum(it => it.State == ProductInventoryState.WaitShipping ? it.Count : 0);
                    srs.Reserved = g.Sum(it => it.State == ProductInventoryState.Reserved ? it.Count : 0);
                    srs.Valid = g.Sum(it => it.State == ProductInventoryState.Inventory ? it.Count : 0);
                    items.Add(srs);
                }
            }
            return new QueryResultList<SteelRollSlice>(ret.Result, ret.Message, items);
        }

        public QueryResultList<ProductInventoryItem> GetItems(SearchCondition con)
        {
            if (con == null) con = new ProductInventoryItemSearchCondition();
            if (con is ProductInventoryItemSearchCondition) (con as ProductInventoryItemSearchCondition).ExcludeModel = MODEL;  //排除原材料库存项
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con);
            return ret;
        }

        public CommandResult Add(ProductInventoryItem info)
        {
            try
            {
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(info, unitWork);
                if (!string.IsNullOrEmpty(info.Supplier))
                {
                    var s = ProviderFactory.Create<IProvider<CompanyInfo, string>>(RepoUri).GetByID(info.Supplier).QueryObject;
                    if (s != null)
                    {
                        DateTime dt = DateTime.Now;
                        AddReceivables(info, new DateTime(info.AddDate.Year, info.AddDate.Month, info.AddDate.Day, dt.Hour, dt.Minute, dt.Second), unitWork);
                        if (info.CalTax() > 0) AddTax(info, new DateTime(info.AddDate.Year, info.AddDate.Month, info.AddDate.Day, dt.Hour, dt.Minute, dt.Second), unitWork);
                    }
                }
                return unitWork.Commit();
            }
            catch (Exception ex)
            {
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }
        /// <summary>
        /// 盘点
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult Check(ProductInventoryItem info, decimal newCount, string checker, string memo)
        {
            try
            {
                if (info.Count == newCount) return new CommandResult(ResultCode.Fail, "实盘数量和库存数量一致");
                if (info.State == ProductInventoryState.Nullified) return new CommandResult(ResultCode.Fail, "作废的库存项不能进行盘点操作");
                if (info.State != ProductInventoryState.Inventory) return new CommandResult(ResultCode.Fail, "库存项数量处于锁定状态,不能盘点");
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
                ProductInventoryItem clone = info.Clone();
                decimal? uw = info.UnitWeight;
                if (uw != null) clone.Weight = newCount * uw; 
                clone.Count = newCount;
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, info, unitWork);

                InventoryCheckRecord record = new InventoryCheckRecord();
                record.ID = Guid.NewGuid();
                record.CheckDateTime = DateTime.Now;
                record.ProductID = info.ProductID;
                record.WarehouseID = info.WareHouseID;
                record.Unit = info.Unit;
                record.Price = 0;
                record.Inventory = info.Count;
                record.CheckCount = newCount;
                record.SourceID = info.ID;
                record.Customer = info.Customer;
                record.Checker = checker;
                record.Operator = Operator.Current.Name;
                record.Memo = memo;
                ProviderFactory.Create<IProvider<InventoryCheckRecord, Guid>>(RepoUri).Insert(record, unitWork);

                var ret = unitWork.Commit();
                if (ret.Result == ResultCode.Successful)
                {
                    info.Count = clone.Count;
                    info.Weight = clone.Weight;
                }
                return ret;
            }
            catch (Exception ex)
            {
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }
        /// <summary>
        /// 拆包
        /// </summary>
        public CommandResult Depart(ProductInventoryItem info, WareHouse w, string customer, decimal count, string specification, string memo)
        {
            if (info.Count < count) return new CommandResult(ResultCode.Fail, "拆包数量大于原包数量");
            if (info.State == ProductInventoryState.Nullified) return new CommandResult(ResultCode.Fail, "作废的库存项不能进行拆包操作");
            if (info.State != ProductInventoryState.Inventory) return new CommandResult(ResultCode.Fail, "库存项数量处于锁定状态,不能拆包");

            Product p = new ProductBLL(AppSettings.Current.ConnStr).Create(info.Product.CategoryID, specification, info.Product.Model, info.Product.Weight, info.Product.Length, info.Product.Density);
            if (p == null) return new CommandResult(ResultCode.Fail, "创建产品信息失败");

            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            decimal? uw = info.UnitWeight;
            ProductInventoryItem clone = info.Clone();
            clone.Count -= count;
            if (uw.HasValue) clone.Weight = clone.Count * uw;
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, info, unitWork);

            ProductInventoryItem depart = info.Clone();
            depart.ID = Guid.NewGuid();
            depart.WareHouseID = w.ID;
            depart.Customer = customer;
            depart.Count = count;
            depart.ProductID = p.ID;
            depart.Product = p;
            if (uw.HasValue)
            {
                depart.OriginalWeight = depart.Count * uw;
                depart.Weight = depart.OriginalWeight;
            }
            else
            {
                depart.OriginalWeight = null;
                depart.Weight = null;
            }
            depart.SourceID = info.ID;
            depart.Memo = memo;
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(depart, unitWork);

            var ret = unitWork.Commit();
            if (ret.Result == ResultCode.Successful)
            {
                info.Count = clone.Count;
                info.Weight = clone.Weight;
            }
            return ret;
        }
        #endregion
    }
}
