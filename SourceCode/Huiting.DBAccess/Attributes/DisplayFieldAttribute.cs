using System;

namespace Huiting.DBAccess.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayFieldAttribute : Attribute
    {
        /// <summary>
        /// 显示值
        /// </summary>
        public string DisplayText { get; set; }
        /// <summary>
        /// 显示别名
        /// </summary>
        public string DisplayAlias { get; set; }
        /// <summary>
        /// 中式单位
        /// </summary>
        public string CnUnitText { get; set; }
        /// <summary>
        /// 英式单位
        /// </summary>
        public string EnUnitText { get; set; }

        public DisplayFieldAttribute()
        {

        }

        public DisplayFieldAttribute(string DisplayText, string DisplayAlias = null, string CnUnitText = null, string EnUnitText = null)
        {
            this.DisplayText = DisplayText;
            this.DisplayAlias = DisplayAlias;
            this.CnUnitText = CnUnitText;
            this.EnUnitText = EnUnitText;
        }
    }
}
