using Facturio.Clients;
using Facturio.Factures;
using Facturio.Produits;
using Facturio.ProduitsFactures;
using Facturio.Rapports.Entities;
using Facturio.Rapports.Hibernate;
using Facturio.RapportsFactures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Facturio.Rapports.Vues
{
    /// <summary>
    /// Logique d'interaction pour DetailFacturationCliente.xaml
    /// </summary>
    public partial class DetailRapport : Window
    {
        const double TPS = 0.09975;
        const double TVQ = 0.05000;

        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public DateTime DateRapport { get; set; }
        public int? IdClient { get; set; }
        public Produit Produit { get; set; }
        public ObservableCollection<RapportFacture> LstFacture { get; set; }
        public ObservableCollection<ProduitFacture> LstProduitFacture { get; set; }
        public int compteur = 0;
        public DataGrid DtgProduit { get; set; }
        public string ObjetRapport { get; set; }
        Produit ProduitRapport { get; set; }

        StackPanel StpInfoFacture { get; set; }

        public decimal Total { get; set; }

        //public DetailFacturationCliente(DateTime dateDebut, DateTime dateFin, Client leClient)
        //{
        //    InitializeComponent();

        //    DtgProduit = dtgProduits;
        //    DateDebut = dateDebut;
        //    DateFin = dateFin;
        //    LstFacture = new ObservableCollection<Facture>(HibernateFactureService.RetrieveFacturationCliente(dateDebut, DateFin, leClient));

        //    RafraichirData(true);
        //}

        public DetailRapport(List<RapportFacture> lstFacture, DateTime dateRapport)
        {
            InitializeComponent();

            DtgProduit = dtgProduits;
            LstFacture = new ObservableCollection<RapportFacture>(lstFacture);
            DateDebut = TrouverIntervalleDate(LstFacture.ToList(), true);
            DateFin = TrouverIntervalleDate(LstFacture.ToList(), false);
            lblDateGeneration.Content = dateRapport.ToString();
            RafraichirData();
        }

        public DetailRapport(Rapport rapport)
        {
            InitializeComponent();

            if (rapport is RapportSommaire)
            {
                
            }

            DtgProduit = dtgProduits;
            LstFacture = new ObservableCollection<RapportFacture>(rapport.LstRapportFacture);
            DateDebut = TrouverIntervalleDate(LstFacture.ToList(), true);
            DateFin = TrouverIntervalleDate(LstFacture.ToList(), false);
            lblInfoRapport.Content = "Voici les factures entre le " + DateDebut + " et " + DateFin;
            lblDateGeneration.Content = rapport.Date.ToString();
            RafraichirData();
        }
        /// <summary>
        /// Constructeur de details si le rapport est un FacturationVenteProduit
        /// </summary>
        /// <param name="rapport">Le Rapport</param>
        /// <param name="produit">Le produit concerné</param>
        public DetailRapport(Rapport rapport, Produit produit)
        {
            InitializeComponent();
            Produit = produit;

            DtgProduit = dtgProduits;
            LstFacture = new ObservableCollection<RapportFacture>(rapport.LstRapportFacture);
            DateDebut = TrouverIntervalleDate(LstFacture.ToList(), true);
            DateFin = TrouverIntervalleDate(LstFacture.ToList(), false);
            lblInfoRapport.Content = "Voici les factures entre le \n" + DateDebut + " et " + DateFin + "\nContenant le produit " + Produit.Nom;
            StpInfoFacture = stpInfoFacture;
            CreerNbFoisVendu(LstFacture.ToList());
            AfficherArgentFaitAvecProduit(LstFacture.ToList());
            lblDateGeneration.Content = rapport.Date.ToString();
            RafraichirData();
        }

        private DateTime? TrouverIntervalleDate(List<RapportFacture> lstFacture, bool trouverBorneInferieur)
        {
            DateTime? date = lstFacture[0].Facture.Date;

            // Si vrai, on veut trouver la borne INFÉRIEUR de l'intervalle des factures
            if (trouverBorneInferieur)
            {
                foreach (RapportFacture rf in lstFacture)
                {
                    if (rf.Facture.Date < date)
                        date = rf.Facture.Date;
                }
            }
            else
            {
                foreach (RapportFacture rf in lstFacture)
                {
                    if (rf.Facture.Date > date)
                        date = rf.Facture.Date;
                }
            }
            return date;
        }

        private void Button_Click_Precedent(object sender, RoutedEventArgs e)
        {
            if (compteur <= 0)
                compteur = LstFacture.Count - 1;
            else
                compteur--;

            RafraichirData();
        }

        private void Button_Click_Suivant(object sender, RoutedEventArgs e)
        {
            if (compteur >= LstFacture.Count - 1)
                compteur = 0;
            else
                compteur++;

            RafraichirData();
        }

        public decimal CalculerSousTotal()
        {
            decimal total = 0;

            foreach (ProduitFacture p in LstFacture[compteur].Facture.LstProduitFacture)
            {
                total += ((decimal)p.Quantite* (decimal)p.Produit.Prix);
            }

            return total;
        }

        public decimal CalculerTaxes(double taxe)
        {
            return (CalculerSousTotal() * (decimal)taxe);
        }   

        public decimal CalculerTotal()
        {
            return (CalculerSousTotal() + CalculerTaxes(TPS) + CalculerTaxes(TVQ));
        }

        public void RafraichirData()
        {
            if (LstFacture != null && LstFacture.Count != 0)
            {
                DtgProduit.ItemsSource = LstFacture[compteur].Facture.LstProduitFacture;
                lblNoFacture.Content = (compteur + 1).ToString() + "/" + LstFacture.Count;
                Total = 0;

                DtgProduit.Items.Refresh();

                txtSousTotal.Content = Math.Round(CalculerSousTotal(), 2).ToString() + "$";
                txtTPS.Content = Math.Round(CalculerTaxes(TPS), 2).ToString() + "$";
                txtTVQ.Content = Math.Round(CalculerTaxes(TVQ), 2).ToString() + "$";
                txtTotal.Content = Math.Round(CalculerTotal(), 2).ToString() + "$";
            }
            else
            {
                lblInfo.Foreground = Brushes.Red;
                lblInfo.Content = "Aucune facture pour la date du " + DateDebut + " au " + DateFin;
                btnPrecedent.IsEnabled = false;
                btnSuivant.IsEnabled = false;
            }
        }

        public List<Facture> ConstruireFactures()
        {
            List<Facture> lstFacture = new List<Facture>();

            foreach (ProduitFacture pf in LstProduitFacture)
            {
                lstFacture.Add(pf.Facture);
            }
            return lstFacture;
        }

        private void CreerNbFoisVendu(List<RapportFacture> lstRF)
        {
            Label textBlock = new Label();
            Label label = new Label();
            StackPanel stp = new StackPanel();
            stp.Orientation = Orientation.Horizontal;
            stp.VerticalAlignment = VerticalAlignment.Center;

            label.Content = "Nombre de fois vendu";

            textBlock.Content = CalculerNBFoisVendu(lstRF);
            StpInfoFacture.Children.Add(stp);
            StpInfoFacture.Children.Add(label);
            StpInfoFacture.Children.Add(textBlock);
        }

        private string CalculerNBFoisVendu(List<RapportFacture> list)
        {
            float compteur = 0;

            foreach (RapportFacture rf in list)
            {
                foreach (ProduitFacture pf in rf.Facture.LstProduitFacture)
                {
                    if (pf.Produit.Id == Produit.Id)
                        compteur+= pf.Quantite;
                }
            }
            return compteur.ToString();
        }

        private void AfficherArgentFaitAvecProduit(List<RapportFacture> lstRF)
        {
            Label textBlock = new Label();
            Label label = new Label();
            StackPanel stp = new StackPanel();
            stp.Orientation = Orientation.Horizontal;
            stp.VerticalAlignment = VerticalAlignment.Center;

            label.Content = "Ce produit vous à rapporter:";

            textBlock.Content = CalculerTotalArgentProduit(lstRF);
            StpInfoFacture.Children.Add(stp);
            StpInfoFacture.Children.Add(label);
            StpInfoFacture.Children.Add(textBlock);
        }

        private string CalculerTotalArgentProduit(List<RapportFacture> list)
        {
            decimal compteur = 0;

            foreach (RapportFacture rf in list)
            {
                foreach (ProduitFacture pf in rf.Facture.LstProduitFacture)
                {
                    if (pf.Produit.Id == Produit.Id)
                        compteur += (decimal)(pf.Produit.Prix*pf.Quantite);
                }
            }
            return compteur.ToString()+"$";
        }
    }
}
