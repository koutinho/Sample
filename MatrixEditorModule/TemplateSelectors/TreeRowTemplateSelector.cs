using DevExpress.Xpf.Grid.TreeList;
using SignalMatrixEditor.ViewModels.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SignalMatrixEditor.TemplateSelectors
{
    public class TreeRowTemplateSelector : DataTemplateSelector
    {
        public DataTemplate GroupingTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            TreeListRowData rowData = item as TreeListRowData;

            if (rowData != null)
            {
                if (rowData.Row is GroupNodeViewModel)
                {
                    return GroupingTemplate;
                }
            }

            return null;
        }
    }
}
