using Huiting.DBAccess.Attributes;
using Newtonsoft.Json;
using System;

namespace XYY.Windows.SAAS.Contract.Dtos
{
	[DataTable("dYMonthData")] 
	public class UnitDevelopDataDto
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

		private String dYDM;
		[JsonProperty("dYDM")]
		[DataField("char(50)",false,false)]
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

		private String nY;
		[JsonProperty("nY")]
		[DataField("char(50)",false,false)]
		public String NY
		{
			get
			{
				return nY;
			}
			set
			{
				nY = value;
			}
		}

		private Double yCY;
		[JsonProperty("yCY")]
		[DataField("float",true,false)]
		public Double YCY
		{
			get
			{
				return yCY;
			}
			set
			{
				yCY = value;
			}
		}

		private Double yCQ;
		[JsonProperty("yCQ")]
		[DataField("float",true,false)]
		public Double YCQ
		{
			get
			{
				return yCQ;
			}
			set
			{
				yCQ = value;
			}
		}

		private Double yCS;
		[JsonProperty("yCS")]
		[DataField("float",true,false)]
		public Double YCS
		{
			get
			{
				return yCS;
			}
			set
			{
				yCS = value;
			}
		}

		private Double yZS;
		[JsonProperty("yZS")]
		[DataField("float",true,false)]
		public Double YZS
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

		private Double lCY;
		[JsonProperty("lCY")]
		[DataField("float",true,false)]
		public Double LCY
		{
			get
			{
				return lCY;
			}
			set
			{
				lCY = value;
			}
		}

		private Double lCQ;
		[JsonProperty("lCQ")]
		[DataField("float",true,false)]
		public Double LCQ
		{
			get
			{
				return lCQ;
			}
			set
			{
				lCQ = value;
			}
		}

		private Double lCS;
		[JsonProperty("lCS")]
		[DataField("float",true,false)]
		public Double LCS
		{
			get
			{
				return lCS;
			}
			set
			{
				lCS = value;
			}
		}

		private Double lZS;
		[JsonProperty("lZS")]
		[DataField("float",true,false)]
		public Double LZS
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

		private Double zYJS;
		[JsonProperty("zYJS")]
		[DataField("float",true,false)]
		public Double ZYJS
		{
			get
			{
				return zYJS;
			}
			set
			{
				zYJS = value;
			}
		}

		private Double kYJS;
		[JsonProperty("kYJS")]
		[DataField("float",true,false)]
		public Double KYJS
		{
			get
			{
				return kYJS;
			}
			set
			{
				kYJS = value;
			}
		}

		private Double zSJS;
		[JsonProperty("zSJS")]
		[DataField("float",true,false)]
		public Double ZSJS
		{
			get
			{
				return zSJS;
			}
			set
			{
				zSJS = value;
			}
		}

		private Double kSJS;
		[JsonProperty("kSJS")]
		[DataField("float",true,false)]
		public Double KSJS
		{
			get
			{
				return kSJS;
			}
			set
			{
				kSJS = value;
			}
		}

	}
}
