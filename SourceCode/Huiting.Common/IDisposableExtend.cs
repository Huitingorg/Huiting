using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.Common
{
    public interface IDisposableExtend:IDisposable
    {
        bool Disposed { get; }
    }

    [Serializable]
    public abstract class ADisposableExtend : IDisposableExtend
    {
        bool disposed = false;
        public bool Disposed
        {
            get
            {
                return disposed;
            }
        }

        public virtual void Dispose()
        {
            this.disposed = true;
            GC.Collect();
        }
    }

}
