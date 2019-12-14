using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Runtime.Caching;

namespace Huiting.DBAccess.Helpers
{
    public class MemoryCacheHelper
    {
        static MemoryCacheHelper()
        {
        }

        protected static ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;//线程安全
            }
        }

        /// <summary>
        /// 读取表缓存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns>ConcurrentDictionary<string, T></returns>
        public static ConcurrentDictionary<string, T> Get<T>(string tableKey) where T : IEntity
        {
            var dic = Cache.GetCacheItem(tableKey);
            if (dic != null && dic.Value is ConcurrentDictionary<string, T>)
            {
                return Cache[tableKey] as ConcurrentDictionary<string, T>;
            }
            return default(ConcurrentDictionary<string, T>);
        }

        /// <summary>
        /// 增加表缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableKey"></param>
        /// <param name="items"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static bool AddTable<T>(string tableKey, IEnumerable<T> items, Func<T, string> action) where T : IEntity
        {
            //string tableKey = typeof(T).Name;
            ConcurrentDictionary<string, T> data = new ConcurrentDictionary<string, T>();
            foreach (var item in items)
            {
                string key = action(item);
                if (!string.IsNullOrEmpty(key))
                {
                    data.TryAdd(key, item);
                }
            }
            if (Cache.Contains(tableKey))
                Cache.Remove(tableKey);
            Cache.Add(new CacheItem(tableKey, data), null);
            return true;
        }

        /// <summary>
        /// 添加单条缓存，如果表缓存不存在，先添加表缓存，之后检测数据缓存是否存在；
        /// 如果不存在则添加，如果存在，则先删除，再添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public static bool Add<T>(string key, T data)
        {
            bool result = false;
            string tableKey = typeof(T).Name;
            if (Cache.Contains(tableKey))
            {
                var dic = Cache[tableKey] as ConcurrentDictionary<string, T>;
                if (!dic.ContainsKey(key))
                {
                    result = dic.TryAdd(key, data);
                }
                else
                {
                    if (dic.TryRemove(key, out T temp))
                        result = dic.TryAdd(key, data);
                }
            }
            else
            {
                var dic = new ConcurrentDictionary<string, object>();
                result = dic.TryAdd(key, data);
                result = Cache.Add(new CacheItem(tableKey, dic), null);
            }
            return result;
        }

        /// <summary>
        /// T 为具体类型才能更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableKey"></param>
        /// <param name="datas"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static bool Update<T>(string tableKey, List<T> datas, Func<T, string> action) where T : IEntity
        {
            bool result = false;
            if (Cache.Contains(tableKey))
            {
                var dic = Cache[tableKey] as ConcurrentDictionary<string, T>;
                if (dic != null)
                {
                    foreach (var data in datas)
                    {
                        string key = action(data);
                        if (!dic.ContainsKey(key))
                        {
                            result = dic.TryAdd(key, data);
                        }
                        else
                        {
                            if (dic.TryRemove(key, out T temp))
                                result = dic.TryAdd(key, data);
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 是否包含表缓存
        /// Model.Contains
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Contains<T>()
        {
            string tableKey = typeof(T).Name;
            return Cache.Contains(tableKey);
        }

        /// <summary>
        /// 包含表缓存数量
        /// </summary>
        public static int Count { get { return (int)(Cache.GetCount()); } }

        /// <summary>
        /// 表缓存包含数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int DataCount<T>()
        {
            string tableKey = typeof(T).Name;
            if (Cache.Contains(tableKey))
            {
                var dic = Cache[tableKey] as ConcurrentDictionary<string, object>;
                if (dic != null)
                    return dic.Count;
            }
            return 0;
        }

        /// <summary>
        /// 删除缓存表中单条数据
        /// </summary>
        /// <param name="key"></param>
        public static bool Remove<T>(string key)
        {
            string tableKey = typeof(T).Name;
            if (Cache.Contains(tableKey))
            {
                var dic = Cache[tableKey] as ConcurrentDictionary<string, object>; ;
                if (dic != null && dic.ContainsKey(key))
                {
                    object temp;
                    return dic.TryRemove(key, out temp);
                }
            }
            return default(bool);
        }

        /// <summary>
        /// 删除缓存表数据
        /// </summary>
        /// <param name="key"></param>
        public static bool RemoveTable<T>()
        {
            string tableKey = typeof(T).Name;
            return RemoveTable(tableKey);
        }

        /// <summary>
        /// 删除缓存表数据
        /// </summary>
        /// <param name="key"></param>
        public static bool RemoveTable(string tableKey)
        {
            if (Cache.Contains(tableKey))
            {
                return Cache.Remove(tableKey) != null;
            }
            return default(bool);
        }
    }

    public interface ICache
    {
        string GetEntityKey(IEntity entity);
        IEnumerable<T> GetEntitys<T>(SQLiteConnection conn, SQLiteTransaction trans);
    }
}