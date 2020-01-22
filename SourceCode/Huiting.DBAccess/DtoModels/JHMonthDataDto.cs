using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("jHMonthData")] 
	public class JHMonthDataDto
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

		private String jh;
		[JsonProperty("jh")]
		[DataField("varchar",false,false)]
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
		[DataField("varchar",false,false)]
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
		[JsonProperty("dydm")]
		[DataField("varchar",false,false)]
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

		private Double scts;
		[JsonProperty("scts")]
		[DataField("float",false,false)]
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

		private String cyfs;
		[JsonProperty("cyfs")]
		[DataField("varchar",false,false)]
		public String CYFS
		{
			get
			{
				return cyfs;
			}
			set
			{
				cyfs = value;
			}
		}

		private String dym;
		[JsonProperty("dym")]
		[DataField("varchar",false,false)]
		public String DYM
		{
			get
			{
				return dym;
			}
			set
			{
				dym = value;
			}
		}

		private Int32 ycyl;
		[JsonProperty("ycyl")]
		[DataField("int",false,false)]
		public Int32 YCYL
		{
			get
			{
				return ycyl;
			}
			set
			{
				ycyl = value;
			}
		}

		private Int32 ycsl;
		[JsonProperty("ycsl")]
		[DataField("int",false,false)]
		public Int32 YCSL
		{
			get
			{
				return ycsl;
			}
			set
			{
				ycsl = value;
			}
		}

		private String ycql;
		[JsonProperty("ycql")]
		[DataField("varchar",false,false)]
		public String YCQL
		{
			get
			{
				return ycql;
			}
			set
			{
				ycql = value;
			}
		}

		private String ljcyl;
		[JsonProperty("ljcyl")]
		[DataField("varchar",false,false)]
		public String LJCYL
		{
			get
			{
				return ljcyl;
			}
			set
			{
				ljcyl = value;
			}
		}

		private String ljcsl;
		[JsonProperty("ljcsl")]
		[DataField("varchar",false,false)]
		public String LJCSL
		{
			get
			{
				return ljcsl;
			}
			set
			{
				ljcsl = value;
			}
		}

		private String ljcql;
		[JsonProperty("ljcql")]
		[DataField("varchar",false,false)]
		public String LJCQL
		{
			get
			{
				return ljcql;
			}
			set
			{
				ljcql = value;
			}
		}

		private String bz;
		[JsonProperty("bz")]
		[DataField("varchar",false,false)]
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

		private Int32 yzs;
		[JsonProperty("yzs")]
		[DataField("int",false,false)]
		public Int32 YZS
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

		private Int32 lzs;
		[JsonProperty("lzs")]
		[DataField("int",false,false)]
		public Int32 LZS
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

		private String mqjb;
		[JsonProperty("mqjb")]
		[DataField("varchar",false,false)]
		public String MQJB
		{
			get
			{
				return mqjb;
			}
			set
			{
				mqjb = value;
			}
		}

	}
}
