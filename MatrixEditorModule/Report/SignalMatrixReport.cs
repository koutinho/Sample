using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using SignalMatrixEditor.Model;
using SignalMatrixEditor.ViewModels.Nodes;
using System.Linq;
using DevExpress.XtraReports.Parameters;

namespace SignalMatrixEditor.Report
{
    public partial class SignalMatrixReport : DevExpress.XtraReports.UI.XtraReport
    {
        public SignalMatrixReport()
        {
            InitializeComponent();
        }

        public SignalMatrixReport(SignalMatrixDescriptor signalMatrixDescriptor,
            IEnumerable<NodeViewModel> nodes, string devicePath, string deviceSerialNumber)
            :this()
        {
            SignalMatrixDescriptor = signalMatrixDescriptor;
            Parameters["ObjectPath"].Value = devicePath;
            Parameters["SerialNumber"].Value = deviceSerialNumber;
            DataSource = nodes.Select(node => ConvertToReportItem(node))
                .ToList(); 
        }

        private void SignalMatrixReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            PopulateDiscreteInputs(SignalMatrixDescriptor.DiscreteInputs);
            PopulateDigitalInputs(SignalMatrixDescriptor.DigitalInputs);
            PopulateOutputRelays(SignalMatrixDescriptor.OutputRelays);

            PopulateDiscreteInputMappings(SignalMatrixDescriptor.DiscreteInputs);
            PopulateDigitalInputMappings(SignalMatrixDescriptor.DigitalInputs);
            PopulateOutputRelayMappings(SignalMatrixDescriptor.OutputRelays);
        }

        private void PopulateDiscreteInputs(List<HardwareIO> discreteInputs)
        {
            DiscreteInputHeaderLabel.WidthF = discreteInputs.Count * 50;
            DiscrteInputHeaderPanel.WidthF = discreteInputs.Count * 50;

            uint index = 0;

            foreach (var discreteInput in discreteInputs)
            {
                XRLabel discreteInputLabel = new XRLabel();
                discreteInputLabel.LocationF = new PointF(50 * index, 0);
                discreteInputLabel.WidthF = 50;
                discreteInputLabel.Font = new Font("Arial", 10F);
                discreteInputLabel.Text = discreteInput.Name;
                discreteInputLabel.HeightF = DiscrteInputHeaderPanel.HeightF;
                discreteInputLabel.Borders = DevExpress.XtraPrinting.BorderSide.All;
                discreteInputLabel.BackColor = Color.LightGray;
                DiscrteInputHeaderPanel.Controls.Add(discreteInputLabel);

                index++;
            }
        }

        private void PopulateDigitalInputs(List<HardwareIO> digitalInputs)
        {
            DigitalInputHeaderLabel.LocationF = new PointF(DiscreteInputHeaderLabel.LocationF.X + DiscreteInputHeaderLabel.WidthF,
                DigitalInputHeaderLabel.LocationF.Y);
            DigitalInputHeaderLabel.WidthF = digitalInputs.Count * 50;

            DigitalInputHeaderPanel.LocationF = new PointF(DiscrteInputHeaderPanel.LocationF.X + DiscrteInputHeaderPanel.WidthF,
                DigitalInputHeaderPanel.LocationF.Y);
            DigitalInputHeaderPanel.WidthF = digitalInputs.Count * 50;

            uint index = 0;

            foreach (var digitalinput in digitalInputs)
            {
                XRLabel digitalInputLabel = new XRLabel();
                digitalInputLabel.LocationF = new PointF(50 * index, 0);
                digitalInputLabel.WidthF = 50;
                digitalInputLabel.Font = new Font("Arial", 10F);
                digitalInputLabel.Text = digitalinput.Name;
                digitalInputLabel.HeightF = DiscrteInputHeaderPanel.HeightF;
                digitalInputLabel.Borders = DevExpress.XtraPrinting.BorderSide.All;
                digitalInputLabel.BackColor = Color.LightGray;
                DigitalInputHeaderPanel.Controls.Add(digitalInputLabel);

                index++;
            }
        }

        private void PopulateOutputRelays(List<HardwareIO> outputRelays)
        {
            OutputRelayHeaderLabel.LocationF = new PointF(DigitalInputHeaderLabel.LocationF.X + DigitalInputHeaderLabel.WidthF,
                OutputRelayHeaderLabel.LocationF.Y);
            OutputRelayHeaderLabel.WidthF = outputRelays.Count * 50;

            OutputRelayHeaderPanel.LocationF = new PointF(DigitalInputHeaderPanel.LocationF.X + DigitalInputHeaderPanel.WidthF,
                OutputRelayHeaderPanel.LocationF.Y);
            OutputRelayHeaderPanel.WidthF = outputRelays.Count * 50;

            uint index = 0;

            foreach (var outputRelay in outputRelays)
            {
                XRLabel outputRelayLabel = new XRLabel();
                outputRelayLabel.LocationF = new PointF(50 * index, 0);
                outputRelayLabel.WidthF = 50;
                outputRelayLabel.Font = new Font("Arial", 10F);
                outputRelayLabel.Text = outputRelay.Name;
                outputRelayLabel.HeightF = DiscrteInputHeaderPanel.HeightF;
                outputRelayLabel.Borders = DevExpress.XtraPrinting.BorderSide.All;
                outputRelayLabel.BackColor = Color.LightGray;
                OutputRelayHeaderPanel.Controls.Add(outputRelayLabel);

                index++;
            }
        }

