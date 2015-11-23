using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.UI.Forms
{
    public class JSEngine
    {
        #region 私有变量
        private static Jurassic.ScriptEngine _JS;
        #endregion

        #region 公共方法
        /// <summary>
        /// 计算表达式的结果，如果成功，在ret中返回表达式的结果
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="ret"></param>
        /// <returns></returns>
        public static bool CalExpression(string expression, out decimal ret)
        {
            try
            {
                if (_JS == null) _JS = new Jurassic.ScriptEngine();
                var temp = _JS.Evaluate(expression);
                ret = Convert.ToDecimal(temp);
                return true;
            }
            catch
            {
                ret = 0;
                return false;
            }

        }
        #endregion
    }
}
