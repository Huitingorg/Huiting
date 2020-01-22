using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("lQGroupJH")] 
	public class LQGroupJHDto
	{
		private String groupid;
		[JsonProperty("groupid")]
		[DataField("varchar",false,true)]
		public String GroupID
		{
			get
			{
				return groupid;
			}
			set
			{
				groupid = value;
			}
		}

		private String jh;
		[JsonProperty("jh")]
		[DataField("varchar",false,true)]
		public String Jh
		{
			get
			{
				return jh;
			}
			set
			{
				jh = value;
			}
		}

		private Object tcrq2;
		[JsonProperty("tcrq2")]
		[DataField("",false,false)]
		public Object Tcrq2
		{
			get
			{
				return tcrq2;
			}
			set
			{
				tcrq2 = value;
			}
		}

		private String tcrq;
		[JsonProperty("tcrq")]
		[DataField("varchar",false,false)]
		public String Tcrq
		{
			get
			{
				return tcrq;
			}
			set
			{
				tcrq = value;
			}
		}

	}
}
