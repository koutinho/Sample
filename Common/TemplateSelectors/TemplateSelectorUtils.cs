using System;
using System.Windows;

namespace Common.TemplateSelectors
{
    public static class TemplateSelectorUtils
    {
        public static DataTemplate FindDataTemplateForType(Type type, DependencyObject container)
        {
            if (type == typeof(object))
            {
                return null;
            }

            var frameworkElement = container as FrameworkElement;
            var dataTemplateKey = new DataTemplateKey(type);

            return frameworkElement?.TryFindResource(dataTemplateKey) as DataTemplate;
        }
    }
}
