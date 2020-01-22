using Huiting.DBAccess.Attributes;
using Huiting.DBAccess.Entity;
using Newtonsoft.Json;
using System;

namespace Huiting.DBAccess.Entity.Dtos
{
    [DataTable("UnitDevelopData")] 
	public class UnitDevelopDataDto : IDto
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

        private String ny;
        [JsonProperty("ny")]
        [DisplayField("年月", "yyyyMM")]
        [DataField("char(50)", false, false)]
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

        private String dydm;
        [BusinessKey]
        [JsonProperty("dydm")]
        [DisplayField("单元代码", "代码")]
        [DataField("char(50)",false,false)]
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

        private String dYMC;
        [JsonProperty("dymc")]
        [DisplayField("单元名称","名称")]
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

        private Double ycy;
		[JsonProperty("ycy")]
        [DisplayField("月产油量", "月产油", "万吨")]
        [DataField("float",true,false)]
		public Double YCY
		{
			get
			{
				return ycy;
			}
			set
			{
				ycy = value;
			}
		}

		private Double ycq;
		[JsonProperty("ycq")]
        [DisplayField("月产气量", "月产气", "万方")]
        [DataField("float",true,false)]
		public Double YCQ
		{
			get
			{
				return ycq;
			}
			set
			{
				ycq = value;
			}
		}

		private Double ycs;
		[JsonProperty("yCS")]
        [DisplayField("月产水量", "月产水", "万吨")]
        [DataField("float",true,false)]
		public Double YCS
		{
			get
			{
				return ycs;
			}
			set
			{
				ycs = value;
			}
		}

		private Double yzs;
		[JsonProperty("yZS")]
        [DisplayField("月注水量", "月注水", "万吨")]
        [DataField("float",true,false)]
		public Double YZS
		{
			get
			{
				return yzs;
			}
			set
			{
				yzs = value;
			}
		}

		private Double lcy;
		[JsonProperty("lcy")]
        [DisplayField("累采油量", "累采油", "万吨")]
        [DataField("float",true,false)]
		public Double LCY
		{
			get
			{
				return lcy;
			}
			set
			{
				lcy = value;
			}
		}

		private Double lcq;
		[JsonProperty("lCQ")]
        [DisplayField("累产气量", "累产气", "万方")]
        [DataField("float",true,false)]
		public Double LCQ
		{
			get
			{
				return lcq;
			}
			set
			{
				lcq = value;
			}
		}

		private Double lcs;
		[JsonProperty("lcs")]
        [DisplayField("累产水量", "累产水", "万吨")]
        [DataField("float",true,false)]
		public Double LCS
		{
			get
			{
				return lcs;
			}
			set
			{
				lcs = value;
			}
		}

		private Double lzs;
		[JsonProperty("lzs")]
        [DisplayField("累注水量", "累注水", "万吨")]
        [DataField("float",true,false)]
		public Double LZS
		{
			get
			{
				return lzs;
			}
			set
			{
				lzs = value;
			}
		}

		private Double zyjs;
		[JsonProperty("zyjs")]
        [DisplayField("钻井数", "钻井数量", "口")]
        [DataField("float",true,false)]
		public Double ZYJS
		{
			get
			{
				return zyjs;
			}
			set
			{
				zyjs = value;
			}
		}

		private Double kyjs;
		[JsonProperty("kyjs")]
        [DisplayField("开井数", "开井数量", "口")]
        [DataField("float",true,false)]
		public Double KYJS
		{
			get
			{
				return kyjs;
			}
			set
			{
				kyjs = value;
			}
		}

		private Double zsjs;
		[JsonProperty("zsjs")]
        [DisplayField("钻水井数", "钻水井数量", "口")]
        [DataField("float", true,false)]
		public Double ZSJS
		{
			get
			{
				return zsjs;
			}
			set
			{
				zsjs = value;
			}
		}

		private Double ksjs;
		[JsonProperty("kSJS")]
        [DisplayField("开水井数", "开水井数量", "口")]
        [DataField("float", true,false)]
		public Double KSJS
		{
			get
			{
				return ksjs;
			}
			set
			{
				ksjs = value;
			}
		}

	}
}
