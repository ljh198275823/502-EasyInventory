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
    public partial class FrmDepartmentMaster : FrmMasterBase
    {
        public FrmDepartmentMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<Department> _depts = null;
        #endregion

        #region 重写基类方法
        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            btn_Add.Enabled = Operator.Current.Permit(Permission.Department, PermissionActions.Edit);
            btn_Delete.Enabled = Operator.Current.Permit(Permission.Department, PermissionActions.Edit);
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.Department, PermissionActions.Edit);
            cMnu_Delete.Enabled = Operator.Current.Permit(Permission.Department, PermissionActions.Edit);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmDepartmentDetail();
        }

        protected override List<object> GetDataSource()
        {
            _depts = (new DepartmentBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            if (_depts != null)
            {
                return (from item in _depts select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Department ct = item as Department;
            row.Cells["colName"].Value = ct.Name;
            if (!string.IsNullOrEmpty(ct.Parent) && _depts != null && _depts.Count > 0)
            {
                Department p = _depts.SingleOrDefault(it => it.ID == ct.Parent);
                row.Cells["colParent"].Value = p != null ? p.Name : string.Empty;
            }
            row.Cells["colMemo"].Value = ct.Memo;
        }

        protected override bool DeletingItem(object item)
        {
            CommandResult ret = (new DepartmentBLL(AppSettings.Current.ConnStr)).Delete(item as Department);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            return ret.Result == ResultCode.Successful;
        }
        #endregion
    }
}
