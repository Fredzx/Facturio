using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Clients
{
    public class ClientsController
    {
        public static ObservableCollection<Client> LstObClients { get; set; } = new ObservableCollection<Client>();
        public static List<Client> LstClients { get; set; } = new List<Client>();

        public ClientsController()
        {

        }

        public static void ChargerListeClients()
        {
            LstClients.AddRange(HibernateClientService.RetrieveAll());
            
        }

        public static void AjouterClient(Client client)
        {
            LstClients.Add(client);
        }
    }
}
