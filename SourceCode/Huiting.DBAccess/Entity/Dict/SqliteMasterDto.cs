using Huiting.DBAccess.Entity;
using System;

namespace Huiting.DBAccess.Entity.Dict
{
    /// <summary>
    /// Sqlite_Master表对应Dto
    /// </summary>
    public class SqliteMasterDto: IDto
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public string Tbl_Name { get; set; }

        public string RootPage { get; set; }

        public string Sql { get; set; }

        public Type TableType { get; set; }
    }
}
