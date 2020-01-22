using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.DBAccess.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class BusinessKeyAttribute : Attribute
    {
        public string GroupName { get; set; } = "BLL";//业务逻辑层Key
        public BusinessKeyAttribute() { }

        public BusinessKeyAttribute(string GroupName)
        {
            this.GroupName = GroupName;
        }
    }
}
