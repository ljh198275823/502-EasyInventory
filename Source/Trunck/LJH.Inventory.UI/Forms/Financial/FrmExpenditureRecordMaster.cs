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
using LJH.Inventory.BLL;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmExpenditureRecordMaster : FrmMasterBase
    {
        public FrmExpenditureRecordMaster()
        {
            InitializeComponent();
        }


        #region 私有变量
        private List<ExpenditureRecord> _Customers = null;
        #endregion

        #region 私有方法
        private void InitCategoryTree()
        {
            this.categoryTree.Nodes.Clear();
            this.categoryTree.Nodes.Add("所有支出类别");

            List<ExpenditureType> items = (new ExpenditureTypeBLL(AppSettings.Current.ConnStr)).GetAll().QueryObjects;
            if (items != null && items.Count > 0)
            {
                AddDesendNodes(items, this.categoryTree.Nodes[0]);
            }
        }

        private void AddDesendNodes(List<ExpenditureType> items, TreeNode parent)
        {
            List<ExpenditureType> pcs = null;
            if (parent.Tag == null)
            {
                pcs = items.Where(it => string.IsNullOrEmpty(it.Parent)).ToList();
            }
            else
            {
                pcs = items.Where(it => it.Parent == (parent.Tag as ExpenditureType).ID).ToList();
            }
            if (pcs != null && pcs.Count > 0)
            {
                foreach (ExpenditureType pc in pcs)
                {
                    TreeNode node = AddNode(pc, parent);
                    AddDesendNodes(items, node);
                }
            }
            parent.ImageIndex = 0;
            parent.SelectedImageIndex = 0;
            parent.ExpandAll();
        }

        private void SelectNode(TreeNode node)
        {
            List<object> items = GetSelectedNodeItems();
            ShowItemsOnGrid(items);
        }

        private List<object> GetSelectedNodeItems()
        {
            List<ExpenditureRecord> items = _Customers;
            ExpenditureType pc = null;
            if (this.categoryTree.SelectedNode != null) pc = this.categoryTree.SelectedNode.Tag as ExpenditureType;
            if (pc != null) items = _Customers.Where(it => it.Category == pc.ID).ToList();

            return (from p in items
                    orderby p.ExpenditureDate descending
                    select (object)p).ToList();
        }

        private TreeNode AddNode(ExpenditureType pc, TreeNode parent)
        {
            TreeNode node = parent.Nodes.Add(string.Format("{0}", pc.Name));
            node.Tag = pc;
            return node;
        }
        #endregion

        #region 重写基类方法和处理事件
        protected override void Init()
        {
            base.Init();
            InitCategoryTree();
            Operator opt = Operator.Current;
            menu.Items["btn_Add"].Enabled = opt.Permit(Permission.EditExpenditureRecord);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmExpenditureRecordDetail frm = new FrmExpenditureRecordDetail();
            frm.Category = categoryTree.SelectedNode != null ? (categoryTree.SelectedNode.Tag as ExpenditureType) : null;
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            _Customers = (new ExpenditureRecordBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            return GetSelectedNodeItems();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            ExpenditureRecord info = item as ExpenditureRecord;
            row.Cells["colID"].Value = info.ID;
            row.Cells["colExpenditureDate"].Value = info.ExpenditureDate.ToString("yyyy-MM-dd");
            row.Cells["colPaymentMode"].Value = PaymentModeDescription.GetDescription(info.PaymentMode);
            row.Cells["colAmount"].Value = info.Amount;
            row.Cells["colCategory"].Value = info.Category;
            row.Cells["colCheckNum"].Value = info.CheckNum;
            row.Cells["colRequest"].Value = info.Request;
            row.Cells["colPayee"].Value = info.Payee;
            row.Cells["colOrderID"].Value = info.OrderID;
            row.Cells["colMemo"].Value = info.Memo;
            if (info.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
            if (_Customers == null || !_Customers.Exists(it => it.ID == info.ID))
            {
                if (_Customers == null) _Customers = new List<ExpenditureRecord>();
                _Customers.Add(info);
            }
        }

        protected override bool DeletingItem(object item)
        {
            return false;
        }
        #endregion

        #region 事件处理程序
        private void mnu_Cancel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("是否要取消此项?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ExpenditureRecord item = dataGridView1.SelectedRows[0].Tag as ExpenditureRecord;
                    CommandResult ret = (new ExpenditureRecordBLL(AppSettings.Current.ConnStr)).Cancel(item, Operator.Current.Name);
                    if (ret.Result == ResultCode.Successful)
                    {
                        ShowItemInGridViewRow(dataGridView1.SelectedRows[0], item);
                    }
                    else
                    {
                        MessageBox.Show(ret.Message);
                    }
                }
            }
        }
        #endregion

        #region 类别树右键菜单
        private void categoryTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectNode(e.Node);
        }

        private void mnu_FreshTree_Click(object sender, EventArgs e)
        {
            InitCategoryTree();
            SelectNode(categoryTree.Nodes[0]);
        }

        private void mnu_AddCategory_Click(object sender, EventArgs e)
        {
            ExpenditureType pc = categoryTree.SelectedNode.Tag as ExpenditureType;
            FrmExpenditureTypeDetail frm = new FrmExpenditureTypeDetail();
            frm.IsAdding = true;
            frm.ParentCategory = pc;
            frm.ItemAdded += delegate(object obj, ItemAddedEventArgs args)
            {
                ExpenditureType item = args.AddedItem as ExpenditureType;
                AddNode(item, categoryTree.SelectedNode);
            };
            frm.ShowDialog();
        }

        private void mnu_DeleteCategory_Click(object sender, EventArgs e)
        {
            ExpenditureType pc = categoryTree.SelectedNode.Tag as ExpenditureType;
            if (pc != null && MessageBox.Show("是否删除此类别及其子项?", "询问", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                CommandResult ret = (new ExpenditureTypeBLL(AppSettings.Current.ConnStr)).Delete(pc);
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
            ExpenditureType pc = categoryTree.SelectedNode.Tag as ExpenditureType;
            FrmExpenditureTypeDetail frm = new FrmExpenditureTypeDetail();
            frm.IsAdding = false;
            frm.UpdatingItem = pc;
            frm.ItemUpdated += delegate(object obj, ItemUpdatedEventArgs args)
            {
                categoryTree.SelectedNode.Text = string.Format("{0}", pc.Name);
            };
            frm.ShowDialog();
        }
        #endregion
    }
}
