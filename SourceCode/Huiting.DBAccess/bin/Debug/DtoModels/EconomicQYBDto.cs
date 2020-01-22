using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("economicQYB")] 
	public class EconomicQYBDto
	{
		private String proid;
		[JsonProperty("proid")]
		[DataField("varchar(36)",false,true)]
		public String PROID
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
		[DataField("varchar(6)",false,true)]
		public String PJND
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
		[DataField("varchar(20)",false,true)]
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

		private Double qyb;
		[JsonProperty("qyb")]
		[DataField("float(20,10)",false,false)]
		public Double QYB
		{
			get
			{
				return qyb;
			}
			set
			{
				qyb = value;
			}
		}

		private Decimal useqyb;
		[JsonProperty("useqyb")]
		[DataField("decimal(1)",false,false)]
		public Decimal USEQYB
		{
			get
			{
				return useqyb;
			}
			set
			{
				useqyb = value;
			}
		}

		private Decimal monthscount;
		[JsonProperty("monthscount")]
		[DataField("decimal(8,4)",false,false)]
		public Decimal MONTHSCOUNT
		{
			get
			{
				return monthscount;
			}
			set
			{
				monthscount = value;
			}
		}

	}
}
