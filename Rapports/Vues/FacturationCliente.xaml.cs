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
            dtgAfficherClient.ItemsSource = LstClient;

            CalendarUI.ButtonClick += ObtenirDate;
        }

        private void ObtenirDate(object sender, DateEventArgs e)
        {
            Window detailFacturationCliente = new DetailFacturationCliente(e.DateDebut, e.DateFin, (Client)dtgAfficherClient.SelectedItem);
            detailFacturationCliente.Show();
        }

        private void dtgAfficherClient_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = ((e.Row.GetIndex()) + 1).ToString();
        }



    }
}
