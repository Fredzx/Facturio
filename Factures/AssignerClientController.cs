using Facturio.Base;
using Facturio.Clients;
using System.Collections.ObjectModel;

namespace Facturio.Factures
{
    public class AssignerClientController : BaseViewModel, IOngletViewModel
    {
        public static ObservableCollection<Client> LstClient { get; set; }
        public string Titre { get; set; }
        public AssignerClientController()
        {
            LstClient = new ObservableCollection<Client>(HibernateClientService.RetrieveAll());
            Titre = "Assigner un client à la facture";
        }

        public static void LiveFiltering(string filter)
        {
            LstClient = new ObservableCollection<Client>(HibernateClientService.RetrieveFilter(filter, 2));
        }

        public static void RafraichirGrille()
        {
            AssignerClient.DtgClientsFacture.ItemsSource = null;
            AssignerClient.DtgClientsFacture.ItemsSource = LstClient;
        }
    }
}
