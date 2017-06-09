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
    public class ProductInventoryItemBLL : BLLBase<Guid, ProductInventoryItem>
    {
        #region 构造函数
        public ProductInventoryItemBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 保护方法
        protected virtual void AddReceivables(ProductInventoryItem sheet, DateTime dt, IUnitWork unitWork)
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
            cr.SetProperty("重量", sheet.OriginalWeight.HasValue ? sheet.OriginalWeight.Value.ToString("F3") : null);
            cr.SetProperty("入库单价", sheet.GetCost(CostItem.入库单价) != null ? sheet.GetCost(CostItem.入库单价).Price.ToString("F2") : null);
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

        protected virtual void AddTax(ProductInventoryItem sheet, DateTime dt, IUnitWork unitWork)
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
            tax.SetProperty("重量", sheet.OriginalWeight.HasValue ? sheet.OriginalWeight.Value.ToString("F3") : null);
            tax.SetProperty("入库单价", sheet.GetCost(CostItem.入库单价) != null ? sheet.GetCost(CostItem.入库单价).Price.ToString("F2") : null);
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

        protected virtual bool DelTax(ProductInventoryItem sheet)
        {
            bool allSuccess = true;
            CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
            con.SheetID = sheet.ID.ToString();
            con.ReceivableTypes = new List<CustomerReceivableType>();
            con.ReceivableTypes.Add(CustomerReceivableType.SupplierTax);
            var items = ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                var bll = new CustomerReceivableBLL(RepoUri);
                foreach (var item in items)
                {
                    var t = bll.Delete(item);
                    allSuccess = t.Result == ResultCode.Successful;
                    if (!allSuccess) break;
                }
            }
            return allSuccess;
        }
        #endregion

        #region 重写基类方法
        public override CommandResult Add(ProductInventoryItem sr)
        {
            try
            {
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(sr, unitWork);
                if (!string.IsNullOrEmpty(sr.Supplier))
                {
                    var s = ProviderFactory.Create<IProvider<CompanyInfo, string>>(RepoUri).GetByID(sr.Supplier).QueryObject;
                    if (s != null)
                    {
                        var dt = DateTime.Now;
                        AddReceivables(sr, new DateTime(sr.AddDate.Year, sr.AddDate.Month, sr.AddDate.Day, dt.Hour, dt.Minute, dt.Second), unitWork);
                        if (sr.CalTax() > 0) AddTax(sr, new DateTime(sr.AddDate.Year, sr.AddDate.Month, sr.AddDate.Day, dt.Hour, dt.Minute, dt.Second), unitWork);
                    }
                }
                return unitWork.Commit();
            }
            catch (Exception ex)
            {
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }

        public override CommandResult Update(ProductInventoryItem sr)
        {
            try
            {
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
                var o = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetByID(sr.ID).QueryObject;
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(sr, o, unitWork);
                if (!string.IsNullOrEmpty(sr.Supplier))
                {
                    DateTime dt = DateTime.Now;
                    var s = ProviderFactory.Create<IProvider<CompanyInfo, string>>(RepoUri).GetByID(sr.Supplier).QueryObject;
                    if (s != null)
                    {
                        AddReceivables(sr, new DateTime(sr.AddDate.Year, sr.AddDate.Month, sr.AddDate.Day, dt.Hour, dt.Minute, dt.Second), unitWork);
                        if (sr.CalTax() > 0) AddTax(sr, new DateTime(sr.AddDate.Year, sr.AddDate.Month, sr.AddDate.Day, dt.Hour, dt.Minute, dt.Second), unitWork);
                    }
                    if (o.CalTax() > 0 && sr.CalTax() == 0 && !DelTax(sr)) return new CommandResult(ResultCode.Fail, "删除应开增值税时出错，请重试");
                }
                return unitWork.Commit();
            }
            catch (Exception ex)
            {
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }
        #endregion

        #region 公共方法
        public CommandResult UpdateMemo(ProductInventoryItem pi, string memo)
        {
            var clone = pi.Clone();
            clone.Memo = memo;
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, pi);
            if (ret.Result == ResultCode.Successful) pi.Memo = memo;
            return ret;
        }

        public CommandResult UpdateWareHouse(ProductInventoryItem pi, WareHouse ws)
        {
            var clone = pi.Clone();
            clone.WareHouseID = ws.ID;
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, pi);
            if (ret.Result == ResultCode.Successful)
            {
                pi.WareHouseID = clone.WareHouseID;
            }
            return ret;
        }

        public List<string> GetAllMaterails()
        {
            return ProviderFactory.Create<IMaterialProvider>(RepoUri).GetItems();
        }

        public List<string> GetAllCarplates()
        {
            return ProviderFactory.Create<ICarplateProvider>(RepoUri).GetItems();
        }

        public CommandResult Reserve(ProductInventoryItem pi, string customer)
        {
            if (pi.State != ProductInventoryState.Inventory) return new CommandResult(ResultCode.Fail, "不能预订");
            var clone = pi.Clone();
            clone.State = ProductInventoryState.Reserved;
            clone.Customer = customer;
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, pi);
            if (ret.Result == ResultCode.Successful)
            {
                pi.State = clone.State;
                pi.Customer = clone.Customer;
            }
            return ret;
        }

        public CommandResult UnReserve(ProductInventoryItem pi)
        {
            if (pi.State != ProductInventoryState.Reserved) return new CommandResult(ResultCode.Fail, "没有预订的项不能取消预订");
            var clone = pi.Clone();
            clone.State = ProductInventoryState.Inventory;
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, pi);
            if (ret.Result == ResultCode.Successful)
            {
                pi.State = clone.State;
            }
            return ret;
        }

        /// <summary>
        /// 废品处理
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public CommandResult Nullify(ProductInventoryItem sr)
        {
            CommandResult ret = new CommandResult(ResultCode.Fail, string.Empty);
            ProductInventoryItem newVal = sr.Clone();
            newVal.State = ProductInventoryState.Nullified;
            if (string.IsNullOrEmpty(newVal.Memo)) newVal.Memo = "废品处理";
            else newVal.Memo += ",废品处理";
            if (sr.Status != "整卷")
            {
                ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(newVal, sr);
            }
            else //整卷需要将对应的应付金额和应付税款删除
            {
                bool allSuccess = true;
                CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
                con.SheetID = sr.ID.ToString();
                var items = ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).GetItems(con).QueryObjects;
                if (items != null && items.Count > 0)
                {
                    var bll = new CustomerReceivableBLL(RepoUri);
                    foreach (var item in items)
                    {
                        var t = bll.Delete(item);
                        allSuccess = t.Result == ResultCode.Successful;
                        if (!allSuccess) break;
                    }
                }
                if (allSuccess) ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(newVal, sr);
                else ret = new CommandResult(ResultCode.Fail, "原材料卷对应的应付款或应付税款删除失败，请重试！");
            }
            if (ret.Result == ResultCode.Successful)
            {
                sr.State = newVal.State;
                sr.Memo = newVal.Memo;
            }
            return ret;
        }

        public CommandResult 设置结算单价(ProductInventoryItem pi, decimal price, string opt, string logID)
        {
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            var clone = pi.Clone();
            var ci = pi.GetCost(CostItem.入库单价);
            if (ci == null) return new CommandResult(ResultCode.Fail, "没有找到入库单价");
            var f = new CostItem() { Name = CostItem.结算单价, Price = price, WithTax = ci.WithTax, Prepay = ci.Prepay };
            clone.SetCost(f);
            AddOperationLog(pi.ID.ToString(), pi.DocumentType, "设置结算单价", unitWork, DateTime.Now, opt, logID, string.Format("将结算单价设置成{0},", price));
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, pi, unitWork);
            var ret = unitWork.Commit();
            if (ret.Result == ResultCode.Successful)
            {
                pi.Costs = clone.Costs;
            }
            return ret;
        }

        public CommandResult ChangeCost(ProductInventoryItem sr, List<CostItem> costs, string opt, string logID)
        {
            try
            {
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
                var clone = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetByID(sr.ID).QueryObject;
                string memo = string.Empty;
                foreach (var ci in costs)
                {
                    var oci = sr.GetCost(ci.Name);
                    memo += string.Format("{0}从{1}改成{2},", ci.Name, oci != null ? oci.Price : 0, ci.Price);
                    clone.SetCost(ci);
                }
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, sr, unitWork);
                AddOperationLog(sr.ID.ToString(), sr.DocumentType, "修改单价", unitWork, DateTime.Now, opt, logID, memo);
                if (!string.IsNullOrEmpty(sr.Supplier))
                {
                    var s = ProviderFactory.Create<IProvider<CompanyInfo, string>>(RepoUri).GetByID(sr.Supplier).QueryObject;
                    if (s != null)
                    {
                        var dt = DateTime.Now;
                        AddReceivables(clone, new DateTime(sr.AddDate.Year, sr.AddDate.Month, sr.AddDate.Day, dt.Hour, dt.Minute, dt.Second), unitWork);
                        if (clone.CalTax() > 0) AddTax(clone, new DateTime(sr.AddDate.Year, sr.AddDate.Month, sr.AddDate.Day, dt.Hour, dt.Minute, dt.Second), unitWork);
                        if (sr.CalTax() > 0 && clone.CalTax() == 0 && !DelTax(clone)) return new CommandResult(ResultCode.Fail, "删除应开增值税时出错，请重试");
                    }
                }
               var ret= unitWork.Commit();
               if (ret.Result == ResultCode.Successful)
               {
                   foreach (var ci in costs)
                   {
                       sr.SetCost(ci);
                   }
               }
               return ret;
            }
            catch (Exception ex)
            {
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }

        private void AddOperationLog(string id, string docType, string operation, IUnitWork unitWork, DateTime dt, string opt, string logID = null, string memo = null)
        {
            DocumentOperation doc = new DocumentOperation()
            {
                ID = Guid.NewGuid(),
                DocumentID = id,
                DocumentType = docType,
                OperatDate = dt,
                Operation = operation,
                Operator = opt,
                LogID = logID,
                Memo = memo
            };
            ProviderFactory.Create<IProvider<DocumentOperation, Guid>>(RepoUri).Insert(doc, unitWork);
        }
        #endregion
    }
}
