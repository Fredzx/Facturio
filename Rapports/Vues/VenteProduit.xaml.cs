using Facturio.Factures;
using Facturio.Produits;
using Facturio.ProduitsFactures;
using Facturio.Rapports.Entities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Facturio.Rapports.Vues
{
    /// <summary>
    /// Interaction logic for VenteProduit.xaml
    /// </summary>
    public partial class VenteProduit : UserControl
    {
        ObservableCollection<Produit> LstProduit { get; set; } = ProduitsController.Produits;
        ObservableCollection<Facture> lstFacture = new ObservableCollection<Facture>();

        public VenteProduit()
        {
            InitializeComponent();
            
            dtgAfficheProduit.ItemsSource = LstProduit;
            btnObtenirRapport.IsEnabled = false;
            cldDateFin.SelectedDate = DateTime.Now;
        }

        private void btnObtenirRapport_Click(object sender, RoutedEventArgs e)
        {
            Produit produit = (Produit)dtgAfficheProduit.SelectedItem;

            List<Facture> LstFacture = HibernateFactureService.RetrieveBetweenDates(cldDateDebut.SelectedDate.Value,
                                                                                    cldDateFin.SelectedDate.Value);

            List<Facture> LstFactureFiltrer = FiltrerListeSelonProduit(LstFacture, (Produit)dtgAfficheProduit.SelectedItem);

            RapportVenteProduit RVP = new RapportVenteProduit();
            RVP.Date = DateTime.Now;
            RVP.LstFacture = new HashSet<Facture>(LstFactureFiltrer);

            if (Valider())
            {
                Window detailFacturationCliente = new DetailRapport(LstFactureFiltrer);
                detailFacturationCliente.Show();
                Hibernate.HibernateRapportVenteProduit.Create(RVP);
            }
        }

        public List<Facture> FiltrerListeSelonProduit(List<Facture> lstFacture, Produit produit)
        {
            List<Facture> lstFactureFiltre = new List<Facture>();

            foreach (Facture f in lstFacture)
            {
                foreach (ProduitFacture pf in f.LstProduitFacture)
                {
                    if (pf.Produit.Id == produit.Id)
                        lstFactureFiltre.Add(f);
                }
            }

            return lstFactureFiltre;
        }

        public List<Facture> RetrouverListeFacture(DateTime dateDebut, DateTime dateFin, Produit produit)
        {
            List<Facture> lstFacture = new List<Facture>();
            List<ProduitFacture> lstProduitFacture = HibernateProduitFacturesService.RetrieveProduit(produit.Id);

            foreach (ProduitFacture pf in lstProduitFacture)
            {
                lstFacture.Add(pf.Facture);
            }
            return lstFacture;
        }

        public void RetrouverListeRapportFacture(RapportVenteProduit RVP ,List<Facture> list)
        {
            //foreach (Facture f in list)
            //{
            //    RVP.LstFacture.Add(f);
            //}
        }

        private bool Valider()
        {
            if (cldDateDebut.SelectedDate.Value == DateTime.MinValue)
            {
                AfficherErreur(1); return false;
            }

            if (cldDateFin.SelectedDate.Value == DateTime.MinValue)
            {
                AfficherErreur(2); return false;
            }

            if (cldDateDebut.SelectedDate.Value > DateTime.Now)
            {
                AfficherErreur(3); return false;
            }

            if (cldDateFin.SelectedDate.Value > DateTime.Now)
            {
                AfficherErreur(4); return false;
            }

            if (cldDateDebut.SelectedDate.Value > cldDateFin.SelectedDate.Value)
            {
                AfficherErreur(5); return false;
            }

            

            return true;
        }

        public void AfficherErreur(int noErreur)
        {
            lblInfoErreur.Foreground = Brushes.Red;

            switch (noErreur)
            {
                case 1: lblInfoErreur.Content = "Vous devez sélectionner une date de début"; break;
                case 2: lblInfoErreur.Content = "Vous devez sélectionner une date de fin"; break;
                case 3: lblInfoErreur.Content = "La date de début doit être plus petite qu'aujourd'hui"; break;
                case 4: lblInfoErreur.Content = "La date de fin doit être plus petite qu'aujourd'hui"; break;
                case 5: lblInfoErreur.Content = "La date de début doit être plus petite que la date de fin"; break;
                case 6: lblInfoErreur.Content = "Vous devez sélectionner un client"; break;
                default:
                    break;
            }
        }



        private void cldDateDebut_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            btnObtenirRapport.IsEnabled = true;

        }

        private void btnRapportPDF_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
