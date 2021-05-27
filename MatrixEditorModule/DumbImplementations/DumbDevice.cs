using SignalMatrixEditor.Model;
using SignalMatrixEditor.Model.Device;
using SignalMatrixEditor.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.DumbImplementations
{
    public class DumbDevice : BinaryDevice
    {
        public DumbDevice(string fileName)
        {
            this.fileName = fileName;
            DeviceInformation = new DeviceInformation("М1", "Серия228");
        }

        public override DeviceInformation DeviceInformation
        {
            get;
            protected set;
        }

        protected override void WriteBytesToDevice(byte[] bytes)
        {
            File.WriteAllBytes(fileName, bytes);
        }

        protected override async Task WriteBytesToDeviceAsync(byte[] bytes)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                await fs.WriteAsync(bytes, 0, bytes.Length);
            }
        }

        protected override byte[] ReadBytesFromDevice()
        {
            return File.ReadAllBytes(fileName);
        }

        protected override async Task<byte[]> ReadBytesFromDeviceAsync()
        {
            byte[] buffer;

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                await fs.ReadAsync(buffer, 0, (int)fs.Length);
            }

            return buffer;
        }

        private string fileName;
    }
}
