using Huiting.DataEditor.Controls;
using Huiting.DataEditor.Enum;
using Huiting.DataEditor.Models;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Huiting.DataEditor.ExcelHelper
{
    //Excel文件导入操作类
    public class C_OpExcelImport
    {
        #region 属性

        //当前处理信息
        RunInfo curRunInfo = null;
        //共处理了多少条记录
        int OpRowsCount = 0;
        //列配置对应关系设置
        ExcelColumnMappingConfig curColumnConfig = null;
        //读取的Excel数据集
        DataSet curExcelFileData = null;
        //实际要保存的表
        DataTable curTable = null;

        //当前数据操作的类型
        DataImportOpType curImportType = DataImportOpType.None;

        //要导入数据的列集合
        BaseDataMappingTable curImportColumnsInfo = new BaseDataMappingTable();

        //错误信息
        public string ErrMsg = "";

        #endregion

        public C_OpExcelImport(RunInfo curRunInfo, DataImportOpType curImportType, ExcelColumnMappingConfig curColumnConfig,DataSet curExcelFileData)
        {
            this.opSourceDB = opSourceDB;
            this.curRunInfo = curRunInfo;
            this.curColumnConfig = curColumnConfig;
            this.curExcelFileData = curExcelFileData;
            this.curImportType = curImportType;
        }

        //开始处理
        public void BeginOp(List<SQLParams> VarValueSQLParams)
        {
            this.VarValueSQLParams = VarValueSQLParams;
            curRunInfo.HitMsg = "正在完成文档与字段的对应映射……";
            //修改字段名称
            RepareDataColumnName();
            curRunInfo.HitMsg = "正在将数据保存进数据库……";
            //更新到数据库
            SavedataTable();
        }

        //保存数据
        private void SavedataTable()
        {
            string TableName = "";
            string TableTitle = "";
            //获取要保存的表名
            switch(curImportType)
            {
                case DataImportOpType.UnitBaseData:
                    TableName = curImportColumnsInfo.UnitBaseTableName;
                    TableTitle = "单元基本信息";
                    //增加工程ID，PJND信息
                    DYDab01AddProject();
                    break;
                case DataImportOpType.UnitDevelopData:
                    TableName = curImportColumnsInfo.UnitDevelopDataTableName;
                    TableTitle = "单元开发数据";
                    break;
                case DataImportOpType.WellDevelopData:
                    TableName = curImportColumnsInfo.WellDevelopDataTableName;
                    TableTitle = "单井开发数据";

                    if(!curTable.Columns.Contains("MQJB"))
                    {
                        curTable.Columns.Add("MQJB");

                        foreach(DataRow curRow in curTable.Rows)
                        {
                            curRow["MQJB"] = 1;
                        }

                    }

                    break;
                default:
                    break;
            }
            curTable.TableName = TableName;

            opSourceDB.NeedThrowException = false;
            opSourceDB.CurUpdateType = UpdateTableType.ForceParseSqlUpdate;

            
            //保存数据表
            if(!opSourceDB.UpdateDateTable(curTable,""))
            {
                ErrMsg = opSourceDB.ErrMsg;
                curRunInfo.ErrMsg = ErrMsg;
            }
            else
            {
                curRunInfo.SucMsg = "更新" + TableTitle + "数据 " + curTable.Rows.Count.ToString() + " 条。" ;
            }
        }

        //修正单元基本信息表，增加工程ID
        private void DYDab01AddProject()
        {
             string ParameValue = "";
             if (JugeContainVarParams("PROID", ref ParameValue))
             {
                 if (!curTable.Columns.Contains("proID"))
                 {
                     curTable.Columns.Add("proID");
                 }

                 foreach(DataRow curRow in curTable.Rows)
                 {
                     curRow["proID"] = ParameValue;
                 }


             }

             //if (JugeContainVarParams("PJND", ref ParameValue))
             //{
             //    if (!curTable.Columns.Contains("PJND"))
             //    {
             //        curTable.Columns.Add("PJND");
             //    }

             //    foreach (DataRow curRow in curTable.Rows)
             //    {
             //        curRow["PJND"] = ParameValue;
             //    }
             //}
        }

        private bool JugeContainVarParams(string ParameName, ref string ParameValue)
        {
            bool FindValue = false;
            ParameName = ParameName.ToLower();
            foreach (SQLParams curParams in VarValueSQLParams)
            {
                if (curParams.ParamName.ToLower() == ParameName)
                {
                    FindValue = true;
                    ParameValue = curParams.ParamValue.ToString();
                    break;
                }
            }

            return FindValue;
        }

        //修正表字段列名称
        private void RepareDataColumnName()
        {
            if ((curColumnConfig.curSelImportType != curImportType) || (curColumnConfig.curSelImportType == DataImportOpType.None) || (curColumnConfig.ColumnConfig.Select("MappingColumnName <>''").Length == 0))
            {
                //无配置文件
                ModifyColumnNameFromAutoConfig();
            }
            else
            {
                //用户配置文件
                ModifyColumnNameFromUserConfig();
            }
        }

        //不根据用户配置，修改完善字段，主要是解决用户选择了默认模板文件的问题。
        private void  ModifyColumnNameFromAutoConfig()
        {

            ArrayList DelList = new ArrayList();
            curTable = curExcelFileData.Tables[0];
            int ColumnCount = curTable.Columns.Count;
            DataRow ColumnRow = curTable.Rows[0];

            string ColumnName = "";
            string RealFiledName = "";
            for (int i = 0; i< ColumnCount;i++)
            {
                ColumnName = ColumnRow[i].ToString();

                RealFiledName = curImportColumnsInfo.GetDBFieldName(curImportType, ColumnName);

                if(string.IsNullOrEmpty(RealFiledName))
                {
                    DelList.Add(curTable.Columns[i].ColumnName);
                    continue;
                }

                curTable.Columns[i].ColumnName = RealFiledName;
            }
            //删除不对应的字段
            for(int i=0;i<DelList.Count;i++)
            {
                curTable.Columns.Remove(DelList[i].ToString());
            }
            //删除列定义行，一般默认是两列
            curTable.Rows[1].Delete();
            curTable.Rows[0].Delete();
        }

        //根据用户配置修改完善字段
        private void ModifyColumnNameFromUserConfig()
        {

            ArrayList DelList = new ArrayList();
            //取到要转换的表
            curTable = curExcelFileData.Tables[curColumnConfig.SelSheetName];
            int ColumnCount = curTable.Columns.Count;
            DataRow ColumnRow = curTable.Rows[0];

            string ColumnName = "";
            string RealFiledName = "";
            for (int i = 0; i < ColumnCount; i++)
            {
                //取到首行的列名
                ColumnName = ColumnRow[i].ToString();
                //从用户定制的模板中取出对应的实际列名
                RealFiledName = GetUserConfigFieldName( ColumnName);

                if (string.IsNullOrEmpty(RealFiledName))
                {
                    //如果该行无映射，放入删除列表，一会删除
                    DelList.Add(curTable.Columns[i].ColumnName);
                    continue;
                }
                //修改为实际数据库的字段
                curTable.Columns[i].ColumnName = RealFiledName;
            }
            //删除不对应的字段
            for (int i = 0; i < DelList.Count; i++)
            {
                curTable.Columns.Remove(DelList[i].ToString());
            }
            //删除列定义行，一般默认是两列
            curTable.Rows[1].Delete();
            curTable.Rows[0].Delete();
        }

        //获取用户设置的该行的对应值
        private string GetUserConfigFieldName(string RowsColumnName)
        {
            string RealName = "";

            string Condition = "MappingColumnName='" + RowsColumnName + "'";
            DataRow[] Rows = curColumnConfig.ColumnConfig.Select(Condition);
            if (Rows.Length == 0)
                return "";
            RealName = Rows[0]["FiledName"].ToString();

            return RealName;
        }
    }



}
