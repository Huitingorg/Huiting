using Huiting.DBAccess.Entity.Dtos;
using Huiting.DBAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.DBAccess.Service
{
    public class EvaluationOptionService : ADataService<EvaluationOptionsDto>
    {
        public IEnumerable<EvaluationOptionsDto> GetEvaluationOptionsDto(string projectId)
        {
            string sql = $"select * from {base.TableName} where proid={projectId} order by pjnd";
            return DapperHelper.SqlWithParams<EvaluationOptionsDto>(sql);
        }
    }
}
