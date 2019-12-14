using Huiting.DBAccess.Dto;
using Huiting.DBAccess.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Huiting.DBAccess.DataFormatGenerator
{
    public class DtoClassGenerator
    {
        public static string ModelFolder = @"E:\CSharpProject\work\可采储量评估分析_Git\DapperCode\POS_YHBranch\ConsoleApp1\CMPModels";

        //private static void GenerateModels()
        //{
        //    if (Directory.Exists(ModelFolder))
        //    {
        //        Directory.Delete(ModelFolder, true);
        //    }

        //    Directory.CreateDirectory(ModelFolder);

        //    var OldCreateSqlList = new List<SqliteMasterDto>();
        //    //查询所有建表语句
        //    OldCreateSqlList = DapperHelper.SqlWithParams<SqliteMasterDto>("select * from sqlite_master where type ='table' and sql is not null;")?.ToList();

        //    foreach (var dr in OldCreateSqlList)
        //    {
        //        string sql = $"PRAGMA table_info({dr.Tbl_Name})";
        //        //查询原表结构
        //        List<TableInfoDto> oldFieldList = conn.Query<TableInfoDto>($"pragma table_info({oldTable.Tbl_Name});", null, trans)?.ToList();
        //        DataTable dtTmp = DBAccessHelper.GetDataTable(sql);
        //        dtTmp.TableName = tableName;

        //        CreateCSFile(dtTmp);
        //    }

        //    Console.WriteLine("模型文件生成成功");
        //}

        ///// <summary>
        ///// 创建CS File
        ///// </summary>
        ///// <param name="dtStruct"></param>
        //static void CreateCSFile(DataTable dtStruct)
        //{
        //    if (dtStruct == null)
        //        return;

        //    string tNameUpper = dtStruct.TableName.FirstCharToUpper();
        //    string tNameLower = dtStruct.TableName.FirstCharToLower();

        //    string fileFullName = Path.Combine(ModelFolder, $"{tNameUpper}Dto.cs");
        //    if (File.Exists(fileFullName))
        //        File.Delete(fileFullName);


        //    string sql = $"select * from {tNameUpper} where 1=2";
        //    DataTable dtEmptyData = DBAccessHelper.GetDataTable(sql);

        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine("using System;");
        //    sb.AppendLine("using Newtonsoft.Json;");
        //    sb.AppendLine("using Huiting.Contract.Attributes;");
        //    sb.AppendLine("using XYY.Windows.SAAS.Contract.EntityInterfaces;");
        //    sb.AppendLine();

        //    sb.AppendLine("namespace Huiting.Contract.CMPModels");
        //    sb.AppendLine("{");
        //    sb.AppendLine($"\t[DataTable(\"{tNameLower}\")] ");
        //    sb.AppendLine($"\tpublic class {tNameUpper}Dto");
        //    sb.AppendLine("\t{");

        //    foreach (DataRow dr in dtStruct.Rows)
        //    {
        //        string str = new string('\t', 20);

        //        string dcNameUpper = dr["name"].ToString().FirstCharToUpper();
        //        string dcNameLower = dr["name"].ToString().FirstCharToLower();
        //        Type dcCodeType = dtEmptyData.Columns[dcNameUpper].DataType;
        //        string dcDBType = dr["type"].ToString().ToLower();
        //        bool isNull = dr["notNull"].ToString() == "1" ? false : true;
        //        bool isPrimaryKey = dr["pk"].ToString() == "1" ? true : false;

        //        sb.AppendLine($"\t\tprivate {dcCodeType.Name} {dcNameLower};");
        //        sb.AppendLine($"\t\t[JsonProperty(\"{dcNameLower}\")]");
        //        sb.AppendLine($"\t\t[DataField(\"{dcDBType}\",{isNull.ToString().ToLower()},{isPrimaryKey.ToString().ToLower()})]");
        //        sb.AppendLine($"\t\tpublic {dcCodeType.Name} {dcNameUpper}");
        //        sb.AppendLine("\t\t{");
        //        sb.AppendLine("\t\t\tget");
        //        sb.AppendLine("\t\t\t{");
        //        sb.AppendLine($"\t\t\t\treturn {dcNameLower};");
        //        sb.AppendLine("\t\t\t}");
        //        sb.AppendLine("\t\t\tset");
        //        sb.AppendLine("\t\t\t{");
        //        sb.AppendLine($"\t\t\t\t{dcNameLower} = value;");
        //        sb.AppendLine("\t\t\t}");
        //        sb.AppendLine("\t\t}");
        //        sb.AppendLine();
        //    }
        //    sb.AppendLine("\t}");
        //    sb.AppendLine("}");

        //    string content = sb.ToString();

        //    System.IO.File.WriteAllText(fileFullName, content);
        //}
    }
}
