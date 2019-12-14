using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.DataEditor.Models
{
    public class RunInfo
    {

        //提示文本
        public string HitMsg = "";

        //提示文本
        public string ChildHitMsg = "";

        private string totalNeedTime = "";

        //总进度还需要时间

        public string TotalNeedTime
        {
            get
            {
                OpTotalNeedTime();
                return totalNeedTime;
            }

        }

        private string childNeedTime = "";

        //子进度还需要时间
        public string ChildNeedTime
        {
            get
            {
                OpChildTotalNeedTime();
                return childNeedTime;
            }
        }

        private int totalCount = 0;
        private int curOpCount = 0;
        //处理开始时间
        private DateTime beginTime = DateTime.Now;
        //运行成功信息
        public string SucMsg = "";
        //运行错误信息
        public string ErrMsg = "";

        //当前更新的进度是子项还是父相,对应进度向不同的进度里面写
        public bool OpParentProgress = true;

        //获取还需多少时间
        private void OpTotalNeedTime()
        {

            int curValue = CurOpCount;
            if (curValue <= 0)
            {
                return;
            }
            int MaxValue = totalCount;

            DateTime dt1 = DateTime.Now;


            TimeSpan ts = dt1.Subtract(beginTime);

            float TotalSec = ts.Hours * 60 * 60 + ts.Minutes * 60 + ts.Seconds;

            float NeedSec = (MaxValue - curValue) * TotalSec / curValue;

            if (NeedSec < 60)
            {
                totalNeedTime = "约需" + ((int)NeedSec).ToString() + "秒";
            }
            else
            {
                int Num = (int)(NeedSec / 60) + 1;
                totalNeedTime = "约需 " + Num.ToString() + "分钟";
            }


        }
        //设置总进度数据总数
        public int TotalCount
        {
            get
            {
                return totalCount;
            }
            set
            {
                totalCount = value;
                beginTime = DateTime.Now;
                CurOpCount = 0;
                totalNeedTime = "";
            }
        }

        //总进度当前处理进度
        public int CurOpCount
        {
            get
            {
                return curOpCount;
            }
            set
            {
                curOpCount = value;

                //处理所需时间
                //OpTotalNeedTime();
            }
        }

        private int childTotalCoung = 0;
        private int curChildOpCount = 0;

        //处理开始时间
        private DateTime childbeginTime = DateTime.Now;
        //获取还需多少时间
        private void OpChildTotalNeedTime()
        {

            int curValue = curChildOpCount;
            if (curValue <= 0)
            {
                return;
            }
            int MaxValue = childTotalCoung;

            DateTime dt1 = DateTime.Now;

            TimeSpan ts = dt1.Subtract(childbeginTime);

            float TotalSec = ts.Hours * 60 * 60 + ts.Minutes * 60 + ts.Seconds;

            float NeedSec = (MaxValue - curValue) * TotalSec / curValue;

            if (NeedSec < 60)
            {
                childNeedTime = "约需" + ((int)NeedSec).ToString() + "秒";
            }
            else
            {
                int Num = (int)(NeedSec / 60) + 1;
                childNeedTime = "约需 " + Num.ToString() + "分钟";
            }


        }

        //子进度总数
        public int ChildTotalCoung
        {
            get
            {
                return childTotalCoung;
            }
            set
            {
                childTotalCoung = value;
                childbeginTime = DateTime.Now;
                curChildOpCount = 0;
                childNeedTime = "";
            }
        }
        //当前子进度处理进度
        public int CurChildOpCount
        {
            get
            {
                return curChildOpCount;
            }
            set
            {
                curChildOpCount = value;
                //OpChildTotalNeedTime();
            }
        }

        /// <summary>
        /// 设置当前的进度最大值
        /// </summary>
        /// <param name="Value">最大值</param>
        public void SetTotalValue(int Value)
        {
            if (OpParentProgress)
            {
                TotalCount = Value;
            }
            else
            {
                ChildTotalCoung = Value;
            }
        }

        /// <summary>
        /// 设置进度当前值
        /// </summary>
        /// <param name="Value">进度值</param>
        public void SetCurValue(int Value)
        {
            if (OpParentProgress)
            {
                CurOpCount = Value;
            }
            else
            {
                CurChildOpCount = Value;
            }
        }

    }
}
