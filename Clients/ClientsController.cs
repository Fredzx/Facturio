using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facturio.Base;

namespace Facturio.Clients
{
    public class ClientsController : BaseViewModel, IOngletViewModel
    {
        public static ObservableCollection<Client> LstObClients { get; set; } = new ObservableCollection<Client>();
       // public static List<Client> LstClients { get; set; } = new List<Client>();

        public string Titre { get; set; }

        public ClientsController()
        {
            Titre = "Clients";
            ChargerListeClients();
        }

        public static void ChargerListeClients()
        {
            List<Client> lstClient = new List<Client>(HibernateClientService.RetrieveAll());

            foreach (Client client in lstClient)
                LstObClients.Add(client);

            //LstClients.AddRange(HibernateClientService.RetrieveAll());

        }

        public static void AjouterClient(Client client)
        {
            LstObClients.Add(client);
        }
    }
}
