using GalaSoft.MvvmLight;
using System.Windows.Input;

namespace Common.ViewModels
{
    public class CommandViewModel : ViewModelBase
    {
        public CommandViewModel()
        {
        }

        public CommandViewModel(string header, ICommand command)
        {
            Header = header;
            Command = command;
        }

        public string Header
        {
            get { return _header; }
            protected set { Set(ref _header, value); }
        }
        private string _header;

        public ICommand Command
        {
            get { return _command; }
            protected set { Set(ref _command, value); }
        }
        private ICommand _command;
    }
}