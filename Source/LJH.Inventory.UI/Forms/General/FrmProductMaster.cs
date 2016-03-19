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
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.General
{
    public partial class FrmProductMaster : FrmMasterBase
    {
        public FrmProductMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        List<Product> _Products = null;
        #endregion

        public string Models { get; set; }

        public string ExcludeModels { get; set; }

        #region 私有方法
        private void FreshData()
        {
            List<object> items = FilterData();
            ShowItemsOnGrid(items);
        }

        private List<object> FilterData()
        {
            List<Product> items = _Products;
            ProductCategory pc = null;
            if (this.categoryTree.SelectedNode != null) pc = this.categoryTree.SelectedNode.Tag as ProductCategory;
            if (pc != null) items = _Products.Where(it => it.CategoryID == pc.ID).ToList();

            return (from p in items
                    where (string.IsNullOrEmpty(Models) || Models.Contains(p.Model)) && (string.IsNullOrEmpty(ExcludeModels) || !ExcludeModels.Contains(p.Model))
                    orderby p.CategoryID ascending, p.Brand ascending, p.Specification ascending
                    select (object)p).ToList();
        }
        #endregion

        #region 重写基类方法
        public override void ReFreshData()
        {
            this.categoryTree.Init();
            base.ReFreshData();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            this.cMnu_Add.Enabled = Operator.Current.Permit(Permission.Product, PermissionActions.Edit);
            this.mnu_AddProduct.Enabled = Operator.Current.Permit(Permission.Product, PermissionActions.Edit);
            this.mnu_AddCategory.Enabled = Operator.Current.Permit(Permission.ProductCategory, PermissionActions.Edit);
            this.mnu_DeleteCategory.Enabled = Operator.Current.Permit(Permission.ProductCategory, PermissionActions.Edit);
            this.mnu_CategoryProperty.Enabled = Operator.Current.Permit(Permission.ProductCategory, PermissionActions.Edit) || Operator.Current.Permit(Permission.ProductCategory, PermissionActions.Read);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmProductDetail frm = new FrmProductDetail();
            if (categoryTree.SelectedNode != null) frm.Category = categoryTree.SelectedNode.Tag as ProductCategory;
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            if (SearchCondition == null)
            {
                _Products = (new ProductBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                _Products = (new ProductBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            List<object> records = FilterData();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Product p = item as Product;
            row.Tag = p;
            row.Cells["colImage"].Value = Properties.Resources.product;
            row.Cells["colNumber"].Value = p.ID;
            row.Cells["colName"].Value = p.Name;
            ProductCategory pc = categoryTree.GetCategory(p.CategoryID);
            row.Cells["colCategoryID"].Value = pc != null ? pc.Name : string.Empty;
            row.Cells["colSpecification"].Value = p.Specification;
            row.Cells["colModel"].Value = p.Model;
            row.Cells["colPrice"].Value = p.Price.Trim();
            row.Cells["colCost"].Value = p.Cost.Trim();
            row.Cells["colBrand"].Value = p.Brand;
            row.Cells["colMemo"].Value = p.Memo;
            if (_Products == null || !_Products.Exists(it => it.ID == p.ID))
            {
                if (_Products == null) _Products = new List<Product>();
                _Products.Add(p);
            }
        }

        protected override bool DeletingItem(object item)
        {
            Product p = item as Product;
            CommandResult ret = (new ProductBLL(AppSettings.Current.ConnStr)).Delete(p);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            else
            {
                _Products.Remove(p);
            }
            return ret.Result == ResultCode.Successful;
        }
        #endregion

        #region 类别树右键菜单
        private void categoryTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FreshData();
        }

        private void mnu_AddCategory_Click(object sender, EventArgs e)
        {
            ProductCategory pc = categoryTree.SelectedNode.Tag as ProductCategory;
            FrmProductCategoryDetail frm = new FrmProductCategoryDetail();
            frm.IsAdding = true;
            frm.ParentCategory = pc;
            frm.ItemAdded += delegate(object obj, ItemAddedEventArgs args)
            {
                ProductCategory item = args.AddedItem as ProductCategory;
                this.categoryTree.AddCategoryNode(item, categoryTree.SelectedNode);
                categoryTree.SelectedNode.Expand();
            };
            frm.ShowDialog();
        }

        private void mnu_AddProduct_Click(object sender, EventArgs e)
        {
            PerformAddData();
        }

        private void mnu_DeleteCategory_Click(object sender, EventArgs e)
        {
            ProductCategory pc = categoryTree.SelectedNode.Tag as ProductCategory;
            if (pc != null && MessageBox.Show("是否删除此类别及其子项?", "询问", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                CommandResult ret = (new ProductCategoryBLL(AppSettings.Current.ConnStr)).Delete(pc);
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
            ProductCategory pc = categoryTree.SelectedNode.Tag as ProductCategory;
            FrmProductCategoryDetail frm = new FrmProductCategoryDetail();
            frm.IsAdding = false;
            frm.UpdatingItem = pc;
            frm.ItemUpdated += delegate(object obj, ItemUpdatedEventArgs args)
            {
                categoryTree.Init();
                categoryTree.SelectCategoryNode(pc.ID);
                FreshData();
            };
            frm.ShowDialog();
        }
        #endregion
    }
}
