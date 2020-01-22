using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Huiting.Common;

namespace ReserveCommon
{
    public class GlobalInfo
    {
        //每桶体积
        public readonly static double BarrelVolume = 6.2898;
        //1m^3 = 35.3147248 立方英尺
        public readonly static double M3ToCF = 35.3147248;
        public readonly static double M3ToMCF = 0.0353147248;

        public readonly static string SensitivityVariable = "Φ";

        public static string Undefined = "未定义";

        public static string TreeRootID = "0";
        public static string DefaultPjnd = "root";
        public static string LocalDBFile = PublicMethods.GetAbsolutePath("local.bddb");
        //单元模板
        public static string DYTemplate = PublicMethods.GetAbsolutePath("DYTemplate.xml");
        //单元曲线选项
        public static string DYSeriesOptions = PublicMethods.GetAbsolutePath("DYSeriesOptions.xml");
        //单元标定模板
        public static string DYBDTemplate = PublicMethods.GetAbsolutePath("DYBDTemplate.xml");

        //构成模板
        public static string GCTemplate = PublicMethods.GetAbsolutePath("GCTemplate.xml");
        //构成曲线选项
        public static string GCSeriesOptions = PublicMethods.GetAbsolutePath("GCSeriesOptions.xml");
        //构成标定模板
        public static string GCBDTemplate = PublicMethods.GetAbsolutePath("GCBDTemplate.xml");

        //拉齐模板
        public static string LQTemplate = PublicMethods.GetAbsolutePath("LQTemplate.xml");
        //拉齐曲线选项
        public static string LQSeriesOptions = PublicMethods.GetAbsolutePath("LQSeriesOptions.xml");
        //拉齐标定模板
        public static string LQBDTemplate = PublicMethods.GetAbsolutePath("LQBDTemplate.xml");
        //敏感性分析
        public static string SensitivityTemplate = PublicMethods.GetAbsolutePath("SensitivityTemplate.xml");
        //失控模板
        public static string SKTemplate = PublicMethods.GetAbsolutePath("SKTemplate.xml");
        //扶停
        public static string FTTemplate = PublicMethods.GetAbsolutePath("FTTemplate.xml");
        ////拉齐曲线选项
        //public static string LQSeriesOptions = PublicMethods.GetAbsolutePath("LQSeriesOptions.xml");
        ////拉齐标定模板
        //public static string LQBDTemplate = PublicMethods.GetAbsolutePath("LQBDTemplate.xml");

        public static bool UsedORGEMethod = true;
    }
}
