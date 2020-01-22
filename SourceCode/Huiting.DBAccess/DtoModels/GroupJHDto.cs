using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("groupJH")] 
	public class GroupJHDto
	{
		private String gcid;
		[JsonProperty("gcid")]
		[DataField("char(36)",false,true)]
		public String GCID
		{
			get
			{
				return gcid;
			}
			set
			{
				gcid = value;
			}
		}

		private String groupname;
		[JsonProperty("groupname")]
		[DataField("varchar(100)",false,true)]
		public String GroupName
		{
			get
			{
				return groupname;
			}
			set
			{
				groupname = value;
			}
		}

		private String jh;
		[JsonProperty("jh")]
		[DataField("varchar(100)",false,true)]
		public String JH
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

	}
}
