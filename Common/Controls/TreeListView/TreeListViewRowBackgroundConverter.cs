using System;
using System.Windows.Media;
using System.Windows.Data;

namespace Common.Controls.TreeListView
{
    public class TreeListViewRowBackgroundConverter : IValueConverter
    {
        private static int count;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TreeListViewItem item = value as TreeListViewItem;

            if (item.Items.Count == 0)
            {
                if ((count++) % 2 == 0)
                {
                    return Brushes.White;
                }
                else
                {
                    return new SolidColorBrush(Color.FromArgb(0xFF, 0xED, 0xED, 0xED));
                }
            }
            else
            {
                return new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
