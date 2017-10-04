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
            LstClients.Add(new Client("Jack", "444 rue alain", "Sparowlt", "M", "4508229945", "Gérant banque JACK", "J3KL2E", 0));
            LstClients.Add(new Client("Charles", "444 rue Paul pierre", "Belisle", "M", "4505144455", "Travail chez yuzu", "J4KL1S", 1));
            LstClients.Add(new Client("Paul", "555 rue lafontaine", "werterd", "M", "4508229945", "Aucun", "R2EG5H", 3));
        }


    }
}
