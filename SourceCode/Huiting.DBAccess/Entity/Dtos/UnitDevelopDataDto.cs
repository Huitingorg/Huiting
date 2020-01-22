using Huiting.DBAccess.Attributes;
using Huiting.DBAccess.Entity;
using Newtonsoft.Json;
using System;

namespace Huiting.DBAccess.Entity.Dtos
{
    [DataTable("UnitDevelopData")] 
	public class UnitDevelopDataDto : IDto
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

        private String ny;
        [JsonProperty("ny")]
        [DisplayField("����", "yyyyMM")]
        [DataField("char(50)", false, false)]
        public String NY
        {
            get
            {
                return ny;
            }
            set
            {
                ny = value;
            }
        }

        private String dydm;
        [BusinessKey]
        [JsonProperty("dydm")]
        [DisplayField("��Ԫ����", "����")]
        [DataField("char(50)",false,false)]
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

        private String dYMC;
        [JsonProperty("dymc")]
        [DisplayField("��Ԫ����","����")]
        [DataField("varchar(255)", false)]
        public String DYMC
        {
            get
            {
                return dYMC;
            }
            set
            {
                dYMC = value;
            }
        }

        private long proID;
        [BusinessKey]
        [JsonProperty("proid")]
        [DataField("integer", false, false)]
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

        private Double ycy;
		[JsonProperty("ycy")]
        [DisplayField("�²�����", "�²���", "���")]
        [DataField("float",true,false)]
		public Double YCY
		{
			get
			{
				return ycy;
			}
			set
			{
				ycy = value;
			}
		}

		private Double ycq;
		[JsonProperty("ycq")]
        [DisplayField("�²�����", "�²���", "��")]
        [DataField("float",true,false)]
		public Double YCQ
		{
			get
			{
				return ycq;
			}
			set
			{
				ycq = value;
			}
		}

		private Double ycs;
		[JsonProperty("yCS")]
        [DisplayField("�²�ˮ��", "�²�ˮ", "���")]
        [DataField("float",true,false)]
		public Double YCS
		{
			get
			{
				return ycs;
			}
			set
			{
				ycs = value;
			}
		}

		private Double yzs;
		[JsonProperty("yZS")]
        [DisplayField("��עˮ��", "��עˮ", "���")]
        [DataField("float",true,false)]
		public Double YZS
		{
			get
			{
				return yzs;
			}
			set
			{
				yzs = value;
			}
		}

		private Double lcy;
		[JsonProperty("lcy")]
        [DisplayField("�۲�����", "�۲���", "���")]
        [DataField("float",true,false)]
		public Double LCY
		{
			get
			{
				return lcy;
			}
			set
			{
				lcy = value;
			}
		}

		private Double lcq;
		[JsonProperty("lCQ")]
        [DisplayField("�۲�����", "�۲���", "��")]
        [DataField("float",true,false)]
		public Double LCQ
		{
			get
			{
				return lcq;
			}
			set
			{
				lcq = value;
			}
		}

		private Double lcs;
		[JsonProperty("lcs")]
        [DisplayField("�۲�ˮ��", "�۲�ˮ", "���")]
        [DataField("float",true,false)]
		public Double LCS
		{
			get
			{
				return lcs;
			}
			set
			{
				lcs = value;
			}
		}

		private Double lzs;
		[JsonProperty("lzs")]
        [DisplayField("��עˮ��", "��עˮ", "���")]
        [DataField("float",true,false)]
		public Double LZS
		{
			get
			{
				return lzs;
			}
			set
			{
				lzs = value;
			}
		}

		private Double zyjs;
		[JsonProperty("zyjs")]
        [DisplayField("�꾮��", "�꾮����", "��")]
        [DataField("float",true,false)]
		public Double ZYJS
		{
			get
			{
				return zyjs;
			}
			set
			{
				zyjs = value;
			}
		}

		private Double kyjs;
		[JsonProperty("kyjs")]
        [DisplayField("������", "��������", "��")]
        [DataField("float",true,false)]
		public Double KYJS
		{
			get
			{
				return kyjs;
			}
			set
			{
				kyjs = value;
			}
		}

		private Double zsjs;
		[JsonProperty("zsjs")]
        [DisplayField("��ˮ����", "��ˮ������", "��")]
        [DataField("float", true,false)]
		public Double ZSJS
		{
			get
			{
				return zsjs;
			}
			set
			{
				zsjs = value;
			}
		}

		private Double ksjs;
		[JsonProperty("kSJS")]
        [DisplayField("��ˮ����", "��ˮ������", "��")]
        [DataField("float", true,false)]
		public Double KSJS
		{
			get
			{
				return ksjs;
			}
			set
			{
				ksjs = value;
			}
		}

	}
}
