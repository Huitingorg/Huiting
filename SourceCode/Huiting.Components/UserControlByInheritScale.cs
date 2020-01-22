using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Huiting.Components
{
    /// <summary>
    /// 继承父控件缩放的用户控件
    /// </summary>
    public class UserControlByInheritScale : UserControl
    {
        /// <summary>
        /// 禁止修改自动缩放模式
        /// </summary>
        public new AutoScaleMode AutoScaleMode { get; private set; }

        public UserControlByInheritScale()
        {
            this.AutoScaleMode = AutoScaleMode.Inherit;
        }
    }
}
