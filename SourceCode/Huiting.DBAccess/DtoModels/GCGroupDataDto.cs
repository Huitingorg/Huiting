using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("gCGroupData")] 
	public class GCGroupDataDto
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

		private String mintcrq;
		[JsonProperty("mintcrq")]
		[DataField("varchar",false,false)]
		public String MinTcrq
		{
			get
			{
				return mintcrq;
			}
			set
			{
				mintcrq = value;
			}
		}

		private String maxtcrq2;
		[JsonProperty("maxtcrq2")]
		[DataField("varchar",false,false)]
		public String MaxTcrq2
		{
			get
			{
				return maxtcrq2;
			}
			set
			{
				maxtcrq2 = value;
			}
		}

		private Double js;
		[JsonProperty("js")]
		[DataField("float",false,false)]
		public Double Js
		{
			get
			{
				return js;
			}
			set
			{
				js = value;
			}
		}

		private Double ljts;
		[JsonProperty("ljts")]
		[DataField("float",false,false)]
		public Double Ljts
		{
			get
			{
				return ljts;
			}
			set
			{
				ljts = value;
			}
		}

		private Double ljcy;
		[JsonProperty("ljcy")]
		[DataField("float",false,false)]
		public Double Ljcy
		{
			get
			{
				return ljcy;
			}
			set
			{
				ljcy = value;
			}
		}

		private Double djl;
		[JsonProperty("djl")]
		[DataField("float",false,false)]
		public Double Djl
		{
			get
			{
				return djl;
			}
			set
			{
				djl = value;
			}
		}

		private Double sykccl;
		[JsonProperty("sykccl")]
		[DataField("float",false,false)]
		public Double Sykccl
		{
			get
			{
				return sykccl;
			}
			set
			{
				sykccl = value;
			}
		}

		private Double ycysum;
		[JsonProperty("ycysum")]
		[DataField("float",false,false)]
		public Double Ycysum
		{
			get
			{
				return ycysum;
			}
			set
			{
				ycysum = value;
			}
		}

		private Double ycssum;
		[JsonProperty("ycssum")]
		[DataField("float",false,false)]
		public Double Ycssum
		{
			get
			{
				return ycssum;
			}
			set
			{
				ycssum = value;
			}
		}

		private Int32 ischecked;
		[JsonProperty("ischecked")]
		[DataField("int",false,false)]
		public Int32 IsChecked
		{
			get
			{
				return ischecked;
			}
			set
			{
				ischecked = value;
			}
		}

		private Double dkkc;
		[JsonProperty("dkkc")]
		[DataField("float",false,false)]
		public Double Dkkc
		{
			get
			{
				return dkkc;
			}
			set
			{
				dkkc = value;
			}
		}

		private String borrowgroupname;
		[JsonProperty("borrowgroupname")]
		[DataField("varchar(100)",false,false)]
		public String BorrowGroupName
		{
			get
			{
				return borrowgroupname;
			}
			set
			{
				borrowgroupname = value;
			}
		}

		private Double borrowdkkc;
		[JsonProperty("borrowdkkc")]
		[DataField("float",false,false)]
		public Double BorrowDKKC
		{
			get
			{
				return borrowdkkc;
			}
			set
			{
				borrowdkkc = value;
			}
		}

		private Int32 useborrow;
		[JsonProperty("useborrow")]
		[DataField("int",false,false)]
		public Int32 UseBorrow
		{
			get
			{
				return useborrow;
			}
			set
			{
				useborrow = value;
			}
		}

	}
}
