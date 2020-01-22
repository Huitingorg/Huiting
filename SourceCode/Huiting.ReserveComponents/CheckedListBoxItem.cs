using ReserveCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveComponents
{
    class CheckedListBoxItem
    {
        public string Text;
        public SortType Type;
        public int Width = 120;

        public SortInfo GetSortInfo()
        {
            SortInfo si = new SortInfo();
            si.Type = this.Type;
            si.Width = this.Width;
            return si;
        }


        public override string ToString()
        {
            if (string.IsNullOrEmpty(Text))
                return base.ToString();
            return Text;
        }
    }
}
