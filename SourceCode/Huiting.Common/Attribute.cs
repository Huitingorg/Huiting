using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BDSoft.Common
{
    /// <summary>
    /// 元素
    /// </summary>
    public class ElementDescriptionAttribute:DescriptionAttribute
    {
        string descrption;

        public string Descrption
        {
            get { return descrption; }
            set { descrption = value; }
        }
    }

    /// <summary>
	/// 类描述
    /// </summary>
    public class ClassDescriptionAttribute : ElementDescriptionAttribute
    {

    }

	/// <summary>
	/// 方法描述
	/// </summary>
    public class MethodDescriptionAttribute : ElementDescriptionAttribute
    {
        string[] paramAry;

        public string[] ParamAry
        {
            get { return paramAry; }
            set { paramAry = value; }
        }
    }

	/// <summary>
	/// 组件描述
	/// </summary>
    public class ComponentDescriptionAttribute : ClassDescriptionAttribute
    {
        string name;

        /// <summary>
        /// 名字
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }


}
