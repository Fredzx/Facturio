﻿using System;
using System.IO;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Facturio.Clients;

namespace Facturio.Factures
{
    public class GenerateurPdfFacture
    {
        private FileStream fileStream;
        private Document document;
        private PdfWriter pdfWriter;
        private PdfPTable tableEntete;
        private PdfPTable tableProduit;

        private string nomFichier;
        private string imageUrl;
        private Facture facture;
        private List<string> titreColonnes;

        public GenerateurPdfFacture(string nomFichier, string imageUrl, Facture facture, List<string> titreColonnes)
        {
            this.nomFichier = nomFichier;
            this.imageUrl = imageUrl;
            this.facture = facture;
            this.titreColonnes = new List<string>(titreColonnes);
        }

        public bool Go()
        {
            try { CreerFichierPdf(); } catch { return false; }
            AjouteEntete();
            AjouteTableProduits();
            document.Close();
            return true;
        }

        private void CreerFichierPdf()
        {
            try
            {
                DateTime dt = DateTime.Now;
                fileStream = new FileStream($"{nomFichier}{dt.Millisecond}_{dt.Day}_{dt.Month}_{dt.Year}.pdf", FileMode.Create, FileAccess.Write);
            }
            catch { throw; }

            document = new Document();
            pdfWriter = PdfWriter.GetInstance(document, fileStream);
            document.Open();
        }

        private void AjouteEntete()
        {
            tableEntete = new PdfPTable(2) { WidthPercentage = 100, SpacingAfter = 25 };

            AjouteImage();
            AjouteInfoClient();

            document.Add(tableEntete);
        }

        private void AjouteImage()
        {
            PdfPCell cell;

            if (!string.IsNullOrEmpty(imageUrl))
            {
                Image image = Image.GetInstance(new Uri(imageUrl));
                image.ScaleToFit(100, 100);

                cell = new PdfPCell(image);
            }
            else
            {
                cell = new PdfPCell();
            }

            cell.Padding = 0;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = Rectangle.NO_BORDER;
            cell.FixedHeight = 100;

            tableEntete.AddCell(cell);
        }

        private void AjouteInfoClient()
        {
            Client client = facture.LeClient;
            string nomPrenom = $"Client: {client.Nom}, {client.Prenom}";

            PdfPCell cell = new PdfPCell(new Phrase(nomPrenom));
            cell.Padding = 0;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = Rectangle.NO_BORDER;
            cell.FixedHeight = 100;

            tableEntete.AddCell(cell);
        }

        private void AjouteTableProduits()
        {
            tableProduit = new PdfPTable(titreColonnes.Count);
            tableProduit.WidthPercentage = 100;
            tableProduit.DefaultCell.Padding = 5;
            tableProduit.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;

            AjouteEntetesProduits();
            AjouteRangeesProduits();

            document.Add(tableProduit);
        }

        private void AjouteEntetesProduits()
        {
            Font font = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD);

            foreach (var titre in titreColonnes)
            {
                var phrase = new Phrase(titre, font);
                var cell = new PdfPCell(phrase) { Padding = 5 };
                tableProduit.AddCell(cell);
            }
        }

        private void AjouteRangeesProduits()
        {
            Font font = new Font(Font.FontFamily.TIMES_ROMAN, 10, Font.NORMAL);

            foreach (var pf in facture.LstProduitFacture)
            {
                foreach (var titre in titreColonnes)
                {
                    switch (titre)
                    {
                        case "Quantité":
                            tableProduit.AddCell(pf.Quantite.ToString());
                            break;
                        case "Prix":
                            tableProduit.AddCell(pf.Produit.Prix.ToString());
                            break;
                        case "Nom produit":
                            tableProduit.AddCell(pf.Produit.Nom);
                            break;
                        case "Description":
                            tableProduit.AddCell(pf.Produit.Description);
                            break;
                        /*
                        case "Nombre d'heures":
                            // tableProduit.AddCell(pf.Produit.NombreHeures);
                            break;
                        case "Taux Horaire":
                            // tableProduit.AddCell(pf.Produit.TauxHoraire);
                            break;
                        */
                        default:
                            tableProduit.AddCell(string.Empty);
                            break;
                    }
                }
            }
        }
    }
}
