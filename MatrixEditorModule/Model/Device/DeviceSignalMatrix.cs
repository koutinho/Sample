using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Model.Device
{
    public class DeviceSignalMatrix
    {
        public DeviceSignalMatrix() { }

        public DeviceSignalMatrix(IEnumerable<DeviceSignalMapping> mappings)
        {
            DeviceSignalMappings.AddRange(mappings);
        }

        public List<DeviceSignalMapping> DeviceSignalMappings { get; set; } = new List<DeviceSignalMapping>();
    }
}
