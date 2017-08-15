using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionarySearcher
{
    [Serializable]
    public class HistoryItem : ICloneable
    {
        public string History { get; set; }
        public int Count { get; set; }

        public HistoryItem()
        {
            History = "";
            Count = 1;
        }

        public object Clone()
        {
            return new HistoryItem() { History = this.History, Count = this.Count };
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            HistoryItem p = obj as HistoryItem;
            if ((System.Object)p == null)
                return false;
            return History == p.History;

        }

        public bool Equals(HistoryItem p)
        {
            if ((object)p == null)
                return false;
            return History == p.History;
        }

        public override int GetHashCode()
        {
            return History.GetHashCode();
        }

        public override string ToString()
        {
            return "(" + Count + ") " + History;
        }
    }
}
