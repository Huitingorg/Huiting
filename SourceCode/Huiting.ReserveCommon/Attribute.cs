using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ReserveCommon
{
    [AttributeUsage(AttributeTargets.All)]
    public class BDDescriptionAttribute : DescriptionAttribute
    {

        string tip;

        public string Tip
        {
            get { return tip; }
            set { tip = value; }
        }

        public BDDescriptionAttribute(string Description):base(Description)
        {
        }

        public BDDescriptionAttribute(string Description, string Tip)
            : this(Description)
        {
            this.tip = Tip;
        }
    }
}
