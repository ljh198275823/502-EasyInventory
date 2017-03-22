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

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmChangeWareHouse : Form
    {
        public FrmChangeWareHouse()
        {
            InitializeComponent();
        }

        public ProductInventoryItem ProductInventory { get; set; }

        private void FrmChangeWareHouse_Load(object sender, EventArgs e)
        {
            if (ProductInventory != null)
            {
                var ws = new WareHouseBLL(AppSettings.Current.ConnStr).GetByID(ProductInventory.WareHouseID).QueryObject;
                txtOriginalWare.Text = ws != null ? ws.Name : ProductInventory.WareHouseID;
            }
        }

        private void lnkWareHouse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmWareHouseMaster frm = new FrmWareHouseMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtWareHouse.Text = (frm.SelectedItem as WareHouse).Name;
                txtWareHouse.Tag = frm.SelectedItem;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtWareHouse.Tag == null || (txtWareHouse.Tag as WareHouse).ID == ProductInventory.WareHouseID)
            {
                MessageBox.Show("没有选择新仓库");
                return;
            }
            var ret = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).UpdateWareHouse(ProductInventory, txtWareHouse.Tag as WareHouse);
            if (ret.Result == LJH.GeneralLibrary.Core.DAL.ResultCode.Successful) this.DialogResult = DialogResult.OK;
            else MessageBox.Show(ret.Message);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
