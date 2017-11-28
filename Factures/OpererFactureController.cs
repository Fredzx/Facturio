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
        public static Facture LaFacture { get; set; }
        public string Titre { get; set; }
        public static string Total { get { return CalculerTotal().ToString(); } set { Total = value; } }
        public static string TPS { get { return CalculerTps().ToString(); } set { TPS = value; } }
        public static string TVQ { get { return CalculerTvq().ToString(); } set { TVQ = value; } }
        public static string SousTotal { get; set; }
        public static string Escompte { get { return CalculerEscompte(LaFacture.LeClient.Rang.Escompte).ToString(); } set { Escompte = value; } }

        public OpererFactureController()
        {
            LaFacture = new Facture()
            {
                LeClient = new Client()
                {
                    Rang = new Rang { Escompte = 0.0F }
                }
            };

            LaFacture.LstProduitFacture = new List<ProduitFacture>();
            Titre = "Opérer la facture";
        }

        public static float CalculerSousTotal()
        {
            var sousTotal = 0.0F;

            foreach (var pf in LaFacture.LstProduitFacture)
                sousTotal += pf.Quantite * (float)pf.Produit.Prix;

            return sousTotal;
        }

        public static float CalculerEscompte(float? pourcentage)
        {
            var sousTotal = CalculerSousTotal();

            if (pourcentage == null)
                return sousTotal;

            return sousTotal * (float)pourcentage;
        }

        public static float CalculerTps()
        {
            const float TPS = 0.05F;
            float MONTANT_SANS_ESCOMPTE = CalculerSousTotal() - CalculerEscompte(OpererFactureController.LaFacture.LeClient.Rang.Escompte);

            return MONTANT_SANS_ESCOMPTE * TPS;
        }

        public static float CalculerTvq()
        {
            const float TVQ = 0.09975F;
            float MONTANT_SANS_ESCOMPTE = CalculerSousTotal() - CalculerEscompte(OpererFactureController.LaFacture.LeClient.Rang.Escompte);

            return MONTANT_SANS_ESCOMPTE * TVQ;
        }

        public static float CalculerTotal()
        {
            return CalculerSousTotal() - CalculerEscompte(OpererFactureController.LaFacture.LeClient.Rang.Escompte) + CalculerTps() + CalculerTvq();
        }
    }
}
