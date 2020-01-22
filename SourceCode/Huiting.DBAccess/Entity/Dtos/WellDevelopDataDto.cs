using Huiting.DBAccess.Attributes;
using Huiting.DBAccess.Entity;
using Newtonsoft.Json;
using System;

namespace Huiting.DBAccess.Entity.Dtos
{
    [DataTable("WellDevelopData")]
    public class WellDevelopDataDto : IDto
    {
        private long id;
        [JsonProperty("id")]
        [DataField("integer", false, true,true)]
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
        [BusinessKey]
        [JsonProperty("ny")]
        [DisplayField("����", "yyyyMM")]
        [DataField("varchar", true, false)]
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

        private String jh;
        [BusinessKey]
        [JsonProperty("jh")]
        [DisplayField("����")]
        [DataField("varchar", true, false)]
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

        private String dydm;
        [BusinessKey]
        [JsonProperty("dydm")]
        [DisplayField("��Ԫ����")]
        [DataField("char(50)", false, false)]
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

        private double yCYL;
        [JsonProperty("ycyl")]
        [DisplayField("�²�����", "�²���", "��")]
        [DataField("int", true, false)]
        public double YCYL
        {
            get
            {
                return yCYL;
            }
            set
            {
                yCYL = value;
            }
        }

        private double yCQL;
        [JsonProperty("ycql")]
        [DisplayField("�²�����", "�²���", "��")]
        [DataField("varchar", true, false)]
        public double YCQL
        {
            get
            {
                return yCQL;
            }
            set
            {
                yCQL = value;
            }
        }

        private double yCSL;
        [JsonProperty("ycsl")]
        [DisplayField("�²�ˮ��", "�²�ˮ", "��")]
        [DataField("int", true, false)]
        public double YCSL
        {
            get
            {
                return yCSL;
            }
            set
            {
                yCSL = value;
            }
        }

        private double lJCYL;
        [JsonProperty("ljcyl")]
        [DisplayField("�۲�����", "�۲���", "���")]
        [DataField("float", true, false)]
        public double LJCYL
        {
            get
            {
                return lJCYL;
            }
            set
            {
                lJCYL = value;
            }
        }

        private double lJCQL;
        [JsonProperty("ljcql")]
        [DisplayField("�۲�����", "�۲���", "��")]
        [DataField("float", true, false)]
        public double LJCQL
        {
            get
            {
                return lJCQL;
            }
            set
            {
                lJCQL = value;
            }
        }

        private double lJCSL;
        [JsonProperty("ljcsl")]
        [DisplayField("�۲�ˮ��", "�۲�ˮ", "���")]
        [DataField("float", true, false)]
        public double LJCSL
        {
            get
            {
                return lJCSL;
            }
            set
            {
                lJCSL = value;
            }
        }

        private double yZS;
        [JsonProperty("yzs")]
        [DisplayField("��עˮ��", "��עˮ", "���")]
        [DataField("float", true, false)]
        public double YZS
        {
            get
            {
                return yZS;
            }
            set
            {
                yZS = value;
            }
        }

        private double lZS;
        [JsonProperty("lzs")]
        [DisplayField("��עˮ��", "��עˮ", "���")]
        [DataField("float", true, false)]
        public double LZS
        {
            get
            {
                return lZS;
            }
            set
            {
                lZS = value;
            }
        }

        private String mQJB;
        [JsonProperty("mqjb")]
        [DisplayField("Ŀǰ����", "����")]
        [DataField("varchar", true, false)]
        public String MQJB
        {
            get
            {
                return mQJB;
            }
            set
            {
                mQJB = value;
            }
        }

        private Double scts;
        [JsonProperty("scts")]
        [DisplayField("��������", "������", "��")]
        [DataField("float", true, false)]
        public Double SCTS
        {
            get
            {
                return scts;
            }
            set
            {
                scts = value;
            }
        }

        private double ty;
        [JsonProperty("ty")]
        [DisplayField("��ѹ")]
        [DataField("float", true, false)]
        public double Ty { get => ty; set => ty = value; }


        private double dYM;
        [JsonProperty("dym")]
        [DisplayField("��Һ��")]
        [DataField("varchar", true, false)]
        public double DYM
        {
            get
            {
                return dYM;
            }
            set
            {
                dYM = value;
            }
        }

        private String bZ;
        [JsonProperty("bZ")]
        [DataField("varchar", true, false)]
        public String BZ
        {
            get
            {
                return bZ;
            }
            set
            {
                bZ = value;
            }
        }

    
    }
}
