using Facturio.Rapports.Entities;
using Facturio.Rapports.Hibernate;
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
    /// Logique d'interaction pour ListeRapport.xaml
    /// </summary>
    public partial class ListeRapportUserControl : UserControl
    {
        public static DataGrid DtgRapports { get; set; }

        public List<Rapport> LstRapport { get; set; } = new List<Rapport>();
        //public virtual Rapport Rapport1 { get; set; } = new Rapport("Charles Bélisle", new DateTime(2017, 02, 01, 08, 00, 00),new List<Factures.Facture>(), "Facturation Cliente");
        //public virtual Rapport Rapport2 { get; set; } = new Rapport("Yannick Charron", new DateTime(2017, 03, 01, 08, 00, 00), new List<Factures.Facture>(), "Facturation Cliente");
        //public virtual Rapport Rapport3 { get; set; } = new Rapport("",new DateTime(2017, 04, 01, 08, 00, 00), new List<Factures.Facture>(), "Sommaire");
        //public virtual Rapport Rapport4 { get; set; } = new Rapport("",new DateTime(2017, 05, 01, 08, 00, 00), new List<Factures.Facture>(), "Sommaire");

        public ListeRapportUserControl()
        {
            InitializeComponent();
            DtgRapports = dtgAfficherRapport;
            //DtgRapports.ItemsSource = HibernateRapportService.RetrieveAll();
            

            //LstRapport.Add(Rapport1);
            //LstRapport.Add(Rapport2);
            //LstRapport.Add(Rapport3);
            //LstRapport.Add(Rapport4);
            DtgRapports.ItemsSource = LstRapport;
            //Rapport1.LstFacture.Add(new Factures.Facture(new Clients.Client()))
        }

        private void dtgAfficherRapport_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = ((e.Row.GetIndex()) + 1).ToString();
        }

        private void dtgAfficherRapport_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
