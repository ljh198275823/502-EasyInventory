using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.UI.Forms;
using LJH.GeneralLibrary;
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
        protected override void Init()
        {
            this.ucDateTimeInterval1.ShowTime = false;
            this.ucDateTimeInterval1.Init();
            this.ucDateTimeInterval1.SelectThisMonth();
            base.Init();
        }

        protected override List<object> GetDataSource()
        {
            List<object> items = null;
            StackOutSheetSearchCondition con = new StackOutSheetSearchCondition();
            con.LastActiveDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            con.States = new List<SheetState>();
            con.States.Add(SheetState.Shipped);
            List<StackOutSheet> sheets = (new StackOutSheetBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;

            var salesGroup = sheets.GroupBy(item => item.SalesPerson);
            foreach (var group in salesGroup)
            {
                IEnumerable<IGrouping<string, StackOutSheet>> gs = null;
                if (rdByDay.Checked)
                {
                    gs = group.GroupBy(item => item.LastActiveDate.ToString("yyyy-MM-dd"));
                }
                if (rdByMonth.Checked)
                {
                    gs = group.GroupBy(item => item.LastActiveDate.ToString("yyyy-MM"));
                }
                if (rdByYear.Checked)
                {
                    gs = group.GroupBy(item => item.LastActiveDate.ToString("yyyy"));
                }
                foreach (var g in gs)
                {
                    if (!string.IsNullOrEmpty(group.Key))
                    {
                        if (items == null) items = new List<object>();
                        GroupData gd = new GroupData() { Key = g.Key, Group = g };
                        items.Add(gd);
                    }
                }
            }
            return items;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            GroupData gd = item as GroupData;
            row.Cells["colDeliveryDate"].Value = gd.Group.Key;
            row.Cells["colSalesPerson"].Value = gd.Key;
            decimal d1;
            d1 = gd.Group.Sum(it => it.Amount).Trim();
            //d2 = g.Sum(it => it.Cost).Trim();
            row.Cells["colAmount"].Value = d1;
            //row.Cells["colCost"].Value = d2;
            //row.Cells["colProfitRate"].Value = ((d1 - d2) / d1).ToString("F3");
            //d2 = g.Sum(it => it.Paid);
            //row.Cells["colPaid"].Value = d2;
            //row.Cells["colPaidRate"].Value = (d2 / d1).ToString("F3");
        }
        #endregion

        private class GroupData
        {
            public string Key { get; set; }
            public IGrouping<string, StackOutSheet> Group { get; set; }
        }
    }
}
