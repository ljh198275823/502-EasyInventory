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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmWareHouseMaster :FrmMasterBase 
    {
        public FrmWareHouseMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法及事件处理
        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmWareHouseDetail();
        }

        protected override bool DeletingItem(object item)
        {
            WareHouse info = item as WareHouse;
            CommandResult result = (new WareHouseBLL(AppSettings.Current.ConnStr)).Delete(info);
            if (result.Result != ResultCode.Successful)
            {
                MessageBox.Show(result.Message, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return result.Result == ResultCode.Successful;
        }

        protected override List<object> GetDataSource()
        {
            WareHouseBLL bll = new WareHouseBLL(AppSettings.Current.ConnStr);
            List<WareHouse> ret = bll.GetItems(null).QueryObjects.ToList();
            List<object> source = new List<object>();
            foreach (object o in ret)
            {
                source.Add(o);
            }
            return source;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            WareHouse info = item as WareHouse;
            row.Tag = item;
            row.Cells["colImage"].Value = Properties.Resources.warehouse;
            row.Cells["colID"].Value = info.ID;
            row.Cells["colName"].Value = info.Name;
            row.Cells["colMemo"].Value = info.Memo;
        }

        protected override void Init()
        {
            base.Init();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.WareHouse, PermissionActions.Edit);
            cMnu_Delete.Enabled = Operator.Current.Permit(Permission.WareHouse, PermissionActions.Edit);
        }
        #endregion
    }
}
