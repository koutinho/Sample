using SignalMatrixEditor.Model.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Model.Verifiers
{
    public class SignalMatrixDublicateVerifier : SignalMatrixVerifierBase
    {
        public override bool Verify(SignalMatrixDescriptor signalMatrixDescriptor, out string errorMessage)
        {
            var dublicateSignals = FlattenSignalTree(signalMatrixDescriptor.SignalTree)
                .GroupBy(node => node.ParameterName).Where(group => group.Count() > 1).ToList();

            if (dublicateSignals.Count > 0)
            {
                string dublicateSignalParameterNames = string.Join(", ", dublicateSignals.Select(signal => signal.Key));
                errorMessage = $"Следующие параметры встречаются более одного раза: \"{dublicateSignalParameterNames}\"";

                return false;
            }

            errorMessage = "";
            return true;
        }

        private static IEnumerable<SignalParameterNode> FlattenSignalTree(IEnumerable<SignalNode> signalTree)
        {
            foreach (var node in signalTree)
            {
                if (node is SignalParameterNode)
                {
                    yield return (SignalParameterNode)node;
                }
                else if (node is SignalGroupNode)
                {
                    IEnumerable<SignalParameterNode> childNodes = FlattenSignalTree(((SignalGroupNode)node).Nodes);

                    foreach (SignalParameterNode childNode in childNodes)
                    {
                        yield return childNode;
                    }
                }
            }
        }
    }
}
