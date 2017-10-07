using System.Windows;
using System.Windows.Controls;

namespace Facturio.Gabarits.View
{
    public class GabaritControl : Control
    {
        static GabaritControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GabaritControl), new FrameworkPropertyMetadata(typeof(GabaritControl)));
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(GabaritControl), new PropertyMetadata(""));
    }
}
