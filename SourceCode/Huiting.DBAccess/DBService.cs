using Dapper;
using Huiting.DBAccess.Attributes;
using Huiting.DBAccess.Entity.Dict;
using Huiting.DBAccess.Entity.Dtos;
using Huiting.DBAccess.Generator;
using Huiting.DBAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Huiting.DBAccess
{
    /// <summary>
    /// 数据库操作服务--DBService为操作数据库唯一入口
    /// </summary>
    public partial class DBService
    {
        #region 属性

        /// <summary>
        /// 单例
        /// </summary>
        private static DBService _uniqueInstance;

        /// <summary>
        /// 同步锁
        /// </summary>
        private static readonly object Locker = new object();

        public Dictionary<string, ICache> Logics = new Dictionary<string, ICache>();

        /// <summary>
        /// 获取DbService实例
        /// </summary>
        /// <returns>DbService实例</returns>
        public static DBService Instance
        {
            get
            {
                // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
                // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
                // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
                lock (Locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (_uniqueInstance == null)
                    {
                        _uniqueInstance = new DBService();
                    }
                }

                return _uniqueInstance;
            }
        }

        #endregion 属性

        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        private DBService()
        {
            try
            {
                //包含所有数据库表的type数组
                List<Type> tableList = new List<Type> {
                  typeof(ProjectInfoDto),
                  typeof(UnitBasicDataDto),
                  typeof(UnitDevelopDataDto),
                  typeof(WellDevelopDataDto),
                };

                DBTableCorrector.CreateTable(tableList.ToArray());
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        #endregion 


        public static DBService GetInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            lock (Locker)
            {
                // 如果类的实例不存在则创建，否则直接返回
                if (_uniqueInstance == null)
                {
                    _uniqueInstance = new DBService();
                }
            }

            return _uniqueInstance;
        }




    }

}
