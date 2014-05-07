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
    public partial class FrmProductCategoryMaster : FrmMasterBase
    {
        public FrmProductCategoryMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmProductCategoryDetail();
        }

        protected override List<object> GetDataSource()
        {
            ProductCategoryBLL bll = new ProductCategoryBLL(AppSettings.Current.ConnStr);
            List<ProductCategory> items = null;
            if (SearchCondition == null)
            {
                items = bll.GetItems(null).QueryObjects;
            }
            else
            {
                items = bll.GetItems(SearchCondition).QueryObjects;
            }
            return items.Select(p => (object)p).ToList();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            ProductCategory p = item as ProductCategory;
            row.Cells["colImage"].Value = Properties.Resources.category;
            row.Cells["colID"].Value = p.ID;
            row.Cells["colName"].Value = p.Name;
            row.Cells["colPrefix"].Value = p.Prefix;
            row.Cells["colMemo"].Value = p.Memo;
            row.Tag = item;
        }
        protected override bool DeletingItem(object item)
        {
            ProductCategoryBLL bll = new ProductCategoryBLL(AppSettings.Current.ConnStr);
            CommandResult ret = bll.Delete(item as ProductCategory);
            if (ret.Result == ResultCode.Successful)
            {
                return true;
            }
            else
            {
                MessageBox.Show(ret.Message);
                return false;
            }
        }

        protected override void Init()
        {
            base.Init();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            this.btn_Add.Enabled = Operator.Current.Permit(Permission.ProductCategory, PermissionActions.Edit);
            this.btn_Delete.Enabled = Operator.Current.Permit(Permission.ProductCategory, PermissionActions.Edit);
            this.cMnu_Add.Enabled = Operator.Current.Permit(Permission.ProductCategory, PermissionActions.Edit);
            this.cMnu_Delete.Enabled = Operator.Current.Permit(Permission.ProductCategory, PermissionActions.Edit);
        }
        #endregion
    }
}
