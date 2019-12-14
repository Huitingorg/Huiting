using Huiting.DBAccess.Attributes;
using Newtonsoft.Json;
using System;

namespace XYY.Windows.SAAS.Contract.Dtos
{
    [DataTable("dYDAB01")] 
	public class UnitBasicDataDto
	{
		private Int64 id;
		[JsonProperty("id")]
		[DataField("integer",true,true)]
		public Int64 Id
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

		private String proID;
		[JsonProperty("proID")]
		[DataField("varchar(100)",true,false)]
		public String ProID
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

		private String dYDM;
		[JsonProperty("dYDM")]
		[DataField("varchar(255)",false,false)]
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

		private String fGSMC;
		[JsonProperty("fGSMC")]
		[DataField("varchar(255)",true,false)]
		public String FGSMC
		{
			get
			{
				return fGSMC;
			}
			set
			{
				fGSMC = value;
			}
		}

		private String cYCMC;
		[JsonProperty("cYCMC")]
		[DataField("varchar(255)",true,false)]
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
		[JsonProperty("yTMC")]
		[DataField("varchar(255)",true,false)]
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
		[JsonProperty("dYMC")]
		[DataField("varchar(255)",true,false)]
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
		[JsonProperty("hYMJ")]
		[DataField("float",true,false)]
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
		[JsonProperty("hQMJ")]
		[DataField("float",true,false)]
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
		[JsonProperty("yYDZCL")]
		[DataField("float",true,false)]
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
		[JsonProperty("yYKCCL")]
		[DataField("varchar(255)",true,false)]
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
		[JsonProperty("yQCLX")]
		[DataField("varchar(255)",true,false)]
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
		[JsonProperty("qDLX")]
		[DataField("varchar(255)",true,false)]
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
		[JsonProperty("qBLX")]
		[DataField("varchar(255)",true,false)]
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
		[JsonProperty("kFFS")]
		[DataField("varchar(255)",true,false)]
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
		[JsonProperty("cLLB")]
		[DataField("varchar(255)",true,false)]
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
		[JsonProperty("wZJS")]
		[DataField("integer",true,false)]
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
		[DataField("char",true,false)]
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
		[DataField("float",true,false)]
		public Double Yymd
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
		[DataField("char(255)",true,false)]
		public String Kfzt
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

		private String dYType;
		[JsonProperty("dYType")]
		[DataField("char(255)",true,false)]
		public String DYType
		{
			get
			{
				return dYType;
			}
			set
			{
				dYType = value;
			}
		}

		private Int64 involvedEconEval;
		[JsonProperty("involvedEconEval")]
		[DataField("integer",true,false)]
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
		[DataField("varchar(100)",true,false)]
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

		private Double qDZCL;
		[JsonProperty("qDZCL")]
		[DataField("float",true,false)]
		public Double QDZCL
		{
			get
			{
				return qDZCL;
			}
			set
			{
				qDZCL = value;
			}
		}

		private Int64 iSHCDY;
		[JsonProperty("iSHCDY")]
		[DataField("integer",true,false)]
		public Int64 ISHCDY
		{
			get
			{
				return iSHCDY;
			}
			set
			{
				iSHCDY = value;
			}
		}

		private Int64 hCLX;
		[JsonProperty("hCLX")]
		[DataField("integer",true,false)]
		public Int64 HCLX
		{
			get
			{
				return hCLX;
			}
			set
			{
				hCLX = value;
			}
		}

		private String hccondition;
		[JsonProperty("hccondition")]
		[DataField("text",true,false)]
		public String Hccondition
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
