using SignalMatrixEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.DumbImplementations
{
    public static class SignalMatrixManagerConfiguratorExtension
    {
        public static SignalMatrixManagerConfigurator UseDumpDevice(this SignalMatrixManagerConfigurator configurator)
        {
            return configurator.UseDevice(new DumbDevice("DeviceSignalMatrix.json"));
        }

        public static SignalMatrixManagerConfigurator UseDumpProjectDb(this SignalMatrixManagerConfigurator configurator)
        {
            return configurator.UseProjectDb(new ConcreteFileSignalMatrixRepository("ProjectDbSignalMatrix.json"));
        }
    }
}
