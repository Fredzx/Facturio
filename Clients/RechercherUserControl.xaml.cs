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

namespace Facturio.Clients
{
    /// <summary>
    /// Logique d'interaction pour RechercherUserControl.xaml
    /// </summary>
    public partial class RechercherUserControl : UserControl
    {
        public RechercherUserControl()
        {
            InitializeComponent();

            ClientsController.ChargerListeClients();
            dtgAfficheClients.ItemsSource = ClientsController.LstClients;
        }


        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = ((e.Row.GetIndex()) + 1).ToString();

        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
           // TabIndexProperty.SelectedIndex = 1;

        }

    }
}
