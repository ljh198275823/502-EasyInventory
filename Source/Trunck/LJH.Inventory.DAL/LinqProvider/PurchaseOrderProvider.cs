using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class PurchaseOrderProvider : ProviderBase<PurchaseOrder, string>, IPurchaseOrderProvider
    {
        #region 构造函数
        public PurchaseOrderProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override PurchaseOrder GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<PurchaseOrder>(order => order.Supplier);
            opt.LoadWith<PurchaseOrder>(order => order.Items);
            opt.LoadWith<PurchaseItem>(oi => oi.Product);
            opt.LoadWith<Product>(p => p.Category);
            dc.LoadOptions = opt;
            PurchaseOrder ord = dc.GetTable<PurchaseOrder>().SingleOrDefault(item => item.ID == id);
            return ord;
        }

        protected override List<PurchaseOrder> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<PurchaseOrder>(order => order.Supplier);
            opt.LoadWith<PurchaseOrder>(order => order.Items);
            opt.LoadWith<PurchaseItem>(oi => oi.Product);
            opt.LoadWith<Product>(p => p.Category);
            dc.LoadOptions = opt;
            IQueryable<PurchaseOrder> ret = dc.GetTable<PurchaseOrder>();
            if (search is PurchaseOrderSearchCondition)
            {
                PurchaseOrderSearchCondition con = search as PurchaseOrderSearchCondition;
                if (!string.IsNullOrEmpty(con.OrderID)) ret = ret.Where(item => item.ID == con.OrderID);
                if (!string.IsNullOrEmpty(con.SupplerID)) ret = ret.Where(item => item.SupplierID == con.SupplerID);
                if (con.OrderDate != null) ret = ret.Where(item => item.OrderDate >= con.OrderDate.Begin && item.OrderDate <= con.OrderDate.End);
                if (!string.IsNullOrEmpty(con.Buyer)) ret = ret.Where(item => item.Buyer.Contains(con.Buyer));
                if (con.States != null) ret = ret.Where(item => con.States.Contains(item.State));
                if (con.WithTax != null)
                {
                    if (con.WithTax.Value)
                    {
                        ret = ret.Where(item => item.WithTax == true);
                    }
                    else
                    {
                        ret = ret.Where(item => item.WithTax == false);
                    }
                }
            }
            List<PurchaseOrder> orders = ret.ToList();
            return orders;
        }

        protected override void InsertingItem(PurchaseOrder info, System.Data.Linq.DataContext dc)
        {
            dc.GetTable<T_PurchaseOrder>().InsertOnSubmit(new T_PurchaseOrder(info));
            foreach (PurchaseItem  item in info.Items)
            {
                item.PurchaseID = info.ID;
                dc.GetTable<T_PurchaseItem>().InsertOnSubmit(new T_PurchaseItem(item));
            }
        }

        protected override void UpdatingItem(PurchaseOrder newVal, PurchaseOrder original, System.Data.Linq.DataContext dc)
        {
            dc.GetTable<T_PurchaseOrder>().Attach(new T_PurchaseOrder(newVal), new T_PurchaseOrder(original));
            foreach (PurchaseItem item in newVal.Items)
            {
                PurchaseItem old = original.Items.SingleOrDefault(it => it.ID == item.ID);
                if (old != null)
                {
                    dc.GetTable<T_PurchaseItem>().Attach(new T_PurchaseItem(item), new T_PurchaseItem(old));
                }
                else
                {
                    item.PurchaseID = newVal.ID;
                    dc.GetTable<T_PurchaseItem>().InsertOnSubmit(new T_PurchaseItem(item));
                }
            }
            foreach (PurchaseItem item in original.Items)
            {
                if (newVal.Items.SingleOrDefault(it => it.ID == item.ID) == null)
                {
                    T_PurchaseItem to = new T_PurchaseItem(item);
                    dc.GetTable<T_PurchaseItem>().Attach(to);
                    dc.GetTable<T_PurchaseItem>().DeleteOnSubmit(to);
                }
            }
        }

        protected override void DeletingItem(PurchaseOrder info, System.Data.Linq.DataContext dc)
        {
            T_PurchaseOrder t = new T_PurchaseOrder(info);
            dc.GetTable<T_PurchaseOrder>().Attach(t);
            dc.GetTable<T_PurchaseOrder>().DeleteOnSubmit(t);
            foreach (PurchaseItem item in info.Items)
            {
                T_PurchaseItem to = new T_PurchaseItem(item);
                dc.GetTable<T_PurchaseItem>().Attach(to);
                dc.GetTable<T_PurchaseItem>().DeleteOnSubmit(to);
            }
        }
        #endregion
    }
}

