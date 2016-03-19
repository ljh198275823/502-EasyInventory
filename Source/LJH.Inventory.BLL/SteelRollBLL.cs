﻿using System;
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
            decimal amount = 0;
            if (sheet.PurchasePrice.HasValue) amount += sheet.OriginalWeight.Value * sheet.PurchasePrice.Value;
            if (sheet.TransCost.HasValue && sheet.TransCostPrepay.HasValue && sheet.TransCostPrepay.Value) amount += sheet.TransCost.Value * sheet.OriginalWeight.Value;
            if (sheet.OtherCost.HasValue && sheet.OtherCostPrepay.HasValue && sheet.OtherCostPrepay.Value) amount += sheet.OtherCost.Value * sheet.OriginalWeight.Value;
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
            decimal amount = 0;
            if (sheet.PurchasePrice.HasValue) amount += sheet.OriginalWeight.Value * sheet.PurchasePrice.Value;
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
        public QueryResult<ProductInventoryItem> GetByID(Guid id)
        {
            return ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetByID(id);
        }

        public QueryResultList<ProductInventoryItem> GetItems(SearchCondition con)
        {
            if (con == null)
            {
                con = new ProductInventoryItemSearchCondition() { Model = MODEL };
            }
            else if (con is ProductInventoryItemSearchCondition)
            {
                (con as ProductInventoryItemSearchCondition).Model = MODEL;
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
                        AddReceivables(sr, sr.AddDate, unitWork);
                        if (sr.WithTax.HasValue && sr.WithTax.Value) AddTax(sr, sr.AddDate, unitWork);
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
                    var s = ProviderFactory.Create<IProvider<CompanyInfo, string>>(RepoUri).GetByID(sr.Supplier).QueryObject;
                    if (s != null)
                    {
                        AddReceivables(sr, sr.AddDate, unitWork);
                        if (sr.WithTax.HasValue && sr.WithTax.Value) AddTax(sr, sr.AddDate, unitWork);
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

        public CommandResult CalRealThick(ProductInventoryItem pi)
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

                    ProductInventoryItemSearchCondition pcon = new ProductInventoryItemSearchCondition();
                    pcon.SourceRoll = pi.ID;
                    var items = provider.GetItems(pcon).QueryObjects;
                    decimal len = items.Sum(it => it.Product.Length.Value * it.Count); //长度，为所有库存中小件数量乘以其长度，这里不能以加工记录的数量为准，是因为小件会有盘点，所以数量以库存中的为准

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
            ProductInventoryItem newVal = sr.Clone();
            newVal.State = ProductInventoryState.Nullified;
            if (string.IsNullOrEmpty(newVal.Memo))
            {
                newVal.Memo = "废品处理";
            }
            else
            {
                newVal.Memo += ",废品处理";
            }
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(newVal, sr);
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
