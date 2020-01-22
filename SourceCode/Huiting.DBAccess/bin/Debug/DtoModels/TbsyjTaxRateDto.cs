using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("tbsyjTaxRate")] 
	public class TbsyjTaxRateDto
	{
		private Double minvalue;
		[JsonProperty("minvalue")]
		[DataField("float",false,true)]
		public Double MinValue
		{
			get
			{
				return minvalue;
			}
			set
			{
				minvalue = value;
			}
		}

		private Double maxvalue;
		[JsonProperty("maxvalue")]
		[DataField("float",false,false)]
		public Double MaxValue
		{
			get
			{
				return maxvalue;
			}
			set
			{
				maxvalue = value;
			}
		}

		private Double taxrate;
		[JsonProperty("taxrate")]
		[DataField("float",false,false)]
		public Double TaxRate
		{
			get
			{
				return taxrate;
			}
			set
			{
				taxrate = value;
			}
		}

	}
}
