using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("econParams")] 
	public class EconParamsDto
	{
		private String proid;
		[JsonProperty("proid")]
		[DataField("varchar",false,true)]
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

		private String ny;
		[JsonProperty("ny")]
		[DataField("varchar",false,true)]
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

		private Int64 inherittype;
		[JsonProperty("inherittype")]
		[DataField("bigint",false,false)]
		public Int64 InheritType
		{
			get
			{
				return inherittype;
			}
			set
			{
				inherittype = value;
			}
		}

		private Double paramvalue;
		[JsonProperty("paramvalue")]
		[DataField("float",false,false)]
		public Double Paramvalue
		{
			get
			{
				return paramvalue;
			}
			set
			{
				paramvalue = value;
			}
		}

	}
}
