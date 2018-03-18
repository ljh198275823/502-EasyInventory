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
    public class SteelRollBLL : ProductInventoryItemBLL
    {
        #region 构造函数
        public SteelRollBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        private static string MODEL = ProductModel.原材料;

        #region 公共方法
        public override QueryResultList<ProductInventoryItem> GetItems(SearchCondition con)
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

        /// <summary>
        /// 更换库存的所属产品
        /// </summary>
        /// <param name="sr"></param>
        /// <returns></returns>
        public CommandResult UpdateProduct(ProductInventoryItem sr)
        {
            if (sr.Product.Weight == null && sr.Product.Model == MODEL)
            {
                var p = new ProductBLL(RepoUri).Create(sr.Product.Name, sr.Product.CategoryID, sr.Product.Specification, sr.Product.Model, sr.Weight, sr.Length, true);
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
            Product p = new ProductBLL(RepoUri).Create(sr.Product.Name, sr.Product.CategoryID, sr.Product .Specification , sliceSheet.SliceType, sliceSheet.Weight, sliceSheet.Length);
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
                //Original克重 = sr.Original克重,
                Count = sliceSheet.Count,
                Model = sliceSheet.SliceType,
                State = ProductInventoryState.Inventory,
                Unit = "张",
                WareHouseID = wh.ID,
                Customer = sliceSheet.Customer,
                Supplier = sr.Supplier,
                Manufacture = sr.Manufacture,
                Material = sr.Material,
                SourceRoll = sr.ID,  //设置加工来源
                CostID = sr.CostID.HasValue ? sr.CostID.Value : sr.ID, //带上成本参数,如果原材料还没有设置成本，默认原材料的成本ID是其ID
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
            if (pis != null && pis.Exists(it => it.Model == ProductModel.原材料 && it.Status != "整卷")) return new CommandResult(ResultCode.Fail, "部分开条后的卷已经加工，不能撤销此次加工");

            SliceRecordSearchCondition con = new SliceRecordSearchCondition();
            con.SourceRoll = sliceSheet.SliceSource;
            List<SteelRollSliceRecord> records = ProviderFactory.Create<IProvider<SteelRollSliceRecord, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (!records.Exists(it => it.ID == sliceSheet.ID)) return new CommandResult(ResultCode.Fail, "没有找到要撤回的加工记录");

            ProductInventoryItem sr = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetByID(sliceSheet.SliceSource).QueryObject;
            if (sr == null) return new CommandResult(ResultCode.Fail, "没有找到相关的原材料卷");

            var width = SpecificationHelper.GetWrittenWidth(sr.Product.Specification);
            var 克重 = SpecificationHelper.GetWritten克重(sr.Product.Specification);

            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            var clone = sr.Clone();
            clone.Weight += sliceSheet.BeforeWeight - sliceSheet.AfterWeight;
            if (clone.Weight == clone.OriginalWeight) clone.Length = clone.OriginalLength; //如果回到整件，则长度设置成入库长度
            else clone.Length = ProductInventoryItem.CalLength(克重.Value, width.Value, clone.Weight.Value);
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
                cloneSheet.BeforeLength = ProductInventoryItem.CalLength(克重.Value, width.Value, cloneSheet.BeforeWeight);
                cloneSheet.AfterWeight += sliceSheet.BeforeWeight - sliceSheet.AfterWeight;
                cloneSheet.AfterLength = ProductInventoryItem.CalLength(克重.Value, width.Value, cloneSheet.AfterWeight);
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
                if (records != null && records.Count > 0 && records.TrueForAll(it => it.SliceType == ProductModel.开平 || it.SliceType == ProductModel.开卷))
                {
                    decimal weight = records.Max(it => it.BeforeWeight); //获取第一次加工记录前的重量，这个重量即为这个卷加工前的重量
                    decimal len = 0;
                    ProductInventoryItemSearchCondition pcon = new ProductInventoryItemSearchCondition();
                    pcon.SourceRoll = pi.ID;
                    var items = provider.GetItems(pcon).QueryObjects;
                    if (realCount) //以库存实际数量为准，包括盘点的数量
                    {
                        len = items.Sum(it => it.Product.Length.Value * it.Count); //长度，为所有库存中小件数量乘以其长度，这里不能以加工记录的数量为准，是因为小件会有盘点，所以数量以库存中的为准
                    }
                    else //以加工单数量为准
                    {
                        len = records.Sum(it => it.Length.Value * it.Count);
                    }

                    thick = ProductInventoryItem.Cal平方克重(SpecificationHelper.GetWrittenWidth(pi.Product.Specification).Value, weight, len / 1000);
                    if (thick.HasValue)
                    {
                        ProductInventoryItem clone = pi.Clone();
                        clone.Real克重 = thick;
                        provider.Update(clone, pi, unitWork);

                        foreach (var slice in items)
                        {
                            var sliceClone = slice.Clone();
                            slice.Real克重 = thick;
                            provider.Update(slice, sliceClone, unitWork);
                        }
                    }
                }
                var ret = unitWork.Commit();
                if (ret.Result == ResultCode.Successful) pi.Real克重 = thick;
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

        public CommandResult 拆卷(ProductInventoryItem sr, decimal weight, string memo, out ProductInventoryItem newR)
        {
            newR = null;
            if (sr.State != ProductInventoryState.Inventory) return new CommandResult(ResultCode.Fail, "只有处于在库状态的卷才能拆卷");
            if (sr.Weight <= weight) return new CommandResult(ResultCode.Fail, "拆卷的重量不能小于或等于原卷重量");
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            decimal? width = SpecificationHelper.GetWrittenWidth(sr.Product.Specification);
            decimal? thick = SpecificationHelper.GetWritten克重(sr.Product.Specification);
            var clone = sr.Clone();
            clone.Weight -= weight;
            clone.Length = ProductInventoryItem.CalLength(thick.Value, width.Value, clone.Weight.Value);
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, sr, unitWork);
            newR = sr.Clone();
            newR.ID = Guid.NewGuid();
            newR.InventorySheet = "拆卷";
            newR.OriginalWeight = weight;
            newR.OriginalLength = ProductInventoryItem.CalLength(thick.Value, width.Value, weight);
            newR.Weight = weight;
            newR.Count = 1;
            newR.OriginalCount = 1;
            newR.Length = newR.OriginalLength;
            newR.SourceRoll = clone.ID;
            newR.CostID = clone.CostID.HasValue ? clone.CostID.Value : clone.ID;
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

        public CommandResult 原材料拆条(ProductInventoryItem sr, List<int> items, string formula, out List<ProductInventoryItem> newRolls)
        {
            newRolls = null;
            if (items == null || items.Count == 0) return new CommandResult(ResultCode.Fail, "没有指定分条规格");
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            var sum = items.Sum();
            var weight = sr.Weight;

            SteelRollSliceRecord record = new SteelRollSliceRecord()
            {
                ID = Guid.NewGuid(),
                SliceDate = DateTime.Now,
                SliceSource = sr.ID,
                SourceRollWeight = sr.OriginalWeight,
                ProductID = sr.ProductID,
                SliceType = "开条",
                BeforeWeight = sr.Weight.Value,
                BeforeLength = ProductInventoryItem.CalLength(SpecificationHelper.GetWritten克重(sr.Product.Specification).Value, SpecificationHelper.GetWrittenWidth(sr.Product.Specification).Value, sr.Weight.Value),
                Customer = sr.Customer,
                Slicer = string.Empty,
                Warehouse = string.Empty,
                Operator = Operator.Current.Name,
                AfterLength = 0,
                AfterWeight = 0,
                Count = items.Count,
                Memo = "开条:" + string.Format("{0}", formula),
            };
            ProviderFactory.Create<IProvider<SteelRollSliceRecord, Guid>>(RepoUri).Insert(record, unitWork);

            foreach (var it in items)
            {
                var newR = sr.Clone();
                newR.ID = Guid.NewGuid();
                newR.SourceRoll = sr.ID;
                string sp = string.Format("{0}*{1}", SpecificationHelper.GetWritten克重(sr.Product.Specification), it);
                Product p = new ProductBLL(AppSettings.Current.ConnStr).Create(sr.Product.Name, sr.Product.CategoryID, sp, "原材料");
                if (p == null) throw new Exception("创建相关产品信息失败");
                newR.Product = p;
                newR.ProductID = p.ID;
                newR.Model = p.Model;
                newR.OriginalLength = sr.Length;
                newR.Length = sr.Length;
                newR.OriginalWeight = weight * it / sum;
                newR.Weight = weight * it / sum;
                newR.CostID = sr.CostID.HasValue ? sr.CostID.Value : sr.ID;
                newR.InventoryItem = record.ID;
                newR.Memo = "分条";
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(newR, unitWork);
                if (newRolls == null) newRolls = new List<ProductInventoryItem>();
                newRolls.Add(newR);
            }

            var clone = sr.Clone();
            clone.Weight = 0;
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, sr, unitWork);

            var ret = unitWork.Commit();
            if (ret.Result == ResultCode.Successful)
            {
                sr.Weight = 0;
                sr.Length = 0;
            }
            else
            {
                newRolls = null;
            }
            return ret;
        }

        /// <summary>
        /// 废品处理
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override CommandResult Nullify(ProductInventoryItem sr)
        {
            CommandResult ret = new CommandResult(ResultCode.Fail, string.Empty);
            ProductInventoryItem newVal = sr.Clone();
            newVal.State = ProductInventoryState.Nullified;
            if (string.IsNullOrEmpty(newVal.Memo)) newVal.Memo = "废品处理";
            else newVal.Memo += ",废品处理";
            if (sr.Model == ProductModel.原材料 && sr.Status != "整卷")
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
        #endregion
    }
}
