﻿using System;
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

namespace LJH.Inventory.UI.Forms.Purchase
{
    public partial class FrmSupplierTypeMaster : FrmMasterBase
    {
        public FrmSupplierTypeMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmSupplierTypeDetail();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            btn_Add.Enabled = Operator.Current.Permit(Permission.SupplierType, PermissionActions.Edit);
            btn_Delete.Enabled = Operator.Current.Permit(Permission.SupplierType, PermissionActions.Edit);
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.SupplierType, PermissionActions.Edit);
            cMnu_Delete.Enabled = Operator.Current.Permit(Permission.SupplierType, PermissionActions.Edit);
        }

        protected override List<object> GetDataSource()
        {
            List<SupplierType> items = null;
            if (SearchCondition == null)
            {
                items = (new SupplierTypeBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                items = (new SupplierTypeBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            if (items != null)
            {
                return (from item in items select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            SupplierType ct = item as SupplierType;
            row.Cells["colName"].Value = ct.Name;
            row.Cells["colMemo"].Value = ct.Memo;
        }

        protected override bool DeletingItem(object item)
        {
            CommandResult ret = (new SupplierTypeBLL(AppSettings.Current.ConnStr)).Delete(item as SupplierType);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            return ret.Result == ResultCode.Successful;
        }
        #endregion
    }
}
