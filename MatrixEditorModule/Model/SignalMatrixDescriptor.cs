using SignalMatrixEditor.Model.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Model
{
    /// <summary>
    /// Описатель матрицы сигналов
    /// </summary>
    public class SignalMatrixDescriptor
    {
        public List<SignalNode> SignalTree { get; private set; } = new List<SignalNode>();

        public List<HardwareIO> DigitalInputs { get; private set; } = new List<HardwareIO>();

        public List<HardwareIO> DiscreteInputs { get; private set; } = new List<HardwareIO>();

        public List<HardwareIO> OutputRelays { get; private set; } = new List<HardwareIO>();
    }
}
