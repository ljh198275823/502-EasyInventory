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

        private readonly string _成本类型 = "成本类型";

        #region 保护方法
        protected virtual void SaveReceivable(ProductInventoryItem sheet, CostItem ci, DateTime? dt, IUnitWork unitWork)
        {
            CustomerReceivable cr = null;
            CustomerReceivable original = null;
            CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
            con.SheetID = sheet.ID.ToString();
            con.ReceivableTypes = new List<CustomerReceivableType>() { CustomerReceivableType.SupplierReceivable };
            var items = ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                foreach (var it in items)
                {
                    var temp = it.GetProperty("_成本类型");
                    if (temp == ci.Name || (string.IsNullOrEmpty(temp) && ci.Name == CostItem.入库单价)) //由于之前的应付款没有指定成本类型，所以这个字段为空时，指的是入库单价产生的应收
                    {
                        original = it;
                        break;
                    }
                }
            }
            if (original == null)
            {
                cr = new CustomerReceivable();
                cr.ID = Guid.NewGuid();
                cr.CreateDate = dt != null ? dt.Value : DateTime.Now;
                cr.ClassID = CustomerReceivableType.SupplierReceivable;
                cr.SheetID = sheet.ID.ToString();
            }
            else
            {
                cr = original.Clone();
            }
            cr.CustomerID = ci.SupllierID;
            cr.OrderID = sheet.PurchaseID;
            cr.SetProperty(_成本类型, ci.Name);
            cr.SetProperty("规格", sheet.Product.Specification);
            cr.SetProperty("重量", sheet.OriginalWeight.HasValue ? sheet.OriginalWeight.Value.ToString("F3") : null);
            if (ci.Name == CostItem.入库单价) cr.SetProperty("入库单价", sheet.GetCost(CostItem.入库单价) != null ? sheet.GetCost(CostItem.入库单价).Price.ToString("F2") : null);
            decimal amount = sheet.CalReceivable(ci);
            if (original != null && original.Haspaid > amount) throw new Exception("原材料应收已核销的金额超过当前总价，请先取消部分核销金额再保存");
            cr.Amount = amount;
            if (original == null)
            {
                if (cr.Amount > 0) ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Insert(cr, unitWork);
            }
            else
            {
                if (cr.Amount > 0) ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Update(cr, original, unitWork);
                else new CustomerReceivableBLL(RepoUri).Delete(original); //如果之前有应收，但现在没有应收，则删除之前的应收
            }
        }

        protected virtual void SaveTax(ProductInventoryItem sheet, CostItem ci, DateTime? dt, IUnitWork unitWork)
        {
            CustomerReceivable cr = null;
            CustomerReceivable original = null;
            CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
            con.SheetID = sheet.ID.ToString();
            con.ReceivableTypes = new List<CustomerReceivableType>() { CustomerReceivableType.SupplierTax };
            var items = ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                foreach (var it in items)
                {
                    var temp = it.GetProperty("_成本类型");
                    if (temp == ci.Name || (string.IsNullOrEmpty(temp) && ci.Name == CostItem.入库单价)) //由于之前的应付款没有指定成本类型，所以这个字段为空时，指的是入库单价产生的应收
                    {
                        original = it;
                        break;
                    }
                }
            }
            if (original == null)
            {
                cr = new CustomerReceivable();
                cr.ID = Guid.NewGuid();
                cr.CreateDate = dt != null ? dt.Value : DateTime.Now;
                cr.ClassID = CustomerReceivableType.SupplierTax;
                cr.SheetID = sheet.ID.ToString();
            }
            else
            {
                cr = original.Clone();
            }
            cr.CustomerID = ci.SupllierID;
            cr.OrderID = sheet.PurchaseID;
            cr.SetProperty(_成本类型, ci.Name);
            cr.SetProperty("规格", sheet.Product.Specification);
            cr.SetProperty("重量", sheet.OriginalWeight.HasValue ? sheet.OriginalWeight.Value.ToString("F3") : null);
            if (ci.Name == CostItem.入库单价) cr.SetProperty("入库单价", sheet.GetCost(CostItem.入库单价) != null ? sheet.GetCost(CostItem.入库单价).Price.ToString("F2") : null);
            decimal amount = sheet.CalTax(ci);
            if (original != null && original.Haspaid > amount) throw new Exception("原材料应收已核销的金额超过当前总价，请先取消部分核销金额再保存");
            cr.Amount = amount;
            if (original == null)
            {
                if (cr.Amount > 0) ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Insert(cr, unitWork);
            }
            else
            {
                if (cr.Amount > 0) ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Update(cr, original, unitWork);
                else new CustomerReceivableBLL(RepoUri).Delete(original); //如果之前有应收，但现在没有应收，则删除之前的应收
            }
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
                    var ci = sr.GetCost(CostItem.入库单价);
                    ci.SupllierID = sr.Supplier;  //入库的时候可能没有保存，所以这里加一个保证保存
                    sr.SetCost(ci);
                    var s = ProviderFactory.Create<IProvider<CompanyInfo, string>>(RepoUri).GetByID(sr.Supplier).QueryObject;
                    if (s != null && ci != null)
                    {
                        var dt = DateTime.Now;
                        SaveReceivable(sr, ci, new DateTime(sr.AddDate.Year, sr.AddDate.Month, sr.AddDate.Day, dt.Hour, dt.Minute, dt.Second), unitWork);
                        SaveTax(sr, ci, new DateTime(sr.AddDate.Year, sr.AddDate.Month, sr.AddDate.Day, dt.Hour, dt.Minute, dt.Second), unitWork);
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
                if (!string.IsNullOrEmpty(sr.Supplier) && sr.SourceID == null && sr.SourceRoll == null) //新建入库的才要计算应收
                {
                    var ci = sr.GetCost(CostItem.入库单价);
                    ci.SupllierID = sr.Supplier;  //入库的时候可能没有保存，所以这里加一个保证保存
                    sr.SetCost(ci);
                    var s = ProviderFactory.Create<IProvider<CompanyInfo, string>>(RepoUri).GetByID(sr.Supplier).QueryObject;
                    if (s != null && ci != null)
                    {
                        DateTime dt = DateTime.Now;
                        SaveReceivable(sr, ci, new DateTime(sr.AddDate.Year, sr.AddDate.Month, sr.AddDate.Day, dt.Hour, dt.Minute, dt.Second), unitWork);
                        SaveTax(sr, ci, new DateTime(sr.AddDate.Year, sr.AddDate.Month, sr.AddDate.Day, dt.Hour, dt.Minute, dt.Second), unitWork);
                    }
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

        public CommandResult UpdatePosition(ProductInventoryItem pi, string position)
        {
            var clone = pi.Clone();
            clone.Position = position;
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, pi);
            if (ret.Result == ResultCode.Successful) pi.Position = position;
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
        public virtual CommandResult Nullify(ProductInventoryItem sr)
        {
            CommandResult ret = new CommandResult(ResultCode.Fail, string.Empty);
            if (sr.SourceID != null && sr.SourceRoll != null) return new CommandResult(ResultCode.Fail, "不是入库的库存项不能作废，可能通过盘点将库存取消");
            var pcon = new ProductInventoryItemSearchCondition();
            pcon.SourceID = sr.ID;
            var pis = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(pcon).QueryObjects;
            if (pis != null && pis.Count > 0) return new CommandResult(ResultCode.Fail, "库存项已经出货或进行过拆分，不能作废");
            ProductInventoryItem newVal = sr.Clone();
            newVal.State = ProductInventoryState.Nullified;
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
            else ret = new CommandResult(ResultCode.Fail, "库存项对应的应付款或应付税款删除失败，请重试！");
            if (ret.Result == ResultCode.Successful)
            {
                sr.State = newVal.State;
                sr.Memo = newVal.Memo;
            }
            return ret;
        }

        public CommandResult 设置成本(ProductInventoryItem info, CostItem ci, string opt, string logID)
        {
            try
            {
                ProductInventoryItem pi = null;
                if (info.CostID.HasValue) pi = GetByID(info.CostID.Value).QueryObject; //成本ID一般是对应的入库项的ID
                if (pi == null) return new CommandResult(ResultCode.Fail, "没有找到入库项，设置成本失败");

                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
                var clone = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetByID(pi.ID).QueryObject;
                string memo = string.Empty;
                var oci = pi.GetCost(ci.Name);
                memo += string.Format("{0}从{1}改成{2},", ci.Name, oci != null ? oci.Price : 0, ci.Price);
                clone.SetCost(ci);
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, pi, unitWork);
                AddOperationLog(pi.ID.ToString(), pi.DocumentType, "修改单价", unitWork, DateTime.Now, opt, logID, memo);

                if (!string.IsNullOrEmpty(ci.SupllierID) && pi.SourceID == null && pi.SourceRoll == null)
                {
                    var s = ProviderFactory.Create<IProvider<CompanyInfo, string>>(RepoUri).GetByID(ci.SupllierID).QueryObject;
                    if (s != null)
                    {
                        var dt = ci.Name == CostItem.入库单价 ? new DateTime(pi.AddDate.Year, pi.AddDate.Month, pi.AddDate.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) : DateTime.Now;
                        SaveReceivable(clone, ci, dt, unitWork);
                        SaveTax(clone, ci, dt, unitWork);
                    }
                }
                var ret = unitWork.Commit();
                if (ret.Result == ResultCode.Successful) info.SetCost(ci);
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
