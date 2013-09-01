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
using LJH.Inventory.UI.Forms.Report;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmNotPurchaseItems : FrmMasterBase
    {
        public FrmNotPurchaseItems()
        {
            InitializeComponent();
        }

        #region 公共属性
        public string CustomerID { get; set; }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return null;
        }

        protected override List<object> GetDataSource()
        {
            OrderBLL bll = new OrderBLL(AppSettings.CurrentSetting.ConnectString);
            OrderSearchCondition con = new OrderSearchCondition();
            con.CustomerID = CustomerID;
            con.States = new List<SheetState>();
            con.States.Add(SheetState.Add);
            con.States.Add(SheetState.Approved);
            List<Order> items = bll.GetItems(con).QueryObjects;
            List<object> ret=new List<object> ();
            if (items != null && items.Count > 0)
            {
                foreach (Order o in items)
                {
                    foreach (OrderItem oi in o.Items)
                    {
                        if (!oi.IsComplete && oi.NotPurchased > 0)
                        {
                            ret.Add(oi);
                        }
                    }
                }
            }
            return ret;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            OrderItem c = item as OrderItem;
            row.Tag = c;
            row.Cells["colOrderID"].Value = c.OrderID;
            row.Cells["colProductName"].Value = c.Product.Name;
            row.Cells["colCount"].Value = c.Count.Trim();
            row.Cells["colDemandDate"].Value = c.DemandDate.ToLongDateString();
            row.Cells["colPrepared"].Value = (c.OnPurchase + c.Inventory).Trim();
            row.Cells["colNotPurchased"].Value = c.NotPurchased.Trim();
            row.Cells["colMemo"].Value = c.Memo;
        }
        #endregion
    }
}
