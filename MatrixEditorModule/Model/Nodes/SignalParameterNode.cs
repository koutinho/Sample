using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Model.Nodes
{
    public class SignalParameterNode : SignalNode
    {
        public SignalParameterNode(string name, uint id, string parameterName,
            string designation, string note,ParameterType parameterType,
            string discreteInput = null, string digitalInput = null, IEnumerable<string> outputRelays = null) :
            base(name)
        {
            Designation = designation;
            ParameterType = parameterType;
            DiscreteInput = discreteInput;
            DigitalInput = digitalInput;
            ParameterName = parameterName;
            Note = note;
            Id = id;

            if (outputRelays != null)
                OutputRelays.AddRange(outputRelays);
        }

        public string Designation { get; set; }

        public uint Id { get; set; }

        public ParameterType ParameterType { get; set; }

        public string DiscreteInput { get; set; }

        public string DigitalInput { get; set; }

        public string ParameterName { get; set; }

        public string Note { get; set; }

        public List<string> OutputRelays { get; set; } = new List<string>();
    }
}
