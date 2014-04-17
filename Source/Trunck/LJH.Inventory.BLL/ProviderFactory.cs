using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using LJH.Inventory .DAL .IProvider ;
using LJH.Inventory .DAL .LinqProvider ;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.BLL
{
    /// <summary>
    /// 表示数据库提供者的工厂类
    /// </summary>
    internal class ProviderFactory
    {
        /// <summary>
        /// 创建一个数据提供者实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repUri"></param>
        /// <returns></returns>
        public static T Create<T>(string connStr) where T : class
        {
            T instance = null;
            try
            {

                Assembly asm = Assembly.Load("LJH.Inventory.DAL");
                if (asm != null)
                {
                    foreach (Type t in asm.GetTypes())
                    {
                        if (t.IsClass && !t.IsAbstract)
                        {
                            foreach (Type inter in t.GetInterfaces())
                            {
                                if (inter == typeof(T))
                                {
                                    instance = Activator.CreateInstance(t, connStr) as T;
                                    return instance;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            throw new Exception(string.Format("没有找到 {0} ,请确保 {1} 已经存在!", typeof(T).FullName, typeof(T).FullName));
        }
    }
}
