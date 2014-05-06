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
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmCustomerMaster : FrmMasterBase
    {
        public FrmCustomerMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<CompanyInfo> _Customers = null;
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> items = FilterData();
            ShowItemsOnGrid(items);
        }

        private List<object> FilterData()
        {
            List<CompanyInfo> items = _Customers;
            List<CustomerType> pc = null;
            if (this.categoryTree.SelectedNode != null && this.categoryTree.SelectedNode.Tag != null) pc = categoryTree.GetCategoryofNode(this.categoryTree.SelectedNode);
            if (pc != null && pc.Count > 0) items = _Customers.Where(it => pc.Exists(c => c.ID == it.CategoryID)).ToList();

            return (from p in items
                    orderby p.Name ascending
                    select (object)p).ToList();
        }
        #endregion

        #region 重写基类方法
        protected override void ReFreshData()
        {
            categoryTree.Init();
            base.ReFreshData();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            this.btn_Add.Enabled = Operator.Current.Permit(Permission.Customer, PermissionActions.Edit);
            this.btn_Delete.Enabled = Operator.Current.Permit(Permission.Customer, PermissionActions.Edit);
            this.cMnu_Add.Enabled = Operator.Current.Permit(Permission.Customer, PermissionActions.Edit);
            this.cMnu_Delete.Enabled = Operator.Current.Permit(Permission.Customer, PermissionActions.Edit);
            this.mnu_AddCustomer.Enabled = Operator.Current.Permit(Permission.Customer, PermissionActions.Edit);
            this.mnu_AddCategory.Enabled = Operator.Current.Permit(Permission.CustomerType, PermissionActions.Edit);
            this.mnu_DeleteCategory.Enabled = Operator.Current.Permit(Permission.CustomerType, PermissionActions.Edit);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmCustomerDetail frm = new FrmCustomerDetail();
            frm.Category = categoryTree.SelectedNode != null ? (categoryTree.SelectedNode.Tag as CustomerType) : null;
            return frm;
        }

        protected override bool DeletingItem(object item)
        {
            CompanyInfo c = item as CompanyInfo;
            CompanyBLL bll = new CompanyBLL(AppSettings.Current.ConnStr);
            CommandResult ret = bll.Delete(c);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            else
            {
                _Customers.Remove(c);
            }
            return ret.Result == ResultCode.Successful;
        }

        protected override List<object> GetDataSource()
        {
            CompanyBLL bll = new CompanyBLL(AppSettings.Current.ConnStr);
            if (SearchCondition == null)
            {
                CustomerSearchCondition con = new CustomerSearchCondition();
                con.ClassID = CustomerClass.Customer;
                SearchCondition = con;
            }
            _Customers = bll.GetItems(SearchCondition).QueryObjects;
            List<object> records = FilterData();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CompanyInfo c = item as CompanyInfo;
            row.Tag = c;
            row.Cells["colImage"].Value = Properties.Resources.customer;
            row.Cells["colID"].Value = c.ID;
            row.Cells["colName"].Value = c.Name;
            CustomerType ct = categoryTree.GetCustomerType(c.CategoryID);
            row.Cells["colCategory"].Value = ct != null ? ct.Name : string.Empty;
            row.Cells["colNation"].Value = c.Nation;
            row.Cells["colCity"].Value = c.City;
            row.Cells["colWeb"].Value = c.Website;
            row.Cells["colTelphone"].Value = c.TelPhone;
            row.Cells["colFax"].Value = c.Fax;
            row.Cells["colPost"].Value = c.PostalCode;
            row.Cells["colAddress"].Value = c.Address;
            row.Cells["colMemo"].Value = c.Memo;
            if (_Customers == null || !_Customers.Exists(it => it.ID == c.ID))
            {
                if (_Customers == null) _Customers = new List<CompanyInfo>();
                _Customers.Add(c);
            }
        }

        protected override void ShowItemsOnGrid(List<object> items)
        {
            base.ShowItemsOnGrid(items);
            Filter(txtKeyword.Text.Trim());
        }
        #endregion

        #region 类别树右键菜单
        private void categoryTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FreshData();
        }

        private void mnu_AddCategory_Click(object sender, EventArgs e)
        {
            CustomerType pc = categoryTree.SelectedNode.Tag as CustomerType;
            FrmCustomerTypeDetail frm = new FrmCustomerTypeDetail();
            frm.IsAdding = true;
            frm.ParentCategory = pc;
            frm.ItemAdded += delegate(object obj, ItemAddedEventArgs args)
            {
                CustomerType item = args.AddedItem as CustomerType;
                TreeNode node = categoryTree.AddCustomerTypeNode(item, categoryTree.SelectedNode, true);
            };
            frm.ShowDialog();
        }

        private void mnu_DeleteCategory_Click(object sender, EventArgs e)
        {
            CustomerType pc = categoryTree.SelectedNode.Tag as CustomerType;
            if (pc != null && MessageBox.Show("是否删除此类别及其子项?", "询问", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                CommandResult ret = (new CustomerTypeBLL(AppSettings.Current.ConnStr)).Delete(pc);
                if (ret.Result == ResultCode.Successful)
                {
                    categoryTree.SelectedNode.Parent.Nodes.Remove(categoryTree.SelectedNode);
                }
                else
                {
                    MessageBox.Show(ret.Message);
                }
            }
        }

        private void mnu_CategoryProperty_Click(object sender, EventArgs e)
        {
            CustomerType pc = categoryTree.SelectedNode.Tag as CustomerType;
            FrmCustomerTypeDetail frm = new FrmCustomerTypeDetail();
            frm.IsAdding = false;
            frm.UpdatingItem = pc;
            frm.ItemUpdated += delegate(object obj, ItemUpdatedEventArgs args)
            {
                categoryTree.Init();
                categoryTree.SelectCustomerTypeNode(pc.ID);
                FreshData();
            };
            frm.ShowDialog();
        }

        private void mnu_AddCustomer_Click(object sender, EventArgs e)
        {
            PerformAddData();
        }
        #endregion
    }
}
