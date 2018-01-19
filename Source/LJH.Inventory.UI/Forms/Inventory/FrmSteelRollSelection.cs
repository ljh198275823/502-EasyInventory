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

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmSteelRollSelection : Form
    {
        public FrmSteelRollSelection()
        {
            InitializeComponent();
        }

        public List<ProductInventoryItem> SelectedItems
        {
            get
            {
                List<ProductInventoryItem> ret = null;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (ret == null) ret = new List<ProductInventoryItem>();
                    ret.Add(row.Tag as ProductInventoryItem);
                }
                return ret;
            }
        }

        private FrmSteelRollMaster _FrmSteelRoll = null;
        private List<CompanyInfo> _AllSuppliers = null;
        private List<WareHouse> _AllWarehouse = null;

        private void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            ProductInventoryItem sr = item as ProductInventoryItem;
            row.Tag = sr;
            row.Cells["colAddDate"].Value = sr.AddDate.ToString("yyyy-MM-dd");
            row.Cells["colName"].Value = sr.Product.Name;
            row.Cells["col克重"].Value = SpecificationHelper.GetWritten克重(sr.Product.Specification);
            row.Cells["colWidth"].Value =SpecificationHelper .GetWrittenWidth ( sr.Product.Specification);
            if (_AllWarehouse != null)
            {
                var ws = _AllWarehouse.SingleOrDefault(it => it.ID == sr.WareHouseID);
                row.Cells["colWareHouse"].Value = ws != null ? ws.Name : null;
            }
            row.Cells["colOriginalWeight"].Value = sr.OriginalWeight;
            row.Cells["colOriginalLength"].Value = sr.OriginalLength;
            row.Cells["colWeight"].Value = sr.Weight;
            row.Cells["colLength"].Value = sr.Length;
            row.Cells["colRealThick"].Value = sr.Real克重;
            row.Cells["colCustomer"].Value = sr.Customer;
            if (_AllSuppliers != null)
            {
                var s = _AllSuppliers.SingleOrDefault(it => it.ID == sr.Supplier);
                row.Cells["colSupplier"].Value = s != null ? s.Name : null;
            }
            row.Cells["colManufacture"].Value = sr.Manufacture;
            row.Cells["colStatus"].Value = sr.Status;
            row.Cells["colSerialNumber"].Value = sr.SerialNumber;
            row.Cells["colAction"].Value = "取消";
        }

        private void FrmSteelRollSelection_Load(object sender, EventArgs e)
        {
            _AllWarehouse = new LJH.Inventory.BLL.WareHouseBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            _AllSuppliers = new LJH.Inventory.BLL.CompanyBLL(AppSettings.Current.ConnStr).GetAllSuppliers().QueryObjects;
            _FrmSteelRoll = new FrmSteelRollMaster();
            _FrmSteelRoll.chk待发货.Enabled = false;
            _FrmSteelRoll.chk待发货.Checked = false;
            _FrmSteelRoll.chk发货.Checked = false;
            _FrmSteelRoll.chk发货.Enabled = false;
            _FrmSteelRoll.chk作废.Enabled = false;
            _FrmSteelRoll.chk作废.Checked = false;
            _FrmSteelRoll.chkRemainless.Checked = false;
            _FrmSteelRoll.chkRemainless.Enabled = false;
            _FrmSteelRoll.chkOnlyTail.Checked = false;
            _FrmSteelRoll.ForSelect = true;
            _FrmSteelRoll.MultiSelect = true;
            _FrmSteelRoll.ItemSelected += new EventHandler<GeneralLibrary.Core.UI.ItemSelectedEventArgs>(_FrmSteelRoll_ItemSelected);
            this.ucFormViewMain.AddAForm(_FrmSteelRoll, false);
        }

        private void _FrmSteelRoll_ItemSelected(object sender, GeneralLibrary.Core.UI.ItemSelectedEventArgs e)
        {
            bool exists = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (object.ReferenceEquals(row.Tag, e.SelectedItem)) exists = true;
                break;
            }
            if (!exists)
            {
                var r = dataGridView1.Rows.Add();
                ShowItemInGridViewRow(dataGridView1.Rows[r], e.SelectedItem);
                dataGridView1.Rows[r].Selected = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colAction")
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                    _FrmSteelRoll.ReFreshData();
                }
            }
        }
    }
}
