using Facturio.Clients;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Facturio.Factures
{
    /// <summary>
    /// Logique d'interaction pour AssignerClient.xaml
    /// </summary>

    public partial class AssignerClient : UserControl
    {
        public static DataGrid DtgClientsFacture { get; set; } = new DataGrid();
        public AssignerClient()
        {
            InitializeComponent();
            DtgClientsFacture = dtgAfficheClient;
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = ((e.Row.GetIndex()) + 1).ToString();
        }

        private void txtRechercherClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtRechercherClient.Text.ToString() == "")
            {
                AssignerClientController.Clients = new ObservableCollection<Client>(HibernateClientService.RetrieveAll());
            }
            else
            {
                AssignerClientController.LiveFiltering(txtRechercherClient.Text.ToString());
            }

            AssignerClientController.RafraichirGrille();
        }

        private void btnAssigner_Click(object sender, RoutedEventArgs e)
        {
            if (dtgAfficheClient.SelectedIndex == -1)
            {
                MessageBox.Show("Vous devez sélectionner un client avant de l'associer à la facture.");
            }
            else
            {
                OpererFactureController.LaFacture.LeClient = (Client)dtgAfficheClient.SelectedItem;
                dtgAfficheClient.SelectedIndex = -1;
                //OpererFactureUserControl.TxtEscompte.Text = "Escompte: " + OpererFactureController.LaFacture.LeClient.Rang.Escompte.ToString() + " %";
                //OpererFactureUserControl.TxtNom.Text = "Nom: " + OpererFactureController.LaFacture.LeClient.Nom;
                //OpererFactureUserControl.TxtPrenom.Text = "Prénom: " + OpererFactureController.LaFacture.LeClient.Prenom;
                OpererFactureUserControl.RefreshAffichage();
                // TODO: Recalculer Prix (Escompte)
            }
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
    }
}
