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
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms
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

        #region 私有方法
        private void FreshData(TreeNode node)
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
                    orderby p.Name ascending
                    select (object)p).ToList();
        }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            this.categoryTree.Init();
            base.Init();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
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
            _Products = (new ProductBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
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
            row.Cells["colCategoryID"].Value = p.Category != null ? p.Category.Name : p.CategoryID;
            row.Cells["colSpecification"].Value = p.Specification;
            row.Cells["colModel"].Value = p.Model;
            row.Cells["colBarCode"].Value = p.BarCode;
            row.Cells["colShortName"].Value = p.ShortName;
            row.Cells["colUnit"].Value = p.Unit;
            row.Cells["colPrice"].Value = p.Price.Trim();
            row.Cells["colCost"].Value = p.Cost.Trim();
            row.Cells["colCompany"].Value = p.Company;
            row.Cells["colInternalID"].Value = p.InternalID;
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

        protected override void ShowItemsOnGrid(List<object> items)
        {
            base.ShowItemsOnGrid(items);
            Filter(txtKeyword.Text.Trim());
        }
        #endregion

        #region 类别树右键菜单
        private void categoryTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FreshData(e.Node);
        }

        private void mnu_FreshTree_Click(object sender, EventArgs e)
        {
            this.categoryTree.Init();
            FreshData(categoryTree.Nodes[0]);
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
                categoryTree.SelectedNode.Text = string.Format("[{0}] {1}", pc.ID, pc.Name);
            };
            frm.ShowDialog();
        }
        #endregion
    }
}
