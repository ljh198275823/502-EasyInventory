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
    public partial class FrmCollectionTypeMaster : FrmMasterBase
    {
        public FrmCollectionTypeMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmCollectionTypeDetail();
        }

        protected override List<object> GetDataSource()
        {
            List<CollectionType> items = (new CollectionTypeBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            if (items != null)
            {
                return (from item in items select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CollectionType ct = item as CollectionType;
            row.Cells["colName"].Value = ct.Name;
            row.Cells["colMemo"].Value = ct.Memo;
        }

        protected override bool DeletingItem(object item)
        {
            CommandResult ret = (new CollectionTypeBLL(AppSettings.Current.ConnStr)).Delete(item as CollectionType);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            return ret.Result == ResultCode.Successful;
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            Operator opt = Operator.Current;
            btn_Add.Enabled = opt.Permit(Permission.EditCollectionType);
            btn_Delete.Enabled = opt.Permit(Permission.EditCollectionType);
            btn_Export.Enabled = opt.Permit(Permission.ReadCollectionType);
            cMnu_Add.Enabled = opt.Permit(Permission.EditCollectionType);
            cMnu_Delete.Enabled = opt.Permit(Permission.EditCollectionType);
            cMnu_Export.Enabled = opt.Permit(Permission.ReadCollectionType);
        }
        #endregion
    }
}
                                                                         