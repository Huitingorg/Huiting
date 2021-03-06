﻿using Huiting.DBAccess.Entity;

namespace Huiting.DBAccess.Entity.Dict
{
    public class TableInfoDto : IDto
    {
        public long Cid { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int NotNull { get; set; }

        public string Dflt_Value { get; set; }

        public int Pk { get; set; }
    }

}
