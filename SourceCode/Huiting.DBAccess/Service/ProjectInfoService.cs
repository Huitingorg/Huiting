using Huiting.DBAccess.Entity.Dtos;
using Huiting.DBAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.DBAccess.Service
{
    public class ProjectInfoService : ADataService<ProjectInfoDto>
    {
        public IEnumerable<ProjectInfoDto> GetProjectInfoDtos()
        {
            return DapperHelper.SqlWithParams<ProjectInfoDto>($"select * from {this.TableName} order by CreateTime desc");
        }
    }
}
