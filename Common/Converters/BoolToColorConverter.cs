using System.Windows.Media;

namespace Common.Converters
{
    /// <summary>
    /// Конвертер значения булевого типа в кисть с цветом
    /// Использует шаблон BoolToValueConverter <T>
    /// </summary>
    public class BoolToColorConverter : BoolToValueConverter<Brush>
    { };
}