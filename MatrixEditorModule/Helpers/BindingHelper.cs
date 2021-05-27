using DevExpress.Mvvm.ModuleInjection.Native;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SignalMatrixEditor.Helpers
{
    public static class BindingHelper
    {
        #region DiscreteInputPath
        public static string GetDiscreteInputPath(GridColumn gridColumn)
        {
            return (string)gridColumn.GetValue(DiscreteInputPathProperty);
        }
        public static void SetDiscreteInputPath(GridColumn gridColumn, string value)
        {
            gridColumn.SetValue(DiscreteInputPathProperty, value);
        }

        public static readonly DependencyProperty DiscreteInputPathProperty =
            DependencyProperty.RegisterAttached("DiscreteInputPath", typeof(string), typeof(BindingHelper), new PropertyMetadata((d, e) => {
                if (!string.IsNullOrWhiteSpace(e.NewValue as string))
                    ((GridColumn)d).Binding = new Binding($"RowData.Row.DiscreteInputs[{e.NewValue}]") { Mode = BindingMode.TwoWay }; }));
        #endregion

        #region DigitalInputPath
        public static string GetDigitalInputPath(GridColumn gridColumn)
        {
            return (string)gridColumn.GetValue(DigitalInputPathProperty);
        }
        public static void SetDigitalInputPath(GridColumn gridColumn, string value)
        {
            gridColumn.SetValue(DigitalInputPathProperty, value);
        }

        public static readonly DependencyProperty DigitalInputPathProperty =
            DependencyProperty.RegisterAttached("DigitalInputPath", typeof(string), typeof(BindingHelper), new PropertyMetadata((d, e) => {
                if (!string.IsNullOrWhiteSpace(e.NewValue as string))
                    ((GridColumn)d).Binding = new Binding($"RowData.Row.DigitalInputs[{e.NewValue}]") { Mode = BindingMode.TwoWay };
            }));
        #endregion

        #region OutputRelayPath
        public static string GetOutputRelayPath(GridColumn gridColumn)
        {
            return (string)gridColumn.GetValue(OutputRelayPathProperty);
        }
        public static void SetOutputRelayPath(GridColumn gridColumn, string value)
        {
            gridColumn.SetValue(OutputRelayPathProperty, value);
        }

        public static readonly DependencyProperty OutputRelayPathProperty =
            DependencyProperty.RegisterAttached("OutputRelayPath", typeof(string), typeof(BindingHelper), new PropertyMetadata((d, e) => {
                if (!string.IsNullOrWhiteSpace(e.NewValue as string))
                    ((GridColumn)d).Binding = new Binding($"RowData.Row.OutputRelays[{e.NewValue}]") { Mode = BindingMode.TwoWay };
            }));
        #endregion
    }
}
