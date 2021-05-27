using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Model
{
    public struct DeviceInformation
    {
        public DeviceInformation(string deviceName, string deviceSeries)
        {
            DeviceName = deviceName;
            DeviceSeries = deviceSeries;
        }

        public string DeviceName { get; set; }

        public string DeviceSeries { get; set; }
    }
}
