using Newtonsoft.Json;
using SignalMatrixEditor.Model;
using SignalMatrixEditor.Model.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Services
{
    public static class SignalMatrixConverter
    {
        public static string ToJson(SignalMatrix signalMatrix)
        {
            return JsonConvert.SerializeObject(signalMatrix.SignalMappings, Formatting.Indented);
        }

        public static string ToJson(DeviceSignalMatrix deviceSignalMatrix)
        {
            return JsonConvert.SerializeObject(deviceSignalMatrix.DeviceSignalMappings, Formatting.Indented);
        }

        public static SignalMatrix FromJson(string json)
        {
            IEnumerable<SignalMapping> mappings = JsonConvert.DeserializeObject<IEnumerable<SignalMapping>>(json);

            SignalMatrix signalMatrix = new SignalMatrix();

            signalMatrix.SignalMappings.AddRange(mappings);

            return signalMatrix;
        }

        public static DeviceSignalMatrix FromJsonToDeviceSignalMatrix(string json)
        {
            IEnumerable<DeviceSignalMapping> mappings = JsonConvert.DeserializeObject<IEnumerable<DeviceSignalMapping>>(json);

            DeviceSignalMatrix signalMatrix = new DeviceSignalMatrix();

            signalMatrix.DeviceSignalMappings.AddRange(mappings);

            return signalMatrix;
        }
    }
}
