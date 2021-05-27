using DevExpress.XtraReports.Parameters;
using GalaSoft.MvvmLight;
using SignalMatrixEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.ViewModels
{
    public class DigitalInputViewModel : CheckableItemViewModel
    {
        public DigitalInputViewModel(HardwareIO hardwareIO, string parameterName)
            : base(hardwareIO, parameterName) { }

        public DigitalInputViewModel(HardwareIO hardwareIO, string parameterName, bool isReadOnly)
            : base(hardwareIO, parameterName, isReadOnly) { }

        public override string Description
        {
            get
            {
                return Checked ? $"Прямая передача статуса дискретного входа \"{Name}\" в значение логической переменной \"{ParameterName}\"."
                               : string.Empty;
            }
        }
    }
}
