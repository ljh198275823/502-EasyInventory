using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmInventorySheetMaster : FrmMasterBase
    {
        public FrmInventorySheetMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<InventorySheet> _Sheets = null;
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
            List<InventorySheet> items = _Sheets;
            if (this.supplierTree1.SelectedNode != null)
            {
                List<CompanyInfo> pcs = null;
                pcs = this.supplierTree1.GetCompanyofNode(this.supplierTree1.SelectedNode);
                if (pcs != null && pcs.Count > 0)
                {
                    items = items.Where(it => pcs.Exists(c => c.ID == it.SupplierID)).ToList();
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
                                        (item.State == SheetState.Inventory && chkInventory.Checked) ||
                                        (item.State == SheetState.Canceled && chkNullify.Checked))).ToList();
            }
            List<object> objs = null;
            if (items != null && items.Count > 0) objs = (from item in items orderby item.ID descending select (object)item).ToList();
            return objs;
        }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            supplierTree1.Init();
            Operator opt = Operator.Current;
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmInventorySheetDetail frm= new FrmInventorySheetDetail();
            if (supplierTree1.SelectedNode != null) frm.Supplier = supplierTree1.SelectedNode.Tag as CompanyInfo;
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            _Sheets = (new InventorySheetBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            _Warehouses = (new WareHouseBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            return FilterData();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            InventorySheet sheet = item as InventorySheet;
            row.Cells["colSheetNo"].Value = sheet.ID;
            CompanyInfo supplier = supplierTree1.GetSupplier(sheet.SupplierID);
            row.Cells["colSupplier"].Value = supplier != null ? supplier.Name : string.Empty;
            WareHouse ws = (_Warehouses != null && _Warehouses.Count > 0) ? _Warehouses.SingleOrDefault(it => it.ID == sheet.WareHouseID) : null;
            row.Cells["colWareHouse"].Value = ws != null ? ws.Name : string.Empty;
            row.Cells["colState"].Value = SheetStateDescription.GetDescription(sheet.State);
            row.Cells["colInventoryDate"].Value = sheet.State == SheetState.Inventory ? sheet.LastActiveDate.ToString("yyyy-MM-dd") : null;
            row.Cells["colAmount"].Value = sheet.Amount.Trim();
            row.Cells["colMemo"].Value = sheet.Memo;
            if (sheet.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
            if (!_Sheets.Exists(it => it.ID == sheet.ID)) _Sheets.Add(sheet);
        }

        protected override void ShowItemsOnGrid(List<object> items)
        {
            base.ShowItemsOnGrid(items);
            Filter(txtKeyword.Text.Trim());
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //if (UpdatingItem != null)
            //{
            //    if (MessageBox.Show("是否将此收货单作废?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            //    {
            //        InventorySheet sheet = UpdatingItem as InventorySheet;
            //        CommandResult ret = (new InventorySheetBLL(AppSettings.CurrentSetting.ConnectString)).Nullify(sheet.ID, OperatorInfo.CurrentOperator.OperatorName);
            //        if (ret.Result == ResultCode.Successful)
            //        {
            //            InventorySheet sheet1 = (new InventorySheetBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(sheet.ID).QueryObject;
            //            this.UpdatingItem = sheet1;
            //            ItemShowing();
            //            ShowButtonState();
            //            this.OnItemUpdated(new ItemUpdatedEventArgs(sheet1));
            //        }
            //        else
            //        {
            //            MessageBox.Show(ret.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
        }

        private void supplierTree1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
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

        private void mnu_FreshTree_Click(object sender, EventArgs e)
        {
            FreshData();
        }

        private void mnu_AddSheet_Click(object sender, EventArgs e)
        {
            PerformAddData();
        }
    }
}
