using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("economicParams")] 
	public class EconomicParamsDto
	{
		private String proid;
		[JsonProperty("proid")]
		[DataField("varchar(36)",false,true)]
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

		private String pjnd;
		[JsonProperty("pjnd")]
		[DataField("varchar",false,true)]
		public String Pjnd
		{
			get
			{
				return pjnd;
			}
			set
			{
				pjnd = value;
			}
		}

		private String orgtype;
		[JsonProperty("orgtype")]
		[DataField("varchar",false,true)]
		public String OrgType
		{
			get
			{
				return orgtype;
			}
			set
			{
				orgtype = value;
			}
		}

		private String orgvalue;
		[JsonProperty("orgvalue")]
		[DataField("varchar",false,true)]
		public String OrgValue
		{
			get
			{
				return orgvalue;
			}
			set
			{
				orgvalue = value;
			}
		}

		private Int32 ny;
		[JsonProperty("ny")]
		[DataField("int",false,true)]
		public Int32 NY
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

		private Decimal yj;
		[JsonProperty("yj")]
		[DataField("decimal",false,false)]
		public Decimal Yj
		{
			get
			{
				return yj;
			}
			set
			{
				yj = value;
			}
		}

		private Decimal qj;
		[JsonProperty("qj")]
		[DataField("decimal",false,false)]
		public Decimal Qj
		{
			get
			{
				return qj;
			}
			set
			{
				qj = value;
			}
		}

		private Decimal yzzsl;
		[JsonProperty("yzzsl")]
		[DataField("decimal",false,false)]
		public Decimal Yzzsl
		{
			get
			{
				return yzzsl;
			}
			set
			{
				yzzsl = value;
			}
		}

		private Decimal qzzsl;
		[JsonProperty("qzzsl")]
		[DataField("decimal",false,false)]
		public Decimal Qzzsl
		{
			get
			{
				return qzzsl;
			}
			set
			{
				qzzsl = value;
			}
		}

		private Decimal tbsyj;
		[JsonProperty("tbsyj")]
		[DataField("decimal",false,false)]
		public Decimal Tbsyj
		{
			get
			{
				return tbsyj;
			}
			set
			{
				tbsyj = value;
			}
		}

		private Decimal zysl;
		[JsonProperty("zysl")]
		[DataField("decimal",false,false)]
		public Decimal Zysl
		{
			get
			{
				return zysl;
			}
			set
			{
				zysl = value;
			}
		}

		private Decimal qtsl;
		[JsonProperty("qtsl")]
		[DataField("decimal",false,false)]
		public Decimal Qtsl
		{
			get
			{
				return qtsl;
			}
			set
			{
				qtsl = value;
			}
		}

		private Decimal hl;
		[JsonProperty("hl")]
		[DataField("decimal",false,false)]
		public Decimal Hl
		{
			get
			{
				return hl;
			}
			set
			{
				hl = value;
			}
		}

		private Decimal tz;
		[JsonProperty("tz")]
		[DataField("decimal",false,false)]
		public Decimal Tz
		{
			get
			{
				return tz;
			}
			set
			{
				tz = value;
			}
		}

		private Decimal qzysl;
		[JsonProperty("qzysl")]
		[DataField("decimal",false,false)]
		public Decimal Qzysl
		{
			get
			{
				return qzysl;
			}
			set
			{
				qzysl = value;
			}
		}

	}
}
