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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmProductCategoryMaster :FrmMasterBase 
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
            ProductCategoryBLL bll = new ProductCategoryBLL(AppSettings.CurrentSetting.ConnectString);
            List<ProductCategory> items = bll.GetAll().QueryObjects;
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
            ProductCategoryBLL bll = new ProductCategoryBLL(AppSettings.CurrentSetting.ConnectString);
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
            OperatorInfo opt = OperatorInfo.CurrentOperator;
            menu.Items["btn_Add"].Enabled = opt.Permit(Permission.EditProductCategory);
            menu.Items["btn_Delete"].Enabled = opt.Permit(Permission.EditProductCategory);
        }
        #endregion
    }
}
