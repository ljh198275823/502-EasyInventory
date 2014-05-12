using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Financial.View
{
    public partial class FrmCustomerReceivableView : FrmMasterBase
    {
        public FrmCustomerReceivableView()
        {
            InitializeComponent();
        }

        #region 公共属性
        public CompanyInfo Customer { get; set; }
        #endregion

        #region 私有方法
        private int DaysBetween(DateTime endDt, DateTime beginDt)
        {
            TimeSpan ts1 = new TimeSpan(endDt.Date.Ticks - beginDt.Date.Ticks);
            return (int)ts1.TotalDays;
        }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            if (Customer != null) this.Text = string.Format("{0} 的应收款明细", Customer.Name);
        }

        protected override List<object> GetDataSource()
        {
            List<CustomerReceivable> items = null;
            CompanyBLL bll = new CompanyBLL(AppSettings.Current.ConnStr);
            if (SearchCondition == null)
            {
                CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
                con.CustomerID = Customer != null ? Customer.ID : null;
                con.Settled = false;
                items = (new CustomerReceivableBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            }
            else
            {
                items = (new CustomerReceivableBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            List<object> records = (from item in items orderby item.CreateDate ascending, item.SheetID ascending select (object)item).ToList();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CustomerReceivable cr = item as CustomerReceivable;
            row.Tag = cr;
            row.Cells["colSheetID"].Value = cr.SheetID;
            row.Cells["colOrderID"].Value = cr.OrderID;
            row.Cells["colCreateDate"].Value = cr.CreateDate.ToString("yyyy-MM-dd");
            row.Cells["colClassID"].Value = cr.ClassID;
            row.Cells["colAmount"].Value = cr.Amount.Trim();
            row.Cells["colHaspaid"].Value = cr.Haspaid.Trim();
            row.Cells["colNotpaid"].Value = cr.Remain.Trim();
            int days = DaysBetween(DateTime.Today, cr.CreateDate);
            row.Cells["colHowold"].Value = days >= 0 ? string.Format("{0}天", days) : string.Empty;
        }

        protected override void ShowItemsOnGrid(List<object> items)
        {
            base.ShowItemsOnGrid(items);
            int rowTotal = GridView.Rows.Add();
            GridView.Rows[rowTotal].Cells["colCreateDate"].Value = "合计";
            GridView.Rows[rowTotal].Cells["colAmount"].Value = items.Sum(item => (item as CustomerReceivable).Amount).Trim();
            GridView.Rows[rowTotal].Cells["colHaspaid"].Value = items.Sum(item => (item as CustomerReceivable).Haspaid).Trim();
            GridView.Rows[rowTotal].Cells["colNotpaid"].Value = items.Sum(item => (item as CustomerReceivable).Remain).Trim();
        }
        #endregion
    }
}
