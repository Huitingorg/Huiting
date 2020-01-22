using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveCommon
{
    public class DictColumnInherit
    {
        Dictionary<string, bool> dict;

        //public Dictionary<string, bool> Data
        //{
        //    get { return dict; }
        //}

        public bool ContainsKey(string Key)
        {
            return dict.ContainsKey(Key);
        }

        public bool this[string Key]
        {
            get
            {
                if (dict == null)
                    return false;
                if (dict.ContainsKey(Key) == false)
                    return false;
                return dict[Key];
            }
            set
            {
                if (dict == null)
                    return;
                if (dict.ContainsKey(Key) == false)
                    return;

                dict[Key] = value;
            }
        }

        public string[] Keys
        {
            get
            {
                if (dict == null)
                    return new string[0];
                return dict.Keys.ToArray();
            }
        }

        public DictColumnInherit(List<string> lst)
        {
            dict = new Dictionary<string, bool>();
            foreach (string item in lst)
            {
                dict.Add(item, false);
            }
        }

        public void SetValue(bool entityInherit)
        {
            string[] keyAry = dict.Keys.ToArray();
            for (int i = 0; i < keyAry.Length; i++)
            {
                dict[keyAry[i]] = entityInherit;
            }
        }

        public void ReSet()
        {
            SetValue(false);
        }

        public bool EntityInherit()
        {
            foreach (KeyValuePair<string, bool> item in dict)
            {
                if (item.Value == false)
                    return false;
            }

            return true;
        }
    }
}
