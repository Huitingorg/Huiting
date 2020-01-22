using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using Dapper;
using XYY.Windows.SAAS.Contract.Configs;
using XYY.Windows.SAAS.Contract.Dto;
using XYY.Windows.SAAS.Contract.EntityInterfaces;
using XYY.Windows.SAAS.Contract.Models;
using XYY.Windows.SAAS.DB.Helpers;

namespace XYY.Windows.SAAS.DB.Logics
{
    public class OrderLogic : ICache
    {
        private readonly string tableName_OrderDto = CacheService.GetInstance().GetTableName<OrderDto>();
        private readonly string tableName_OrderDetailDto = CacheService.GetInstance().GetTableName<OrderDetailDto>();
        private readonly string tableName_IncompatibilityDto = CacheService.GetInstance().GetTableName<PrescriptionInputHistoryDto>();

        #region 处方登记输入历史记录

        private IEnumerable<T> GetPrescriptionInputHistory<T>(SQLiteConnection conn, SQLiteTransaction trans)
        {
            return DapperHelper.Query<T>(conn, $"SELECT * FROM {tableName_IncompatibilityDto} WHERE OrganSign = '{ CacheInfo.Drugstore.OrganSign }';", null, trans);
        }

        public bool RecordPrescriptionInputHistory(PrescriptionInputHistoryDto inputHistory)
        {
            return DapperHelper.SQLLiteSession<bool>((conn, trans) =>
            {
                POSQuerySqlHelper posSql = new POSQuerySqlHelper(new SqlCommonQuery { OrganSign = CacheInfo.Drugstore.OrganSign, Yn = 1 });
                string sql = posSql.Sql_PrescriptionInputHistory();
                PrescriptionInputHistoryDto currentInputHistory = conn.Query<PrescriptionInputHistoryDto>(sql).FirstOrDefault();

                if (currentInputHistory != null)
                {
                    string updateSql = CreateSqlHelper.GetUpdateSqlByModel(typeof(PrescriptionInputHistoryDto), CacheService.GetInstance().TableNames[typeof(PrescriptionInputHistoryDto)]);
                    updateSql = updateSql + $" WHERE OrganSign = '{ inputHistory.OrganSign }'";

                    return conn.Execute(updateSql, inputHistory, trans) > 0 ? true : false;
                }

                string intsertSql = CreateSqlHelper.GetInsertSqlByModel(typeof(PrescriptionInputHistoryDto), CacheService.GetInstance().TableNames[typeof(PrescriptionInputHistoryDto)]);
                return conn.Execute(intsertSql, inputHistory, trans) > 0 ? true : false;
            });
        }

        #endregion 处方登记输入历史记录

        public string GetEntityKey(IEntity entity)
        {
            return (entity as PrescriptionInputHistoryDto).OrganSign;
        }

        public IEnumerable<T> GetEntitys<T>(SQLiteConnection conn, SQLiteTransaction trans)
        {
            string tableKey = typeof(T).Name;
            if (tableKey == nameof(PrescriptionInputHistoryDto))
                return GetPrescriptionInputHistory<T>(conn, trans);
            return default(IEnumerable<T>);
        }
    }
}