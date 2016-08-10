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

        public CommandResult UpdateMemo(ProductInventoryItem pi,string memo)
        {
            var clone = pi.Clone();
            clone.Memo = memo;
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, pi);
            if (ret.Result == ResultCode.Successful) pi.Memo = memo;
            return ret;
        }

        public CommandResult UpdateWareHouse(ProductInventoryItem pi, WareHouse  ws)
        {
            var clone = pi.Clone();
            clone.WareHouseID = ws.ID;
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, pi);
            if (ret.Result == ResultCode.Successful)
            {
                pi.WareHouseID = clone.WareHouseID;
                pi.WareHouse = ws;
            }
            return ret;
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
    }
}
