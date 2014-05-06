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
    public partial class FrmExpenditureRecordMaster : FrmMasterBase
    {
        public FrmExpenditureRecordMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<ExpenditureRecord> _Sheets = null;
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> objs = FilterData();
            ShowItemsOnGrid(objs);
        }

        private List<object> FilterData()
        {
            List<ExpenditureRecord> items = _Sheets;
            if (this.categoryTree.SelectedNode != null)
            {
                List<ExpenditureType> pcs = null;
                pcs = this.categoryTree.GetCategoryofNode(this.categoryTree.SelectedNode);
                if (pcs != null && pcs.Count > 0)
                {
                    items = items.Where(it => pcs.Exists(c => c.ID == it.Category)).ToList();
                }
                else
                {
                    items = null;
                }
            }
            if (items != null && items.Count > 0)
            {
                items = items.Where(item => ((item.State == SheetState.Add && chkAdded.Checked) ||
                                        (item.State == SheetState.Approved && chkApproved.Checked) ||
                                        (item.State == SheetState.Canceled && chkNullify.Checked))).ToList();
            }
            List<object> objs = null;
            if (items != null && items.Count > 0) objs = (from item in items orderby item.ID descending select (object)item).ToList();
            return objs;
        }
        #endregion

        #region 重写基类方法和处理事件
        protected override void ReFreshData()
        {
            this.categoryTree.Init();
            base.ReFreshData();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.Edit);
            mnu_AddExpenditure.Enabled = Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.Edit);
            mnu_AddCategory.Enabled = Operator.Current.Permit(Permission.ExpenditureType, PermissionActions.Edit);
            mnu_DeleteCategory.Enabled = Operator.Current.Permit(Permission.ExpenditureType, PermissionActions.Edit);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmExpenditureRecordDetail frm = new FrmExpenditureRecordDetail();
            frm.Category = categoryTree.SelectedNode != null ? (categoryTree.SelectedNode.Tag as ExpenditureType) : null;
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            _Sheets = (new ExpenditureRecordBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            return FilterData();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            ExpenditureRecord info = item as ExpenditureRecord;
            row.Cells["colID"].Value = info.ID;
            row.Cells["colLastActiveDate"].Value = info.LastActiveDate.ToString("yyyy-MM-dd");
            row.Cells["colPaymentMode"].Value = PaymentModeDescription.GetDescription(info.PaymentMode);
            row.Cells["colAmount"].Value = info.Amount;
            ExpenditureType et = categoryTree.GetExpenditureType(info.Category);
            row.Cells["colCategory"].Value = et != null ? et.Name : string.Empty;
            row.Cells["colCheckNum"].Value = info.CheckNum;
            row.Cells["colRequest"].Value = info.Request;
            row.Cells["colPayee"].Value = info.Payee;
            row.Cells["colOrderID"].Value = info.OrderID;
            row.Cells["colState"].Value = SheetStateDescription.GetDescription(info.State);
            row.Cells["colMemo"].Value = info.Memo;
            if (info.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
            if (_Sheets == null || !_Sheets.Exists(it => it.ID == info.ID))
            {
                if (_Sheets == null) _Sheets = new List<ExpenditureRecord>();
                _Sheets.Add(info);
            }
        }

        protected override void ShowItemsOnGrid(List<object> items)
        {
            base.ShowItemsOnGrid(items);
            Filter(txtKeyword.Text.Trim());
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

    }
}
