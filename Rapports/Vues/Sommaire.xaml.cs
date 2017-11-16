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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Facturio.Rapports.Vues
{
    /// <summary>
    /// Interaction logic for Sommaire.xaml
    /// </summary>
    public partial class Sommaire : UserControl
    {
        public DataGrid DtgSommaire { get; set; }

        public Produit MonProduit { get; set; }
        public int NbFoisVendu { get; set; }
        public decimal PrixVente { get; set; }
        public decimal Total { get; set; }


        public ObservableCollection<Facture> LstFacture { get; set; }

        public Sommaire()
        {
            InitializeComponent();

            DtgSommaire = dtgSommaire;
            //ButtonClick += ListerSommaire;
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = ((e.Row.GetIndex()) + 1).ToString();
        }

        private void ListerSommaire()
        {
            LstFacture = new ObservableCollection<Facture>(HibernateFactureService.RetrieveSommaire(cldDateDebut.SelectedDate.Value, cldDateFin.SelectedDate.Value));
            DtgSommaire.ItemsSource = LstFacture;
        }

        private void btnObtenirRapport_Click(object sender, RoutedEventArgs e)
        {
            ListerSommaire();
        }

        private void btnRapportPDF_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
