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
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.General
{
    public partial class FrmCurrencyTypeMaster : FrmMasterBase
    {
        public FrmCurrencyTypeMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            //btn_Add.Enabled = Operator.Current.Permit(Permission.CurrencyType, PermissionActions.Edit);
            //btn_Delete.Enabled = Operator.Current.Permit(Permission.CurrencyType, PermissionActions.Edit);
            //cMnu_Add.Enabled = Operator.Current.Permit(Permission.CurrencyType, PermissionActions.Edit);
            //cMnu_Delete.Enabled = Operator.Current.Permit(Permission.CurrencyType, PermissionActions.Edit);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmCurrencyTypeDetail();
        }

        protected override List<object> GetDataSource()
        {
            List<CurrencyType> items = null;
            if (SearchCondition == null)
            {
                items = (new CurrencyTypeBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                items = (new CurrencyTypeBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            if (items != null)
            {
                return (from item in items select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CurrencyType ct = item as CurrencyType;
            row.Cells["colID"].Value = ct.ID;
            row.Cells["colName"].Value = ct.Name;
            row.Cells["colSymbol"].Value = ct.Symbol;
            row.Cells["colExchangeRate"].Value = ct.ExchangeRate.Trim();
            row.Cells["colMemo"].Value = ct.Memo;
        }

        protected override bool DeletingItem(object item)
        {
            CommandResult ret = (new CurrencyTypeBLL(AppSettings.Current.ConnStr)).Delete(item as CurrencyType);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            return ret.Result == ResultCode.Successful;
        }
        #endregion
    }
}
