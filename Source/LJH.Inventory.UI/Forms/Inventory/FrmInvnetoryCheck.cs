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
    public partial class FrmInvnetoryCheck : Form
    {
        public FrmInvnetoryCheck()
        {
            InitializeComponent();
        }

        #region 公共属性
        public SteelRollSlice ProductInventory { get; set; }
        #endregion

        #region 事件处理程序
        private void FrmInvnetoryCheck_Load(object sender, EventArgs e)
        {
            if (ProductInventory != null)
            {
                txtProduct.Text = ProductInventory.Product.Name;
                txtWarehouse.Text = ProductInventory.WareHouse.Name;
                txtInventory.DecimalValue = ProductInventory.Count;
                txtCheckCount.DecimalValue = ProductInventory.Count;
                txtCheckCount.Focus();
                txtCheckCount.SelectAll();
            }
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
            InventoryCheckRecord record = new InventoryCheckRecord();
            record.ID = Guid.NewGuid();
            record.ProductID = ProductInventory.ProductID;
            record.WarehouseID = ProductInventory.WareHouseID;
            record.Unit = ProductInventory.Unit;
            record.Price = ProductInventory.Product.Cost;
            record.CheckDateTime = DateTime.Now;
            record.Inventory = ProductInventory.Count;
            record.CheckCount = txtCheckCount.DecimalValue;
            record.Checker = txtChecker.Text;
            record.Operator = Operator.Current.Name;
            record.Memo = txtMemo.Text;
            CommandResult ret = (new InventoryCheckRecordBLL(AppSettings.Current.ConnStr)).Add(record);
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

        private void txtChecker_DoubleClick(object sender, EventArgs e)
        {
            txtChecker.Text = string.Empty;
        }
        #endregion
    }
}
