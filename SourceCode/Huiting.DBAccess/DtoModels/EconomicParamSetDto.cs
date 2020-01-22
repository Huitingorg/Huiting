using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("economicParamSet")] 
	public class EconomicParamSetDto
	{
		private String proid;
		[JsonProperty("proid")]
		[DataField("varchar(36)",false,true)]
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

		private String paramname;
		[JsonProperty("paramname")]
		[DataField("varchar",false,true)]
		public String ParamName
		{
			get
			{
				return paramname;
			}
			set
			{
				paramname = value;
			}
		}

	}
}
