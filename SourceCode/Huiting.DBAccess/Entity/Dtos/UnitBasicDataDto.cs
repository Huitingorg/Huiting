using Huiting.DBAccess.Attributes;
using Huiting.DBAccess.Entity;
using Newtonsoft.Json;
using System;

namespace Huiting.DBAccess.Entity.Dtos
{
    [DataTable("UnitBasicData")]
    public class UnitBasicDataDto : IDto
    {
        private long id;
        [JsonProperty("id")]
        [DataField("integer", false, true, true)]
        public long Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private String dYDM;
        [JsonProperty("dydm")]
        [BusinessKey]
        [DisplayField("单元代码", "代码")]
        [DataField("varchar(255)", false, false)]
        public String DYDM
        {
            get
            {
                return dYDM;
            }
            set
            {
                dYDM = value;
            }
        }

        private long proID;
        [BusinessKey]
        [JsonProperty("proid")]
        [DataField("integer", false, false)]
        public long ProID
        {
            get
            {
                return proID;
            }
            set
            {
                proID = value;
            }
        }
               
        private String fgsmc;
        [JsonProperty("fgsmc")]
        [DisplayField("分公司名称", "公司名,companyName,公司,company")]
        [DataField("varchar(255)", true)]
        public String FGSMC
        {
            get
            {
                return fgsmc;
            }
            set
            {
                fgsmc = value;
            }
        }

        private String cYCMC;
        [JsonProperty("cycmc")]
        [DisplayField("采油厂名称", "factory,采油厂,厂名称,厂名,厂")]
        [DataField("varchar(255)", true)]
        public String CYCMC
        {
            get
            {
                return cYCMC;
            }
            set
            {
                cYCMC = value;
            }
        }

        private String yTMC;
        [JsonProperty("ytmc")]
        [DisplayField("油田名称", "油田名称,油田")]
        [DataField("varchar(255)", false)]
        public String YTMC
        {
            get
            {
                return yTMC;
            }
            set
            {
                yTMC = value;
            }
        }

        private String dYMC;
        [JsonProperty("dymc")]
        [DisplayField("单元名称", "单元名称,单元")]
        [DataField("varchar(255)", false)]
        public String DYMC
        {
            get
            {
                return dYMC;
            }
            set
            {
                dYMC = value;
            }
        }

        private Double hYMJ;
        [JsonProperty("hymj")]
        [DisplayField("含油面积")]
        [DataField("float")]
        public Double HYMJ
        {
            get
            {
                return hYMJ;
            }
            set
            {
                hYMJ = value;
            }
        }

        private Double hQMJ;
        [JsonProperty("hqmj")]
        [DisplayField("含气面积")]
        [DataField("float")]
        public Double HQMJ
        {
            get
            {
                return hQMJ;
            }
            set
            {
                hQMJ = value;
            }
        }

        private Double yYDZCL;
        [JsonProperty("yydzcl")]
        [DisplayField("原油地质储量", "油地质储量", "万吨")]
        [DataField("float")]
        public Double YYDZCL
        {
            get
            {
                return yYDZCL;
            }
            set
            {
                yYDZCL = value;
            }
        }

        private String yYKCCL;
        [JsonProperty("yykccl")]
        [DisplayField("原油可采储量", "油可采储量", "万吨")]
        [DataField("varchar(255)")]
        public String YYKCCL
        {
            get
            {
                return yYKCCL;
            }
            set
            {
                yYKCCL = value;
            }
        }

        private String yQCLX;
        [JsonProperty("yqclx")]
        [DisplayField("油气藏类型", "油气藏")]
        [DataField("varchar(255)")]
        public String YQCLX
        {
            get
            {
                return yQCLX;
            }
            set
            {
                yQCLX = value;
            }
        }

        private String qDLX;
        [JsonProperty("qdlx")]
        [DisplayField("驱动类型", "驱动")]
        [DataField("varchar(255)")]
        public String QDLX
        {
            get
            {
                return qDLX;
            }
            set
            {
                qDLX = value;
            }
        }

