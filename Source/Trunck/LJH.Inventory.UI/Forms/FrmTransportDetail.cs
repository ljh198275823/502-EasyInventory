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
    public partial class FrmTransportDetail : FrmDetailBase
    {
        public FrmTransportDetail()
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
            Transport ct = UpdatingItem as Transport;
            txtName.Text = ct.Name;
            txtMemo.Text = ct.Memo;
        }

        protected override Object GetItemFromInput()
        {
            Transport ct = UpdatingItem as Transport;
            if (IsAdding)
            {
                ct = new Transport();
                ct.ID = txtName.Text;
            }
            ct.Name = txtName.Text;
            ct.Memo = txtMemo.Text;
            return ct;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            return (new TransportBLL(AppSettings.CurrentSetting.ConnStr)).Add(addingItem as Transport);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            return (new TransportBLL(AppSettings.CurrentSetting.ConnStr)).Update(updatingItem as Transport);
        }
        #endregion
    }
}