        private void PopulateDiscreteInputMappings(List<HardwareIO> discreteInputs)
        {
            DiscreteInputPanel.WidthF = discreteInputs.Count * 50;

            uint index = 0;

            foreach (var discreteInput in discreteInputs)
            {
                DiscreteInputPanel.WidthF = discreteInputs.Count * 50;

                var discreteInputLabel = new XRLabel();
                discreteInputLabel.LocationF = new PointF(50 * index, 0);
                discreteInputLabel.WidthF = 50;
                discreteInputLabel.StyleName = "CrossCellStyle";

                discreteInputLabel.ExpressionBindings.AddRange(new ExpressionBinding[] {
                    new ExpressionBinding("BeforePrint", "Text", $"Iif([DiscreteInputs]==null, null, [DiscreteInputs][[Key] == '{discreteInput.Name}'].Single([Value]))")});

                DiscreteInputPanel.Controls.Add(discreteInputLabel);

                index++;
            }
        }

        private void PopulateDigitalInputMappings(List<HardwareIO> digitalInputs)
        {
            DigitalInputPanel.WidthF = digitalInputs.Count * 50;

            uint index = 0;

            DigitalInputPanel.LocationF = new PointF(DiscreteInputPanel.LocationF.X + DiscreteInputPanel.WidthF,
                DigitalInputPanel.LocationF.Y);

            foreach (var digitalInput in digitalInputs)
            {
                DigitalInputPanel.WidthF = digitalInputs.Count * 50;

                var digitalInputLabel = new XRLabel();
                digitalInputLabel.LocationF = new PointF(50 * index, 0);
                digitalInputLabel.WidthF = 50;
                digitalInputLabel.StyleName = "CrossCellStyle";

                digitalInputLabel.ExpressionBindings.AddRange(new ExpressionBinding[] {
                    new ExpressionBinding("BeforePrint", "Text", $"Iif([DigitalInputs]==null, null, [DigitalInputs][[Key] == '{digitalInput.Name}'].Single([Value]))")});

                DigitalInputPanel.Controls.Add(digitalInputLabel);

                index++;
            }
        }

        private void PopulateOutputRelayMappings(List<HardwareIO> outputRelays)
        {
            OutputRelayPanel.WidthF = outputRelays.Count * 50;

            uint index = 0;

            OutputRelayPanel.LocationF = new PointF(DigitalInputPanel.LocationF.X + DigitalInputPanel.WidthF,
                OutputRelayPanel.LocationF.Y);

            foreach (var outputRelay in outputRelays)
            {
                OutputRelayPanel.WidthF = outputRelays.Count * 50;

                var outputRelayLabel = new XRLabel();
                outputRelayLabel.LocationF = new PointF(50 * index, 0);
                outputRelayLabel.WidthF = 50;
                outputRelayLabel.StyleName = "CrossCellStyle";

                outputRelayLabel.ExpressionBindings.AddRange(new ExpressionBinding[] {
                    new ExpressionBinding("BeforePrint", "Text", $"Iif([OutputRelays]==null, null, [OutputRelays][[Key] == '{outputRelay.Name}'].Single([Value]))")});

                OutputRelayPanel.Controls.Add(outputRelayLabel);

                index++;
            }
        }

        public SignalMatrixDescriptor SignalMatrixDescriptor { get; set; }

        private SignalMappingReportItem ConvertToReportItem(NodeViewModel node)
        {
            SignalMappingReportItem item = new SignalMappingReportItem();
            item.Name = node.Name;

            if (node is GroupNodeViewModel)
            {
                item.Nodes = ((GroupNodeViewModel)node).Nodes
                    .Select(child => ConvertToReportItem(child))
                    .ToList();
            }
            if (node is ParameterNodeViewModel)
            {
                ParameterNodeViewModel parameterNode = (ParameterNodeViewModel)node;

                item.Designation = parameterNode.Designation;
                item.ParameterType = parameterNode.Type;
                item.DiscreteInputs = parameterNode.DiscreteInputs
                    .ToDictionary(record => record.Key, record => record.Value.Checked ? "X" : "");
                item.DigitalInputs = parameterNode.DigitalInputs
                    .ToDictionary(record => record.Key, record => record.Value.Checked ? "X" : "");
                item.OutputRelays = parameterNode.OutputRelays
                    .ToDictionary(record => record.Key, record => record.Value.Checked ? "X" : "");
            }

            return item;
        }
    }
}
