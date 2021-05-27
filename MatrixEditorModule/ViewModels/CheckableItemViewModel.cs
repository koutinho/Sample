using GalaSoft.MvvmLight;
using SignalMatrixEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.ViewModels
{
    public abstract class CheckableItemViewModel : ViewModelBase
    {
        public CheckableItemViewModel(HardwareIO hardwareIO, string parameterName)
        {
            Name = hardwareIO.Name;
            Id = hardwareIO.Id;
            ParameterName = parameterName;
        }

        public CheckableItemViewModel(HardwareIO hardwareIO, string parameterName, bool isReadOnly)
            : this(hardwareIO, parameterName)
        {
            IsReadOnly = isReadOnly;
        }

        public uint Id
        {
            get
            {
                return _id;
            }
            set
            {
                Set(ref _id, value);
            }
        }
        private uint _id;

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

        public string ParameterName
        {
            get
            {
                return _parameterName;
            }
            set
            {
                Set(ref _parameterName, value);
            }
        }
        private string _parameterName;

        public bool Checked
        {
            get
            {
                return _checked;
            }

            set
            {
                bool oldValue = _checked;

                Set(ref _checked, value);

                if (oldValue != value)
                {
                    RaisePropertyChanged(() => IsCheckedChanged);
                    CheckedChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        private bool _checked;

        public bool IsCheckedChanged
        {
            get
            {
                return originValue != Checked;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return _isReadOnly;
            }

            set
            {
                Set(ref _isReadOnly, value);
            }
        }
        private bool _isReadOnly;

        public abstract string Description { get; }

        public event EventHandler<EventArgs> CheckedChanged;

        public void Commit()
        {
            originValue = Checked;
            RaisePropertyChanged(() => this.IsCheckedChanged);
        }

        private bool originValue;
    }
}
