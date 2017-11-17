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
    }
}
