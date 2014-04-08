using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmCustomerTypeMaster : FrmMasterBase
    {
        public FrmCustomerTypeMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmCustomerTypeDetail();
        }

        protected override List<object> GetDataSource()
        {
            List<CustomerType> items = (new CustomerTypeBLL(AppSettings.Current.ConnStr)).GetAll().QueryObjects;
            if (items != null)
            {
                return (from item in items select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CustomerType ct = item as CustomerType;
            row.Cells["colName"].Value = ct.Name;
            row.Cells["colMemo"].Value = ct.Memo;
        }

        protected override bool DeletingItem(object item)
        {
            CommandResult ret = (new CustomerTypeBLL(AppSettings.Current.ConnStr)).Delete(item as CustomerType);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            return ret.Result == ResultCode.Successful;
        }
        #endregion
    }
}
