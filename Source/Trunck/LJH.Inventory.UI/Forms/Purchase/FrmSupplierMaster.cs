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
    public partial class FrmSupplierMaster : FrmMasterBase
    {
        public FrmSupplierMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<CompanyInfo> _Suppliers = null;
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> items = FilterData();
            ShowItemsOnGrid(items);
        }

        private List<object> FilterData()
        {
            List<CompanyInfo> items = _Suppliers;
            List<SupplierType> pc = null;
            if (this.categoryTree.SelectedNode != null && this.categoryTree.SelectedNode.Tag != null) pc = categoryTree.GetCategoryofNode(this.categoryTree.SelectedNode);
            if (pc != null && pc.Count > 0) items = _Suppliers.Where(it => pc.Exists(c => c.ID == it.CategoryID)).ToList();

            return (from p in items
                    orderby p.Name ascending
                    select (object)p).ToList();
        }
        #endregion

        #region 重写基类方法
        protected override void ReFreshData()
        {
            this.categoryTree.Init();
            base.ReFreshData();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            this.btn_Add.Enabled = Operator.Current.Permit(Permission.Supplier, PermissionActions.Edit);
            this.btn_Delete.Enabled = Operator.Current.Permit(Permission.Supplier, PermissionActions.Edit);
            this.cMnu_Add.Enabled = Operator.Current.Permit(Permission.Supplier, PermissionActions.Edit);
            this.cMnu_Delete.Enabled = Operator.Current.Permit(Permission.Supplier, PermissionActions.Edit);
            this.mnu_AddSupplier.Enabled = Operator.Current.Permit(Permission.Supplier, PermissionActions.Edit);
            this.mnu_AddCategory.Enabled = Operator.Current.Permit(Permission.SupplierType, PermissionActions.Edit);
            this.mnu_DeleteCategory.Enabled = Operator.Current.Permit(Permission.SupplierType, PermissionActions.Edit);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmSupplierDetail frm = new FrmSupplierDetail();
            frm.Category = categoryTree.SelectedNode != null ? (categoryTree.SelectedNode.Tag as SupplierType) : null;
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
                _Suppliers.Remove(c);
            }
            return ret.Result == ResultCode.Successful;
        }

        protected override List<object> GetDataSource()
        {
            CompanyBLL bll = new CompanyBLL(AppSettings.Current.ConnStr);
            if (SearchCondition == null)
            {
                CustomerSearchCondition con = new CustomerSearchCondition();
                con.ClassID = CustomerClass.Supplier;
                SearchCondition = con;
            }
            _Suppliers = bll.GetItems(SearchCondition).QueryObjects;
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
            SupplierType st = categoryTree.GetSupplierType(c.CategoryID);
            row.Cells["colCategory"].Value = st != null ? st.Name : string.Empty;
            row.Cells["colNation"].Value = c.Nation;
            row.Cells["colCity"].Value = c.City;
            row.Cells["colWebsite"].Value = c.Website;
            row.Cells["colTelphone"].Value = c.TelPhone;
            row.Cells["colFax"].Value = c.Fax;
            row.Cells["colAddress"].Value = c.Address;
            row.Cells["colPostalCode"].Value = c.PostalCode;
            row.Cells["colMemo"].Value = c.Memo;
            if (_Suppliers == null || !_Suppliers.Exists(it => it.ID == c.ID))
            {
                if (_Suppliers == null) _Suppliers = new List<CompanyInfo>();
                _Suppliers.Add(c);
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
            SupplierType pc = categoryTree.SelectedNode.Tag as SupplierType;
            FrmSupplierTypeDetail frm = new FrmSupplierTypeDetail();
            frm.IsAdding = true;
            frm.ParentCategory = pc;
            frm.ItemAdded += delegate(object obj, ItemAddedEventArgs args)
            {
                SupplierType item = args.AddedItem as SupplierType;
                TreeNode node = categoryTree.AddSupplierTypeNode(item, categoryTree.SelectedNode);
                categoryTree.SelectedNode.Expand();
            };
            frm.ShowDialog();
        }

        private void mnu_DeleteCategory_Click(object sender, EventArgs e)
        {
            SupplierType pc = categoryTree.SelectedNode.Tag as SupplierType;
            if (pc != null && MessageBox.Show("是否删除此类别及其子项?", "询问", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                CommandResult ret = (new SupplierTypeBLL(AppSettings.Current.ConnStr)).Delete(pc);
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
            SupplierType pc = categoryTree.SelectedNode.Tag as SupplierType;
            FrmSupplierTypeDetail frm = new FrmSupplierTypeDetail();
            frm.IsAdding = false;
            frm.UpdatingItem = pc;
            frm.ItemUpdated += delegate(object obj, ItemUpdatedEventArgs args)
            {
                categoryTree.Init();
                categoryTree.SelectSupplierTypeNode(pc.ID);
                FreshData();
            };
            frm.ShowDialog();
        }
        #endregion

        private void mnu_AddSupplier_Click(object sender, EventArgs e)
        {
            PerformAddData();
        }
    }
}
