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
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmSupplierTypeDetail : FrmDetailBase
    {
        public FrmSupplierTypeDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置父类别
        /// </summary>
        public SupplierType ParentCategory { get; set; }
        #endregion

        #region 重写基类方法
        protected override void InitControls()
        {
            base.InitControls();
            txtParentCategory.Text = ParentCategory != null ? ParentCategory.Name : string.Empty;
            btnOk.Enabled = Operator.Current.Permit(Permission.EditSupplier);
        }

        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("名称不能为空");
                txtName.Focus();
                return false;
            }
            return true;
        }

        protected override void ItemShowing()
        {
            SupplierType ct = UpdatingItem as SupplierType;
            txtName.Text = ct.Name;
            if (!string.IsNullOrEmpty(ct.Parent))
            {
                ParentCategory = (new SupplierTypeBLL(AppSettings.Current.ConnStr)).GetByID(ct.Parent).QueryObject;
            }
            txtParentCategory.Text = ParentCategory != null ? ParentCategory.Name : string.Empty;
            txtMemo.Text = ct.Memo;
        }

        protected override Object GetItemFromInput()
        {
            SupplierType ct = UpdatingItem as SupplierType;
            if (IsAdding)
            {
                ct = new SupplierType();
                ct.ID = txtName.Text;
            }
            ct.Name = txtName.Text;
            ct.Parent = ParentCategory != null ? ParentCategory.ID : null;
            ct.Memo = txtMemo.Text;
            return ct;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            return (new SupplierTypeBLL(AppSettings.Current.ConnStr)).Add(addingItem as SupplierType);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            return (new SupplierTypeBLL(AppSettings.Current.ConnStr)).Update(updatingItem as SupplierType);
        }
        #endregion

        private void lnkParentCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSupplierTypeMaster frm = new FrmSupplierTypeMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ParentCategory = frm.SelectedItem as SupplierType;
                this.txtParentCategory.Text = ParentCategory.Name;
            }
        }
    }
}
