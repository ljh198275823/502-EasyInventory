using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel.SearchCondition;

namespace LJH.Inventory.UI.ExcelExporter
{
    /// <summary>
    /// 表示一个送货单导出电子表格类
    /// </summary>
    public class DeliverySheetExporter
    {
        public DeliverySheetExporter(string modalPath)
        {
            ReportModal = modalPath;
        }

        /// <summary>
        /// 获取或设置EXCEL模板的路径
        /// </summary>
        public string ReportModal { get; set; }

        /// <summary>
        /// 导出操作员当班信息到EXCEL中
        /// </summary>
        /// <param name="optLog"></param>
        public void Export(DeliverySheet deliverySheet, string path)
        {
            Application app = new Application();
            Workbook book = null;
            book = app.Workbooks.Add(ReportModal);
            try
            {
                Worksheet sheet = book.ActiveSheet as Worksheet;
                FillDeliverySheet(sheet, deliverySheet);
                book.SaveAs(path, XlFileFormat.xlXMLSpreadsheet, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                book.Close(false, Type.Missing, Type.Missing);
            }
        }
        /// <summary>
        /// 直接打印送货单
        /// </summary>
        /// <param name="deliverySheet"></param>
        public void PrintDeliverySheet(DeliverySheet deliverySheet)
        {
            Application app = new Application();
            Workbook book = null;
            book = app.Workbooks.Add(ReportModal);
            try
            {
                Worksheet sheet = book.ActiveSheet as Worksheet;
                FillDeliverySheet(sheet, deliverySheet);
                sheet.PrintOutEx(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                book.Close(false, Type.Missing, Type.Missing);
            }
        }

        #region 私有方法
        private void FillDeliverySheet(Worksheet sheet, DeliverySheet deliverySheet)
        {
            Range r = sheet.get_Range("A1", Type.Missing);
            r.Value2 = UserSettings.Current.CompanyName;
            r = sheet.get_Range("B" + 2, Type.Missing);
            r.Value2 = "'" + deliverySheet.ID;
            r = sheet.get_Range("D" + 2, Type.Missing);
            r.Value2 = deliverySheet.LastActiveDate.ToString("yyyy-MM-dd");
            CompanyInfo customer = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(deliverySheet.CustomerID).QueryObject;
            r = sheet.get_Range("B" + 3, Type.Missing);
            r.Value2 = customer != null ? customer.Name : string.Empty;
            r = sheet.get_Range("D" + 3, Type.Missing);
            r.Value2 = deliverySheet.Linker;
            r = sheet.get_Range("G" + 3, Type.Missing);
            r.Value2 = "'" + deliverySheet.LinkerPhoneCall;

            r = sheet.get_Range("B" + 4, Type.Missing);
            r.Value2 = deliverySheet.Address;

            r = sheet.get_Range("B" + 5, Type.Missing);
            r.Value2 = deliverySheet.Memo;

            int count = 7;
            List<string> pids = deliverySheet.Items.Select(it => it.ProductID).ToList();
            List<Product> ps = (new ProductBLL(AppSettings.Current.ConnStr)).GetItems(new ProductSearchCondition() { ProductIDS = pids }).QueryObjects;
            foreach (DeliveryItem item in deliverySheet.Items)
            {
                if (count < 17)
                {
                    Product p = ps.SingleOrDefault(it => it.ID == item.ProductID);
                    r = sheet.get_Range("A" + count, Type.Missing);
                    r.Value2 = "'" + item.ProductID;
                    r = sheet.get_Range("B" + count, Type.Missing);
                    r.Value2 = p != null ? p.Name : string.Empty;
                    r = sheet.get_Range("C" + count, Type.Missing);
                    r.Value2 = p != null ? p.Specification : string.Empty;
                    r = sheet.get_Range("D" + count, Type.Missing);
                    r.Value = item.Unit;
                    r = sheet.get_Range("E" + count, Type.Missing);
                    r.Value2 = item.Price;
                    r = sheet.get_Range("F" + count, Type.Missing);
                    r.Value2 = item.Count;
                    r = sheet.get_Range("G" + count, Type.Missing);
                    r.Value2 = item.Amount;
                    count++;
                }
            }
        }

        private void AddBorder(Range r)
        {
            r.Borders.LineStyle = XlLineStyle.xlContinuous;
        }
        #endregion
    }
}
