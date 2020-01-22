using Huiting.DBAccess.Attributes;
using Huiting.DBAccess.Entity;
using Newtonsoft.Json;
using System;

namespace Huiting.DBAccess.Entity.Dtos
{
    [DataTable("ProjectInfo")]
    public class ProjectInfoDto : IDto
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

        private String mc;
        [JsonProperty("mc")]
        [DataField("varchar(100)", false)]
        public String MC
        {
            get
            {
                return mc;
            }
            set
            {
                mc = value;
            }
        }

        private DateTime createtime;
        [JsonProperty("createtime")]
        [DataField("date", false)]
        public DateTime CreateTime
        {
            get
            {
                return createtime;
            }
            set
            {
                createtime = value;
            }
        }

        private DateTime updatetime;
        [JsonProperty("updatetime")]
        [DataField("date")]
        public DateTime UpdateTime
        {
            get
            {
                return updatetime;
            }
            set
            {
                updatetime = value;
            }
        }

        private String grouplist;
        [JsonProperty("grouplist")]
        [DataField("varchar(100)")]
        public String GroupList
        {
            get
            {
                return grouplist;
            }
            set
            {
                grouplist = value;
            }
        }

        private String sortlist;
        [JsonProperty("sortlist")]
        [DataField("varchar(100)")]
        public String SortList
        {
            get
            {
                return sortlist;
            }
            set
            {
                sortlist = value;
            }
        }

        private String remark;
        [JsonProperty("remark")]
        [DataField("varchar(250)")]
        public String Remark
        {
            get
            {
                return remark;
            }
            set
            {
                remark = value;
            }
        }

    }
}
