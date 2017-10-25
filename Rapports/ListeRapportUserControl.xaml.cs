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

namespace Facturio.Rapports
{
    /// <summary>
    /// Logique d'interaction pour ListeRapport.xaml
    /// </summary>
    public partial class ListeRapportUserControl : UserControl
    {
        public static DataGrid DtgRapports { get; set; }
        public ListeRapportUserControl()
        {
            InitializeComponent();
            DtgRapports = dtgAfficherRapport;
            DtgRapports.ItemsSource = HibernateRapportService.RetrieveAll();
        }

        private void dtgAfficherRapport_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DtgRapports = dtgAfficherRapport;
        }
    }
}
