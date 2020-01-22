using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Huiting.Common;
using System.IO;

namespace ReserveCommon
{
    /// <summary>
    /// 读写本地的用户操作状态信息
    /// </summary>
    public class ConfigInfo : KeyReader
    {
        private static ConfigInfo instance = new ConfigInfo();
        public static ConfigInfo Instance
        {
            get { return ConfigInfo.instance; }
        }

        private ConfigInfo()
            : base("configFile.bd")
        {
        }
    }

    public class FqclReader : KeyReader
    {
        private static FqclReader instance = new FqclReader();
        public static FqclReader Instance
        {
            get { return FqclReader.instance; }
        }

        private FqclReader()
            : base("defaultFqcl.bd")
        {
        }
    }
}