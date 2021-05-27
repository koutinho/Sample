using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.ViewModels.Nodes
{
    public abstract class NodeViewModel : ViewModelBase
    {
        public NodeViewModel(string name)
        {
            Name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                Set(ref _name, value);
            }
        }
        private string _name;
    }
}
