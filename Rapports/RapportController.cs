using Facturio.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Rapports
{
    class RapportController : BaseViewModel, IOngletViewModel
    {
        public static IList<Rapport> LstRapport { get; set; }
        //public static IList<Factures.Facture> LstFacture { get; set; } 

        public string Titre { get; set; }

        public RapportController()
        {
            Titre = "Rapports";
            LstRapport = new ObservableCollection<Rapport>(HibernateRapportService.RetrieveAll());
            //LstFacture = new ObservableCollection<Factures.Facture>(Facturio.Factures.HibernateFactureService.RetrieveAll());
        }
    }
}
