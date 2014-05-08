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
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmPaymentAssign : Form
    {
        public FrmPaymentAssign()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置要分配的客户收款单号
        /// </summary>
        public string CustomerPaymentID { get; set; }
        #endregion

        #region 私有方法
        private void ShowReceivables(string customerID)
        {
            CompanyBLL bll = new CompanyBLL(AppSettings.Current.ConnStr);
            CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
            con.CustomerID = customerID;
            con.Settled = false;
            List<CustomerReceivable> items = (new CustomerReceivableBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                items = (from item in items orderby item.CreateDate ascending, item.SheetID ascending select item).ToList();
                foreach (CustomerReceivable cr in items)
                {
                    int row = GridView.Rows.Add();
                    ShowItemInGridViewRow(GridView.Rows[row], cr);
                }
            }
        }

        private void ShowItemInGridViewRow(DataGridViewRow row, CustomerReceivable cr)
        {
            row.Tag = cr;
            row.Cells["colSheetID"].Value = cr.SheetID;
            row.Cells["colCreateDate"].Value = cr.CreateDate.ToString("yyyy-MM-dd");
            row.Cells["colClassID"].Value = cr.ClassID;
            row.Cells["colRemain"].Value = cr.Remain;
            row.Cells["colAssign"].Value = 0;
            row.Cells["colMemo"].Value = cr.Memo;
        }

        private decimal GetAssignsFromGrid()
        {
            decimal ret = 0;
            foreach (DataGridViewRow row in GridView.Rows)
            {
                decimal temp = Convert.ToDecimal(row.Cells["colAssign"].Value);
                ret += temp;
            }
            return ret;
        }
        #endregion

        #region 事件处理程序
        private void FrmPaymentAssign_Load(object sender, EventArgs e)
        {
            CustomerPayment item = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetByID(CustomerPaymentID).QueryObject;
            if (item != null)
            {
                txtID.Text = item.ID;
                txtAmount.DecimalValue = item.Remain.Trim();
                txtRemain.DecimalValue = item.Remain.Trim();
                ShowReceivables(item.CustomerID);
            }
        }

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridView.Columns[e.ColumnIndex].Name == "colCheck")
            {
                DataGridViewCheckBoxCell chk = GridView.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
                if ((bool)chk.EditedFormattedValue)
                {
                    if (txtRemain.DecimalValue > 0)
                    {
                        decimal temp = Convert.ToDecimal(GridView.Rows[e.RowIndex].Cells["colRemain"].Value);
                        decimal assign = txtRemain.DecimalValue > temp ? temp : txtRemain.DecimalValue;
                        GridView.Rows[e.RowIndex].Cells["colAssign"].Value = assign;
                        GridView.Rows[e.RowIndex].Cells["colAssign"].Selected = true;
                        txtRemain.DecimalValue = txtAmount.DecimalValue - GetAssignsFromGrid();
                    }
                }
                else
                {
                    decimal temp = Convert.ToDecimal(GridView.Rows[e.RowIndex].Cells["colAssign"].Value);
                    GridView.Rows[e.RowIndex].Cells["colAssign"].Value = 0;
                    txtRemain.DecimalValue = txtAmount.DecimalValue - GetAssignsFromGrid();
                }
            }
        }

        private void GridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0 && GridView.Columns[e.ColumnIndex].Name == "colAssign")
            {
                DataGridViewCheckBoxCell chk = GridView.Rows[e.RowIndex].Cells["colCheck"] as DataGridViewCheckBoxCell;
                if (chk == null || !(bool)chk.EditedFormattedValue)
                {
                    e.Cancel = true;
                }
            }
        }

        private void GridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && GridView.Columns[e.ColumnIndex].Name == "colAssign")
            {
                if (GridView.Rows[e.RowIndex].Cells["colAssign"].Value == null)
                {
                    GridView.Rows[e.RowIndex].Cells["colAssign"].Value = 0;
                    return;
                }
                string temp = GridView.Rows[e.RowIndex].Cells["colAssign"].Value.ToString();
                decimal t = 0;
                if (decimal.TryParse(temp, out t))
                {
                    decimal allAssigned = GetAssignsFromGrid();
                    if (allAssigned > txtAmount.DecimalValue)
                    {
                        GridView.Rows[e.RowIndex].Cells["colAssign"].Value = 0;
                        txtRemain.DecimalValue = txtAmount.DecimalValue - GetAssignsFromGrid();
                        MessageBox.Show("分配的金额已经超出客户付款未分配额度");
                    }
                    else
                    {
                        txtRemain.DecimalValue = txtAmount.DecimalValue - allAssigned;
                    }
                }
                else
                {
                    MessageBox.Show("输入的内容不能转换成金额,请重新输入");
                    GridView.Rows[e.RowIndex].Cells["colAssign"].Value = 0;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool allSuccess = true;
            foreach (DataGridViewRow row in GridView.Rows)
            {
                DataGridViewCheckBoxCell chk = row.Cells["colCheck"] as DataGridViewCheckBoxCell;
                if ((bool)chk.EditedFormattedValue)
                {
                    decimal temp = Convert.ToDecimal(row.Cells["colAssign"].Value);
                    if (temp > 0)
                    {
                        CustomerPaymentAssign item = new CustomerPaymentAssign()
                        {
                            ID = Guid.NewGuid(),
                            PaymentID = CustomerPaymentID,
                            ReceivableID = (row.Tag as CustomerReceivable).ID,
                            Amount = temp,
                        };
                        CommandResult ret = (new CustomerPaymentAssignBLL(AppSettings.Current.ConnStr)).Assign(item);
                        row.Cells["colMemo"].Value = ret.Result == ResultCode.Successful ? "成功" : "失败";
                        if (ret.Result != ResultCode.Successful) allSuccess = false;
                    }
                }
                if (allSuccess) this.DialogResult = DialogResult.OK;
            }
        }
        #endregion
    }
}
