using Huiting.DBAccess.Entity;
using Huiting.DBAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.DBAccess.Service
{
    public interface IDataService<T> where T : IDto
    {
        string TableName { get; }
    }

    public abstract class ADataService<T> : IDataService<T> where T : IDto
    {
        public string TableName
        {
            get { return DapperHelper.TableNames[typeof(T)]; }
        }



    }
}
