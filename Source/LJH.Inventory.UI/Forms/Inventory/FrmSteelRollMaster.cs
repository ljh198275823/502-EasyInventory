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
using LJH.Inventory.UI.Report;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmSteelRollMaster : FrmMasterBase
    {
        public FrmSteelRollMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<ProductInventoryItem> _SteelRolls = null;
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> items = FilterData();
            ShowItemsOnGrid(items);
        }

        private List<object> FilterData()
        {
            List<ProductInventoryItem> items = _SteelRolls;
            List<ProductCategory> cs = null;
            if (this.categoryTree.SelectedNode != null)
            {
                cs = this.categoryTree.GetCategoryofNode(this.categoryTree.SelectedNode);
                if (cs != null && cs.Count > 0) items = _SteelRolls.Where(it => cs.Exists(c => c.ID == it.Product.CategoryID)).ToList();
            }
            string warehouse = wareHouseComboBox1.SelectedWareHouseID;
            if (items != null && items.Count > 0 && !string.IsNullOrEmpty(warehouse))
            {
                items = items.Where(it => it.WareHouseID == warehouse).ToList();
            }
            if (items != null && items.Count > 0)
            {
                return (from p in items
                        orderby p.AddDate descending, p.Product.CategoryID ascending, p.Product.Specification ascending
                        select (object)p).ToList();
            }
            return null;
        }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            this.wareHouseComboBox1.Init();
            this.wareHouseComboBox1.SelectedIndexChanged -= wareHouseComboBox1_SelectedIndexChanged;
            this.wareHouseComboBox1.SelectedIndexChanged += wareHouseComboBox1_SelectedIndexChanged;
        }

        protected override void ReFreshData()
        {
            this.categoryTree.Init();
            base.ReFreshData();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.ProductInventory, PermissionActions.Edit);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmSteelRollDetail frm = new FrmSteelRollDetail();
            return frm;
        }

        protected override bool DeletingItem(object item)
        {
            return false;
        }

        protected override List<object> GetDataSource()
        {
            ProductInventoryItemBLL bll = new ProductInventoryItemBLL(AppSettings.Current.ConnStr);
            List<ProductInventoryItem> items = null;
            if (SearchCondition == null)
            {
                items = bll.GetItems(null).QueryObjects;
            }
            else
            {
                items = bll.GetItems(SearchCondition).QueryObjects;
            }
            _SteelRolls = bll.GetItems(SearchCondition).QueryObjects;
            List<object> records = FilterData();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            ProductInventoryItem sr = item as ProductInventoryItem;
            row.Cells["colAddDate"].Value = sr.AddDate.ToString("yyyy年MM月dd日");
            row.Cells["colCategory"].Value = sr.Product.Category == null ? sr.Product.CategoryID : sr.Product.Category.Name;
            row.Cells["colSpecification"].Value = sr.Product.Specification;
            row.Cells["colWareHouse"].Value = sr.WareHouse.Name;
            row.Cells["colOriginalWeight"].Value = sr.OriginalWeight.ToString("F3");
            row.Cells["colOriginalLength"].Value = sr.OriginalLength.ToString("F2");
            row.Cells["colWeight"].Value = sr.Weight.ToString("F3");
            row.Cells["colLength"].Value = sr.Length.ToString("F2");
            row.Cells["colSupplier"].Value = sr.SupplierID;
            row.Cells["colManufacture"].Value = sr.Manufacture;
            row.Cells["colState"].Value = sr.State;
            row.Cells["colSerialNumber"].Value = sr.SerialNumber;
            row.Cells["colMemo"].Value = sr.Memo;
        }
        #endregion

        #region 事件处理函数
        private void categoryTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FreshData();
        }

        private void wareHouseComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FreshData();
        }

        private void mnu_StackRecords_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                ProductInventory pi = dataGridView1.SelectedRows[0].Tag as ProductInventory;
                View.FrmProductStackRecordsView frm = new View.FrmProductStackRecordsView();
                frm.ProductInventory = pi;
                frm.ShowDialog();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colValid")
                {
                    ProductInventory item = dataGridView1.Rows[e.RowIndex].Tag as ProductInventory;
                    ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                    con.Products = new List<string>();
                    con.Products.Add(item.ProductID);
                    con.WareHouseID = item.WareHouseID;
                    con.UnReserved = true;
                    con.UnShipped = true;
                    View.FrmProductInventoryItemView frm = new View.FrmProductInventoryItemView();
                    frm.SearchCondition = con;
                    frm.ShowDialog();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "colReserved")
                {
                    ProductInventory item = dataGridView1.Rows[e.RowIndex].Tag as ProductInventory;
                    ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                    con.Products = new List<string>();
                    con.Products.Add(item.ProductID);
                    con.WareHouseID = item.WareHouseID;
                    con.UnReserved = false;
                    con.UnShipped = true;
                    View.FrmProductInventoryItemView frm = new View.FrmProductInventoryItemView();
                    frm.SearchCondition = con;
                    frm.ShowDialog();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "colAmount")
                {
                    ProductInventory item = dataGridView1.Rows[e.RowIndex].Tag as ProductInventory;
                    ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                    con.Products = new List<string>();
                    con.Products.Add(item.ProductID);
                    con.WareHouseID = item.WareHouseID;
                    con.UnShipped = true;
                    View.FrmProductInventoryItemView frm = new View.FrmProductInventoryItemView();
                    frm.SearchCondition = con;
                    frm.ShowDialog();
                }
            }
        }

        private void mnu_Check_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                ProductInventory pi = dataGridView1.SelectedRows[0].Tag as ProductInventory;
                FrmInvnetoryCheck frm = new FrmInvnetoryCheck();
                frm.ProductInventory = pi;
                DialogResult ret= frm.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    ProductInventorySearchCondition con = new ProductInventorySearchCondition();
                    con.ProductID = pi.ProductID;
                    con.WareHouseID = pi.WareHouseID;
                    List<ProductInventory> items = (new ProductInventoryBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
                    ProductInventory pii = items[0];
                    ShowItemInGridViewRow(dataGridView1.SelectedRows[0], pii);
                }
            }
        }
        #endregion
    }
}