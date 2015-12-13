using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory .BLL ;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmSteelRollSliceCheck : Form
    {
        public FrmSteelRollSliceCheck()
        {
            InitializeComponent();
        }

        #region 公共属性
        public ProductInventoryItem ProductInventory { get; set; }
        #endregion

        #region 事件处理程序
        private void FrmInvnetoryCheck_Load(object sender, EventArgs e)
        {
            if (ProductInventory != null)
            {
                txtInventory.DecimalValue = ProductInventory.Count;
                txtCheckCount.Focus();
                txtCheckCount.SelectAll();
            }
            btnOk.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Check);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtChecker.Text))
            {
                MessageBox.Show("没有指定盘点人员");
                return;
            }
            if (txtCheckCount.DecimalValue < 0)
            {
                MessageBox.Show("盘点数量不能为负数");
                return;
            }
            CommandResult ret = (new SteelRollSliceBLL(AppSettings.Current.ConnStr)).Check(ProductInventory, txtCheckCount.DecimalValue, txtChecker.Text, txtMemo.Text);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message, "失败");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkChecker_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.General.FrmStaffMaster frm = new Forms.General.FrmStaffMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Staff item = frm.SelectedItem as Staff;
                txtChecker.Text = item != null ? item.Name : string.Empty;
            }
        }
        #endregion
    }
}
