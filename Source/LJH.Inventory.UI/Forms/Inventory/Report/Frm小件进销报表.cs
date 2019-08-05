using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.GeneralLibrary;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.Inventory.UI.Forms;
using LJH.Inventory.UI.Forms.General;
using LJH.Inventory.UI.Forms.Sale;

namespace LJH.Inventory.UI.Forms.Inventory.Report
{
    public partial class Frm小件进销报表 : FrmReportBase
    {
        public Frm小件进销报表()
        {
            InitializeComponent();
        }

        private decimal _balance = 0;
        public Product Product { get; set; }

        #region 重写基类方法
        protected override void Init()
        {
            ucDateTimeInterval1.ShowTime = false;
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            base.Init();
            if (Product != null) btnSearch.PerformClick();
        }

        protected override List<object> GetDataSource()
        {
            _balance = 0;
            if (Product == null)
            {
                MessageBox.Show("没有指定小件");
                return null;
            }
            List<小件往来项> ret = new List<小件往来项>();
            StackInRecordSearchCondition con = new StackInRecordSearchCondition();
            con.ProductID = Product.ID;
            con.States = new List<SheetState>();
            con.States.Add(SheetState.已入库);
            List<StackInRecord> inItems = (new StackInSheetBLL(AppSettings.Current.ConnStr)).GetInventoryRecords(con).QueryObjects;
            if (inItems != null && inItems.Count > 0)
            {
                ret.AddRange(from it in inItems
                             select new 小件往来项()
                             {
                                 Name = it.LastActiveDate.ToString("yyyy-MM-dd"),
                                 CreateDate = it.LastActiveDate,
                                 单据编号 = it.SheetNo,
                                 入库 = it.Count
                             });
            }

            StackOutRecordSearchCondition con1 = new StackOutRecordSearchCondition();
            con1.ProductID = Product.ID;
            con1.States = new List<SheetState>();
            con1.States.Add(SheetState.已发货);
            con1.SheetTypes = new List<StackOutSheetType>();
            con1.SheetTypes.Add(StackOutSheetType.DeliverySheet);
            List<StackOutRecord> outItems = (new StackOutSheetBLL(AppSettings.Current.ConnStr)).GetDeliveryRecords(con1).QueryObjects;
            if (outItems != null && outItems.Count > 0)
            {
                ret.AddRange(from it in outItems
                             select new 小件往来项()
                             {
                                 Name = it.SheetDate.ToString("yyyy-MM-dd"),
                                 CreateDate = it.SheetDate,
                                 单据编号 = it.SheetNo,
                                 出货 = it.Count,
                                 来源卷重 = it.SourceRollWeight.HasValue ? it.SourceRollWeight.Value.ToString("F3") : null,
                                 Memo = it.Memo
                             });
            }

            InventoryCheckRecordSearchCondition con2 = new InventoryCheckRecordSearchCondition();
            con2.ProductID = Product.ID;
            List<InventoryCheckRecord> records = (new InventoryCheckRecordBLL(AppSettings.Current.ConnStr)).GetItems(con2).QueryObjects;
            if (records != null && records.Count > 0)
            {
                ret.AddRange(from it in records
                             select new 小件往来项()
                             {
                                 Name = it.CheckDateTime.ToString("yyyy-MM-dd"),
                                 CreateDate = it.CheckDateTime,
                                 单据编号 = it.CheckCount > it.Inventory ? "盘盈" : "盘亏",
                                 入库 = it.CheckCount > it.Inventory ? it.CheckCount - it.Inventory : 0,
                                 出货 = it.Inventory > it.CheckCount ? it.Inventory - it.CheckCount : 0,
                                 Memo = it.Memo
                             });
            }

            var con3 = new SliceRecordSearchCondition() { ProductID = Product.ID };
            var items3 = new SteelRollSliceRecordBLL(AppSettings.Current.ConnStr).GetItems(con3).QueryObjects;
            if (items3 != null && items3.Count > 0)
            {
                ret.AddRange(from it in items3
                             select new 小件往来项()
                             {
                                 Name = it.SliceDate.ToString("yyyy-MM-dd"),
                                 CreateDate = it.SliceDate,
                                 单据编号 = "加工入库",
                                 入库 = it.Count,
                                 来源卷重 = it.SourceRollWeight.HasValue ? it.SourceRollWeight.Value.ToString("F3") : null,
                                 来源卷 = it.SliceSource,
                                 操作员 = it.Operator,
                                 Memo = it.Memo
                             });
            }

            var con4 = new ProductInventoryItemSearchCondition();
            con4.ProductID = Product.ID;
            con4.HasRemain = true;
            var item4 = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).GetItems(con4).QueryObjects;
            _balance = item4.Where(it => it.State == ProductInventoryState.Inventory || it.State == ProductInventoryState.Reserved || it.State == ProductInventoryState.WaitShipping).Sum(it => it.Count);
            if (txtWeight.DecimalValue > 0) ret = ret.Where(it => !string.IsNullOrEmpty(it.来源卷重) && it.来源卷重.Contains(txtWeight.Text)).ToList();
            ret = (from it in ret
                   where it.CreateDate >= ucDateTimeInterval1.StartDateTime && it.CreateDate <= ucDateTimeInterval1.EndDateTime
                   orderby it.CreateDate descending
                   select it).ToList();
            lblTotalIn.Text = string.Format("总入库数量 {0}", ret.Sum(it => it.入库).Trim());
            lblTotalOut.Text = string.Format("总出库数量 {0}", ret.Sum(it => it.出货).Trim());
            return ret.Select(it => (object)it).ToList();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            小件往来项 cp = item as 小件往来项;
            row.Tag = cp;
            row.Cells["colSheetDate"].Value = cp.Name;
            row.Cells["colSheetID"].Value = cp.单据编号;
            row.Cells["col数量"].Value = cp.入库 > 0 ? cp.入库.Trim() : cp.出货.Trim();
            row.Cells["col余数"].Value = _balance.Trim();
            row.Cells["col操作员"].Value = cp.操作员;
            row.Cells["col来源卷"].Value = cp.来源卷重;
            row.Cells["colMemo"].Value = cp.Memo;
            row.DefaultCellStyle.ForeColor = cp.入库 > 0 ? Color.Blue : Color.Red;
            _balance = _balance + cp.出货 - cp.入库;
        }
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            var pi = dataGridView1.Rows[e.RowIndex].Tag as 小件往来项;
            if (GridView.Columns[e.ColumnIndex].Name == "colSheetID" && !string.IsNullOrEmpty(pi.单据编号))
            {
                var sheet = new StackOutSheetBLL(AppSettings.Current.ConnStr).GetByID(pi.单据编号).QueryObject;
                if (sheet != null)
                {
                    Inventory.FrmStackOutSheetDetail frm = new Inventory.FrmStackOutSheetDetail();
                    frm.IsAdding = false;
                    frm.IsForView = true;
                    frm.UpdatingItem = sheet;
                    frm.ShowDialog();
                }
            }
        }
    }

    internal class 小件往来项
    {
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public string 单据编号 { get; set; }

        public decimal 出货 { get; set; }

        public decimal 入库 { get; set; }

        public string 操作员 { get; set; }

        public string 来源卷重 { get; set; }

        public Guid? 来源卷 { get; set; }

        public string Memo { get; set; }
    }
}
