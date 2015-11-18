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
using LJH.Inventory.UI.Controls;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;
using LJH.Inventory.UI.Forms.General;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmSteelRollSliceDetail : FrmDetailBase
    {
        public FrmSteelRollSliceDetail()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (txtCategory.Tag == null)
            {
                MessageBox.Show("没有选择类别");
                return false;
            }
            if (txtWareHouse.Tag == null)
            {
                MessageBox.Show("没有选择仓库");
                txtWareHouse.Focus();
                return false;
            }
            if (txtLength.DecimalValue == 0 && txtWeight.DecimalValue == 0)
            {
                MessageBox.Show("至少要指定小件的长度或重量中的一项");
                return false;
            }
            if (txtCount.DecimalValue == 0)
            {
                MessageBox.Show("库存数量没有填写");
                txtCount.Focus();
                return false;
            }
            return true;
        }

        protected override void InitControls()
        {
            base.InitControls();
            cmbSpecification.Init();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            btnOk.Enabled = Operator.Current.Permit(Permission.ProductInventory, PermissionActions.Edit);
        }

        protected override void ItemShowing()
        {
            SteelRollSlice item = UpdatingItem as SteelRollSlice;
            cmbSpecification.Text = item.Product.Specification;
            txtCategory.Text = item.Product.Category.Name;
            txtCategory.Tag = item.Product.Category;
            rdToPanel.Checked = item.Product.Model == "开平";
            rdToRoll.Checked = item.Product.Model == "开卷";
            rdToWeight.Checked = item.Product.Model == "开吨";
            txtLength.DecimalValue = item.Product.Length.HasValue ? item.Product.Length.Value : 0;
            txtWeight.DecimalValue = item.Product.Weight.HasValue ? item.Product.Weight.Value : 0;
            txtPrice.Visible = false;
            lblPrice.Visible = false;
            txtCount.DecimalValue = item.Count;
            txtWareHouse.Text = item.WareHouse.Name;
            txtWareHouse.Tag = item.WareHouse;
            txtWareHouse.Enabled = false;
            lnkWarehouse.Enabled = false;
            btnOk.Enabled = false;
        }

        protected override object GetItemFromInput()
        {
            SteelRollSlice item = null;
            if (UpdatingItem == null)
            {
                string sliceTo = null;
                if (rdToPanel.Checked) sliceTo = rdToPanel.Text;
                else if (rdToRoll.Checked) sliceTo = rdToRoll.Text;
                else if (rdToWeight.Checked) sliceTo = rdToWeight.Text;
                Product p = new ProductBLL(AppSettings.Current.ConnStr).Create((txtCategory.Tag as ProductCategory).ID,
                                                                                  StringHelper.ToDBC(cmbSpecification.Text).Trim(),
                                                                                  sliceTo,
                                                                                  txtWeight.DecimalValue != 0 ? (decimal?)txtWeight.DecimalValue : null,
                                                                                  txtLength.DecimalValue != 0 ? (decimal?)txtLength.DecimalValue : null, 7.85m);
                if (p != null)
                {
                    item = new SteelRollSlice();
                    item.ID = Guid.NewGuid();
                    item.Product = p;
                    item.WareHouse = txtWareHouse.Tag as WareHouse;
                    item.Valid = txtCount.DecimalValue;
                    item.ValidAmount = txtCount.DecimalValue * txtPrice.DecimalValue;
                }
            }
            else
            {
                item = UpdatingItem as SteelRollSlice;
            }
            return item;
        }

        protected override CommandResult AddItem(object item)
        {
            if (item != null)
            {
                SteelRollSliceBLL bll = new SteelRollSliceBLL(AppSettings.Current.ConnStr);
                return bll.CreateInventory(item as SteelRollSlice, Operator.Current.Name, txtMemo.Text);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "创建产品信息失败");
            }
        }

        protected override CommandResult UpdateItem(object item)
        {
            return new CommandResult(ResultCode.Fail, "库存项不能进行更新操作");
        }
        #endregion

        #region 事件处理程序
        private void rdSliceType_CheckedChanged(object sender, EventArgs e)
        {
            txtLength.Enabled = !rdToWeight.Checked;
            txtWeight.Enabled = rdToWeight.Checked;
        }

        private void lnkCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmProductCategoryMaster frm = new FrmProductCategoryMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var c = frm.SelectedItem as ProductCategory;
                txtCategory.Text = c != null ? c.Name : string.Empty;
                txtCategory.Tag = c;
            }
        }

        private void lnkWarehouse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmWareHouseMaster frm = new FrmWareHouseMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                WareHouse w = frm.SelectedItem as WareHouse;
                txtWareHouse.Text = w != null ? w.Name : string.Empty;
                txtWareHouse.Tag = w;
            }
        }
        #endregion
        
    }
}
