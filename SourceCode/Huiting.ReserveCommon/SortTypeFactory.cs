using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveCommon
{
   public class SortTypeFactory
    {
        private static SortTypeFactory instance = new SortTypeFactory();

        public static SortTypeFactory Instance
        {
            get { return SortTypeFactory.instance; }
            set { SortTypeFactory.instance = value; }
        }

       private SortTypeFactory()
       {

       }

       public string GetFieldName(SortType type)
       {
           return type.ToString();
       }

    }
}
