using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("baseDict")] 
	public class BaseDictDto
	{
		private String typename;
		[JsonProperty("typename")]
		[DataField("varchar",false,true)]
		public String TypeName
		{
			get
			{
				return typename;
			}
			set
			{
				typename = value;
			}
		}

		private String itemvalue;
		[JsonProperty("itemvalue")]
		[DataField("varchar",false,true)]
		public String ItemValue
		{
			get
			{
				return itemvalue;
			}
			set
			{
				itemvalue = value;
			}
		}

		private String itemdesc;
		[JsonProperty("itemdesc")]
		[DataField("varchar",false,false)]
		public String ItemDesc
		{
			get
			{
				return itemdesc;
			}
			set
			{
				itemdesc = value;
			}
		}

	}
}
