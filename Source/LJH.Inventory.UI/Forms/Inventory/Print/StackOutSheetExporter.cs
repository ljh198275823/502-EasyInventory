using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary;

namespace LJH.Inventory.UI.Forms.Inventory.Print
{
    /// <summary>
    /// 表示一个送货单导出电子表格类
    /// </summary>
    public class StackOutSheetExporter
    {
        public StackOutSheetExporter(string modalPath)
        {
            modal = modalPath;
        }

        /// <summary>
        /// 获取或设置EXCEL模板的路径
        /// </summary>
        public string modal;

        private bool _ShowPrice = false;

        /// <summary>
        /// 导出信息到EXCEL中
        /// </summary>
        /// <param name="optLog"></param>
        public List<string> Export(StackOutSheet info, string path, bool showPrice, int itemsPerPage = 10, int itemFirstRow = 7)
        {
            _ShowPrice = showPrice;
            List<string> files = new List<string>();
            var items = info.GetSummaryItems();
            for (int i = 0; i < items.Count; i += itemsPerPage)
            {
                StackOutItem[] temp = new StackOutItem[itemsPerPage];
                items.CopyTo(i, temp, 0, items.Count - i >= temp.Length ? temp.Length : (items.Count - i));
                string file = Path.Combine(path, Guid.NewGuid().ToString() + ".xls");
                files.Add(file);
                using (FileStream fs = new FileStream(modal, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook wb = WorkbookFactory.Create(fs);
                    ISheet sheet = wb.GetSheetAt(0);
                    FillSheetInfo(info, sheet);
                    FillSheetItems(temp, sheet, itemFirstRow);
                    MemoryStream stream = new MemoryStream();
                    wb.Write(stream);
                    var buf = stream.ToArray();
                    //保存为Excel文件
                    using (FileStream fs1 = new FileStream(file, FileMode.Create, FileAccess.Write))
                    {
                        fs1.Write(buf, 0, buf.Length);
                        fs1.Flush();
                    }
                }
            }
            return files;
        }

        private void FillSheetInfo(StackOutSheet info, ISheet sheet)
        {
            for (int i = sheet.FirstRowNum; i < sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row == null) continue;
                for (int j = row.FirstCellNum; j < row.LastCellNum; j++)
                {
                    ICell cell = row.GetCell(j);
                    if (cell != null) FillSheetInfo(info, cell);
                }
            }
        }

        private void FillSheetInfo(StackOutSheet info, ICell cell)
        {
            var express = cell.StringCellValue;
            if (string.IsNullOrEmpty(express)) return;
            if (!express.StartsWith("[") || !express.EndsWith("]")) return;
            if (express == "[送货单号]") cell.SetCellValue(info.ID);
            else if (express == "[送货日期]") cell.SetCellValue(info.SheetDate.ToString("yyyy年MM月dd日"));
            else if (express == "[客户]")
            {
                CompanyInfo customer = new CompanyBLL(AppSettings.Current.ConnStr).GetByID(info.CustomerID).QueryObject;
                if (customer != null) cell.SetCellValue(customer.Name);
            }
            else if (express == "[联系人]") cell.SetCellValue(info.Linker);
            else if (express == "[联系人电话]") cell.SetCellValue(info.LinkerCall);
            else if (express == "[送货司机]") cell.SetCellValue(info.Driver);
            else if (express == "[司机电话]") cell.SetCellValue(info.DriverCall);
            else if (express == "[送货车牌]") cell.SetCellValue(info.CarPlate);
            else if (express == "[送货地址]") cell.SetCellValue(info.Address);
            else if (express == "[开票]") cell.SetCellValue(info.WithTax ? "KP" : "BK");
            else if (express == "[备注]") cell.SetCellValue(info.Memo);
            else if (express == "[付款方式]") cell.SetCellValue(info.付款方式);
            else if (express == "[付款金额]")
            {
                if (_ShowPrice)
                {
                    var finance = new StackOutSheetBLL(AppSettings.Current.ConnStr).GetFinancialStateOf(info.ID).QueryObject;
                    cell.SetCellValue((double)(finance != null ? finance.Paid : 0));
                }
                else cell.SetCellValue(string.Empty);
            }
            else if (express == "[本次欠款]")
            {
                if (_ShowPrice)
                {
                    var finance = new StackOutSheetBLL(AppSettings.Current.ConnStr).GetFinancialStateOf(info.ID).QueryObject;
                    cell.SetCellValue((double)(finance != null ? finance.NotPaid : 0));
                }
                else cell.SetCellValue(string.Empty);
            }
            else if (express == "[累计欠款]")
            {
                var customerState = new CompanyBLL(AppSettings.Current.ConnStr).GetCustomerState(info.CustomerID).QueryObject;
                decimal total = customerState != null ? (customerState.Recievables - customerState.Prepay) : 0;
                if (info.State != LJH.Inventory.BusinessModel.SheetState.已发货) total += info.Amount; //如果送货单还未处于送货状态，说明此单的还没有加到应收里面，此时总欠款要加上这一笔
                cell.SetCellValue((double)total);
            }
            else if (express == "[总金额]")
            {
                if (_ShowPrice) cell.SetCellValue((double)info.Amount);
                else cell.SetCellValue(string.Empty);
            }
            else if (express == "[大写总金额]")
            {
                if (_ShowPrice) cell.SetCellValue(RMBHelper.NumGetStr((double)info.Amount));
                else cell.SetCellValue(string.Empty);
            }
        }

