using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示单据的操作，如果审批，发货，取消等。
    /// </summary>
    public class DocumentOperation
    {
        #region 构造函数
        public DocumentOperation()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 获取或设置单据ID
        /// </summary>
        public string DocumentID { get; set; }
        /// <summary>
        /// 获取或设置单据类型
        /// </summary>
        public string DocumentType { get; set; }
        /// <summary>
        /// 获取或设置操作日期
        /// </summary>
        public DateTime  OperatDate { get; set; }
        /// <summary>
        /// 获取或设置操作
        /// </summary>
        public string Operation { get; set; }
        /// <summary>
        /// 获取或设置操作员
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 获取或设置当前操作后单据的状态
        /// </summary>
        public SheetState State { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        public string Memo { get; set; }
        #endregion
    }
}
