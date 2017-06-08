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
using LJH.Inventory.UI.Controls;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;
using LJH.GeneralLibrary;
using LJH.Inventory.UI.Forms.General;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmChangeCosts : Form
    {
        public FrmChangeCosts()
        {
            InitializeComponent();
        }

        public List<CostItem> Costs { get; set; }

        private void FrmChangeCosts_Load(object sender, EventArgs e)
        {
            if (Costs != null && Costs.Count > 0)
            {
                foreach (var ci in Costs)
                {
                    if (ci.Name == CostItem.入库单价)
                    {
                        txtPurchasePrice.DecimalValue = ci != null ? ci.Price : 0;
                        rdWithTax_入库单价.Checked = ci != null && ci.WithTax;
                        rdWithoutTax__入库单价.Checked = !rdWithTax_入库单价.Checked;
                    }
                    else if (ci.Name == CostItem.运费)
                    {
                        txtTransCost.DecimalValue = ci != null ? ci.Price : 0;
                        rdWithTax_运费.Checked = ci != null && ci.WithTax;
                        rdWithoutTax__运费.Checked = !rdWithTax_运费.Checked;
                        chkTransCostPrepay.Checked = ci != null && ci.Prepay;
                    }
                    else if (ci.Name == CostItem.其它费用)
                    {
                        txtOtherCost.DecimalValue = ci != null ? ci.Price : 0;
                        rdWithTax_其它费用.Checked = ci != null && ci.WithTax;
                        rdWithoutTax__其它费用.Checked = !rdWithTax_其它费用.Checked;
                        chkOtherCostPrepay.Checked = ci != null && ci.Prepay;
                    }
                }
            }
        }

        private void chk入库单价_CheckedChanged(object sender, EventArgs e)
        {
            txtPurchasePrice.Enabled = chk入库单价.Checked;
            pnlTax.Enabled = chk入库单价.Checked;
        }

        private void chk运费_CheckedChanged(object sender, EventArgs e)
        {
            txtTransCost.Enabled = chk运费.Checked;
            pnlTrans.Enabled = chk运费.Checked;
            chkTransCostPrepay.Enabled = chk运费.Checked;
        }

        private void chk其它费用_CheckedChanged(object sender, EventArgs e)
        {
            txtOtherCost.Enabled = chk其它费用.Checked;
            pnlOther.Enabled = chk其它费用.Checked;
            chkOtherCostPrepay.Enabled = chk其它费用.Checked;
        }

        private void btnOk1_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            Costs = new List<CostItem>();
            if (chk入库单价.Checked) Costs.Add(new CostItem() { Name = CostItem.入库单价, Price = txtPurchasePrice.DecimalValue, WithTax = rdWithTax_入库单价.Checked });
            if (chk运费.Checked) Costs.Add(new CostItem() { Name = CostItem.运费, Price = txtTransCost.DecimalValue, WithTax = rdWithTax_运费.Checked, Prepay = chkTransCostPrepay.Checked });
            if (chk其它费用.Checked) Costs.Add(new CostItem() { Name = CostItem.其它费用, Price = txtOtherCost.DecimalValue, WithTax = rdWithTax_其它费用.Checked, Prepay = chkOtherCostPrepay.Checked });
            if (Costs.Count == 0)
            {
                MessageBox.Show("请至少选择修改其中一种成本");
                return;
            }
            if (MessageBox.Show("修改入库价格会同时修改供应商的应收，是否继续?", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool CheckInput()
        {
            if (chk入库单价.Checked && txtPurchasePrice.DecimalValue > 0 && !rdWithoutTax__入库单价.Checked && !rdWithTax_入库单价.Checked)
            {
                MessageBox.Show("没有指定入库价格是否含税");
                return false;
            }
            if (chk运费.Checked && txtTransCost.DecimalValue > 0 && !rdWithTax_运费.Checked && !rdWithoutTax__运费.Checked)
            {
                MessageBox.Show("没有指定运费是否含税");
                return false;
            }
            if (chk其它费用.Checked && txtOtherCost.DecimalValue > 0 && !rdWithTax_其它费用.Checked && !rdWithoutTax__其它费用.Checked)
            {
                MessageBox.Show("没有指定其它费用是否含税");
                return false;
            }
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
