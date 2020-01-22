using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("gCGroupCondition")] 
	public class GCGroupConditionDto
	{
		private String gcid;
		[JsonProperty("gcid")]
		[DataField("char(36)",false,true)]
		public String GCID
		{
			get
			{
				return gcid;
			}
			set
			{
				gcid = value;
			}
		}

		private String proid;
		[JsonProperty("proid")]
		[DataField("char(36)",false,false)]
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
		[DataField("varchar(50)",false,false)]
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
		[DataField("varchar(20)",false,false)]
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

		private String startdate;
		[JsonProperty("startdate")]
		[DataField("char(6)",false,false)]
		public String StartDate
		{
			get
			{
				return startdate;
			}
			set
			{
				startdate = value;
			}
		}

		private String enddate;
		[JsonProperty("enddate")]
		[DataField("char(6)",false,false)]
		public String EndDate
		{
			get
			{
				return enddate;
			}
			set
			{
				enddate = value;
			}
		}

	}
}
