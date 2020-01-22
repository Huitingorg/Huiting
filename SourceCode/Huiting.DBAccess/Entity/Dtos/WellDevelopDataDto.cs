using Huiting.DBAccess.Attributes;
using Huiting.DBAccess.Entity;
using Newtonsoft.Json;
using System;

namespace Huiting.DBAccess.Entity.Dtos
{
    [DataTable("WellDevelopData")]
    public class WellDevelopDataDto : IDto
    {
        private long id;
        [JsonProperty("id")]
        [DataField("integer", false, true,true)]
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

        private String ny;
        [BusinessKey]
        [JsonProperty("ny")]
        [DisplayField("年月", "yyyyMM")]
        [DataField("varchar", true, false)]
        public String NY
        {
            get
            {
                return ny;
            }
            set
            {
                ny = value;
            }
        }

        private String jh;
        [BusinessKey]
        [JsonProperty("jh")]
        [DisplayField("井号")]
        [DataField("varchar", true, false)]
        public String JH
        {
            get
            {
                return jh;
            }
            set
            {
                jh = value;
            }
        }

        private String dydm;
        [BusinessKey]
        [JsonProperty("dydm")]
        [DisplayField("单元代码")]
        [DataField("char(50)", false, false)]
        public String DYDM
        {
            get
            {
                return dydm;
            }
            set
            {
                dydm = value;
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

        private double yCYL;
        [JsonProperty("ycyl")]
        [DisplayField("月产油量", "月产油", "吨")]
        [DataField("int", true, false)]
        public double YCYL
        {
            get
            {
                return yCYL;
            }
            set
            {
                yCYL = value;
            }
        }

        private double yCQL;
        [JsonProperty("ycql")]
        [DisplayField("月产气量", "月产气", "万方")]
        [DataField("varchar", true, false)]
        public double YCQL
        {
            get
            {
                return yCQL;
            }
            set
            {
                yCQL = value;
            }
        }

        private double yCSL;
        [JsonProperty("ycsl")]
        [DisplayField("月产水量", "月产水", "吨")]
        [DataField("int", true, false)]
        public double YCSL
        {
            get
            {
                return yCSL;
            }
            set
            {
                yCSL = value;
            }
        }

        private double lJCYL;
        [JsonProperty("ljcyl")]
        [DisplayField("累产油量", "累产油", "万吨")]
        [DataField("float", true, false)]
        public double LJCYL
        {
            get
            {
                return lJCYL;
            }
            set
            {
                lJCYL = value;
            }
        }

        private double lJCQL;
        [JsonProperty("ljcql")]
        [DisplayField("累产气量", "累产气", "万方")]
        [DataField("float", true, false)]
        public double LJCQL
        {
            get
            {
                return lJCQL;
            }
            set
            {
                lJCQL = value;
            }
        }

        private double lJCSL;
        [JsonProperty("ljcsl")]
        [DisplayField("累产水量", "累产水", "万吨")]
        [DataField("float", true, false)]
        public double LJCSL
        {
            get
            {
                return lJCSL;
            }
            set
            {
                lJCSL = value;
            }
        }

        private double yZS;
        [JsonProperty("yzs")]
        [DisplayField("月注水量", "月注水", "万吨")]
        [DataField("float", true, false)]
        public double YZS
        {
            get
            {
                return yZS;
            }
            set
            {
                yZS = value;
            }
        }

        private double lZS;
        [JsonProperty("lzs")]
        [DisplayField("累注水量", "累注水", "万吨")]
        [DataField("float", true, false)]
        public double LZS
        {
            get
            {
                return lZS;
            }
            set
            {
                lZS = value;
            }
        }

        private String mQJB;
        [JsonProperty("mqjb")]
        [DisplayField("目前井别", "井别")]
        [DataField("varchar", true, false)]
        public String MQJB
        {
            get
            {
                return mQJB;
            }
            set
            {
                mQJB = value;
            }
        }

        private Double scts;
        [JsonProperty("scts")]
        [DisplayField("生产天数", "生产天", "天")]
        [DataField("float", true, false)]
        public Double SCTS
        {
            get
            {
                return scts;
            }
            set
            {
                scts = value;
            }
        }

        private double ty;
        [JsonProperty("ty")]
        [DisplayField("套压")]
        [DataField("float", true, false)]
        public double Ty { get => ty; set => ty = value; }


        private double dYM;
        [JsonProperty("dym")]
        [DisplayField("动液面")]
        [DataField("varchar", true, false)]
        public double DYM
        {
            get
            {
                return dYM;
            }
            set
            {
                dYM = value;
            }
        }

        private String bZ;
        [JsonProperty("bZ")]
        [DataField("varchar", true, false)]
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

    
    }
}
