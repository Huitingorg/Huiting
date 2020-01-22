using Huiting.DBAccess.Attributes;
using Huiting.DBAccess.Entity;
using Newtonsoft.Json;
using System;

namespace Huiting.DBAccess.Entity.Dtos
{
    [DataTable("EvaluationOptions")] 
	public class EvaluationOptionsDto:IDto
	{
        private long id;
        [JsonProperty("id")]
        [DataField("integer", false, true, true)]
        public long Id
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

        private long proID;
        [BusinessKey]
        [JsonProperty("proid")]
        [DataField("integer", false)]
        public long ProID
        {
            get
            {
                return proID;
            }
            set
            {
                proID = value;
            }
        }

        private String pjnd;
		[JsonProperty("pjnd")]
		[DataField("varchar(36)",false)]
		public String PJND
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

        private String startny;
		[JsonProperty("startny")]
		[DataField("varchar(6)",false)]
		public String StartNY
		{
			get
			{
				return startny;
			}
			set
			{
				startny = value;
			}
		}

		private String endny;
		[JsonProperty("endny")]
		[DataField("varchar(6)",false)]
		public String EndNY
		{
			get
			{
				return endny;
			}
			set
			{
				endny = value;
			}
		}

		private Double yfqcl;
		[JsonProperty("yfqcl")]
		[DataField("float",false)]
		public Double YFQCL
		{
			get
			{
				return yfqcl;
			}
			set
			{
				yfqcl = value;
			}
		}

        private Double qfqcl;
        [JsonProperty("qfqcl")]
        [DataField("float", false)]
        public Double QFQCL
        {
            get
            {
                return qfqcl;
            }
            set
            {
                qfqcl = value;
            }
        }

        private string zxny;
		[JsonProperty("zxny")]
		[DataField("varchar(6)", false)]
		public string ZXNY
		{
			get
			{
				return zxny;
			}
			set
			{
				zxny = value;
			}
		}

		private Double nzxl;
		[JsonProperty("nzxl")]
		[DataField("float",false)]
		public Double NZXL
		{
			get
			{
				return nzxl;
			}
			set
			{
				nzxl = value;
			}
		}
    }
}
