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
using LJH.Inventory.BusinessModel.SearchCondition;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmPaymentAssign : Form
    {
        public FrmPaymentAssign()
        {
            InitializeComponent();
        }

        #region 私有方法
        private void ShowItemInGridViewRow(DataGridViewRow row, CustomerPayment item)
        {
            row.Tag = item;
            row.Cells["colID"].Value = item.ID;
            row.Cells["colPaidDate"].Value = item.PaidDate;
            row.Cells["colRemain"].Value = item.NotAssigned;
            row.Cells["colMemo"].Value = item.Memo;
        }

        private decimal GetTotalAssign(DataGridViewRow exceptRow)
        {
            decimal total = 0;
            foreach (DataGridViewRow row in GridView.Rows)
            {
                if (!object.ReferenceEquals(row, exceptRow) && row.Tag != null)
                {
                    DataGridViewCheckBoxCell chk = row.Cells["colCheck"] as DataGridViewCheckBoxCell;
                    if (chk.EditedFormattedValue != null && (bool)chk.EditedFormattedValue == true)
                    {
                        decimal assign = 0;
                        if (row.Cells["colAssign"].Value!=null && decimal.TryParse(row.Cells["colAssign"].Value.ToString(), out assign))
                        {
                            total += assign;
                        }
                    }
                }
            }
            return total;
        }

        private List<CustomerPaymentAssign> GetAllAssigns()
        {
            List<CustomerPaymentAssign> items = new List<CustomerPaymentAssign>();
            foreach (DataGridViewRow row in GridView.Rows)
            {
                if (row.Tag != null)
                {
                    CustomerPayment cp = row.Tag as CustomerPayment;
                    DataGridViewCheckBoxCell chk = row.Cells["colCheck"] as DataGridViewCheckBoxCell;
                    if (chk.EditedFormattedValue != null && (bool)chk.EditedFormattedValue == true)
                    {
                        decimal assign = 0;
                        if (row.Cells["colAssign"].Value!=null && decimal.TryParse(row.Cells["colAssign"].Value.ToString(), out assign))
                        {
                            CustomerPaymentAssign cpa = new CustomerPaymentAssign()
                            {
                                PaymentID = cp.ID,
                                ReceivableID = ReceivableID,
                                Amount = assign
                            };
                            items.Add(cpa);
                        }
                    }
                }
            }
            return items;
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取或设置支付的客户ID
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 获取或设置要支付的应收项ID
        /// </summary>
        public string ReceivableID { get; set; }
        /// <summary>
        /// 获取或设置支付的应收金额
        /// </summary>
        public decimal Receivables { get; set; }
        #endregion

        private void FrmPaymentAssign_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CustomerID))
            {
                txtReceivableID.Text = ReceivableID;
                txtReceivables.DecimalValue = Receivables;
                List<CustomerPayment> items = (new CustomerPaymentBLL(AppSettings.CurrentSetting.ConnectString)).GetAllRemains(CustomerID).QueryObjects;
                if (items != null && items.Count > 0)
                {
                    foreach (CustomerPayment item in items)
                    {
                        int row = GridView.Rows.Add();
                        ShowItemInGridViewRow(GridView.Rows[row], item);
                    }
                    int rowTotal = GridView.Rows.Add();
                    GridView.Rows[rowTotal].Cells["colPaidDate"].Value = "合计";
                    GridView.Rows[rowTotal].Cells["colRemain"].Value = items.Sum(item => item.NotAssigned);
                    GridView.Rows[0].Selected = false;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<CustomerPaymentAssign> assigns = GetAllAssigns();
            if (assigns != null && assigns.Count > 0)
            {
                CommandResult ret = (new CustomerPaymentBLL(AppSettings.CurrentSetting.ConnectString)).AssignPayment(assigns);
                if (ret.Result == ResultCode.Successful)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(ret.Message);
                }
            }
        }

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = GridView.Rows[e.RowIndex];
                if (GridView.Columns[e.ColumnIndex].Name == "colCheck" && row.Tag != null)
                {
                    DataGridViewCheckBoxCell chk = row.Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
                    if (chk.EditedFormattedValue != null && (bool)chk.EditedFormattedValue == true)
                    {
                        CustomerPayment cp = row.Tag as CustomerPayment;
                        decimal total = GetTotalAssign(row);
                        decimal assign = 0;
                        if (total < Receivables)
                        {
                            assign = Receivables - total;
                            if (assign > cp.NotAssigned) assign = cp.NotAssigned;
                        }
                        row.Cells["colAssign"].Value = assign;
                        GridView.Rows[GridView.Rows.Count - 1].Cells["colAssign"].Value = GetTotalAssign(null);
                    }
                    else
                    {
                        row.Cells["colAssign"].Value = null;
                    }
                }
            }
        }

        private void GridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && GridView.Rows[e.RowIndex].Tag != null)
            {
                if (GridView.Columns[e.ColumnIndex].Name == "colAssign" && GridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    decimal assign = 0;
                    decimal realAssign = 0;
                    if (decimal.TryParse(GridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out assign) && assign > 0)
                    {
                        CustomerPayment cp = GridView.Rows[e.RowIndex].Tag as CustomerPayment;
                        if (assign <= cp.NotAssigned)
                        {
                            decimal total = GetTotalAssign(GridView.Rows[e.RowIndex]);
                            if (total + assign <= Receivables)
                            {
                                realAssign = assign;
                            }
                        }
                    }
                    if (realAssign > 0)
                    {
                        GridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = realAssign;
                        GridView.Rows[GridView.Rows.Count - 1].Cells["colAssign"].Value = GetTotalAssign(null);
                    }
                    else
                    {
                        GridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                    }
                }
            }
        }
    }
}
