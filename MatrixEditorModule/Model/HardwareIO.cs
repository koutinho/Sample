using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Model
{
    public class HardwareIO
    {
        public HardwareIO(string name, uint id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; set; }

        public uint Id { get; set; }
    }
}
