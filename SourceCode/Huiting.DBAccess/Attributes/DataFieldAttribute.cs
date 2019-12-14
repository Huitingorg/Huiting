using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.DBAccess.Attributes
{
    /// <summary>
    /// 字段特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DataFieldAttribute : Attribute
    {
        /// <summary>
        /// 创建表字段类型特性
        /// </summary>
        /// <param name="typeAndSize">类型</param>
        /// <param name="isNull">是否可空 true（默认）：可空 false：不可空</param>
        /// <param name="isPrimaryKey">是否主键 true：主键 false（默认）：非主键</param>
        /// <param name="isIdentity">是否自增列 true：自增 false（默认）：不自增</param>
        public DataFieldAttribute(string typeAndSize, bool isNull = true, bool isPrimaryKey = false, bool isIdentity = false, bool isUnique = false, bool isIndex = false, string defaultValue = null)
        {
            //ColumnName = columnName;
            TypeAndSize = typeAndSize;
            IsNull = isNull;
            IsPrimaryKey = isPrimaryKey;
            IsIdentity = isIdentity;
            IsUnique = isUnique;
            IsIndex = isIndex;
            DefaultValue = defaultValue;
        }

        /// <summary>
        /// 列名称
        /// </summary>
        //public string ColumnName { get; }

        /// <summary>
        /// 列类型和大小
        /// </summary>
        public string TypeAndSize { get; }

        /// <summary>
        /// 是否为空
        /// </summary>
        public bool IsNull { get; }

        /// <summary>
        /// 是否为主键
        /// </summary>
        public bool IsPrimaryKey { get; }

        /// <summary>
        /// 是否为自增列
        /// </summary>
        public bool IsIdentity { get; }

        /// <summary>
        /// 是否唯一
        /// </summary>
        public bool IsUnique { get; }

        /// <summary>
        /// 是否创建索引
        /// </summary>
        public bool IsIndex { get; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; }
    }
}
