using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Facturio.Gabarits.View
{
    public class GabaritControl : Control
    {
        static GabaritControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GabaritControl), new FrameworkPropertyMetadata(typeof(GabaritControl)));
        }

        #region Title DependencyProperty

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(GabaritControl), new PropertyMetadata(string.Empty));

        #endregion

        #region Command DependencyProperty
        /*
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(ICommand));
        */
        #endregion
    }
}
