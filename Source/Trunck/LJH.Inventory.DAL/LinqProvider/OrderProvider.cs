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
    public class OrderProvider : ProviderBase<Order, string>, IOrderProvider
    {
        #region 构造函数
        public OrderProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override Order GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<Order>(item => item.Items);
            dc.LoadOptions = opt;
            Order sheet = dc.GetTable<Order>().SingleOrDefault(item => item.ID == id);
            if (sheet != null)
            {
                sheet.Customer = (new CustomerProvider(ConnectStr)).GetByID(sheet.CustomerID).QueryObject;
                if (sheet.Items != null && sheet.Items.Count > 0)
                {
                    List<Product> ps = (new ProductProvider(ConnectStr)).GetItems(null).QueryObjects;
                    foreach (OrderItem item in sheet.Items)
                    {
                        item.Product = ps.SingleOrDefault(p => p.ID == item.ProductID);
                    }
                }
            }
            return sheet;
        }

        protected override List<Order> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<Order>(item => item.Items);
            dc.LoadOptions = opt;
            IQueryable<Order> ret = dc.GetTable<Order>();
            if (search is SheetSearchCondition)
            {
                SheetSearchCondition con = search as SheetSearchCondition;
                if (!string.IsNullOrEmpty(con.SheetNo)) ret = ret.Where(item => item.ID.Contains(con.SheetNo));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains((int)item.State));
                if (!string.IsNullOrEmpty(con.Memo)) ret = ret.Where(item => item.Memo.Contains(con.Memo));
            }
            if (search is OrderSearchCondition)
            {
                OrderSearchCondition con = search as OrderSearchCondition;
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.CustomerID == con.CustomerID);
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
            List<Order> sheets = ret.ToList();
            if (sheets != null && sheets.Count > 0)  //有些查询不能直接用SQL语句查询
            {
                List<CompanyInfo> cs = (new CustomerProvider(ConnectStr)).GetItems(null).QueryObjects;
                List<Product> ps = (new ProductProvider(ConnectStr)).GetItems(null).QueryObjects;
                foreach (Order sheet in sheets)
                {
                    sheet.Customer = cs.SingleOrDefault(item => item.ID == sheet.CustomerID);
                    if (sheet.Items != null && sheet.Items.Count > 0)
                    {
                        foreach (OrderItem si in sheet.Items)
                        {
                            si.Product = ps.SingleOrDefault(item => item.ID == si.ProductID);
                        }
                    }
                }
            }
            return sheets;
        }

        protected override void UpdatingItem(Order newVal, Order original, System.Data.Linq.DataContext dc)
        {
            dc.GetTable<Order>().Attach(newVal, original);
            foreach (OrderItem item in newVal.Items)
            {
                OrderItem old = original.Items.SingleOrDefault(it => it.ID == item.ID);
                if (old != null)
                {
                    dc.GetTable<OrderItem>().Attach(item, old);
                }
                else
                {
                    item.OrderID = newVal.ID;
                    dc.GetTable<OrderItem>().InsertOnSubmit(item);
                }
            }
            foreach (OrderItem item in original.Items)
            {
                if (newVal.Items.SingleOrDefault(it => it.ID == item.ID) == null)
                {
                    dc.GetTable<OrderItem>().Attach(item);
                    dc.GetTable<OrderItem>().DeleteOnSubmit(item);
                }
            }
        }
        #endregion
    }
}
