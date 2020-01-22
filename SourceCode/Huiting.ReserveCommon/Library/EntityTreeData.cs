using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReserveCommon
{
    /// <summary>
    /// 节点数据
    /// </summary>
    public interface ITreeNodeData : IDisposable
    {
        string ID { get; set; }
        string PID { get; set; }
        string Text { get; set; }
    }

    [Serializable]
    public abstract class ATreeNodeData : ITreeNodeData
    {
        public string ID { get; set; }
        public string PID { get; set; }
        public string Text { get; set; }

        public virtual void Dispose()
        {
        }
    }
    
    [Serializable]
    public class EntityTreeData : ATreeNodeData
    {

    }

    [Serializable]
    public class ItemData : ATreeNodeData
    {
        public Bitmap Image { get; set; }
        public string Tip { get; set; }
        public string Desc1 { get; set; }
        public string Desc2 { get; set; }
        public object Tag { get; set; }
    }
}