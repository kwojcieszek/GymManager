using System.Windows;

namespace GymManager.Common
{
    public static class FocusHelper
    {
        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.RegisterAttached(
                "IsFocused", typeof(bool), typeof(FocusHelper),
                new UIPropertyMetadata(false, OnIsFocusedPropertyChanged));

        public static bool GetIsFocused(DependencyObject ctrl)
        {
            return (bool)ctrl.GetValue(IsFocusedProperty);
        }

        public static void SetIsFocused(DependencyObject ctrl, bool value)
        {
            ctrl.SetValue(IsFocusedProperty, value);
        }

        private static void OnIsFocusedPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var ctrl = (UIElement)d;

            if((bool)e.NewValue)
            {
                ctrl.Focus(); // Don't care about false values.
            }
        }
    }
}