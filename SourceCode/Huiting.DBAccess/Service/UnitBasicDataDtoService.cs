using Huiting.Common;
using Huiting.DBAccess.Entity.Dtos;
using Huiting.DBAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.DBAccess.Service
{
    /// <summary>
    /// 单元基础数据服务
    /// </summary>
    public class UnitBasicDataDtoService : ADataService<UnitBasicDataDto>
    {
        /// <summary>
        /// 获取单元数据
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="keyWordWithDisplayItems"></param>
        /// <returns></returns>
        public IEnumerable<UnitBasicDataDto> GetUnitBasicDataDto(long projectID, string sqlPart)
        {
            if (string.IsNullOrWhiteSpace(sqlPart) == false)
                sqlPart = $" and {sqlPart}";

            return DapperHelper.SqlWithParams<UnitBasicDataDto>($"select * from {this.TableName} where proid={projectID} {sqlPart} ");
        }

  
    }
}
