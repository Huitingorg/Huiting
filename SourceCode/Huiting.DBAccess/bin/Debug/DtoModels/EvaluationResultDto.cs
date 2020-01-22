using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("evaluationResult")] 
	public class EvaluationResultDto
	{
		private String proid;
		[JsonProperty("proid")]
		[DataField("varchar(36)",false,true)]
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

		private String pjnd;
		[JsonProperty("pjnd")]
		[DataField("varchar",false,true)]
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

		private Decimal ysykcclcn;
		[JsonProperty("ysykcclcn")]
		[DataField("decimal",false,false)]
		public Decimal YSykcclCN
		{
			get
			{
				return ysykcclcn;
			}
			set
			{
				ysykcclcn = value;
			}
		}

		private Decimal ysykcclen;
		[JsonProperty("ysykcclen")]
		[DataField("decimal",false,false)]
		public Decimal YSykcclEn
		{
			get
			{
				return ysykcclen;
			}
			set
			{
				ysykcclen = value;
			}
		}

		private Decimal qsykcclcn;
		[JsonProperty("qsykcclcn")]
		[DataField("decimal",false,false)]
		public Decimal QSykcclCN
		{
			get
			{
				return qsykcclcn;
			}
			set
			{
				qsykcclcn = value;
			}
		}

		private Decimal qsykcclen;
		[JsonProperty("qsykcclen")]
		[DataField("decimal",false,false)]
		public Decimal QSykcclEN
		{
			get
			{
				return qsykcclen;
			}
			set
			{
				qsykcclen = value;
			}
		}

		private Decimal kcnx;
		[JsonProperty("kcnx")]
		[DataField("decimal",false,false)]
		public Decimal Kcnx
		{
			get
			{
				return kcnx;
			}
			set
			{
				kcnx = value;
			}
		}

		private String kcny;
		[JsonProperty("kcny")]
		[DataField("varchar",false,false)]
		public String Kcny
		{
			get
			{
				return kcny;
			}
			set
			{
				kcny = value;
			}
		}

		private Decimal syjjjzcn;
		[JsonProperty("syjjjzcn")]
		[DataField("decimal",false,false)]
		public Decimal SyjjjzCN
		{
			get
			{
				return syjjjzcn;
			}
			set
			{
				syjjjzcn = value;
			}
		}

		private Decimal syjjjzen;
		[JsonProperty("syjjjzen")]
		[DataField("decimal",false,false)]
		public Decimal SyjjjzEN
		{
			get
			{
				return syjjjzen;
			}
			set
			{
				syjjjzen = value;
			}
		}

	}
}