        private String qBLX;
        [JsonProperty("qblx")]
        [DisplayField("圈闭类型", "圈闭")]
        [DataField("varchar(255)")]
        public String QBLX
        {
            get
            {
                return qBLX;
            }
            set
            {
                qBLX = value;
            }
        }

        private String kFFS;
        [JsonProperty("kffs")]
        [DisplayField("开发方式", "开发")]
        [DataField("varchar(255)")]
        public String KFFS
        {
            get
            {
                return kFFS;
            }
            set
            {
                kFFS = value;
            }
        }

        private String cLLB;
        [JsonProperty("cllb")]
        [DisplayField("储量类别")]
        [DataField("varchar(255)")]
        public String CLLB
        {
            get
            {
                return cLLB;
            }
            set
            {
                cLLB = value;
            }
        }

        private Int64 wZJS;
        [JsonProperty("wzjs")]
        [DisplayField("完钻井数", "完钻井")]
        [DataField("integer")]
        public Int64 WZJS
        {
            get
            {
                return wZJS;
            }
            set
            {
                wZJS = value;
            }
        }

        private String bZ;
        [JsonProperty("bZ")]
        [DisplayField("备注")]
        [DataField("char(255)")]
        public String BZ
        {
            get
            {
                return bZ;
            }
            set
            {
                bZ = value;
            }
        }

        private Double yymd;
        [JsonProperty("yymd")]
        [DisplayField("原油密度", "油密度,密度")]
        [DataField("float")]
        public Double YYMD
        {
            get
            {
                return yymd;
            }
            set
            {
                yymd = value;
            }
        }

        private String kfzt;
        [JsonProperty("kfzt")]
        [DisplayField("开发状态")]
        [DataField("char(255)")]
        public String KFZT
        {
            get
            {
                return kfzt;
            }
            set
            {
                kfzt = value;
            }
        }

        private String dyType;
        [JsonProperty("dytype")]
        [DisplayField("单元类型")]
        [DataField("char(255)")]
        public String DYType
        {
            get
            {
                return dyType;
            }
            set
            {
                dyType = value;
            }
        }

        private Int64 involvedEconEval;
        [JsonProperty("involvedEconEval")]
        [DisplayField("参与经济评价")]
        [DataField("integer")]
        public Int64 InvolvedEconEval
        {
            get
            {
                return involvedEconEval;
            }
            set
            {
                involvedEconEval = value;
            }
        }

        private String mainProduct;
        [JsonProperty("mainProduct")]
        [DisplayField("主产品项", "主要产品")]
        [DataField("varchar(100)")]
        public String MainProduct
        {
            get
            {
                return mainProduct;
            }
            set
            {
                mainProduct = value;
            }
        }

        private Double qdzcl;
        [JsonProperty("qDZCL")]
        [DisplayField("气地质储量", "气地质", "万方")]
        [DataField("float")]
        public Double QDZCL
        {
            get
            {
                return qdzcl;
            }
            set
            {
                qdzcl = value;
            }
        }

        private String qKCCL;
        [JsonProperty("yykccl")]
        [DisplayField("气可采储量", "气可采", "万方")]
        [DataField("varchar(255)")]
        public String QKCCL
        {
            get
            {
                return qKCCL;
            }
            set
            {
                qKCCL = value;
            }
        }

        private Int64 ishcdy;
        [JsonProperty("iSHCDY")]
        [DisplayField("是否合成单元")]
        [DataField("integer")]
        public Int64 IsHCDY
        {
            get
            {
                return ishcdy;
            }
            set
            {
                ishcdy = value;
            }
        }

        private Int64 hclx;
        [JsonProperty("hCLX")]
        [DisplayField("合成类型")]
        [DataField("integer")]
        public Int64 HCLX
        {
            get
            {
                return hclx;
            }
            set
            {
                hclx = value;
            }
        }

        private String hccondition;
        [JsonProperty("hccondition")]
        [DisplayField("合成条件")]
        [DataField("text")]
        public String HCCondition
        {
            get
            {
                return hccondition;
            }
            set
            {
                hccondition = value;
            }
        }

    }
}
