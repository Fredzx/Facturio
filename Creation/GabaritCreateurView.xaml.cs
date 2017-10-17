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

            DataContext = new GabaritCreateurViewModel();
        }
    }
}
