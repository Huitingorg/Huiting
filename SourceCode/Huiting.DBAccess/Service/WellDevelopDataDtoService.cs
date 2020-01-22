using Huiting.DBAccess.Entity.Dtos;
using Huiting.DBAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.DBAccess.Service
{
    public class WellDevelopDataDtoService: ADataService<WellDevelopDataDto>
    {
        /// <summary>
        /// 获取单元数据
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="keyWordWithDisplayItems"></param>
        /// <returns></returns>
        public IEnumerable<WellDevelopDataDto> GetUnitBasicDataDto(long projectID, List<string> dydms, Tuple<string, List<string>> keyWordWithDisplayItems)
        {
            string connectedStr = "or ";

            StringBuilder sb = new StringBuilder();
            keyWordWithDisplayItems.Item2.ForEach(x => sb.Append($" {x} like '%{keyWordWithDisplayItems.Item1}%' or"));
            sb.Remove(sb.Length - connectedStr.Length, connectedStr.Length);

            string sqlPart = null;
            if (keyWordWithDisplayItems.Item2.Count > 0)
            {
                sqlPart = "and ";
                if (keyWordWithDisplayItems.Item2.Count == 1)
                    sqlPart = $"{sqlPart} {sb.ToString()}";
                else
                    sqlPart = $"{sqlPart} ({sb.ToString()})";
            }

            return DapperHelper.SqlWithParams<WellDevelopDataDto>($"select * from {this.TableName} where proid={projectID} {sqlPart} ");
        }

    }
}
