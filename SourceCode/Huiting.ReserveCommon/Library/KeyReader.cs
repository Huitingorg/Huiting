using Huiting.Common;
using System;
using System.Data;
using System.IO;

namespace ReserveCommon
{
    public class KeyReader
    {
        DataTable dtConfig;

        string configFile;
        public KeyReader(string fileName)
        {
            if (PublicMethods.IsAbsolutePath(fileName))
                configFile = PublicMethods.GetAbsolutePath(fileName);
            else
                configFile = fileName;
            ReadFile();
        }

        private void InitDataTable()
        {
            if (dtConfig != null)
                return;

            dtConfig = new DataTable();
            dtConfig.TableName = "config";
            dtConfig.Columns.Add("key");
            dtConfig.Columns.Add("value");
        }

        public void ReadFile()
        {
            InitDataTable();
            if (File.Exists(configFile) == false)
                return;
            try
            {
                dtConfig.ReadXml(configFile);
            }
            catch (Exception ex)
            {
                File.Delete(configFile);
            }
        }

        public void SaveFile()
        {
            try
            {
                dtConfig.WriteXml(configFile, XmlWriteMode.IgnoreSchema);
            }
            catch (Exception ex)
            {

            }
        }

        public void SetValue(string key, object value)
        {
            string _value = value == null ? "" : value.ToString();
            SetValue(key, _value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">key不区分大小写</param>
        /// <param name="value">value区分大小写</param>
        public void SetValue(string key,string value)
        {
            //key不区分大小写
            key= key.ToLower();
            DataRow[] drAry = dtConfig.Select("key ='" + key + "'");
            if (drAry.Length > 0)
            {
                drAry[0][1] = value;
            }
            else
            {
                DataRow dr = dtConfig.NewRow();
                dr[0] = key;
                dr[1] = value;

                dtConfig.Rows.Add(dr);
            }

            SaveFile();
        }

        public string GetValue(string key)
        {
            //key不区分大小写
            key = key.ToLower();
            DataRow[] drAry = dtConfig.Select("key ='" + key + "'");
            if (drAry.Length > 0)
                return drAry[0][1].ToString();
            return null;
        }

        public bool ExistKey(string key)
        {
            //key不区分大小写
            key = key.ToLower();
            DataRow[] drAry = dtConfig.Select("key ='" + key + "'");
            return drAry.Length > 0;
        }
    }

    //public class ConfigKey
    //{
    //    public static string UseQyb = "UseQyb";
    //    public static string DefaultMonthCountByQYB = "DefaultMonthCountByQYB";
    //    public static string LimitedTime = "LimitedTime";
    //    public static string Title = "Title";
    //}
}