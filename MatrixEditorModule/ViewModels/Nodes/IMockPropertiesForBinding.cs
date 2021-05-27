using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.ViewModels.Nodes
{
    /// <summary>
    /// Костыль, предоставляющий недостающие свойства для корректного
    /// срабатывания привязок (binding) в элементе grid
    /// </summary>
    public interface IMockPropertiesForBinding
    {
        string Note { get; }

        Dictionary<string, DiscreteInputViewModel> DiscreteInputs { get; }

        Dictionary<string, DigitalInputViewModel> DigitalInputs { get; }

        Dictionary<string, OutputRelayViewModel> OutputRelays { get; }
    }
}
