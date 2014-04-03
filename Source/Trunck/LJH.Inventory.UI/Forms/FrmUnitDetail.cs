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
    public partial class FrmUnitDetail : FrmDetailBase 
    {
        public FrmUnitDetail()
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
            if (string.IsNullOrEmpty(txtPlural.Text))
            {
                MessageBox.Show("复数不能为空");
                txtPlural.Focus();
                return false;
            }
            return true;
        }

        protected override void ItemShowing()
        {
            Unit ct = UpdatingItem as Unit;
            txtID.Text = ct.ID;
            txtID.Enabled = false;
            txtName.Text = ct.Name;
            txtPlural.Text = ct.Plural ;
            txtMemo.Text = ct.Memo;
        }

        protected override Object GetItemFromInput()
        {
            Unit ct = UpdatingItem as Unit;
            if (IsAdding)
            {
                ct = new Unit();
            }
            ct.ID = txtID.Text;
            ct.Name = txtName.Text;
            ct.Plural  = txtPlural.Text;
            ct.Memo = txtMemo.Text;
            return ct;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            return (new UnitBLL(AppSettings.CurrentSetting.ConnStr)).Add(addingItem as Unit);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            return (new UnitBLL(AppSettings.CurrentSetting.ConnStr)).Update(updatingItem as Unit);
        }
        #endregion
    }
}
