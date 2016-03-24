using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LJH.Inventory.BusinessModel
{
    [DataContract]
    public class UserSettings
    {
        #region 获取或设置当前设置
        public static UserSettings Current { get; set; }
        #endregion

        #region 构造函数
        public UserSettings()
        {
            BecomeRemainlessAt = 5;
            BecomeTailAt = 30;
            this.CompanyName = "易存信息系统有限公司";

            this.CustomerPrefix = "C";
            this.CustomerSerialCount = 3;

            this.SupplierPrefix = "S";
            this.SupplierSerialCount = 3;

            this.WareHousePrefix = "W";
            this.WareHouseSerialCount = 3;

            this.CategoryPrefix = "CA";
            this.CategorySerialCount = 3;

            this.ProductSerialCount = 4;

            this.DeliverySheetPrefix = "SHD";
            this.DeliverySheetDateFormat = "yyyyMM";
            this.DeliverySheetSerialCount = 5;

            this.InventorySheetPrefix = "RKD";
            this.InventorySheetDateFormat = "yyyyMM";
            this.InventorySheetSerialCount = 5;

            this.OrderPrefix = "DHD";
            this.OrderDateFormat = "yyyyMM";
            this.OrderSerialCount = 5;

            this.PurchaseSheetPrefix = "CGD";
            this.PurchaseSheetDateFormat = "yyyyMM";
            this.PurchaseSheetSerialCount = 5;

            this.CustomerPaymentPrefix = "FKD";
            this.CustomerPaymentDateFormat = "yyyyMM";
            this.CustomerPaymentSerialCount = 5;

            this.DaiFuPrefix = "DFD";
            this.DaiFuDateFormat = "yyyyMM";
            this.DaiFuSerialCount = 5;

            this.ExpenditureRecordPrefix = "ZCD";
            this.ExpenditureRecordDateFormat = "yyyyMM";
            this.ExpenditureRecordSerialCount = 5;
        }
        #endregion

        #region 基本
        /// <summary>
        /// 获取或设置原料在小于或等于多长后当成无尾料
        /// </summary>
        [DataMember]
        public decimal BecomeRemainlessAt { get; set; }
        /// <summary>
        /// 获取或设置原料在小于或等于多长后当成尾卷
        /// </summary>
        [DataMember]
        public decimal BecomeTailAt { get; set; }

        [DataMember]
        public string DefaultCustomer { get; set; }

        [DataMember]
        public string DefaultWarehouse { get; set; }

        [DataMember]
        public string DefaultProductCategory { get; set; }
        #endregion

        #region 本公司信息
        /// <summary>
        /// 获取或设置公司名称
        /// </summary>
        [DataMember]
        public string CompanyName { get; set; }
        /// <summary>
        /// 获取或设置英文名称
        /// </summary>
        [DataMember]
        public string ForeignName { get; set; }
        /// <summary>
        /// 获取或设置联系电话
        /// </summary>
        [DataMember]
        public string TelPhone { get; set; }
        /// <summary>
        /// 获取或设置传真
        /// </summary>
        [DataMember]
        public string Fax { get; set; }
        /// <summary>
        /// 获取或设置邮政编码
        /// </summary>
        [DataMember]
        public string PostalCode { get; set; }
        /// <summary>
        /// 获取或设置网站
        /// </summary>
        [DataMember]
        public string Website { get; set; }
        /// <summary>
        /// 获取或设置电子邮件
        /// </summary>
        [DataMember]
        public string Email { get; set; }
        /// <summary>
        /// 获取或设置地址
        /// </summary>
        [DataMember]
        public string Address { get; set; }
        #endregion

        #region 送货单选项
        /// <summary>
        /// 获取或设置送货单的还款期限为送货之日起第几日,0表示不设还款期，1表示当天，以此类推
        /// </summary>
        [DataMember]
        public int DeadlineDays { get; set; }
        /// <summary>
        /// 获取或设置是否在送货单发货时如果超出客户信用额度时提醒操作员
        /// </summary>
        [DataMember]
        public bool ReminderWhenOverCreditLimit { get; set; }
        /// <summary>
        /// 获取或设置是否在送货单发货时如果超出客户信用额度时禁止发货
        /// </summary>
        [DataMember]
        public bool ForbidWhenOverCreditLimit { get; set; }
        /// <summary>
        /// 获取或设置送货单没有指定订单号时是否禁止保存送货单
        /// </summary>
        [DataMember]
        public bool ForbidWhenNoOrderID { get; set; }
        /// <summary>
        /// 获取或设置是否禁止发货，当发货数量超出订单订货数量时
        /// </summary>
        [DataMember]
        public bool ForbidWhenOverCount { get; set; }
        /// <summary>
        /// 获取或设置是否在保存送货单时先检查库存数量
        /// </summary>
        [DataMember]
        public bool CheckCountWhenSaveDeliverySheet { get; set; }
        /// <summary>
        /// 获取或设置库存出货方式
        /// </summary>
        [DataMember]
        public InventoryOutType InventoryOutType { get; set; }
        /// <summary>
        /// 获取或设置打印送货单的时候即出货
        /// </summary>
        [DataMember]
        public bool DoShipAfterPrint { get; set; }
        /// <summary>
        /// 获取或设置送货单打印模板
        /// </summary>
        [DataMember]
        public string StackoutSheetModel { get; set; }
        /// <summary>
        /// 获取或设置加载多少个月之前的送货单 0表示本月，1表示最近一月，依此类推
        /// </summary>
        [DataMember]
        public int LoadSheetsBefore { get; set; }
        #endregion
          
        #region 自动生成单号  
        //自动生成的单号分成三部分 1前缀 2日期部分 3序列号 如FH13050001 其中前缀为FH 日期部分为1305表示2013年5月， 序号 
        /// <summary>
        /// 获取或设置送货单号前缀
        /// </summary>
        [DataMember]
        public string DeliverySheetPrefix { get; set; }
        /// <summary>
        /// 获取或设置送货单号日期部分的格式
        /// </summary>
        [DataMember]
        public string DeliverySheetDateFormat { get; set; }
        /// <summary>
        /// 获取或设置送货单序列号部分的长度
        /// </summary>
        [DataMember]
        public int DeliverySheetSerialCount { get; set; }
        /// <summary>
        /// 获取或设置收货单号前缀
        /// </summary>
        [DataMember]
        public string InventorySheetPrefix { get; set; }
        /// <summary>
        /// 获取或设置收货单日期部分的格式
        /// </summary>
        [DataMember]
        public string InventorySheetDateFormat { get; set; }
        /// <summary>
        /// 获取或设置收货单序列号部分的长度
        /// </summary>
        [DataMember]
        public int InventorySheetSerialCount { get; set; }

        /// <summary>
        /// 获取或设置订单号前缀
        /// </summary>
        [DataMember]
        public string OrderPrefix { get; set; }
        /// <summary>
        /// 获取或设置订单日期部分的格式
        /// </summary>
        [DataMember]
        public string OrderDateFormat { get; set; }
        /// <summary>
        /// 获取或设置订单序列号部分的长度
        /// </summary>
        [DataMember]
        public int OrderSerialCount { get; set; }

        /// <summary>
        /// 获取或设置订单号前缀
        /// </summary>
        [DataMember]
        public string PurchaseSheetPrefix { get; set; }
        /// <summary>
        /// 获取或设置订单日期部分的格式
        /// </summary>
        [DataMember]
        public string PurchaseSheetDateFormat { get; set; }
        /// <summary>
        /// 获取或设置订单序列号部分的长度
        /// </summary>
        [DataMember]
        public int PurchaseSheetSerialCount { get; set; }

        /// <summary>
        /// 获取或设置客户收款单前缀
        /// </summary>
        [DataMember]
        public string CustomerPaymentPrefix { get; set; }
        /// <summary>
        /// 获取或设置客户收款单日期部分的格式
        /// </summary>
        [DataMember]
        public string CustomerPaymentDateFormat { get; set; }
        /// <summary>
        /// 获取或设置客户收款单序列号部分的长度
        /// </summary>
        [DataMember]
        public int CustomerPaymentSerialCount { get; set; }

        /// <summary>
        /// 获取或设置资金支出单前缀
        /// </summary>
        [DataMember]
        public string ExpenditureRecordPrefix { get; set; }
        /// <summary>
        /// 获取或设置资金支出单日期部分的格式
        /// </summary>
        [DataMember]
        public string ExpenditureRecordDateFormat { get; set; }
        /// <summary>
        /// 获取或设置资金支出单序列号部分的长度
        /// </summary>
        [DataMember]
        public int ExpenditureRecordSerialCount { get; set; }

        /// <summary>
        /// 获取或设置代付款单前缀
        /// </summary>
        [DataMember]
        public string DaiFuPrefix { get; set; }
        /// <summary>
        /// 获取或设置代付款单日期部分的格式
        /// </summary>
        [DataMember]
        public string DaiFuDateFormat { get; set; }
        /// <summary>
        /// 获取或设置代付款单序列号部分的长度
        /// </summary>
        [DataMember]
        public int DaiFuSerialCount { get; set; }

        [DataMember]
        public string CustomerPrefix { get; set; }

        [DataMember]
        public int CustomerSerialCount { get; set; }

        [DataMember]
        public string SupplierPrefix { get; set; }

        [DataMember]
        public int SupplierSerialCount { get; set; }

        [DataMember]
        public string WareHousePrefix { get; set; }

        [DataMember]
        public int WareHouseSerialCount { get; set; }

        [DataMember]
        public string CategoryPrefix { get; set; }

        [DataMember]
        public int CategorySerialCount { get; set; }

        [DataMember]
        public int ProductSerialCount { get; set; }
        #endregion
    }
}
