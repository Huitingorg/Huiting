using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ReserveCommon
{
    /// <summary>
    /// 节点类型
    /// </summary>
    public enum EnumNodeType
    {
        CYC = 0,//采油厂
        YT = 1,//油田
        DY = 2,//单元
        Other = 3//根节点
    }

    //单元内容分组
    public enum UnitContentGroupType
    {
        [Description("基础数据")]
        JiChuShuJu,
        [Description("Arps递减分析")]
        HeXinFenXi,
        [Description("水驱特征曲线分析")]
        ShuQuTeZheQuXianFenXi,
        [Description("分析成果")]
        FenXiChengGuo,
        [Description("辅助工具")]
        FuZhuGongJu,
        [Description("其它")]
        Other,
    }
}
