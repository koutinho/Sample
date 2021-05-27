using GalaSoft.MvvmLight;

namespace Common.ViewModels
{
    public abstract class ValidatableViewModelBase : ViewModelBase
    {
        virtual public bool IsValid => true;
    }
}