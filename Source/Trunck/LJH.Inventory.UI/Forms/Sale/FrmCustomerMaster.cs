﻿using System;
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
using LJH.GeneralLibrary.DAL;
using LJH.GeneralLibrary.UI;

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
        private void SelectNode(TreeNode node)
        {
            List<object> items = GetSelectedNodeItems();
            ShowItemsOnGrid(items);
        }

        private List<object> GetSelectedNodeItems()
        {
            List<CompanyInfo> items = _Customers;
            List<CustomerType> pc = null;
            if (this.categoryTree.SelectedNode != null) pc = categoryTree.GetCategoryofNode(this.categoryTree.SelectedNode);
            if (pc != null && pc.Count > 0) items = _Customers.Where(it => pc.Exists(c => c.ID == it.CategoryID)).ToList();

            return (from p in items
                    orderby p.Name ascending
                    select (object)p).ToList();
        }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            categoryTree.Init();
            Operator opt = Operator.Current;
            menu.Items["btn_Add"].Enabled = opt.Permit(Permission.EditCustomer);
            menu.Items["btn_Delete"].Enabled = opt.Permit(Permission.EditCustomer);
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
            List<object> records = GetSelectedNodeItems();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CompanyInfo c = item as CompanyInfo;
            row.Tag = c;
            row.Cells["colImage"].Value = Properties.Resources.customer;
            row.Cells["colID"].Value = c.ID;
            row.Cells["colName"].Value = c.Name;
            row.Cells["colCategory"].Value = c.CategoryID;
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
            SelectNode(e.Node);
        }

        private void mnu_FreshTree_Click(object sender, EventArgs e)
        {
            categoryTree.Init();
            SelectNode(categoryTree.Nodes[0]);
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
                categoryTree.AddCustomerTypeNode(item, categoryTree.SelectedNode);
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
                categoryTree.SelectedNode.Text = string.Format("{0}", pc.Name);
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
