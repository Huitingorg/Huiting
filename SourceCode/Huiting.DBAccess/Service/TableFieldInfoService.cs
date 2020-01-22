using Huiting.DBAccess.Entity.Dtos;
using Huiting.DBAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.DBAccess.Service
{
    public class TableFieldInfoService : ADataService<TableFieldInfoDto>
    {
        public IEnumerable<TableFieldInfoDto> GetTableFieldInfoDtos()
        {
            return DapperHelper.SqlWithParams<TableFieldInfoDto>($"select * from {this.TableName} order by TableName desc");
        }

        public IEnumerable<TableFieldInfoDto> GetTableFieldInfoDtos(string tableName)
        {
            return DapperHelper.SqlWithParams<TableFieldInfoDto>($"select * from {this.TableName} where tablename='{tableName}' order by fieldName desc");
        }

        public IEnumerable<TableFieldInfoDto> GetTableFieldInfoDtos(Type DtoType)
        {
            string tableName = DapperHelper.TableNames[DtoType];
            return DapperHelper.SqlWithParams<TableFieldInfoDto>($"select * from {this.TableName} where tablename='{tableName}' order by fieldName desc");
        }
    }
}
