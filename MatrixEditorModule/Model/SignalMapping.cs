using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Model
{
    /// <summary>
    /// Ассоциация параметра с физическим сигналом
    /// </summary>
    public class SignalMapping
    {
        public SignalMapping(string parameterName)
        {
            ParameterName = parameterName;
        }

        [JsonProperty(Required = Required.Always)]
        public string ParameterName { get; set; }

        public List<string> DiscreteInputs { get; private set; } = new List<string>();

        public List<string> DigitalInputs { get; private set; } = new List<string>();

        public List<string> OutputRelays { get; private set; } = new List<string>();
    }
}
