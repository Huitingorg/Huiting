using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.DB.Access
{
    public interface IEntity
    {
        /// <summary>
        /// 操作版本号
        /// </summary>
        long BaseVersion { get; set; }

        /// <summary>
        /// 药店唯一标识
        /// </summary>
        string OrganSign { get; set; }
    }
}
