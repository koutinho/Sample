using System;
using System.Globalization;
using System.Windows.Data;

namespace Common.Converters
{
    public class TimeZoneIdConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var timeZoneId = value as string;
            if (!string.IsNullOrEmpty(timeZoneId))
            {
                try
                {
                    return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                }
                catch
                {}
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var timeZoneInfo = value as TimeZoneInfo;
            if (timeZoneInfo != null)
            {
                return timeZoneInfo.Id;
            }

            return null;
        }
    }
}
