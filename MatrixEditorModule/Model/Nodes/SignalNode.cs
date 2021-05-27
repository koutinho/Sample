using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Model.Nodes
{
    public abstract class SignalNode
    {
        public SignalNode(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
