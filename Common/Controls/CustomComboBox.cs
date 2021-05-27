using Common.Extensions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Common.Controls
{
    public class CustomComboBox : ComboBox
    {
        private const double ToggleButtonArrowOpacity = 0.1;
        private const double ToggleButtonArrowMouseOverOpacity = 1;

        public CustomComboBox()
        {
            Loaded += CustomComboBox_Loaded;
            MouseEnter += CustomComboBox_MouseEnter;
            MouseLeave += CustomComboBox_MouseLeave;
        }

        private void CustomComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            toggleButtonArrow = this.FindChild<ToggleButton>()?.FindChild<Path>();

            SetToggleButtonArrowOpacity(ToggleButtonArrowOpacity);
        }

        private void CustomComboBox_MouseEnter(object sender, MouseEventArgs e)
        {
            SetToggleButtonArrowOpacity(ToggleButtonArrowMouseOverOpacity);
        }

        private void CustomComboBox_MouseLeave(object sender, MouseEventArgs e)
        {
            SetToggleButtonArrowOpacity(ToggleButtonArrowOpacity);
        }

        private void SetToggleButtonArrowOpacity(double opacity)
        {
            if (toggleButtonArrow != null)
            {
                toggleButtonArrow.Opacity = opacity;
            }
        }

        private Path toggleButtonArrow;
    }
}
