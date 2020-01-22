using Huiting.DBAccess.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.DBAccess.Entity.Dtos
{
    [DataTable("TableFieldInfo")]
    public class TableFieldInfoDto : IDto
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

        [JsonProperty("tableName")]
        [DataField("varchar(50)", false, false)]
        public string TableName { get; set; }

        [JsonProperty("fieldName")]
        [DataField("varchar(50)", false, false)]
        public string FieldName { get; set; }

        [JsonProperty("fieldAlias")]
        [DataField("varchar(200)")]
        public string FieldAlias { get; set; }

        [JsonProperty("noNull")]
        [DataField("integer")]
        public int NoNull { get; set; }

        [JsonProperty("cnUnitText")]
        [DataField("varchar(20)")]
        public string CNUnitText { get; set; }

        [JsonProperty("enUnitText")]
        [DataField("varchar(20)")]
        public string ENUnitText { get; set; }
    }
}
