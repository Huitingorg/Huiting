using Huiting.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveCommon
{
    public interface IStringConverter
    {
        string Separator { get; }

        bool ConvertFrom(string formatStr);
        string ConvertTo();
    }

    #region 分组--树形分级
    
    [Serializable]
    public class GroupInfo : IStringConverter
    {
        string separator = ",";

        public string Separator
        {
            get { return separator; }
        }

        SortType type;

        public SortType Type
        {
            get { return type; }
            set {
                if (type == value)
                    return;
                type = value;
                text = GetText(type);
            }
        }

        bool asc= true;

        public bool Asc
        {
            get { return asc; }
            set { asc = value; }
        }

        string text;

        public string Text
        {
            get
            {
                if (string.IsNullOrEmpty(text))
                    text = GetText(type);
                return text;
            }
            set { text = value; }
        }

        public string GetFieldName()
        {
            return SortTypeFactory.Instance.GetFieldName(this.type);
        }

        private string GetText(SortType type)
        {
            return EnumAttrDict<SortType, SortAttribute>.Instance.GetAttribute(type).Description;
        }

        public bool ConvertFrom(string formatStr)
        {
            string[] strAry = formatStr.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            if (strAry.Length <= 0)
                return false;
            if (strAry.Length >= 1)
                Type = (SortType)Enum.Parse(typeof(SortType), strAry[0]);
            if (strAry.Length >= 2)
            {
                int bolValue;
                int.TryParse(strAry[1], out bolValue);
                this.asc = bolValue == 0 ? false : true;
            }

            return true;
        }

        public string ConvertTo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Type.ToString());
            sb.Append(separator);
            sb.Append(this.Asc == true ? 1 : 0);
            return sb.ToString();
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Text))
                return base.ToString();
            return Text;
        }
    }

    [Serializable]
    public class GroupInfoQueue : BasicQueue<GroupInfo>, IStringConverter
    {
        string separator = ";";
        public string Separator
        {
            get { return separator; }
        }

        public bool ConvertFrom(string formatStr)
        {
            if (string.IsNullOrEmpty(formatStr))
                return false;
            this.lstData.Clear();
            string[] strAry = formatStr.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in strAry)
            {
                GroupInfo si = new GroupInfo();
                if (si.ConvertFrom(item))
                    this.lstData.Add(si);
            }

            return true;
        }

        public string ConvertTo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (GroupInfo item in this.lstData)
            {
                string itemStr = item.ConvertTo();
                if (string.IsNullOrEmpty(itemStr))
                    continue;
                sb.Append(itemStr);
                sb.Append(separator);
            }

            return sb.ToString();
        }
    }

    #endregion

    #region 排序--列出现的排序
    
    [Serializable]
    public class SortInfo : GroupInfo
    {
        #region Properties

        int width=100;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        int sortIndex;
        //排序序号
        public int SortIndex
        {
            get { return sortIndex; }
            set { sortIndex = value; }
        }

        public SortInfo()
        {
            this.Width = 120;
            this.Asc = true;
        }

        #endregion



        public new bool ConvertFrom(string formatStr)
        {
            string[] strAry = formatStr.Split(new string[] { Separator }, StringSplitOptions.RemoveEmptyEntries);
            if (strAry.Length <= 0)
                return false;
            if (strAry.Length >= 1)
                Type = (SortType)Enum.Parse(typeof(SortType), strAry[0]);
            if (strAry.Length >= 2)
                int.TryParse(strAry[1],out width);
            if(strAry.Length>=3)
            {
                int bolValue;
                int.TryParse(strAry[2],out bolValue);
                this.Asc = bolValue == 0 ? false : true;
            }

            return true;
        }

        public new string ConvertTo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Type.ToString());
            sb.Append(Separator);
            sb.Append(Width.ToString());
            sb.Append(Separator);
            sb.Append(this.Asc == true ? 1 : 0);
            return sb.ToString();
        }

        public SortInfo Copy()
        {
            return PublicMethods.DeepClone(this);
        }
    }

    public class SrotInfoComparer : IComparer<SortInfo>
    {
        public int Compare(SortInfo x, SortInfo y)
        {
            if (x.SortIndex > y.SortIndex)
                return 1;
            else if (x.SortIndex == y.SortIndex)
                return 0;
            else
                return -1;
        }
    }

    [Serializable]
    public class SortInfoQueue : BasicQueue<SortInfo>,IStringConverter
    {
        string separator = "|";

        public string Separator
        {
            get { return separator; }
            set { separator = value; }
        }

        public bool ConvertFrom(string formatStr)
        {
            if (string.IsNullOrEmpty(formatStr))
                return false;
            this.lstData.Clear();
            string[] strAry = formatStr.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in strAry)
            {
                SortInfo si = new SortInfo();
                if (si.ConvertFrom(item))
                    this.lstData.Add(si);
            }

            return true;
        }

        public string ConvertTo()
        {
            StringBuilder sb=new StringBuilder();
            foreach (SortInfo item in this.lstData)
            {
                string itemStr = item.ConvertTo();
                if (string.IsNullOrEmpty(itemStr))
                    continue;
                sb.Append(itemStr);
                sb.Append(separator);
            }

            return sb.ToString();
        }

        public string ToOrderSql()
        {
            //做复本
            List<SortInfo> lstCopy=new List<SortInfo>();
            foreach (SortInfo item in this.lstData)
            {
                SortInfo si = item.Copy();
                si.Text = si.Type.ToString() + " " + (si.Asc ? "asc" : "desc");
                lstCopy.Add(si);
            }

            //给复本排序
            SrotInfoComparer siComparer = new SrotInfoComparer();
            lstCopy.Sort(siComparer);

            //收集部分sql 
            string sqlPart=null;
            foreach (SortInfo item in lstCopy)
            {
                if(!string.IsNullOrEmpty(sqlPart))
                    sqlPart+=",";
                sqlPart += item.Type.ToString() + " " + (item.Asc ? "asc" : "desc");
            }

            return sqlPart;
        }

        public Dictionary<string, string> GetDictPropertyName()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (SortInfo item in lstData)
            {
                string key= SortTypeFactory.Instance.GetFieldName(item.Type);
                string text = EnumDictionary<SortType>.Instance.GetAttribute(item.Type).Description;
                dict.Add(key, text);
            }

            return dict;
        }
    }

    #endregion
}