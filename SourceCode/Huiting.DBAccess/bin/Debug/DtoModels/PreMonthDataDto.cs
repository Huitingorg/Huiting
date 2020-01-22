using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("preMonthData")] 
	public class PreMonthDataDto
	{
		private String prelineid;
		[JsonProperty("prelineid")]
		[DataField("varchar(36)",false,true)]
		public String PrelineID
		{
			get
			{
				return prelineid;
			}
			set
			{
				prelineid = value;
			}
		}

		private String ny;
		[JsonProperty("ny")]
		[DataField("varchar(6)",false,true)]
		public String NY
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

		private Double ycvalue;
		[JsonProperty("ycvalue")]
		[DataField("real",false,false)]
		public Double YCValue
		{
			get
			{
				return ycvalue;
			}
			set
			{
				ycvalue = value;
			}
		}

	}
}
