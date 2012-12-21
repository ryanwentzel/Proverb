using System.Windows;
using System.Windows.Controls;

namespace Proverb.Helpers
{
    public sealed class Text
    {
        public static readonly DependencyProperty UppercaseProperty =
            DependencyProperty.RegisterAttached(
            "Uppercase", 
            typeof(bool), 
            typeof(HeaderedItemsControl), 
            new FrameworkPropertyMetadata(
                false, 
                FrameworkPropertyMetadataOptions.AffectsRender, 
                new PropertyChangedCallback(OnPropertyChanged)));

        private Text()
        {
        }

        public static bool GetUppercase(DependencyObject source)
        {
            return (bool)source.GetValue(UppercaseProperty);
        }

        public static void SetUppercase(DependencyObject source, bool value)
        {
            source.SetValue(UppercaseProperty, value);
        }

        private static void OnPropertyChanged(DependencyObject element, DependencyPropertyChangedEventArgs args)
        {
            var control = element as HeaderedItemsControl;
            if (control != null)
            {
                control.Loaded += OnControlLoaded;
                TransformText(control);
            }
        }

        static void OnControlLoaded(object sender, RoutedEventArgs e)
        {
            var control = sender as HeaderedItemsControl;

            bool uppercase = (bool)control.GetValue(UppercaseProperty);
            if (uppercase)
            {
                TransformText(control);
            }
        }

        private static void TransformText(HeaderedItemsControl control)
        {
            var header = control.Header as string;
            if (header == null || header.Length == 0) return;

            control.Header = header.ToUpper();
        }
    }
}
