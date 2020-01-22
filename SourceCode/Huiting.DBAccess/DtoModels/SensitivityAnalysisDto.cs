using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("sensitivityAnalysis")] 
	public class SensitivityAnalysisDto
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

		private Decimal stepvalue;
		[JsonProperty("stepvalue")]
		[DataField("decimal",false,false)]
		public Decimal StepValue
		{
			get
			{
				return stepvalue;
			}
			set
			{
				stepvalue = value;
			}
		}

		private Byte[] result;
		[JsonProperty("result")]
		[DataField("blob",false,false)]
		public Byte[] Result
		{
			get
			{
				return result;
			}
			set
			{
				result = value;
			}
		}

		private Int32 itemtype;
		[JsonProperty("itemtype")]
		[DataField("int",false,true)]
		public Int32 ItemType
		{
			get
			{
				return itemtype;
			}
			set
			{
				itemtype = value;
			}
		}

	}
}
