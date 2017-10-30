using System.Windows;
using System.Windows.Controls;

namespace Facturio.Creation
{
    /// <summary>
    /// Interaction logic for GabaritCreateurView.xaml
    /// </summary>
    public partial class GabaritCreateurView : UserControl
    {
        public GabaritCreateurView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var dc = DataContext;
            DataContext = null;
            DataContext = dc;

            //var lol = ItemsControlCriteres.ItemsSource;
            //ItemsControlCriteres.ItemsSource = null;
            //ItemsControlCriteres.ItemsSource = lol;
        }
    }
}
