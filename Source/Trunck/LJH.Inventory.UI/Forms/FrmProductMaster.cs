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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmProductMaster : FrmMasterBase 
    {
        public FrmProductMaster()
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
            List<ProductCategory> items = (new ProductCategoryBLL(AppSettings.CurrentSetting.ConnectString)).GetAll().QueryObjects;
            if (items != null && items.Count > 0)
            {
                Button b = new Button();
                b.Name = "全部";
                b.BackColor = SystemColors.ControlDark;
                b.Size = new Size(200, 42);
                b.Dock = DockStyle.Top;
                b.FlatStyle = FlatStyle.Popup;
                _Buttons.Add(b);

                foreach (ProductCategory pc in items)
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
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmProductDetail();
        }

        protected override List<object> GetDataSource()
        {
            List<Product> items = (new ProductBLL(AppSettings.CurrentSetting.ConnectString)).GetItems(null).QueryObjects;
            List<object> records = null;
            if (_Buttons.Count > 1)
            {
                for (int i = 1; i < _Buttons.Count; i++)
                {
                    records = (from p in items
                             where p.Category.Name == _Buttons[i].Name
                             orderby p.Name ascending
                             select (object)p).ToList();
                    _Buttons[i].Tag = records;
                    _Buttons[i].Text = string.Format("{0} ({1})", _Buttons[i].Name, records == null ? 0 : records.Count);
                }
            }

            records = (from p in items
                     orderby p.Name ascending
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
            Product p = item as Product;
            row.Tag = p;
            row.Cells["colImage"].Value = Properties.Resources.product;
            row.Cells["colNumber"].Value = p.ID;
            row.Cells["colName"].Value = p.Name;
            row.Cells["colForeignName"].Value = p.ForeignName;
            row.Cells["colCategoryID"].Value = p.Category != null ? p.Category.Name : p.CategoryID;
            row.Cells["colSpecification"].Value = p.Specification;
            row.Cells["colModel"].Value = p.Model;
            row.Cells["colHSCode"].Value = p.HSCode;
            row.Cells["colMemo"].Value = p.Memo;
        }

        protected override bool DeletingItem(object item)
        {
            CommandResult ret = (new ProductBLL(AppSettings.CurrentSetting.ConnectString)).Delete(item as Product);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            return ret.Result == ResultCode.Successful;
        }
        #endregion

    }
}
