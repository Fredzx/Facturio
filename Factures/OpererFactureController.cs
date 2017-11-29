﻿using System;
using System.IO;
using System.Collections.Generic;
using Facturio.Base;
using Facturio.Clients;
using Facturio.ProduitsFactures;
using iTextSharp.text;
using iTextSharp.text.pdf;

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

        // TODO: Sur le clique du bouton on doit enregistrer la facture et réduire les quantités en BD.
        public static void GenererPdf(string nomFichier, string logoUrl)
        {
            // Création du fichier PDF
            FileStream fileStream = new FileStream($"{nomFichier}.pdf", FileMode.Create, FileAccess.Write);
            Document document = new Document();
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, fileStream);
            var titreColonnes = new List<string>();

            // Ouvre le document
            document.Open();

            // Le logo en haut à gauche
            Image logo = Image.GetInstance(new Uri(logoUrl));
            logo.ScaleToFit(100.0F, 100.0F);
            document.Add(logo);

            // Les informations du client en haut à droite
            Paragraph paragraph = new Paragraph(new Phrase($"Client: {LaFacture.LeClient.Nom}, {LaFacture.LeClient.Prenom}"));
            document.Add(paragraph);

            // Extrait le titre des colonnes utilisées par le gabarit
            foreach (var gc in OpererFacture.Gabarit.GabaritCriteres)
                if (gc.EstUtilise)
                    titreColonnes.Add(gc.Critere.Titre);

            // Création de la table pour les produits
            PdfPTable table = new PdfPTable(titreColonnes.Count);
            table.DefaultCell.Padding = 5;
            table.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;

            // La font pour les entêtes des colonnes
            Font font = new Font(Font.FontFamily.SYMBOL, 10, Font.BOLD);

            // Ajoute les entêtes
            foreach (var titre in titreColonnes)
            {
                var phrase = new Phrase(titre, font);
                var cell = new PdfPCell(phrase) { Padding = 5 };
                table.AddCell(cell);
            }

            // Ajoute les infos de chaque produit
            foreach (var pf in LaFacture.LstProduitFacture)
            {
                foreach (var titre in titreColonnes)
                {
                    switch (titre)
                    {
                        case "Quantité":
                            table.AddCell(pf.Quantite.ToString());
                            break;
                        case "Prix":
                            table.AddCell(pf.Produit.Prix.ToString());
                            break;
                        case "Nom produit":
                            table.AddCell(pf.Produit.Nom);
                            break;
                        case "Description":
                            table.AddCell(pf.Produit.Description);
                            break;
                        /*
                        case "Nombre d'heures":
                            // table.AddCell(pf.Produit.NombreHeures);
                            break;
                        case "Taux Horaire":
                            // table.AddCell(pf.Produit.TauxHoraire);
                            break;
                        */
                        default:
                            table.AddCell(string.Empty);
                            break;
                    }
                }
            }

            // Ajoute la table au document
            document.Add(table);

            // Ferme le document
            document.Close();
        }
    }
}
