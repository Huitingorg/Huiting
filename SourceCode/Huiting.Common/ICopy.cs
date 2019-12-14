using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.Common
{
    public interface ICopy<T>
    {
        T Copy();
    }

    public abstract class ACopy<T> where T : class
    {
        public T Copy()
        {
            return PublicMethods.DeepClone<T>(this as T);
        }
    }
}
