using SignalMatrixEditor.Model;
using SignalMatrixEditor.Model.Device;
using SignalMatrixEditor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.ViewModels
{
    public class SignalMatrixManagerConfigurator
    {
        public SignalMatrixManagerConfigurator(SignalMatrixManagerViewModel signalMatrixManagerViewModel)
        {
            this.signalMatrixManagerViewModel = signalMatrixManagerViewModel;
        }

        public SignalMatrixManagerConfigurator UseDevice(IDevice device)
        {
            signalMatrixManagerViewModel.UseDevice(device);
            return this;
        }

        public SignalMatrixManagerConfigurator UseProjectDb(ISignalMatrixRepository projectDb)
        {
            signalMatrixManagerViewModel.ProjectDbSignalMatrixRepository = projectDb;
            return this;
        }

        private SignalMatrixManagerViewModel signalMatrixManagerViewModel;
    }
}
