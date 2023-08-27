using Core.Enums;
using System.Windows;
using System.Windows.Controls;

namespace Core.Extensions
{
    public partial class DataGridRowStyleSelectorBehavior
    {
        #region dp

        public static readonly DependencyProperty SelectedThemeProperty =
            DependencyProperty.Register("SelectedTheme",
                typeof(BookThemes),
                typeof(DataGridRowStyleSelectorBehavior),
                new PropertyMetadata(null));

        #endregion

        protected override void OnAttached()
        {
            AssociatedObject.Loaded += DataGrid_Loaded;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= DataGrid_Loaded;
        }

        private IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }
    }
}
