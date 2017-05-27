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
    public class StackOutSheetBLL : SheetProcessorBase<StackOutSheet>
    {
        #region 构造函数
        public StackOutSheetBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 私有方法
        private void AddReceivables(StackOutSheet sheet, DateTime dt, IUnitWork unitWork)
        {
            CustomerReceivable cr = new CustomerReceivable()
            {
                ID = Guid.NewGuid(),
                CreateDate = dt,
                ClassID = CustomerReceivableType.CustomerReceivable,
                CustomerID = sheet.CustomerID,
                SheetID = sheet.ID,
                Amount = sheet.Amount,
            };
            ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Insert(cr, unitWork);
        }

        private void AddTax(StackOutSheet sheet, DateTime dt, IUnitWork unitWork)
        {
            CustomerReceivable tax = new CustomerReceivable()
            {
                ID = Guid.NewGuid(),
                CreateDate = dt,
                ClassID = CustomerReceivableType.CustomerTax,
                CustomerID = sheet.CustomerID,
                SheetID = sheet.ID,
                Amount = sheet.Amount,
            };
            ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Insert(tax, unitWork);
        }

        //分配, 为某个送货单项分配指定数量的库存
        private void F_Assign(ProductInventoryItem source, StackOutItem si, List<ProductInventoryItem> addingItems, List<ProductInventoryItem> updatingitems, List<ProductInventoryItem> cloneItems, List<ProductInventoryItem> deletingItems)
        {
            if (source.Count < si.Count) throw new Exception("出货数量超出库存数量");
            if (!updatingitems.Exists(it => it.ID == source.ID))
            {
                updatingitems.Add(source);
                cloneItems.Add(source.Clone());
            }
            decimal? uw = source.UnitWeight;
            source.Count -= si.Count;
            if (uw != null) source.Weight = source.Count * uw;

            ProductInventoryItem newItem = source.Clone();
            newItem.ID = Guid.NewGuid();
            newItem.SourceID = source.ID;
            newItem.Count = si.Count;
            if (uw != null)
            {
                newItem.OriginalWeight = newItem.Count * uw;
                newItem.Weight = newItem.Count * uw;
            }
            newItem.State = ProductInventoryState.WaitShipping;
            newItem.DeliveryItem = si.ID;
            newItem.DeliverySheet = si.SheetNo;
            addingItems.Add(newItem);
        }

        //更新分配置的数量,
        private void F_Change(ProductInventoryItem source, ProductInventoryItem des, decimal newCount, List<ProductInventoryItem> addingItems, List<ProductInventoryItem> updatingitems, List<ProductInventoryItem> cloneItems, List<ProductInventoryItem> deletingItems)
        {
            if (des.Count == newCount) return;
            if ((des.Count + source.Count) < newCount) throw new Exception("出货数量超出库存数量");
            if (!updatingitems.Exists(it => it.ID == source.ID))
            {
                updatingitems.Add(source);
                cloneItems.Add(source.Clone());
            }
            if (!updatingitems.Exists(it => it.ID == des.ID))
            {
                updatingitems.Add(des);
                cloneItems.Add(des.Clone());
            }

            decimal? uw = source.Count > 0 ? source.UnitWeight : des.UnitWeight;
            //两行的顺序不能反!
            source.Count += des.Count - newCount; //相减的两者不管谁大谁小都用同一个表达式,不会出错的
            des.Count = newCount;
            if (uw != null)
            {
                source.Weight = source.Count * uw;
                des.Weight = des.Count * uw;
            }
        }

        //合并项,将deleting项的数量合并到source中,并删除deleting
        private void F_Merge(ProductInventoryItem source, ProductInventoryItem deleting, List<ProductInventoryItem> addingItems, List<ProductInventoryItem> updatingitems, List<ProductInventoryItem> cloneItems, List<ProductInventoryItem> deletingItems)
        {
            if (!updatingitems.Exists(it => it.ID == source.ID))
            {
                updatingitems.Add(source);
                cloneItems.Add(source.Clone());
            }
            source.Count += deleting.Count;
            source.Weight += deleting.Weight;
            deletingItems.Add(deleting);
        }

        private void F_CommitChanges(List<ProductInventoryItem> addingItems, List<ProductInventoryItem> updatingitems, List<ProductInventoryItem> cloneItems, List<ProductInventoryItem> deletingItems, IUnitWork unitWork)
        {
            var provider = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri);
            if (addingItems != null && addingItems.Count > 0)
            {
                foreach (var item in addingItems)
                {
                    provider.Insert(item, unitWork);
                }
            }
            if (updatingitems != null && updatingitems.Count > 0)
            {
                foreach (var item in updatingitems)
                {
                    var clone = cloneItems.Single(it => it.ID == item.ID);
                    provider.Update(item, clone, unitWork);
                }
            }
            if (deletingItems != null && deletingItems.Count > 0)
            {
                foreach (var item in deletingItems)
                {
                    provider.Delete(item, unitWork);
                }
            }
        }
        #endregion

        #region 重写基类方法
        protected override string CreateSheetID(StackOutSheet info)
        {
            if (info.ClassID == StackOutSheetType.DeliverySheet)
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber(UserSettings.Current.DeliverySheetPrefix,
                        UserSettings.Current.DeliverySheetDateFormat, UserSettings.Current.DeliverySheetSerialCount, info.DocumentType);
            }
            else if (info.ClassID == StackOutSheetType.CustomerBorrow)
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("JYD",
                        UserSettings.Current.DeliverySheetDateFormat, UserSettings.Current.DeliverySheetSerialCount, info.DocumentType);
            }
            if (!string.IsNullOrEmpty(info.ID)) info.Items.ForEach(item => item.SheetNo = info.ID);//这一句不能省!!
            return info.ID;
        }

        protected override void DoAdd(StackOutSheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            base.DoAdd(info, unitWork, dt, opt);
            List<ProductInventoryItem> addingItems = new List<ProductInventoryItem>();
            List<ProductInventoryItem> updatingitems = new List<ProductInventoryItem>();
            List<ProductInventoryItem> cloneItems = new List<ProductInventoryItem>();
            List<ProductInventoryItem> deletingItems = new List<ProductInventoryItem>();

            ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
            con.IDS = info.Items.Select(it => it.InventoryItem.Value).ToList();
            var pis = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con).QueryObjects;
            foreach (var item in info.Items)  //将原材料的项的状态变成待出货状态
            {
                if (item.InventoryItem != null)
                {
                    ProductInventoryItem pi = pis.SingleOrDefault(it => it.ID == item.InventoryItem);
                    if (pi == null) throw new ApplicationException("不存在相关的库存！");
                    F_Assign(pi, item, addingItems, updatingitems, cloneItems, deletingItems);
                }
            }
            F_CommitChanges(addingItems, updatingitems, cloneItems, deletingItems, unitWork);
        }

        protected override void DoUpdate(StackOutSheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            base.DoUpdate(info, unitWork, dt, opt);
            var original = GetByID(info.ID).QueryObject;
            List<ProductInventoryItem> addingItems = new List<ProductInventoryItem>();
            List<ProductInventoryItem> updatingitems = new List<ProductInventoryItem>();
            List<ProductInventoryItem> cloneItems = new List<ProductInventoryItem>();
            List<ProductInventoryItem> deletingItems = new List<ProductInventoryItem>();

            ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
            con.IDS = info.Items.Where(it => it.InventoryItem != null).Select(it => it.InventoryItem.Value).Union(
                      original.Items.Where(it => it.InventoryItem != null).Select(it => it.InventoryItem.Value)
                      ).Distinct().ToList();
            var sources = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con).QueryObjects;

            con = new ProductInventoryItemSearchCondition();
            con.DeliverySheetNo = info.ID;
            var assigns = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con).QueryObjects;
            foreach (var item in info.Items)
            {
                if (item.InventoryItem != null) //如果有进行分配
                {
                    var source = sources.SingleOrDefault(it => it.ID == item.InventoryItem);
                    if (original.Items.Exists(it => it.ID == item.ID))
                    {
                        var assigned = assigns.SingleOrDefault(it => it.DeliveryItem == item.ID);  //每一个出货单项有且只有一项分配项
                        F_Change(source, assigned, item.Count, addingItems, updatingitems, cloneItems, deletingItems);
                    }
                    else
                    {
                        F_Assign(source, item, addingItems, updatingitems, cloneItems, deletingItems);
                    }
                }
            }
            foreach (var item in original.Items)
            {
                if (item.InventoryItem != null && !info.Items.Exists(it => it.ID == item.ID))
                {
                    var source = sources.SingleOrDefault(it => it.ID == item.InventoryItem);
                    var assigned = assigns.SingleOrDefault(it => it.DeliveryItem == item.ID);  //每一个出货单项有且只有一
                    F_Merge(source, assigned, addingItems, updatingitems, cloneItems, deletingItems);
                }
            }
            foreach (var assign in assigns) //将所有没有匹配的其它库存归成在库状态
            {
                if (!sources.Exists(it => it.ID == assign.SourceID))
                {
                    var assignClone = assign.Clone();
                    assignClone.DeliveryItem = null;
                    assignClone.DeliverySheet = null;
                    assignClone.State = ProductInventoryState.Inventory;
                    ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(assignClone, assign, unitWork);
                }
            }
            F_CommitChanges(addingItems, updatingitems, cloneItems, deletingItems, unitWork);
        }

        protected override void DoShip(StackOutSheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            IProvider<StackOutSheet, string> sp = ProviderFactory.Create<IProvider<StackOutSheet, string>>(RepoUri);
            if (info.Items == null || info.Items.Count == 0) throw new Exception("单号为 " + info.ID + " 的送货单发货失败，没有送货单项");
            StackOutSheet sheet1 = info.Clone() as StackOutSheet;
            info.LastActiveDate = dt;
            info.State = SheetState.Shipped;
            sp.Update(info, sheet1, unitWork);

            var provider = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri);
            ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
            con.DeliverySheetNo = info.ID;
            List<ProductInventoryItem> piis = provider.GetItems(con).QueryObjects;
            if (piis == null || piis.Count == 0) throw new ApplicationException("没有找到送货单对应的库存项！");
            if (piis.Exists(it => !info.Items.Exists(si => it.DeliveryItem == si.ID))) throw new ApplicationException("送货单的库存项有错误，请重新保存此送货单再出货");
            foreach (var item in info.Items)  //检查库存数量与出货数量是否一致
            {
                if (item.InventoryItem.HasValue && piis.Sum(it => it.DeliveryItem == item.ID ? it.Count : 0) != item.Count) throw new ApplicationException("送货单数量与出库数量不一致！");
            }
            foreach (var pi in piis)
            {
                var piClone = pi.Clone();
                piClone.State = ProductInventoryState.Shipped;
                provider.Update(piClone, pi, unitWork);
            }

            if (info.ClassID == StackOutSheetType.DeliverySheet)
            {
                AddReceivables(info, dt, unitWork);         //类型为送货单的出库单出货时增加应收
                if (info.WithTax) AddTax(info, dt, unitWork); //含税时需要增加应开增值税发票
            }
        }

        protected override void DoNullify(StackOutSheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            //删除所有的应收和应开增值税
            bool allSuccess = true;
            CustomerReceivableSearchCondition crsc = new CustomerReceivableSearchCondition();
            crsc.SheetID = info.ID;
            List<CustomerReceivable> crs = new CustomerReceivableBLL(RepoUri).GetItems(crsc).QueryObjects;
            if (crs != null && crs.Count > 0)
            {
                foreach (var cr in crs)
                {
                    var t = new CustomerReceivableBLL(RepoUri).Delete(cr);
                    allSuccess = t.Result == ResultCode.Successful;
                    if (!allSuccess) break;
                }
            }
            if (!allSuccess) throw new ApplicationException("删除送货单对应的应收款或应开增值税资料时出错，请重试！");

            base.DoNullify(info, unitWork, dt, opt);
            List<ProductInventoryItem> addingItems = new List<ProductInventoryItem>();
            List<ProductInventoryItem> updatingitems = new List<ProductInventoryItem>();
            List<ProductInventoryItem> cloneItems = new List<ProductInventoryItem>();
            List<ProductInventoryItem> deletingItems = new List<ProductInventoryItem>();
            var provider = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri);
            foreach (var item in info.Items)  //将原材料的项的状态恢复到在库状态
            {
                if (item.InventoryItem.HasValue)
                {
                    ProductInventoryItem sourcePi = provider.GetByID(item.InventoryItem.Value).QueryObject;
                    if (sourcePi == null) throw new ApplicationException("在删除送货单的送货库存时出错！");
                    ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                    con.DeliveryItem = item.ID;
                    List<ProductInventoryItem> piis = provider.GetItems(con).QueryObjects;
                    if (piis == null || piis.Count == 0 || piis.Sum(it => it.Count) != item.Count) throw new ApplicationException("在删除送货单的送货库存时出错！");
                    piis.ForEach(pi => F_Merge(sourcePi, pi, addingItems, updatingitems, cloneItems, deletingItems)); //将分配的库存与原库存项合并
                }
            }
            F_CommitChanges(addingItems, updatingitems, cloneItems, deletingItems, unitWork);
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 通过查询条件获取相关商品销售记录
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public QueryResultList<StackOutRecord> GetDeliveryRecords(SearchCondition con)
        {
            var ret = ProviderFactory.Create<IProvider<StackOutRecord, Guid>>(RepoUri).GetItems(con);
            if (ret.QueryObjects != null && ret.QueryObjects.Count > 0)
            {
                List<ProductInventoryItem> pis = new ProductInventoryItemBLL(RepoUri).GetItems(null).QueryObjects;
                foreach (var item in ret.QueryObjects)
                {
                    var pi = pis.FirstOrDefault(it => it.DeliveryItem == item.ID);
                    if (pi != null && pi.SourceRoll.HasValue)
                    {
                        pi = pis.SingleOrDefault(it => it.ID == pi.SourceRoll.Value);
                        if (pi != null) item.SourceRollWeight = pi.OriginalWeight;
                    }
                }
            }
            return ret;
        }

        public void AssignPayment(StackOutSheet info)
        {
            CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
            con.SheetID = info.ID;
            con.Settled = false;
            con.ReceivableTypes = new List<CustomerReceivableType>();
            con.ReceivableTypes.Add(CustomerReceivableType.CustomerReceivable);
            var crs = new CustomerReceivableBLL(RepoUri).GetItems(con).QueryObjects;
            if (crs != null && crs.Count > 0)
            {
                AccountRecordSearchCondition cpsc = new AccountRecordSearchCondition();
                cpsc.StackSheetID = info.ID;
                cpsc.HasRemain = true;
                var cps = ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).GetItems(cpsc).QueryObjects;
                if (cps != null && cps.Count > 0)
                {
                    foreach (var cr in crs)
                    {
                        foreach (var cp in cps.Where(it => it.Remain > 0))
                        {
                            var assign = new AccountRecordAssign()
                            {
                                ID = Guid.NewGuid(),
                                PaymentID = cp.ID,
                                ReceivableID = cr.ID,
                                Amount = cr.Remain >= cp.Remain ? cp.Remain : cr.Remain
                            };
                            cr.Haspaid += assign.Amount;
                            cp.Assigned += assign.Amount;
                            if (assign.Amount > 0) new AccountRecordAssignBLL(RepoUri).Assign(assign);
                            if (cr.Remain == 0) break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 获取某个送货单的财务状态
        /// </summary>
        /// <param name="sheetID"></param>
        /// <returns></returns>
        public QueryResult<StackOutSheetFinancialState> GetFinancialStateOf(string sheetID)
        {
            var item = GetByID(sheetID).QueryObject;
            if (item == null) return new QueryResult<StackOutSheetFinancialState>(ResultCode.Fail, "没有找到相关送货单信息", null);
            var ret = new StackOutSheetFinancialState() { ID = sheetID };

            AccountRecordSearchCondition con = new AccountRecordSearchCondition();
            con.PaymentTypes = new List<CustomerPaymentType>() { CustomerPaymentType.Customer };
            con.StackSheetID = item.ID;
            var cps = new AccountRecordBLL(AppSettings.Current.ConnStr).GetItems(con).QueryObjects;
            if (cps != null && cps.Count == 1)
            {
                ret.FirstAccountID = cps[0].AccountID;
            }
            if (item.State != SheetState.Shipped)
            {
                if (cps != null) ret.Paid = cps.Sum(it => it.Remain);
            }
            else
            {
                CustomerReceivableSearchCondition con1 = new CustomerReceivableSearchCondition() { SheetID = item.ID };
                List<CustomerReceivable> crs = (new CustomerReceivableBLL(AppSettings.Current.ConnStr)).GetItems(con1).QueryObjects;
                if (crs != null) ret.Paid = crs.Sum(it => it.Haspaid);
            }
            ret.NotPaid = item.Amount - item.Discount - ret.Paid;
            return new QueryResult<StackOutSheetFinancialState>(ResultCode.Successful, string.Empty, ret);
        }
        #endregion
    }
}
