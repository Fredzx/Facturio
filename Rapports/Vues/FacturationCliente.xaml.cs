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
        }
    }
}
