using Facturio.GabaritsCriteres;
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

        private void btnSuivant_Click(object sender, RoutedEventArgs e)
        {
            // Dire au controleur de changer de fenêtre
            GabaritCreateurController.AfficherInterfaceCreationSuivante();

            // GabaritCreationConteneurView.AfficherGabaritCreateurLogo();
        }

        // TODO: Vérifier s'il est possible de faire en sorte que les checkbox soient des commandes à place d'événements direct dans le code-behind.
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GabaritCreateurViewModel.Colonnes.Add(new DataGridTextColumn { Header = ((CheckBox)sender).Content.ToString() });
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < GabaritCreateurViewModel.Colonnes.Count; ++i)
            {
                if (GabaritCreateurViewModel.Colonnes[i].Header == ((CheckBox)sender).Content)
                {
                    GabaritCreateurViewModel.Colonnes.RemoveAt(i);
                }
            }
        }
    }
}
