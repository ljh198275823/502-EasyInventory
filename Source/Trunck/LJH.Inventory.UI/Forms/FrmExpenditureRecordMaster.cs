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

        #region 重写基类方法和处理事件
        protected override void Init()
        {
            base.Init();
            OperatorInfo opt = OperatorInfo.CurrentOperator;
            menu.Items["btn_Add"].Enabled = opt.Permit(Permission.EditExpenditureRecord);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmExpenditureRecordDetail();
        }

        protected override List<object> GetDataSource()
        {
            List<ExpenditureRecord> items = (new ExpenditureRecordBLL(AppSettings.CurrentSetting.ConnectString)).GetItems(null).QueryObjects;
            if (items != null && items.Count > 0)
            {
                return (from cp in items
                        orderby cp.ExpenditureDate descending
                        select (object)cp).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            ExpenditureRecord info = item as ExpenditureRecord;
            row.Cells["colID"].Value = info.ID;
            row.Cells["colExpenditureDate"].Value = info.ExpenditureDate.ToString("yyyy-MM-dd");
            row.Cells["colPaymentMode"].Value = PaymentModeDescription.GetDescription(info.PaymentMode);
            row.Cells["colAmount"].Value = info.Amount;
            row.Cells["colCategory"].Value = info.Category;
            row.Cells["colMemo"].Value = info.Memo;
            row.Cells["colCancelDate"].Value = info.CancelDate;
            row.Cells["colCancelOperator"].Value = info.CancelOperator;
            if (info.CancelDate != null)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
        }

        protected override bool DeletingItem(object item)
        {
            return false;
        }
        #endregion

        private void mnu_Cancel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("是否要取消此项?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ExpenditureRecord item = dataGridView1.SelectedRows[0].Tag as ExpenditureRecord;
                    CommandResult ret = (new ExpenditureRecordBLL(AppSettings.CurrentSetting.ConnectString)).Cancel(item, OperatorInfo.CurrentOperator.OperatorName);
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
    }
}
