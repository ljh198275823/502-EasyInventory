using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;

namespace LJH.Inventory.UnitTest.BLLTest
{
    [TestClass]
    public class OrderBLLTest
    {
        private Order CreatAOrder()
        {
            Order order = new Order();
            order.ID = Guid.NewGuid().ToString();
            order.OrderDate = DateTime.Today;
            order.CustomerName = "ralid";
            order.Memo = "ede";
            return order;
        }

        private void AssertEqual(Order o1, Order o2)
        {

        }

        [TestMethod]
        public void CanAddAOrder()
        {
            Order order = CreatAOrder();
            CommandResult ret = (new OrderBLL(StaticConnectString.ConnectString)).Add(order);
            Assert.IsTrue(ret.Result == ResultCode.Successful);

            QueryResult<Order> qret = (new OrderBLL(StaticConnectString.ConnectString)).GetByID(order.ID);
            Order order1 = qret.QueryObject;
            Assert.IsTrue(order1 != null);
            AssertEqual(order, order1);

            ret = (new OrderBLL(StaticConnectString.ConnectString)).Delete(order);
            Assert.IsTrue(ret.Result == ResultCode.Successful);

            order1 = (new OrderBLL(StaticConnectString.ConnectString)).GetByID(order.ID).QueryObject;
            Assert.IsTrue(order1 == null);
        }
    }
}
