using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("dYMonthData")] 
	public class DYMonthDataDto
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

		private String dydm;
		[JsonProperty("dydm")]
		[DataField("char(50)",true,false)]
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

		private String ny;
		[JsonProperty("ny")]
		[DataField("char(50)",true,false)]
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

		private Double ycy;
		[JsonProperty("ycy")]
		[DataField("float",false,false)]
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
		[DataField("float",false,false)]
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
		[JsonProperty("ycs")]
		[DataField("float",false,false)]
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
		[JsonProperty("yzs")]
		[DataField("float",false,false)]
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
		[DataField("float",false,false)]
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
		[JsonProperty("lcq")]
		[DataField("float",false,false)]
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
		[DataField("float",false,false)]
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
		[DataField("float",false,false)]
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
		[DataField("float",false,false)]
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
		[DataField("float",false,false)]
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
		[DataField("float",false,false)]
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
		[JsonProperty("ksjs")]
		[DataField("float",false,false)]
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
