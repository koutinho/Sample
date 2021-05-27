using GalaSoft.MvvmLight;
using SignalMatrixEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.ViewModels
{
    public class OutputRelayViewModel : CheckableItemViewModel
    {
        public OutputRelayViewModel(HardwareIO hardwareIO, string parameterName)
            : base(hardwareIO, parameterName) { }

        public OutputRelayViewModel(HardwareIO hardwareIO, string parameterName, bool isReadOnly)
            : base(hardwareIO, parameterName, isReadOnly) { }

        public override string Description
        {
            get
            {
                return Checked ? $"Прямая передача значения логической переменной \"{ParameterName}\" на реле \"{Name}\"."
                               : string.Empty;
            }
        }
    }
}
