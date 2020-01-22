using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("dYDAB01")] 
	public class DYDAB01Dto
	{
		private Int64 id;
		[JsonProperty("id")]
		[DataField("integer",false,true)]
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

		private String proid;
		[JsonProperty("proid")]
		[DataField("varchar(100)",false,false)]
		public String ProID
		{
			get
			{
				return proid;
			}
			set
			{
				proid = value;
			}
		}

		private String dydm;
		[JsonProperty("dydm")]
		[DataField("varchar(255)",true,false)]
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

		private String fgsmc;
		[JsonProperty("fgsmc")]
		[DataField("varchar(255)",false,false)]
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

		private String cycmc;
		[JsonProperty("cycmc")]
		[DataField("varchar(255)",false,false)]
		public String CYCMC
		{
			get
			{
				return cycmc;
			}
			set
			{
				cycmc = value;
			}
		}

		private String ytmc;
		[JsonProperty("ytmc")]
		[DataField("varchar(255)",false,false)]
		public String YTMC
		{
			get
			{
				return ytmc;
			}
			set
			{
				ytmc = value;
			}
		}

		private String dymc;
		[JsonProperty("dymc")]
		[DataField("varchar(255)",false,false)]
		public String DYMC
		{
			get
			{
				return dymc;
			}
			set
			{
				dymc = value;
			}
		}

		private Double hymj;
		[JsonProperty("hymj")]
		[DataField("float",false,false)]
		public Double HYMJ
		{
			get
			{
				return hymj;
			}
			set
			{
				hymj = value;
			}
		}

		private Double hqmj;
		[JsonProperty("hqmj")]
		[DataField("float",false,false)]
		public Double HQMJ
		{
			get
			{
				return hqmj;
			}
			set
			{
				hqmj = value;
			}
		}

		private Double yydzcl;
		[JsonProperty("yydzcl")]
		[DataField("float",false,false)]
		public Double YYDZCL
		{
			get
			{
				return yydzcl;
			}
			set
			{
				yydzcl = value;
			}
		}

		private String yykccl;
		[JsonProperty("yykccl")]
		[DataField("varchar(255)",false,false)]
		public String YYKCCL
		{
			get
			{
				return yykccl;
			}
			set
			{
				yykccl = value;
			}
		}

		private String yqclx;
		[JsonProperty("yqclx")]
		[DataField("varchar(255)",false,false)]
		public String YQCLX
		{
			get
			{
				return yqclx;
			}
			set
			{
				yqclx = value;
			}
		}

		private String qdlx;
		[JsonProperty("qdlx")]
		[DataField("varchar(255)",false,false)]
		public String QDLX
		{
			get
			{
				return qdlx;
			}
			set
			{
				qdlx = value;
			}
		}

		private String qblx;
		[JsonProperty("qblx")]
		[DataField("varchar(255)",false,false)]
		public String QBLX
		{
			get
			{
				return qblx;
			}
			set
			{
				qblx = value;
			}
		}

		private String kffs;
		[JsonProperty("kffs")]
		[DataField("varchar(255)",false,false)]
		public String KFFS
		{
			get
			{
				return kffs;
			}
			set
			{
				kffs = value;
			}
		}

		private String cllb;
		[JsonProperty("cllb")]
		[DataField("varchar(255)",false,false)]
		public String CLLB
		{
			get
			{
				return cllb;
			}
			set
			{
				cllb = value;
			}
		}

		private Int64 wzjs;
		[JsonProperty("wzjs")]
		[DataField("integer",false,false)]
		public Int64 WZJS
		{
			get
			{
				return wzjs;
			}
			set
			{
				wzjs = value;
			}
		}

		private String bz;
		[JsonProperty("bz")]
		[DataField("char",false,false)]
		public String BZ
		{
			get
			{
				return bz;
			}
			set
			{
				bz = value;
			}
		}

		private Double yymd;
		[JsonProperty("yymd")]
		[DataField("float",false,false)]
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
		[DataField("char(255)",false,false)]
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

		private String dytype;
		[JsonProperty("dytype")]
		[DataField("char(255)",false,false)]
		public String DYType
		{
			get
			{
				return dytype;
			}
			set
			{
				dytype = value;
			}
		}

		private Int64 involvedeconeval;
		[JsonProperty("involvedeconeval")]
		[DataField("integer",false,false)]
		public Int64 InvolvedEconEval
		{
			get
			{
				return involvedeconeval;
			}
			set
			{
				involvedeconeval = value;
			}
		}

		private String mainproduct;
		[JsonProperty("mainproduct")]
		[DataField("varchar(100)",false,false)]
		public String MainProduct
		{
			get
			{
				return mainproduct;
			}
			set
			{
				mainproduct = value;
			}
		}

		private Double qdzcl;
		[JsonProperty("qdzcl")]
		[DataField("float",false,false)]
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

		private Int64 ishcdy;
		[JsonProperty("ishcdy")]
		[DataField("integer",false,false)]
		public Int64 ISHCDY
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
		[JsonProperty("hclx")]
		[DataField("integer",false,false)]
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
		[DataField("text",false,false)]
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
