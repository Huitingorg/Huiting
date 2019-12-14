using Huiting.DB.Common.Attributes;
using Huiting.DB.Access.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;

namespace Huiting.DB.Access
{
    public class CacheService
    {
        /// <summary>
        /// 单例
        /// </summary>
        private static CacheService _uniqueInstance;

        /// <summary>
        /// 同步锁
        /// </summary>
        private static readonly object Locker = new object();

        /// <summary>
        /// 获取DbService实例
        /// </summary>
        /// <returns>DbService实例</returns>
        public static CacheService GetInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            lock (Locker)
            {
                // 如果类的实例不存在则创建，否则直接返回
                if (_uniqueInstance == null)
                {
                    _uniqueInstance = new CacheService();
                }
            }

            return _uniqueInstance;
        }

        #region 缓存表数据

        /// <summary>
        /// 缓存表数据
        /// </summary>
        /// <returns></returns>
        public bool InitDBCaches()
        {
            DapperHelper.SQLLiteSession((con, trans) =>
            {
                ////添加对象缓存
                //AddTableCache<ProductDto>(con, trans);
                //AddTableCache<InvDto>(con, trans);
                //AddTableCache<SystemDictDto>(con, trans);
                //AddTableCache<PositionDto>(con, trans);
                //AddTableCache<IncompatibilityDto>(con, trans);
                //AddTableCache<SystemDrugRemindDto>(con, trans);
                //AddTableCache<PrescriptionInputHistoryDto>(con, trans);
            });

            return true;
        }

        /// <summary>
        /// 添加表数据缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        private void AddTableCache<T>(SQLiteConnection conn, SQLiteTransaction trans) where T : IEntity
        {
            string tableKey = typeof(T).Name;
            MemoryCacheHelper.AddTable(tableKey, DBService.GetInstance().Logics[tableKey]?.GetEntitys<T>(conn, trans), o => DBService.GetInstance().Logics[tableKey]?.GetEntityKey(o));
        }

        /// <summary>
        /// 读取表缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public ConcurrentDictionary<string, T> Get<T>() where T : IEntity
        {
            string tableKey = typeof(T).Name;
            var result = MemoryCacheHelper.Get<T>(tableKey);
            if (result == null)
            {
                DapperHelper.SQLLiteSession((con, trans) =>
                {
                    AddTableCache<T>(con, trans);
                });
                result = MemoryCacheHelper.Get<T>(tableKey);
            }
            return result;
        }

        /// <summary>
        /// 更新表缓存
        /// </summary>
        /// <param name="tableKey"></param>
        public void Update<T>(string tableKey, List<T> data) where T : IEntity
        {
            try
            {
                MemoryCacheHelper.Update(tableKey, data, o => DBService.GetInstance().Logics[tableKey]?.GetEntityKey(o));
            }
            catch (Exception ex)
            {
                Trace.TraceError("CacheService.Update: " + ex.ToString());
            }
        }

        #endregion 缓存表数据

        #region 缓存表名

        /// <summary>
        /// 表名字典
        /// </summary>
        internal readonly Dictionary<Type, string> TableNames = new Dictionary<Type, string>();

        public void AddTableNames(Type type)
        {
            string tableName = ((DataTableAttribute[])type.GetCustomAttributes(typeof(DataTableAttribute), false))[0].TableName;
            if (!TableNames.ContainsKey(type))
                TableNames.Add(type, tableName);
        }

        public string GetTableName<T>()
        {
            return GetTableName(typeof(T));
        }

        public string GetTableName(Type type)
        {
            return TableNames.ContainsKey(type) ? TableNames[type] : string.Empty;
        }

        public Type GetTableType(string tableName)
        {
            if (!string.IsNullOrWhiteSpace(tableName))
            {
                if (TableNames.ContainsValue(tableName))
                    return TableNames.FirstOrDefault(x => x.Value == tableName).Key;
            }
            return null;
        }

        #endregion 缓存表名
    }
}