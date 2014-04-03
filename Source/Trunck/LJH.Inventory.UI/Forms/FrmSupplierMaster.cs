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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmSupplierMaster : FrmMasterBase
    {
        public FrmSupplierMaster()
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
            List<SupplierType> items = (new SupplierTypeBLL(AppSettings.CurrentSetting.ConnectString)).GetAll().QueryObjects;
            if (items != null && items.Count > 0)
            {
                Button b = new Button();
                b.Name = "全部";
                b.BackColor = SystemColors.ControlDark;
                b.Size = new Size(200, 42);
                b.Dock = DockStyle.Top;
                b.FlatStyle = FlatStyle.Popup;
                _Buttons.Add(b);

                foreach (SupplierType pc in items)
                {
                    Button button = new Button();
                    button.Name = pc.ID;
                    button.Text = pc.Name;
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
            OperatorInfo opt = OperatorInfo.CurrentOperator;
            menu.Items["btn_Add"].Enabled = opt.Permit(Permission.EditSupplier);
            menu.Items["btn_Delete"].Enabled = opt.Permit(Permission.EditSupplier);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmSupplierDetail frm = new FrmSupplierDetail();
            return frm;
        }

        protected override bool DeletingItem(object item)
        {
            CustomerBLL bll = new CustomerBLL(AppSettings.CurrentSetting.ConnectString);
            CommandResult ret = bll.Delete(item as Customer);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            return ret.Result == ResultCode.Successful;
        }

        protected override List<object> GetDataSource()
        {
            CustomerBLL bll = new CustomerBLL(AppSettings.CurrentSetting.ConnectString);
            if (SearchCondition == null)
            {
                CustomerSearchCondition con = new CustomerSearchCondition();
                con.ClassID = CustomerClass.Supplier;
                SearchCondition = con;
            }
            List<Customer> ss = bll.GetItems(SearchCondition).QueryObjects;
            List<object> items = null;
            if (_Buttons.Count > 1)
            {
                for (int i = 1; i < _Buttons.Count; i++)
                {
                    items = (from c in ss
                             where c.CategoryID == _Buttons[i].Name
                             orderby c.ID ascending
                             select (object)c).ToList();
                    _Buttons[i].Tag = items;
                    _Buttons[i].Text = string.Format("{0} ({1})", _Buttons[i].Name, items == null ? 0 : items.Count);
                }
            }

            items = (from c in ss
                     orderby c.ID ascending
                     select (object)c).ToList();
            if (_Buttons.Count > 0)
            {
                _Buttons[0].Tag = items;
                _Buttons[0].Text = string.Format("{0} ({1})", _Buttons[0].Name, items == null ? 0 : items.Count);
            }
            return items;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Customer c = item as Customer;
            row.Tag = c;
            row.Cells["colImage"].Value = Properties.Resources.customer;
            row.Cells["colID"].Value = c.ID;
            row.Cells["colNation"].Value = c.Nation;
            row.Cells["colName"].Value = c.Name;
            row.Cells["colWebsite"].Value = c.Website;
            row.Cells["colTelphone"].Value = c.TelPhone;
            row.Cells["colFax"].Value = c.Fax;
            row.Cells["colAddress"].Value = c.Address;
            row.Cells["colPostalCode"].Value = c.PostalCode;
            row.Cells["colMemo"].Value = c.Memo;
        }
        #endregion
    }
}
