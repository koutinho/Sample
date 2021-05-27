using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Common.Controls
{
    /// <summary>
    /// Компонент для отображения изображения из xaml-файла
    /// </summary>
    public partial class XamlImage : UserControl
    {
        public XamlImage()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(string), typeof(XamlImage), new FrameworkPropertyMetadata(OnSourceChanged));

        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        #region Private

        private static void OnSourceChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var xamlImage = dependencyObject as XamlImage;
            if (xamlImage != null)
            {
                xamlImage.Content = LoadXaml(xamlImage.Source);
            }
        }

        /// <summary>
        /// Загрузка xaml-файла
        /// </summary>
        private static object LoadXaml(string fileName)
        {
            try
            {
                return XamlReader.Parse(File.ReadAllText(fileName));
            }
            catch
            {
                return null;
            }
        }

        #endregion Private
    }
}
