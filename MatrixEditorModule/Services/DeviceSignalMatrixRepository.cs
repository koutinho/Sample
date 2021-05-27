using SignalMatrixEditor.Model;
using SignalMatrixEditor.Model.Device;
using SignalMatrixEditor.Model.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Services
{
    public class DeviceSignalMatrixRepository : ISignalMatrixRepository
    {
        public DeviceSignalMatrixRepository(IDevice device, SignalMatrixDescriptor signalMatrixDescriptor)
        {
            Device = device;
            this.signalMatrixDescriptor = signalMatrixDescriptor;

            Signals = signalMatrixDescriptor.SignalTree
                .SelectMany(node => GetAllSignals(node))
                .ToList();

            DiscreteInputs = signalMatrixDescriptor.DiscreteInputs.ToList();
            DigitalInputs = signalMatrixDescriptor.DigitalInputs.ToList();
            OutputRelays = signalMatrixDescriptor.OutputRelays.ToList();
        }

        public IDevice Device { get; private set; }

        public List<SignalParameterNode> Signals { get; private set; }

        public List<HardwareIO> DiscreteInputs { get; private set; }

        public List<HardwareIO> DigitalInputs { get; private set; }

        public List<HardwareIO> OutputRelays { get; private set; } = new List<HardwareIO>();

        public SignalMatrix Read()
        {
            DeviceSignalMatrix deviceSignalMatrix = Device.ReadMatrix();

            return FromDeviceSignalMatrix(deviceSignalMatrix);
        }

        public async Task<SignalMatrix> ReadAsync()
        {
            DeviceSignalMatrix deviceSignalMatrix = null;

            try
            {
                deviceSignalMatrix = await Device.ReadMatrixAsync();
            }
            catch (Exception ex)
            {
                // TODO Надо подумать над более тщательной обработкой ошибок
                return null;
            }

            return FromDeviceSignalMatrix(deviceSignalMatrix);
        }

        public void Write(SignalMatrix signalMatrix)
        {
            DeviceSignalMatrix deviceSignalMatrix = ToDeviceSignalMatrix(signalMatrix);

            Device.WriteMatrix(deviceSignalMatrix);
        }

        public async Task WriteAsync(SignalMatrix signalMatrix)
        {
            DeviceSignalMatrix deviceSignalMatrix = ToDeviceSignalMatrix(signalMatrix);

            await Device.WriteMatrixAsync(deviceSignalMatrix);
        }

        private IEnumerable<SignalParameterNode> GetAllSignals(SignalNode node)
        {
            if (node is SignalParameterNode)
            {
                yield return (SignalParameterNode)node;
            }

            if (node is SignalGroupNode)
            {
                var signalNodes = ((SignalGroupNode)node).Nodes
                    .SelectMany(childNode => GetAllSignals(childNode));

                foreach (var signalNode in signalNodes)
                {
                    yield return signalNode;
                }
            }
        }

        private DeviceSignalMatrix ToDeviceSignalMatrix(SignalMatrix signalMatrix)
        {
            DeviceSignalMatrix deviceSignalMatrix = new DeviceSignalMatrix();

            foreach (var mapping in signalMatrix.SignalMappings)
            {
                var signal = Signals.FirstOrDefault(_signal => _signal.ParameterName == mapping.ParameterName);

                if (signal == null)
                    continue;

                foreach (string discreteInput in mapping.DiscreteInputs)
                {
                    var hardwareIO = DiscreteInputs.FirstOrDefault(_discreteInput => _discreteInput.Name == discreteInput);
                    if (hardwareIO == null)
                        continue;

                    deviceSignalMatrix.DeviceSignalMappings.Add(new DeviceSignalMapping(hardwareIO.Id, signal.Id));
                }

                foreach (string digitalInput in mapping.DigitalInputs)
                {
                    var hardwareIO = DigitalInputs.FirstOrDefault(_digitalInput => _digitalInput.Name == digitalInput);
                    if (hardwareIO == null)
                        continue;

                    deviceSignalMatrix.DeviceSignalMappings.Add(new DeviceSignalMapping(hardwareIO.Id, signal.Id));
                }

                foreach (string outputRelay in mapping.OutputRelays)
                {
                    var hardwareIO = OutputRelays.FirstOrDefault(_outputRelay => _outputRelay.Name == outputRelay);
                    if (hardwareIO == null)
                        continue;

                    deviceSignalMatrix.DeviceSignalMappings.Add(new DeviceSignalMapping(hardwareIO.Id, signal.Id));
                }
            }

            return deviceSignalMatrix;
        }

        private SignalMatrix FromDeviceSignalMatrix(DeviceSignalMatrix deviceSignalMatrix)
        {
            SignalMatrix signalMatrix = new SignalMatrix();

            foreach (var mapping in deviceSignalMatrix.DeviceSignalMappings)
            {
                SignalParameterNode signal = Signals.FirstOrDefault(node => node.Id == mapping.SignalId);

                if (signal == null)
                    continue;

                SignalMapping signalMappin = signalMatrix.SignalMappings
                    .FirstOrDefault(signalMapping => signalMapping.ParameterName == signal.ParameterName);

                if (signalMappin == null)
                {
                    signalMappin = new SignalMapping(signal.ParameterName);
                    signalMatrix.SignalMappings.Add(signalMappin);
                }

                HardwareIO discreteInput = DiscreteInputs
                    .SingleOrDefault(hardwareIO => hardwareIO.Id == mapping.HardwareId);

                if (discreteInput != null)
                {
                    signalMappin.DiscreteInputs.Add(discreteInput.Name);
                    continue;
                }

                HardwareIO digitalInput = DigitalInputs
                    .SingleOrDefault(hardwareIO => hardwareIO.Id == mapping.HardwareId);

                if (digitalInput != null)
                {
                    signalMappin.DigitalInputs.Add(digitalInput.Name);
                    continue;
                }

                HardwareIO outputRelay = OutputRelays
                    .SingleOrDefault(hardwareIO => hardwareIO.Id == mapping.HardwareId);

                if (outputRelay != null)
                {
                    signalMappin.OutputRelays.Add(outputRelay.Name);
                    continue;
                }
            }

            return signalMatrix;
        }

        private SignalMatrixDescriptor signalMatrixDescriptor;
    }
}
