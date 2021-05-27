using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;
using System.Threading.Tasks;
using System;
using Common.Interfaces;
using System.Windows.Input;

namespace Common.Controls.TreeListView
{
    public class TreeListView : TreeView
    {
        #region public

        public TreeListView()
        {
            Loaded += TreeListView_Loaded;
            PreviewKeyDown += TreeListView_PreviewKeyDown;
        }

        /// <summary> GridViewColumn List</summary>
        public GridViewColumnCollection Columns
        {
            get
            {
                if (_columns == null)
                {
                    _columns = new GridViewColumnCollection();
                }

                return _columns;
            }
        }
        private GridViewColumnCollection _columns;

        public static readonly DependencyProperty SelectedTreeListViewItemProperty = DependencyProperty.Register("SelectedTreeListViewItem", typeof(object), typeof(TreeListView));

        public object SelectedTreeListViewItem
        {
            get
            {
                return GetValue(SelectedTreeListViewItemProperty);
            }

            set
            {
                SetValue(SelectedTreeListViewItemProperty, value);
            }
        }

        public bool IsAllItemsExpanded
        {
            get
            {
                return _isAllItemsExpanded;
            }

            set
            {
                _isAllItemsExpanded = value;

                SetAllExpansionState();
            }
        }
        private bool _isAllItemsExpanded;

        public bool IsAutoWidth { get; set; } = true;

        #endregion public

        #region protected
        protected override DependencyObject GetContainerForItemOverride()
        {
            TreeListViewItem item = new TreeListViewItem();

            item.Expanded += (s, e) =>
            {
                SetColumnsAutoWidth();
            };

            return item;
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is TreeListViewItem;
        }

        protected override void OnSelectedItemChanged(RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedTreeListViewItem = SelectedItem;

            base.OnSelectedItemChanged(e);
        }
        #endregion protected

        private void SetAllExpansionState()
        {
            bool isAutoWidthSaveValue = IsAutoWidth;
            IsAutoWidth = false;

            if (ItemsSource != null)
            {
                foreach (var item in ItemsSource)
                {
                    TreeListViewItem treeListViewItem = ItemContainerGenerator.ContainerFromItem(item) as TreeListViewItem;

                    if (treeListViewItem != null)
                    {
                        treeListViewItem.IsExpanded = IsAllItemsExpanded;
                        Dispatcher.Invoke(new System.Action<TreeListViewItem>(SetSubTreeExpansionState), DispatcherPriority.Loaded, treeListViewItem);
                    }
                }
            }

            IsAutoWidth = isAutoWidthSaveValue;

            SetColumnsAutoWidth();
        }

        void SetSubTreeExpansionState(TreeListViewItem treeListViewItem)
        {
            if (treeListViewItem.ItemsSource != null)
            {
                foreach (var item in treeListViewItem.ItemsSource)
                {
                    TreeListViewItem childTreeListViewItem = treeListViewItem.ItemContainerGenerator.ContainerFromItem(item) as TreeListViewItem;

                    if (childTreeListViewItem != null)
                    {
                        childTreeListViewItem.IsExpanded = IsAllItemsExpanded;
                        Dispatcher.Invoke(new System.Action<TreeListViewItem>(SetSubTreeExpansionState), DispatcherPriority.Background, childTreeListViewItem);
                    }
                }
            }
        }

        private void SetColumnsAutoWidth()
        {
            if (IsAutoWidth)
            {
                // Без асинхронности не срабатывает на первый вызов
                // Видимо связанно с диспетчеризацией и отрисовкой
                SetColumnsAutoWidthAsync();
            }
        }

        private async Task SetColumnsAutoWidthAsync()
        {
            await Task.Run(
                new Action(
                    () =>
                    {
                    Dispatcher.Invoke(
                        () =>
                        {
                            foreach (var column in Columns)
                            {
                                if (double.IsNaN(column.Width))
                                {
                                    column.Width = column.ActualWidth;
                                }

                                column.Width = double.NaN;
                            }
                        }, DispatcherPriority.Render);
                    }
                )
            );
        }

        private void dataContext_ContentChanged(object sender, EventArgs e)
        {
            SetColumnsAutoWidthAsync();
        }

        // Обработчик нажатия "-" на NumPad. 
        // По-умолчанию сворачивает поддерево. В обработчике обеспечивается ввод значения в TextBox, DecimalTextBox.
        private void TreeListView_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Subtract && 
                (
                e.OriginalSource.GetType() == typeof(TextBox)
                || e.OriginalSource.GetType() == typeof(DecimalTextBox)
                ))
            {
                e.Handled = true;

                int lastLocation = ((TextBox)e.OriginalSource).SelectionStart;
                ((TextBox)e.OriginalSource).Text = ((TextBox)e.OriginalSource).Text.Insert(lastLocation, "-");
                ((TextBox)e.OriginalSource).SelectionStart = lastLocation + 1;
            }
        }

        private void TreeListView_Loaded(object sender, RoutedEventArgs e)
        {
            INotifyContentChanged dataContext = DataContext as INotifyContentChanged;

            if (dataContext != null)
            {
                dataContext.ContentChanged += dataContext_ContentChanged;
            }
        }
    }
}
