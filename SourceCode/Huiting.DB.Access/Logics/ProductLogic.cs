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
    public class ProductLogic : ICache
    {
        private readonly string tableName_ProductDto = CacheService.GetInstance().GetTableName<ProductDto>();
        private readonly string tableName_IncompatibilityDto = CacheService.GetInstance().GetTableName<IncompatibilityDto>();
        private readonly string tableName_SystemDrugRemindDto = CacheService.GetInstance().GetTableName<SystemDrugRemindDto>();

        public IEnumerable<T> QueryAll<T>() where T : class, IProduct
        {
            return DapperHelper.SqlWithParams<T>($"select pro.*,dic.name as unitName,dosDic.name as dosageFormName from {tableName_ProductDto} as pro left join {CacheService.GetInstance().TableNames[typeof(SystemDictDto)]} as dic on pro.unitId=dic.id left join {CacheService.GetInstance().TableNames[typeof(SystemDictDto)]} as dosDic on pro.dosageFormId=dosDic.id where pro.organSign='{CacheInfo.Drugstore.OrganSign}' and pro.yn=1;");
        }

        private IEnumerable<T> QueryEnable<T>(SQLiteConnection conn, SQLiteTransaction trans)
        {
            return DapperHelper.Query<T>(conn, $"select * from {tableName_ProductDto} where organSign='{CacheInfo.Drugstore.OrganSign}' and yn=1 and used=1;", null, trans);
        }

        private IEnumerable<T> QueryIncompatibilityDto<T>(SQLiteConnection conn, SQLiteTransaction trans)
        {
            return DapperHelper.Query<T>(conn, $"select * from {tableName_IncompatibilityDto} where organSign='{CacheInfo.Drugstore.OrganSign}' and yn=1;", null, trans);
        }

        private IEnumerable<T> QuerySystemDrugRemindDto<T>(SQLiteConnection conn, SQLiteTransaction trans)
        {
            return DapperHelper.Query<T>(conn, $"select * from {tableName_SystemDrugRemindDto} where organSign='{CacheInfo.Drugstore.OrganSign}';", null, trans);
        }

        public string GetEntityKey(IEntity entity)
        {
            if (entity is IProduct)
                return (entity as IProduct).Pref;
            else if (entity is IIncompatibility)
                return (entity as IIncompatibility).Guid;
            else if (entity is SystemDrugRemindDto)
                return (entity as SystemDrugRemindDto).Id.ToString();

            return null;
        }

        public IEnumerable<T> GetEntitys<T>(SQLiteConnection conn, SQLiteTransaction trans)
        {
            string tableKey = typeof(T).Name;
            if (tableKey == nameof(ProductDto))
                return QueryEnable<T>(conn, trans);
            else if (tableKey == nameof(IncompatibilityDto))
                return QueryIncompatibilityDto<T>(conn, trans);
            else if (tableKey == nameof(SystemDrugRemindDto))
                return QuerySystemDrugRemindDto<T>(conn, trans);
            return default(IEnumerable<T>);
        }
    }
}