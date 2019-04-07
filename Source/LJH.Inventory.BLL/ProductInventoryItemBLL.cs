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
        protected virtual void SaveReceivable(ProductInventoryItem sheet, CostItem ci, DateTime? dt, string memo, IUnitWork unitWork, decimal? 总额 = null, string carPlate = null)
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
                    var temp = it.GetProperty(_成本类型);
                    if (temp == CostItem.结算单价 && ci.Name == CostItem.入库单价) return; //如果已经设置了结算成本了，再设置入库成本的时候不再改变应收
                    if (temp == ci.Name)
                    {
                        original = it;
                        break;
                    }
                    else if ((string.IsNullOrEmpty(temp) || temp == CostItem.入库单价 || temp == CostItem.结算单价) &&
                             (ci.Name == CostItem.入库单价 || ci.Name == CostItem.结算单价))     //由于之前的应付款没有指定成本类型，所以这个字段为空时，指的是入库单价产生的应收
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
            if (!string.IsNullOrEmpty(memo)) cr.Memo = memo;
            cr.SetProperty(_成本类型, ci.Name);
            cr.SetProperty("规格", sheet.Product.Specification);
            cr.SetProperty("入库单价", ci.Price.ToString("F2"));
            cr.SetProperty("重量", sheet.OriginalWeight.HasValue ? sheet.OriginalWeight.Value.ToString("F3") : null);
            cr.SetProperty("费用类别", ci.Name);
            if (!string.IsNullOrEmpty(sheet.Customer)) cr.SetProperty("购货单位", sheet.Customer);
            if (!string.IsNullOrEmpty(carPlate)) cr.SetProperty("车皮号", carPlate);
            decimal amount = 总额.HasValue ? 总额.Value : sheet.CalReceivable(ci);
            if (original != null && original.Haspaid > amount) new AccountRecordAssignBLL(RepoUri).UndoAssign(cr, cr.Haspaid - amount);  //这里用cr,如果用original后面更新的时候会更新不到
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

        protected virtual void SaveTax(ProductInventoryItem sheet, CostItem ci, DateTime? dt, string memo, IUnitWork unitWork, decimal? 总额 = null, string carPlate = null)
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
                    var temp = it.GetProperty(_成本类型);
                    if (temp == CostItem.结算单价 && ci.Name == CostItem.入库单价) return; //如果已经设置了结算成本了，再设置入库成本的时候不再改变应收
                    if (temp == ci.Name)
                    {
                        original = it;
                        break;
                    }
                    else if ((string.IsNullOrEmpty(temp) || temp == CostItem.入库单价 || temp == CostItem.结算单价) &&
                             (ci.Name == CostItem.入库单价 || ci.Name == CostItem.结算单价))     //由于之前的应付款没有指定成本类型，所以这个字段为空时，指的是入库单价产生的应收
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
            if (!string.IsNullOrEmpty(memo)) cr.Memo = memo;
            cr.SetProperty(_成本类型, ci.Name);
            cr.SetProperty("规格", sheet.Product.Specification);
            cr.SetProperty("入库单价", ci.Price.ToString("F2"));
            cr.SetProperty("重量", sheet.OriginalWeight.HasValue ? sheet.OriginalWeight.Value.ToString("F3") : null);
            if (!string.IsNullOrEmpty(sheet.Customer)) cr.SetProperty("购货单位", sheet.Customer);
            if (!string.IsNullOrEmpty(carPlate)) cr.SetProperty("车皮号", carPlate);
            decimal amount = 0;
            if (ci.WithTax) amount = 总额.HasValue ? 总额.Value : sheet.CalTax(ci);
            if (original != null && original.Haspaid > amount) new AccountRecordAssignBLL(RepoUri).UndoAssign(cr, cr.Haspaid - amount); //这里用cr,如果用original后面更新的时候会更新不到
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

        public CommandResult UpdatePurchaseID(ProductInventoryItem pi, string purchaseID)
        {
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            var clone = pi.Clone();
            clone.PurchaseID = purchaseID;
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, pi, unitWork);
            var con = new ProductInventoryItemSearchCondition() { SourceRoll = pi.CostID.HasValue ? pi.CostID : pi.ID };
            var pis = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con).QueryObjects;
            foreach (var item in pis)
            {
                if (item.ID == pi.ID) continue;
                var itemClone = item.Clone();
                itemClone.PurchaseID = purchaseID;
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(itemClone, item, unitWork);
            }

            con = new ProductInventoryItemSearchCondition() { SourceID = pi.CostID.HasValue ? pi.CostID : pi.ID };
            pis = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con).QueryObjects;
            foreach (var item in pis)
            {
                if (item.ID == pi.ID) continue;
                var itemClone = item.Clone();
                itemClone.PurchaseID = purchaseID;
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(itemClone, item, unitWork);
            }

            var rcon = new CustomerReceivableSearchCondition() { SheetID = (pi.CostID.HasValue ? pi.CostID.Value : pi.ID).ToString() };
            var crs = ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).GetItems(rcon).QueryObjects;
            foreach (var item in crs)
            {
                var crClone = item.Clone();
                crClone.OrderID = purchaseID;
                ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Update(crClone, item, unitWork);
            }
            var ret = unitWork.Commit();
            if (ret.Result == ResultCode.Successful) pi.Position = purchaseID;
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

        public CommandResult 设置成本(ProductInventoryItem info, CostItem ci, string opt, string logID, string 备注, decimal? 总额 = null, string carPlate = null)
        {
            try
            {
                ProductInventoryItem pi = null;
                if (info.CostID.HasValue) pi = GetByID(info.CostID.Value).QueryObject; //成本ID一般是对应的入库项的ID
                if (pi == null) return new CommandResult(ResultCode.Fail, "没有找到入库项，设置成本失败");
                if (ci.Name == CostItem.入库单价 || ci.Name == CostItem.结算单价)
                {
                    if (string.IsNullOrEmpty(ci.SupllierID)) ci.SupllierID = pi.Supplier;
                }
                ci.Operator = opt;

                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
                var clone = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetByID(pi.ID).QueryObject;
                if (总额.HasValue)
                {
                    if (pi.OriginalWeight > 0) ci.Price = Math.Round(ci.Price / pi.OriginalWeight.Value, 2); //如果是总额，则换算成吨价
                    else if (pi.OriginalCount > 0) ci.Price = Math.Round(ci.Price / pi.OriginalCount.Value, 2); //如果是总额，则换算成单个数量的价格
                }
                string memo = string.Empty;
                var oci = pi.GetCost(ci.Name);
                var s = (!string.IsNullOrEmpty(ci.SupllierID)) ? new CompanyBLL(RepoUri).GetByID(ci.SupllierID).QueryObject : null;
                memo += string.Format("{0}从{1}改成{2}, 供应商:{3}", ci.Name, oci != null ? oci.Price : 0, ci.Price, s != null ? s.Name : string.Empty);
                clone.SetCost(ci);
                if (ci.Name == CostItem.结算单价 && clone.Supplier != ci.SupllierID)  //2017-11-28 修改入库单价时，如果同时修改了
                {
                    clone.Supplier = ci.SupllierID;
                    var pcon = new ProductInventoryItemSearchCondition() { CostID = clone.CostID };
                    var pis = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(pcon).QueryObjects;
                    if (pis != null && pis.Count > 0)
                    {
                        foreach (var fpi in pis)
                        {
                            if (fpi.ID != pi.ID)
                            {
                                var fpiClone = fpi.Clone();
                                fpiClone.Supplier = ci.SupllierID;
                                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(fpiClone, fpi, unitWork);
                            }
                        }
                    }
                }
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, pi, unitWork);

                AddOperationLog(pi.ID.ToString(), pi.DocumentType, ci.Name == CostItem.结算单价 ? "设置结算单价" : "修改成本", unitWork, DateTime.Now, opt, logID, memo);
                if (!string.IsNullOrEmpty(ci.SupllierID) && pi.SourceID == null && pi.SourceRoll == null)
                {
                    if (s != null)
                    {
                        var dt = (ci.Name == CostItem.入库单价 || ci.Name == CostItem.结算单价) ? new DateTime(pi.AddDate.Year, pi.AddDate.Month, pi.AddDate.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) : DateTime.Now;
                        SaveReceivable(clone, ci, dt, 备注, unitWork, 总额, carPlate);
                        SaveTax(clone, ci, dt, 备注, unitWork, 总额, carPlate);
                    }
                }
                var ret = unitWork.Commit();
                if (ret.Result == ResultCode.Successful)
                {
                    info.SetCost(ci);
                    info.Supplier = clone.Supplier;
                }
                return ret;
            }
            catch (Exception ex)
            {
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }

        public CommandResult 设置其它成本(List<ProductInventoryItem> items, CostItem ci, string opt, string logID, string 备注, decimal? 总额 = null, string carPlate = null)
        {
            try
            {
                ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition() { IDS = items.Select(it => it.CostID.Value).Distinct().ToList() }; //获取原始入库项
                var pis = GetItems(con).QueryObjects;
                var s = new CompanyBLL(RepoUri).GetByID(ci.SupllierID).QueryObject;
                ci.Operator = opt;
                var amount = pis.Sum(it => it.OriginalWeight.HasValue ? it.OriginalWeight.Value : it.OriginalCount.Value);
                if (总额.HasValue && amount > 0) ci.Price = Math.Round(总额.Value / amount, 2);    //如果是总额，则换算成单个数量的价格
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
                foreach (var pi in pis)
                {
                    var clone = pi.Clone();
                    string memo = string.Empty;
                    var oci = pi.GetCost(ci.Name);
                    memo += string.Format("{0}从{1}改成{2}, 供应商：{3}", ci.Name, oci != null ? oci.Price : 0, ci.Price, s != null ? s.Name : string.Empty);
                    clone.SetCost(ci);
                    ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, pi, unitWork);
                    AddOperationLog(pi.ID.ToString(), pi.DocumentType, "修改成本", unitWork, DateTime.Now, opt, logID, memo);
                    if (总额 == null && s != null && pi.SourceID == null && pi.SourceRoll == null)
                    {
                        var dt = DateTime.Now;
                        SaveReceivable(clone, ci, dt, 备注, unitWork, 总额, carPlate);
                        SaveTax(clone, ci, dt, 备注, unitWork, 总额, carPlate);
                    }
                }
                var ret = unitWork.Commit();
                if (ret.Result == ResultCode.Successful)
                {
                    items.ForEach(it => it.SetCost(ci));
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
