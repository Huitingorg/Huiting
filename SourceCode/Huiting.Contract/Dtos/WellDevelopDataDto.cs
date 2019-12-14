using Huiting.DBAccess.Attributes;
using Newtonsoft.Json;
using System;

namespace XYY.Windows.SAAS.Contract.Dtos
{
	[DataTable("jhMonthData")] 
	public class WellDevelopDataDto
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

		private String jh;
		[JsonProperty("jh")]
		[DataField("varchar",true,false)]
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

		private String ny;
		[JsonProperty("ny")]
		[DataField("varchar",true,false)]
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

		private String dYDM;
		[JsonProperty("dYDM")]
		[DataField("varchar",true,false)]
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

		private Double sCTS;
		[JsonProperty("sCTS")]
		[DataField("float",true,false)]
		public Double SCTS
		{
			get
			{
				return sCTS;
			}
			set
			{
				sCTS = value;
			}
		}

		private String cYFS;
		[JsonProperty("cYFS")]
		[DataField("varchar",true,false)]
		public String CYFS
		{
			get
			{
				return cYFS;
			}
			set
			{
				cYFS = value;
			}
		}

		private String dYM;
		[JsonProperty("dYM")]
		[DataField("varchar",true,false)]
		public String DYM
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

		private Int32 yCYL;
		[JsonProperty("yCYL")]
		[DataField("int",true,false)]
		public Int32 YCYL
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

		private Int32 yCSL;
		[JsonProperty("yCSL")]
		[DataField("int",true,false)]
		public Int32 YCSL
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

		private String yCQL;
		[JsonProperty("yCQL")]
		[DataField("varchar",true,false)]
		public String YCQL
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

		private String lJCYL;
		[JsonProperty("lJCYL")]
		[DataField("varchar",true,false)]
		public String LJCYL
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

		private String lJCSL;
		[JsonProperty("lJCSL")]
		[DataField("varchar",true,false)]
		public String LJCSL
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

		private String lJCQL;
		[JsonProperty("lJCQL")]
		[DataField("varchar",true,false)]
		public String LJCQL
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

		private String bZ;
		[JsonProperty("bZ")]
		[DataField("varchar",true,false)]
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

		private Int32 yZS;
		[JsonProperty("yZS")]
		[DataField("int",true,false)]
		public Int32 YZS
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

		private Int32 lZS;
		[JsonProperty("lZS")]
		[DataField("int",true,false)]
		public Int32 LZS
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
		[JsonProperty("mQJB")]
		[DataField("varchar",true,false)]
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

	}
}
