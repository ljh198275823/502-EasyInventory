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

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmCustomerReceivableView : FrmMasterBase
    {
        public FrmCustomerReceivableView()
        {
            InitializeComponent();
        }

        #region 公共方法
        public CompanyInfo Customer { get; set; }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            if (Customer != null) this.Text = string.Format("{0} 的应收款明细", Customer.Name);
        }

        protected override List<object> GetDataSource()
        {
            CompanyBLL bll = new CompanyBLL(AppSettings.Current.ConnStr);
            if (SearchCondition == null)
            {
                CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
                con.CustomerID = Customer != null ? Customer.ID : null;
                SearchCondition = con;
            }
            List<CustomerReceivable> items = (new CustomerReceivableBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            List<object> records = (from item in items select (object)item).ToList();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CustomerReceivable cr = item as CustomerReceivable;
            row.Tag = cr;
            row.Cells["colSheetID"].Value = cr.SheetID;
            row.Cells["colCreateDate"].Value = cr.CreateDate.ToString("yyyy-MM-dd");
            row.Cells["colClassID"].Value = cr.ClassID;
            row.Cells["colAmount"].Value = cr.Amount;
            row.Cells["colRemain"].Value = cr.Remain;
            row.Cells["colMemo"].Value = cr.Memo;
        }
        #endregion
    }
}
