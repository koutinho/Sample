using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Model.Nodes
{
    public class SignalGroupNode : SignalNode
    {
        public SignalGroupNode(string name)
            :base(name)
        { }

        public List<SignalNode> Nodes { get; private set; } = new List<SignalNode>();
    }
}
