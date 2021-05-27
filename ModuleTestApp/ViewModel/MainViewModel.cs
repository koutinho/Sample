using DevExpress.Mvvm;
using ModuleTestApp.ViewModel.Modules;
using SignalMatrixEditor.DumbImplementations;
using SignalMatrixEditor.Model;
using SignalMatrixEditor.Model.Nodes;
using SignalMatrixEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text.RegularExpressions;

namespace ModuleTestApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    /// 
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            RegisterModules();

            ApplicationClosedCommand = new DelegateCommand(ApplicationClosed);
            ModuleSelectedCommand = new DelegateCommand(ModuleSelected);
        }

        public string Title { get; set; } = "Заголовок";

        public List<ModuleFactoryViewModelBase> Modules { get; set; }

        public ModuleFactoryViewModelBase SelectedModuleFactory { get; set; }

        public ViewModelBase CurrentModule
        {
            get
            {
                return currentModule;
            }
            set
            {
                SetValue(ref currentModule, value);
            }
        }
        private ViewModelBase currentModule;

        public DelegateCommand ModuleSelectedCommand { get; set; }

        public DelegateCommand ApplicationClosedCommand { get; set; }

        private void ApplicationClosed()
        {
            if (CurrentModule == null)
                return;

            if (CurrentModule is SignalMatrixManagerViewModel)
            {
                ((SignalMatrixManagerViewModel)CurrentModule).DeInitialize();
            }
        }

        private void RegisterModules()
        {
            Modules = new List<ModuleFactoryViewModelBase>();

            Modules.Add(new SignalMatrixModuleFactory("Матрица сигналов"));
        }

        private void ModuleSelected()
        {
            CurrentModule = SelectedModuleFactory?.Create();
        }
    }
}