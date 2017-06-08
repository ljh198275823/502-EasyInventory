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
using LJH.Inventory.UI.Forms;
using LJH.Inventory.UI.Forms.General;
using LJH.Inventory.UI.Forms.Sale;
using LJH.GeneralLibrary;

namespace LJH.Inventory.UI.Forms.Inventory.Report
{
    public partial class FrmDeliveryStatistics : FrmReportBase
    {
        public FrmDeliveryStatistics()
        {
            InitializeComponent();
        }

        private List<CompanyInfo> _AllCustomers = null;

        decimal Amount = 0;
        decimal 产品成本 =0;
        decimal 国税计提 =0;
        decimal 毛利 = 0;

        #region 私有方法
        private List<StackOutSheet> GetItems()
        {
            StackOutSheetSearchCondition con = new StackOutSheetSearchCondition();
            con.SheetDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            con.States = new List<SheetState>() { SheetState.Shipped };
            con.SheetTypes = new List<StackOutSheetType>() { StackOutSheetType.DeliverySheet };
            if (txtCustomer.Tag != null) con.CustomerID = (txtCustomer.Tag as CompanyInfo).ID;
            List<StackOutSheet> items = (new StackOutSheetBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                return (from item in items
                        orderby item.SheetDate ascending
                        select item).ToList();
            }
            return null;
        }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            ucDateTimeInterval1.ShowTime = false;
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            base.Init();
        }

        protected override List<object> GetDataSource()
        {
            List<StackOutSheet> sheets = GetItems();
            if (sheets != null && sheets.Count > 0)
            {
                IEnumerable<IGrouping<string, StackOutSheet>> gps = null;
                if (rdBySheet.Checked)
                {
                    gridView.Columns["colName"].HeaderText = "送货单";
                    gps = sheets.GroupBy(item => item.ID);
                }
                else if (rdByCustomer.Checked)
                {
                    gridView.Columns["colName"].HeaderText = "客户";
                    gps = sheets.GroupBy(item => item.CustomerID);
                }
                else if (rdByNone.Checked)
                {
                    gridView.Columns["colName"].HeaderText = string.Empty;
                    gps = sheets.GroupBy(it => string.Empty);
                }
                return (from it in gps select (object)it).ToList();
            }
            return null;
        }

        protected override void ShowItemsOnGrid(List<object> items)
        {
            if (rdByCustomer.Checked) _AllCustomers = new CompanyBLL(AppSettings.Current.ConnStr).GetAllCustomers().QueryObjects;
            Amount = 0;
            产品成本 = 0;
            国税计提 = 0;
            毛利 = 0;
            base.ShowItemsOnGrid(items);
            lbl销售金额.Text = string.Format("销售金额：{0:C2}", Amount);
            lbl产品成本.Text = string.Format("产品成本：{0:C2}", 产品成本);
            lbl国税计提.Text = string.Format("国税计提：{0:C2}", 国税计提);
            if (产品成本 > 0) lbl毛利.Text = string.Format("毛    利：{0:C2}", 毛利);
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            IGrouping<string, StackOutSheet> gp = item as IGrouping<string, StackOutSheet>;
            CompanyInfo c = null;
            if (rdByCustomer.Checked) c = _AllCustomers.SingleOrDefault(it => it.ID == gp.Key);
            row.Cells["colName"].Value = c != null ? c.Name : gp.Key;
            row.Cells["colWeight"].Value = gp.Sum(it => it.TotalWeight);
            decimal d1 = gp.Sum(it => it.Amount).Trim();
            row.Cells["colAmount"].Value = d1;
            Amount += d1;
            decimal d2 = gp.Sum(it => it.Costs.HasValue ? it.Costs.Value : 0).Trim();
            row.Cells["colCost"].Value = d2;
            产品成本 += d2;
            decimal d3 = gp.Sum(it => it.WithTax ? it.Amount * UserSettings.Current.国税系数 : 0);
            row.Cells["col国税计提"].Value = d3;
            国税计提 += d3;
            if (d2 > 0)
            {
                row.Cells["colProfit"].Value = (d1 - d2 - d3).Trim();
                row.Cells["colProfitRate"].Value = ((d1 - d2 - d3) / d2).ToString("P3");
                毛利 += (d1 - d2 - d3);
            }
            else
            {
                row.Cells["colProfit"].Value = "---";
                row.Cells["colProfitRate"].Value = "---";
            }
        }
        #endregion

        #region 事件处理程序
        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerMaster frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CompanyInfo customer = frm.SelectedItem as CompanyInfo;
                txtCustomer.Text = customer != null ? customer.Name : string.Empty;
                txtCustomer.Tag = customer;
            }
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            txtCustomer.Text = string.Empty;
            txtCustomer.Tag = null;
        }
        #endregion
    }
}
