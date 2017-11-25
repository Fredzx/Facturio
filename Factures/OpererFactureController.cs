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

        private void ViderFacture()
        {
            LaFacture.LstProduitFacture.Clear();
        }

        private float CalculerSousTotal()
        {
            var sousTotal = 0.0F;

            foreach (var pf in LaFacture.LstProduitFacture)
                sousTotal += pf.Quantite * (float)pf.Produit.Prix;

            return sousTotal;
        }

        private float CalculerEscompte(float? pourcentage)
        {
            var sousTotal = CalculerSousTotal();

            return sousTotal * (float)pourcentage;
        }

        private float CalculerTps()
        {
            const float TPS = 0.05F;
            float MONTANT_SANS_ESCOMPTE = CalculerSousTotal() - CalculerEscompte(LeClient.Rang.Escompte);

            return MONTANT_SANS_ESCOMPTE * TPS;
        }

        private float CalculerTvq()
        {
            const float TVQ = 0.09975F;
            float MONTANT_SANS_ESCOMPTE = CalculerSousTotal() - CalculerEscompte(LeClient.Rang.Escompte);

            return MONTANT_SANS_ESCOMPTE * TVQ;
        }

        private float CalculerTotal()
        {
            return CalculerSousTotal() - CalculerEscompte(LeClient.Rang.Escompte) + CalculerTps() + CalculerTvq();
        }
    }
}
