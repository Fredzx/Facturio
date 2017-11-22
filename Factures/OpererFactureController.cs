using Facturio.Base;
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
    class OpererFactureController : BaseViewModel, IOngletViewModel
    {
        public static Client LeClient { get; set; }
        public static Facture LaFacture { get; set; }
        public string Titre { get; set; }
        public OpererFactureController()
        {
            LeClient = new Client();
            LaFacture = new Facture();
            LaFacture.LstProduitFacture = new List<ProduitFacture>();
            Titre = "Opérer la facture";
        }

    }
}
