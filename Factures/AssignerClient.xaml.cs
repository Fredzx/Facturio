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

        //private void btnAssigner_Click(object sender, RoutedEventArgs e)
        //{
        //    //TODO: Transformer le client et l'envoyer à la facture
        //    Client c = (Client)dtgAfficheClient.SelectedItem;
        //}

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
            OpererFactureController.LaFacture.LeClient = (Client)dtgAfficheClient.SelectedItem;
            BindingExpression binding = OpererFactureUserControl.TxtPrenom.GetBindingExpression(TextBlock.TextProperty);
            binding.UpdateSource();
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
    }
}
