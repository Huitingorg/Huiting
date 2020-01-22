using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYY.Windows.SAAS.Contract.Enums;

namespace Huiting.DBAccess.Attributes
{
    /// <summary>
    /// 动态列特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DynamicColumnAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="header">标题</param>
        /// <param name="type">类型</param>
        /// <param name="index">索引</param>
        /// <param name="width">宽度</param>
        //public DynamicColumnAttribute(string header, ColumnTypeEnum type, int index, double width = 100)
        //{
        //    Header = header;
        //    Type = type;
        //    Index = index;
        //    Width = width;
        //}

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="header">标题</param>
        /// <param name="type">类型</param>
        /// <param name="index">索引</param>
        /// <param name="isShown">是否显示</param>
        /// <param name="isSystem">是否为系统</param>
        /// <param name="width">宽度</param>
        public DynamicColumnAttribute(string header, ColumnTypeEnum type, int index, int isShown = 1, int isSystem = 0, double width = 100)
        {
            Header = header;
            Type = type;
            Index = index;
            IsShown = isShown;
            IsSystem = isSystem;
            Width = width;
        }

        /// <summary>
        /// 列标题
        /// </summary>
        public string Header { get; }

        /// <summary>
        /// 列类型
        /// </summary>
        public ColumnTypeEnum Type { get; }

        /// <summary>
        /// 列宽度
        /// </summary>
        public double Width { get; }

        /// <summary>
        /// 列索引
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// 是否显示(0：否默认 1：是)
        /// </summary>
        public int IsShown { get; }

        /// <summary>
        /// 是否系统列，系统列不可由用户更改显示、隐藏属性(0：否默认 1：是)
        /// </summary>
        public int IsSystem { get; }
    }
}
