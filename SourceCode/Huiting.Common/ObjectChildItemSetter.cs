using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.Common
{
    public class ObjectChildItemSetter
    {
        /// <summary>
        /// 属性赋值
        /// </summary>
        /// <param name="objGiver">给予者</param>
        /// <param name="objReceiver">接收者</param>
        /// <returns></returns>
        public static bool SetProperties(object objGiver, object objReceiver)
        {
            if (objGiver == null)
                return false;

            Type typeGiver = objGiver.GetType();
            Type typeReceiver = objReceiver.GetType();
            var piAryGiver = typeGiver.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            var piAryReceiver = typeReceiver.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            foreach (var piReceiver in piAryReceiver)
            {
                if (piReceiver.PropertyType != typeof(string) || piReceiver.CanWrite == false)
                    continue;
                var piGiver = piAryReceiver.FirstOrDefault(x => x.PropertyType == piReceiver.PropertyType && x.Name == piReceiver.Name);
                if (piGiver == null)
                    continue;
                var giverValue = piGiver.GetValue(objReceiver, null);
                piGiver.SetValue(objReceiver, giverValue, null);
            }

            return true;
        }

    }
}
