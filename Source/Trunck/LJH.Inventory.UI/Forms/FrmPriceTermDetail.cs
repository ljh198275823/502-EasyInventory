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
    public partial class FrmPriceTermDetail :FrmDetailBase 
    {
        public FrmPriceTermDetail()
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
            PriceTerm ct = UpdatingItem as PriceTerm;
            txtName.Text = ct.Name;
            txtMemo.Text = ct.Memo;
        }

        protected override Object GetItemFromInput()
        {
            PriceTerm ct = UpdatingItem as PriceTerm;
            if (IsAdding)
            {
                ct = new PriceTerm();
                ct.ID = txtName.Text;
            }
            ct.Name = txtName.Text;
            ct.Memo = txtMemo.Text;
            return ct;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            return (new PriceTermBLL(AppSettings.CurrentSetting.ConnStr)).Add(addingItem as PriceTerm);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            return (new PriceTermBLL(AppSettings.CurrentSetting.ConnStr)).Update(updatingItem as PriceTerm);
        }
        #endregion
    }
}
