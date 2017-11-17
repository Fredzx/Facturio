using System.Windows.Controls;
using Facturio.Base;

namespace Facturio.Creation
{
    /// <summary>
    /// Logique d'interaction pour GabaritCreateurLogo.xaml
    /// </summary>
    public partial class GabaritCreateurLogo : UserControl
    {
        public GabaritCreateurLogo()
        {
            InitializeComponent();
            GabaritCreateurController.Gabarits.TitreGabarit = "TestingName";
            lblTitreFacture.Content = GabaritCreateurController.Gabarits.TitreGabarit;
        }

        private void btnOuvrir_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Dire au controleur de changer de fenêtre
            GabaritCreateurController.AfficherInterfaceOperationFacture();
        }
    }
}
