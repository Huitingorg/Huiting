using Huiting.Common;
using Huiting.DBAccess.Entity.Dict;
using Huiting.DBAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Huiting.DBAccess.Generator
{
    /// <summary>
    /// 模型生成器
    /// </summary>
    public static class DtoModelGenerator
    {
        /// <summary>
        /// 根据Sqlite数据表，修正表模型
        /// </summary>
        /// <param name="ModelFolder">模型保存路径</param>
        internal static void GenerateDtosByDBTable(string ModelFolder = null)
        {
            if (ModelFolder == null)
                ModelFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../DtoModels");
            if (Directory.Exists(ModelFolder))
                Directory.Delete(ModelFolder, true);
            Directory.CreateDirectory(ModelFolder);

            var OldCreateSqlList = new List<SqliteMasterDto>();
            //查询所有建表语句
            OldCreateSqlList = DapperHelper.SqlWithParams<SqliteMasterDto>("select * from sqlite_master where type ='table' and sql is not null;")?.ToList();

            foreach (var sqliteMasterDto in OldCreateSqlList)
            {
                string sql = $"PRAGMA table_info({sqliteMasterDto.Tbl_Name})";
                //查询原表结构
                List<TableInfoDto> oldFieldList = DapperHelper.SqlWithParams<TableInfoDto>($"pragma table_info({sqliteMasterDto.Tbl_Name});")?.ToList();
                //DataTable dtTmp = DBAccessHelper.GetDataTable(sql);
                //dtTmp.TableName = tableName;

                CreateCSFile(sqliteMasterDto.Name, oldFieldList,ModelFolder);

                //CreateCSFile(dtTmp);
            }

            Console.WriteLine("模型文件生成成功");
        }

        /// <summary>
        /// 创建CS File
        /// </summary>
        /// <param name="dtStruct"></param>
        internal static void CreateCSFile(string tableName, List<TableInfoDto> oldFieldList, string ModelFolder)
        {
            string tNameUpper = tableName.FirstCharToUpper();
            string tNameLower = tableName.FirstCharToLower();

            string fileFullName = Path.Combine(ModelFolder, $"{tNameUpper}Dto.cs");
            if (File.Exists(fileFullName))
                File.Delete(fileFullName);

            string sql = $"select * from {tNameUpper} where 1=2";
            DataTable dtEmptyData = DapperHelper.GetDataTable(sql);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using Newtonsoft.Json;");
            sb.AppendLine("using Huiting.DBAccess.Attributes;");
            sb.AppendLine();

            sb.AppendLine("namespace Huiting.DBAccess.Entity.Dtos");
            sb.AppendLine("{");
            sb.AppendLine($"\t[DataTable(\"{tNameLower}\")] ");
            sb.AppendLine($"\tpublic class {tNameUpper}Dto");
            sb.AppendLine("\t{");

            foreach (var item in oldFieldList)
            {
                string str = new string('\t', 20);

                string dcNameUpper = item.Name.FirstCharToUpper(); //dr["name"].ToString().FirstCharToUpper();
                string dcNameLower = item.Name.ToLower(); //dr["name"].ToString().FirstCharToLower();
                Type dcCodeType = dtEmptyData.Columns[dcNameUpper].DataType;
                string dcDBType = item.Type.ToString().ToLower();// dr["type"].ToString().ToLower();
                bool isNull = item.NotNull == 0 ? true : false;
                bool isPrimaryKey = item.Pk == 0 ? false : true;

                sb.AppendLine($"\t\tprivate {dcCodeType.Name} {dcNameLower};");
                sb.AppendLine($"\t\t[JsonProperty(\"{dcNameLower}\")]");
                sb.AppendLine($"\t\t[DataField(\"{dcDBType}\",{isNull.ToString().ToLower()},{isPrimaryKey.ToString().ToLower()})]");
                sb.AppendLine($"\t\tpublic {dcCodeType.Name} {dcNameUpper}");
                sb.AppendLine("\t\t{");
                sb.AppendLine("\t\t\tget");
                sb.AppendLine("\t\t\t{");
                sb.AppendLine($"\t\t\t\treturn {dcNameLower};");
                sb.AppendLine("\t\t\t}");
                sb.AppendLine("\t\t\tset");
                sb.AppendLine("\t\t\t{");
                sb.AppendLine($"\t\t\t\t{dcNameLower} = value;");
                sb.AppendLine("\t\t\t}");
                sb.AppendLine("\t\t}");
                sb.AppendLine();
            }
            sb.AppendLine("\t}");
            sb.AppendLine("}");

            string content = sb.ToString();

            System.IO.File.WriteAllText(fileFullName, content);
        }
    }
}