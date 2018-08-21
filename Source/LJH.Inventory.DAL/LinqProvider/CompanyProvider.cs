using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using LJH.Inventory .DAL .IProvider ;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class CompanyProvider : ProviderBase<CompanyInfo, string>,ICompanyProvider
    {
        #region 构造函数
        public CompanyProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr,ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override CompanyInfo GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            CompanyInfo c = dc.GetTable<CompanyInfo>().SingleOrDefault(item => item.ID == id);
            return c;
        }

        protected override List<CompanyInfo> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<CompanyInfo> ret = dc.GetTable<CompanyInfo>();
            if (search is CustomerSearchCondition)
            {
                CustomerSearchCondition con = search as CustomerSearchCondition;
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.ID.Contains(con.CustomerID));
                if (con.ClassID != null) ret = ret.Where(item => item.ClassID == con.ClassID.Value);
                if (!string.IsNullOrEmpty(con.Category)) ret = ret.Where(item => item.CategoryID == con.Category);
            }
            List<CompanyInfo> cs = ret.ToList();
            return cs;
        }

        protected override void DeletingItem(CompanyInfo info, System.Data.Linq.DataContext dc)
        {
            throw new Exception("不能调用这个方法删除客户信息，请调用DeleteEx方法");
        }
        #endregion

        public CommandResult Merge(string source, string des)
        {
            try
            {
                string sql = string.Empty;
                sql += string.Format("update AccountRecord  set CustomerID='{0}' where CustomerID='{1}' ", des, source);
                sql += string.Format("update Contact set Company='{0}' where Company='{1}' ", des, source);
                sql += string.Format("update CustomerPayment set CustomerID='{0}' where CustomerID='{1}' ", des, source);
                sql += string.Format("update CustomerReceivable  set CustomerID='{0}' where CustomerID='{1}' ", des, source);
                sql += string.Format("update [Order] set CustomerID='{0}' where CustomerID='{1}' ", des, source);
                sql += string.Format("update OtherReceivableSheet  set CustomerID='{0}' where CustomerID='{1}' ", des, source);
                sql += string.Format("update PurchaseOrder  set SupplierID='{0}' where SupplierID='{1}' ", des, source);
                sql += string.Format("update StackInSheet  set SupplierID='{0}' where SupplierID='{1}' ", des, source);
                sql += string.Format("update StackOutSheet  set CustomerID='{0}' where CustomerID='{1}' ", des, source);
                sql += string.Format("delete Customer where ID='{0}' ", source);
                var dc = CreateDataContext();
                dc.ExecuteCommand(sql);
                return new CommandResult(ResultCode.Successful, string.Empty);
            }
            catch (Exception ex)
            {
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }

        public CommandResult DeleteEx(string id)
        {
            try
            {
                string sql = string.Empty;
                sql += string.Format("if exists (select * from AccountRecord  where CustomerID='{0}') begin RAISERROR ('{1}',16,1) return end \n", id, "不能删除，此客户已经有单据信息");
                sql += string.Format("if exists (select * from CustomerPayment  where CustomerID='{0}') begin RAISERROR ('{1}',16,1) return end \n", id, "不能删除，此客户已经有单据信息");
                sql += string.Format("if exists (select * from CustomerReceivable  where CustomerID='{0}') begin RAISERROR ('{1}',16,1) return end \n", id, "不能删除，此客户已经有单据信息");
                sql += string.Format("if exists (select * from [Order] where CustomerID='{0}') begin RAISERROR ('{1}',16,1) return end \n", id, "不能删除，此客户已经有单据信息");
                sql += string.Format("if exists (select * from OtherReceivableSheet  where CustomerID='{0}') begin RAISERROR ('{1}',16,1) return end \n", id, "不能删除，此客户已经有单据信息");
                sql += string.Format("if exists (select * from PurchaseOrder  where SupplierID='{0}') begin RAISERROR ('{1}',16,1) return end \n", id, "不能删除，此客户已经有单据信息");
                sql += string.Format("if exists (select * from StackInSheet  where SupplierID='{0}') begin RAISERROR ('{1}',16,1) return end \n", id, "不能删除，此客户已经有单据信息");
                sql += string.Format("if exists (select * from StackOutSheet  where CustomerID='{0}') begin RAISERROR ('{1}',16,1) return end \n", id, "不能删除，此客户已经有单据信息");
                sql += string.Format("delete Customer where ID='{0}' ", id);
                var dc = CreateDataContext();
                dc.ExecuteCommand(sql);
                return new CommandResult(ResultCode.Successful, string.Empty);
            }
            catch (Exception ex)
            {
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }
    }
}
