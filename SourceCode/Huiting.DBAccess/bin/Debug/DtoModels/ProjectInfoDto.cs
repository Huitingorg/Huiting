using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("projectInfo")] 
	public class ProjectInfoDto
	{
		private String id;
		[JsonProperty("id")]
		[DataField("char(36)",false,true)]
		public String ID
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

		private String mc;
		[JsonProperty("mc")]
		[DataField("varchar(100)",false,false)]
		public String MC
		{
			get
			{
				return mc;
			}
			set
			{
				mc = value;
			}
		}

		private DateTime createtime;
		[JsonProperty("createtime")]
		[DataField("date",false,false)]
		public DateTime CreateTime
		{
			get
			{
				return createtime;
			}
			set
			{
				createtime = value;
			}
		}

		private DateTime updatetime;
		[JsonProperty("updatetime")]
		[DataField("date",false,false)]
		public DateTime UpdateTime
		{
			get
			{
				return updatetime;
			}
			set
			{
				updatetime = value;
			}
		}

		private String grouplist;
		[JsonProperty("grouplist")]
		[DataField("varchar(100)",false,false)]
		public String GroupList
		{
			get
			{
				return grouplist;
			}
			set
			{
				grouplist = value;
			}
		}

		private String sortlist;
		[JsonProperty("sortlist")]
		[DataField("varchar(100)",false,false)]
		public String SortList
		{
			get
			{
				return sortlist;
			}
			set
			{
				sortlist = value;
			}
		}

		private String remark;
		[JsonProperty("remark")]
		[DataField("varchar(250)",false,false)]
		public String Remark
		{
			get
			{
				return remark;
			}
			set
			{
				remark = value;
			}
		}

	}
}
