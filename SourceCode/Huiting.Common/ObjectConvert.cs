using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Huiting.Common
{
    public static class ObjectConvert
    {
        public static int ToInt(this Color color)
        {
            return color.ToArgb();
        }

        public static Color ToColor(this int argb)
        {
            return Color.FromArgb(argb);
        }

        public static Color ToColor(this string argb)
        {
            return Color.FromArgb(int.Parse(argb));
        }

        public static string ToString(this Color color)
        {
            return color.ToArgb().ToString();
        }

        public static string ConvertToString(this Padding padding)
        {
            return padding.Left.ToString() + "," +
                padding.Top.ToString() + "," +
                padding.Right.ToString() + "," +
                padding.Bottom.ToString();
        }

        public static Padding ToPadding(this string paddingStr)
        {
            Padding padding = new Padding();
            string[] strAry = paddingStr.Split(new char[] { ',' });
            if (strAry.Length != 4)
                return padding;

            padding = new Padding(int.Parse(strAry[0]), int.Parse(strAry[1]), int.Parse(strAry[2]), int.Parse(strAry[3]));
            return padding;
        }

        public static Size ToMaxSize(this SizeF sizef)
        {
            int Width = (int)(Math.Ceiling(sizef.Width));
            int Height = (int)(Math.Ceiling(sizef.Height));
            return new Size(Width, Height);
        }

        public static Size ToMinSize(this SizeF sizef)
        {
            int Width = (int)(Math.Floor(sizef.Width));
            int Height = (int)(Math.Floor(sizef.Height));
            return new Size(Width, Height);
        }

        public static double ToDoubleWithDefaultZero(this Object obj)
        {
            return obj.ToDouble(0.0);
        }

        public static double ToDouble(this Object obj, double DefaultValue)
        {
            double db = DefaultValue;
            if (obj == null || obj == System.DBNull.Value)
                return db;
            bool bol = double.TryParse(obj.ToString(), out db);
            return db;
        }

        public static double ToDouble(this Object obj)
        {
            double db = 0;
            if (obj == null || obj == System.DBNull.Value)
                return db;
            bool bol = double.TryParse(obj.ToString(), out db);
            return db;
        }

        public static double? ToDoubleOrNull(this Object obj)
        {
            double? result = null;
            if (obj == null || obj == System.DBNull.Value)
                return result;
            double curDB;
            if (double.TryParse(obj.ToString(), out curDB) == false)
                return result;
            result = curDB;
            return result;
        }

        public static double? ToDoubleOrNull(this Object obj, int decimalPlace)
        {
            double? result = default(double?);
            if (obj == null || obj == System.DBNull.Value)
                return result;

            result = obj.ToDouble(decimalPlace);
            return result;
        }

        public static double ToDouble(this Object obj, int decimalPlace)
        {
            double dblValue = obj.ToDouble();
            return PublicMethods.Round(dblValue, decimalPlace);
        }

        public static decimal ToDecimal(this Object obj)
        {
            decimal db = 0;
            if (obj == null)
                return db;
            bool bol = decimal.TryParse(obj.ToString(), out db);
            return db;
        }

        // 获取日期格式
        public static string GetDecimalFormat(int decimalPlace)
        {
            string format = "0";

            for (int i = 0; i < decimalPlace; i++)
            {
                if (i == 0)
                    format += ".";
                format += "#";
            }

            return format;
        }

        public static float ToFloat(this Object obj)
        {
            float db = float.NaN;
            if (obj == null || obj == System.DBNull.Value)
                return db;
            bool bol = float.TryParse(obj.ToString(), out db);
            if (bol)
                return db;
            else
                return float.NaN;
        }

        ////根据出现的可能性排序
        //static string[] DateStringAry = {   
        //                                    "yyyyMM",
        //                                    "yyyy/MM/dd","yyyy/MM/dd",
        //                                    "yyyy/MM",
        //                                    "yyyy/MM/dd hh:mm:ss",
        //                                    "yyyy/MM/dd h:mm:ss",
        //                                    "yyyy/MM/d h:mm:ss",
        //                                    "yyyy/MM/dd ddd hh:mm:ss",
        //                                    "yyyy/MM/dd/ddd hh:mm:ss",
        //                                    "yyyy/MM/dd ddd",
        //                                    "yyyy/MM/dd/ ddd",
        //                                    "yyyy", 
        //                                     "yyyy-MM", 
        //                                    "yyyy/M", "yyyy-M", "yyyyM",
        //                                    "MM/yyyy","MM-yyyy","MMyyyy",
        //                                    "M/yyyy", "M-yyyy", "Myyyy",
        //                                     "yyyy-MM-dd", "yyyyMMdd", 
        //                                    "yyyy/M/d", "yyyy-M-d", "yyyyMd", 
        //                                    "MM/dd/yyyy", "MM-dd-yyyy", "MMddyyyy",
        //                                    "M/d/yyyy", "M-d-yyyy", "Mdyyyy",
        //                                    "dd/MM/yyyy","dd-MM-yyyy","ddMMyyyy",
        //                                    "d/M/yyyy","d-M-yyyy","dMyyyy",
        //                                    };

        ////日期形式
        //static string[] DateStringAry = {   
        //                                    "yy",//年年

        //                                    "yyyy", //年年年年
        //                                    "yyMM", //年年月月
        //                                    "MMyy", //月月年年
        //                                    "yy-M", //年年-0月
        //                                    "M-yy", //0月-年年

        //                                    "yyyyM",
        //                                    "Myyyy",
        //                                    "yy-MM",
        //                                    "MM-yy",
   
        //                                    "yyyyMM",
        //                                    "MMyyyy",
        //                                    "yyMMdd",
        //                                    "MMddyy",
        //                                    "ddMMyy",
        //                                    "yyyy-M",
        //                                    "M-yyyy",
 
        //                                    "yyyy-MM",
        //                                    "MM-yyyy",

        //                                    "yy-MM-dd",
        //                                    "MM-dd-yy",
        //                                    "dd-MM-yy",

        //                                    "yyyyMMdd",
        //                                    "ddMMyyyy",
        //                                    "yyyy-M-d",
        //                                    "M-d-yyyy",
        //                                    "d-M-yyyy",

        //                                    "yyyy-MM-dd",
        //                                    "MM-dd-yyyy",
        //                                    "dd-MM-yyyy",

        //                                    "yyyy-M-d hh:mm",
        //                                    "M-d-yyyy hh:mm",
        //                                    "d-M-yyyy hh:mm",

        //                                    "yyyy-MM-dd hh:mm",
        //                                    "MM-dd-yyyy hh:mm",
        //                                    "dd-MM-yyyy hh:mm",

        //                                    "yyyy-MM-dd hh:mm:ss",
        //                                    "MM-dd-yyyy hh:mm:ss",
        //                                    "dd-MM-yyyy hh:mm:ss",
                                            
        //                                    "yyyyM",
        //                                    "yyyy-M",
        //                                    "Myyyy",
        //                                    "M-yyyy"
        //                                };

        //日期形式
        static string[] DateStringAry = {   
                                            //年月
                                            "yy-M", //年年-0月
                                            "M-yy", //0月-年年

                                            "yy-MM",
                                            "MM-yy",

                                            "yyyyMM",
                                            "MMyyyy",
                    
                                            "yyyy-M",
                                            "M-yyyy",

                                            "yyyy-MM",
                                            "MM-yyyy",

                                            //年月日
                                            "yyyyMMdd",
                                            "MMddyyyy",
                                            "ddMMyyyy",

                                            "yyMMdd",
                                            "MMddyy",
                                            "ddMMyy",

                                            "yyyy-M-d",
                                            "M-d-yyyy",
                                            "d-M-yyyy",

                                            "yyyy-MM-dd",
                                            "MM-dd-yyyy",
                                            "dd-MM-yyyy",

                                            //年月日时分
                                            "yyyy-M-d h:m",
                                            "M-d-yyyy h:m",
                                            "d-M-yyyy h:m",

                                            "yyyy-M-d hh:mm",
                                            "M-d-yyyy hh:mm",
                                            "d-M-yyyy hh:mm",

                                            "yyyy-MM-dd hh:mm",
                                            "MM-dd-yyyy hh:mm",
                                            "dd-MM-yyyy hh:mm",

                                            //年月日时分秒
                                            "yyyy-M-d h:m:s",
                                            "M-d-yyyy h:m:s",
                                            "d-M-yyyy h:m:s",

                                            "yyyy-M-d hh:mm:ss",
                                            "M-d-yyyy hh:mm:ss",
                                            "d-M-yyyy hh:mm:ss",

                                            "yyyy-MM-dd hh:mm:ss",
                                            "MM-dd-yyyy hh:mm:ss",
                                            "dd-MM-yyyy hh:mm:ss",
                                        };

        public static DateTime ToDateTime(this object dateTime)
        {
            DateTime rightNY = DateTime.Now;
            if (dateTime == null)
                return rightNY;

            //先用常归转换一次
            string strDateTime = dateTime.ToString().Trim();
            #region 处理字符串有包含非能决定日期的信息，比如周几或星期几等信息
            
            //若关键字符串中包含“周”或"星期"，先替换成关键字周
            strDateTime = strDateTime.Replace("星期", "周");
            //若关键字符串中包含“周”，先判断前后字符
            int index = strDateTime.IndexOf("周");
            if (index >= 0)
            {
                string strBefore = "", strAfter = "";
                if (index > 0)
                    strBefore = strDateTime.Substring(0, index - 1).Trim();
                if (index + 2 < strDateTime.Length)
                    strAfter = strDateTime.Substring(index + 3, strDateTime.Length - index - 3).Trim();
                strDateTime = strBefore + ' ' + strAfter;
            }

            #endregion

            if (DateTime.TryParse(strDateTime, out rightNY))
                return rightNY;

            //将分隔符批量替换成‘-’形式
            strDateTime = strDateTime.Replace('/', '-');
            
            //bool bol = DateTime.TryParseExact(strDateTime, "yyyy-M-d h:mm:ss", null, DateTimeStyles.None, out rightNY);
            if (DateTime.TryParseExact(strDateTime, DateStringAry, null, DateTimeStyles.None, out rightNY))
                return rightNY;
            return rightNY;
        }

        public static bool TryDateTime(this object dateTime)
        {
            DateTime rightNY;
            return dateTime.TryDateTime(out rightNY);
        }

        public static bool TryDateTime(this object dateTime, out DateTime rightNY)
        {
            rightNY = DateTime.Now;
            if (dateTime == null)
                return false;

            string strDateTime = dateTime.ToString().Trim();
            strDateTime = strDateTime.Replace('/', '-');

            if (DateTime.TryParse(strDateTime, out rightNY) == false)
            {
                if (DateTime.TryParseExact(strDateTime, DateStringAry, null, DateTimeStyles.None, out rightNY) == false)
                    return false;
            }
            return true;
        }

        public static int ToIntWithDefaultValue(this Object obj, int defaultValue)
        {
            if (obj == null)
                return defaultValue;

            int m_int = defaultValue;
            if (obj == null || obj == System.DBNull.Value)
                return m_int;

            double dbl;
            if (double.TryParse(obj.ToString(), out dbl))
                return (int)dbl;

            bool bol = Int32.TryParse(obj.ToString(), out m_int);
            if (bol)
                return m_int;
            return defaultValue;
        }

        public static int ToInt(this Object obj)
        {
            return obj.ToIntWithDefaultValue(0);
        }

        public static int? ToIntOrNull(this Object obj)
        {
            if (obj == null || obj == null || obj == System.DBNull.Value)
                return null;
            return obj.ToInt();
        }

        public static bool ToBoolWithZeroIsFalse(this Object obj)
        {
            if (obj != null)
            {
                string strObj = obj.ToString();
                if (strObj == "0" || string.IsNullOrEmpty(strObj))
                    return false;
            }
            return ToBool(obj);
        }

        public static bool ToBool(this Object obj)
        {
            if (obj == null)
                return false;
            string strObj = obj.ToString();

            bool result;
            //如果不能转换成bool值，但有值，则返回真
            if (bool.TryParse(strObj, out result) == false)
                return true;

            return result;
        }

        public static T[] Insert<T>(this T[] ary, int index, T obj)
        {
            List<T> lstT = new List<T>(ary);
            lstT.Insert(index, obj);
            return lstT.ToArray();
        }


        public static void SetColumnNameToLower(this DataTable dt)
        {
            foreach (DataColumn dc in dt.Columns)
                dc.ColumnName = dc.ColumnName.ToLower();
        }

        public static int IndexOf<T, D>(this Dictionary<T, D> dict, T keyValue)
        {
            int index = -1;
            foreach (KeyValuePair<T, D> item in dict)
            {
                index++;
                object objTmp = item.Key;
                object objTmp2 = keyValue;
                if (objTmp.ToString() == objTmp2.ToString())
                    return index;
            }

            return index;
        }

        /// <summary>
        /// 给表添加拼音列
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="pyColumn"></param>
        /// <param name="sourceColumn"></param>
        public static void AddPYColumn(this DataTable dt, string pyColumn, string sourceColumn)
        {
            if (dt.Columns.Contains(pyColumn)==false)
                dt.Columns.Add(pyColumn);

            if (dt.Columns.Contains(sourceColumn) == false) return;

            foreach (DataRow dr in dt.Rows)
                dr[pyColumn] = ChineseToPinYin.ToPinYin(dr[sourceColumn].ToString(), null);
        }
    }
}