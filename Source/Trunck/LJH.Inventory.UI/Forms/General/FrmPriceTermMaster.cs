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
using LJH.GeneralLibrary.DAL;
using LJH.GeneralLibrary.UI;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmPriceTermMaster : FrmMasterBase 
    {
        public FrmPriceTermMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmPriceTermDetail();
        }

        protected override List<object> GetDataSource()
        {
            List<PriceTerm> items = (new PriceTermBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            if (items != null)
            {
                return (from item in items select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            PriceTerm ct = item as PriceTerm;
            row.Cells["colName"].Value = ct.Name;
            row.Cells["colMemo"].Value = ct.Memo;
        }

        protected override bool DeletingItem(object item)
        {
            CommandResult ret = (new PriceTermBLL(AppSettings.Current.ConnStr)).Delete(item as PriceTerm);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            return ret.Result == ResultCode.Successful;
        }
        #endregion
    }
}
