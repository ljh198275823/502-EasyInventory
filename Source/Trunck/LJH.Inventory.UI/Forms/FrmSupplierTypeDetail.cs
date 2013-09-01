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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmSupplierTypeDetail : FrmDetailBase
    {
        public FrmSupplierTypeDetail()
        {
            InitializeComponent();
        }

        #region 重写基类方法
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
            txtMemo.Text = ct.Memo;
        }

        protected override Object GetItemFromInput()
        {
            SupplierType ct = UpdatingItem as SupplierType;
            if (IsAdding)
            {
                ct = new SupplierType();
            }
            ct.ID = txtName.Text;
            ct.Name = txtName.Text;
            ct.Memo = txtMemo.Text;
            return ct;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            return (new SupplierTypeBLL(AppSettings.CurrentSetting.ConnectString)).Add(addingItem as SupplierType);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            return (new SupplierTypeBLL(AppSettings.CurrentSetting.ConnectString)).Update(updatingItem as SupplierType);
        }
        #endregion
    }
}
