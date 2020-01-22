using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ReserveCommon
{
    [Serializable]
    public class SortAttribute : DescriptionAttribute
    {
        bool onlyGroup;

        public bool OnlyGroup
        {
            get { return onlyGroup; }
            set { onlyGroup = value; }
        }

        public SortAttribute()
            : base()
        {

        }

        public SortAttribute(string Description)
            : base(Description)
        {
            this.onlyGroup = true;
        }

        public SortAttribute(string Description, bool OnlySort)
            : base(Description)
        {
            this.onlyGroup = OnlySort;
        }
    }
}
