using System.Windows;
using System.Windows.Controls.Primitives;

namespace Common.Controls.TreeListView
{
    /// <summary>
    /// Represents a control that can switch states in order to expand a node of a TreeListView.
    /// </summary>
    public class TreeListViewExpander : ToggleButton
    {
        static TreeListViewExpander()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListViewExpander), new FrameworkPropertyMetadata(typeof(TreeListViewExpander)));
        }
    }
}
