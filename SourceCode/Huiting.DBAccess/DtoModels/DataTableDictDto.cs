using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("dataTableDict")] 
	public class DataTableDictDto
	{
		private String tabcode;
		[JsonProperty("tabcode")]
		[DataField("char(255)",true,true)]
		public String TabCode
		{
			get
			{
				return tabcode;
			}
			set
			{
				tabcode = value;
			}
		}

		private String fldcode;
		[JsonProperty("fldcode")]
		[DataField("char(255)",true,true)]
		public String FldCode
		{
			get
			{
				return fldcode;
			}
			set
			{
				fldcode = value;
			}
		}

		private String fldname;
		[JsonProperty("fldname")]
		[DataField("char(255)",false,false)]
		public String FldName
		{
			get
			{
				return fldname;
			}
			set
			{
				fldname = value;
			}
		}

		private String fldtype;
		[JsonProperty("fldtype")]
		[DataField("char(255)",false,false)]
		public String FldType
		{
			get
			{
				return fldtype;
			}
			set
			{
				fldtype = value;
			}
		}

		private Int64 num;
		[JsonProperty("num")]
		[DataField("integer",false,false)]
		public Int64 Num
		{
			get
			{
				return num;
			}
			set
			{
				num = value;
			}
		}

	}
}
