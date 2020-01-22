using Huiting.DBAccess.Attributes;
using Huiting.DBAccess.Entity;
using Newtonsoft.Json;
using System;

namespace Huiting.DBAccess.Entity.Dtos
{
    [DataTable("UnitBasicData")]
    public class UnitBasicDataDto : IDto
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

        private String dYDM;
        [JsonProperty("dydm")]
        [BusinessKey]
        [DisplayField("��Ԫ����", "����")]
        [DataField("varchar(255)", false, false)]
        public String DYDM
        {
            get
            {
                return dYDM;
            }
            set
            {
                dYDM = value;
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
               
        private String fgsmc;
        [JsonProperty("fgsmc")]
        [DisplayField("�ֹ�˾����", "��˾��,companyName,��˾,company")]
        [DataField("varchar(255)", true)]
        public String FGSMC
        {
            get
            {
                return fgsmc;
            }
            set
            {
                fgsmc = value;
            }
        }

        private String cYCMC;
        [JsonProperty("cycmc")]
        [DisplayField("���ͳ�����", "factory,���ͳ�,������,����,��")]
        [DataField("varchar(255)", true)]
        public String CYCMC
        {
            get
            {
                return cYCMC;
            }
            set
            {
                cYCMC = value;
            }
        }

        private String yTMC;
        [JsonProperty("ytmc")]
        [DisplayField("��������", "��������,����")]
        [DataField("varchar(255)", false)]
        public String YTMC
        {
            get
            {
                return yTMC;
            }
            set
            {
                yTMC = value;
            }
        }

        private String dYMC;
        [JsonProperty("dymc")]
        [DisplayField("��Ԫ����", "��Ԫ����,��Ԫ")]
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

        private Double hYMJ;
        [JsonProperty("hymj")]
        [DisplayField("�������")]
        [DataField("float")]
        public Double HYMJ
        {
            get
            {
                return hYMJ;
            }
            set
            {
                hYMJ = value;
            }
        }

        private Double hQMJ;
        [JsonProperty("hqmj")]
        [DisplayField("�������")]
        [DataField("float")]
        public Double HQMJ
        {
            get
            {
                return hQMJ;
            }
            set
            {
                hQMJ = value;
            }
        }

        private Double yYDZCL;
        [JsonProperty("yydzcl")]
        [DisplayField("ԭ�͵��ʴ���", "�͵��ʴ���", "���")]
        [DataField("float")]
        public Double YYDZCL
        {
            get
            {
                return yYDZCL;
            }
            set
            {
                yYDZCL = value;
            }
        }

        private String yYKCCL;
        [JsonProperty("yykccl")]
        [DisplayField("ԭ�Ϳɲɴ���", "�Ϳɲɴ���", "���")]
        [DataField("varchar(255)")]
        public String YYKCCL
        {
            get
            {
                return yYKCCL;
            }
            set
            {
                yYKCCL = value;
            }
        }

        private String yQCLX;
        [JsonProperty("yqclx")]
        [DisplayField("����������", "������")]
        [DataField("varchar(255)")]
        public String YQCLX
        {
            get
            {
                return yQCLX;
            }
            set
            {
                yQCLX = value;
            }
        }

        private String qDLX;
        [JsonProperty("qdlx")]
        [DisplayField("��������", "����")]
        [DataField("varchar(255)")]
        public String QDLX
        {
            get
            {
                return qDLX;
            }
            set
            {
                qDLX = value;
            }
        }

        private String qBLX;
        [JsonProperty("qblx")]
        [DisplayField("Ȧ������", "Ȧ��")]
        [DataField("varchar(255)")]
        public String QBLX
        {
            get
            {
                return qBLX;
            }
            set
            {
                qBLX = value;
            }
        }

        private String kFFS;
        [JsonProperty("kffs")]
        [DisplayField("������ʽ", "����")]
        [DataField("varchar(255)")]
        public String KFFS
        {
            get
            {
                return kFFS;
            }
            set
            {
                kFFS = value;
            }
        }

        private String cLLB;
        [JsonProperty("cllb")]
        [DisplayField("�������")]
        [DataField("varchar(255)")]
        public String CLLB
        {
            get
            {
                return cLLB;
            }
            set
            {
                cLLB = value;
            }
        }

        private Int64 wZJS;
        [JsonProperty("wzjs")]
        [DisplayField("���꾮��", "���꾮")]
        [DataField("integer")]
        public Int64 WZJS
        {
            get
            {
                return wZJS;
            }
            set
            {
                wZJS = value;
            }
        }

        private String bZ;
        [JsonProperty("bZ")]
        [DisplayField("��ע")]
        [DataField("char(255)")]
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

        private Double yymd;
        [JsonProperty("yymd")]
        [DisplayField("ԭ���ܶ�", "���ܶ�,�ܶ�")]
        [DataField("float")]
        public Double YYMD
        {
            get
            {
                return yymd;
            }
            set
            {
                yymd = value;
            }
        }

        private String kfzt;
        [JsonProperty("kfzt")]
        [DisplayField("����״̬")]
        [DataField("char(255)")]
        public String KFZT
        {
            get
            {
                return kfzt;
            }
            set
            {
                kfzt = value;
            }
        }

        private String dyType;
        [JsonProperty("dytype")]
        [DisplayField("��Ԫ����")]
        [DataField("char(255)")]
        public String DYType
        {
            get
            {
                return dyType;
            }
            set
            {
                dyType = value;
            }
        }

        private Int64 involvedEconEval;
        [JsonProperty("involvedEconEval")]
        [DisplayField("���뾭������")]
        [DataField("integer")]
        public Int64 InvolvedEconEval
        {
            get
            {
                return involvedEconEval;
            }
            set
            {
                involvedEconEval = value;
            }
        }

        private String mainProduct;
        [JsonProperty("mainProduct")]
        [DisplayField("����Ʒ��", "��Ҫ��Ʒ")]
        [DataField("varchar(100)")]
        public String MainProduct
        {
            get
            {
                return mainProduct;
            }
            set
            {
                mainProduct = value;
            }
        }

        private Double qdzcl;
        [JsonProperty("qDZCL")]
        [DisplayField("�����ʴ���", "������", "��")]
        [DataField("float")]
        public Double QDZCL
        {
            get
            {
                return qdzcl;
            }
            set
            {
                qdzcl = value;
            }
        }

        private String qKCCL;
        [JsonProperty("yykccl")]
        [DisplayField("���ɲɴ���", "���ɲ�", "��")]
        [DataField("varchar(255)")]
        public String QKCCL
        {
            get
            {
                return qKCCL;
            }
            set
            {
                qKCCL = value;
            }
        }

        private Int64 ishcdy;
        [JsonProperty("iSHCDY")]
        [DisplayField("�Ƿ�ϳɵ�Ԫ")]
        [DataField("integer")]
        public Int64 IsHCDY
        {
            get
            {
                return ishcdy;
            }
            set
            {
                ishcdy = value;
            }
        }

        private Int64 hclx;
        [JsonProperty("hCLX")]
        [DisplayField("�ϳ�����")]
        [DataField("integer")]
        public Int64 HCLX
        {
            get
            {
                return hclx;
            }
            set
            {
                hclx = value;
            }
        }

        private String hccondition;
        [JsonProperty("hccondition")]
        [DisplayField("�ϳ�����")]
        [DataField("text")]
        public String HCCondition
        {
            get
            {
                return hccondition;
            }
            set
            {
                hccondition = value;
            }
        }

    }
}
