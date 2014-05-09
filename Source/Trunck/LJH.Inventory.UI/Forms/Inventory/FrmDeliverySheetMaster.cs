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
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.UI.Report;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmDeliverySheetMaster : FrmMasterBase
    {
        public FrmDeliverySheetMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<DeliverySheet> _Sheets = null;
        private List<WareHouse> _Warehouses = null;
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> objs = FilterData();
            ShowItemsOnGrid(objs);
        }

        private List<object> FilterData()
        {
            List<DeliverySheet> items = _Sheets;
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
                                        (item.State == SheetState.Shipped && chkShipped.Checked) ||
                                        (item.State == SheetState.Canceled && chkNullify.Checked))).ToList();
            }
            List<object> objs = null;
            if (items != null && items.Count > 0) objs = (from item in items orderby item.ID descending select (object)item).ToList();
            return objs;
        }
        #endregion

        #region 重写基类方法和处理事件
        protected override void ReFreshData()
        {
            customerTree1.Init();
            base.ReFreshData();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Edit);
            mnu_AddSheet.Enabled = Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Edit);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmDeliverySheetDetail frm = new FrmDeliverySheetDetail();
            if (customerTree1.SelectedNode != null) frm.Customer = customerTree1.SelectedNode.Tag as CompanyInfo;
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            if (SearchCondition == null)
            {
                DeliverySheetSearchCondition con = new DeliverySheetSearchCondition();
                con.LastActiveDate = new DateTimeRange(DateTime.Today.AddYears(-1), DateTime.Now);
                _Sheets = (new DeliverySheetBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            }
            else
            {
                _Sheets = (new DeliverySheetBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            _Warehouses = (new WareHouseBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            return FilterData();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            DeliverySheet sheet = item as DeliverySheet;
            row.Tag = sheet;
            row.Cells["colSheetNo"].Value = sheet.ID;
            CompanyInfo customer = customerTree1.GetCustomer(sheet.CustomerID);
            row.Cells["colCustomer"].Value = customer != null ? customer.Name : string.Empty;
            WareHouse ws = (_Warehouses != null && _Warehouses.Count > 0) ? _Warehouses.SingleOrDefault(it => it.ID == sheet.WareHouseID) : null;
            row.Cells["colWareHouse"].Value = ws != null ? ws.Name : string.Empty;
            //row.Cells["colAmount"].Value = sheet.Amount;
            row.Cells["colState"].Value = SheetStateDescription.GetDescription(sheet.State);
            row.Cells["colShipDate"].Value = sheet.State == SheetState.Shipped ? sheet.LastActiveDate.ToString("yyyy-MM-dd") : null;
            row.Cells["colLinker"].Value = sheet.Linker;
            row.Cells["colTelphone"].Value = sheet.LinkerPhoneCall;
            row.Cells["colAddress"].Value = sheet.Address;
            row.Cells["colMemo"].Value = sheet.Memo;
            if (sheet.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
            if (!_Sheets.Exists(it => it.ID == sheet.ID)) _Sheets.Add(sheet);
        }

        protected override bool DeletingItem(object item)
        {
            MessageBox.Show("不能删除送货单,可以将送货单作废", "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
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
            if (e.RowIndex >= 0)
            {
                DeliverySheet sheet = dataGridView1.Rows[e.RowIndex].Tag as DeliverySheet;
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colPaid")
                {
                    FrmReceivablePaymentAssigns frm = new FrmReceivablePaymentAssigns();
                    frm.ReceivableID = sheet.ID;
                    frm.ShowDialog();
                }
            }
        }

        private void customerTree1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FreshData();
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            FreshData();
        }

        private void chkState_CheckedChanged(object sender, EventArgs e)
        {
            FreshData();
        }

        private void mnu_AddSheet_Click(object sender, EventArgs e)
        {
            PerformAddData();
        }
        #endregion
    }
}
