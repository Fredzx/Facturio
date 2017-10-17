using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Clients
{
    public class ClientsController
    {
        public static List<Client> LstClients { get; set; } = new List<Client>();

        public ClientsController()
        {

        }

        public static void ChargerListeClients()
        {
            LstClients.AddRange(HibernateClientService.RetrieveAll());            
        }
    }
}
