using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Huiting.DataEditor.Controls
{
    public class MyUserControl : UserControl
    {
        //自定义控件的标签
        private string title = "";

        public string Title
        {
            set
            {
                title = value;
            }
            get
            {
                return title;
            }
        }
    }
}
