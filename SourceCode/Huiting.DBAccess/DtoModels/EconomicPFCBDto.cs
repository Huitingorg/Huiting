using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("economicPFCB")] 
	public class EconomicPFCBDto
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

		private String orgtype;
		[JsonProperty("orgtype")]
		[DataField("varchar(50)",false,true)]
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

		private String gdcbisen;
		[JsonProperty("gdcbisen")]
		[DataField("char",false,false)]
		public String GdcbIsEn
		{
			get
			{
				return gdcbisen;
			}
			set
			{
				gdcbisen = value;
			}
		}

		private Decimal ykbcb;
		[JsonProperty("ykbcb")]
		[DataField("decimal",false,false)]
		public Decimal Ykbcb
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

		private Decimal kbcbisen;
		[JsonProperty("kbcbisen")]
		[DataField("decimal",false,false)]
		public Decimal KbcbIsEn
		{
			get
			{
				return kbcbisen;
			}
			set
			{
				kbcbisen = value;
			}
		}

		private Decimal qkbcb;
		[JsonProperty("qkbcb")]
		[DataField("decimal",false,false)]
		public Decimal Qkbcb
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

		private Int64 ischecked;
		[JsonProperty("ischecked")]
		[DataField("bigint",false,false)]
		public Int64 IsChecked
		{
			get
			{
				return ischecked;
			}
			set
			{
				ischecked = value;
			}
		}

	}
}
