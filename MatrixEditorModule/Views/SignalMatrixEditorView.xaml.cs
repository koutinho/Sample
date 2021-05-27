using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SignalMatrixEditor.Views
{
    /// <summary>
    /// Логика взаимодействия для SignalMatrixEditorView.xaml
    /// </summary>
    public partial class SignalMatrixEditorView : UserControl
    {
        public SignalMatrixEditorView()
        {
            InitializeComponent();

            ExpandAllButton.IsChecked = true;
        }

        private void GridControl_Loaded(object sender, RoutedEventArgs e)
        {
            ((TreeListView)MatrixGrid.View).BestFitColumns();
        }

        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is DockPanel)
            {
                ClickCheckEdit((DockPanel)sender);
            }
        }

        private void DockPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && sender is DockPanel)
            {
                ClickCheckEdit((DockPanel)sender);
            }
        }

        private void ClickCheckEdit(DockPanel panel)
        {
            foreach (object child in panel.Children)
            {
                if (child is CheckEdit)
                {
                    CheckEdit checkEdit = (CheckEdit)child;
                    checkEdit.IsChecked = !checkEdit.IsChecked;

                    return;
                }
            }
        }

        private void TriangleToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            (MatrixGrid.View as TreeListView)?.ExpandAllNodes();

            (MatrixGrid.View as TreeListView)?.BestFitColumns();
        }

        private void TriangleToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            (MatrixGrid.View as TreeListView)?.CollapseAllNodes();

            (MatrixGrid.View as TreeListView)?.BestFitColumns();
        }
    }
}
