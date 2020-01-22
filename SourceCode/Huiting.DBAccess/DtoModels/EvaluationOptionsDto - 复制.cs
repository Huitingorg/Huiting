using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("evaluationOptions")] 
	public class EvaluationOptionsDto
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
		[DataField("varchar(36)",false,true)]
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
		[DataField("varchar(20)",false,true)]
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

		private String startny;
		[JsonProperty("startny")]
		[DataField("varchar(6)",false,false)]
		public String Startny
		{
			get
			{
				return startny;
			}
			set
			{
				startny = value;
			}
		}

		private String endny;
		[JsonProperty("endny")]
		[DataField("varchar(6)",false,false)]
		public String Endny
		{
			get
			{
				return endny;
			}
			set
			{
				endny = value;
			}
		}

		private Double fqcl;
		[JsonProperty("fqcl")]
		[DataField("float",false,false)]
		public Double Fqcl
		{
			get
			{
				return fqcl;
			}
			set
			{
				fqcl = value;
			}
		}

		private Int64 zxny;
		[JsonProperty("zxny")]
		[DataField("integer",false,false)]
		public Int64 Zxny
		{
			get
			{
				return zxny;
			}
			set
			{
				zxny = value;
			}
		}

		private Double nzxl;
		[JsonProperty("nzxl")]
		[DataField("float",false,false)]
		public Double Nzxl
		{
			get
			{
				return nzxl;
			}
			set
			{
				nzxl = value;
			}
		}

		private Double qfqcl;
		[JsonProperty("qfqcl")]
		[DataField("float",false,false)]
		public Double Qfqcl
		{
			get
			{
				return qfqcl;
			}
			set
			{
				qfqcl = value;
			}
		}

	}
}
