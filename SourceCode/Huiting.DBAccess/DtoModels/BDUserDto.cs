using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("bDUser")] 
	public class BDUserDto
	{
		private String bz;
		[JsonProperty("bz")]
		[DataField("varchar(500)",false,false)]
		public String BZ
		{
			get
			{
				return bz;
			}
			set
			{
				bz = value;
			}
		}

		private String username;
		[JsonProperty("username")]
		[DataField("varchar(15)",false,true)]
		public String UserName
		{
			get
			{
				return username;
			}
			set
			{
				username = value;
			}
		}

		private String psw;
		[JsonProperty("psw")]
		[DataField("varchar(50)",false,false)]
		public String Psw
		{
			get
			{
				return psw;
			}
			set
			{
				psw = value;
			}
		}

		private String realname;
		[JsonProperty("realname")]
		[DataField("varchar(20)",false,false)]
		public String RealName
		{
			get
			{
				return realname;
			}
			set
			{
				realname = value;
			}
		}

		private String department;
		[JsonProperty("department")]
		[DataField("varchar(50)",false,false)]
		public String Department
		{
			get
			{
				return department;
			}
			set
			{
				department = value;
			}
		}

		private Decimal tel;
		[JsonProperty("tel")]
		[DataField("decimal(11)",false,false)]
		public Decimal Tel
		{
			get
			{
				return tel;
			}
			set
			{
				tel = value;
			}
		}

		private Decimal qq;
		[JsonProperty("qq")]
		[DataField("decimal(20)",false,false)]
		public Decimal QQ
		{
			get
			{
				return qq;
			}
			set
			{
				qq = value;
			}
		}

		private String email;
		[JsonProperty("email")]
		[DataField("varchar(50)",false,false)]
		public String Email
		{
			get
			{
				return email;
			}
			set
			{
				email = value;
			}
		}

	}
}
