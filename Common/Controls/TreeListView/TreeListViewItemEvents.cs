using Common.Extensions;
using System.Windows;

namespace Common.Controls.TreeListView
{
    public partial class TreeListViewItemEvents
    {
        //TODO: Надо изменить реализацию на более красивую.
        //Здесь сделано так по следующим причинам:
        //В TreeListViewResourceDictionary.xaml изначально для установки TreeListViewItem.IsSelected  использовался триггер
        //<Trigger Property = "IsKeyboardFocusWithin" Value="True">
        //    <Setter Property = "IsSelected" Value="True" />
        //</Trigger>-->
        //При наличии родительских элементов этот триггер не всегда срабатывает корректно.
        //
        //Решено сделать присвоение TreeListViewItem.IsSelected  в обработчике маршрутизируемого события, приходящего от вложенного UI элемента (TextBlock)
        //В ControlTemplate добавлена ссылка обрабочика события GotFocus, но у ResourceDictionary нет кода,
        //пришлось описать класс TreeListViewItemEvents и указать его в параметре x:Class="Common.Controls.TreeListView.TreeListViewItemEvents" библиотеки ресурсов

        public void TreeListViewItemGotFocus(object sender, RoutedEventArgs e)
        {
            TreeListViewItem treeListViewItem = (sender as DependencyObject)?.FindParent<TreeListViewItem>();

            if (treeListViewItem != null)
            {
                treeListViewItem.IsSelected = true;
            }

            e.Handled = true;           
        }
    }
}
