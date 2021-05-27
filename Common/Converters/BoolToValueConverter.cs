using System;
using System.Windows.Data;

namespace Common.Converters
{
    /// <summary>
    /// Шаблон. Универсальный конвертер из значения булева типа в значение заданного типа
    /// </summary>

    public class BoolToValueConverter<T> : IValueConverter
    {
        public T TrueValue { get; set; }
        public T FalseValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is bool))
            {
                return FalseValue;
            }

            return value != null && (bool)value
                ? TrueValue
                : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null && value.Equals(TrueValue);
        }
    }
}
