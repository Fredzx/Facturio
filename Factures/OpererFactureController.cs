using Facturio.Clients;
using Facturio.Produits;
using Facturio.ProduitsFactures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Factures
{
    class OpererFactureController
    {
        public static Client LeClient { get; set; }
        public static Facture LaFacture { get; set; } = new Facture();
        OpererFactureController()
        {
            LeClient = new Client();
            LaFacture.LstProduitFacture = new List<ProduitFacture>();
        }

    }
}
