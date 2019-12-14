using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDSoft.Components
{
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

        public void Dispose()
        {

        }
    }
}
