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
    public class SteelRollBLL
    {
        #region 构造函数
        public SteelRollBLL(string repoUri)
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
            decimal amount = sheet.CalTax ();
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

        private bool DelTax(ProductInventoryItem sheet)
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

        #region 公共方法
        public QueryResult<ProductInventoryItem> GetByID(Guid id)
        {
            return ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetByID(id);
        }

        public QueryResultList<ProductInventoryItem> GetItems(SearchCondition con)
        {
            if (con == null)
            {
                con = new ProductInventoryItemSearchCondition() { Model = MODEL, HasRemain = true };
            }
            else if (con is ProductInventoryItemSearchCondition)
            {
                (con as ProductInventoryItemSearchCondition).Model = MODEL;
                (con as ProductInventoryItemSearchCondition).HasRemain = true;
            }
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con);
            if (ret.QueryObjects != null) ret.QueryObjects = ret.QueryObjects.Where(it => it.Count != 0).ToList();
            return ret;
        }

        public CommandResult Add(ProductInventoryItem sr)
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

        public CommandResult Update(ProductInventoryItem sr)
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
        /// <summary>
        /// 更换库存的所属产品
        /// </summary>
        /// <param name="sr"></param>
        /// <returns></returns>
        public CommandResult UpdateProduct(ProductInventoryItem sr)
        {
            if (sr.Product.Weight == null && sr.Product.Model == MODEL)
            {
                var p = new ProductBLL(RepoUri).Create(sr.Product.CategoryID, sr.Product.Specification, sr.Product.Model, sr.Weight, sr.Length, sr.Product.Density, true);
                if (p != null)
                {
                    var clone = sr.Clone();
                    clone.ProductID = p.ID;
                    clone.Product = p;
                    var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, sr);
                    if (ret.Result == ResultCode.Successful)
                    {
                        sr.ProductID = p.ID;
                        sr.Product = p;
                    }
                    return ret;
                }
                else
                {
                    return new CommandResult(ResultCode.Fail, "创建产品信息失败");
                }
            }
            return new CommandResult(ResultCode.Successful, string.Empty);
        }

        /// <summary>
        /// 原材料加工
        /// </summary>
        /// <param name="sr"></param>
        /// <param name="slicedTo"></param>
        /// <param name="length"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public CommandResult Slice(ProductInventoryItem sr, SteelRollSliceRecord sliceSheet, WareHouse wh)
        {
            Product p = new ProductBLL(RepoUri).Create(sr.Product.CategoryID, sliceSheet.Specification, sliceSheet.SliceType, sliceSheet.Weight, sliceSheet.Length, sr.Product.Density);
            if (p == null) return new CommandResult(ResultCode.Fail, "创建相关产品信息失败");

            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);

            ProductInventoryItem newVal = sr.Clone();
            newVal.Weight = sliceSheet.AfterWeight;
            newVal.Length = sliceSheet.AfterLength;
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(newVal, sr, unitWork);

            ProviderFactory.Create<IProvider<SteelRollSliceRecord, Guid>>(RepoUri).Insert(sliceSheet, unitWork);

            ProductInventoryItem pi = new ProductInventoryItem()
            {
                ID = Guid.NewGuid(),
                ProductID = p.ID,
                AddDate = sliceSheet.SliceDate,
                InventorySheet = "加工入库",
                InventoryItem = sliceSheet.ID,
                OriginalWeight = sliceSheet.BeforeWeight - sliceSheet.AfterWeight,
                Weight = sliceSheet.BeforeWeight - sliceSheet.AfterWeight,
                OriginalThick = sr.OriginalThick,
                Count = sliceSheet.Count,
                Model = sliceSheet.SliceType,
                State = ProductInventoryState.Inventory,
                Unit = "件",
                WareHouseID = wh.ID,
                Customer = sliceSheet.Customer,
                SourceRoll = sr.ID,  //设置加工来源
                Memo = sliceSheet.Memo,
            };
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(pi, unitWork);
            CommandResult ret = unitWork.Commit();
            if (ret.Result == ResultCode.Successful)
            {
                sr.Weight = newVal.Weight;
                sr.Length = newVal.Length;
            }
            return ret;
        }

        public CommandResult UndoSlice(SteelRollSliceRecord sliceSheet)
        {
            ProductInventoryItemSearchCondition con1 = new ProductInventoryItemSearchCondition();
            con1.InventoryItem = sliceSheet.ID;
            List<ProductInventoryItem> pis = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con1).QueryObjects;
            if (pis != null && pis.Exists(it => it.State != ProductInventoryState.Inventory && it.State != ProductInventoryState.Reserved)) return new CommandResult(ResultCode.Fail, "加工的某些小件已经出货或待出货，不能撤回此次加工");

            SliceRecordSearchCondition con = new SliceRecordSearchCondition();
            con.SourceRoll = sliceSheet.SliceSource;
            List<SteelRollSliceRecord> records = ProviderFactory.Create<IProvider<SteelRollSliceRecord, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (!records.Exists(it => it.ID == sliceSheet.ID)) return new CommandResult(ResultCode.Fail, "没有找到要撤回的加工记录");

            ProductInventoryItem sr = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetByID(sliceSheet.SliceSource).QueryObject;
            if (sr == null) return new CommandResult(ResultCode.Fail, "没有找到相关的原材料卷");

            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            var clone = sr.Clone();
            clone.Weight += sliceSheet.BeforeWeight - sliceSheet.AfterWeight;
            if (clone.Weight == clone.OriginalWeight) clone.Length = clone.OriginalLength; //如果回到整件，则长度设置成入库长度
            else clone.Length = ProductInventoryItem.CalLength(clone.OriginalThick.Value, SpecificationHelper.GetWrittenWidth(clone.Product.Specification).Value, clone.Weight.Value, clone.Product.Density.Value);
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, sr, unitWork); //

            foreach (var pi in pis) //删除所有加工产生的小件库存
            {
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Delete(pi, unitWork);
            }

            ProviderFactory.Create<IProvider<SteelRollSliceRecord, Guid>>(RepoUri).Delete(sliceSheet, unitWork); //删除加工记录

            var sheets = records.Where(it => it.BeforeWeight < sliceSheet.BeforeWeight); //后续的加工记录也要修改加工前和加工后四个参数
            foreach (var sheet in sheets)
            {
                var cloneSheet = sheet.Clone();
                cloneSheet.BeforeWeight += sliceSheet.BeforeWeight - sliceSheet.AfterWeight;
                cloneSheet.BeforeLength = ProductInventoryItem.CalLength(clone.OriginalThick.Value, SpecificationHelper.GetWrittenWidth(clone.Product.Specification).Value, cloneSheet.BeforeWeight, clone.Product.Density.Value);
                cloneSheet.AfterWeight += sliceSheet.BeforeWeight - sliceSheet.AfterWeight;
                cloneSheet.AfterLength = ProductInventoryItem.CalLength(clone.OriginalThick.Value, SpecificationHelper.GetWrittenWidth(clone.Product.Specification).Value, cloneSheet.AfterWeight, clone.Product.Density.Value);
                ProviderFactory.Create<IProvider<SteelRollSliceRecord, Guid>>(RepoUri).Update(cloneSheet, sheet, unitWork);
            }
            return unitWork.Commit();
        }

        /// <summary>
        /// 计算实际厚度
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="realCount">为真表示按库存实际数量计算，为假表示按加工实际数量计算</param>
        /// <returns></returns>
        public CommandResult CalRealThick(ProductInventoryItem pi, bool realCount)
        {
            try
            {
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
                var provider = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri);
                decimal? thick = null;
                SliceRecordSearchCondition con = new SliceRecordSearchCondition();
                con.SourceRoll = pi.ID;
                var records = new SteelRollSliceRecordBLL(RepoUri).GetItems(con).QueryObjects;
                if (records != null && records.Count > 0 && records.TrueForAll(it => it.SliceType == "开平" || it.SliceType == "开卷"))
                {
                    decimal weight = records.Max(it => it.BeforeWeight); //获取第一次加工记录前的重量，这个重量即为这个卷加工前的重量
                    decimal len = 0;
                    ProductInventoryItemSearchCondition pcon = new ProductInventoryItemSearchCondition();
                    pcon.SourceRoll = pi.ID;
                    var items = provider.GetItems(pcon).QueryObjects;
                    if (realCount)
                    {
                        len = items.Sum(it => it.Product.Length.Value * it.Count); //长度，为所有库存中小件数量乘以其长度，这里不能以加工记录的数量为准，是因为小件会有盘点，所以数量以库存中的为准
                    }
                    else
                    {
                        len = records.Sum(it => it.Length.Value * it.Count);
                    }

                    thick = ProductInventoryItem.CalThick(SpecificationHelper.GetWrittenWidth(pi.Product.Specification).Value, weight, len, pi.Product.Density.Value);
                    if (thick.HasValue)
                    {
                        ProductInventoryItem clone = pi.Clone();
                        clone.RealThick = thick;
                        provider.Update(clone, pi, unitWork);

                        foreach (var slice in items)
                        {
                            var sliceClone = slice.Clone();
                            slice.RealThick = thick;
                            provider.Update(slice, sliceClone, unitWork);
                        }
                    }
                }
                var ret = unitWork.Commit();
                if (ret.Result == ResultCode.Successful) pi.RealThick = thick;
                return ret;
            }
            catch (Exception ex)
            {
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }
        /// <summary>
        /// 原材料盘点
        /// </summary>
        /// <returns></returns>
        public CommandResult Check(ProductInventoryItem sr, decimal newWeight, string memo, string checker, string operatorName)
        {
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            ProductInventoryItem newVal = sr.Clone();
            newVal.Weight = newWeight;
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(newVal, sr, unitWork);
            InventoryCheckRecord citem = new InventoryCheckRecord()
            {
                ID = Guid.NewGuid(),
                CheckDateTime = DateTime.Now,
                ProductID = sr.ProductID,
                WarehouseID = sr.WareHouseID,
                SourceID = sr.ID,
                BeforeWeight = sr.Weight,
                Weight = newWeight,
                Inventory = 1,
                CheckCount = 1,
                Unit = sr.Unit,
                Price = 0,
                Operator = operatorName,
                Customer = sr.Customer,
                Checker = checker,
                Memo = memo
            };
            ProviderFactory.Create<IProvider<InventoryCheckRecord, Guid>>(RepoUri).Insert(citem, unitWork);
            CommandResult ret = unitWork.Commit();
            if (ret.Result == ResultCode.Successful)
            {
                sr.Weight = newWeight;
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

        public List<string> GetAllMaterails()
        {
            return ProviderFactory.Create<IMaterialProvider>(RepoUri).GetItems();
        }

        public List<string> GetAllCarplates()
        {
            return ProviderFactory.Create<ICarplateProvider>(RepoUri).GetItems();
        }

        public CommandResult 拆卷(ProductInventoryItem sr, decimal weight, string memo, out ProductInventoryItem newR)
        {
            newR = null;
            if (sr.State != ProductInventoryState.Inventory) return new CommandResult(ResultCode.Fail, "只有处于在库状态的卷才能拆卷");
            if (sr.Weight <= weight) return new CommandResult(ResultCode.Fail, "拆卷的重量不能小于或等于原卷重量");
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            decimal? width = SpecificationHelper.GetWrittenWidth(sr.Product.Specification);
            decimal? thick = SpecificationHelper.GetWrittenThick(sr.Product.Specification);
            var clone = sr.Clone();
            clone.Weight -= weight;
            clone.Length = ProductInventoryItem.CalLength(thick.Value, width.Value, clone.Weight.Value, clone.Product.Density.Value);
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, sr, unitWork);
            newR = sr.Clone();
            newR.ID = Guid.NewGuid();
            newR.InventorySheet = "拆卷";
            newR.OriginalWeight = weight;
            newR.OriginalLength = ProductInventoryItem.CalLength(thick.Value, width.Value, weight, clone.Product.Density.Value);
            newR.Weight = weight;
            newR.Count = 1;
            newR.OriginalCount = 1;
            newR.Length = newR.OriginalLength;
            newR.SourceRoll = clone.ID;
            newR.Memo = memo;
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(newR, unitWork);
            var ret = unitWork.Commit();
            if (ret.Result == ResultCode.Successful)
            {
                sr.Weight = clone.Weight;
                sr.Length = clone.Length;
            }
            return ret;
        }

        public CommandResult 合卷(List<ProductInventoryItem> srs, out ProductInventoryItem newR)
        {
            newR = null;
            if (srs.Exists(it => it.ProductID != srs[0].ProductID)) return new CommandResult(ResultCode.Fail, "不是同一种规格的卷材不能合并");
            if (srs.Exists(it => it.State != ProductInventoryState.Inventory)) return new CommandResult(ResultCode.Fail, "只有在库的卷才能合并");
            if (srs.Exists(it => it.OriginalWeight != it.Weight)) return new CommandResult(ResultCode.Fail, "只有整卷卷材才能合并");
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            newR = srs[0].Clone();
            newR.ID = Guid.NewGuid();
            newR.ProductID = srs[0].ProductID;
            newR.Product = srs[0].Product;
            newR.WareHouseID = srs[0].WareHouseID;
            newR.AddDate = DateTime.Today;
            newR.InventorySheet = "合卷";
            newR.OriginalCount = 1;
            newR.OriginalWeight = 0;
            newR.Count = 1;
            newR.Weight = 0;
            newR.Memo = "合并卷";
            foreach (var sr in srs)
            {
                var clone = sr.Clone();
                clone.Weight = 0;
                clone.Length = 0;
                clone.SourceID = newR.ID;
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, sr, unitWork);
                newR.OriginalWeight += sr.Weight;
                newR.Weight += sr.Weight;
            }
            decimal? width = SpecificationHelper.GetWrittenWidth(newR.Product.Specification);
            decimal? thick = SpecificationHelper.GetWrittenThick(newR.Product.Specification);
            newR.OriginalLength = ProductInventoryItem.CalLength(thick.Value, width.Value, newR.OriginalWeight.Value, newR.Product.Density.Value);
            newR.Length = newR.OriginalLength;
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(newR, unitWork);
            var ret = unitWork.Commit();
            if (ret.Result == ResultCode.Successful)
            {
                srs.ForEach(it =>
                    {
                        it.Weight = 0;
                        it.Length = 0;
                    });
            }
            return ret;
        }
        #endregion
    }
}
