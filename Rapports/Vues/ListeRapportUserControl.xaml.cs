using Facturio.Rapports.Entities;
using Facturio.Rapports.Hibernate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Logique d'interaction pour ListeRapport.xaml
    /// </summary>
    public partial class ListeRapportUserControl : UserControl
    {
        public static DataGrid DtgRapports { get; set; }

        //public ObservableCollection<Rapport> LstRapport { get; set; }
        public ListeRapportUserControl()
        {
            InitializeComponent();
            DtgRapports = dtgAfficherRapport;

            RapportController.LstRapport = new ObservableCollection<Rapport>(HibernateRapportService.RetrieveAll());

            DtgRapports.ItemsSource = RapportController.LstRapport;
        }

        private void dtgAfficherRapport_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window w = new DetailRapport((Rapport)DtgRapports.SelectedItem);
            w.Show();
        }
    }
}
