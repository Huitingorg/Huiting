using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("sqlite_sequence")] 
	public class Sqlite_sequenceDto
	{
		private Object name;
		[JsonProperty("name")]
		[DataField("",false,false)]
		public Object Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		private Object seq;
		[JsonProperty("seq")]
		[DataField("",false,false)]
		public Object Seq
		{
			get
			{
				return seq;
			}
			set
			{
				seq = value;
			}
		}

	}
}
