using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTestApp.ViewModel.Modules
{
    public abstract class ModuleFactoryViewModelBase : ViewModelBase
    {
        public ModuleFactoryViewModelBase(string moduleName)
        {
            ModuleName = moduleName;
        }

        public string ModuleName { get; set; }

        public abstract ViewModelBase Create();
    }
}
