using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveCommon
{
    [Serializable]
    public enum ProductType
    {
        [Description("原油")]
        Oil,
        [Description("天然气")]
        Gas,
        [Description("其它")]
        Other,
    }

    [Serializable]
    public enum OrganizationType
    {
        [Description("根目录")]
        Root = 0,
        [Description("分公司")]
        Fgsmc,
        [Description("采油厂")]
        Cycmc,
        [Description("油田")]
        Ytmc,
        [Description("单元")]
        Dydm
    }

    [Serializable]
    public enum AttributeType
    {
        [Description("排序")]
        Sort,
        [Description("分组")]
        Group
    }

    [Serializable]
    [Description("排序类型")]
    public enum SortType
    {
        [SortAttribute("分公司")]
        FGSMC = 0,
        [SortAttribute("采油厂")]
        CYCMC = 1,
        [SortAttribute("油田")]
        YTMC,
        [SortAttribute("油气藏类型")]
        YQCLX,
        [SortAttribute("驱动类型")]
        QDLX,
        //[SortAttribute("圈闭类型")]
        //QBLX,
        [SortAttribute("开发方式")]
        KFFS,
        [SortAttribute("储量类别")]
        CLLB,
        [SortAttribute("开发状态")]
        KFZT,
        [SortAttribute("单元名称", false)]
        DYMC,
        [SortAttribute("单元代码", false)]
        DYDM,
        //[SortAttribute("其它", true)]
        //Other,
    }

    [Serializable]
    [Description("油气藏类型")]
    public enum EnumYQCLX
    {
        [Description("中高渗整装油藏")]
        ZGSZZYC = 0,
        [Description("中高渗断块油藏")]
        ZGSDKYC,
        [Description("低渗透油藏")]
        DSTYC,
        [Description("稠油油藏")]
        CYYC,
        [Description("特殊岩性油藏")]
        TSYQYC,
        [Description("海上油藏")]
        HSYC,
    }

    [Serializable]
    [Description("驱动类型")]
    public enum EnumQDLX
    {
        [Description("弹性驱动")]
        TXQD = 0,
        [Description("水压驱动")]
        SYQD,
        [Description("气压驱动")]
        QYQD,
        [Description("弹性水压驱动")]
        TXSYQD,
        [Description("重力驱动")]
        ZLQD,
        [Description("溶解气驱动")]
        RJQQD,
        [Description("综合驱动")]
        ZHQD,
        [Description("人工注水")]
        RGZS,
        [Description("蒸汽吞吐")]
        ZQTT,
        [Description("蒸汽驱")]
        ZQQ,
        [Description("火烧油层")]
        HSYC,
    }

    [Serializable]
    [Description("开发方式")]
    public enum EnumKFFS
    {
        [Description("天然能量")]
        TRNL = 0,
        [Description("注水开发")]
        ZSKF,
        [Description("热采（吞吐）")]
        RC_TT,
        [Description("热采（蒸汽驱）")]
        RC_ZQQ,
        [Description("化学驱（聚合物驱）")]
        XXQ_JHWQ,
        [Description("化学驱（二元复合驱）")]
        XXQ_EYFHQ,
        [Description("其他")]
        QT,
    }

    [Serializable]
    [Description("储量类别")]
    public enum EnumCLLB
    {
        [Description("探明储量")]
        TMCL = 0,
        [Description("控制储量")]
        CZCL,
        [Description("预测储量")]
        YCCL,
        [Description("Proved")]
        Proved,
    }

    [Serializable]
    [Description("开发状态")]
    public enum EnumKFZT
    {
        [Description("已开发")]
        Developed = 0,
        [Description("未开发")]
        Undeveloped,
    }

    //[Serializable]
    //[Description("圈闭类型")]
    //public enum EnumQBLX
    //{
    //    [Description("层状圈闭")]
    //    CZQB,
    //    [Description("块状圈闭")]
    //    KZQB,
    //    [Description("不规则圈闭")]
    //    BGZQB
    //}

    [Serializable]
    [Description("单元内容类型")]
    public enum UnitFunctionType
    {
        [BDDescription("单元基本信息")]
        JiBenXinXI,
        [BDDescription("LgWp~Np(甲)", "适用于粘度在3-30mPa.s的中粘层状油藏")]
        SQTZJia,
        [BDDescription("LgLp~Np(乙)", "适用于高粘(>30mPa.s)的层状油藏")]
        SQTZYi,
        [BDDescription("Lp/Np~Lp(丙)", "适用于粘度在3-30mPa.s的中粘层状油藏")]
        SQTZBing,
        [BDDescription("Lp/Np~Wp(丁)", "适用于低粘(<３mPa.s)的层状油藏和碳酸盐岩底水油藏")]
        SQTZDing,
        [BDDescription("拉齐分析")]
        LaQiFenXi,
        [BDDescription("产量 vs 时间")]
        DJQXChanLiangDuiShiJian,
        [BDDescription("月产 vs 累产")]
        DJQXYueChanDuiLeiChan,
        [BDDescription("含油率 vs 累产")]
        DJQXHanYouLvDuiLeiChan,
        [BDDescription("含水率 vs 累产")]
        DJQXHanShuiLvDuiLeiChan,
        [BDDescription("水油比 vs 累产")]
        DJQXShuiYouBiDuiLeiChan,
        [BDDescription("预测产量数据")]
        YuCeChaLiangShuJu,
        [BDDescription("经济评价")]
        JingJiPingJia,
        [BDDescription("敏感性分析")]
        MinGanXingFenXi,
        [BDDescription("单元开发数据")]
        DanYuanShuJu,
        [BDDescription("单井开发数据")]
        DanJingShuJu,
        //[BDDescription("可采储量分析结果")]
        //KeCaiChuLiangFenXiJieGuo,
        [BDDescription("现金流量表")]
        BaoGaoShuChu,
        [BDDescription("统计表")]
        KPMGBaoBiao,
        [BDDescription("开储表")]
        KaiChuBiao,
        [BDDescription("童宪章图版法")]
        TongXianZhangTuBanFa,
        [BDDescription("经济参数")]
        JingJiPingJiaCanShu,
        [BDDescription("经验公式")]
        JingYanGongShi,
    }

    [Serializable]
    [Description("单元内容分组")]
    public enum UnitFunctionGroupType
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

    [Serializable]
    [Description("图标类型")]
    public enum EntityType
    {
        //项目
        Project,
        //分组
        Group,
        //单元
        Unit,
        //功能
        Function
    }


    /// <summary>
    /// 研究类型
    /// </summary>
    [Serializable]
    public enum StudyType
    {
        DYFX = 0,//单元分析
        GCFX,//构成分析
        [Description("拉齐分析")]
        LQFX,//拉齐分析
        [Description("失控可采")]
        LQSK,//拉齐失控分析
        [Description("扶停分析")]
        LQFT,//拉齐扶停分析
    }


    [Serializable]
    [Description("敏感性指标类型")]
    public enum SensitivityItemType
    {
        [Description("油价")]
        YJ = 0,
        [Description("气价")]
        QJ = 1,
        [Description("初始产量")]
        CSCL,
        [Description("递减率")]
        DJL,
        //[Description("产量")]
        //CL,
        [Description("成本")]
        CB,
        //[Description("固定成本")]
        //GDCB,
        //[Description("油可变成本")]
        //YKBCB,
        //[Description("气可变成本")]
        //QKBCB,
        //[Description("投资")]
        //TZ,
    }

    [Serializable]
    [Description("敏感性结果类型")]
    public enum SensitivityResultType
    {
        [Description("油剩余可采储量(千桶)")]
        YSykcclEN,
        [Description("气剩余可采储量(千立方)")]
        QSykcclEN,
        [Description("剩余可采价值(千美元)")]
        SykcclJZEN,
        [Description("油剩余可采储量(万吨)")]
        YSykcclCN,
        [Description("气剩余可采储量(万方)")]
        QSykcclCN,
        [Description("剩余可采价值(万元)")]
        SykcclJZCN
    }
}