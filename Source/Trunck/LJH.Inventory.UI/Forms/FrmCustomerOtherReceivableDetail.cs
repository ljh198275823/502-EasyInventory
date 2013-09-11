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
using LJH.Inventory.BLL;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmCustomerOtherReceivableDetail : FrmDetailBase
    {
        public FrmCustomerOtherReceivableDetail()
        {
            InitializeComponent();
        }

        #region 私有方法
        private void ShowOperations(string sheetNo)
        {
            dataGridView1.Rows.Clear();
            List<DocumentOperation> items = (new CustomerOtherReceivableBLL(AppSettings.CurrentSetting.ConnectString)).GetHisOperations(sheetNo).QueryObjects;
            items = (from item in items
                     orderby item.OperatDate ascending
                     select item).ToList();
            foreach (DocumentOperation item in items)
            {
                int row = dataGridView1.Rows.Add();
                dataGridView1.Rows[row].Cells["colOperateDate"].Value = item.OperatDate;
                dataGridView1.Rows[row].Cells["colOperation"].Value = item.Operation;
                dataGridView1.Rows[row].Cells["colOperator"].Value = item.Operator;
            }
        }
        #endregion

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (txtCustomer.Tag == null)
            {
                MessageBox.Show("客户不能为空");
                txtCustomer.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCurrencyType.Text))
            {
                MessageBox.Show("没有选择相应的币别");
                return false;
            }
            if (txtAmount.DecimalValue <= 0)
            {
                MessageBox.Show("金额不正确");
                txtAmount.Focus();
                return false;
            }
            return true;
        }

        protected override void ItemShowing()
        {
            CustomerOtherReceivable cor = UpdatingItem as CustomerOtherReceivable;
            if (cor != null)
            {
                this.txtID.Text = cor.ID;
                this.txtID.Enabled = false;
                dtCreateDate.Value = cor.CreateDate;
                txtCurrencyType.Text = cor.CurrencyType;
                txtAmount.DecimalValue = cor.Amount;
                txtCustomer.Text = cor.Customer != null ? cor.Customer.Name : string.Empty;
                txtCustomer.Tag = cor.Customer;
                txtMemo.Text = cor.Memo;
                ShowOperations(cor.ID);
                ShowButtonState();
            }
        }

        protected override object GetItemFromInput()
        {
            CustomerOtherReceivable info = null;
            if (UpdatingItem == null)
            {
                info = new CustomerOtherReceivable();
            }
            else
            {
                info = UpdatingItem as CustomerOtherReceivable;
            }
            if (txtID.Text == _AutoCreate) info.ID = string.Empty;
            info.CreateDate = dtCreateDate.Value;
            info.CurrencyType = txtCurrencyType.Text;
            info.Amount = txtAmount.DecimalValue;
            info.Customer = txtCustomer.Tag as Customer;
            info.CustomerID = info.Customer.ID;
            info.Memo = txtMemo.Text;
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            CustomerOtherReceivableBLL bll = new CustomerOtherReceivableBLL(AppSettings.CurrentSetting.ConnectString);
            return bll.Add(item as CustomerOtherReceivable, OperatorInfo.CurrentOperator.OperatorName);
        }

        protected override CommandResult UpdateItem(object item)
        {
            return null;
        }

        protected override void ShowButtonState()
        {
            this.btnOk.Enabled = UpdatingItem == null; 
        }
        #endregion

        #region 事件处理程序
        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerMaster frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Customer item = frm.SelectedItem as Customer;
                txtCustomer.Text = item.Name;
                txtCustomer.Tag = item;
            }
        }

        private void lnkCurrencyType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCurrencyTypeMaster frm = new FrmCurrencyTypeMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CurrencyType item = frm.SelectedItem as CurrencyType;
                txtCurrencyType.Text = item.ID;
            }
        }
        #endregion
    }
}
