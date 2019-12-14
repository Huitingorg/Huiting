using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.DBAccess.Attributes
{
    /// <summary>
    /// 表特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class DataTableAttribute : Attribute
    {
        public DataTableAttribute(string tableName, bool isClearData = false)
        {
            TableName = tableName;
            IsClearData = isClearData;
        }

        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName { get; }

        /// <summary>
        /// 是否清除数据，清除数据为true；不清除为false默认
        /// </summary>
        public bool IsClearData { get; }
    }
}
