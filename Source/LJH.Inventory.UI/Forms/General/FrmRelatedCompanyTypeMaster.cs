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
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.General
{
    public partial class FrmRelatedCompanyTypeMaster : FrmMasterBase
    {
        public FrmRelatedCompanyTypeMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override FrmDetailBase GetDetailForm()
        {
            FrmRelatedCompanyTypeDetail frm = new FrmRelatedCompanyTypeDetail();
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            List<RelatedCompanyType> items = null;
            if (SearchCondition == null)
            {
                items = (new RelatedCompanyTypeBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                items = (new RelatedCompanyTypeBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            if (items != null)
            {
                return (from item in items select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            RelatedCompanyType ct = item as RelatedCompanyType;
            row.Cells["colName"].Value = ct.Name;
            row.Cells["colMemo"].Value = ct.Memo;
        }

        protected override bool DeletingItem(object item)
        {
            CommandResult ret = (new RelatedCompanyTypeBLL(AppSettings.Current.ConnStr)).Delete(item as RelatedCompanyType);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            return ret.Result == ResultCode.Successful;
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            btn_Add.Enabled = Operator.Current.Permit(Permission.Manufacturer, PermissionActions.Edit);
            btn_Delete.Enabled = Operator.Current.Permit(Permission.Manufacturer, PermissionActions.Edit);
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.Manufacturer, PermissionActions.Edit);
            cMnu_Delete.Enabled = Operator.Current.Permit(Permission.Manufacturer, PermissionActions.Edit);
        }
        #endregion
    }
}
