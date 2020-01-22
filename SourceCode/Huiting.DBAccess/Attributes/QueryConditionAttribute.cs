using System;

namespace Huiting.DBAccess.Attributes
{
    /// <summary>
    /// 查询条件特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryConditionAttribute : Attribute
    {
        /// <summary>
        /// 是否为查询条件属性
        /// </summary>
        public bool IsLikeQuery { get; private set; }
        
        public QueryConditionAttribute(bool isLikeQuery = false)
        {
            this.IsLikeQuery = isLikeQuery;
        }
    }
}
