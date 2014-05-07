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
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmUnitMaster : FrmMasterBase 
    {
        public FrmUnitMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmUnitDetail();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            btn_Add.Enabled = Operator.Current.Permit(Permission.Unit, PermissionActions.Edit);
            btn_Delete.Enabled = Operator.Current.Permit(Permission.Unit, PermissionActions.Edit);
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.Unit, PermissionActions.Edit);
            cMnu_Delete.Enabled = Operator.Current.Permit(Permission.Unit, PermissionActions.Edit);
        }

        protected override List<object> GetDataSource()
        {
            List<Unit> items = null;
            if (SearchCondition == null)
            {
                items = (new UnitBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                items = (new UnitBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            if (items != null)
            {
                return (from item in items select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Unit ct = item as Unit;
            row.Cells["colID"].Value = ct.ID;
            row.Cells["colName"].Value = ct.Name;
            row.Cells["colPlural"].Value = ct.Plural;
            row.Cells["colMemo"].Value = ct.Memo;
        }

        protected override bool DeletingItem(object item)
        {
            CommandResult ret = (new UnitBLL(AppSettings.Current.ConnStr)).Delete(item as Unit);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            return ret.Result == ResultCode.Successful;
        }
        #endregion
    }
}
