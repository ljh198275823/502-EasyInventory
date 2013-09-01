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
    public partial class FrmProductInventoryMaster : FrmMasterBase
    {
        public FrmProductInventoryMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<Button> _Buttons = new List<Button>();
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            List<WareHouse> items = (new WareHouseBLL(AppSettings.CurrentSetting.ConnectString)).GetAll().QueryObjects;
            if (items != null && items.Count > 0)
            {
                Button b = new Button();
                b.Name = "全部";
                b.BackColor = SystemColors.ControlDark;
                b.Size = new Size(200, 42);
                b.Dock = DockStyle.Top;
                b.FlatStyle = FlatStyle.Popup;
                _Buttons.Add(b);

                foreach (WareHouse pc in items)
                {
                    Button button = new Button();
                    button.Name = pc.Name;
                    button.Dock = DockStyle.Top;
                    button.Size = new Size(200, 42);
                    button.FlatStyle = FlatStyle.Popup;
                    _Buttons.Add(button);
                }
                for (int i = _Buttons.Count - 1; i >= 0; i--)
                {
                    pnlLeft.Controls.Add(_Buttons[i]);
                }
            }
            else
            {
                this.pnlLeft.Visible = false;
                this.splitter1.Visible = false;
            }
            menu.Items["btn_Delete"].Visible = false;
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmProductInventoryDetail();
        }

        protected override bool DeletingItem(object item)
        {
            return false;
        }

        protected override List<object> GetDataSource()
        {
            ProductInventoryBLL bll = new ProductInventoryBLL(AppSettings.CurrentSetting.ConnectString);
            List<ProductInventory> items = bll.GetItems(null).QueryObjects;
            List<object> records = null;
            if (_Buttons.Count > 1)
            {
                for (int i = 1; i < _Buttons.Count; i++)
                {
                    records = (from p in items
                               where p.WareHouse.Name == _Buttons[i].Name
                               orderby p.ProductID ascending
                               select (object)p).ToList();
                    _Buttons[i].Tag = records;
                    _Buttons[i].Text = string.Format("{0} ({1})", _Buttons[i].Name, records == null ? 0 : records.Count);
                }
            }

            records = (from p in items
                       orderby p.ProductID ascending
                       select (object)p).ToList();
            if (_Buttons.Count > 0)
            {
                _Buttons[0].Tag = records;
                _Buttons[0].Text = string.Format("{0} ({1})", _Buttons[0].Name, records == null ? 0 : records.Count);
            }
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            ProductInventory pi = item as ProductInventory;
            row.Cells["colImage"].Value = Properties.Resources.inventory;
            row.Cells["colProductID"].Value = pi.ProductID;
            row.Cells["colProduct"].Value = pi.Product.Name;
            row.Cells["colCategory"].Value = pi.Product.Category == null ? pi.Product.CategoryID : pi.Product.Category.Name;
            row.Cells["colSpecification"].Value = pi.Product.Specification;
            row.Cells["colModel"].Value = pi.Product.Model;
            row.Cells["colWareHouse"].Value = pi.WareHouse.Name;
            row.Cells["colUnit"].Value = pi.Unit;
            row.Cells["colCount"].Value = pi.Count.Trim();
            row.Cells["colAmount"].Value = pi.Amount;
        }
        #endregion

        #region 事件处理函数
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colProductID")
                {
                    ProductInventory pi = dataGridView1.Rows[e.RowIndex].Tag as ProductInventory;
                    Product p = (new ProductBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(pi.ProductID).QueryObject;
                    if (p != null)
                    {
                        FrmProductDetail frm = new FrmProductDetail();
                        frm.UpdatingItem = p;
                        frm.IsAdding = false;
                        frm.IsForView = true;
                        frm.ShowDialog();
                    }
                }
            }
        }
        #endregion
    }
}