using Core.Enums;
using Core.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
    }

    public class SelectedThemeRowStyleSelector : StyleSelector
    {
        private Style _selectedThemeStyle { get; init; }
        private BookThemes _selectedTheme { get; init; }

        public SelectedThemeRowStyleSelector(Style selectedThemeStyle, BookThemes selectedTheme)
        {
            _selectedThemeStyle = selectedThemeStyle;
            _selectedTheme = selectedTheme;
        }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (item is Book book)
            {
                if (book.Theme == _selectedTheme)
                {
                    return _selectedThemeStyle;
                }
            }

            return null;
        }
    }
}
