using SignalMatrixEditor.Model;
using SignalMatrixEditor.Model.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.ViewModels.Nodes
{
    public class ParameterNodeViewModel : NodeViewModel
    {
        public ParameterNodeViewModel(SignalParameterNode parameter, IEnumerable<HardwareIO> discreteInputs,
            IEnumerable<HardwareIO> digitalInputs, IEnumerable<HardwareIO> outputRelays)
            : base(parameter.Name)
        {
            Designation = parameter.Designation;
            Note = parameter.Note;
            Type = parameter.ParameterType;
            Id = parameter.Id;
            Parameter = parameter;

            foreach (var discreteInput in discreteInputs)
            {
                bool isReadOnly = Parameter.ParameterType == ParameterType.Input || Parameter.ParameterType == ParameterType.InputOutput;
                DiscreteInputViewModel discreteInputViewModel = new DiscreteInputViewModel(discreteInput, Parameter.Name, isReadOnly);
                discreteInputViewModel.CheckedChanged += DiscreteInputViewModel_CheckedChanged;

                DiscreteInputs.Add(discreteInputViewModel.Name, discreteInputViewModel);
            }

            foreach (var digitalInput in digitalInputs)
            {
                bool isReadOnly = Parameter.ParameterType == ParameterType.Input || Parameter.ParameterType == ParameterType.InputOutput;
                DigitalInputViewModel digitalInputViewModel = new DigitalInputViewModel(digitalInput, Parameter.Name, isReadOnly);
                digitalInputViewModel.CheckedChanged += DigitalInputViewModel_CheckedChanged;

                DigitalInputs.Add(digitalInputViewModel.Name, digitalInputViewModel);
            }

            foreach (var outputRelay in outputRelays)
            {
                bool isReadOnly = Parameter.ParameterType == ParameterType.Output || Parameter.ParameterType == ParameterType.InputOutput;
                OutputRelayViewModel outputRelayViewModel = new OutputRelayViewModel(outputRelay, Parameter.Name, isReadOnly);
                outputRelayViewModel.CheckedChanged += OutputRelayViewModel_CheckedChanged;

                OutputRelays.Add(outputRelayViewModel.Name, outputRelayViewModel);
            }
        }

        public SignalParameterNode Parameter { get; private set; }

        public bool IsMappingsChanged
        {
            get
            {
                return DiscreteInputs.Values.Any(discreteInput => discreteInput.IsCheckedChanged) ||
                       DigitalInputs.Values.Any(digitalInput => digitalInput.IsCheckedChanged) ||
                       OutputRelays.Values.Any(outputRelay => outputRelay.IsCheckedChanged);
            }
        }

        public string Designation
        {
            get
            {
                return _designation;
            }
            set
            {
                Set(ref _designation, value);
            }
        }
        private string _designation;

        public string Note
        {
            get
            {
                return _note;
            }
            set
            {
                Set(ref _note, value);
            }
        }
        private string _note;

        public ParameterType Type
        {
            get
            {
                return _type;
            }
            set
            {
                Set(ref _type, value);
            }
        }
        private ParameterType _type;

        public uint Id
        {
            get
            {
                return _id;
            }
            set
            {
                Set(ref _id, value);
            }
        }
        private uint _id;

        public Dictionary<string, DiscreteInputViewModel> DiscreteInputs { get; private set; } = new Dictionary<string, DiscreteInputViewModel>();

        public Dictionary<string, DigitalInputViewModel> DigitalInputs { get; private set; } = new Dictionary<string, DigitalInputViewModel>();

        public Dictionary<string, OutputRelayViewModel> OutputRelays { get; private set; } = new Dictionary<string, OutputRelayViewModel>();

        public SignalMapping BuildSignalMapping()
        {
            SignalMapping mapping = new SignalMapping(Parameter.ParameterName);

            if (Parameter.ParameterType == ParameterType.Input || Parameter.ParameterType == ParameterType.InputOutput)
            {
                mapping.DigitalInputs.AddRange(DigitalInputs
                    .Where(digitalInput => digitalInput.Value.Checked)
                    .Select(digitalInput => digitalInput.Key));

                mapping.DiscreteInputs.AddRange(DiscreteInputs
                    .Where(discreteInput => discreteInput.Value.Checked)
                    .Select(discreteInput => discreteInput.Key));
            }

            if (Parameter.ParameterType == ParameterType.Output || Parameter.ParameterType == ParameterType.InputOutput)
            {
                mapping.OutputRelays.AddRange(OutputRelays
                    .Where(outputRelay => outputRelay.Value.Checked)
                    .Select(outputRelay => outputRelay.Key));
            }

            return mapping;
        }

        public void Initialize(SignalMapping signalMapping)
        {
            Reset();

            foreach (var discreteInput in signalMapping.DiscreteInputs)
            {
                if (DiscreteInputs.ContainsKey(discreteInput))
                {
                    DiscreteInputs[discreteInput].Checked = true;
                }
            }

            foreach (var digitalInput in signalMapping.DigitalInputs)
            {
                if (DigitalInputs.ContainsKey(digitalInput))
                {
                    DigitalInputs[digitalInput].Checked = true;
                }
            }

            foreach (var outputRelays in signalMapping.OutputRelays)
            {
                if (OutputRelays.ContainsKey(outputRelays))
                {
                    OutputRelays[outputRelays].Checked = true;
                }
            }
        }

        public void Reset()
        {
            foreach (var discreteInput in DiscreteInputs.Values)
            {
                discreteInput.Checked = false;
            }

            foreach (var digitalInput in DigitalInputs.Values)
            {
                digitalInput.Checked = false;
            }

            foreach (var outputRelays in OutputRelays.Values)
            {
                outputRelays.Checked = false;
            }
        }

        public void Commit()
        {
            foreach (var discreteInput in DiscreteInputs.Values)
            {
                discreteInput.Commit();
            }

            foreach (var digitalInput in DigitalInputs.Values)
            {
                digitalInput.Commit();
            }

            foreach (var outputRelay in OutputRelays.Values)
            {
                outputRelay.Commit();
            }
        }

        private void DiscreteInputViewModel_CheckedChanged(object sender, EventArgs e)
        {
            if (((DiscreteInputViewModel)sender).Checked)
            {
                foreach (var viewModel in DiscreteInputs.Values)
                {
                    if (viewModel != sender)
                        viewModel.Checked = false;
                }

                Parameter.DiscreteInput = ((DiscreteInputViewModel)sender).Name;
            }
            else
            {
                Parameter.DiscreteInput = null;
            }
        }

        private void DigitalInputViewModel_CheckedChanged(object sender, EventArgs e)
        {
            if (((DigitalInputViewModel)sender).Checked)
            {
                foreach (var viewModel in DigitalInputs.Values)
                {
                    if (viewModel != sender)
                        viewModel.Checked = false;
                }
                Parameter.DigitalInput = ((DigitalInputViewModel)sender).Name;
            }
            else
            {
                Parameter.DigitalInput = null;
            }
        }

        private void OutputRelayViewModel_CheckedChanged(object sender, EventArgs e)
        {
            if (((OutputRelayViewModel)sender).Checked)
            {
                Parameter.OutputRelays.Add(((OutputRelayViewModel)sender).Name);
            }
            else
            {
                Parameter.OutputRelays.Remove(((OutputRelayViewModel)sender).Name);
            }
        }
    }
}
