using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Model.Device
{
    public abstract class BinaryDevice : IDevice
    {
        public virtual DeviceInformation DeviceInformation { get; protected set; }

        public virtual DeviceSignalMatrix ReadMatrix()
        {
            byte[] bytes = ReadBytesFromDevice();

            DeviceSignalMatrix deviceSignalMatrix = FromByteArray(bytes);

            return deviceSignalMatrix;
        }

        public virtual async Task<DeviceSignalMatrix> ReadMatrixAsync()
        {
            byte[] bytes = await ReadBytesFromDeviceAsync();

            DeviceSignalMatrix deviceSignalMatrix = FromByteArray(bytes);

            return deviceSignalMatrix;
        }

        public virtual void WriteMatrix(DeviceSignalMatrix signalMatrix)
        {
            byte[] bytes = ToByteArray(signalMatrix);
            WriteBytesToDevice(bytes);
        }

        public virtual async Task WriteMatrixAsync(DeviceSignalMatrix signalMatrix)
        {
            byte[] bytes = ToByteArray(signalMatrix);
            await WriteBytesToDeviceAsync(bytes);
        }

        protected abstract void WriteBytesToDevice(byte[] bytes);

        protected abstract Task WriteBytesToDeviceAsync(byte[] bytes);

        protected abstract byte[] ReadBytesFromDevice();

        protected abstract Task<byte[]> ReadBytesFromDeviceAsync();

        private byte[] ToByteArray(DeviceSignalMatrix signalMatrix)
        {
            List<byte> bytes = new List<byte>();

            foreach (var mapping in signalMatrix.DeviceSignalMappings)
            {
                byte[] hardwareIOBytes = BitConverter.GetBytes(mapping.HardwareId);
                bytes.Add(hardwareIOBytes[0]);
                bytes.Add(hardwareIOBytes[1]);

                byte[] signalBytes = BitConverter.GetBytes(mapping.SignalId);
                bytes.Add(signalBytes[0]);
                bytes.Add(signalBytes[1]);
            }

            return bytes.ToArray();
        }

        private DeviceSignalMatrix FromByteArray(byte[] bytes)
        {
            DeviceSignalMatrix deviceSignalMatrix = new DeviceSignalMatrix();

            int recordsCount = bytes.Length / matrixRecordSize;

            for (int recordIndex = 0; recordIndex < recordsCount; recordIndex++)
            {
                int positionInArray = recordIndex * matrixRecordSize;

                UInt16 hardwareId = BitConverter.ToUInt16(bytes, positionInArray);
                UInt16 parameterAddress = BitConverter.ToUInt16(bytes, positionInArray + 2);

                DeviceSignalMapping signalMapping = new DeviceSignalMapping(hardwareId, parameterAddress);

                deviceSignalMatrix.DeviceSignalMappings.Add(signalMapping);
            }

            return deviceSignalMatrix;
        }

        private const int matrixRecordSize = sizeof(UInt16) + sizeof(UInt16);
    }
}
