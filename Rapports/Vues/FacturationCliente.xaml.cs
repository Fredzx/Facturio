using Facturio.Clients;
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

        }

        private void ObtenirDate(object sender, DateEventArgs e)
        {
            if (dtgAfficherClient.SelectedIndex != -1)
            {
                Window detailFacturationCliente = new DetailFacturationCliente(e.DateDebut, e.DateFin, (Client)dtgAfficherClient.SelectedItem);
                detailFacturationCliente.Show();
            }
        }

        private void btnRapportPDF_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObtenirRapport_Click(object sender, RoutedEventArgs e)
        {
            if (!Valider())
            {
                Window detailFacturationCliente = new DetailFacturationCliente(cldDateDebut.SelectedDate.Value, cldDateFin.SelectedDate.Value, (Client)dtgAfficherClient.SelectedItem);
                detailFacturationCliente.Show();
            }

        }

        private void btnObtenirRapport_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private bool Valider()
        {
            if(cldDateDebut.SelectedDate.Value == DateTime.MinValue)
            {
                MessageBox.Show("Vous devez sélectionner une date de début");
                return false;        
            }

            if (cldDateDebut.SelectedDate.Value > DateTime.Now)
            {
                MessageBox.Show("Vous devez choisir une date plus petite qu'aujourd'hui");
                return false;
            }

            if (cldDateFin.SelectedDate.Value == DateTime.MinValue)
            {
                MessageBox.Show("Vous devez sélectionner une date de fin");
                return false;
            }

            if(dtgAfficherClient.SelectedIndex == -1)
            {
                MessageBox.Show("Vous devez sélectionner un client");
                return false;
            }

            return true;
        }

        private void cldDateDebut_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            btnObtenirRapport.IsEnabled = true;
        }
    }
}
