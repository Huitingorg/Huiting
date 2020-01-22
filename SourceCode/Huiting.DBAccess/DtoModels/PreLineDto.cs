using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("preLine")] 
	public class PreLineDto
	{
		private String prelineid;
		[JsonProperty("prelineid")]
		[DataField("char(36)",false,true)]
		public String PrelineID
		{
			get
			{
				return prelineid;
			}
			set
			{
				prelineid = value;
			}
		}

		private String proid;
		[JsonProperty("proid")]
		[DataField("char(36)",false,false)]
		public String ProID
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
		[DataField("varchar(100)",false,false)]
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
		[DataField("varchar(20)",false,false)]
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

		private String studytype;
		[JsonProperty("studytype")]
		[DataField("varchar(100)",false,false)]
		public String StudyType
		{
			get
			{
				return studytype;
			}
			set
			{
				studytype = value;
			}
		}

		private String groupname;
		[JsonProperty("groupname")]
		[DataField("varchar(100)",false,false)]
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

		private String qxlx;
		[JsonProperty("qxlx")]
		[DataField("varchar(20)",false,false)]
		public String QXLX
		{
			get
			{
				return qxlx;
			}
			set
			{
				qxlx = value;
			}
		}

		private Double sqzs;
		[JsonProperty("sqzs")]
		[DataField("float",false,false)]
		public Double SQZS
		{
			get
			{
				return sqzs;
			}
			set
			{
				sqzs = value;
			}
		}

		private String seriesname;
		[JsonProperty("seriesname")]
		[DataField("varchar(100)",false,false)]
		public String SeriesName
		{
			get
			{
				return seriesname;
			}
			set
			{
				seriesname = value;
			}
		}

		private Double fitendoutput;
		[JsonProperty("fitendoutput")]
		[DataField("float",false,false)]
		public Double FitEndoutput
		{
			get
			{
				return fitendoutput;
			}
			set
			{
				fitendoutput = value;
			}
		}

		private Double fityeardecrate;
		[JsonProperty("fityeardecrate")]
		[DataField("float",false,false)]
		public Double FityeardecRate
		{
			get
			{
				return fityeardecrate;
			}
			set
			{
				fityeardecrate = value;
			}
		}

		private Double fitrelative;
		[JsonProperty("fitrelative")]
		[DataField("float",false,false)]
		public Double FitRelative
		{
			get
			{
				return fitrelative;
			}
			set
			{
				fitrelative = value;
			}
		}

		private String pjndvisiblelist;
		[JsonProperty("pjndvisiblelist")]
		[DataField("varchar(200)",false,false)]
		public String PjndVisibleList
		{
			get
			{
				return pjndvisiblelist;
			}
			set
			{
				pjndvisiblelist = value;
			}
		}

		private String selectedpoints;
		[JsonProperty("selectedpoints")]
		[DataField("text",false,false)]
		public String SelectedPoints
		{
			get
			{
				return selectedpoints;
			}
			set
			{
				selectedpoints = value;
			}
		}

		private String markedinfo;
		[JsonProperty("markedinfo")]
		[DataField("text",false,false)]
		public String MarkedInfo
		{
			get
			{
				return markedinfo;
			}
			set
			{
				markedinfo = value;
			}
		}

	}
}
