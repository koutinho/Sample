using Common.Logging;
using DevExpress.Mvvm;
using DevExpress.XtraRichEdit.Layout.Engine;
using SignalMatrixEditor.Model;
using SignalMatrixEditor.Model.Nodes;
using SignalMatrixEditor.ViewModels.Nodes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.ViewModels
{
    public class SignalMatrixEditorViewModel : ViewModelBase
    {
        public SignalMatrixEditorViewModel(SignalMatrixDescriptor signalMatrixDescriptor)
        {
            DiscreteInputs = signalMatrixDescriptor.DiscreteInputs.ToList();
            DigitalInputs = signalMatrixDescriptor.DigitalInputs.ToList();
            OutputRelays = signalMatrixDescriptor.OutputRelays.ToList();

            NodeViewModels = FormNodeViewModelTree(signalMatrixDescriptor.SignalTree)
                .ToList();
        }

        public List<HardwareIO> DiscreteInputs
        {
            get; private set;
        }

        public List<HardwareIO> DigitalInputs
        {
            get; private set;
        }

        public List<HardwareIO> OutputRelays
        {
            get; private set;
        }

        public bool IsThereAnyDiscreteInputs
        {
            get
            {
                return DiscreteInputs.Count != 0;
            }
        }

        public bool IsThereAnyDigitalInputs
        {
            get
            {
                return DigitalInputs.Count != 0;
            }
        }

        public bool IsThereAnyOutputRelays
        {
            get
            {
                return OutputRelays.Count != 0;
            }
        }

        public List<NodeViewModel> NodeViewModels
        {
            get; private set;
        }

        public bool IsMatrixChanged
        {
            get
            {
                return parameterNodeViewModels.Values
                    .Any(parameter => parameter.IsMappingsChanged);
            }
        }

        public void Initialize(SignalMatrix signalMatrix)
        {
            Reset();

            foreach (var mapping in signalMatrix.SignalMappings)
            {
                if (parameterNodeViewModels.ContainsKey(mapping.ParameterName))
                {
                    parameterNodeViewModels[mapping.ParameterName].Initialize(mapping);
                }
            }
        }

        public void Reset()
        {
            foreach (var parameterNodeViewModel in parameterNodeViewModels.Values)
            {
                parameterNodeViewModel.Reset();
            }
        }

        public void Commit()
        {
            foreach (var parameterNodeViewModel in parameterNodeViewModels.Values)
            {
                parameterNodeViewModel.Commit();
            }
        }

        public SignalMatrix BuildSignalMatrix()
        {
            SignalMatrix signalMatrix = new SignalMatrix();

            foreach (ParameterNodeViewModel node in parameterNodeViewModels.Values)
            {
                signalMatrix.SignalMappings.Add(node.BuildSignalMapping());
            }

            return signalMatrix;
        }

        private Dictionary<string, ParameterNodeViewModel> parameterNodeViewModels = new Dictionary<string, ParameterNodeViewModel>();

        private IEnumerable<NodeViewModel> FormNodeViewModelTree(IEnumerable<SignalNode> nodeTree)
        {
            foreach (var node in nodeTree)
            {
                if (node is SignalGroupNode)
                {
                    GroupNodeViewModel nodeViewModel = new GroupNodeViewModel(node.Name, DiscreteInputs, DigitalInputs, OutputRelays);

                    IEnumerable<NodeViewModel> childNodeViewModelTree = FormNodeViewModelTree(((SignalGroupNode)node).Nodes);

                    nodeViewModel.Nodes.AddRange(childNodeViewModelTree);

                    yield return nodeViewModel;
                }
                else if (node is SignalParameterNode)
                {
                    SignalParameterNode parameterNode = (SignalParameterNode)node;

                    if (parameterNodeViewModels.ContainsKey(parameterNode.ParameterName))
                    {
                        logger.Warn($"Попытка добавить уже существующий параметр {parameterNode.ParameterName} ");
                        continue;
                    }

                    ParameterNodeViewModel nodeViewModel = new ParameterNodeViewModel(parameterNode, DiscreteInputs, DigitalInputs, OutputRelays);

                    parameterNodeViewModels.Add(nodeViewModel.Parameter.ParameterName, nodeViewModel);

                    yield return nodeViewModel;
                }
                else
                    logger.Warn($"Неизвестный тип узла {node.GetType()}");
            }
        }

        private ILog logger = LogManager.GetLogger<SignalMatrixManagerViewModel>();
    }
}
