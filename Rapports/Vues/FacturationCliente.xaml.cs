using Facturio.Clients;
using Facturio.Factures;
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
                RFC.LstRapportFacture = new ObservableCollection<RapportFacture>(HibernateRapportFactureService.RetrieveFacturationCliente(cldDateDebut.SelectedDate.Value,
                                                       cldDateFin.SelectedDate.Value,
                                                       (Client)dtgAfficherClient.SelectedItem));

                RFC.LeClient = (Client)dtgAfficherClient.SelectedItem;
                RFC.Date = DateTime.Now;
               // RapportController.CreerPDF(RFC);
            }
        }

        private void btnObtenirRapport_Click(object sender, RoutedEventArgs e)
        {
            RapportFacturationCliente RFC = new RapportFacturationCliente();

            if (Valider())
            {
                List<Facture> lstFactureLocal = new List<Facture>(HibernateFactureService.RetrieveFacturationCliente(cldDateDebut.SelectedDate.Value,
                                                                                           cldDateFin.SelectedDate.Value,
                                                                                           (Client)dtgAfficherClient.SelectedItem));
                RFC.Date = DateTime.Now;

                Window detailFacturationCliente = new DetailRapport(RapportController.ConstruireRapportFacture(lstFactureLocal,RFC));
                // ici, je créer un Rapport en BD, mais SANS sa liste de RapportFacture, Sans cela,
                // la liste de RapportFacture essaie de faire référence au rapport mais le rapport n'a pas son ID, donc sa plante
                // C'est bizzare mais ça fonctionne
                HibernateRapportFacturationCliente.Create(RFC);
                detailFacturationCliente.Show();
                
                // Après avoir créer le rapport en BD, on a son ID. Maintenant on peut créer les RapportFactures, 
                RFC.LstRapportFacture = RapportController.ConstruireRapportFacture(lstFactureLocal, RFC);
                RapportController.InsertRapportFacture(RFC.LstRapportFacture.ToList());
                RapportController.LstRapport.Add(RFC);

            }
        }

        //public void InsertRapportFacture(List<RapportFacture> lstRF)
        //{
        //    foreach (RapportFacture rf in lstRF)
        //    {
        //        HibernateRapportFactureService.Create(rf);
        //    }
        //}
        /// <summary>
        /// Avec les factures et le rapport courant, je créer ma liste de RapportFacture pcq NHibernate ne le fait pas 
        /// </summary>
        /// <param name="lstFacture">La liste de facture</param>
        /// <param name="rapport">Le rapport</param>
        /// <returns>Une liste de type RapportFacture</returns>
        //public List<RapportFacture>ConstruireRapportFacture(List<Facture> lstFacture, Rapport rapport)
        //{
        //    ObservableCollection<RapportFacture> listRapportFacture = new ObservableCollection<RapportFacture>();

        //    for (int i = 0; i < lstFacture.Count-1; i++)
        //    {
        //        listRapportFacture.Add(new RapportFacture(rapport,lstFacture[i]));
        //    }
        //    return listRapportFacture.ToList();
        //}

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
