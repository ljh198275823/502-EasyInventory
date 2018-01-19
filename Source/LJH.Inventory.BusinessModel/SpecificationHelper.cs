﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary;

namespace LJH.Inventory.BusinessModel
{
    public class SpecificationHelper
    {
        /// <summary>
        /// 从产品规格中获取标定的厚度
        /// </summary>
        public static int? GetWritten克重(string specification)
        {
            if (!string.IsNullOrEmpty(specification))
            {
                string[] temp = specification.Split('*');
                if (temp.Length >= 1)
                {
                    decimal ret = 0;
                    if (decimal.TryParse(temp[0], out ret) && ret > 0) return (int)ret;
                }
            }
            return null;
        }

        /// <summary>
        /// 从产品规格中获取标定的宽度
        /// </summary>
        public static int? GetWrittenWidth(string specification)
        {
            if (!string.IsNullOrEmpty(specification))
            {
                string[] temp = specification.Split('*');
                if (temp.Length >= 2)
                {
                    decimal ret = 0;
                    if (decimal.TryParse(temp[1], out ret) && ret > 0) return (int)ret;
                }
            }
            return null;
        }
    }
}
