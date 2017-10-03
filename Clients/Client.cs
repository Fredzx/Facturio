using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facturio.Provinces;
using Facturio.Rangs;

namespace Facturio.Clients
{
    
    public class Client
    {
        public Province NomProvince { get; set; }
        
        public Rang LeRang { get; set; }

        public Client()
        {
            Client client = new Client();
        }
    }
}
