using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmSteelRollSelection : Form
    {
        public FrmSteelRollSelection()
        {
            InitializeComponent();
        }

        public List<ProductInventoryItem> SelectedItems { get; set; }

        private FrmSteelRollMaster _FrmSteelRoll = null;

        private void FrmSteelRollSelection_Load(object sender, EventArgs e)
        {
            _FrmSteelRoll = new FrmSteelRollMaster();
            var con = new ProductInventoryItemSearchCondition();
            con.HasRemain = true;
            con.States = (int)(ProductInventoryState.Inventory | ProductInventoryState.Reserved);
            _FrmSteelRoll.SearchCondition = con;
            this.ucFormViewMain.AddAForm(_FrmSteelRoll, false);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.SelectedItems = _FrmSteelRoll.SelectedItems;
            this.DialogResult = DialogResult.OK;
        }
    }
}
