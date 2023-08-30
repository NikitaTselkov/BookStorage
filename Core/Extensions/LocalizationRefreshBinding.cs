using System.Windows;
using System.Windows.Controls;

namespace Core.Extensions
{
    public class LocalizationRefreshBinding : ItemsControl
    {
        private static ItemsControl _currentItemsControl;

        public static bool GetIsNeedUpdateBindings(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsNeedUpdateBindingsProperty);
        }

        public static void SetIsNeedUpdateBindings(DependencyObject obj, bool value)
        {
            obj.SetValue(IsNeedUpdateBindingsProperty, value);
        }

        public static readonly DependencyProperty IsNeedUpdateBindingsProperty =
            DependencyProperty.RegisterAttached("IsNeedUpdateBindings", 
                typeof(bool),
                typeof(LocalizationRefreshBinding),
                new PropertyMetadata(IsNeedUpdateBindingsChanged));

        private static void IsNeedUpdateBindingsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ItemsControl itemsControl)
            {
                _currentItemsControl = itemsControl;

                if ((bool)e.NewValue == true)   
                    TranslationSource.Instance.PropertyChanged += Culture_PropertyChanged;
                else
                    TranslationSource.Instance.PropertyChanged -= Culture_PropertyChanged;
            }
        }

        private static void Culture_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _currentItemsControl?.Items.Refresh();
        }
    }
}
