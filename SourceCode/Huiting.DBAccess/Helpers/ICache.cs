using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace Huiting.DBAccess.Helpers
{
    public interface ICache
    {
        string GetEntityKey(IEntity entity);
        IEnumerable<T> GetEntitys<T>(SQLiteConnection conn, SQLiteTransaction trans);
    }
}
