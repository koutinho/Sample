using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Model.Verifiers
{
    public abstract class SignalMatrixVerifierBase : ISignalMatrixVerifier
    {
        public bool Verify(SignalMatrixDescriptor signalMatrixDescriptor)
        {
            string errorMessage;

            return Verify(signalMatrixDescriptor, out errorMessage);
        }

        public abstract bool Verify(SignalMatrixDescriptor signalMatrixDescriptor, out string errorMessage);
    }
}
