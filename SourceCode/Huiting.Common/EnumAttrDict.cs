using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Huiting.Common
{
    public class EnumAttrDict<T, K>
        where T : struct
        where K : Attribute
    {
        private static EnumAttrDict<T, K> instance = new EnumAttrDict<T, K>();

        public static EnumAttrDict<T, K> Instance
        {
            get { return EnumAttrDict<T, K>.instance; }
        }

        private Dictionary<T, K> dictStyle = new Dictionary<T, K>();

        public Dictionary<T, K> Dictionary
        {
            get { return dictStyle; }
        }

        protected EnumAttrDict()
        {
            System.Reflection.FieldInfo[] fieldAry = typeof(T).GetFields();
            foreach (System.Reflection.FieldInfo item in fieldAry)
            {
                object[] objAry = item.GetCustomAttributes(typeof(K), false);
                if (objAry.Length > 0)
                {
                    K da = objAry[0] as K;
                    dictStyle.Add((T)Enum.Parse(typeof(T), item.Name), da);
                }
            }
        }

        public K GetAttribute(T t)
        {
            if (dictStyle.ContainsKey(t))
                return dictStyle[t];
            else
                return default(K);
        }
    }
}
