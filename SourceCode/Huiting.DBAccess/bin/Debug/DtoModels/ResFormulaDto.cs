using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("resFormula")] 
	public class ResFormulaDto
	{
		private Int64 id;
		[JsonProperty("id")]
		[DataField("integer",true,true)]
		public Int64 ID
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		private Int64 flag;
		[JsonProperty("flag")]
		[DataField("integer",true,true)]
		public Int64 Flag
		{
			get
			{
				return flag;
			}
			set
			{
				flag = value;
			}
		}

		private String title;
		[JsonProperty("title")]
		[DataField("char(255)",false,false)]
		public String Title
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
			}
		}

		private String unit;
		[JsonProperty("unit")]
		[DataField("char(255)",false,false)]
		public String Unit
		{
			get
			{
				return unit;
			}
			set
			{
				unit = value;
			}
		}

		private String fields;
		[JsonProperty("fields")]
		[DataField("char",false,false)]
		public String Fields
		{
			get
			{
				return fields;
			}
			set
			{
				fields = value;
			}
		}

		private String formulatext;
		[JsonProperty("formulatext")]
		[DataField("char",false,false)]
		public String FormulaText
		{
			get
			{
				return formulatext;
			}
			set
			{
				formulatext = value;
			}
		}

		private Boolean isuse;
		[JsonProperty("isuse")]
		[DataField("boolean",true,false)]
		public Boolean IsUse
		{
			get
			{
				return isuse;
			}
			set
			{
				isuse = value;
			}
		}

		private String inputtext;
		[JsonProperty("inputtext")]
		[DataField("char(255)",false,false)]
		public String InputText
		{
			get
			{
				return inputtext;
			}
			set
			{
				inputtext = value;
			}
		}

	}
}
