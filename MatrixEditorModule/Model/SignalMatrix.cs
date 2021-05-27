using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Model
{
    /// <summary>
    /// Матрица сигналов
    /// </summary>
    public class SignalMatrix
    {
        public List<SignalMapping> SignalMappings { get; private set; } = new List<SignalMapping>();
    }
}
