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

namespace Facturio.Rapports
{
    public class RapportController : BaseViewModel, IOngletViewModel
    {
        //public static ISet<Rapport> LstRapport { get; set; }
        public static ListeRapportUserControl RapportUserControl { get; set; } = new ListeRapportUserControl(); 

        

        public string Titre { get; set; }

        public RapportController()
        {
            Titre = "Rapports";
            //LstRapport = new HashSet<Rapport>(HibernateRapportService.RetrieveAll());

            
        }

        public static void CreerPDF(Rapport rapport)
        {
            string nomClient = rapport.LstFacture[0].LeClient.Nom;
            string prenomClient = rapport.LstFacture[0].LeClient.Prenom;
            string header = "Factures de " + prenomClient + " " + nomClient;
            int compteur = 0;
            FileStream fs = new FileStream("RapportFacturationCliente.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            document.Add(new Paragraph(0,header));

            foreach (Facture f in rapport.LstFacture)
            {
                
                PdfPTable tableau = new PdfPTable(3);
                PdfPCell cellule = new PdfPCell();

                foreach (ProduitFacture p in f.LstProduit)
                {
                    tableau.AddCell(p.Produit.Nom.ToString());
                    tableau.AddCell(p.Quantite.ToString());
                    tableau.AddCell(p.Produit.Prix.ToString());
                }

                document.Add(tableau);
                document.NewPage();
            }

            document.Close();
            
        }

    }
}
