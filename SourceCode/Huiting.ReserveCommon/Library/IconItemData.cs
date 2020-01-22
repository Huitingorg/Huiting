using Huiting.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ReserveCommon
{
    [Serializable]
    public class IconItemData : ITreeNodeData,IDisposable
    {
        public string ID { get; set; }
        public string PID { get; set; }
        public string Text { get; set; }
        public string Tip { get; set; }
        public string Desc1 { get; set; }
        public string Desc2 { get; set; }
        public object Tag { get; set; }

        public Bitmap Image { get; set; }

        public void Dispose()
        {
            this.Image.Dispose();
        }
    }
}
