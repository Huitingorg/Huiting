using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("采油厂")] 
	public class 采油厂Dto
	{
		private Object id;
		[JsonProperty("id")]
		[DataField("",false,true)]
		public Object ID
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

		private Object cyc;
		[JsonProperty("cyc")]
		[DataField("",false,false)]
		public Object CYC
		{
			get
			{
				return cyc;
			}
			set
			{
				cyc = value;
			}
		}

		private Object dm;
		[JsonProperty("dm")]
		[DataField("",false,false)]
		public Object DM
		{
			get
			{
				return dm;
			}
			set
			{
				dm = value;
			}
		}

	}
}
