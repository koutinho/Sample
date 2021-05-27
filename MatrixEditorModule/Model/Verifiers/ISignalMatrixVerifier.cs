using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Model.Verifiers
{
    public interface ISignalMatrixVerifier
    {
        bool Verify(SignalMatrixDescriptor signalMatrixDescriptor);

        bool Verify(SignalMatrixDescriptor signalMatrixDescriptor, out string errorMessage);
    }
}
