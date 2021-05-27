using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Model.Device
{
    public interface IDevice
    {
        DeviceInformation DeviceInformation { get; }

        void WriteMatrix(DeviceSignalMatrix signalMatrix);

        DeviceSignalMatrix ReadMatrix();

        Task WriteMatrixAsync(DeviceSignalMatrix signalMatrix);

        Task<DeviceSignalMatrix> ReadMatrixAsync();
    }
}
