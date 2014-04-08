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
            //CompanyInfo c = item as CompanyInfo;
            //row.Tag = c;
            //row.Cells["colImage"].Value = Properties.Resources.customer;
            //row.Cells["colID"].Value = c.ID;
            //row.Cells["colName"].Value = c.Name;
            //row.Cells["colCategory"].Value = c.CategoryID;
            //CustomerState cs = null;
            //if (_CustomerStates != null && _CustomerStates.Count > 0) cs = _CustomerStates.SingleOrDefault(it => it.CustomerID == c.ID);
            //row.Cells["colPrepay"].Value = cs != null ? cs.Prepay.Trim() : 0;
            //row.Cells["colReceivable"].Value = cs != null ? cs.Receivable.Trim() : 0;
        }
        #endregion
    }
}
