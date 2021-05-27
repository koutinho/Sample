using System.Windows;
using System.Windows.Media;

namespace Common.Extensions
{
    public static class DependencyObjectExtentions
    {
        /// <summary>
        /// Ищет родительский элемент указанного типа ParentType.
        /// </summary>
        /// <typeparam name="ParentType">Тип искомого родительского элемента</typeparam>
        /// <param name="item">Элемент, для которого ищется родительский</param>
        /// <returns>Найденный родительский элемент. Если родительский элемент не найден, то возвращается null</returns>
        public static ParentType FindParent<ParentType>(this DependencyObject item) where ParentType : DependencyObject
        {
            if (item == null)
            {
                return null;
            }
            
            var parent = VisualTreeHelper.GetParent(item);
            
            return parent as ParentType ?? FindParent<ParentType>(parent);
        }

        /// <summary>
        /// Ищет дочерний элемент указанного типа ChildType.
        /// </summary>
        /// <typeparam name="ChildType">Тип искомого дочернего элемента</typeparam>
        /// <param name="root">Элемент в котором ищется дочерний</param>
        /// <returns>Найденный дочерний элемент. Если дочерний элемент не найден, то возвращается null</returns>
        public static ChildType FindChild<ChildType>(this DependencyObject root) where ChildType : DependencyObject
        {
            if (root == null)
            {
                return null;
            }

            var childrenCount = VisualTreeHelper.GetChildrenCount(root);
            for (int i = 0; i < childrenCount; ++i)
            {
                var child = VisualTreeHelper.GetChild(root, i);

                var foundChild = child as ChildType ?? FindChild<ChildType>(child);
                if (foundChild != null)
                {
                    return foundChild;
                }
            }

            return null;
        }
    }
}
