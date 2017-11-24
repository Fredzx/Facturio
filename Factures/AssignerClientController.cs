using Facturio.Base;
using Facturio.Clients;
using Facturio.Produits;
using System.Collections.ObjectModel;

namespace Facturio.Factures
{
    public class AssignerClientController : BaseViewModel, IOngletViewModel
    {
        public static ObservableCollection<Client> Clients { get; set; }
        public string Titre { get; set; }
        public AssignerClientController()
        {
            Clients = new ObservableCollection<Client>(HibernateClientService.RetrieveAll());
            Titre = "Assigner un client à la facture";
        }

        public static void LiveFiltering(string filter)
        {
            Clients = new ObservableCollection<Client>(HibernateClientService.RetrieveFilter(filter));
        }

        public static void RafraichirGrille()
        {
            AssignerClient.DtgClientsFacture.ItemsSource = null;
            AssignerClient.DtgClientsFacture.ItemsSource = Clients;
        }

        public static void AssignerClientFacture()
        {
            if (ProduitsController.SiProduitSelectionne("l'assigner à la facture", AssignerClient.DtgClientsFacture))
            {
                Client c = (Client)AssignerClient.DtgClientsFacture.SelectedItem;
                OpererFactureController.LaFacture.LeClient = c;
                AssignerClient.DtgClientsFacture.SelectedIndex = -1;
            }
        }
    }
}
