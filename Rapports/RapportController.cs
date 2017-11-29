using Facturio.Base;
using Facturio.Rapports.Entities;
using Facturio.Rapports.Hibernate;
using Facturio.Rapports.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Facturio.Factures;
using Facturio.Produits;
using Facturio.ProduitsFactures;
using System.IO;
using Facturio.RapportsFactures;

namespace Facturio.Rapports
{
    public class RapportController : BaseViewModel, IOngletViewModel
    {
        //public static IList<Rapport> LstRapport { get; set; }
        public static ListeRapportUserControl RapportUserControl { get; set; } = new ListeRapportUserControl();

        public static ObservableCollection<Rapport> LstRapport { get; set; } = new ObservableCollection<Rapport>();

        public string Titre { get; set; }

        public RapportController()
        {
            Titre = "Rapports";
        }

        public static void CreerPDF(Rapport rapport, string nomPDF)
        {
            string nomClient = rapport.LstRapportFacture[0].Facture.LeClient.Nom;
            string prenomClient = rapport.LstRapportFacture[0].Facture.LeClient.Prenom;
            string header = "Factures de " + prenomClient + " " + nomClient;
            
            FileStream fs = new FileStream(nomPDF + ".pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            document.Open();
            Paragraph para = new Paragraph(0,header);
            para.SpacingAfter = 40;

            document.Add(para);
            foreach (RapportFacture rf in rapport.LstRapportFacture)
            {
                PdfPTable tableau = new PdfPTable(4);
                PdfPCell cellule = new PdfPCell();

                tableau.AddCell("Produit");
                tableau.AddCell("Quantité");
                tableau.AddCell("Prix");
                tableau.AddCell("Sous-Total");

                foreach (ProduitFacture p in rf.Facture.LstProduitFacture)
                {
                    tableau.AddCell(p.Produit.Nom.ToString());
                    tableau.AddCell(p.Quantite.ToString());
                    tableau.AddCell(p.Produit.Prix.ToString()+"$");
                    tableau.AddCell(p.SousTotal.ToString()+"$");
                }

                
                tableau.SpacingAfter = 20;
                document.Add(tableau);
            }
            document.Close();
        }

        /// <summary>
        /// Avec les factures et le rapport courant, je créer ma liste de RapportFacture pcq NHibernate ne le fait pas 
        /// </summary>
        /// <param name="lstFacture">La liste de facture</param>
        /// <param name="rapport">Le rapport</param>
        /// <returns>Une liste de type RapportFacture</returns>
        public static List<RapportFacture> ConstruireRapportFacture(List<Facture> lstFacture, Rapport rapport)
        {
            ObservableCollection<RapportFacture> listRapportFacture = new ObservableCollection<RapportFacture>();

            for (int i = 0; i <= lstFacture.Count - 1; i++)
            {
                listRapportFacture.Add(new RapportFacture(rapport, lstFacture[i]));
            }
            return listRapportFacture.ToList();
        }

        public static void InsertRapportFacture(List<RapportFacture> lstRF)
        {
            foreach (RapportFacture rf in lstRF)
            {
                HibernateRapportFactureService.Create(rf);
            }
        }

    }
}
