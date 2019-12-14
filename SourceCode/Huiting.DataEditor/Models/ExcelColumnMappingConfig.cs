using Huiting.DataEditor.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Huiting.DataEditor.Models
{
    /// <summary>
    /// Excel列配置对象
    /// </summary>
    public class ExcelColumnMappingConfig
    {
        //用户选择的Sheet页
        public string SelSheetName = "";
        //数据表列占行数
        public int ColumnRows = -1;
        //字段映射配置
        public DataTable ColumnConfig = new DataTable();
        //用户操作的当前导入类型
        public DataImportOpType curSelImportType = DataImportOpType.None;
        public ExcelColumnMappingConfig(string SelSheetName, int ColumnRows, DataTable ColumnConfig)
        {
            this.SelSheetName = SelSheetName;
            this.ColumnRows = ColumnRows;
            this.ColumnConfig = ColumnConfig;
        }
        public ExcelColumnMappingConfig()
        {

        }
    }
}
