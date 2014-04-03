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
    public partial class FrmCurrencyTypeDetail : FrmDetailBase
    {
        public FrmCurrencyTypeDetail()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("ID不能为空");
                txtID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("名称不能为空");
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSymbol.Text))
            {
                MessageBox.Show("符号不能为空");
                txtSymbol.Focus();
                return false;
            }
            return true;
        }

        protected override void ItemShowing()
        {
            CurrencyType ct = UpdatingItem as CurrencyType;
            txtID.Text = ct.ID;
            txtID.Enabled = false;
            txtName.Text = ct.Name;
            txtSymbol.Text = ct.Symbol;
            txtExchangeRate.DecimalValue = ct.ExchangeRate;
            txtMemo.Text = ct.Memo;
        }

        protected override Object GetItemFromInput()
        {
            CurrencyType ct = UpdatingItem as CurrencyType;
            if (IsAdding)
            {
                ct = new CurrencyType();
            }
            ct.ID = txtID.Text;
            ct.Name = txtName.Text;
            ct.Symbol = txtSymbol.Text;
            ct.ExchangeRate = txtExchangeRate.DecimalValue;
            ct.Memo = txtMemo.Text;
            return ct;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            return (new CurrencyTypeBLL(AppSettings.CurrentSetting.ConnStr)).Add(addingItem as CurrencyType);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            return (new CurrencyTypeBLL(AppSettings.CurrentSetting.ConnStr)).Update(updatingItem as CurrencyType);
        }
        #endregion
    }
}
