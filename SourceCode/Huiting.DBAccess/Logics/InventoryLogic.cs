using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using XYY.Windows.SAAS.Contract.Configs;
using XYY.Windows.SAAS.Contract.Dto;
using XYY.Windows.SAAS.Contract.EntityInterfaces;
using XYY.Windows.SAAS.DB.Helpers;

namespace XYY.Windows.SAAS.DB.Logics
{
    public class InventoryLogic : ICache
    {
        private readonly string tableName = CacheService.GetInstance().GetTableName<InvDto>();

        public string GetEntityKey(IEntity entity)
        {
            return (entity as IInventory).ProductPref;
        }

        public IEnumerable<T> QueryEnable<T>(SQLiteConnection conn, SQLiteTransaction trans)
        {
            return DapperHelper.Query<T>(conn, $"select * from {tableName} where organSign='{CacheInfo.Drugstore.OrganSign}' and yn=1;", null, trans);
        }

        public IEnumerable<T> GetEntitys<T>(SQLiteConnection conn, SQLiteTransaction trans)
        {
            string tableKey = typeof(T).Name;
            if (tableKey == nameof(InvDto))
                return QueryEnable<T>(conn, trans);
            return default(IEnumerable<T>);
        }
    }
}