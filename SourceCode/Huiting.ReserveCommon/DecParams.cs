using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveCommon
{
    public class DecParams
    {
        /// <summary>
        /// 项目ID
        /// </summary>
        string proID;
        /// <summary>
        /// 项目ID
        /// </summary>
        public string ProID
        {
            get { return proID; }
            set { proID = value; }
        }

        string pjnd;

        public string Pjnd
        {
            get { return pjnd; }
            set { pjnd = value; }
        }

        string dydm;

        public string Dydm
        {
            get { return dydm; }
            set { dydm = value; }
        }

        /// <summary>
        /// 预测起始日期
        /// </summary>
        DateTime preStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        /// <summary>
        /// 预测起始日期
        /// </summary>
        public DateTime PreStartDate
        {
            get { return preStartDate; }
            set
            {
                if (value == DateTime.MaxValue || value == DateTime.MinValue)
                    throw new Exception("预测起始日期必须在合理的范围内！");
                preStartDate = value;
            }
        }

        public string Ycqsrq
        {
            get
            {
                return PreStartDate.ToString("yyyyMM");
            }
        }

        /// <summary>
        /// 预测结束日期
        /// </summary>
        DateTime preEndDate;
        /// <summary>
        /// 预测结束日期
        /// </summary>
        public DateTime PreEndDate
        {
            get { return preEndDate; }
            set {
                if (value <= preStartDate)
                    throw new Exception("预测结束日期 必须大于 预测起始日期");
                preEndDate = value;
            }
        }

        /// <summary>
        /// 产量起始日期
        /// </summary>
        DateTime outputStartDate = DateTime.Now;
        /// <summary>
        /// 产量起始日期
        /// </summary>
        public DateTime OutputStartDate
        {
            get { return outputStartDate; }
            set
            {
                if (value < preStartDate)
                    throw new Exception("产量起始日期 必须大于等于 预测起始日期 !");
                outputStartDate = value;
            }
        }

        /// <summary>
        /// 折现日期
        /// </summary>
        DateTime discountDate = DateTime.Now;
        /// <summary>
        /// 折现日期
        /// </summary>
        public DateTime DiscountDate
        {
            get { return discountDate; }
            set { discountDate = value; }
        }
        /// <summary>
        /// 折现率
        /// </summary>
        double discountRate = 0.1;
        /// <summary>
        /// 折现率
        /// </summary>
        public double DiscountRate
        {
            get { return discountRate; }
            set {
                if (discountRate >= 1 || discountRate <= 0)
                    throw new Exception("折现率 应该在0~1的范围内！");
                discountRate = value; }
        }

        /// <summary>
        /// 极限最小产量吨
        /// </summary>
        public double LimitMinOutput = 0.001;

        public DecParams()
        {
            preEndDate = preStartDate.AddYears(100).AddMonths(-1);
        }

        ///// <summary>
        ///// 极限最大月份（从预测起始日期开始算起）
        ///// </summary>
        //int limitMaxMonthsCount = 1200;

        //public int LimitMaxMonthsCount
        //{
        //    get { return limitMaxMonthsCount; }
        //    set {
        //        if (value <= 0 || value >= int.MaxValue)
        //            throw new Exception("极限最大月份 必须在0~+∞ 之间！");
        //        limitMaxMonthsCount = value; }
        //}
        //public DateTime ReachMaxDate
        //{
        //    get
        //    {
        //        return PreStartDate.AddMonths(LimitMaxMonthsCount-1);
        //    }
        //}
    }
}