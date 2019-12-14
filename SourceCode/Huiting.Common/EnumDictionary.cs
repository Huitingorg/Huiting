using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Huiting.Common
{
    public class EnumDictionary<T> : EnumAttrDict<T, DescriptionAttribute> where T : struct
    {
        private static EnumDictionary<T> instance = new EnumDictionary<T>();

        public new static EnumDictionary<T> Instance
        {
            get { return instance; }
            set { instance = value; }
        }

        protected EnumDictionary()
        {

        }

        public string GetDescription(T t)
        {
            Attribute attr = this.GetAttribute(t);
            if (attr == null)
                return null;
            object obj= PublicMethods.GetPropertyValue(attr, "Description");
            if (obj == null)
                return null;

            return obj.ToString();
        }

    }
}
