using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    class NLinkNode
    {
        public NLinkNode(object data)
        {
            this.Data = data;
            Links = new List<NLinkNode>();
        }

        public object Data { get; set; }
        public List<NLinkNode> Links { get; private set; }
    }
}
