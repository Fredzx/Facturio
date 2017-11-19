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
        }

        /*
        // TODO: Vérifier s'il est possible de faire en sorte que les checkbox soient des commandes à place d'événements direct dans le code-behind.
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var titreColonne = ((CheckBox)sender).Content.ToString();
            var dtgTxtCol = new DataGridTextColumn { Header = titreColonne };
            GabaritCreateurViewModel.Colonnes.Add(dtgTxtCol);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var colonnes = GabaritCreateurViewModel.Colonnes;

            for (int i = 0; i < colonnes.Count; ++i)
                if (colonnes[i].Header == ((CheckBox)sender).Content)
                    colonnes.RemoveAt(i);
        }
        */
    }
}
