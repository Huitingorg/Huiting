using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("economicTZ")] 
	public class EconomicTZDto
	{
		private String proid;
		[JsonProperty("proid")]
		[DataField("char(36)",false,true)]
		public String Proid
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
		[DataField("varchar(50)",false,true)]
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

		private String dydm;
		[JsonProperty("dydm")]
		[DataField("varchar(50)",false,true)]
		public String Dydm
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
		[DataField("char(6)",false,true)]
		public String Ny
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

		private Int64 isen;
		[JsonProperty("isen")]
		[DataField("bigint",false,false)]
		public Int64 IsEN
		{
			get
			{
				return isen;
			}
			set
			{
				isen = value;
			}
		}

	}
}
