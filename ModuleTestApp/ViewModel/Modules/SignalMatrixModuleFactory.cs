using DevExpress.Mvvm;
using SignalMatrixEditor.DumbImplementations;
using SignalMatrixEditor.Model;
using SignalMatrixEditor.Model.Nodes;
using SignalMatrixEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTestApp.ViewModel.Modules
{
    public class SignalMatrixModuleFactory : ModuleFactoryViewModelBase
    {
        public SignalMatrixModuleFactory(string moduleName)
            : base(moduleName) { }

        public override ViewModelBase Create()
        {
            List<HardwareIO> descreteInputs = new List<HardwareIO>
            {
                new HardwareIO("1B1", 1),
                new HardwareIO("1B2", 2),
                new HardwareIO("1B3", 3),
                new HardwareIO("1B4", 4),
                new HardwareIO("1B5", 5)
            };

            List<HardwareIO> digitalInputs = new List<HardwareIO>
            {
                new HardwareIO("5", 6),
                new HardwareIO("6", 7),
                new HardwareIO("7", 8),
            };

            List<HardwareIO> outputRelays = new List<HardwareIO>
            {
                new HardwareIO("2К1", 9),
                new HardwareIO("2К2", 10),
                new HardwareIO("2К3", 11),
                new HardwareIO("2К4", 12),
                new HardwareIO("2К5", 13)
            };

            SignalMatrixDescriptor signalMatrixDescriptor = new SignalMatrixDescriptor();

            signalMatrixDescriptor.SignalTree.AddRange(DataSource());
            signalMatrixDescriptor.DiscreteInputs.AddRange(descreteInputs);
            signalMatrixDescriptor.DigitalInputs.AddRange(digitalInputs);
            signalMatrixDescriptor.OutputRelays.AddRange(outputRelays);

            SignalMatrixManagerViewModel signalMatrixManagerViewModel = new SignalMatrixManagerViewModel(signalMatrixDescriptor);

            signalMatrixManagerViewModel.Configure(configurator =>
                configurator.UseDumpDevice()
                    .UseDumpProjectDb());

            signalMatrixManagerViewModel.Initialize();

            return signalMatrixManagerViewModel;
        }

        public static IEnumerable<SignalNode> DataSource()
        {
            SignalGroupNode commonGroup = new SignalGroupNode("Общие");

            commonGroup.Nodes.Add(new SignalParameterNode("", 1, "cmdCls", "Команда ВКЛ", "Команда ВКЛ", ParameterType.Input));
            commonGroup.Nodes.Add(new SignalParameterNode("", 2, "cmdOpn", "Команда ОТКЛ", "Команда ОТКЛ", ParameterType.Input));
            commonGroup.Nodes.Add(new SignalParameterNode("", 3, "LocKey", "Ключ М/Д", "Ключ М/Д", ParameterType.Input));
            commonGroup.Nodes.Add(new SignalParameterNode("", 4, "posCls", "РПВ", "РПВ", ParameterType.Input));
            commonGroup.Nodes.Add(new SignalParameterNode("", 5, "posOpn", "РПО", "РПО", ParameterType.Input));
            commonGroup.Nodes.Add(new SignalParameterNode("", 6, "reCB", "Готовность выкл.", "Готовность выкл.", ParameterType.Input));
            commonGroup.Nodes.Add(new SignalParameterNode("", 7, "keyRREC", "Ключ вывода АПВ", "Ключ вывода АПВ", ParameterType.Input));

            SignalGroupNode tznpGroup = new SignalGroupNode("Блок ТЗНП-1");

            SignalGroupNode mtzGroup = new SignalGroupNode("МТЗ-1");

            mtzGroup.Nodes.Add(new SignalParameterNode("МТЗ-1_В", 8, "SGF1", "Ввод", "Ввод", ParameterType.Input));
            mtzGroup.Nodes.Add(new SignalParameterNode("МТЗ-1_П", 9, "SGF2", "Пуск", "Пуск", ParameterType.Output));
            mtzGroup.Nodes.Add(new SignalParameterNode("МТЗ-1_С", 10, "SGF3", "Срабатывание", "Срабатывание", ParameterType.Output));
            mtzGroup.Nodes.Add(new SignalParameterNode("МТЗ-1_АУ", 11, "SGF4", "Автоматическое ускорение", "Автоматическое ускорение", ParameterType.Output));

            return new List<SignalNode>
            {
                commonGroup, tznpGroup, mtzGroup
            };
        }
    }
}
