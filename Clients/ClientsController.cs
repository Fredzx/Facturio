using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Clients
{

    class ClientsController
    {
        public static List<Client> LstClients { get; set; } = new List<Client>();

        public ClientsController()
        {

        }

        public static void ChargerListeClients()
        {
            /*
            LstClients.Add(new Client("Jack", "444 rue alain", "Sparowlt", "M", "4508229945", "1002", "Gérant banque JACK"));
            LstClients.Add(new Client("Charles", "444 rue Paul pierre", "Belisle", "M", "4505144455", "1005", "Travail chez yuzu"));
            LstClients.Add(new Client("Paul", "555 rue lafontaine", "werterd", "M", "4508229945", "1002", "Aucun"));
            */
        }
    }
}
