using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("lQGroupData")] 
	public class LQGroupDataDto
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

		private String proid;
		[JsonProperty("proid")]
		[DataField("varchar",false,false)]
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

		private String dydm;
		[JsonProperty("dydm")]
		[DataField("varchar",false,false)]
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

		private String pjnd;
		[JsonProperty("pjnd")]
		[DataField("varchar",false,false)]
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

		private String groupname;
		[JsonProperty("groupname")]
		[DataField("varchar",false,false)]
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

		private Int32 xh;
		[JsonProperty("xh")]
		[DataField("int",false,false)]
		public Int32 Xh
		{
			get
			{
				return xh;
			}
			set
			{
				xh = value;
			}
		}

		private String stopwellny;
		[JsonProperty("stopwellny")]
		[DataField("varchar",false,false)]
		public String StopWellNY
		{
			get
			{
				return stopwellny;
			}
			set
			{
				stopwellny = value;
			}
		}

		private String conditionstr;
		[JsonProperty("conditionstr")]
		[DataField("varchar",false,false)]
		public String ConditionStr
		{
			get
			{
				return conditionstr;
			}
			set
			{
				conditionstr = value;
			}
		}

		private Int32 lqtype;
		[JsonProperty("lqtype")]
		[DataField("int",false,false)]
		public Int32 LQType
		{
			get
			{
				return lqtype;
			}
			set
			{
				lqtype = value;
			}
		}

		private Int32 maxmonthcount;
		[JsonProperty("maxmonthcount")]
		[DataField("int",false,false)]
		public Int32 MaxMonthCount
		{
			get
			{
				return maxmonthcount;
			}
			set
			{
				maxmonthcount = value;
			}
		}

		private Int32 minmonthcount;
		[JsonProperty("minmonthcount")]
		[DataField("int",false,false)]
		public Int32 MinMonthCount
		{
			get
			{
				return minmonthcount;
			}
			set
			{
				minmonthcount = value;
			}
		}

		private Int32 trackmonthcount;
		[JsonProperty("trackmonthcount")]
		[DataField("int",false,false)]
		public Int32 TrackMonthCount
		{
			get
			{
				return trackmonthcount;
			}
			set
			{
				trackmonthcount = value;
			}
		}

		private Int32 islocal;
		[JsonProperty("islocal")]
		[DataField("int",false,false)]
		public Int32 Islocal
		{
			get
			{
				return islocal;
			}
			set
			{
				islocal = value;
			}
		}

		private Int32 withmaxmonthcount;
		[JsonProperty("withmaxmonthcount")]
		[DataField("int",false,false)]
		public Int32 WithMaxMonthCount
		{
			get
			{
				return withmaxmonthcount;
			}
			set
			{
				withmaxmonthcount = value;
			}
		}

	}
}
