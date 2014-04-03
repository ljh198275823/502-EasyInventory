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

namespace LJH.Inventory.UI.Report
{
    public partial class FrmSalesPersonPerformanceReport : FrmReportBase 
    {
        public FrmSalesPersonPerformanceReport()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override void OnItemSearching(EventArgs e)
        {
            DeliverySheetSearchCondition con = new DeliverySheetSearchCondition();
            con.DeliveryDateTime = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            con.States = new List<int>();
            con.States.Add((int)SheetState.Shipped);
            List<DeliverySheet> sheets = (new DeliverySheetBLL(AppSettings.CurrentSetting.ConnStr)).GetItems(con).QueryObjects;

            var salesGroup = sheets.GroupBy(item => item.SalesPerson);
            foreach (var group in salesGroup)
            {
                IEnumerable<IGrouping<string, DeliverySheet>> gs = null;
                //if (rdByDay.Checked)
                //{
                //    gs = group.GroupBy(item => item.DeliveryDate.Value.ToString("yyyy-MM-dd"));
                //}
                //if (rdByMonth.Checked)
                //{
                //    gs = group.GroupBy(item => item.DeliveryDate.Value.ToString("yyyy-MM"));
                //}
                //if (rdByYear.Checked)
                //{
                //    gs = group.GroupBy(item => item.DeliveryDate.Value.ToString("yyyy"));
                //}
                foreach (var g in gs)
                {
                    if (!string.IsNullOrEmpty(group.Key))
                    {
                        int row = gridView.Rows.Add();
                        gridView.Rows[row].Cells["colDeliveryDate"].Value = g.Key;
                        gridView.Rows[row].Cells["colSalesPerson"].Value = group.Key;
                        decimal d1;
                        d1 = g.Sum(it => it.Amount).Trim();
                        //d2 = g.Sum(it => it.Cost).Trim();
                        gridView.Rows[row].Cells["colAmount"].Value = d1;
                        //gridView.Rows[row].Cells["colCost"].Value = d2;
                        //gridView.Rows[row].Cells["colProfitRate"].Value = ((d1 - d2) / d1).ToString("F3");
                        //d2 = g.Sum(it => it.Paid);
                        //gridView.Rows[row].Cells["colPaid"].Value = d2;
                        //gridView.Rows[row].Cells["colPaidRate"].Value = (d2 / d1).ToString("F3");
                    }
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            this.ucDateTimeInterval1.Init();
            this.ucDateTimeInterval1.SelectThisMonth();
        }
        #endregion
    }
}
