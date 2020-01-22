using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("dYGroupUnitWellList")] 
	public class DYGroupUnitWellListDto
	{
		private String proid;
		[JsonProperty("proid")]
		[DataField("varchar",false,true)]
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

		private String dydm;
		[JsonProperty("dydm")]
		[DataField("varchar",false,true)]
		public String DYDM
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

		private String childdydm;
		[JsonProperty("childdydm")]
		[DataField("varchar",false,true)]
		public String ChildDYDM
		{
			get
			{
				return childdydm;
			}
			set
			{
				childdydm = value;
			}
		}

		private String jh;
		[JsonProperty("jh")]
		[DataField("varchar",false,true)]
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
