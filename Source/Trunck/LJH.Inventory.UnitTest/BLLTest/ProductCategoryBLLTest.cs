using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;

namespace LJH.Inventory.UnitTest.BLLTest
{
    /// <summary>
    /// ProductCategoryBLLTest
    /// </summary>
    [TestClass]
    public class ProductCategoryBLLTest
    {
        public ProductCategoryBLLTest()
        {

        }

        [TestMethod]
        public void GUIDTest()
        {
            ProductCategory item0 = new ProductCategory() { ID = "ewoftogoeo", Name = "镀锌钢板", Memo = "厂家:正泰" };
            ProductCategoryBLL bll = new ProductCategoryBLL(StaticConnectString.ConnectString);
            CommandResult ret = bll.Insert(item0);

            Assert.IsTrue(ret.Result == ResultCode.Successful);

            List<ProductCategory> items = bll.GetAll().QueryObjects;
            Assert.IsTrue(items.Count > 0);
            Assert.IsTrue(items.SingleOrDefault(item => item.ID == item0.ID) != null);

            item0.Name += "123";
            item0.Memo += "123";
            ret = bll.Update(item0);
            Assert.IsTrue(ret.Result == ResultCode.Successful);
            ProductCategory item1 = bll.GetByID(item0.ID).QueryObject;
            Assert.IsTrue(item0.Name == item1.Name);
            Assert.IsTrue(item0.Memo == item1.Memo);

            ret = bll.Delete(item0);
            Assert.IsTrue(ret.Result == ResultCode.Successful);
            item1 = bll.GetByID(item0.ID).QueryObject;
            Assert.IsTrue(item1 == null);
        }
    }
}
