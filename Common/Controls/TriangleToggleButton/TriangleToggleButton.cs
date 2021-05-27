using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Common.Controls.TriangleToggleButton
{
    public class TriangleToggleButton : ToggleButton
    {
        public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(TriangleToggleButton));

        public Brush Fill
        {
            get
            {
                return (Brush)GetValue(FillProperty);
            }
            set
            {
                SetValue(FillProperty, value);
            }
        }

        public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register("Stroke", typeof(Brush), typeof(TriangleToggleButton));

        public Brush Stroke
        {
            get
            {
                return (Brush)GetValue(StrokeProperty);
            }
            set
            {
                SetValue(StrokeProperty, value);
            }
        }
    }
}
