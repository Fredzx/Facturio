using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facturio.Clients;
using Facturio.Gabarits;

namespace Facturio.Factures
{
    public class Facture
    {
        public virtual int? IdFacture { get; set; } = null;

        public virtual Client LeClient { get; set; } = new Client();

        public virtual DateTime? Date { get; set; } = null;


        public Facture() { }


        public Facture(Client client, DateTime date)
        {
            LeClient = client;
            Date = date;
        }

    }
}
