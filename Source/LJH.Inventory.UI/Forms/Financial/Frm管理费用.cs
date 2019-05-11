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
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class Frm管理费用 : FrmMasterBase
    {
        public Frm管理费用()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<CustomerPayment> _Sheets = null;
        private List<Account> _AllAccounts = null;
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> objs = FilterData();
            ShowItemsOnGrid(objs);
        }

        private List<object> FilterData()
        {
            List<CustomerPayment> items = _Sheets;
            if (this.categoryTree.SelectedNode != null)
            {
                List<ExpenditureType> pcs = null;
                pcs = this.categoryTree.GetCategoryofNode(this.categoryTree.SelectedNode);
                if (pcs != null && pcs.Count > 0)
                {
                    items = items.Where(it => pcs.Exists(c => c.ID == it.GetProperty("费用类别"))).ToList();
                }
                else
                {
                    items = null;
                }
            }
            if (items != null && items.Count > 0)
            {
                items = items.Where(item => ((item.State == SheetState.新增 && chkAdded.Checked) ||
                                        (item.State == SheetState.已审核 && chkApproved.Checked) ||
                                        (item.State == SheetState.作废 && chkNullify.Checked))).ToList();
            }
            List<object> objs = null;
            if (items != null && items.Count > 0) objs = (from item in items orderby item.ID descending select (object)item).ToList();
            return objs;
        }
        #endregion

        #region 重写基类方法和处理事件
        protected override void Init()
        {
            base.Init();
            this.ucDateTimeInterval1.Init();
            this.ucDateTimeInterval1.SelectThisMonth();
        }

        public override void ReFreshData()
        {
            this.categoryTree.Init();
            base.ReFreshData();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            mnu_新建管理费用.Enabled = Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.Edit);
            mnu_新建管理费用退款.Enabled = Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.Edit);
            mnu_AddExpenditure.Enabled = Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.Edit);
            mnu_AddCategory.Enabled = Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.Edit);
            mnu_DeleteCategory.Enabled = Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.Edit);
        }

        private void PerformAddData(CustomerPaymentType ct)
        {
            try
            {
                FrmDetailBase frm = null;
                if (ct == CustomerPaymentType.管理费用) frm = new Frm管理费用明细();
                else if (ct == CustomerPaymentType.管理费用退款) frm = new Frm管理费用退款();
                if (frm != null)
                {
                    frm.IsAdding = true;
                    frm.ItemAdded += delegate(object obj, ItemAddedEventArgs args)
                    {
                        Add_And_Show_Row(args.AddedItem);
                    };
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        protected override void PerformUpdateData()
        {
            if (this.GridView != null && this.GridView.SelectedRows != null && this.GridView.SelectedRows.Count > 0)
            {
                CustomerPayment pre = this.GridView.SelectedRows[0].Tag as CustomerPayment;
                if (pre != null)
                {
                    FrmDetailBase frm = null;
                    if (pre.ClassID == CustomerPaymentType.管理费用) frm = new Frm管理费用明细();
                    else if (pre.ClassID == CustomerPaymentType.管理费用退款) frm = new Frm管理费用退款();
                    if (frm != null)
                    {
                        frm.IsAdding = false;
                        frm.UpdatingItem = pre;
                        frm.ItemUpdated += delegate(object obj, ItemUpdatedEventArgs args)
                        {
                            ShowItemInGridViewRow(this.GridView.SelectedRows[0], args.UpdatedItem);
                        };
                        frm.ShowDialog();
                    }
                }
            }
        }

        protected override List<object> GetDataSource()
        {
            _AllAccounts = new AccountBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            if (SearchCondition == null)
            {
                CustomerPaymentSearchCondition con = new CustomerPaymentSearchCondition();
                con.SheetDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
                con.PaymentTypes = new List<CustomerPaymentType>() { CustomerPaymentType.管理费用, CustomerPaymentType.管理费用退款 };
                _Sheets = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            }
            else
            {
                _Sheets = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
                if (_Sheets != null) _Sheets.RemoveAll(it => it.ClassID != CustomerPaymentType.管理费用 && it.ClassID != CustomerPaymentType.管理费用退款);
            }
            return FilterData();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CustomerPayment info = item as CustomerPayment;
            row.Tag = info;
            row.Cells["colID"].Value = info.ID;
            row.Cells["colSheetDate"].Value = info.SheetDate.ToString("yyyy-MM-dd");
            if (info.ClassID == CustomerPaymentType.管理费用) row.Cells["colAmount"].Value = info.Amount;
            else if (info.ClassID == CustomerPaymentType.管理费用退款) row.Cells["col退款"].Value = info.Amount;
            row.Cells["colCategory"].Value = info.GetProperty("费用类别");
            Account ac = null;
            if (!string.IsNullOrEmpty(info.AccountID) && _AllAccounts != null && _AllAccounts.Count > 0) ac = _AllAccounts.SingleOrDefault(it => it.ID == info.AccountID);
            row.Cells["colAccount"].Value = ac != null ? ac.Name : null;
            row.Cells["colRequest"].Value = info.GetProperty("申请人");
            row.Cells["colPayer"].Value = info.Payer;
            row.Cells["colState"].Value = SheetStateDescription.GetDescription(info.State);
            row.Cells["colMemo"].Value = info.Memo;
            if (info.State == SheetState.作废)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
            else
            {
                row.DefaultCellStyle.ForeColor = info.ClassID == CustomerPaymentType.管理费用 ? Color.Black : Color.Red;
            }
            if (_Sheets == null || !_Sheets.Exists(it => it.ID == info.ID))
            {
                if (_Sheets == null) _Sheets = new List<CustomerPayment>();
                _Sheets.Add(info);
            }
            
        }

        protected override void ShowItemsOnGrid(List<object> items)
        {
            base.ShowItemsOnGrid(items);
            Filter(txtKeyword.Text.Trim());
            decimal _Amount = 0;
            decimal _退款 = 0;
            foreach (DataGridViewRow row in GridView.Rows)
            {
                if (row.Visible)
                {
                    CustomerPayment r = row.Tag as CustomerPayment;
                    if (r.ClassID == CustomerPaymentType.管理费用) _Amount += r.State != SheetState.作废 ? r.Amount : 0;
                    else if (r.ClassID == CustomerPaymentType.管理费用退款) _退款 += r.State != SheetState.作废 ? r.Amount : 0;
                }
            }
            lbl合计.Text = string.Format("支出合计：{0:C2} 元", _Amount);
            lbl退款.Text = string.Format("退款合计：{0:C2} 元", _退款);
            lbl结余.Text = string.Format("结余合计：{0:C2} 元",_Amount - _退款);
        }
        #endregion

        #region 类别树右键菜单
        private void mnu_AddCategory_Click(object sender, EventArgs e)
        {
            ExpenditureType pc = categoryTree.SelectedNode.Tag as ExpenditureType;
            FrmExpenditureTypeDetail frm = new FrmExpenditureTypeDetail();
            frm.IsAdding = true;
            frm.ParentCategory = pc;
            frm.ItemAdded += delegate(object obj, ItemAddedEventArgs args)
            {
                ExpenditureType item = args.AddedItem as ExpenditureType;
                categoryTree.AddExpenditureTypeNode(item, categoryTree.SelectedNode);
                categoryTree.SelectedNode.Expand();
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
                categoryTree.Init();
                categoryTree.SelectCategoryNode(pc.ID);
                FreshData();
            };
            frm.ShowDialog();
        }

        private void mnu_AddExpenditure_Click(object sender, EventArgs e)
        {
            PerformAddData();
        }
        #endregion

        #region 事件处理程序
        private void category_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FreshData();
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            FreshData();
        }

        private void chkState_CheckedChanged(object sender, EventArgs e)
        {
            FreshData();
        }

        private void mnu_新建管理费用_Click(object sender, EventArgs e)
        {
            PerformAddData(CustomerPaymentType.管理费用);
        }

        private void mnu_新建管理费用退款_Click(object sender, EventArgs e)
        {
            PerformAddData(CustomerPaymentType.管理费用退款);
        }

        private void ucDateTimeInterval1_ValueChanged(object sender, EventArgs e)
        {
            cMnu_Fresh.PerformClick();
        }
        #endregion
    }
}
