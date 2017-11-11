using Facturio.Rapports.Entities;
using Facturio.Rapports.Hibernate;
using System;
using System.Collections;
using System.Collections.Generic;
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

        public List<Rapport> LstRapport { get; set; } = new List<Rapport>();
        //public List<AccueilRapport> LstRapportss { get; set; }
        public ListeRapportUserControl()
        {
            InitializeComponent();
            DtgRapports = dtgAfficherRapport;

            LstRapport = HibernateRapportService.RetrieveAll();

            DtgRapports.ItemsSource = LstRapport;
            
        }

        private void dtgAfficherRapport_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = ((e.Row.GetIndex()) + 1).ToString();
        }

        private void dtgAfficherRapport_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        //public struct AccueilRapport
        //{
        //    public string TypeRapport { get; set; }
        //    public string Client { get; set; }
        //    public DateTime Date { get; set; }
        //    public List<Rapport> MesRapports;

            
        //    public AccueilRapport(string tr, string client, DateTime date) {

        //        TypeRapport = r.GetTypeRapport();
        //        Date = r.Date;
        //        Client = client;
        //        MesRapports = HibernateRapportService.RetrieveAll();

        //        foreach (Rapport r in MesRapports)
        //        {
        //            TypeRapport = r.GetTypeRapport();
        //            Date = r.Date;
        //            Client = client;
        //            AccueilRapport AR = new AccueilRapport(tr, "", Date);
        //        }

        //    }

        //    public List<AccueilRapport> AfficherTypeRapport()
        //    {
        //        List<AccueilRapport> lstRapport = new List<AccueilRapport>();

        //        foreach (Rapport r in MesRapports)
        //        {
        //            TypeRapport = r.GetTypeRapport();
        //            Date = r.Date;
        //            AccueilRapport AR = new AccueilRapport(TypeRapport, "", Date);
        //        }

        //        return lstRapport;
        //    }
        //}
    }
}
