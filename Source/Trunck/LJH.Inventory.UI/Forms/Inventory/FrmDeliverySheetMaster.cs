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
using LJH.Inventory.UI.ExcelExporter;
using LJH.Inventory.UI.Report;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmDeliverySheetMaster : FrmMasterBase
    {
        public FrmDeliverySheetMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<DeliverySheet > _Sheets = null;
        #endregion

        #region 私有方法
        private void SelectNode(TreeNode node)
        {
            List<object> items = GetSelectedNodeItems();
            ShowItemsOnGrid(items);
        }

        private List<object> GetSelectedNodeItems()
        {
            List<DeliverySheet> items = _Sheets;
            CompanyInfo pc = null;
            if (this.customerTree1.SelectedNode != null) pc = this.customerTree1.SelectedNode.Tag as CompanyInfo;
            if (pc != null) items = _Sheets.Where(it => it.CustomerID == pc.ID).ToList();

            return (from p in items
                    select (object)p).ToList();
        }
        #endregion

        #region 重写基类方法和处理事件
        protected override void Init()
        {
            base.Init();
            customerTree1.Init();
            menu.Items["btn_Add"].Enabled = Operator.Current.Permit(Permission.EditDeliverySheet);
            dataGridView1.Columns["colAmount"].Visible = Operator.Current.Permit(Permission.ReadPrice);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmDetailBase frm= new FrmDeliverySheetDetail();
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            _Sheets  = (new DeliverySheetBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            return GetSelectedNodeItems();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            DeliverySheet sheet = item as DeliverySheet;
            row.Tag = sheet;
            row.Cells["colSheetNo"].Value = sheet.ID;
            row.Cells["colCustomer"].Value = sheet.Customer.Name ;
            row.Cells["colWareHouse"].Value = sheet.WareHouse != null ? sheet.WareHouse.Name : string.Empty;
            row.Cells["colAmount"].Value = sheet.Amount;
            row.Cells["colState"].Value = SheetStateDescription.GetDescription(sheet.State);
            row.Cells["colLinker"].Value = sheet.Linker;
            row.Cells["colTelphone"].Value = sheet.LinkerPhoneCall;
            row.Cells["colAddress"].Value = sheet.Address;
            row.Cells["colWithTax"].Value = sheet.IsWithTax;
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
            SelectNode(e.Node);
        }
        #endregion
    }
}
