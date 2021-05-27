using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Common.TemplateSelectors
{
    /// <summary>
    /// Обеспечивает выбор шаблона System.Windows.DataTemplate для ViewModel.
    /// Порядок выбора:
    /// 1. Поиск DataTemplate в ресурсах по типу ViewModel.
    ///    Функционал идентичный поведению по умолчанию без задания ContentTemplateSelector. Для выбора DataTemplate, заданных при помощи:
    ///    <DataTemplate DataType="{x:Type FooType}">
    ///        ...
    ///    </DataTemplate>
    /// 2. Поиск View по названию ViewModel и создание DataTemplate на основе найденного View.
    ///    Порядок поиска View:
    ///       a. Поиск View в сборке выполняющегося приложения.
    ///          Поиск View осуществляется в пространстве имен "<Имя приложения>.Views".
    ///       b. Поиск View в сборке, где находится ViewModel.
    ///          Если ViewModel находится в пространстве имен "...ViewModels...",
    ///          поиск View осуществляется в пространстве имен "...Views...",
    ///          иначе в пространстве имен, где находится ViewModel.
    ///       c. Поиск View в сборке, где находится ViewModel.
    ///          Поиск View осуществляется в пространстве имен "<Имя сборки>.Views".
    ///    Правила формирования названия View для поиска:
    ///       Если название ViewModel содержит подстроку "ViewModel",
    ///       то она заменяется на строку "View",
    ///       иначе к названию ViewModel добавляется строка "View".
    /// </summary>
    public class ViewModelTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Выбор DataTemplate для item.
        /// </summary>
        /// <param name="item">Объект данных, для которого необходимо выбрать DataTemplate.</param>
        /// <param name="container">Объект, привязанный к данным.</param>
        /// <returns>Возвращает шаблон System.Windows.DataTemplate или значение null.</returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
            {
                return null;
            }

            var viewModelType = item.GetType();

            // Поиск DataTemplate в ресурсах по типу ViewModel
            DataTemplate dataTemplate = TemplateSelectorUtils.FindDataTemplateForType(viewModelType, container);
            if (dataTemplate != null)
            {
                return dataTemplate;
            }

            // Поиск View по имени ViewModel
            var viewType = ViewForViewModel(viewModelType);
            if (viewType != null)
            {
                return new DataTemplate()
                {
                    VisualTree = new FrameworkElementFactory(viewType)
                };
            }

            return base.SelectTemplate(item, container);
        }

        #region Private

        private static Type ViewForViewModel(Type viewModelType)
        {
            Type viewType;
            if (viewTypeCache.TryGetValue(viewModelType, out viewType))
            {
                return viewType;
            }

            viewType =
                FindViewType(viewModelType, Assembly.GetEntryAssembly()) ??       // Поиск View в сборке выполняющегося приложения
                FindViewType(viewModelType) ??                                    // Поиск View в пространстве имен "...Views..." сборки, где находится ViewModel
                FindViewType(viewModelType, Assembly.GetAssembly(viewModelType)); // Поиск View в пространстве имен "<Имя сборки>.Views" сборки, где находится ViewModel

            viewTypeCache.Add(viewModelType, viewType);

            return viewType;
        }

        private static Type FindViewType(Type viewModelType, Assembly assembly = null)
        {
            var tempName = assembly != null
                ? assembly.GetName().Name + ".Views." + viewModelType.Name
                : viewModelType.FullName.Replace("ViewModels.", "Views.");

            var viewName = tempName.Contains("ViewModel") ?
                tempName.Replace("ViewModel", "View") :
                tempName + "View";

            return (assembly ?? viewModelType.Assembly).GetType(viewName);
        }

        private static readonly Dictionary<Type, Type> viewTypeCache = new Dictionary<Type, Type>();

        #endregion Private
    }
}
