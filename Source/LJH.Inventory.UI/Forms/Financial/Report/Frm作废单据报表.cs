using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.Inventory.UI.Forms.Sale;
using LJH.Inventory.UI.Forms.Inventory;

namespace LJH.Inventory.UI.Forms.Financial.Report
{
    public partial class Frm作废单据报表 : FrmReportBase
    {
        public Frm作废单据报表()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override void Init()
        {
            ucDateTimeInterval1.ShowTime = false;
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            btnSaveAs.Enabled = Operator.Current.Permit(Permission.单据作废记录报表, PermissionActions.导出);
            base.Init();
        }

        protected override List<object> GetDataSource()
        {
            var dcon = new DocumentSearchCondition();
            dcon.Operation = "作废";
            dcon.CreateDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, DateTime.MaxValue);
            var items = new DocumentOperationBLL(AppSettings.Current.ConnStr).GetItems(dcon).QueryObjects;
            foreach (var ctrl in pnlDocType.Controls)
            {
                if (ctrl is CheckBox)
                {
                    var chk = ctrl as CheckBox;
                    if (!chk.Checked) items.RemoveAll(it => it.DocumentType == chk.Text);
                }
            }
            return (from item in items
                    orderby item.OperatDate ascending
                    select (object)item).ToList();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            DocumentOperation doc = item as DocumentOperation;
            row.Tag = doc;
            row.Cells["colSheetID"].Value = doc.DocumentID;
            row.Cells["col单据类别"].Value = doc.DocumentType;
            row.Cells["col作废日期"].Value = doc.OperatDate.ToString("yyyy-MM-dd HH:mm:ss");
            row.Cells["col操作员"].Value = doc.Operator;
            row.Cells["col作废原因"].Value = doc.Memo;
        }
        #endregion

        #region 事件处理程序
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Tag == null) return;
                var doc = dataGridView1.Rows[e.RowIndex].Tag as DocumentOperation;
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "colSheetID")
                {
                    ISheet<string> sheet = null;
                    if (doc.DocumentType == "送货单")
                    {
                        sheet = new StackOutSheetBLL(AppSettings.Current.ConnStr).GetByID(doc.DocumentID).QueryObject;
                        if (sheet != null) { Show送货单(sheet as StackOutSheet); return; }
                    }

                    sheet = new CustomerPaymentBLL(AppSettings.Current.ConnStr).GetByID(doc.DocumentID).QueryObject;
                    if (sheet != null) { Show收付款流水表(sheet as CustomerPayment); return; }

                    sheet = new OtherReceivableSheetBLL(AppSettings.Current.ConnStr).GetByID(doc.DocumentID).QueryObject;
                    if (sheet != null) { Show客户应收单(sheet as OtherReceivableSheet); return; }

                    sheet = new StackOutSheetBLL(AppSettings.Current.ConnStr).GetByID(doc.DocumentID).QueryObject;
                    if (sheet != null) { Show送货单(sheet as StackOutSheet); return; }
                }
            }
        }

        private void Show收付款流水表(CustomerPayment sheet)
        {
            if (sheet.ClassID == CustomerPaymentType.客户收款)
            {
                Frm收付款流水明细 frm = new Frm收付款流水明细();
                frm.UpdatingItem = sheet;
                frm.PaymentType = sheet.ClassID;
                frm.ShowDialog();
            }
            else if (sheet.ClassID == CustomerPaymentType.供应商付款)
            {
                var frm = new Frm供应商付款流水明细();
                frm.UpdatingItem = sheet;
                frm.PaymentType = sheet.ClassID;
                frm.ShowDialog();
            }
            else if (sheet.ClassID == CustomerPaymentType.转公账)
            {
                Frm转公账 frm = new Frm转公账();
                frm.UpdatingItem = sheet;
                frm.ShowDialog();
            }
            else if (sheet.ClassID == CustomerPaymentType.转账)
            {
                Frm转账 frm = new Frm转账();
                frm.UpdatingItem = sheet;
                frm.ShowDialog();
            }
            else if (sheet.ClassID == CustomerPaymentType.其它收款)
            {
                Frm其它收款 frm = new Frm其它收款();
                frm.UpdatingItem = sheet;
                frm.ShowDialog();
            }
            else if (sheet.ClassID == CustomerPaymentType.管理费用)
            {
                Frm管理费用明细 frm = new Frm管理费用明细();
                frm.UpdatingItem = sheet;
                frm.ShowDialog();
            }
            else if (sheet.ClassID == CustomerPaymentType.管理费用退款)
            {
                var frm = new Frm管理费用退款();
                frm.UpdatingItem = sheet;
                frm.ShowDialog();
            }
            else if (sheet.ClassID == CustomerPaymentType.客户退款)
            {
                Frm退款 frm = new Frm退款();
                frm.UpdatingItem = sheet;
                frm.ShowDialog();
            }
            else if (sheet.ClassID == CustomerPaymentType.客户增值税发票 || sheet.ClassID == CustomerPaymentType.供应商增值税发票)
            {
                FrmCustomerTaxBillDetail frm = new FrmCustomerTaxBillDetail();
                frm.TaxType = sheet.ClassID;
                frm.IsAdding = false;
                frm.UpdatingItem = sheet;
                frm.IsForView = true;
                frm.ShowDialog();
            }
        }

        private void Show送货单(StackOutSheet sheet)
        {
            Inventory.FrmStackOutSheetDetail frm = new Inventory.FrmStackOutSheetDetail();
            frm.IsAdding = false;
            frm.IsForView = true;
            frm.UpdatingItem = sheet;
            frm.ShowDialog();
        }

        private void Show客户应收单(OtherReceivableSheet sheet)
        {
            Frm其它应收明细 frm = new Frm其它应收明细();
            frm.ReceivableType = sheet.ClassID;
            frm.UpdatingItem = sheet;
            frm.ShowDialog();
        }
        #endregion

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var ctrl in pnlDocType.Controls)
            {
                if (ctrl is CheckBox)
                {
                    var chk = ctrl as CheckBox;
                    chk.Checked = chkAll.Checked;
                }
            }
        }
    }
}
