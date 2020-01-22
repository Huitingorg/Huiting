using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Huiting.Common;

namespace ReserveCommon
{
    [Serializable]
    public class ColumnInfo
    {
        public ColumnInfo()
        {
            
        }

        public ColumnInfo(ColumnInfo columnInfoDjl, int index)
        {
            DataPropertyName = columnInfoDjl.DataPropertyName + index.ToString();
            HeadText = "第" + index.ToString() + "段" + columnInfoDjl.HeadText;
            Unit = columnInfoDjl.Unit;
            DataType = columnInfoDjl.DataType;
            Format = columnInfoDjl.Format;
        }

        /// <summary>
        /// 列头
        /// </summary>
        public string HeadText { get; set; }
        /// <summary>
        /// 对应数据字段
        /// </summary>
        public string DataPropertyName { get; set; }

        public string Unit { get; set; }

        public Type DataType { get; set; }

        public int Width { get; set; }

        public string Format { get; set; }

        //public bool Visible { get; set; }
        bool visible = true;

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
    }

    //预测线的参数的部分
    [Serializable]
    public class PreResultLineParamPart
    {
        public double? DJL { get; set; }
        public int? MonthsCount { get; set; }
        //public double? TZ { get; set; }
    }

    //预测线的参数
    [Serializable]
    public class PreResultLineParam : ICopy<PreResultLineParam>
    {
        public string ProID;
        public string Dydm;
        public string Pjnd;
        public string ProductType;
        //预测起始日期
        public string Ycqsrq;
        //初始日期（未开发使用的）
        public string Csrq;
        //初始产量
        public double Cscl;
        //末期产量
        public double Mqcl;
        //气油比
        public double QYB;
        //笔记
        public string Note;

        public List<PreResultLineParamPart> LstParamPart;

        public string Checked()
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(Dydm))
                sb.Append("单元代码不能为空；");
            if (string.IsNullOrEmpty(Pjnd))
                sb.Append("评价年度不能为空；");
            if (string.IsNullOrEmpty(Ycqsrq))
                sb.Append("预测起始日期不能为空；");
            if (Ycqsrq.TryDateTime() == false)
                sb.Append("预测起始日期格式不正确；");

            if (string.IsNullOrEmpty(Csrq))
                sb.Append("初始日期不能为空；");
            if (Csrq.TryDateTime() == false)
                sb.Append("初始日期格式不正确；");

            if (double.NaN.Equals(Cscl) || Cscl <= 0)
                sb.Append("初始产量值不正确；");
            if (double.NaN.Equals(Mqcl) || Mqcl <= 0)
                sb.Append("末期产量值不正确；");

            if (double.NaN.Equals(Cscl) == false && double.NaN.Equals(Mqcl) == false && Cscl < Mqcl)
                sb.Append("初始产量小于末期产量；");

            if (LstParamPart == null || LstParamPart.Count == 0)
            {
                sb.Append("缺少递减段信息；");
                return sb.ToString(); ;
            }

            bool preMonthsCountValid = false;
            for (int i = 0; i < LstParamPart.Count; i++)
            {
                PreResultLineParamPart item = LstParamPart[i];
                if (i == 0)
                {
                    if (item.DJL == null || double.NaN.Equals(item.DJL))
                        sb.Append("第1段递减率不能为null；");
                    if (item.MonthsCount == null)
                        preMonthsCountValid = false;
                    else
                        preMonthsCountValid = true;
                }
                else
                {
                    if (preMonthsCountValid == false)
                    {
                        sb.Append("未设置第" + (i + 1) + "段递减延续时间；");
                        //if(item.DJL==LstParamPart[i-1].DJL)
                        //    sb.Append("未设置第" + (i + 1) + "段递减延续时间；");
                        //else
                        //    sb.Append("未设置第" + (i + 1) + "段递减延续时间；");
                    }
                }
            }
            return sb.ToString();
        }

        public PreResultLineParam Copy()
        {
            PreResultLineParam prlp = new PreResultLineParam();

            prlp.ProID = this.ProID;
            prlp.Dydm = this.Dydm;
            prlp.Pjnd = this.Pjnd;
            prlp.ProductType = this.ProductType;
            prlp.Ycqsrq = this.Ycqsrq;
            prlp.Csrq = this.Csrq;
            prlp.Cscl = this.Cscl;
            prlp.Mqcl = this.Mqcl;
            prlp.QYB = this.QYB;

            prlp.LstParamPart = new List<PreResultLineParamPart>();

            foreach (PreResultLineParamPart item in this.LstParamPart)
            {
                PreResultLineParamPart prlpp = new PreResultLineParamPart();

                prlpp.DJL = item.DJL;
                prlpp.MonthsCount = item.MonthsCount;

                prlp.LstParamPart.Add(prlpp);
            }

            return prlp;
        }
    }
}
