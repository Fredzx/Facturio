using Facturio.Base;
using Facturio.Clients;
using Facturio.ProduitsFactures;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;

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

        // TODO: Sur le clique du bouton on doit enregistrer la facture et réduire les quantités en BD.
        public static void GenererPdf(string nomFichier, string logoUrl)
        {
            // Création du fichier PDF
            // TODO: Ajouter quelque chose d'unique à la fin du nom du fichier (Ex: Facture4.pdf)
            FileStream fileStream = new FileStream($"{nomFichier}.pdf", FileMode.Create, FileAccess.Write);
            Document document = new Document();
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, fileStream);
            // Nombre de colonnes qu'il y aura dans la facture
            var nombreColonnes = 0;

            // Ouvre le document
            document.Open();

            // Le logo en haut à gauche
            // TODO: Mettre l'URL vers le logo ici
            Image logo = Image.GetInstance(@"");
            logo.ScaleToFit(200.0F, 200.0F);
            logo.Alignment = Element.ALIGN_LEFT;
            document.Add(logo);

            // Les informations du client en haut à droite
            // Paragraph paragraph = new Paragraph(new Phrase($"{LeClient.Nom}, {LeClient.Prenom}"));
            Paragraph paragraph = new Paragraph(new Phrase("Sarrazin, Frédéric"));
            paragraph.Alignment = Element.ALIGN_RIGHT;
            document.Add(paragraph);

            // Détermine combien de colonnes ont a besoin
            foreach (var gc in OpererFacture.Gabarit.GabaritCriteres)
                if (gc.EstUtilise)
                    ++nombreColonnes;

            // Création de la table pour les produits
            PdfPTable table = new PdfPTable(nombreColonnes);
            table.DefaultCell.Padding = 5;

            // La font pour les entêtes des colonnes
            Font font = new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD);

            // Génère les rangées de la facture
            foreach (var gc in OpererFacture.Gabarit.GabaritCriteres)
            {
                if (gc.EstUtilise)
                {
                    // Création de la cellule de l'entête
                    var phrase = new Phrase(gc.Critere.Titre, font);
                    var cell = new PdfPCell(phrase) { Padding = 5 };
                    table.AddCell(cell);
                }
            }

            foreach (var pf in LaFacture.LstProduitFacture)
            {
                foreach (var gc in OpererFacture.Gabarit.GabaritCriteres)
                {
                    if (gc.EstUtilise)
                    {
                        // Garde en mémoire les cellules de la rangée du produit
                        switch (gc.Critere.Titre)
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
                            case "Nombre d'heures":
                                // TODO
                                break;
                            case "Taux Horaire":
                                // TODO
                                break;
                        }
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
