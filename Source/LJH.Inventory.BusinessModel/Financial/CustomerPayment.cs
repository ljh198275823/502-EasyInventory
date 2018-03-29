﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示客户收款记录
    /// </summary>
    public class CustomerPayment : ISheet<string>
    {
        #region 构造函数
        public CustomerPayment()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置付款记录ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置单据类型
        /// </summary>
        public CustomerPaymentType ClassID { get; set; }
        /// <summary>
        /// 获取或设置单据日期
        /// </summary>
        public DateTime SheetDate { get; set; }
        /// <summary>
        /// 获取或设置最近活动日期
        /// </summary>
        public DateTime LastActiveDate { get; set; }
        /// <summary>
        /// 获取或设置付款客户ID
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 获取或设置到款账号
        /// </summary>
        public string AccountID { get; set; }
        /// <summary>
        /// 获取或设置付款方式
        /// </summary>
        public PaymentMode PaymentMode { get; set; }
        /// <summary>
        /// 获取或设置付款金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 获取或设置付款单位
        /// </summary>
        public string Payer { get; set; }
        /// <summary>
        /// 获取或设置付款流水的收发货单据号
        /// </summary>
        public string StackSheetID { get; set; }
        /// <summary>
        /// 获取或设置当前状态
        /// </summary>
        public SheetState State { get; set; }
        /// <summary>
        /// 获取或设置备注信息
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region ISheet接口
        public bool CanDo(SheetOperation operation)
        {
            switch (operation)
            {
                case SheetOperation.Modify:
                    return State == SheetState.新增;
                case SheetOperation.Approve:
                    return State == SheetState.新增;
                case SheetOperation.UndoApprove:
                    return State == SheetState.已审批;
                case SheetOperation.Nullify:
                    return State != SheetState.作废;
                default:
                    return false;
            }
        }
        /// <summary>
        /// 获取单据类型
        /// </summary>
        public string DocumentType
        {
            get
            {
                switch (ClassID)
                {
                    case CustomerPaymentType.客户收款:
                        return "客户收款";
                    case CustomerPaymentType.供应商付款:
                        return "供应商付款";
                    case CustomerPaymentType.客户增值税发票:
                        return "客户增值税发票";
                    case CustomerPaymentType.供应商增值税发票:
                        return "供应商增值税发票";
                    case CustomerPaymentType.其它收款:
                        return "其它收款";
                    case CustomerPaymentType.转账:
                    case CustomerPaymentType.转公账:
                        return "账户转账";
                    case CustomerPaymentType.客户退款:
                    case CustomerPaymentType.供应商退款:
                    case CustomerPaymentType.管理费用退款:
                        return "退款";
                    case CustomerPaymentType.管理费用:
                        return "公司管理费用";
                    default:
                        throw new Exception("客户付款单没有指定类型");
                }
            }
        }

        public ISheet<string> Clone()
        {
            return MemberwiseClone() as CustomerPayment;
        }
        #endregion

        #region 扩展属性
        /// <summary>
        /// 获取或设置扩展属性
        /// </summary>
        public string Note { get; set; }

        private Dictionary<string, string> _Externals = null;

        public string GetProperty(string key)
        {
            if (_Externals == null && !string.IsNullOrEmpty(Note)) _Externals = JsonConvert.DeserializeObject<Dictionary<string, string>>(Note);
            if (_Externals == null) return null;
            if (_Externals.ContainsKey(key)) return _Externals[key];
            return null;
        }

        public void SetProperty(string key, string value)
        {
            if (_Externals == null && !string.IsNullOrEmpty(Note)) _Externals = JsonConvert.DeserializeObject<Dictionary<string, string>>(Note);
            if (_Externals == null) _Externals = new Dictionary<string, string>();
            if (value == null && _Externals.ContainsKey(key)) _Externals.Remove(key);
            else _Externals[key] = value;
            Note = JsonConvert.SerializeObject(_Externals);
        }

        public void RemoveProperty(string key)
        {
            if (_Externals == null && !string.IsNullOrEmpty(Note)) _Externals = JsonConvert.DeserializeObject<Dictionary<string, string>>(Note);
            if (_Externals == null) return;
            if (_Externals.ContainsKey(key)) _Externals.Remove(key);
            Note = JsonConvert.SerializeObject(_Externals);
        }
        #endregion
    }
}
