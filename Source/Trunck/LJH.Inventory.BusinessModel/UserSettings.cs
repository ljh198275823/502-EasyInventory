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
            this.CompanyName = "易存企业管理系统送货单";

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
            this.DeliverySheetDateFormat = "yyMM";
            this.DeliverySheetSerialCount = 5;

            this.InventorySheetPrefix = "RKD";
            this.InventorySheetDateFormat = "yyMM";
            this.InventorySheetSerialCount = 5;

            this.OrderPrefix = "DHD";
            this.OrderDateFormat = "yyMM";
            this.OrderSerialCount = 5;

            this.PurchaseSheetPrefix = "CGD";
            this.PurchaseSheetDateFormat = "yyMM";
            this.PurchaseSheetSerialCount = 5;

            this.CustomerPaymentPrefix = "FKD";
            this.CustomerPaymentDateFormat = "yyMM";
            this.CustomerPaymentSerialCount = 5;

            this.DaiFuPrefix = "DFD";
            this.DaiFuDateFormat = "yyMM";
            this.DaiFuSerialCount = 5;

            this.ExpenditureRecordPrefix = "ZCD";
            this.ExpenditureRecordDateFormat = "yyMM";
            this.ExpenditureRecordSerialCount = 5;
        }
        #endregion

        #region 常规
        /// <summary>
        /// 获取或设置公司名称
        /// </summary>
        [DataMember]
        public string CompanyName { get; set; }
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
        /// 获取或设置客户付款单前缀
        /// </summary>
        [DataMember]
        public string CustomerPaymentPrefix { get; set; }
        /// <summary>
        /// 获取或设置客户付款单日期部分的格式
        /// </summary>
        [DataMember]
        public string CustomerPaymentDateFormat { get; set; }
        /// <summary>
        /// 获取或设置客户付款单序列号部分的长度
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
