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
            txtCategory.Init();
            this.cmbSpecification.Init(new List<string> { ProductModel.原材料, ProductModel.开平, ProductModel.开卷, ProductModel.开吨, ProductModel.开条 });
            base.Init();
            if (Product != null) btnSearch.PerformClick();
            btnSaveAs.Enabled = Operator.Current.Permit(Permission.小件进销报表, PermissionActions.导出);
        }

        protected override List<object> GetDataSource()
        {
            _balance = 0;
            if (string.IsNullOrEmpty(cmbSpecification.Text))
            {
                MessageBox.Show("没有指定小件规格");
                return null;
            }
            if (string.IsNullOrEmpty(txtCategory.Text))
            {
                MessageBox.Show("没有指定小件类别");
                return null;
            }
            if (txtLength.DecimalValue == 0)
            {
                MessageBox.Show("没有指定小件长度");
                return null;
            }
            var pcon = new ProductSearchCondition() { CategoryID = txtCategory.SelectedCategoryID, Specification = cmbSpecification.Text };
            List<Product> ps =new ProductBLL(AppSettings .Current .ConnStr ). GetItems(pcon).QueryObjects;
            if (ps != null && ps.Count > 0) Product = ps.FirstOrDefault(it => it.Length == txtLength.DecimalValue);
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
                                 客户 = it.Customer != null ? it.Customer.Name : null,
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
            if (cp.入库 > 0) row.Cells["col进货"].Value = cp.入库.Trim();
            if (cp.出货 > 0) row.Cells["col出货"].Value = cp.出货.Trim();
            row.Cells["col余数"].Value = _balance.Trim();
            row.Cells["col客户"].Value = cp.客户;
            row.Cells["col来源卷"].Value = cp.来源卷重;
            row.Cells["colMemo"].Value = cp.Memo;
            row.Cells["col操作员"].Value = cp.操作员;
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

        public string 客户 { get; set; }

        public string Memo { get; set; }
    }
}
