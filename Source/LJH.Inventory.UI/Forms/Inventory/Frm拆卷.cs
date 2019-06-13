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
    public partial class Frm拆卷 : Form
    {
        public Frm拆卷()
        {
            InitializeComponent();
        }

        public ProductInventoryItem SteelRoll { get; set; }

        public ProductInventoryItem NewRoll { get; set; }

        private void Frm拆卷_Load(object sender, EventArgs e)
        {
            if (SteelRoll != null)
            {
                txtNewWeigth.MaxValue = SteelRoll.Weight.Value;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtNewWeigth.DecimalValue > 0)
            {
                ProductInventoryItem newR;
                var ret = new SteelRollBLL(AppSettings.Current.ConnStr).拆卷(SteelRoll, txtNewWeigth.DecimalValue, txtMemo.Text, out newR);
                if (ret.Result == LJH.GeneralLibrary.Core.DAL.ResultCode.Successful)
                {
                    NewRoll = newR;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(ret.Message);
                }
            }
        }
    }
}
