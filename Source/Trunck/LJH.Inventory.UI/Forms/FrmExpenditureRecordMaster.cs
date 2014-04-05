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
        private List<Button> _Buttons = new List<Button>();
        #endregion

        #region 重写基类方法和处理事件
        protected override void Init()
        {
            base.Init();
            Operator opt = Operator.Current;
            menu.Items["btn_Add"].Enabled = opt.Permit(Permission.EditExpenditureRecord);
            List<ExpenditureType> items = (new ExpenditureTypeBLL(AppSettings.Current.ConnStr)).GetAll().QueryObjects;
            if (items != null && items.Count > 0)
            {
                Button b = new Button();
                b.Name = "全部";
                b.BackColor = SystemColors.ControlDark;
                b.Size = new Size(200, 42);
                b.Dock = DockStyle.Top;
                b.FlatStyle = FlatStyle.Popup;
                _Buttons.Add(b);

                foreach (ExpenditureType pc in items)
                {
                    Button button = new Button();
                    button.Name = pc.Name;
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
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmExpenditureRecordDetail();
        }

        protected override List<object> GetDataSource()
        {
            List<ExpenditureRecord> items = (new ExpenditureRecordBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            List<object> records = null;
            if (_Buttons.Count > 1)
            {
                for (int i = 1; i < _Buttons.Count; i++)
                {
                    records = (from p in items
                               where p.Category == _Buttons[i].Name
                               orderby p.ID ascending
                               select (object)p).ToList();
                    _Buttons[i].Tag = records;
                    _Buttons[i].Text = string.Format("{0} ({1})", _Buttons[i].Name, records == null ? 0 : records.Count);
                }
            }

            records = (from p in items
                       orderby p.ID ascending
                       select (object)p).ToList();
            if (_Buttons.Count > 0)
            {
                _Buttons[0].Tag = records;
                _Buttons[0].Text = string.Format("{0} ({1})", _Buttons[0].Name, records == null ? 0 : records.Count);
            }
            return records;
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
    }
}
