using Facturio.Clients;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

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

        //private void btnAssigner_Click(object sender, RoutedEventArgs e)
        //{
        //    //TODO: Transformer le client et l'envoyer à la facture
        //    Client c = (Client)dtgAfficheClient.SelectedItem;
        //}

        private void txtRechercherClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtRechercherClient.Text.ToString() == "")
            {
                AssignerClientController.LstClient = new ObservableCollection<Client>(HibernateClientService.RetrieveAll());
            }
            else
            {
                AssignerClientController.LiveFiltering(txtRechercherClient.Text.ToString());
            }

            AssignerClientController.RafraichirGrille();
        }
    }
}
