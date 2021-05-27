using Common.Utilities.SecurityUtilities;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Common.Converters
{
    /// <summary>
    /// Конвертер пароля в хэш пароля
    /// </summary>
    public class PasswordToHashConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Hash.GetMd5Hash(value != null ? (string)value : string.Empty);
        }
    }
}
