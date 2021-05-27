using Common.Extensions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Common.Controls
{
    /// <summary>
    /// В Win8, Win10 в отличие от Win7 невозможно поменять цвет ComboBox установкой свойства Background
    /// Данный класс позводлет установить цвет ComboBox через поле Color
    /// </summary>
    public class ColoredComboBox : ComboBox
    {
        public ColoredComboBox()
        {
            Loaded += ColoredComboBox_Loaded;
        }

        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(SolidColorBrush), typeof(ColoredComboBox), new FrameworkPropertyMetadata(OnColorChanged));

        public SolidColorBrush Color
        {
            get
            {
                return (SolidColorBrush)GetValue(ColorProperty);
            }

            set
            {
                SetValue(ColorProperty, value);
            }
        }

        private void ColoredComboBox_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            border = this.FindChild<Border>();
        }

        private static void OnColorChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            ColoredComboBox coloredComboBox = dependencyObject as ColoredComboBox;

            if (coloredComboBox?.border != null)
            {
                coloredComboBox.border.Background = coloredComboBox.Color;
            }
        }

        private Border border;
    }
}
