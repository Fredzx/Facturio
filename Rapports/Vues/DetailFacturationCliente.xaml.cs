using Facturio.Clients;
using Facturio.Factures;
using Facturio.Produits;
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
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int? IdClient { get; set; }
        public Produit DetailProduit  { get; set; }
        public ObservableCollection<Facture> LstFacture { get; set; }
        public static int compteur = 0;

        public DetailFacturationCliente(DateTime dateDebut, DateTime dateFin, Client leClient)
        {
            InitializeComponent();

            DateDebut = dateDebut;
            DateFin = dateFin;
            IdClient = leClient.IdClient;
            LstFacture = new ObservableCollection<Facture>(HibernateFactureService.RetrieveFacturationCliente(dateDebut, DateFin, 1));
            dtgProduits.ItemsSource = LstFacture[compteur].LstProduit;
        }
        
       

        private void Button_Click_Precedent(object sender, RoutedEventArgs e)
        {
            if (compteur < 0)
                compteur = LstFacture.Count;
            else
                compteur--;
        }

        private void Button_Click_Suivant(object sender, RoutedEventArgs e)
        {
            if (compteur > LstFacture.Count)
                compteur = 0;
            else
                compteur++;
               
            
        }
    }

}
