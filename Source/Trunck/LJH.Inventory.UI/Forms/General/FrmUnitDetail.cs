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
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.General
{
    public partial class FrmUnitDetail :FrmDetailBase
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
                MessageBox.Show("名称不能为空");
                txtID.Focus();
                return false;
            }
            return true;
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            btnOk.Enabled = Operator.Current.Permit(Permission.Unit, PermissionActions.Edit);
        }

        protected override void ItemShowing()
        {
            Unit ct = UpdatingItem as Unit;
            txtID.Text = ct.ID;
            txtID.Enabled = false;
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
            ct.Name = txtID.Text;
            ct.Plural = txtID.Text;
            ct.Memo = txtMemo.Text;
            return ct;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            return (new UnitBLL(AppSettings.Current.ConnStr)).Add(addingItem as Unit);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            return (new UnitBLL(AppSettings.Current.ConnStr)).Update(updatingItem as Unit);
        }
        #endregion
    }
}
