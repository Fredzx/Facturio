using Facturio.Clients;
using Facturio.Factures;
using Facturio.Produits;
using Facturio.ProduitsFactures;
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
    public partial class DetailFacturationCliente : Window
    {
        const double TPS = 0.09975;
        const double TVQ = 0.05000;

        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int? IdClient { get; set; }
        public Produit DetailProduit { get; set; }
        public ObservableCollection<Facture> LstFacture { get; set; }
        public int compteur = 0;
        public DataGrid DtgProduit { get; set; }

        public DetailFacturationCliente(DateTime dateDebut, DateTime dateFin, Client leClient)
        {
            InitializeComponent();

            DtgProduit = dtgProduits;
            DateDebut = dateDebut;
            DateFin = dateFin;
            IdClient = leClient.IdClient;
            LstFacture = new ObservableCollection<Facture>(HibernateFactureService.RetrieveFacturationCliente(dateDebut, DateFin, IdClient));
            DtgProduit.ItemsSource = LstFacture[compteur].LstProduit;
            lblNoFacture.Content = (compteur + 1).ToString() + "/" + LstFacture.Count;
            txtSousTotal.Text = Math.Round(CalculerSousTotal(),2).ToString() + "$";
            txtTPS.Text = Math.Round(CalculerTaxes(TPS),2).ToString() + "$";
            txtTVQ.Text = Math.Round(CalculerTaxes(TVQ),2).ToString() + "$";
            txtTotal.Text = Math.Round(CalculerTotal(),2).ToString() + "$";
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
        private void CalculerSousTotalLigne(int index)
        {

        }

        public decimal CalculerSousTotal()
        {
            decimal total = 0;

            foreach (ProduitFacture p in LstFacture[compteur].LstProduit)
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
            DtgProduit.ItemsSource = LstFacture[compteur].LstProduit;
            lblNoFacture.Content = (compteur + 1).ToString() + "/" + LstFacture.Count;
            DtgProduit.Items.Refresh();

            txtSousTotal.Text = Math.Round(CalculerSousTotal(), 2).ToString() + "$";
            txtTPS.Text = Math.Round(CalculerTaxes(TPS), 2).ToString() + "$";
            txtTVQ.Text = Math.Round(CalculerTaxes(TVQ), 2).ToString() + "$";
            txtTotal.Text = Math.Round(CalculerTotal(), 2).ToString() + "$";
        }
    }

    
}
