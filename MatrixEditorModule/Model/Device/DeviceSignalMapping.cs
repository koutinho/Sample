using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Model.Device
{
    public class DeviceSignalMapping
    {
        public DeviceSignalMapping(uint hardwareId, uint signalId)
        {
            HardwareId = hardwareId;
            SignalId = signalId;
        }

        [JsonProperty(Required = Required.Always)]
        public uint HardwareId { get; set; }

        [JsonProperty(Required = Required.Always)]
        public uint SignalId { get; set; }
    }
}
