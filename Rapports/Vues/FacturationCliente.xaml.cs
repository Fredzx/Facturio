using Facturio.Clients;
using Facturio.Factures;
using Facturio.Rapports.Entities;
using Facturio.Rapports.Hibernate;
using Facturio.RapportsFactures;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for FacturationCliente.xaml
    /// </summary>
    public partial class FacturationCliente : UserControl
    {
        public IList<Client> LstClient { get; set; }

        public FacturationCliente()
        {
            InitializeComponent();

            LstClient = ClientsController.LstObClients;
            dtgAfficherClient.ItemsSource = ClientsController.LstObClients;
            btnObtenirRapport.IsEnabled = false;
            btnRapportPDF.IsEnabled = false;
            dtgAfficherClient.SelectedIndex = 0;
            cldDateFin.SelectedDate = DateTime.Now;
        }

        private void btnRapportPDF_Click(object sender, RoutedEventArgs e)
        {
            RapportFacturationCliente RFC = new RapportFacturationCliente();
           

            if (Valider())
            {
                RFC.LstFacture = new HashSet<Facture>(HibernateFactureService.RetrieveFacturationCliente(cldDateDebut.SelectedDate.Value,
                                                       cldDateFin.SelectedDate.Value,
                                                       (Client)dtgAfficherClient.SelectedItem));

                RFC.LeClient = (Client)dtgAfficherClient.SelectedItem;
                RFC.Date = DateTime.Now;
                RapportController.CreerPDF(RFC);
            }
        }

        private void btnObtenirRapport_Click(object sender, RoutedEventArgs e)
        {
            RapportFacturationCliente RFC = new RapportFacturationCliente();
            
            if (Valider())
            {
                RFC.LstFacture = new HashSet<Facture>(HibernateFactureService.RetrieveFacturationCliente(cldDateDebut.SelectedDate.Value,
                                                                                           cldDateFin.SelectedDate.Value,
                                                                                           (Client)dtgAfficherClient.SelectedItem));

                RFC.LeClient = (Client)dtgAfficherClient.SelectedItem;
                RFC.Date = DateTime.Now;

                List<Facture> lstFactureLocal = new List<Facture>(RFC.LstFacture);
                Window detailFacturationCliente = new DetailRapport(lstFactureLocal);
                detailFacturationCliente.Show();
                HibernateRapportFacturationCliente.Create(RFC);
            }

        }

        private bool Valider()
        {
            if(cldDateDebut.SelectedDate.Value == DateTime.MinValue)
            {
                AfficherErreur(1); return false;        
            }

            if (cldDateFin.SelectedDate.Value == DateTime.MinValue)
            {
                AfficherErreur(2); return false;
            }

            if (cldDateDebut.SelectedDate.Value > DateTime.Now )
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

            if (dtgAfficherClient.SelectedIndex == -1)
            {
                AfficherErreur(6); return false;
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
            btnRapportPDF.IsEnabled = true;
        }
    }
}
