using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("waterDriveResult")] 
	public class WaterDriveResultDto
	{
		private String proid;
		[JsonProperty("proid")]
		[DataField("varchar",false,true)]
		public String Proid
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

		private String watertype;
		[JsonProperty("watertype")]
		[DataField("varchar",false,true)]
		public String WaterType
		{
			get
			{
				return watertype;
			}
			set
			{
				watertype = value;
			}
		}

		private Byte[] chartdata;
		[JsonProperty("chartdata")]
		[DataField("blob",false,false)]
		public Byte[] ChartData
		{
			get
			{
				return chartdata;
			}
			set
			{
				chartdata = value;
			}
		}

		private Byte[] fititems;
		[JsonProperty("fititems")]
		[DataField("blob",false,false)]
		public Byte[] FitItems
		{
			get
			{
				return fititems;
			}
			set
			{
				fititems = value;
			}
		}

	}
}
