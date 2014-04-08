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
        #endregion

        #region 私有方法
        private void SelectNode(TreeNode node)
        {
            List<object> items = GetSelectedNodeItems();
            ShowItemsOnGrid(items);
        }

        private List<object> GetSelectedNodeItems()
        {
            List<InventorySheet> items = _Sheets;
            CompanyInfo pc = null;
            if (this.supplierTree1.SelectedNode != null) pc = this.supplierTree1.SelectedNode.Tag as CompanyInfo;
            if (pc != null) items = _Sheets.Where(it => it.SupplierID == pc.ID).ToList();

            return (from p in items
                    select (object)p).ToList();
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
            return new FrmInventorySheetDetail();
        }

        protected override List<object> GetDataSource()
        {
            _Sheets = (new InventorySheetBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            return GetSelectedNodeItems();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            InventorySheet sheet = item as InventorySheet;
            row.Cells["colSheetNo"].Value = sheet.ID;
            row.Cells["colWareHouseName"].Value = sheet.WareHouse.Name;
            row.Cells["colState"].Value = SheetStateDescription.GetDescription(sheet.State);
            row.Cells["colSupplier"].Value = sheet.Supplier.Name;
            row.Cells["colAmount"].Value = sheet.Amount.Trim();
            row.Cells["colMemo"].Value = sheet.Memo;
            if (sheet.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
            if (!_Sheets.Exists(it => it.ID == sheet.ID)) _Sheets.Add(sheet);
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
            SelectNode(e.Node);
        }
    }
}
