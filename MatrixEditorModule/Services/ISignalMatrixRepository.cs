using Microsoft.Win32;
using SignalMatrixEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Services
{
    public interface ISignalMatrixRepository
    {
        void Write(SignalMatrix signalMatrix);

        SignalMatrix Read();

        Task WriteAsync(SignalMatrix signalMatrix);

        Task<SignalMatrix> ReadAsync();
    }
}
