﻿using System;
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
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.UI.View;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Sale
{
    public partial class FrmOrderItemRecordMaster : FrmMasterBase
    {
        public FrmOrderItemRecordMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<OrderItemRecord> _Records = null;
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> objs = FilterData();
            ShowItemsOnGrid(objs);
        }

        private List<object> FilterData()
        {
            List<OrderItemRecord> items = _Records;
            if (this.customerTree1.SelectedNode != null)
            {
                List<CompanyInfo> pcs = null;
                pcs = this.customerTree1.GetCompanyofNode(this.customerTree1.SelectedNode);
                if (pcs != null && pcs.Count > 0)
                {
                    items = items.Where(it => pcs.Exists(c => c.ID == it.CustomerID)).ToList();
                }
                else
                {
                    items = null;
                }
            }
            if (items != null && items.Count > 0)
            {
                items = items.Where(item => ((item.State == SheetState.Add && chkAdded.Checked) ||
                                        (item.State == SheetState.Approved && chkApproved.Checked) ||
                                        (item.State == SheetState.Canceled && chkNullify.Checked))).ToList();
            }
            if (items != null && items.Count > 0)
            {
                items = items.Where(item => ((item.Shipped == 0 && chkNoneShipped.Checked) ||
                                             (item.Shipped > 0 && item.NotShipped > 0 && chkPatialShipped.Checked) ||
                                             (item.NotShipped == 0 && chkAllShipped.Checked))).ToList();
            }
            List<object> objs = null;
            if (items != null && items.Count > 0) objs = (from item in items orderby item.SheetNo descending select (object)item).ToList();
            return objs;
        }
        #endregion

        #region 重写基类方法和处理事件
        protected override void Init()
        {
            base.Init();
            this.customerTree1.Init();
            Operator opt = Operator.Current;
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmOrderDetail();
        }

        protected override List<object> GetDataSource()
        {
            if (SearchCondition == null)
            {
                OrderItemRecordSearchCondition con = new OrderItemRecordSearchCondition();
                con.OrderDate = new DateTimeRange(DateTime.Today.AddYears(-1), DateTime.Now); //获取最后一年产生的订单
                SearchCondition = con;
            }
            _Records = (new OrderBLL(AppSettings.Current.ConnStr)).GetRecords(SearchCondition).QueryObjects;
            return FilterData();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            OrderItemRecord info = item as OrderItemRecord;
            row.Tag = info;
            row.Cells["colOrderID"].Value = info.SheetNo;
            row.Cells["colOrderDate"].Value = info.OrderDate;
            row.Cells["colCustomer"].Value = info.Customer.Name;
            row.Cells["colProduct"].Value = info.Product != null ? info.Product.Name : info.ProductID;
            row.Cells["colUnit"].Value = info.Unit;
            row.Cells["colSales"].Value = info.SalesPerson;
            row.Cells["colDemandDate"].Value = info.DemandDate;
            row.Cells["colCount"].Value = info.Count.Trim();
            row.Cells["colState"].Value = row.Cells["colState"].Value = SheetStateDescription.GetDescription(info.State);
            row.Cells["colOnWay"].Value = info.OnWay.Trim();
            row.Cells["colInventory"].Value = info.Inventory.Trim();
            row.Cells["colShipped"].Value = info.Shipped.Trim();
            row.Cells["colNotPurchased"].Value = info.NotPurchased.Trim();
            row.Cells["colMemo"].Value = info.Memo;
            if (info.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
            if (!_Records.Exists(it => it.ID == info.ID)) _Records.Add(info);
        }

        protected override void ShowItemsOnGrid(List<object> items)
        {
            base.ShowItemsOnGrid(items);
            Filter(txtKeyword.Text.Trim());
        }
        #endregion

        #region 事件处理程序
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "colReceivable")
            {
                Order order = dataGridView1.Rows[e.RowIndex].Tag as Order;
                DeliveryRecordSearchCondition con = new DeliveryRecordSearchCondition();
                con.States = new List<SheetState>();
                con.States.Add(SheetState.Shipped);
                con.OrderID = order.ID;
                FrmDeliveryRecordView frm = new FrmDeliveryRecordView();
                frm.SearchCondition = con;
                frm.ShowDialog();
            }
        }

        private void customerTree1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FreshData();
        }

        private void cMnu_Reserve_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
            {
                OrderItemRecord item = dataGridView1.SelectedRows[0].Tag as OrderItemRecord;
                LJH.Inventory.UI.Forms.Inventory.FrmProductInventoryAssign frm = new Inventory.FrmProductInventoryAssign();
                frm.ProductID = item.ProductID;
                frm.MaxCount = item.NotPurchased;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CommandResult ret = (new ProductInventoryBLL(AppSettings.Current.ConnStr)).Reserve(frm.WarehouseID, item.ProductID, item.ID, frm.Count);
                    if (ret.Result == ResultCode.Successful)
                    {
                        item = (new OrderBLL(AppSettings.Current.ConnStr)).GetRecordById(item.ID).QueryObject;
                        ShowItemInGridViewRow(dataGridView1.SelectedRows[0], item);
                    }
                    else
                    {
                        MessageBox.Show(ret.Message);
                    }
                }
            }
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            FreshData();
        }

        private void chkState_CheckedChanged(object sender, EventArgs e)
        {
            FreshData();
        }
        #endregion
    }
}