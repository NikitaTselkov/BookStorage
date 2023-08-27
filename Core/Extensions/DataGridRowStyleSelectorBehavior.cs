using Core.Enums;
using Core.Models;
using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;

namespace Core.Extensions
{
    public partial class DataGridRowStyleSelectorBehavior : Behavior<DataGrid>
    {
        public BookThemes SelectedTheme
        {
            get { return (BookThemes)GetValue(SelectedThemeProperty); }
            set { SetValue(SelectedThemeProperty, value); }
        }

        public Style SelectedThemeStyle { get; set; }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var row in GetDataGridRows(AssociatedObject))
            {
                if (row != null && row.Item is Book book)
                {
                    if (book.Theme == SelectedTheme)
                    {
                        row.Style = SelectedThemeStyle;
                    }
                }
            }
        }
    }
}
