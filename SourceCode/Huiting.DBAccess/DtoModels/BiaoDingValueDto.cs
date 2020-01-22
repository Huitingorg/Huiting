using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("biaoDingValue")] 
	public class BiaoDingValueDto
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
		[DataField("varchar(100)",false,true)]
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

		private String fieldcode;
		[JsonProperty("fieldcode")]
		[DataField("varchar(20)",false,true)]
		public String FieldCode
		{
			get
			{
				return fieldcode;
			}
			set
			{
				fieldcode = value;
			}
		}

		private Int32 xh;
		[JsonProperty("xh")]
		[DataField("int",false,false)]
		public Int32 Xh
		{
			get
			{
				return xh;
			}
			set
			{
				xh = value;
			}
		}

		private String fieldname;
		[JsonProperty("fieldname")]
		[DataField("varchar(100)",false,false)]
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

		private String fieldvalue;
		[JsonProperty("fieldvalue")]
		[DataField("varchar(100)",false,false)]
		public String FieldValue
		{
			get
			{
				return fieldvalue;
			}
			set
			{
				fieldvalue = value;
			}
		}

	}
}
