using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class AttachmentHeader
    {
        #region 构造函数
        public AttachmentHeader()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置ID
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置所属的单据ID
        /// </summary>
        public string DocumentID { get; set; }
        /// <summary>
        /// 获取或设置单据类别
        /// </summary>
        public string DocumentType { get; set; }
        /// <summary>
        /// 获取或设置所有人
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// 获取或设置上传时间
        /// </summary>
        public DateTime UploadDateTime { get; set; }
        /// <summary>
        /// 获取或设置文件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        public string Memo { get; set; }
        #endregion
    }
}
