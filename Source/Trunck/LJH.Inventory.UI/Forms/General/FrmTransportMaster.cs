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

namespace LJH.Inventory.UI.Forms.General
{
    public partial class FrmTransportMaster : FrmMasterBase
    {
        public FrmTransportMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmTransportDetail();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            btn_Add.Enabled = Operator.Current.Permit(Permission.Transport, PermissionActions.Edit);
            btn_Delete.Enabled = Operator.Current.Permit(Permission.Transport, PermissionActions.Edit);
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.Transport, PermissionActions.Edit);
            cMnu_Delete.Enabled = Operator.Current.Permit(Permission.Transport, PermissionActions.Edit);
        }

        protected override List<object> GetDataSource()
        {
            List<Transport> items = null;
            if (SearchCondition == null)
            {
                items = (new TransportBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                items = (new TransportBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            if (items != null)
            {
                return (from item in items select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Transport ct = item as Transport;
            row.Cells["colName"].Value = ct.Name;
            row.Cells["colMemo"].Value = ct.Memo;
        }

        protected override bool DeletingItem(object item)
        {
            CommandResult ret = (new TransportBLL(AppSettings.Current.ConnStr)).Delete(item as Transport);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            return ret.Result == ResultCode.Successful;
        }
        #endregion
    }
}
