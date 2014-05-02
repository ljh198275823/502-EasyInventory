using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmPaymentAssign : Form
    {
        public FrmPaymentAssign()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置要分配的客户收款单号
        /// </summary>
        public string CustomerPaymentID { get; set; }
        #endregion

        #region 私有方法
        private void ShowReceivables(string customerID)
        {
            CompanyBLL bll = new CompanyBLL(AppSettings.Current.ConnStr);
            CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
            con.CustomerID = customerID;
            con.Settled = false;
            List<CustomerReceivable> items = (new CustomerReceivableBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                items = (from item in items orderby item.CreateDate ascending, item.SheetID ascending select item).ToList();
                foreach (CustomerReceivable cr in items)
                {
                    int row = GridView.Rows.Add();
                    ShowItemInGridViewRow(GridView.Rows[row], cr);
                }
            }
        }

        private void ShowItemInGridViewRow(DataGridViewRow row, CustomerReceivable cr)
        {
            row.Tag = cr;
            row.Cells["colSheetID"].Value = cr.SheetID;
            row.Cells["colCreateDate"].Value = cr.CreateDate.ToString("yyyy-MM-dd");
            row.Cells["colClassID"].Value = cr.ClassID;
            row.Cells["colAmount"].Value = cr.Amount;
            row.Cells["colRemain"].Value = cr.Remain;
            row.Cells["colMemo"].Value = cr.Memo;
        }
        #endregion

        private void FrmPaymentAssign_Load(object sender, EventArgs e)
        {
            CustomerPayment item = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetByID(CustomerPaymentID).QueryObject;
            if (item != null)
            {
                txtID.Text = item.ID;
                txtAmount.DecimalValue = item.Amount.Trim();
                txtRemain.DecimalValue = item.Remain.Trim();
                ShowReceivables(item.CustomerID);
            }
        }
    }
}
