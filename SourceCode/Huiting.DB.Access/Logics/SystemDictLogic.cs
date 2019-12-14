using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using XYY.Windows.SAAS.Contract.Configs;
using XYY.Windows.SAAS.Contract.Dto;
using XYY.Windows.SAAS.Contract.EntityInterfaces;
using XYY.Windows.SAAS.DB.Helpers;

namespace XYY.Windows.SAAS.DB.Logics
{
    public class SystemDictLogic : ICache
    {
        private readonly string tableName = CacheService.GetInstance().GetTableName<SystemDictDto>();

        public string GetEntityKey(IEntity entity)
        {
            return (entity as ISystemDict).Id.ToString();
        }

        private IEnumerable<T> QueryEnable<T>(SQLiteConnection conn, SQLiteTransaction trans)
        {
            return DapperHelper.Query<T>(conn, $"select * from {tableName} where yn=1;", null, trans);
        }

        /// <summary>
        /// 获取字典值
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public List<SystemDictDto> GetSystemDicInfos(string description)
        {
            List<SystemDictDto> list = new List<SystemDictDto>();

            try
            {
                var sql = $"select * from saas_system_dict where  Description='{description}'";
                list = DapperHelper.SqlWithParams<SystemDictDto>(sql, null)?.ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }

            return list;
        }

        public IEnumerable<T> GetEntitys<T>(SQLiteConnection conn, SQLiteTransaction trans)
        {
            string tableKey = typeof(T).Name;
            if (tableKey == nameof(SystemDictDto))
                return QueryEnable<T>(conn, trans);
            return default(IEnumerable<T>);
        }
    }
}