using DevExpress.Xpf.Bars;
using SignalMatrixEditor.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.ViewModels.Nodes
{
    public class GroupNodeViewModel : NodeViewModel, IMockPropertiesForBinding
    {
        public GroupNodeViewModel(string name)
            : base(name) { }

        public GroupNodeViewModel(string name, IEnumerable<HardwareIO> discreteInputs,
            IEnumerable<HardwareIO> digitalInputs, IEnumerable<HardwareIO> outputRelays) : this(name)
        {
            foreach (var discreteInput in discreteInputs)
            {
                DiscreteInputViewModel discreteInputViewModel = new DiscreteInputViewModel(discreteInput, "");

                DiscreteInputs.Add(discreteInputViewModel.Name, discreteInputViewModel);
            }

            foreach (var digitalInput in digitalInputs)
            {
                DigitalInputViewModel digitalInputViewModel = new DigitalInputViewModel(digitalInput, "");

                DigitalInputs.Add(digitalInputViewModel.Name, digitalInputViewModel);
            }

            foreach (var outputRelay in outputRelays)
            {
                OutputRelayViewModel outputRelayViewModel = new OutputRelayViewModel(outputRelay, "");                

                OutputRelays.Add(outputRelayViewModel.Name, outputRelayViewModel);
            }
        }

        public List<NodeViewModel> Nodes
        {
            get;
            private set;
        } = new List<NodeViewModel>();

        public string Note => "";

        public Dictionary<string, DiscreteInputViewModel> DiscreteInputs { get; private set; } = new Dictionary<string, DiscreteInputViewModel>();

        public Dictionary<string, DigitalInputViewModel> DigitalInputs { get; private set; } = new Dictionary<string, DigitalInputViewModel>();

        public Dictionary<string, OutputRelayViewModel> OutputRelays { get; private set; } = new Dictionary<string, OutputRelayViewModel>();
    }
}
