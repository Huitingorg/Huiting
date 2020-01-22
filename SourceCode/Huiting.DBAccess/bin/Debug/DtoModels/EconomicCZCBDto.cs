using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("economicCZCB")] 
	public class EconomicCZCBDto
	{
		private String proid;
		[JsonProperty("proid")]
		[DataField("char(36)",false,true)]
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

		private Decimal ny;
		[JsonProperty("ny")]
		[DataField("decimal",false,true)]
		public Decimal Ny
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

		private Decimal gdcb;
		[JsonProperty("gdcb")]
		[DataField("decimal",false,false)]
		public Decimal Gdcb
		{
			get
			{
				return gdcb;
			}
			set
			{
				gdcb = value;
			}
		}

		private Decimal ykbcb;
		[JsonProperty("ykbcb")]
		[DataField("decimal",false,false)]
		public Decimal YKbcb
		{
			get
			{
				return ykbcb;
			}
			set
			{
				ykbcb = value;
			}
		}

		private Decimal qkbcb;
		[JsonProperty("qkbcb")]
		[DataField("decimal",false,false)]
		public Decimal QKbcb
		{
			get
			{
				return qkbcb;
			}
			set
			{
				qkbcb = value;
			}
		}

	}
}
