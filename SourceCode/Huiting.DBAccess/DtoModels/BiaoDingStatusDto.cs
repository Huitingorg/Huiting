using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("biaoDingStatus")] 
	public class BiaoDingStatusDto
	{
		private String proid;
		[JsonProperty("proid")]
		[DataField("char(36)",false,true)]
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
		[DataField("varchar(100)",false,true)]
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
		[DataField("varchar(50)",false,true)]
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
		[DataField("varchar",false,true)]
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

		private String displaypjnd;
		[JsonProperty("displaypjnd")]
		[DataField("varchar(100)",false,true)]
		public String DisplayPjnd
		{
			get
			{
				return displaypjnd;
			}
			set
			{
				displaypjnd = value;
			}
		}

		private String bdposition;
		[JsonProperty("bdposition")]
		[DataField("varchar(100)",false,false)]
		public String BDposition
		{
			get
			{
				return bdposition;
			}
			set
			{
				bdposition = value;
			}
		}

		private Int64 bddisplay;
		[JsonProperty("bddisplay")]
		[DataField("bigint",false,false)]
		public Int64 BDDisplay
		{
			get
			{
				return bddisplay;
			}
			set
			{
				bddisplay = value;
			}
		}

	}
}
