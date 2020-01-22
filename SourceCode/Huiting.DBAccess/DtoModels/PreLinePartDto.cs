using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("preLinePart")] 
	public class PreLinePartDto
	{
		private String prelineid;
		[JsonProperty("prelineid")]
		[DataField("char(36)",false,true)]
		public String PreLineID
		{
			get
			{
				return prelineid;
			}
			set
			{
				prelineid = value;
			}
		}

		private Int32 xh;
		[JsonProperty("xh")]
		[DataField("int",false,true)]
		public Int32 XH
		{
			get
			{
				return xh;
			}
			set
			{
				xh = value;
			}
		}

		private String qxlx;
		[JsonProperty("qxlx")]
		[DataField("varchar(50)",false,false)]
		public String QXLX
		{
			get
			{
				return qxlx;
			}
			set
			{
				qxlx = value;
			}
		}

		private Decimal sqzs;
		[JsonProperty("sqzs")]
		[DataField("decimal",false,false)]
		public Decimal SQZS
		{
			get
			{
				return sqzs;
			}
			set
			{
				sqzs = value;
			}
		}

		private Decimal csdjl;
		[JsonProperty("csdjl")]
		[DataField("decimal",false,false)]
		public Decimal CSDJL
		{
			get
			{
				return csdjl;
			}
			set
			{
				csdjl = value;
			}
		}

		private String csrq;
		[JsonProperty("csrq")]
		[DataField("varchar(20)",false,false)]
		public String CSRQ
		{
			get
			{
				return csrq;
			}
			set
			{
				csrq = value;
			}
		}

		private Decimal cscl;
		[JsonProperty("cscl")]
		[DataField("decimal",false,false)]
		public Decimal CSCL
		{
			get
			{
				return cscl;
			}
			set
			{
				cscl = value;
			}
		}

		private Decimal jscl;
		[JsonProperty("jscl")]
		[DataField("decimal",false,false)]
		public Decimal JSCL
		{
			get
			{
				return jscl;
			}
			set
			{
				jscl = value;
			}
		}

		private String jsrq;
		[JsonProperty("jsrq")]
		[DataField("varchar(20)",false,false)]
		public String JSRQ
		{
			get
			{
				return jsrq;
			}
			set
			{
				jsrq = value;
			}
		}

		private Decimal ljl;
		[JsonProperty("ljl")]
		[DataField("decimal",false,false)]
		public Decimal LJL
		{
			get
			{
				return ljl;
			}
			set
			{
				ljl = value;
			}
		}

		private Decimal zdpgrzqcl;
		[JsonProperty("zdpgrzqcl")]
		[DataField("decimal",false,false)]
		public Decimal ZDPGRZQCL
		{
			get
			{
				return zdpgrzqcl;
			}
			set
			{
				zdpgrzqcl = value;
			}
		}

		private Decimal zzkccl;
		[JsonProperty("zzkccl")]
		[DataField("decimal",false,false)]
		public Decimal ZZKCCL
		{
			get
			{
				return zzkccl;
			}
			set
			{
				zzkccl = value;
			}
		}

	}
}
