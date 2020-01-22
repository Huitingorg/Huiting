using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("vertAxisState")] 
	public class VertAxisStateDto
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

		private String dydm;
		[JsonProperty("dydm")]
		[DataField("varchar",false,true)]
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

		private String studytype;
		[JsonProperty("studytype")]
		[DataField("varchar",false,true)]
		public String StudyType
		{
			get
			{
				return studytype;
			}
			set
			{
				studytype = value;
			}
		}

		private String fieldname;
		[JsonProperty("fieldname")]
		[DataField("varchar",false,true)]
		public String FieldName
		{
			get
			{
				return fieldname;
			}
			set
			{
				fieldname = value;
			}
		}

		private Int32 log10min;
		[JsonProperty("log10min")]
		[DataField("int",false,false)]
		public Int32 Log10Min
		{
			get
			{
				return log10min;
			}
			set
			{
				log10min = value;
			}
		}

		private Int32 loginterval;
		[JsonProperty("loginterval")]
		[DataField("int",false,false)]
		public Int32 LogInterval
		{
			get
			{
				return loginterval;
			}
			set
			{
				loginterval = value;
			}
		}

		private Double linemin;
		[JsonProperty("linemin")]
		[DataField("float",false,false)]
		public Double LineMin
		{
			get
			{
				return linemin;
			}
			set
			{
				linemin = value;
			}
		}

		private Double linemax;
		[JsonProperty("linemax")]
		[DataField("float",false,false)]
		public Double LineMax
		{
			get
			{
				return linemax;
			}
			set
			{
				linemax = value;
			}
		}

		private Double lineinterval;
		[JsonProperty("lineinterval")]
		[DataField("float",false,false)]
		public Double LineInterval
		{
			get
			{
				return lineinterval;
			}
			set
			{
				lineinterval = value;
			}
		}

	}
}