        private void FillSheetItems(StackOutItem[] items, ISheet sheet, int firstRow)
        {
            Dictionary<int, string> templates = new Dictionary<int, string>();
            IRow row = sheet.GetRow(firstRow);
            if (row == null) return;
            for (int i = row.FirstCellNum; i < row.LastCellNum; i++)
            {
                ICell cell = row.GetCell(i);
                templates.Add(i, cell.StringCellValue);
            }
            for (int i = 0; i < items.Length; i++)
            {
                row = sheet.GetRow(i + firstRow);
                if (row == null) continue;
                for (int j = row.FirstCellNum; j < row.LastCellNum; j++)
                {
                    ICell cell = row.GetCell(j);
                    if (cell == null) continue;
                    if (templates.ContainsKey(j) && items[i] != null) FillSheetItemInfo(items[i], templates[j], cell);
                }
            }
        }

        private void FillSheetItemInfo(StackOutItem item, string express, ICell cell)
        {
            if (express == "[产品类别]")
            {
                var p = new ProductBLL(AppSettings.Current.ConnStr).GetByID(item.ProductID).QueryObject;
                cell.SetCellValue(p.Category.Name);
            }
            else if (express == "[产品规格]")
            {
                var p = new ProductBLL(AppSettings.Current.ConnStr).GetByID(item.ProductID).QueryObject;
                cell.SetCellValue(p.Specification);
            }
            else if (express == "[产品长度]")
            {
                cell.SetCellValue(item.Length.HasValue ? item.Length.Value.ToString("F3") : string.Empty);
            }
            else if (express == "[产品数量]")
            {
                cell.SetCellValue(item.Count.ToString("F0"));
            }
            else if (express == "[产品重量]")
            {
                cell.SetCellValue(item.TotalWeight.HasValue ? item.TotalWeight.Value.ToString("F3") : string.Empty);
            }
            else if (express == "[产品类型]")
            {
                var p = new ProductBLL(AppSettings.Current.ConnStr).GetByID(item.ProductID).QueryObject;
                cell.SetCellValue(p.Model == "原材料" ? "卷" : p.Model);
            }
            else if (express == "[产品单价]")
            {
                if (_ShowPrice) cell.SetCellValue((Double)item.Price);
                else cell.SetCellValue(string.Empty);
            }
            else if (express == "[产品金额]")
            {
                if (_ShowPrice) cell.SetCellValue((Double)item.Amount);
                else cell.SetCellValue(string.Empty);
            }
            else if (express == "[产品备注]")
            {
                cell.SetCellValue(item.Memo);
            }
        }
    }
}
