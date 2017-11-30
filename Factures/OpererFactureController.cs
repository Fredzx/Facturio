using System;
using System.IO;
using System.Collections.Generic;
using Facturio.Base;
using Facturio.Clients;
using Facturio.ProduitsFactures;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows;

namespace Facturio.Factures
{
    class OpererFactureController : BaseViewModel, IOngletViewModel
    {
        public static Facture LaFacture { get; set; }
        public string Titre { get; set; }
        public static string Total { get; set; }
        public static string TPS { get; set; }
        public static string TVQ { get; set; }
        public static string SousTotal { get; set; }
        public static string Escompte { get; set; }

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

            return sousTotal * ((float)pourcentage/100);
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

        public static void GenererPdf(string nomFichier, string logoUrl)
        {
            var titreColonnes = new List<string>();
            foreach (var gc in OpererFacture.Gabarit.GabaritCriteres)
                if (gc.EstUtilise)
                    titreColonnes.Add(gc.Critere.Titre);

            GenerateurPdfFacture gen = new GenerateurPdfFacture(nomFichier, logoUrl, LaFacture, titreColonnes);
            if (gen.Go())
                MessageBox.Show("Création du fichier terminée!");
            else
                MessageBox.Show("Une erreur s'est produite lors de la création du fichier PDF.");
        }
    }
}
