using SignalMatrixEditor.Model.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Report
{
    public class SignalMappingReportItem
    {
        public string Name { get; set; }

        public string Designation { get; set; }

        public ParameterType? ParameterType { get; set; }

        public Dictionary<string, string> DiscreteInputs { get; set; }

        public Dictionary<string, string> DigitalInputs { get; set; }

        public Dictionary<string, string> OutputRelays { get; set; }

        public List<SignalMappingReportItem> Nodes { get; set; } = null;
    }
}
